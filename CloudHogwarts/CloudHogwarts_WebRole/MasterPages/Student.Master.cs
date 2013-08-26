using System;
using System.ServiceModel;
using System.ServiceModel.Security;
using Microsoft.WindowsAzure;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using CloudHogwarts_WorkerRole;
using System.Web.Security;
using System.Threading;

namespace CloudHogwarts_WebRole.MasterPages
{
    public class StudentNotice
    {
        public int AnnouncementID{ get; set; }
        public string Publisher{get; set;}
        public string Title{get; set;}
        public StudentNotice(int AnnouncementID, string Publisher, string Title)
        {
            this.AnnouncementID = AnnouncementID;
            this.Publisher = Publisher;
            this.Title = Title;
        }
    }

    public partial class Student : System.Web.UI.MasterPage
    {
        public int index;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Label1.Text = "Welcome " + Context.User.Identity.Name;
                announcement.Visible = false;
                this.HyperLink1.Visible = false;
                this.Timer1.Enabled = false;
                ReloadAnnouncements();
                this.Timer1.Enabled = true;
            }
        }

        private void ReloadAnnouncements()
        {
            INotificationService wcfClient = Classes.TableDataContract.getINotificationService();
            int StudentID = Classes.HogwartsDataAccess.GetStudentID(Context.User.Identity.Name);
            Session["lst"] = wcfClient.getRelatingMessages(StudentID);
            if (Session["lst"] == null) return;
            List<StudentNotice> NoticeLst = new List<StudentNotice>();
            List<bool> lsNoticeBool = new List<bool>();
            int maxSize = ((List<Message>)Session["lst"]).Count > 9 ? 9 : ((List<Message>)Session["lst"]).Count;
            for (int i = 0; i < maxSize; i++)
            {
                CloudHogwarts_WebRole.Staff st = Classes.HogwartsDataAccess.GetStaff(((List<Message>)Session["lst"])[i].StaffID);
                string StaffName = st.FirstName + " " + st.LastName;
                NoticeLst.Add(new StudentNotice(((List<Message>)Session["lst"])[i].AnnouncementID, StaffName, ((List<Message>)Session["lst"])[i].Title));
                lsNoticeBool.Add(((List<Message>)Session["lst"])[i].IsNotification);
            }

            int NotViewedNumber = 0;
            for (int i = 0; i < ((List<Message>)Session["lst"]).Count; i++)
            {
                if (((List<Message>)Session["lst"])[i].IsViewed == false)
                    NotViewedNumber++;
            }

            if (NotViewedNumber == 0)
                this.Button1.Text = "";
            else
                this.Button1.Text = NotViewedNumber.ToString();
            Session["BoolList"] = lsNoticeBool;
            Session["NoticeLst"] = NoticeLst;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            ReloadAnnouncements();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = false;
            if (announcement.Visible == false)
            {
                ReloadAnnouncements();
                if (((List<Message>)Session["lst"]) == null) return;//there're no announcements for student
                if (((List<Message>)Session["lst"]).Count > 9) this.HyperLink1.Visible = true;
                else this.HyperLink1.Visible = false;
                //set initial announcement index
                index=0;
                for (int i = 0; i < ((List<Message>)Session["lst"]).Count; i++)
                        Classes.TableDataContract.ChangeViewedStatus(((List<Message>)Session["lst"])[i].RowKey);
                this.Button1.Text = "";
                announcement.Dispose();
                announcement.DataSource = Session["NoticeLst"];
                announcement.DataBind();
                announcement.Visible = true;
            }
            else
            {
                this.HyperLink1.Visible = false;
                announcement.DataSource = null;
                announcement.DataBind();
                announcement.Visible = false;
                //start the timer
                this.Timer1.Enabled = true;
            }
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