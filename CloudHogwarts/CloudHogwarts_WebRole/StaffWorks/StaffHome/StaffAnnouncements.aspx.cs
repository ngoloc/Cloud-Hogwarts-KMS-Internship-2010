using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudHogwarts_WebRole.StaffWorks.StaffWorks.StaffHome
{
    public partial class StaffAnnouncements : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 0)
                Response.Redirect("~/StudentWorks/StudentHome/StudentProfile.aspx");
            if (!IsPostBack)
            {
                PageLoad();
            }
        }

        private void PageLoad()
        {
            if (!Page.IsPostBack)
                ReloadAnnouncements();
        }

        private void ReloadAnnouncements()
        {
            HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
            var ars = (from ar in db.Articles
                       where ar.StaffID == (int)Session["StaffID"]
                       select new { ar.ArticleID, ar.Title, PostingDate = ar.DateTime }).ToList();
            GridView1.DataSource = ars;
            GridView1.DataBind();
            db.Connection.Close();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (index >= GridView1.Rows.Count) return;
            GridViewRow selectedRow = ((GridView)e.CommandSource).Rows[index];
            string ID = selectedRow.Cells[2].Text;
            if (e.CommandName == "remove")
            {
                if (GridView1.Rows.Count == 0) return;
                HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
                var DeleteAr = (from ar in db.Articles
                                where ar.ArticleID.ToString() == ID
                                select ar).First();

                db.Articles.DeleteOnSubmit(DeleteAr);
                db.SubmitChanges();
                db.Connection.Close();
                //delete relevant content in table
                Classes.TableDataContract.DeleteArticle(Convert.ToInt32(ID));
                ReloadAnnouncements();
                Response.Redirect("StaffAnnouncements.aspx");
            }
            else if (e.CommandName == "view")
            {
                Session["ArticleID"] = Convert.ToInt32(ID);
                Response.Redirect("./NewsPage.aspx");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ReloadAnnouncements();
            GridView1.Focus();
        }
    }
}