using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudHogwarts_WebRole.Classes;

namespace CloudHogwarts_WebRole.StaffWorks.CourseManagement
{
    public partial class ViewOpenedCourses : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 0)
                Response.Redirect("~/StudentWorks/StudentHome/StudentProfile.aspx");
            if (!Page.IsPostBack)
            {
                DropDownList1.DataSource = Classes.HogwartsDataAccess.GetSemesterList();
                DropDownList1.DataBind();
                DropDownList1.SelectedIndex = 0;
                DropDownList2.DataSource = Classes.HogwartsDataAccess.GetDepartmentList();
                DropDownList2.DataBind();
                DropDownList2.SelectedIndex = 0;
                CourseGeH.Visible = false;
                SessionGeH.Visible = false;
            }
        }

        protected void Reload()
        {
            HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
            var courses = (from course in db.Courses
                           where course.Semester.Time == (string)ViewState["SemesterTime"] && course.Discipline.Department.Name == (string)ViewState["DepartmentName"]
                           select new { course.CourseID, course.Semester.Time, Department = course.Discipline.Department.Name, Discipline = course.Discipline.Name, Teacher = course.Staff.FirstName + " " + course.Staff.LastName, course.AttendeeNumber, course.MaxCapacity }).ToList();
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
                int CourseID = Int32.Parse(gvr.Cells[0].Text);
                Course course = HogwartsDataAccess.GetCourse(CourseID);
                if (course.AttendeeNumber == null)
                    gvr.Cells[7].Text = "";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            ViewState["SemesterTime"] = DropDownList1.SelectedValue;
            ViewState["DepartmentName"] = DropDownList2.SelectedValue;
            Reload();
        }

        protected void GidView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow selectedRow = GridView1.Rows[e.RowIndex];
            TableCell CourseIDCell = selectedRow.Cells[0];
            string CourseID = CourseIDCell.Text;
            Session["CourseID"] = CourseID;
            Response.Redirect("./InputGrade.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Reload();
            GridView1.Focus();
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            Reload();
            GridView2.Focus();
        }
    }
}