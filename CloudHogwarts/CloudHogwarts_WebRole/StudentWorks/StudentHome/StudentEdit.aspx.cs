using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudHogwarts_WebRole;

namespace CloudHogwarts_WebRole.StudentWorks.StudentHome
{
    public partial class StudentEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 1)
                Response.Redirect("~/StaffWorks/StaffHome/StaffProfile.aspx");
            if (!Page.IsPostBack)
            {
                HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
                var halls = (from hall in db.Houses
                             select hall.HouseName);
                DropDownList1.DataSource = halls;
                DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = Label2.Text = Label3.Text = Label4.Text = "";
            if (TextBox1.Text == "")
                Label1.Text = "Field can't be nill";
            if (TextBox2.Text == "")
                Label2.Text = "Field can't be nill";
            if (TextBox3.Text == "")
                Label3.Text = "Field can't be nill";
            if (TextBox4.Text == "")
                Label4.Text = "Field can't be nill";
            if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "" || TextBox4.Text == "")
                return;

            //update username + password
            string OldUserName = Context.User.Identity.Name;
            HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
            var NeededStu = (from st in db.Students
                             where st.UserName == OldUserName
                             select st).First();
            StudentRequest sr = new StudentRequest();
            sr.StudentID = NeededStu.StudentID;
            sr.NewFirstName = TextBox1.Text;
            sr.NewLastName = TextBox2.Text;
            sr.NewNationality = TextBox3.Text;
            sr.NewMMailAddress = TextBox4.Text;
            sr.NewHouseName = DropDownList1.SelectedValue;
            db.StudentRequests.InsertOnSubmit(sr);
            db.SubmitChanges();

            //NOTICE TO ALL ONLINE STAFF
            List<Staff> lst = db.Staffs.ToList();
            for(int i=0;i<lst.Count;i++)
                Classes.TableDataContract.AddStudentRequest(Classes.HogwartsDataAccess.GetStudentID(Context.User.Identity.Name), lst[i].StaffID, false);
            Response.Redirect("./StudentInfo.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("./ChangePassword.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("./StudentInfo.aspx");
        }  
    }
}