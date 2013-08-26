using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudHogwarts_WebRole.StudentWorks.StudentHome
{
    public partial class StudentNewsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 1)
                Response.Redirect("~/StaffWorks/StaffHome/StaffProfile.aspx");
            HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
            int ArticleID = (int)Session["ArticleID"];
            var ar = (from a in db.Articles
                      where ArticleID == a.ArticleID
                      select a).FirstOrDefault();
            if (ar == null)
            {
                ErrorH.Visible = true;
                return;
            }
            ErrorH.Visible = false;
            title.InnerText = ar.Title;
            time.InnerText = ar.DateTime.ToString();
            content.InnerHtml = ar.Content;
        }
    }
}