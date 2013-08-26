using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudHogwarts_WebRole.StaffWorks.StaffHome
{
    public partial class StaffProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 0)
                Response.Redirect("~/StudentWorks/StudentHome/StudentProfile.aspx");
            if (!Page.IsPostBack)
            {
                HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
                string username = Context.User.Identity.Name;
                var rec = (from c in db.Staffs
                           where username == c.UserName
                           select c).First();
                Session["StaffID"] = rec.StaffID;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ProcessStudentRequests.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("./StaffPictures.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ComposeAnnouncements.aspx");
        }
    }
}