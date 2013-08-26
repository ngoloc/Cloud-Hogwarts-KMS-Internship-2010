using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudHogwarts_WebRole.Classes;

namespace CloudHogwarts_WebRole.StudentWorks.CourseRegistration
{
    public partial class AddCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 1)
                Response.Redirect("~/StaffWorks/StaffHome/StaffProfile.aspx");
            if (Session["SemesterID"] == null || Session["DepartmentID"] == null)
                Response.Redirect("RegisterCourse.aspx");

            if (!Page.IsPostBack)
                ReLoad();
        }

        private void ReLoad()
        {
            int SemesterID = (int)Session["SemesterID"];
            int DepartmentID = (int)Session["DepartmentID"];
            HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
            var courses = (from course in db.Courses
                           where course.SemesterID == SemesterID && course.Discipline.DepartmentID == DepartmentID
                           select new { course.CourseID, course.Semester.Time, Department = course.Discipline.Department.Name, Discipline = course.Discipline.Name, Teacher = course.Staff.FirstName + " " + course.Staff.LastName, course.AttendeeNumber, course.MaxCapacity }).ToList();

            SemH.InnerText = "semester: " + Classes.HogwartsDataAccess.GetSemester(SemesterID).Time;
            DeptH.InnerText = "department: " + Classes.HogwartsDataAccess.GetDepartment(DepartmentID);
            if (courses.Count() == 0)
            {
                Label1.Text = "There's no course for this semester";
                CourseGeH.Visible = false;
                SessionGeH.Visible = false;
                GridView1.Visible = false;
                GridView2.Visible = false;
                return;
            }

            GridView1.DataSource = courses;
            GridView1.DataBind();
            foreach (GridViewRow gvr in GridView1.Rows)
            {
                if (Classes.HogwartsDataAccess.StudentInCourse((int)Session["StudentID"], Int32.Parse(gvr.Cells[0].Text)))
                {
                    CheckBox cb = (CheckBox)gvr.FindControl("Checkbox1");
                    cb.Checked = true;
                }
            }
            List<TempSession> TSessionLst = Utility.CreateNewTempSessionList(db.Sessions.ToList<Session>());
            var sessions = (from ts in TSessionLst
                            from c in courses
                            where ts.TempCourseID == c.CourseID
                            select new { CourseID = ts.TempCourseID, SessionID = ts.TempSessionID, ts.Classroom, ts.Weekday, ts.StartingTime, ts.FinishingTime }).ToList();
            GridView2.DataSource = sessions;
            GridView2.DataBind();
            Label1.Text = "";
            CourseGeH.Visible = true;
            SessionGeH.Visible = true;
            GridView1.Visible = true;
            GridView2.Visible = true;
            db.Connection.Close();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            GridViewRow gvr = (GridViewRow)cb.NamingContainer;
            Label1.Text = "";
            int CourseID = Int32.Parse(gvr.Cells[0].Text);
            int StudentID = (int)Session["StudentID"];
            if (cb.Checked)
            {
                //Array[7][9]
                bool[][] AllottedTable = Classes.HogwartsDataAccess.GetStudentAllotedTable((int)Session["SemesterID"], StudentID);
                List<Session> ls = Classes.HogwartsDataAccess.GetSessions(CourseID);
                foreach (Session s in ls)
                {
                    if (AllottedTable[s.Weekday][s.StartingPeriod] || AllottedTable[s.Weekday][s.StartingPeriod + 1])
                    {
                        Label1.Text = "School time is ovelapped";
                        cb.Checked = false;
                        return;
                    }
                }
                HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
                var course = (from c in db.Courses
                              where c.CourseID == CourseID
                              select c).First();

                if (course.AttendeeNumber >= course.MaxCapacity)
                {
                    Label1.Text = "Course is full";
                    return;
                }

                StudentInCourse sic = new StudentInCourse();
                sic.CourseID = CourseID;
                sic.StudentID = StudentID;
                db.StudentInCourses.InsertOnSubmit(sic);
                if (course.AttendeeNumber == null)
                {
                    course.AttendeeNumber = 1;
                    gvr.Cells[5].Text = "1";
                }
                else
                {
                    course.AttendeeNumber++;
                    gvr.Cells[5].Text = (Int32.Parse(gvr.Cells[5].Text) + 1).ToString();
                }
                db.SubmitChanges();
                db.Connection.Close();
            }
            else
            {
                HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
                StudentInCourse sic = (from sc in db.StudentInCourses
                                       where sc.CourseID == CourseID && sc.StudentID == StudentID
                                       select sc).First();
                db.StudentInCourses.DeleteOnSubmit(sic);
                var course = (from c in db.Courses
                              where c.CourseID == CourseID
                              select c).First();
                if (course.AttendeeNumber == 1)
                {
                    course.AttendeeNumber = null;
                    gvr.Cells[5].Text = "";
                }
                else
                {
                    course.AttendeeNumber--;
                    gvr.Cells[5].Text = (Int32.Parse(gvr.Cells[5].Text) - 1).ToString();
                }
                db.SubmitChanges();
                db.Connection.Close();
            }
            Response.Redirect("AddCourses.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("./RegisterCourses.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ReLoad();
            GridView1.Focus();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            ReLoad();
            GridView2.Focus();
        }
    }
}