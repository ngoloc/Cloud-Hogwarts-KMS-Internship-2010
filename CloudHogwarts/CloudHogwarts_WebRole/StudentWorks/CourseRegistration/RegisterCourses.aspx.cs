using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudHogwarts_WebRole.StudentWorks.CourseRegistration
{
    public partial class RegisterCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 1)
                Response.Redirect("~/StaffWorks/StaffHome/StaffProfile.aspx");
            if (!Page.IsPostBack)
            {
                DropDownList1.DataSource = Classes.HogwartsDataAccess.GetSemesterList();
                DropDownList1.DataBind();
                DropDownList1.SelectedIndex = 0;
                DropDownList2.DataSource = Classes.HogwartsDataAccess.GetDepartmentList();
                DropDownList2.DataBind();
                DropDownList2.SelectedIndex = 0;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Session["SemesterID"] = Classes.HogwartsDataAccess.GetSemesterID(DropDownList1.SelectedValue);
            Session["DepartmentID"] = Classes.HogwartsDataAccess.GetDepartmentID(DropDownList2.SelectedValue);
            Response.Redirect("./AddCourses.aspx");
        }

    }
}