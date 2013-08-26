using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudHogwarts_WebRole.MasterPages;
using CloudHogwarts_WorkerRole;

namespace CloudHogwarts_WebRole.StudentWorks.StudentHome
{
    public partial class FullAnnouncements : System.Web.UI.Page
    {
        public int index;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 1)
                Response.Redirect("~/StaffWorks/StaffHome/StaffProfile.aspx");
            if (!Page.IsPostBack)
            {
                INotificationService wcfClient = Classes.TableDataContract.getINotificationService();
                int StudentID = Classes.HogwartsDataAccess.GetStudentID(Context.User.Identity.Name);
                List<Message> lst = wcfClient.getRelatingMessages(StudentID);
                if (lst == null) return;
                List<StudentNotice> NoticeLst = new List<StudentNotice>();
                List<bool> lsNoticeBool = new List<bool>();
                int maxSize = lst.Count;
                for (int i = 0; i < maxSize; i++)
                {
                    CloudHogwarts_WebRole.Staff st = Classes.HogwartsDataAccess.GetStaff(lst[i].StaffID);
                    string StaffName = st.FirstName + " " + st.LastName;
                    NoticeLst.Add(new StudentNotice(lst[i].AnnouncementID, StaffName, lst[i].Title));
                    lsNoticeBool.Add(lst[i].IsNotification);
                }
                index = 0;
                Session["FullBoolList"] = lsNoticeBool;
                announcement.DataSource = NoticeLst;
                announcement.DataBind();
            }
        }
        protected void OnAnnouncementDataBound(object sender, ListViewItemEventArgs e)
        {
        }
    }
}