using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CloudHogwarts_WebRole.Classes;

namespace CloudHogwarts_WebRole.StaffWorks.CourseManagement
{
    public partial class GenerateCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Classes.HogwartsDataAccess.GetRole(Context.User.Identity.Name) == 0)
                Response.Redirect("~/StudentWorks/StudentHome/StudentProfile.aspx");
            if (!Page.IsPostBack)
            {
                RestartGeneration();
                HideInfo();
            }
        }
        private void RestartGeneration()
        {
            DropDownList1.DataSource = Classes.HogwartsDataAccess.GetSemesterList();
            DropDownList1.DataBind();
            DropDownList1.SelectedIndex = 0;
            DropDownList2.DataSource = Classes.HogwartsDataAccess.GetDepartmentList();
            DropDownList2.DataBind();
            DropDownList2.SelectedIndex = 0;
            DropDownList3.DataSource = Classes.HogwartsDataAccess.GetDisciplineList(DropDownList2.SelectedValue);
            DropDownList3.DataBind();
            RadioButtonList1.SelectedIndex = 0;
            DropDownList4.DataSource = Classes.HogwartsDataAccess.GetTeacherList(DropDownList2.SelectedValue);
            DropDownList4.DataBind();
        }

        protected void ChangeDept(object sender, EventArgs e)
        {
            DropDownList3.DataSource = Classes.HogwartsDataAccess.GetDisciplineList(DropDownList2.SelectedValue);
            DropDownList3.DataBind();
            RadioButtonList1.SelectedIndex = 0;
            DropDownList4.DataSource = Classes.HogwartsDataAccess.GetTeacherList(DropDownList2.SelectedValue);
            DropDownList4.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            RestartGeneration();
            HideInfo();
            HogwartsDatabaseModelDataContext db = new HogwartsDatabaseModelDataContext();

            Dictionary<int, int> D = new Dictionary<int, int>();

            foreach (Course c in (List<Course>)Session["CourseLst"])
            {
                int disp1 = c.CourseID;
                db.Courses.InsertOnSubmit(c);
                db.SubmitChanges();
                int disp2 = c.CourseID;
                D[disp1] = disp2;
            }

            foreach (Session s in (List<Session>)Session["SessionLst"])
            {
                s.CourseID = D[s.CourseID];
                db.Sessions.InsertOnSubmit(s);
                db.SubmitChanges();
            }
            db.Connection.Close();
            Response.Redirect("GenerateCourses.aspx");
        }

        private void HideInfo()
        {
            Label1.Text = "";
            CourseGeH.Visible = false;
            GridView1.Visible = false;
            SessionGeH.Visible = false;
            GridView2.Visible = false;
            Button2.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Teacher has at most 4 teaching hours everday
            //There're 8 periods from 8 -> 15 (from Monday -> Friday)
            //There're only 2 kinds of credit hours: 2 hrs(1 session) & 4 hrs(2 sessions)
            //There're 10 classrooms in Hogwarts School (Room #1 -> Room #10)
            int CreditHours = Classes.HogwartsDataAccess.GetCreditHours(DropDownList2.SelectedValue, DropDownList3.SelectedValue);
            bool[][] AllottedTable = new bool[7][];//8, 9, 10, 11, 12, 13, 14, 15
            for (int i = 0; i <= 6; i++)
                AllottedTable[i] = new bool[9];
            bool[][][] AllottedClass = new bool[11][][];

            for (int i = 0; i <= 10; i++)
                AllottedClass[i] = new bool[7][];

            for (int i = 0; i <= 10; i++)
                for (int j = 0; j <= 6; j++)
                    AllottedClass[i][j] = new bool[9];

            Classes.HogwartsDataAccess.FillAllottedTable(DropDownList1.SelectedValue, DropDownList2.SelectedValue, DropDownList4.SelectedValue, AllottedTable);
            Classes.HogwartsDataAccess.FillAllottedClass(DropDownList1.SelectedValue, AllottedClass);
            Session["CourseLst"] = new List<Course>();
            List<TempCourse> TCourseLst = new List<TempCourse>();
            Session["SessionLst"] = new List<Session>();
            List<TempSession> TSessionLst;
            string error = "";
            for (int i = 1; i <= RadioButtonList1.SelectedIndex + 1; i++)
            {
                Course c = new Course();
                c.CourseID = i;
                c.SemesterID = Classes.HogwartsDataAccess.GetSemesterID(DropDownList1.SelectedValue);
                c.StaffID = Classes.HogwartsDataAccess.GetStaffID(DropDownList2.SelectedValue, DropDownList4.SelectedValue);
                c.DisciplineID = Classes.HogwartsDataAccess.GetDisciplineID(DropDownList2.SelectedValue, DropDownList3.SelectedValue);
                c.MaxCapacity = 50;
                List<Course> LC = (List<Course>)Session["CourseLst"];
                LC.Add(c);
                Session["CourseLst"] = LC;
                TempCourse tc = new TempCourse(i, DropDownList1.SelectedValue, DropDownList2.SelectedValue, DropDownList3.SelectedValue, DropDownList4.SelectedValue, c.MaxCapacity);
                TCourseLst.Add(tc);
                List<Session> LS = (List<Session>)Session["SessionLst"];
                error = AddOneCourse(i, CreditHours, AllottedClass, AllottedTable, LS);
                Session["SessionLst"] = LS;
                if (error != "")
                    break;
            }

            if (error != "")
            {
                HideInfo();
                Label1.Text = error;
                return;
            }

            //show all new courses and sessions
            Label1.Text = "";
            TSessionLst = Utility.CreateNewTempSessionList((List<Session>)Session["SessionLst"]);
            CourseGeH.Visible = true;
            GridView1.DataSource = TCourseLst;
            GridView1.DataBind();
            GridView1.Visible = true;
            SessionGeH.Visible = true;
            GridView2.DataSource = TSessionLst;
            GridView2.DataBind();
            GridView2.Visible = true;
            Button2.Visible = true;
        }

        private bool SearchDay(ref bool FreeTime, int CourseID, int WeekDay, bool[][] AllotedTable, bool[][][] AllottedClass, ref int StartingPeriod, ref int ClassRoom)
        {
            int sum = 0;
            for (int i = 1; i <= 8; i++)
                if (AllotedTable[WeekDay][i])
                    sum++;
            if (sum >= 4)
                return false;
            for (int j = 1; j < 8; j++)
            {
                if (!AllotedTable[WeekDay][j] && !AllotedTable[WeekDay][j + 1])
                {
                    FreeTime = true;
                    for (int k = 1; k <= 10; k++)
                        if (!AllottedClass[k][WeekDay][j] && !AllottedClass[k][WeekDay][j + 1])
                        {
                            StartingPeriod = j;
                            ClassRoom = k;
                            return true;
                        }
                }
            }
            return false;
        }

        private string AddOneCourse(int CourseID, int CreditHrs, bool[][][] AllottedClass, bool[][] AllotedTable, List<Session> SessionLst)
        {
            bool FreeTime = false;
            if (CreditHrs == 2)
            {
                for (int i = 2; i <= 6; i++)
                {
                    int ClassRoom = 0;
                    int StartingPeriod = 0;
                    if (SearchDay(ref FreeTime, CourseID, i, AllotedTable, AllottedClass, ref StartingPeriod, ref ClassRoom))
                    {
                        AllotedTable[i][StartingPeriod] = AllotedTable[i][StartingPeriod + 1] = true;
                        AllottedClass[ClassRoom][i][StartingPeriod] = AllottedClass[ClassRoom][i][StartingPeriod + 1] = true;
                        Session s = new Session();
                        s.CourseID = CourseID;
                        s.SessionID = 1;
                        s.Classroom = ClassRoom;
                        s.Weekday = i;
                        s.StartingPeriod = StartingPeriod;
                        s.PeriodNumber = 2;
                        SessionLst.Add(s);
                        return "";
                    }
                }
            }
            else
            {
                for (int t1 = 2; t1 <= 5; t1++)
                    for (int t2 = t1 + 1; t2 <= 6; t2++)
                    {
                        FreeTime = false;
                        int ClassRoom1 = 0;
                        int StartingPeriod1 = 0;
                        if (SearchDay(ref FreeTime, CourseID, t1, AllotedTable, AllottedClass, ref StartingPeriod1, ref ClassRoom1))
                        {
                            AllotedTable[t1][StartingPeriod1] = AllotedTable[t1][StartingPeriod1 + 1] = true;
                            AllottedClass[ClassRoom1][t1][StartingPeriod1] = AllottedClass[ClassRoom1][t1][StartingPeriod1 + 1] = true;
                            int ClassRoom2 = 0;
                            int StartingPeriod2 = 0;
                            FreeTime = false;
                            if (SearchDay(ref FreeTime, CourseID, t2, AllotedTable, AllottedClass, ref StartingPeriod2, ref ClassRoom2))
                            {
                                AllotedTable[t2][StartingPeriod2] = AllotedTable[t2][StartingPeriod2 + 1] = true;
                                AllottedClass[ClassRoom2][t2][StartingPeriod2] = AllottedClass[ClassRoom2][t2][StartingPeriod2 + 1] = true;

                                Session s1 = new Session();
                                s1.CourseID = CourseID;
                                s1.SessionID = 1;
                                s1.Classroom = ClassRoom1;
                                s1.Weekday = t1;
                                s1.StartingPeriod = StartingPeriod1;
                                s1.PeriodNumber = 2;
                                SessionLst.Add(s1);

                                Session s2 = new Session();
                                s2.CourseID = CourseID;
                                s2.SessionID = 2;
                                s2.Classroom = ClassRoom2;
                                s2.Weekday = t2;
                                s2.StartingPeriod = StartingPeriod2;
                                s2.PeriodNumber = 2;
                                SessionLst.Add(s2);
                                return "";
                            }
                            AllotedTable[t1][StartingPeriod1] = AllotedTable[t1][StartingPeriod1 + 1] = false;
                            AllottedClass[ClassRoom1][t1][StartingPeriod1] = AllottedClass[ClassRoom1][t1][StartingPeriod1 + 1] = false;
                        }
                    }
            }
            if (FreeTime)
                return "Can't allocate rooms. All rooms are reserved";
            else
                return "Teacher is overworking";
        }
    }
}