using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudHogwarts_WebRole.Classes;

namespace CloudHogwarts_WebRole.StudentWorks.StudentHome
{
    public partial class ClassSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 1)
                Response.Redirect("~/StaffWorks/StaffHome/StaffProfile.aspx");
            if (!Page.IsPostBack)
            {
                HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
                List<Semester> Semesters = (from s in db.Semesters
                                            select s).ToList<Semester>();
                for (int i = 0; i < Semesters.Count; i++)
                    DropDownList1.Items.Add(Semesters[i].Time);
                db.Connection.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
            int StudentID = (int)Session["StudentID"];
            int SemesterID = Classes.HogwartsDataAccess.GetSemesterID(DropDownList1.SelectedValue);
            var courses = (from sic in db.StudentInCourses
                           where sic.Student.StudentID == StudentID && sic.Course.SemesterID == SemesterID
                           select sic.Course);

            var sessions = (from c in courses
                            from s in db.Sessions
                            where c.CourseID == s.CourseID
                            select new { Semester = c.Semester.Time, c.CourseID, Discipline = c.Discipline.Name, c.Discipline.CreditNumber, s.SessionID, Weekday = Utility.GetWeekday(s.Weekday), StartingTime = Utility.GetStartingTime(s.StartingPeriod), FinishingTime = Utility.GetFinishingTime(s.StartingPeriod) });

            if (sessions.Count() == 0)
            {
                Label1.Text = "NO DATA AVAILABLE";
                GridView1.Visible = false;
                Label2.Text = "";
                return;
            }

            Label1.Text = "";
            GridView1.Visible = true;
            GridView1.DataSource = sessions;
            GridView1.DataBind();
            
            for (int i = GridView1.Rows.Count-1; i>0 ; i--)
            {
                int j = 1;
                while (i>0 && GridView1.Rows[i].Cells[1].Text == GridView1.Rows[i-1].Cells[1].Text)
                {
                    GridView1.Rows[i].Cells.RemoveAt(3);
                    GridView1.Rows[i].Cells.RemoveAt(2);
                    GridView1.Rows[i].Cells.RemoveAt(1);
                    i--;
                    j++;
                }
                GridView1.Rows[i].Cells[3].RowSpan = j;
                GridView1.Rows[i].Cells[2].RowSpan = j;
                GridView1.Rows[i].Cells[1].RowSpan = j;
            }

            for (int i = GridView1.Rows.Count - 1; i > 0; i--)
                GridView1.Rows[i].Cells.RemoveAt(0);
            GridView1.Rows[0].Cells[0].RowSpan = GridView1.Rows.Count;
            db.Connection.Close();

            int CreditHrs = 0;
            Course[] CA = courses.ToArray();

            for (int i = 0; i < CA.Count(); i++)
            {
                bool found = false;
                for (int j = i + 1; j < CA.Count(); j++)
                    if (CA[i].DisciplineID == CA[j].DisciplineID)
                    {
                        found = true;
                        break;
                    }
                if (!found)
                    CreditHrs += CA[i].Discipline.CreditNumber;
            }

            Label2.Text = "Credit Hours: "+CreditHrs.ToString();
        }
    }
}