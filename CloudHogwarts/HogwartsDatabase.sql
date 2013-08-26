USE [HogwartsDatabase]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 06/21/2011 16:22:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Description] [varchar](1000) NOT NULL,
	[StudentNumber] [int] NULL,
	[StaffNumber] [int] NULL,
	[DisciplineNumber] [int] NULL,
	[DepartmentDeanID] [int] NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON
INSERT [dbo].[Department] ([DepartmentID], [Name], [Description], [StudentNumber], [StaffNumber], [DisciplineNumber], [DepartmentDeanID]) VALUES (1, N'Maseeh College of Engineering & Computer Science', N'<H4><FONT color=#000080 size=5>Engineering education in the heart of the Silicon Forest</FONT></H4><P><FONT color=#006400 size=4>Maseeh College of Engineering and Computer Science (Maseeh College) students take advantage of PSU''s proximity and access to technology-oriented companies in the metropolitan area.</FONT></P><P><FONT color=#006400 size=4>Maseeh College works hard to create Scholarship and Internship programs&nbsp;for its undergraduate and graduate students.</FONT></P><P align="center"><IMG src="../../Images/medium_Maseeh-College.jpg"></P><P><FONT color=#006400 size=4>Maseeh College has a rich history which has evolved over a 45-year period, paralleling the growth of the high-technology industry in Oregon. Consequently, Maseeh College has become the leading supplier of new employees for companies such as Intel Corporation and Tektronix, Inc.</FONT></P>', 2000, 200, 300, 13)
INSERT [dbo].[Department] ([DepartmentID], [Name], [Description], [StudentNumber], [StaffNumber], [DisciplineNumber], [DepartmentDeanID]) VALUES (2, N'School of Business Administration', N'<H3>The School of Business Administration (SBA) at Portland State University strives to contribute to the economic and social vitality of our local and global communities. </H3>', 1500, 150, 200, 7)
INSERT [dbo].[Department] ([DepartmentID], [Name], [Description], [StudentNumber], [StaffNumber], [DisciplineNumber], [DepartmentDeanID]) VALUES (3, N'College of Liberal Arts & Sciences ', N'<P><FONT color=#000080 face=Arial size=4>As the largest academic school at Portland State, Liberal Arts &amp; Sciences has a lot going on.</FONT></P><P align=center><IMG src="../../Images/yellowstone.jpg"></P><DIV id=Breadcrumb align=center jQuery1308206386783="50"><FONT size=4>Photo by Louis Mazzatenta for <STRONG><I>National Geographic</I> </STRONG></FONT></DIV>', 5000, 500, 800, 4)
SET IDENTITY_INSERT [dbo].[Department] OFF
/****** Object:  Table [dbo].[Discipline]    Script Date: 06/21/2011 16:22:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Discipline](
	[DisciplineID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Description] [varchar](1000) NOT NULL,
	[CreditNumber] [int] NOT NULL,
	[PeriodPerWeek] [int] NOT NULL,
	[DepartmentID] [int] NULL,
 CONSTRAINT [PK_Discipline] PRIMARY KEY CLUSTERED 
(
	[DisciplineID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Discipline] ON
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (1, N'CS 350 Algorithms and Complexity', N'Techniques for the design and analysis of algorithms. Case studies of existing algorithms (sorting, searching, graph algorithms, dynamic programming, matrix multiplication fast Fourier transformation). NP-completeness.', 4, 4, 1)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (7, N'CS 163 Data Structures', N'Data abstraction with formal specification. Elementary algorithm analysis. Basic concepts of data and its representation inside a computer. Linear, linked, and orthogonal lists; tree structures. Data structures are implemented as data abstractions. Sorting and search strategies. Data management.', 4, 4, 1)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (8, N'CS 441 Artificial Intelligence', N'This course will provide students with an overview of the major topics and techniques of current-day artificial intelligence.', 4, 4, 1)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (9, N'CS 447 Computer Graphics', N'This course will provide an introduction to computer graphics and focus on how to use computers to produce and manipulate images.', 4, 4, 1)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (12, N'FIN 441 - Fundamentals of Derivative Securities', N'N/A', 3, 2, 2)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (13, N'FIN 456 - International Financial Management', N'N/A', 3, 2, 2)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (14, N'Ph 679 ADVANCED ATOMOSPHERIC PHYSICS', N'Advanced course to provide a working knowledge of base models for studying global change including the greenhouse effect, global warming, stratospheric ozone depletion from man-made chemicals, tropospheric chemistry of HO and O3 and transport modeling.', 2, 4, 3)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (17, N'Ph 201 GENERAL PHYSICS', N'Introductory physics for science majors. The student will explore topics in physics including Newtonian mechanics, electricity, and magnetism, thermal physics, optics, and modern physics.', 2, 4, 3)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (19, N'Mth 312 Advanced Multivariate Calculus ', N'Differential and integral calculus of functions of several variables, the inverse and implicit function theorems, infinite and power series, differential forms, line and surface integrals, Green''s, Stokes'', and Gauss'' theorems. Courses must be taken in sequence.', 4, 4, 3)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (20, N'Mth 343 Applied Linear Algebra', N'Topics in matrix algebra, determinants, systems of linear equations, eigenvalues, eigenvectors, and linear transformations. Selected applications from science, engineering, computer science, and business.', 4, 4, 3)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (21, N'Accounting (ACTG) 421 - Introduction to Taxation', N'N/A', 4, 4, 2)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (22, N'Accounting (ACTG) 430 - Governmental and Not-for-Profit Accounting', N'N/A', 1, 2, 2)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (23, N'FIN 319 - Intermediate Financial Management', N'N/A', 4, 4, 2)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (25, N'CS 321 Languages and Compiler Design I ', N'Principles of programming languages and language implementation by compilation. Techniques of language definition. Run-time behavior of programs. Compilation by recursive descent. Use of LR compiler-generation tools. Design and implementation of a compiler for a small language.', 4, 4, 1)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (26, N'CS 322 Languages and Compiler Design II ', N'Principles of programming languages and language implementation by compilation. Techniques of language definition. Run-time behavior of programs. Compilation by recursive descent. Use of LR compiler-generation tools. Design and implementation of a compiler for a small language.', 4, 4, 1)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (27, N'CS 386 Introduction to Databases ', N'Introduction to fundamental concepts of database management with the relational model. Schema design and refinement, query languages, transaction management, security, database application environments, physical data organization, overview of query processing, physical design tuning.', 4, 4, 1)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (28, N'CS 333 Introduction to Operating Systems ', N'Introduction to the principles of operating systems and concurrent programming. Operating system services, file systems, resource management, synchronization. The concept of a process; process cooperation and interference. Introduction to networks, and protection and security. Examples drawn from one or more modern operating systems. Programming projects, including concurrent programming.', 4, 4, 1)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (29, N'Mth 338 - Modern College Geometry', N'Topics in Euclidean and non-Euclidean geometry.', 3, 2, 3)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (30, N'CH 321 Quant Analysis Lab', N'N/A', 2, 2, 3)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (31, N'CH 337M Organic Chem Lab', N'N/A', 2, 2, 3)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (32, N'G 203 Historical Geology ', N'N/A', 3, 2, 3)
INSERT [dbo].[Discipline] ([DisciplineID], [Name], [Description], [CreditNumber], [PeriodPerWeek], [DepartmentID]) VALUES (33, N'G 435 Stratigraphy and Sedimentation', N'N/A', 5, 4, 3)
SET IDENTITY_INSERT [dbo].[Discipline] OFF
/****** Object:  Table [dbo].[House]    Script Date: 06/21/2011 16:22:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[House](
	[HouseID] [int] IDENTITY(1,1) NOT NULL,
	[HouseName] [varchar](100) NOT NULL,
	[Description] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_House] PRIMARY KEY CLUSTERED 
(
	[HouseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[House] ON
INSERT [dbo].[House] ([HouseID], [HouseName], [Description]) VALUES (1, N'Blumel Hall', N'This building forms an "L" shape between Science Bldg. 2 and Parking Structure 3. This nine-story, 195,500 sq. ft. building was built by PSU in 1986.')
INSERT [dbo].[House] ([HouseID], [HouseName], [Description]) VALUES (2, N'The Blackstone', N'This five-story building is located in the Park Blocks, just north of Millar Library, and was built in 1931.')
INSERT [dbo].[House] ([HouseID], [HouseName], [Description]) VALUES (3, N'Ondine', N'Built in 1932 and acquired by PSU in 1969, the Parkway is a five-story student residence consisting of 40,500 sq. ft.')
INSERT [dbo].[House] ([HouseID], [HouseName], [Description]) VALUES (4, N'Stephen E. Epler Hall', N'Built in 2003, Epler Hall is one of the newest additions to Portland State University''s on-campus housing.')
SET IDENTITY_INSERT [dbo].[House] OFF
/****** Object:  Table [dbo].[Student]    Script Date: 06/21/2011 16:22:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[MagicalSecurityNumber] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[MmailAddress] [varchar](100) NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Nationality] [varchar](100) NOT NULL,
	[Female] [bit] NOT NULL,
	[AcquiredCreditNumber] [int] NULL,
	[GradePointAverage] [float] NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[HouseID] [int] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON
INSERT [dbo].[Student] ([StudentID], [MagicalSecurityNumber], [DepartmentID], [MmailAddress], [FirstName], [LastName], [Nationality], [Female], [AcquiredCreditNumber], [GradePointAverage], [UserName], [Password], [HouseID]) VALUES (1, 11000, 1, N'harry.potter@pdx.edu', N'Harry', N'Potter', N'England', 0, NULL, NULL, N'harry_potter', N'harry_potter', 1)
INSERT [dbo].[Student] ([StudentID], [MagicalSecurityNumber], [DepartmentID], [MmailAddress], [FirstName], [LastName], [Nationality], [Female], [AcquiredCreditNumber], [GradePointAverage], [UserName], [Password], [HouseID]) VALUES (3, 12000, 1, N'ron.weasley@pdx.edu', N'Ron', N'Weasley', N'England', 0, NULL, NULL, N'ron_weasley', N'ron_weasley', 1)
INSERT [dbo].[Student] ([StudentID], [MagicalSecurityNumber], [DepartmentID], [MmailAddress], [FirstName], [LastName], [Nationality], [Female], [AcquiredCreditNumber], [GradePointAverage], [UserName], [Password], [HouseID]) VALUES (5, 13000, 2, N'hermione.granger', N'Hermione', N'Granger', N'England', 1, NULL, NULL, N'hermione_granger', N'hermione_granger', 3)
INSERT [dbo].[Student] ([StudentID], [MagicalSecurityNumber], [DepartmentID], [MmailAddress], [FirstName], [LastName], [Nationality], [Female], [AcquiredCreditNumber], [GradePointAverage], [UserName], [Password], [HouseID]) VALUES (6, 14000, 2, N'sookie.stackhouse@pdx.edu', N'Sookie', N'Stackhouse', N'USA', 1, NULL, NULL, N'sookie_stackhouse', N'sookie_stackhouse', 2)
INSERT [dbo].[Student] ([StudentID], [MagicalSecurityNumber], [DepartmentID], [MmailAddress], [FirstName], [LastName], [Nationality], [Female], [AcquiredCreditNumber], [GradePointAverage], [UserName], [Password], [HouseID]) VALUES (9, 15000, 3, N'eric.northman@pdx.edu', N'Eric', N'Northman', N'USA', 0, NULL, NULL, N'eric_northman', N'eric_northman', 4)
INSERT [dbo].[Student] ([StudentID], [MagicalSecurityNumber], [DepartmentID], [MmailAddress], [FirstName], [LastName], [Nationality], [Female], [AcquiredCreditNumber], [GradePointAverage], [UserName], [Password], [HouseID]) VALUES (10, 16000, 3, N'paul.cho@pdx.edu', N'Paul', N'Cho', N'USA', 0, NULL, NULL, N'paul_cho', N'paul_cho', 1)
SET IDENTITY_INSERT [dbo].[Student] OFF
/****** Object:  Table [dbo].[StudentRequest]    Script Date: 06/21/2011 16:22:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentRequest](
	[StudentID] [int] NOT NULL,
	[NewFirstName] [nvarchar](50) NOT NULL,
	[NewLastName] [nvarchar](50) NOT NULL,
	[NewNationality] [varchar](100) NOT NULL,
	[NewMMailAddress] [varchar](100) NOT NULL,
	[NewHouseName] [varchar](100) NOT NULL,
	[RequestID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_StudentRequest] PRIMARY KEY CLUSTERED 
(
	[RequestID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 06/21/2011 16:22:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semester](
	[SemesterID] [int] IDENTITY(1,1) NOT NULL,
	[Time] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[SemesterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Semester] ON
INSERT [dbo].[Semester] ([SemesterID], [Time]) VALUES (1, N'Fall 2010')
INSERT [dbo].[Semester] ([SemesterID], [Time]) VALUES (2, N'Winter 2011')
INSERT [dbo].[Semester] ([SemesterID], [Time]) VALUES (3, N'Spring 2011')
SET IDENTITY_INSERT [dbo].[Semester] OFF
/****** Object:  Table [dbo].[Staff]    Script Date: 06/21/2011 16:22:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[MmailAddress] [varchar](100) NULL,
	[Nationality] [varchar](100) NOT NULL,
	[MagicalSecurityNumber] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[Female] [bit] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Staff] ON
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [MmailAddress], [Nationality], [MagicalSecurityNumber], [DepartmentID], [Female], [UserName], [Password]) VALUES (4, N'Dick', N'Knight', N'dknight@pdx.edu', N'USA', 10000, 3, 0, N'dick_knight', N'dick_knight')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [MmailAddress], [Nationality], [MagicalSecurityNumber], [DepartmentID], [Female], [UserName], [Password]) VALUES (6, N'Melissa', N'Leonard', N'mleonard@pdx.edu', N'Canada', 20000, 3, 1, N'melissa_leonard', N'melissa_leonard')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [MmailAddress], [Nationality], [MagicalSecurityNumber], [DepartmentID], [Female], [UserName], [Password]) VALUES (7, N'Kathy', N'Black', N'kblack@pdx.edu', N'England', 30000, 2, 1, N'kathy_black', N'kathy_black')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [MmailAddress], [Nationality], [MagicalSecurityNumber], [DepartmentID], [Female], [UserName], [Password]) VALUES (8, N'Tina', N'Ford', NULL, N'USA', 40000, 2, 1, N'tina_ford', N'tina_ford')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [MmailAddress], [Nationality], [MagicalSecurityNumber], [DepartmentID], [Female], [UserName], [Password]) VALUES (12, N'Jones', N'Mark', N'mpj@cs.pdx.edu', N'USA', 50000, 1, 0, N'jones_mark', N'jones_mark')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [MmailAddress], [Nationality], [MagicalSecurityNumber], [DepartmentID], [Female], [UserName], [Password]) VALUES (13, N'Feng', N'Wuchi', N'wuchi@cs.pdx.edu', N'China', 60000, 1, 0, N'feng_wuchi', N'feng_wuchi')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [MmailAddress], [Nationality], [MagicalSecurityNumber], [DepartmentID], [Female], [UserName], [Password]) VALUES (14, N'Fant', N'Karla', N'karlaf@cs.pdx.edu', N'USA', 70000, 1, 1, N'fant_karla', N'fant_karla')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [MmailAddress], [Nationality], [MagicalSecurityNumber], [DepartmentID], [Female], [UserName], [Password]) VALUES (15, N'Scott', N'F. Burns', N'scott@pdx.edu', N'USA', 90000, 3, 0, N'scott', N'scott')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [MmailAddress], [Nationality], [MagicalSecurityNumber], [DepartmentID], [Female], [UserName], [Password]) VALUES (16, N'Andrew', N'G. Fountain', N'andrew@pdx.edu', N'Greece', 10001, 3, 0, N'andrew', N'andrew')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [MmailAddress], [Nationality], [MagicalSecurityNumber], [DepartmentID], [Female], [UserName], [Password]) VALUES (17, N'Christina', N'L. Hulbe', N'christina@pdx.edu', N'USA', 10003, 3, 1, N'christina', N'christina')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [MmailAddress], [Nationality], [MagicalSecurityNumber], [DepartmentID], [Female], [UserName], [Password]) VALUES (18, N'Martin', N'J. Streck', N'martin@pdx.edu', N'France', 10005, 2, 0, N'martin', N'martin')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [MmailAddress], [Nationality], [MagicalSecurityNumber], [DepartmentID], [Female], [UserName], [Password]) VALUES (19, N'Alex', N'M. Ruzicka', N'alex@pdx.edu', N'Ireland', 10007, 2, 1, N'alex', N'alex')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [MmailAddress], [Nationality], [MagicalSecurityNumber], [DepartmentID], [Female], [UserName], [Password]) VALUES (20, N'Curt', N'D. Peterson', N'curt@pdx.edu', N'Russia', 10009, 2, 0, N'curt', N'curt')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [MmailAddress], [Nationality], [MagicalSecurityNumber], [DepartmentID], [Female], [UserName], [Password]) VALUES (21, N'Antoy', N'Sergio', N'antoy@pdx.edu', N'USA', 10011, 1, 0, N'antoy', N'antoy')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [MmailAddress], [Nationality], [MagicalSecurityNumber], [DepartmentID], [Female], [UserName], [Password]) VALUES (22, N'Xie', N'Fei', N'xie@pdx.edu', N'China', 10013, 1, 1, N'xie', N'xie')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [MmailAddress], [Nationality], [MagicalSecurityNumber], [DepartmentID], [Female], [UserName], [Password]) VALUES (23, N'Sheard', N'Tim', N'sheard@pdx.edu', N'India', 10015, 1, 0, N'sheard', N'sheard')
INSERT [dbo].[Staff] ([StaffID], [FirstName], [LastName], [MmailAddress], [Nationality], [MagicalSecurityNumber], [DepartmentID], [Female], [UserName], [Password]) VALUES (25, N'Harrison', N'Warren', N'harrison', N'USA', 10017, 1, 0, N'harrison', N'harrison')
SET IDENTITY_INSERT [dbo].[Staff] OFF
/****** Object:  Table [dbo].[Course]    Script Date: 06/21/2011 16:22:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[SemesterID] [int] NOT NULL,
	[DisciplineID] [int] NOT NULL,
	[StaffID] [int] NOT NULL,
	[AttendeeNumber] [int] NULL,
	[MaxCapacity] [int] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentInCourse]    Script Date: 06/21/2011 16:22:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentInCourse](
	[StudentID] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
	[CourseGPA] [varchar](10) NULL,
 CONSTRAINT [PK_StudentInCourse] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[CourseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Article]    Script Date: 06/21/2011 16:22:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Article](
	[ArticleID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Content] [text] NOT NULL,
	[StaffID] [int] NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED 
(
	[ArticleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Article] ON
INSERT [dbo].[Article] ([ArticleID], [Title], [Content], [StaffID], [DateTime]) VALUES (30, N'rrrrrrrrrrr', N'<P>ertetetre dsfdsfdsf</P>
<P align=center><STRONG>asdsadsadsadsadsadsadsadsadsd</STRONG></P>
<P align=center><IMG src="http://127.0.0.1:10000/devstoreaccount1/gallery/ttt"></P>
<P>sadasdsadsadsadsadsadasd dsf asfkas gdfgks dfghs fghs dfj sadfgajds kdjk dvkajsf ksfasjdf dsgi agias iadifhir iaeuri gaeiurgirea igargia ig&nbsp; sd </P>
<P align=right><STRONG>sd asgiuae iruer </STRONG></P>', 4, CAST(0x00009F0900D2416E AS DateTime))
SET IDENTITY_INSERT [dbo].[Article] OFF
/****** Object:  Table [dbo].[Session]    Script Date: 06/21/2011 16:22:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Session](
	[CourseID] [int] NOT NULL,
	[SessionID] [int] IDENTITY(1,1) NOT NULL,
	[Classroom] [int] NOT NULL,
	[Weekday] [int] NOT NULL,
	[PeriodNumber] [int] NOT NULL,
	[StartingPeriod] [int] NOT NULL,
 CONSTRAINT [PK_Session] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC,
	[SessionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Article_Staff]    Script Date: 06/21/2011 16:22:09 ******/
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_Article_Staff] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[Article] CHECK CONSTRAINT [FK_Article_Staff]
GO
/****** Object:  ForeignKey [FK_Course_Discipline]    Script Date: 06/21/2011 16:22:09 ******/
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Discipline] FOREIGN KEY([DisciplineID])
REFERENCES [dbo].[Discipline] ([DisciplineID])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Discipline]
GO
/****** Object:  ForeignKey [FK_Course_Semester]    Script Date: 06/21/2011 16:22:09 ******/
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Semester] FOREIGN KEY([SemesterID])
REFERENCES [dbo].[Semester] ([SemesterID])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Semester]
GO
/****** Object:  ForeignKey [FK_Course_Staff]    Script Date: 06/21/2011 16:22:09 ******/
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Staff] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Staff]
GO
/****** Object:  ForeignKey [FK_Department_Staff]    Script Date: 06/21/2011 16:22:09 ******/
ALTER TABLE [dbo].[Department]  WITH CHECK ADD  CONSTRAINT [FK_Department_Staff] FOREIGN KEY([DepartmentDeanID])
REFERENCES [dbo].[Staff] ([StaffID])
GO
ALTER TABLE [dbo].[Department] CHECK CONSTRAINT [FK_Department_Staff]
GO
/****** Object:  ForeignKey [FK_Discipline_Department]    Script Date: 06/21/2011 16:22:09 ******/
ALTER TABLE [dbo].[Discipline]  WITH CHECK ADD  CONSTRAINT [FK_Discipline_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentID])
GO
ALTER TABLE [dbo].[Discipline] CHECK CONSTRAINT [FK_Discipline_Department]
GO
/****** Object:  ForeignKey [FK_Session_Course]    Script Date: 06/21/2011 16:22:09 ******/
ALTER TABLE [dbo].[Session]  WITH CHECK ADD  CONSTRAINT [FK_Session_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[Session] CHECK CONSTRAINT [FK_Session_Course]
GO
/****** Object:  ForeignKey [FK_Staff_Department]    Script Date: 06/21/2011 16:22:09 ******/
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentID])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Department]
GO
/****** Object:  ForeignKey [FK_Student_Department]    Script Date: 06/21/2011 16:22:09 ******/
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Department] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([DepartmentID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Department]
GO
/****** Object:  ForeignKey [FK_Student_House]    Script Date: 06/21/2011 16:22:09 ******/
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_House] FOREIGN KEY([HouseID])
REFERENCES [dbo].[House] ([HouseID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_House]
GO
/****** Object:  ForeignKey [FK_StudentInCourse_Course]    Script Date: 06/21/2011 16:22:09 ******/
ALTER TABLE [dbo].[StudentInCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentInCourse_Course] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[StudentInCourse] CHECK CONSTRAINT [FK_StudentInCourse_Course]
GO
/****** Object:  ForeignKey [FK_StudentInCourse_Student]    Script Date: 06/21/2011 16:22:09 ******/
ALTER TABLE [dbo].[StudentInCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentInCourse_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[StudentInCourse] CHECK CONSTRAINT [FK_StudentInCourse_Student]
GO
/****** Object:  ForeignKey [FK_StudentRequest_Student]    Script Date: 06/21/2011 16:22:09 ******/
ALTER TABLE [dbo].[StudentRequest]  WITH CHECK ADD  CONSTRAINT [FK_StudentRequest_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[StudentRequest] CHECK CONSTRAINT [FK_StudentRequest_Student]
GO
