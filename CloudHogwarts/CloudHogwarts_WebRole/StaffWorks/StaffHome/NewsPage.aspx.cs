using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudHogwarts_WebRole.StaffWorks.StaffHome
{
    public partial class NewsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 0)
                Response.Redirect("~/StudentWorks/StudentHome/StudentProfile.aspx");
            HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
            int ArticleID = (int)Session["ArticleID"];
            var ar = (from a in db.Articles
                      where ArticleID == a.ArticleID
                      select a).First();
           
            title.InnerText = ar.Title;
            time.InnerText = ar.DateTime.ToString();
            content.InnerHtml = ar.Content;
        }
    }
}