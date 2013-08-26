using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudHogwarts_WebRole.Classes;
using CloudHogwarts_WebRole;

namespace CloudHogwarts_WebRole.StudentWorks.StudentHome
{
        public partial class StudentInfo : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 1)
                    Response.Redirect("~/StaffWorks/StaffHome/StaffProfile.aspx");
                HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
                int StudentID = (int)Session["studentID"];
                var EachStudent = (from st in db.Students
                                   where st.StudentID == StudentID
                                   select st).First();
                var rec = (from sr in db.StudentRequests
                           where StudentID == sr.StudentID
                           select sr).FirstOrDefault();
                if (rec != null) LinkButton1.Enabled = false;
                else LinkButton1.Enabled = true;                
                Label2.Text = EachStudent.FirstName + " " + EachStudent.LastName;
                Label3.Text = EachStudent.Nationality;
                Label4.Text = EachStudent.MmailAddress;
                Label5.Text = EachStudent.House.HouseName;
                Label6.Text = Context.User.Identity.Name;
            }

            protected void LinkButton1_Click(object sender, EventArgs e)
            {
                Response.Redirect("./StudentEdit.aspx");
            }
        }
}