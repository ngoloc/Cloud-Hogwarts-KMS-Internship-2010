using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;
using System.Reflection;
using System.ServiceModel;
using System.Threading;
using System.Web.UI.WebControls;
using CloudHogwarts_WorkerRole;
using System.Web.Security;

namespace CloudHogwarts_WebRole.MasterPages
{
    public class StaffNotice
    {
        public string text { get; set; }
        public StaffNotice(string text)
        {
            this.text = text;
        }
    }

    public partial class Staff : System.Web.UI.MasterPage
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
            int StaffID = Classes.HogwartsDataAccess.GetStaff(Context.User.Identity.Name).StaffID;
            Session["stafflst"] = wcfClient.getStaffRelatingMessages(StaffID);
            if (Session["stafflst"] == null) return;
            List<StaffNotice> NoticeLst = new List<StaffNotice>();
            List<bool> lsNoticeBool = new List<bool>();
            int maxSize = ((List<StaffMessage>)Session["stafflst"]).Count > 9 ? 9 : ((List<StaffMessage>)Session["stafflst"]).Count;
            for (int i = 0; i < maxSize; i++)
            {
                CloudHogwarts_WebRole.Staff st = Classes.HogwartsDataAccess.GetStaff(((List<StaffMessage>)Session["stafflst"])[i].StaffID);
                string StaffName = st.FirstName + " " + st.LastName;
                NoticeLst.Add(new StaffNotice(((List<StaffMessage>)Session["stafflst"])[i].text));
            }

            int NotViewedNumber = 0;
            for (int i = 0; i < ((List<StaffMessage>)Session["stafflst"]).Count; i++)
            {
                if (((List<StaffMessage>)Session["stafflst"])[i].IsViewed == false)
                    NotViewedNumber++;
            }
            if (NotViewedNumber == 0)
                this.Button1.Text = "";
            else
                this.Button1.Text = NotViewedNumber.ToString();
            Session["StaffNoticeLst"] = NoticeLst;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            ReloadAnnouncements();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Timer1.Enabled = false;
            if (this.announcement.Visible == false)
            {
                ReloadAnnouncements();
                if (((List<StaffMessage>)Session["stafflst"]) == null) return;//there're no announcements for staff      
                if (((List<StaffMessage>)Session["stafflst"]).Count > 9) this.HyperLink1.Visible = true;
                else this.HyperLink1.Visible = false;
                //set initial announcement index
                index = 0;
                
                for (int i = 0; i < ((List<StaffMessage>)Session["stafflst"]).Count; i++)
                {
                    Classes.TableDataContract.ChangeStaffViewedStatus(((List<StaffMessage>)Session["stafflst"])[i].RowKey);
                }
                this.Button1.Text = "";
                announcement.Dispose();
                announcement.DataSource = Session["StaffNoticeLst"];
                announcement.DataBind();
                this.announcement.Visible = true;
            }
            else
            {
                this.HyperLink1.Visible = false;
                this.announcement.DataSource = null;
                this.announcement.DataBind();
                this.announcement.Visible = false;
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