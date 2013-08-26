using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace CloudHogwarts_WebRole.Classes
{
    public class TempCourse
    {
        public TempCourse(int TempCourseID, string Semester, string Department, string Discipline, string Teacher, int? MaxCapacity)
        {
            this.TempCourseID = TempCourseID;
            this.Semester = Semester;
            this.Department = Department;
            this.Discipline = Discipline;
            this.Teacher = Teacher;
            this.MaxCapacity = MaxCapacity;
        }

        public int TempCourseID { get; set; }
        public string Semester { get; set; }
        public string Department { get; set; }
        public string Discipline { get; set; }
        public string Teacher { get; set; }
        public int? MaxCapacity { get; set; }
    }

    public class TempSession
    {
        public TempSession(int TempCourseID, int TempSessionID, int Classroom, string Weekday, string StartingTime, string FinishingTime)
        {
            this.TempCourseID = TempCourseID;
            this.TempSessionID = TempSessionID;
            this.Weekday = Weekday;
            this.StartingTime = StartingTime;
            this.FinishingTime = FinishingTime;
            this.Classroom = Classroom;
        }

        public int TempCourseID { get; set; }
        public int TempSessionID { get; set; }
        public int Classroom { get; set; }
        public string Weekday { get; set; }
        public string StartingTime { get; set; }
        public string FinishingTime { get; set; }
    }

    public static class Utility
    {

        public static string GetWeekday(int day)
        {
            switch (day)
            {
                case 2:
                    return "Monday";
                case 3:
                    return "Tuesday";
                case 4:
                    return "Wednesday";
                case 5:
                    return "Thursday";
            }
            return "Friday";
        }

        public static string GetStartingTime(int StartingPeriod)
        {
            switch (StartingPeriod)
            {
                case 1:
                    return "08:00 am";
                case 3:
                    return "10:00 am";
                case 5:
                    return "01:00 pm";
            }
            return "03:00 pm";
        }

        public static string GetFinishingTime(int StartingPeriod)
        {
            switch (StartingPeriod)
            {
                case 1:
                    return "09:50 am";
                case 3:
                    return "11:50 am";
                case 5:
                    return "02:50 pm";
            }
            return "04:50 pm";
        }

        public static List<TempSession> CreateNewTempSessionList(List<Session> SessionLst)
        {
            List<TempSession> TSessionLst = new List<TempSession>();
            foreach (Session s in SessionLst)
            {
                int CourseID = s.CourseID;
                int SessionID = s.SessionID;
                int Classroom = s.Classroom;
                string Weekday = GetWeekday(s.Weekday);
                string StartingTime = GetStartingTime(s.StartingPeriod);
                string FinishingTime = GetFinishingTime(s.StartingPeriod);
                
                TempSession ts = new TempSession(CourseID, SessionID, Classroom, Weekday, StartingTime, FinishingTime);
                TSessionLst.Add(ts);
            }
            return TSessionLst;
        }

        public static double MapGrade(string grade)
        {
            switch(grade)
            {
                case "A":
                    return 4.0;
                case "A-":
                    return 3.7;
                case "B+":
                    return 3.3;
                case "B":
                    return 3.0;
                case "B-":
                    return 2.7;
                case "C+":
                    return 2.3;
                case "C":
                    return 2.0;
            }
            return 0.0;
        }
    }
}