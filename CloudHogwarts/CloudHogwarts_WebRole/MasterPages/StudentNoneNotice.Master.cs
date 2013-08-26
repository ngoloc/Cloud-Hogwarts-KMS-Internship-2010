using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace CloudHogwarts_WebRole.MasterPages
{
    public partial class StudentNoneNotice : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Label1.Text = "Welcome " + Context.User.Identity.Name;
        }

        protected void exit(object sender, MenuEventArgs e)
        {
            if (e.Item.Text == "Exit")
            {
                FormsAuthentication.SignOut();
                Session.Clear();
                ViewState.Clear();
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}