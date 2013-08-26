using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudHogwarts_WebRole.MasterPages;
using CloudHogwarts_WorkerRole;

namespace CloudHogwarts_WebRole.StaffWorks.StaffHome
{
    public partial class FullStaffAnnouncements : System.Web.UI.Page
    {
        public int index;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 0)
                Response.Redirect("~/StudentWorks/StudentHome/StudentProfile.aspx");
            INotificationService wcfClient = Classes.TableDataContract.getINotificationService();
            int StaffID = Classes.HogwartsDataAccess.GetStaff(Context.User.Identity.Name).StaffID;
            List<StaffMessage> lst = wcfClient.getStaffRelatingMessages(StaffID);
            if (lst == null) return;
            List<StaffNotice> NoticeLst = new List<StaffNotice>();
            List<bool> lsNoticeBool = new List<bool>();
            int maxSize = lst.Count;
            for (int i = 0; i < maxSize; i++)
            {
                CloudHogwarts_WebRole.Staff st = Classes.HogwartsDataAccess.GetStaff(lst[i].StaffID);
                string StaffName = st.FirstName + " " + st.LastName;
                NoticeLst.Add(new StaffNotice(lst[i].text));
            }
            index = 0;
            announcement.DataSource = NoticeLst;
            announcement.DataBind();
        }
    }
}