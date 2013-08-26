using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure;
using System.Collections.Specialized;

namespace CloudHogwarts_WebRole.StaffWorks.StaffHome
{
    public partial class ComposeAnnouncements : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 0)
                Response.Redirect("~/StudentWorks/StudentHome/StudentProfile.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("./StaffPictures.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            if (TextBox1.Text == "")
            {
                Label1.Text = "Title must not be nill";
                return;
            }

            if (TextBox1.Text.Length>100)
            {
                Label1.Text = "Title is too long";
                return;
            }

            HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
            string username = Context.User.Identity.Name;
            Staff staff = Classes.HogwartsDataAccess.GetStaff(username);
            //Insert new article to database
            Article ar = new Article();
            ar.Title = TextBox1.Text;
            ar.Content = FreeTextBox1.ViewStateText;
            ar.DateTime = DateTime.Now;
            ar.StaffID = staff.StaffID;
            db.Articles.InsertOnSubmit(ar);
            db.SubmitChanges();
            //GET LATEST SUBMITTED ARTICLE ID
            List<Article> ArticleLst = db.Articles.ToList() ;
            int UpdateArticleID = 0;
            for(int i=ArticleLst.Count - 1; i>=0; i--)
                if(ArticleLst[i].StaffID == ar.StaffID)
                {
                    UpdateArticleID = ArticleLst[i].ArticleID;
                    break;
                }

            Session["ArticleID"] = UpdateArticleID;

            //NOTICE TO ALL ONLINE STUDENT
            List<Student> lst = db.Students.ToList();
            for(int i=0;i<lst.Count;i++)
                Classes.TableDataContract.AddNotice(ar.StaffID, lst[i].StudentID, ar.Title, UpdateArticleID, false, false);
            Response.Redirect("./NewsPage.aspx");
        }

    }
}