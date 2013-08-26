using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudHogwarts_WebRole.StudentWorks.StudentHome
{
    public class Record
    {
        public string Semester { get; set; }
        public int CourseID { get; set; }
        public string Discipline { get; set; }
        public int CreditNumber { get; set; }
        public string CourseGPA { get; set; }
        public Record(string Semester, int CourseID, string Discipline, int CreditNumber, string CourseGPA)
        {
            this.Semester = Semester;
            this.CourseID = CourseID;
            this.Discipline = Discipline;
            this.CreditNumber = CreditNumber;
            this.CourseGPA = CourseGPA;
        }
    }

    public partial class Transcript : System.Web.UI.Page
    {
        public int TotalCredits;
        public double TotalGPA;
        private Dictionary<int, double> TD;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 1)
                Response.Redirect("~/StaffWorks/StaffHome/StaffProfile.aspx");
            if (!Page.IsPostBack)
            {
                DropDownList1.Items.Add(new ListItem("All"));
                HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
                List<Semester> Semesters = (from s in db.Semesters
                                            select s).ToList<Semester>();
                for (int i = 0; i < Semesters.Count; i++)
                    DropDownList1.Items.Add(Semesters[i].Time);
                db.Connection.Close();
            }
        }

        protected Boolean less(string semester1, string semester2)
        {
            string season1 = semester1.Substring(0, semester1.IndexOf(" "));
            int year1 = Convert.ToInt32(semester1.Substring(semester1.IndexOf(" ") + 1, semester1.Length - semester1.IndexOf(" ") - 1));

            string season2 = semester2.Substring(0, semester2.IndexOf(" "));
            int year2 = Convert.ToInt32(semester2.Substring(semester2.IndexOf(" ") + 1, semester2.Length - semester2.IndexOf(" ") - 1));

            if (year2 > year1) return true;
            if (year2 < year1) return false;
            if (season1 == season2) return false;
            if (season1 == "Winter") return true;
            if (season2 == "Winter") return false;
            if (season1 == "Spring") return true;
            if (season2 == "Spring") return false;
            if (season1 == "Summer") return true;
            return false;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("./StudentProfile.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
            int StudentID = (int)Session["StudentID"];

            List<StudentInCourse> result = (from sic in db.StudentInCourses
                                            where sic.StudentID == StudentID
                                            select sic).ToList<StudentInCourse>();

            List<List<StudentInCourse>> lst = new List<List<StudentInCourse>>();
            for (int i = 0; i < result.Count; i++)
            {
                Boolean found = false;
                for (int j = 0; j < lst.Count; j++)
                {
                    if (lst[j][0].Course.SemesterID == result[i].Course.SemesterID)
                    {
                        lst[j].Add(result[i]);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    List<StudentInCourse> NewLst = new List<StudentInCourse>();
                    NewLst.Add(result[i]);
                    lst.Add(NewLst);
                }
            }

            //sort the semesters
            for (int i = 0; i < lst.Count - 1; i++)
                for (int j = i + 1; j < lst.Count; j++)
                {
                    if (!less(lst[i][0].Course.Semester.Time, lst[j][0].Course.Semester.Time))
                    {
                        List<StudentInCourse> temp = lst[i];
                        lst[i] = lst[j];
                        lst[j] = temp;
                    }
                }
            //save lst to session and covert to aspx
            string semester = DropDownList1.SelectedValue;
            TotalCredits = 0;
            TotalGPA = 0;
            TD = new Dictionary<int, double>();
            if (semester == "All")
            {
                ViewState["AllSemester"] = true;
                ViewState["count"] = lst.Count;
                for (int i = 0; i < lst.Count; i++)
                {
                    Session[Convert.ToString(i)] = GetDataDisplayed(lst[i]);
                    CalculateSemesterWork(lst[i],i);
                }
            }
            else
            {
                ViewState["AllSemester"] = false;
                Boolean found = false;
                int index = 0;
                for (int i = 0; i < lst.Count; i++)
                {
                    if (lst[i][0].Course.Semester.Time == semester)
                    {
                        found = true;
                        index = i;
                        break;
                    }
                }
                if (!found)
                {
                    ViewState["count"] = 0;
                    db.Connection.Close();
                    return;
                }
                else
                {
                    ViewState["count"] = 1;
                    Session["0"] = GetDataDisplayed(lst[index]);
                    CalculateSemesterWork(lst[index], 0);
                }
            }

            foreach (int DisciplineID in TD.Keys)
                if (TD[DisciplineID] >= 2.0)
                {
                    TotalCredits += Classes.HogwartsDataAccess.GetDiscipline(DisciplineID).CreditNumber;
                    TotalGPA += TD[DisciplineID] * Classes.HogwartsDataAccess.GetDiscipline(DisciplineID).CreditNumber;
                }
            if (TotalCredits == 0)
                TotalGPA = 0.0;
            else
                TotalGPA = TotalGPA /= TotalCredits;
            TotalGPA = Math.Round(TotalGPA, 2, MidpointRounding.AwayFromZero); 
            db.Connection.Close();
        }

        private List<Record> GetDataDisplayed(List<StudentInCourse> sicl)
        {
            var ret = (from sic in sicl
                       select new Record(sic.Course.Semester.Time, sic.CourseID, sic.Course.Discipline.Name, sic.Course.Discipline.CreditNumber, sic.CourseGPA)).ToList();
            return ret;
        }

        private void CalculateSemesterWork(List<StudentInCourse> lst,int SemesterIndex)
        {
            int Credits = 0;
            int PassedCredits = 0;
            double GPA = 0;
            
            StudentInCourse[] RA = lst.ToArray();
            Dictionary<int, double> D = new Dictionary<int,double>();
            for (int i = 0; i < RA.Count(); i++)
                if (!D.ContainsKey(RA[i].Course.DisciplineID))
                    D[RA[i].Course.DisciplineID] = Classes.Utility.MapGrade(RA[i].CourseGPA);
                else
                    D[RA[i].Course.DisciplineID] = Math.Max(D[RA[i].Course.DisciplineID],Classes.Utility.MapGrade(RA[i].CourseGPA));

            foreach (int DisciplineID in D.Keys)
            {
                if (D[DisciplineID] >= 2.0)
                {
                    PassedCredits += Classes.HogwartsDataAccess.GetDiscipline(DisciplineID).CreditNumber;
                    GPA += D[DisciplineID] * Classes.HogwartsDataAccess.GetDiscipline(DisciplineID).CreditNumber;
                    if(!TD.ContainsKey(DisciplineID))
                        TD[DisciplineID] = D[DisciplineID];
                    else
                        TD[DisciplineID] = Math.Max(TD[DisciplineID],D[DisciplineID]);
                }
                Credits += Classes.HogwartsDataAccess.GetDiscipline(DisciplineID).CreditNumber;
            }

            if(Credits == 0)
                GPA = 0.0;
            else
                GPA /= Credits;
            GPA = Math.Round(GPA, 2, MidpointRounding.AwayFromZero); 
            ViewState["Semester Credits " + SemesterIndex.ToString()] = PassedCredits.ToString();
            ViewState["Semester GPA " + SemesterIndex.ToString()] = GPA.ToString();
        }
    }
}