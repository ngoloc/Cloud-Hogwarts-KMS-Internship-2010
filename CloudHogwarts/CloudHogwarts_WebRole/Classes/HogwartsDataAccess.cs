using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Linq;
using System.Data;

namespace CloudHogwarts_WebRole.Classes
{

    public static class HogwartsDataAccess
    {
        public static string ConnectionString { get; set; }
        static HogwartsDataAccess()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["HogwartsDatabaseConnectionString"].ConnectionString;
        }

        public static List<Semester> GetAllSemesters()
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var result = (from semester in context.Semesters
                          select semester).ToList<Semester>();
            context.Connection.Close();
            return result;
        }

        public static IQueryable<string> GetSemesterList()
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var result = (from semester in context.Semesters
                          select semester.Time);
            context.Connection.Close();
            return result;
        }

        public static Department GetDepartment(string username)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var result = (from stu in context.Students
                          where stu.UserName == username
                          select stu).First();
            return result.Department;
        }

        public static List<Department> GetDepartments()
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var result = (from department in context.Departments
                          select department).ToList<Department>();
            context.Connection.Close();
            return result;
        }

        public static IQueryable<string> GetDepartmentList()
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var result = (from department in context.Departments
                          select department.Name);
            context.Connection.Close();
            return result;
        }

        public static List<Discipline> GetDisciplines(int departmentID)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext();
            var result = (from discipline in context.Disciplines
                          where discipline.DepartmentID == departmentID
                          select discipline).ToList<Discipline>();
            context.Connection.Close();
            return result;
        }
        public static Discipline GetDiscipline(int disciplineID)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            Discipline discipline = (from d in context.Disciplines
                                     where d.DisciplineID == disciplineID
                                     select d).FirstOrDefault<Discipline>();
            context.Connection.Close();
            return discipline;
        }
        public static List<Staff> GetStaffs(int deparmentID)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext();
            var result = (from staff in context.Staffs
                          where staff.DepartmentID == deparmentID
                          select staff).ToList<Staff>();
            context.Connection.Close();
            return result;
        }
        public static int InsertCourse(Course course)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            context.Courses.InsertOnSubmit(course);
            context.SubmitChanges();
            context.Connection.Close();
            return course.CourseID;
        }
        public static int InsertSession(Session session)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            context.Sessions.InsertOnSubmit(session);
            context.SubmitChanges();
            context.Connection.Close();
            return session.SessionID;
        }
        public static void DeleteCourse(Course course)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            Course outCourse = (from c in context.Courses
                                where c.CourseID == course.CourseID
                                select c).FirstOrDefault<Course>();
            context.Courses.DeleteOnSubmit(outCourse);
            context.SubmitChanges();
            context.Connection.Close();
        }
        public static void DeleteSession(Session session)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            Session outSession = (from s in context.Sessions
                                  where s.CourseID == session.CourseID && s.SessionID == session.SessionID
                                  select s).FirstOrDefault<Session>();
            context.Sessions.DeleteOnSubmit(outSession);
            context.SubmitChanges();
            context.Connection.Close();
        }
        public static void DeleteCourseList(List<Course> courses)
        {
            foreach (Course course in courses)
            {
                DeleteCourse(course);
            }
        }
        public static void DeleteSessionList(List<Session> sessions)
        {
            foreach (Session session in sessions)
            {
                DeleteSession(session);
            }
        }
        public static Staff GetStaff(int staffID)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            Staff outStaff = (from staff in context.Staffs
                              where staff.StaffID == staffID
                              select staff).FirstOrDefault<Staff>();
            context.Connection.Close();
            return outStaff;
        }

        public static Staff GetStaff(string username)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            Staff outStaff = (from staff in context.Staffs
                              where staff.UserName == username
                              select staff).FirstOrDefault<Staff>();
            context.Connection.Close();
            return outStaff;
        }

        public static Semester GetSemester(int semesterID)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            Semester outSemester = (from semester in context.Semesters
                                 where semester.SemesterID == semesterID
                                 select semester).FirstOrDefault<Semester>();
            return outSemester;
        }
        public static List<Course> GetAllCourses()
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var courses = (from course in context.Courses
                           select course).ToList<Course>();
            context.Connection.Close();
            return courses;
        }
        public static List<Session> GetSessions(int courseID)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var sessions = (from session in context.Sessions
                            where session.CourseID == courseID
                            select session).ToList<Session>();
            context.Connection.Close();
            return sessions;
        }
        public static List<Course> GetCourses(int semesterID)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            List<Course> courses = (from course in context.Courses
                                    where course.SemesterID == semesterID
                                    select course).ToList<Course>();
            context.Connection.Close();
            return courses;
        }
        public static Student GetStudent(string UserName, string Password)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            Student student = (from stu in context.Students
                               where stu.UserName == UserName && stu.Password == Password
                               select stu).FirstOrDefault<Student>();
            context.Connection.Close();
            return student;
        }

        public static string GetStudentName(int StudentID)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            Student student = (from stu in context.Students
                               where stu.StudentID == StudentID
                               select stu).FirstOrDefault<Student>();
            context.Connection.Close();
            return student.FirstName+ " " + student.LastName;
        }
        public static Staff GetStaff(string UserName, string Password)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            Staff staff = (from sta in context.Staffs
                             where sta.UserName == UserName && sta.Password == Password
                             select sta).FirstOrDefault<Staff>();
            context.Connection.Close();
            return staff;
        }
        public static HogwartsDatabaseModelDataContext entity = new HogwartsDatabaseModelDataContext();
        public static List<Semester> ShowSemester()
        {
            var semesterQuery = from s in entity.Semesters
                                orderby s.SemesterID
                                select s;
            return semesterQuery.ToList<Semester>();

        }
        public static IQueryable ShowCourseOfDiscipline(String disciplineID, String semesterID)
        {
            int disId = Int32.Parse(disciplineID);
            int semId = Int32.Parse(semesterID);
            var courseQuery = from course in entity.Courses
                              from staff in entity.Staffs
                              from discipline in entity.Disciplines
                              where course.DisciplineID == disId && course.SemesterID == semId && course.StaffID == staff.StaffID && course.DisciplineID == discipline.DisciplineID
                              orderby course.CourseID
                              select new
                              {
                                  course.CourseID,
                                  course.DisciplineID,
                                  disName = discipline.Name,
                                  discipline.Description,
                                  course.AttendeeNumber,
                                  course.MaxCapacity,
                                  staff.MmailAddress,
                                  Name = staff.FirstName + " " + staff.LastName
                              };
            return courseQuery;
        }
        public static IQueryable ShowAllCourses(String semesterID)
        {
            int semId = Int32.Parse(semesterID);
            var courseQuery = from course in entity.Courses
                              from staff in entity.Staffs
                              from discipline in entity.Disciplines
                              where course.SemesterID == semId && course.StaffID == staff.StaffID && course.DisciplineID == discipline.DisciplineID
                              orderby course.CourseID
                              select new
                              {
                                  course.CourseID,
                                  course.DisciplineID,
                                  disName = discipline.Name,
                                  discipline.Description,
                                  course.AttendeeNumber,
                                  course.MaxCapacity,
                                  staff.MmailAddress,
                                  Name = staff.FirstName + " " + staff.LastName
                              };
            return courseQuery;
        }

        public static List<Session> ShowSession(String CourseID)
        {
            int CourseIDInt = Int32.Parse(CourseID);
            var sessionQuery = from s in entity.Sessions
                               where s.CourseID == CourseIDInt
                               select s;
            return sessionQuery.ToList<Session>();
        }

        public static bool checkCourse(int CourseID, int StudentID)
        {
            var courseDisciplineQuery = (from c in entity.Courses
                                         where c.CourseID == CourseID
                                         select c).First();
            int disID = (int)courseDisciplineQuery.DisciplineID;
            var courseQuery = from stuInCourse in entity.StudentInCourses
                              from course in entity.Courses
                              where stuInCourse.CourseID == course.CourseID && course.DisciplineID == disID && stuInCourse.StudentID == StudentID
                              select stuInCourse;

            List<StudentInCourse> list = courseQuery.ToList<StudentInCourse>();
            if (list.Count > 0)
                return true;
            else
                return false;

        }
        public static IQueryable ShowSchedule(int StudentID, int SemesterID)
        {
            var scheduleQuery = from stuInCourse in entity.StudentInCourses
                                from session in entity.Sessions
                                from course in entity.Courses
                                from staff in entity.Staffs
                                from discipline in entity.Disciplines
                                where stuInCourse.StudentID == StudentID && course.CourseID == stuInCourse.CourseID && session.CourseID == stuInCourse.CourseID
                                    && staff.StaffID == course.StaffID && discipline.DisciplineID == course.DisciplineID && course.SemesterID == SemesterID
                                orderby discipline.Name
                                select new
                                {
                                    Discipine = discipline.Name,
                                    StaffName = staff.FirstName + " " + staff.LastName,
                                    session.Classroom,
                                    session.Weekday,
                                    session.StartingPeriod,
                                    session.PeriodNumber

                                };
            return scheduleQuery;
        }
        public static String ShowStudent(int StudentID)
        {
            List<string> rs = new List<string>();
            var stuQuery = from s in entity.Students
                           where s.StudentID == StudentID
                           select s;
            foreach (Student s in stuQuery)
            {
                rs.Add(s.FirstName + " " + s.LastName);
            }
            return rs[0];
        }

        public static bool checkAttendee(int courseID)
        {
            var courseQuery = (from course in entity.Courses
                               where course.CourseID == courseID
                               select course).First();
            if (courseQuery.AttendeeNumber < courseQuery.MaxCapacity)
                return true;
            else
                return false;
        }

        public static int GetStudentID(string username)
        {
            if (username != null)
            {
                HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
                Student student = (from stu in context.Students
                                   where stu.UserName == username
                                   select stu).FirstOrDefault<Student>();
                //  context.Connection.Close();
                if (student == null)
                    return -1;
                return student.StudentID;
            }
            else
                return -1;
        }
        public static List<Student> GetStudent(int studentID)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            List<Student> students = (from stu in context.Students
                               where stu.StudentID == studentID
                               select stu).ToList<Student>();
            context.Connection.Close();
            return students;
        }

        public static IQueryable<string> GetDisciplineList(string deptname)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var disps = (from dept in context.Departments
                                      from disp in context.Disciplines
                                      where dept.Name == deptname && dept.DepartmentID == disp.DepartmentID
                                      select disp.Name );
            context.Connection.Close(); 
            return disps;
        }

        public static IQueryable GetTeacherList(string deptname)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var teachers = (from dept in context.Departments
                            from teacher in context.Staffs
                            where dept.Name == deptname && dept.DepartmentID == teacher.DepartmentID
                            select teacher.FirstName + " " + teacher.LastName);
            context.Connection.Close();
            return teachers;
        }

        public static int GetCreditHours(string dept, string disp)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var ret = (from department in context.Departments
                       from discipline in context.Disciplines
                       where department.DepartmentID == discipline.DepartmentID && department.Name == dept && discipline.Name == disp
                       select discipline.PeriodPerWeek).First();
            context.Connection.Close();
            return ret;
        }

        public static void FillAllottedTable(string time,string dept, string teacher, bool[][] AllottedTable)
        {
            for (int i = 2; i <= 6; i++)
                for (int j = 1; j <= 8; j++)
                    AllottedTable[i][j] = false;
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var ret = (from session in context.Sessions
                       where session.Course.Semester.Time == time && session.Course.Discipline.Department.Name == dept
                       && session.Course.Staff.FirstName+" "+session.Course.Staff.LastName == teacher
                       select session);
            foreach (Session s in ret)
            {
                AllottedTable[s.Weekday][s.StartingPeriod] = true;
                AllottedTable[s.Weekday][s.StartingPeriod+1] = true;
            }
            context.Connection.Close();
        }

        public static void FillAllottedClass(string time, bool[][][] AllottedClass)
        {
            for (int i = 1; i <= 10; i++)
                for (int j = 2; j <= 6; j++)
                    for (int k = 1; k <= 8; k++)
                        AllottedClass[i][j][k] = false;
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var ret = (from semester in context.Semesters
                       where semester.Time == time
                       from course in context.Courses
                       where course.SemesterID == semester.SemesterID
                       from session in context.Sessions
                       where session.CourseID == course.CourseID
                       select session);
            foreach (Session s in ret)
            {
                AllottedClass[s.Classroom][s.Weekday][s.StartingPeriod] = true;
                AllottedClass[s.Classroom][s.Weekday][s.StartingPeriod+1] = true;
            }
            context.Connection.Close();
        }

        public static int GetSemesterID(string time)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var ret = (from semester in context.Semesters
                       where semester.Time == time
                       select semester.SemesterID).First();
            context.Connection.Close();
            return ret;
        }

        public static int GetStaffID(string dept, string teacher)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var ret = (from department in context.Departments
                       where department.Name == dept
                       from staff in context.Staffs
                       where staff.FirstName + " " + staff.LastName == teacher && staff.DepartmentID == department.DepartmentID
                       select staff.StaffID).First();
            context.Connection.Close();
            return ret;
        }

        public static int GetDisciplineID(string dept, string disp)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var ret = (from department in context.Departments
                       where department.Name == dept
                       from discipline in context.Disciplines
                       where discipline.Name == disp && discipline.DepartmentID == department.DepartmentID
                       select discipline.DisciplineID).First();
            context.Connection.Close();
            return ret;
        }

        public static int GetDepartmentID(string dept)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var ret = (from department in context.Departments
                       where department.Name == dept
                       select department.DepartmentID).First();
            context.Connection.Close();
            return ret;
        }

        public static string GetDepartment(int DepartmentID)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var ret = (from department in context.Departments
                       where department.DepartmentID == DepartmentID
                       select department.Name).First();
            context.Connection.Close();
            return ret;
        }

        public static bool[][] GetStudentAllotedTable(int SemesterID,int StudentID)
        {
            bool[][] sat = new bool[7][];
            for (int i = 0; i < 7; i++)
                sat[i] = new bool[9];
            for (int i = 0; i < 7; i++)
                for (int j = 0; j < 9; j++)
                    sat[i][j] = false;
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);

            var sessions = (from sic in context.StudentInCourses
                            where sic.StudentID == StudentID && sic.Course.SemesterID == SemesterID
                            from s in context.Sessions
                            where s.CourseID == sic.CourseID
                            select s);
            foreach (Session s in sessions)
            {
                sat[s.Weekday][s.StartingPeriod] = true;
                sat[s.Weekday][s.StartingPeriod+1] = true;
            }
            context.Connection.Close();
            return sat;
        }

        public static bool StudentInCourse(int StudentID, int CourseID)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var ret = (from sic in context.StudentInCourses
                       where sic.StudentID == StudentID && sic.CourseID == CourseID
                       select sic);
            context.Connection.Close();
            if (ret.Count() == 0)
                return false;
            return true;
        }

        public static Course GetCourse(int CourseID)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var course = (from c in context.Courses
                          where c.CourseID == CourseID
                          select c).First();
            context.Connection.Close();
            return course;
        }

        public static string GetStudentInCourse(int StudentID, int CourseID)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var CourseGPA = (from sic in context.StudentInCourses
                       where sic.StudentID == StudentID && sic.CourseID == CourseID
                       select sic.CourseGPA).First();
            context.Connection.Close();
            return CourseGPA;
        }

        public static int GetRole(string username)
        {
            HogwartsDatabaseModelDataContext context = new HogwartsDatabaseModelDataContext(ConnectionString);
            var staff = (from s in context.Staffs
                     where username == s.UserName
                     select s);
            if (staff.Count() == 0)
                return 0;
            return 1;
        }
    }
}