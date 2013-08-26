using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudHogwarts_WebRole.StudentWorks.StudentHome
{
    public partial class DepartmentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 1)
                Response.Redirect("~/StaffWorks/StaffHome/StaffProfile.aspx");
            title.InnerText = Classes.HogwartsDataAccess.GetDepartment(Context.User.Identity.Name).Name;
            content.InnerHtml = Classes.HogwartsDataAccess.GetDepartment(Context.User.Identity.Name).Description;
        }
    }
}