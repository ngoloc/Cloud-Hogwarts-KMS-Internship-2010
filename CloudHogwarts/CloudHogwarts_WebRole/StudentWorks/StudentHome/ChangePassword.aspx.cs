using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudHogwarts_WebRole.StudentWorks.StudentHome
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 1)
                Response.Redirect("~/StaffWorks/StaffHome/StaffProfile.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != TextBox2.Text || TextBox1.Text == "")
            {
                Label1.Text = "Passwords do not match. Type them again.";
                return;
            }

            string UserName = Context.User.Identity.Name;
            HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
            var NeededStu = (from st in db.Students
                             where st.UserName == UserName
                             select st).First();
            NeededStu.Password = TextBox1.Text;
            db.SubmitChanges();
            Label1.Text = "Your password has been changed successfully.";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("./StudentEdit.aspx");
        }  
    }
}