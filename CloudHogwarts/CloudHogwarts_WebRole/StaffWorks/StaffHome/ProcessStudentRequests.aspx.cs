using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudHogwarts_WebRole;

namespace CloudHogwarts_WebRole.StaffWorks.StaffHome
{
    public partial class ProcessStudentRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 0)
                Response.Redirect("~/StudentWorks/StudentHome/StudentProfile.aspx");
            if (!IsPostBack)
            {
                Button2.Visible = false;
                Button3.Visible = false;
                HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
                List<StudentRequest> rec = (from stu in db.StudentRequests
                                            select stu).ToList<StudentRequest>();
                for (int i = 0; i < rec.Count; i++)
                    DropDownList1.Items.Add(Convert.ToString(rec[i].StudentID));
            }
        }

        protected void deleteStudentRequest()
        {
            HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
            int StudentID = Convert.ToInt32(GridView1.Rows[0].Cells[0].Text);
            var Stu = (from stu in db.StudentRequests
                       where stu.StudentID == StudentID
                       select stu).First();
            db.StudentRequests.DeleteOnSubmit(Stu);
            db.SubmitChanges();
            GridView1.DataSource = null;
            GridView1.DataBind();
            GridView2.DataSource = null;
            GridView2.DataBind();
            DropDownList1.Items.Remove(Convert.ToString(StudentID));
            Button2.Visible = false;
            Button3.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Staff staff = Classes.HogwartsDataAccess.GetStaff(Context.User.Identity.Name);
            int StudentID = Convert.ToInt32(GridView1.Rows[0].Cells[0].Text);
            Classes.TableDataContract.AddNotice(staff.StaffID, StudentID, "rejected", 0, true, false);
            deleteStudentRequest();
            Response.Redirect("ProcessStudentRequests.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.Items.Count == 0) return;
            HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
            int StudentID = Convert.ToInt32(DropDownList1.SelectedValue);
            var NeededStu = (from stu in db.Students
                             join house in db.Houses on stu.HouseID equals house.HouseID
                             where stu.StudentID == StudentID && stu.HouseID == house.HouseID
                             select new
                             {
                                 StudentID = stu.StudentID,
                                 CurrentFirstname = stu.FirstName,
                                 CurrentLastname = stu.LastName,
                                 CurrentNationality = stu.Nationality,
                                 CurrentMMailAddress = stu.MmailAddress,
                                 CurrentHouseName = house.HouseName
                             });

            GridView1.DataSource = NeededStu;
            GridView1.DataBind();
            var NewStu = (from stu in db.StudentRequests
                          where stu.StudentID == StudentID
                          select stu);

            GridView2.DataSource = NewStu;
            GridView2.DataBind();
            Button2.Visible = true;
            Button3.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();
            int StudentID = Convert.ToInt32(GridView1.Rows[0].Cells[0].Text);

            var NewStu = (from nstu in db.StudentRequests
                          where nstu.StudentID == StudentID
                          select nstu).First();

            string NewHouseName = NewStu.NewHouseName;

            var house = (from h in db.Houses
                         where h.HouseName == NewHouseName
                         select h).First();
            var stu = (from s in db.Students
                       where s.StudentID == StudentID
                       select s).First();

            stu.FirstName = NewStu.NewFirstName;
            stu.LastName = NewStu.NewLastName;
            stu.Nationality = NewStu.NewNationality;
            stu.MmailAddress = NewStu.NewMMailAddress;
            stu.HouseID = house.HouseID;
            db.SubmitChanges();
            deleteStudentRequest();
            //give notification to the student in charge
            Staff staff = Classes.HogwartsDataAccess.GetStaff(Context.User.Identity.Name);
            Classes.TableDataContract.AddNotice(staff.StaffID, StudentID, "accepted", 0, true, false);
            Response.Redirect("ProcessStudentRequests.aspx");
        }
    }
}