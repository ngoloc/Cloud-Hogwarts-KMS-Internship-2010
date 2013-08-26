using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudHogwarts_WebRole.StaffWorks.CourseManagement
{
    public partial class InputGrade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 0)
                Response.Redirect("~/StudentWorks/StudentHome/StudentProfile.aspx");
            if (Session["CourseID"] == null)
                Response.Redirect("./ViewOpenedCourses.aspx");
            if (!Page.IsPostBack)
                Reload();
        }

        protected void Reload()
        {
            int CourseID = Int32.Parse((string)Session["CourseID"]);
            HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
            Course ret = (from course in db.Courses
                          where course.CourseID == CourseID
                          select course).First();
            SemH.InnerText = "semester: "+ret.Semester.Time;
            DeptH.InnerText = "department: "+ret.Discipline.Department.Name;
            CourseH.InnerText = "course: #" + ret.CourseID.ToString() + " | " + ret.Discipline.Name;
            InstructorH.InnerText = "instructor: "+ret.Staff.FirstName + " " + ret.Staff.LastName;
            if (ret.AttendeeNumber == null)
            {
                Label1.Text = "There's no student in this course";
                GridView1.Visible = false;
                Button1.Visible = false;
                return;
            }
            Label1.Text = "";
            var sics = (from sic in db.StudentInCourses
                        where sic.CourseID == CourseID
                        select new { sic.StudentID, sic.Student.FirstName, sic.Student.LastName }).ToList();
            GridView1.DataSource = sics;
            GridView1.DataBind();
            foreach (GridViewRow gvr in GridView1.Rows)
            {
                DropDownList ddl = (DropDownList)gvr.FindControl("DropDownList1");
                ddl.SelectedValue = Classes.HogwartsDataAccess.GetStudentInCourse(Int32.Parse(gvr.Cells[0].Text), CourseID);
            }
            GridView1.Visible = true;
            Button1.Visible = true;
            db.Connection.Close();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("./ViewOpenedCourses.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int CourseID = Int32.Parse((string)Session["CourseID"]);
            HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
            foreach (GridViewRow gvr in GridView1.Rows)
            {
                DropDownList ddl = (DropDownList)gvr.FindControl("DropDownList1");
                int StudentID = Int32.Parse(gvr.Cells[0].Text);
                string grade = ddl.SelectedValue;
                var sic = (from s in db.StudentInCourses
                           where s.StudentID == StudentID && s.CourseID == CourseID
                           select s).First();
                sic.CourseGPA = grade;
                db.SubmitChanges();
            }
            db.Connection.Close();
            Label1.Text = "Grades have been updated";
        }

    }
}