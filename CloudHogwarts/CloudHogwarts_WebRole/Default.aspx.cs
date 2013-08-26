using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudHogwarts_WebRole;
using CloudHogwarts_WebRole.Classes;
using System.Web.Security;

namespace CloudHogwarts_WebRole
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated)
                if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 1)
                    Response.Redirect("~/StaffWorks/StaffHome/StaffProfile.aspx");
                else
                    Response.Redirect("~/StudentWorks/StudentHome/StudentProfile.aspx");
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
            Student student = HogwartsDataAccess.GetStudent(UsernameTextBox.Text, PasswordTextBox.Text);

            if (student == null)
            {
                Staff staff = HogwartsDataAccess.GetStaff(UsernameTextBox.Text, PasswordTextBox.Text);
                if (staff == null)
                {
                    UsernameTextBox.Text = "";
                    PasswordTextBox.Text = "";
                    error.Visible = true;
                    return;
                }
                FormsAuthentication.RedirectFromLoginPage(UsernameTextBox.Text,false);
                Response.Redirect("~/StaffWorks/StaffHome/StaffProfile.aspx");
                return;
            }
            FormsAuthentication.RedirectFromLoginPage(UsernameTextBox.Text, false);
            Response.Redirect("~/StudentWorks/StudentHome/StudentProfile.aspx");
        }
    }
}