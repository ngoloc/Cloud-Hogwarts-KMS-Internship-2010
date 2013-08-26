using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudHogwarts_WebRole;
using CloudHogwarts_WebRole.Classes;

namespace CloudHogwarts_WebRole.StudentWorks.StudentHome
{
    public partial class StudentProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 1)
                Response.Redirect("~/StaffWorks/StaffHome/StaffProfile.aspx");
            if (!Page.IsPostBack)
            {
                HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
                string username = Context.User.Identity.Name;
                var rec = (from c in db.Students
                           where username == c.UserName
                           select c).First();
                Session["StudentID"] = rec.StudentID;
                Session["StudentName"] = rec.FirstName + " " + rec.LastName;
                Label2.Text = Classes.HogwartsDataAccess.GetStudentName(rec.StudentID);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("./DepartmentInfo.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ClassSchedule.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Transcript.aspx");
        }
    }
}