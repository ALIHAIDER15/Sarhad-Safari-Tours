USE [master]
GO
/****** Object:  Database [Sarhad]    Script Date: 10/26/2020 6:18:57 AM ******/
CREATE DATABASE [Sarhad]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Sarhad', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSERVER\MSSQL\DATA\Sarhad.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Sarhad_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLSERVER\MSSQL\DATA\Sarhad_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Sarhad] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Sarhad].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Sarhad] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Sarhad] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Sarhad] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Sarhad] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Sarhad] SET ARITHABORT OFF 
GO
ALTER DATABASE [Sarhad] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Sarhad] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Sarhad] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Sarhad] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Sarhad] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Sarhad] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Sarhad] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Sarhad] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Sarhad] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Sarhad] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Sarhad] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Sarhad] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Sarhad] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Sarhad] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Sarhad] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Sarhad] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Sarhad] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Sarhad] SET RECOVERY FULL 
GO
ALTER DATABASE [Sarhad] SET  MULTI_USER 
GO
ALTER DATABASE [Sarhad] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Sarhad] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Sarhad] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Sarhad] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Sarhad] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Sarhad', N'ON'
GO
ALTER DATABASE [Sarhad] SET QUERY_STORE = OFF
GO
USE [Sarhad]
GO
/****** Object:  Table [dbo].[tbl_Admin]    Script Date: 10/26/2020 6:18:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Admin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[ImagePath] [nvarchar](300) NULL,
	[Admin_rank] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_category]    Script Date: 10/26/2020 6:18:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_category](
	[Category_id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_tbl_category] PRIMARY KEY CLUSTERED 
(
	[Category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_city]    Script Date: 10/26/2020 6:18:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_city](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_city] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ContactUs]    Script Date: 10/26/2020 6:18:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ContactUs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Subject] [nvarchar](50) NULL,
	[Message] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_ContactUs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Guide]    Script Date: 10/26/2020 6:18:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Guide](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Age] [nvarchar](200) NULL,
	[Gender] [nvarchar](200) NULL,
	[Name] [nvarchar](max) NULL,
	[Experience] [nvarchar](max) NULL,
	[Total_Tours] [nvarchar](max) NULL,
	[Charges] [nvarchar](max) NULL,
	[Govt_License] [nvarchar](max) NULL,
	[ImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_Guide] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Hotel_images]    Script Date: 10/26/2020 6:18:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Hotel_images](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Hotel_ID] [int] NULL,
	[ImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_Hotel_images] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Hotels]    Script Date: 10/26/2020 6:18:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Hotels](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
	[Gov_License] [nvarchar](max) NULL,
	[Standard] [nvarchar](max) NULL,
	[Charges] [nvarchar](max) NULL,
	[ImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_Hotels] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Items]    Script Date: 10/26/2020 6:18:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Items](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_Items] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_MakeMyTrip]    Script Date: 10/26/2020 6:18:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MakeMyTrip](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Item_ID] [int] NULL,
	[Package_ID] [int] NULL,
	[Hotel_ID] [int] NULL,
	[Guide_ID] [int] NULL,
	[To] [date] NULL,
	[From] [date] NULL,
	[Adults] [nvarchar](50) NULL,
	[Child] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Nic] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[Transport] [nvarchar](50) NULL,
	[Guide] [nvarchar](50) NULL,
	[Others] [nvarchar](50) NULL,
	[test] [int] NULL,
 CONSTRAINT [PK_tbl_MakeMyTrip] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_MemberShip]    Script Date: 10/26/2020 6:18:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MemberShip](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Price] [nvarchar](max) NULL,
	[Monthly_Cost] [nvarchar](max) NULL,
	[Monthly_Souvenirs] [nvarchar](max) NULL,
	[Trekking_Equipment] [nvarchar](max) NULL,
	[Extra_Field1] [nvarchar](max) NULL,
	[Extra_Field2] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_MemberShip] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Packages]    Script Date: 10/26/2020 6:18:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Packages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PackageName] [nvarchar](50) NULL,
	[PackageDescription] [nvarchar](max) NULL,
	[Date] [int] NULL,
	[Month] [nvarchar](50) NULL,
	[NoOfDays] [int] NULL,
	[Location] [nvarchar](50) NULL,
	[Standard] [nvarchar](50) NULL,
	[SpotSiteSeeing] [nvarchar](100) NULL,
	[Contact] [nvarchar](50) NULL,
	[ImagePath] [nvarchar](300) NULL,
 CONSTRAINT [PK_tbl_Packages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 10/26/2020 6:18:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_user](
	[User_id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Gender] [nvarchar](50) NULL,
	[Csharp] [bit] NULL,
	[Java] [bit] NULL,
	[Python] [bit] NULL,
	[CityId] [int] NULL,
	[DBO] [date] NULL,
	[ImagePath] [nvarchar](max) NULL,
	[Role] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_user] PRIMARY KEY CLUSTERED 
(
	[User_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_Admin] ON 

INSERT [dbo].[tbl_Admin] ([ID], [Name], [Email], [Password], [ImagePath], [Admin_rank]) VALUES (1, N'Ali ', N'Ali@gmail.com', N'Ali1234', N'/images/team-220311496.jpg', N'A')
INSERT [dbo].[tbl_Admin] ([ID], [Name], [Email], [Password], [ImagePath], [Admin_rank]) VALUES (3, N'waqas', N'waqas@gmail.com', N'waqas123', N'/images/team-120085889.jpg', N'E')
INSERT [dbo].[tbl_Admin] ([ID], [Name], [Email], [Password], [ImagePath], [Admin_rank]) VALUES (9, N'adil', N'adil@gmail.com', N'adas', N'/images/i320230708.jpg', N'A')
INSERT [dbo].[tbl_Admin] ([ID], [Name], [Email], [Password], [ImagePath], [Admin_rank]) VALUES (1002, N'wajidss', N'asadadas', N'asdad', N'/images/download20235305.png', N'E')
INSERT [dbo].[tbl_Admin] ([ID], [Name], [Email], [Password], [ImagePath], [Admin_rank]) VALUES (1003, N'adas', N'adasdada', N'adasd', N'/images/download20291583.png', NULL)
INSERT [dbo].[tbl_Admin] ([ID], [Name], [Email], [Password], [ImagePath], [Admin_rank]) VALUES (1005, N'Ali Haider', N'Ali@gmail.com', N'Ali123', N'/images/download20291583.png', N'A')
INSERT [dbo].[tbl_Admin] ([ID], [Name], [Email], [Password], [ImagePath], [Admin_rank]) VALUES (1006, N'koko', NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_Admin] ([ID], [Name], [Email], [Password], [ImagePath], [Admin_rank]) VALUES (1007, NULL, N'koko@gmail.com', N'koko', NULL, NULL)
INSERT [dbo].[tbl_Admin] ([ID], [Name], [Email], [Password], [ImagePath], [Admin_rank]) VALUES (1008, N'wajid', N'wajidsada', N'koko', NULL, NULL)
INSERT [dbo].[tbl_Admin] ([ID], [Name], [Email], [Password], [ImagePath], [Admin_rank]) VALUES (1009, N'wajid', N'wajidsada', N'adas', NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_Admin] OFF
SET IDENTITY_INSERT [dbo].[tbl_category] ON 

INSERT [dbo].[tbl_category] ([Category_id], [Name], [Description]) VALUES (6, N'haider', N'booss')
INSERT [dbo].[tbl_category] ([Category_id], [Name], [Description]) VALUES (7, N'whatsup', N'boossxx11')
SET IDENTITY_INSERT [dbo].[tbl_category] OFF
SET IDENTITY_INSERT [dbo].[tbl_city] ON 

INSERT [dbo].[tbl_city] ([CityId], [CityName]) VALUES (1, N'Peshawar')
INSERT [dbo].[tbl_city] ([CityId], [CityName]) VALUES (2, N'Karachi')
INSERT [dbo].[tbl_city] ([CityId], [CityName]) VALUES (3, N'Islamabad')
INSERT [dbo].[tbl_city] ([CityId], [CityName]) VALUES (4, N'Lahore')
INSERT [dbo].[tbl_city] ([CityId], [CityName]) VALUES (5, N'Multan')
INSERT [dbo].[tbl_city] ([CityId], [CityName]) VALUES (6, N'Pindi')
SET IDENTITY_INSERT [dbo].[tbl_city] OFF
SET IDENTITY_INSERT [dbo].[tbl_ContactUs] ON 

INSERT [dbo].[tbl_ContactUs] ([ID], [Name], [Email], [Subject], [Message]) VALUES (8, N'ali', N'emailasdas', N'ADSADAS', N'ASDA')
INSERT [dbo].[tbl_ContactUs] ([ID], [Name], [Email], [Subject], [Message]) VALUES (9, N'ASDA', N'GGGG', N'AAAA', N'SSS')
INSERT [dbo].[tbl_ContactUs] ([ID], [Name], [Email], [Subject], [Message]) VALUES (13, N'ali', N'HAIDER', N'aaaa', N'kia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haikia hall haiv')
INSERT [dbo].[tbl_ContactUs] ([ID], [Name], [Email], [Subject], [Message]) VALUES (15, N'ali', N'Ali@gmail.com', N'aaaa', N'aaa')
INSERT [dbo].[tbl_ContactUs] ([ID], [Name], [Email], [Subject], [Message]) VALUES (16, N'ss', N'ss', N'ss', N'ss')
INSERT [dbo].[tbl_ContactUs] ([ID], [Name], [Email], [Subject], [Message]) VALUES (17, N'ss', N'ss', N'ss', N'ss')
INSERT [dbo].[tbl_ContactUs] ([ID], [Name], [Email], [Subject], [Message]) VALUES (18, N'ss', N'ss', N'ss', N'ss')
INSERT [dbo].[tbl_ContactUs] ([ID], [Name], [Email], [Subject], [Message]) VALUES (19, N'ali', N'Ali@gmail.com', N'a', N'a')
INSERT [dbo].[tbl_ContactUs] ([ID], [Name], [Email], [Subject], [Message]) VALUES (20, N'ali', N'Ali@gmail.com', N'a', N'a')
SET IDENTITY_INSERT [dbo].[tbl_ContactUs] OFF
SET IDENTITY_INSERT [dbo].[tbl_Guide] ON 

INSERT [dbo].[tbl_Guide] ([ID], [Age], [Gender], [Name], [Experience], [Total_Tours], [Charges], [Govt_License], [ImagePath]) VALUES (1, N'12', N'male', N'ALI khan', N'10', N'120', N'5000', N'yes', N'/images/WhatsApp Image 2018-12-25 at 10.53.52 PM20333239.jpeg')
INSERT [dbo].[tbl_Guide] ([ID], [Age], [Gender], [Name], [Experience], [Total_Tours], [Charges], [Govt_License], [ImagePath]) VALUES (2, N'23', N'male', N'waqas', N'103', N'12032', N'500022', N'yes', N'/images/WhatsApp Image 2019-01-05 at 3.09.40 PM20264769.jpeg')
INSERT [dbo].[tbl_Guide] ([ID], [Age], [Gender], [Name], [Experience], [Total_Tours], [Charges], [Govt_License], [ImagePath]) VALUES (3, N'231', N'male', N'waqas g', N'10', N'120', N'5000', N'yes', N'/images/WhatsApp Image 2019-01-13 at 11.56.06 PM20062756.jpeg')
INSERT [dbo].[tbl_Guide] ([ID], [Age], [Gender], [Name], [Experience], [Total_Tours], [Charges], [Govt_License], [ImagePath]) VALUES (4, N'23', N'male', N'ALI abbas', N'10', N'120', N'5000', N'yes', N'/images/WhatsApp Image 2019-02-13 at 10.27.41 PM20065424.jpeg')
INSERT [dbo].[tbl_Guide] ([ID], [Age], [Gender], [Name], [Experience], [Total_Tours], [Charges], [Govt_License], [ImagePath]) VALUES (5, N'23', N'male', N'ALI', N'10', N'120', N'5000', N'yes', N'/images/WhatsApp Image 2018-12-18 at 10.30.09 PM20090411.jpeg')
INSERT [dbo].[tbl_Guide] ([ID], [Age], [Gender], [Name], [Experience], [Total_Tours], [Charges], [Govt_License], [ImagePath]) VALUES (9, N'23', N'male', N'ALI', N'10', N'5 till now', N'a', N'yes', N'/images/japan20101789.jpg')
INSERT [dbo].[tbl_Guide] ([ID], [Age], [Gender], [Name], [Experience], [Total_Tours], [Charges], [Govt_License], [ImagePath]) VALUES (10, N'23', N'male', N'ALI', N'10', N'120', N'5000', N'yes', N'/images/japan20151135.jpg')
INSERT [dbo].[tbl_Guide] ([ID], [Age], [Gender], [Name], [Experience], [Total_Tours], [Charges], [Govt_License], [ImagePath]) VALUES (11, N'23', N'male', N'ALI', N'10', N'120', N'500022', N'yes', NULL)
INSERT [dbo].[tbl_Guide] ([ID], [Age], [Gender], [Name], [Experience], [Total_Tours], [Charges], [Govt_License], [ImagePath]) VALUES (12, N'23', N'male', N'ALI', N'10', N'120', N'5000', N'yes', N'/images/lahore-68-scaled20284859.jpg')
INSERT [dbo].[tbl_Guide] ([ID], [Age], [Gender], [Name], [Experience], [Total_Tours], [Charges], [Govt_License], [ImagePath]) VALUES (13, N'asd', N'male', N'as', N'10', N'120', N'2000', N'yes', NULL)
SET IDENTITY_INSERT [dbo].[tbl_Guide] OFF
SET IDENTITY_INSERT [dbo].[tbl_Hotel_images] ON 

INSERT [dbo].[tbl_Hotel_images] ([ID], [Hotel_ID], [ImagePath]) VALUES (1, 0, N'/images/download (1)20140915.jpg')
INSERT [dbo].[tbl_Hotel_images] ([ID], [Hotel_ID], [ImagePath]) VALUES (2, 0, N'/images/download20140999.jpg')
INSERT [dbo].[tbl_Hotel_images] ([ID], [Hotel_ID], [ImagePath]) VALUES (3, 0, N'/images/download (1)20012876.jpg')
INSERT [dbo].[tbl_Hotel_images] ([ID], [Hotel_ID], [ImagePath]) VALUES (4, 0, N'/images/download20012931.jpg')
INSERT [dbo].[tbl_Hotel_images] ([ID], [Hotel_ID], [ImagePath]) VALUES (5, 0, N'/images/download (1)20020931.jpg')
INSERT [dbo].[tbl_Hotel_images] ([ID], [Hotel_ID], [ImagePath]) VALUES (6, 0, N'/images/download20035689.jpg')
INSERT [dbo].[tbl_Hotel_images] ([ID], [Hotel_ID], [ImagePath]) VALUES (7, 1011, N'/images/download (1)20221626.jpg')
INSERT [dbo].[tbl_Hotel_images] ([ID], [Hotel_ID], [ImagePath]) VALUES (8, 1012, N'/images/download20225285.jpg')
INSERT [dbo].[tbl_Hotel_images] ([ID], [Hotel_ID], [ImagePath]) VALUES (9, 1013, N'/images/download (1)20312333.jpg')
INSERT [dbo].[tbl_Hotel_images] ([ID], [Hotel_ID], [ImagePath]) VALUES (10, 1013, N'/images/download20313228.jpg')
INSERT [dbo].[tbl_Hotel_images] ([ID], [Hotel_ID], [ImagePath]) VALUES (11, 1016, N'/images/20423711Cat032036225020322402.jpg')
INSERT [dbo].[tbl_Hotel_images] ([ID], [Hotel_ID], [ImagePath]) VALUES (12, 1016, N'/images/20580866Cat032035245120322414.jpg')
INSERT [dbo].[tbl_Hotel_images] ([ID], [Hotel_ID], [ImagePath]) VALUES (13, 1016, N'/images/20580866Cat032037197920322425.jpg')
INSERT [dbo].[tbl_Hotel_images] ([ID], [Hotel_ID], [ImagePath]) VALUES (14, 1016, N'/images/20580866Cat032049276820322426.jpg')
INSERT [dbo].[tbl_Hotel_images] ([ID], [Hotel_ID], [ImagePath]) VALUES (15, 1017, N'/images/rock20465453.jpg')
INSERT [dbo].[tbl_Hotel_images] ([ID], [Hotel_ID], [ImagePath]) VALUES (16, 1017, N'/images/second20465455.jpg')
SET IDENTITY_INSERT [dbo].[tbl_Hotel_images] OFF
SET IDENTITY_INSERT [dbo].[tbl_Hotels] ON 

INSERT [dbo].[tbl_Hotels] ([ID], [Name], [Location], [Gov_License], [Standard], [Charges], [ImagePath]) VALUES (1, N'sabrina', N'islamabad', N'yes', N'5', N'60000', N'/images/WhatsApp Image 2019-09-20 at 7.44.49 PM20075926.jpeg')
INSERT [dbo].[tbl_Hotels] ([ID], [Name], [Location], [Gov_License], [Standard], [Charges], [ImagePath]) VALUES (3, N'sabrina 2', N'islamabad2', N'yes', N'5', N'60000', N'/images/WhatsApp Image 2018-12-13 at 11.45.16 PM20460605.jpeg')
INSERT [dbo].[tbl_Hotels] ([ID], [Name], [Location], [Gov_License], [Standard], [Charges], [ImagePath]) VALUES (7, N'aaaaaaaaaaasdawda', N'islamabad', N'yes', N'5', N'60000', N'/images/WhatsApp Image 2018-12-18 at 3.46.33 PM20553049.jpeg')
INSERT [dbo].[tbl_Hotels] ([ID], [Name], [Location], [Gov_License], [Standard], [Charges], [ImagePath]) VALUES (8, N'pc', N'karachi', N'yes', N'5', N'60000', N'/images/images20070662.jpg')
INSERT [dbo].[tbl_Hotels] ([ID], [Name], [Location], [Gov_License], [Standard], [Charges], [ImagePath]) VALUES (9, N'salatin', N'islamabad', N'yes', N'5', N'60000', N'/images/hotel-presidente-4s20073089.jpg')
INSERT [dbo].[tbl_Hotels] ([ID], [Name], [Location], [Gov_License], [Standard], [Charges], [ImagePath]) VALUES (10, N'sabrina', N'islamabad', N'yes', N'5', N'60000', N'/images/wawlc-exterior-7823-hor-wide20074639.jpg')
INSERT [dbo].[tbl_Hotels] ([ID], [Name], [Location], [Gov_License], [Standard], [Charges], [ImagePath]) VALUES (1007, N'demanchi', N'naran', N'yes', N'3 star', N'on season 5000 off season 10000', N'/images/swat41215-68-scaled20160053.jpg')
INSERT [dbo].[tbl_Hotels] ([ID], [Name], [Location], [Gov_License], [Standard], [Charges], [ImagePath]) VALUES (1010, N'sabrina', N'islamabad', N'yes', N'5', N'60000', N'/images/No_Image_Available.jpg')
INSERT [dbo].[tbl_Hotels] ([ID], [Name], [Location], [Gov_License], [Standard], [Charges], [ImagePath]) VALUES (1012, N'sabrina', N'islamabad', N'yes', N'5', N'60000', N'')
INSERT [dbo].[tbl_Hotels] ([ID], [Name], [Location], [Gov_License], [Standard], [Charges], [ImagePath]) VALUES (1013, N'sabrina 2', N'islamabad', N'yes', N'5', N'60000', NULL)
INSERT [dbo].[tbl_Hotels] ([ID], [Name], [Location], [Gov_License], [Standard], [Charges], [ImagePath]) VALUES (1014, N'sabrina', N'islamabad', N'yes', N'5', N'60000', NULL)
INSERT [dbo].[tbl_Hotels] ([ID], [Name], [Location], [Gov_License], [Standard], [Charges], [ImagePath]) VALUES (1015, N'q', N'q', N'q', N'q', N'q', NULL)
INSERT [dbo].[tbl_Hotels] ([ID], [Name], [Location], [Gov_License], [Standard], [Charges], [ImagePath]) VALUES (1016, N'sabrina', N'islamabad', N'yes', N'5', N'60000', NULL)
INSERT [dbo].[tbl_Hotels] ([ID], [Name], [Location], [Gov_License], [Standard], [Charges], [ImagePath]) VALUES (1017, N'sabrina', N'islamabad', N'yes', N'5', N'60000', NULL)
SET IDENTITY_INSERT [dbo].[tbl_Hotels] OFF
SET IDENTITY_INSERT [dbo].[tbl_Items] ON 

INSERT [dbo].[tbl_Items] ([ID], [Name]) VALUES (1, N'Tent')
INSERT [dbo].[tbl_Items] ([ID], [Name]) VALUES (2, N'Stove ')
INSERT [dbo].[tbl_Items] ([ID], [Name]) VALUES (3, N'Bags')
INSERT [dbo].[tbl_Items] ([ID], [Name]) VALUES (4, N'Jeep')
INSERT [dbo].[tbl_Items] ([ID], [Name]) VALUES (5, N'First aid kit')
INSERT [dbo].[tbl_Items] ([ID], [Name]) VALUES (6, N'Rain jacket')
INSERT [dbo].[tbl_Items] ([ID], [Name]) VALUES (7, N'Navigation tool.')
SET IDENTITY_INSERT [dbo].[tbl_Items] OFF
SET IDENTITY_INSERT [dbo].[tbl_MakeMyTrip] ON 

INSERT [dbo].[tbl_MakeMyTrip] ([ID], [Item_ID], [Package_ID], [Hotel_ID], [Guide_ID], [To], [From], [Adults], [Child], [Name], [Email], [Phone], [Nic], [Address], [Transport], [Guide], [Others], [test]) VALUES (56, 1, NULL, NULL, NULL, CAST(N'2020-07-02' AS Date), CAST(N'2020-07-02' AS Date), N'2', N'2', N'muree', N'Ali@gmail.com', N'000', N'ssa', N'3ra', N'HIACE', N'No', N'Tent with sleeping bags and matters', NULL)
INSERT [dbo].[tbl_MakeMyTrip] ([ID], [Item_ID], [Package_ID], [Hotel_ID], [Guide_ID], [To], [From], [Adults], [Child], [Name], [Email], [Phone], [Nic], [Address], [Transport], [Guide], [Others], [test]) VALUES (57, 2, 2, 11, 1, CAST(N'2020-10-25' AS Date), CAST(N'2020-10-25' AS Date), N'2', N'2', N'sss', N'ss', N'0', N'11', N'sds', N'sad', N'no', NULL, NULL)
INSERT [dbo].[tbl_MakeMyTrip] ([ID], [Item_ID], [Package_ID], [Hotel_ID], [Guide_ID], [To], [From], [Adults], [Child], [Name], [Email], [Phone], [Nic], [Address], [Transport], [Guide], [Others], [test]) VALUES (58, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'karachi', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_MakeMyTrip] ([ID], [Item_ID], [Package_ID], [Hotel_ID], [Guide_ID], [To], [From], [Adults], [Child], [Name], [Email], [Phone], [Nic], [Address], [Transport], [Guide], [Others], [test]) VALUES (59, 2, 1, 7, 3, CAST(N'2020-01-10' AS Date), CAST(N'2020-01-10' AS Date), N'1', N'1', N'karachi', N'ali@gmail.com', N'0331112211', N'11111111111111', N'karachi', N'HIACE', N'No', N'Tent with sleeping bags and matters', NULL)
INSERT [dbo].[tbl_MakeMyTrip] ([ID], [Item_ID], [Package_ID], [Hotel_ID], [Guide_ID], [To], [From], [Adults], [Child], [Name], [Email], [Phone], [Nic], [Address], [Transport], [Guide], [Others], [test]) VALUES (60, 3, 4, NULL, 4, CAST(N'2020-10-10' AS Date), CAST(N'2020-10-01' AS Date), N'11', N'11', N'karachi', N'ali@gmail.com', N'0331112211', N'11111111111111', N'karachi', N'HIACE', N'No', N'Tent with sleeping bags and matters', NULL)
INSERT [dbo].[tbl_MakeMyTrip] ([ID], [Item_ID], [Package_ID], [Hotel_ID], [Guide_ID], [To], [From], [Adults], [Child], [Name], [Email], [Phone], [Nic], [Address], [Transport], [Guide], [Others], [test]) VALUES (61, 3, 4, NULL, 4, CAST(N'2020-10-10' AS Date), CAST(N'2020-10-01' AS Date), N'11', N'11', N'karachi', N'ali@gmail.com', N'0331112211', N'11111111111111', N'karachi', N'HIACE', N'No', N'Tent with sleeping bags and matters', NULL)
INSERT [dbo].[tbl_MakeMyTrip] ([ID], [Item_ID], [Package_ID], [Hotel_ID], [Guide_ID], [To], [From], [Adults], [Child], [Name], [Email], [Phone], [Nic], [Address], [Transport], [Guide], [Others], [test]) VALUES (62, NULL, NULL, NULL, NULL, CAST(N'2020-10-29' AS Date), CAST(N'2020-10-01' AS Date), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_MakeMyTrip] ([ID], [Item_ID], [Package_ID], [Hotel_ID], [Guide_ID], [To], [From], [Adults], [Child], [Name], [Email], [Phone], [Nic], [Address], [Transport], [Guide], [Others], [test]) VALUES (63, 5, 7, 3, 5, CAST(N'2020-10-31' AS Date), CAST(N'2020-10-01' AS Date), NULL, NULL, N'karachi', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_MakeMyTrip] ([ID], [Item_ID], [Package_ID], [Hotel_ID], [Guide_ID], [To], [From], [Adults], [Child], [Name], [Email], [Phone], [Nic], [Address], [Transport], [Guide], [Others], [test]) VALUES (64, NULL, 24, 1012, 10, CAST(N'2020-10-31' AS Date), CAST(N'2020-10-01' AS Date), N'11', N'11', N'karachi', N'ali@gmail.com', N'0331112211', N'1111111111111', N'karachi', N'HIACE', NULL, N'Tent with sleeping bags and matters', NULL)
SET IDENTITY_INSERT [dbo].[tbl_MakeMyTrip] OFF
SET IDENTITY_INSERT [dbo].[tbl_MemberShip] ON 

INSERT [dbo].[tbl_MemberShip] ([ID], [Title], [Price], [Monthly_Cost], [Monthly_Souvenirs], [Trekking_Equipment], [Extra_Field1], [Extra_Field2]) VALUES (3, N'Gold', N'The customer will purchase a PLATINUM  card for RS.500.', N'The customer will pay Rs.200-300 monthly to the company.', N'The member will get  monthly souvenirs e.g. (shirt, pen, mug, key chain)', N'Trekking equipment  all also be available but after the first four souvenirs are attained by the member ', N'Member after reaching the required bonus points will get an exclusive  free trip from the company', N'The bonus points will be award as per company rules/regulations')
INSERT [dbo].[tbl_MemberShip] ([ID], [Title], [Price], [Monthly_Cost], [Monthly_Souvenirs], [Trekking_Equipment], [Extra_Field1], [Extra_Field2]) VALUES (11, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_MemberShip] ([ID], [Title], [Price], [Monthly_Cost], [Monthly_Souvenirs], [Trekking_Equipment], [Extra_Field1], [Extra_Field2]) VALUES (13, N'2', N'3', N'3', N'3', N'3', N's', N's')
SET IDENTITY_INSERT [dbo].[tbl_MemberShip] OFF
SET IDENTITY_INSERT [dbo].[tbl_Packages] ON 

INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (1, N'karachi occian', N'hi this will be very amazing tourhi this will be very amazing tourhi this will be very amazing tourhi this will be very amazing tourhi this will be very amazing tour', 17, N'Januaryttttttttttttttt', 2, N'kaliftan', N'4', N'not showing', N'03319186108', N'/images/user-medium20425705.png')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (2, N'karachi occian2', N'hi this will be very amazing tourhi this will be very amazing tourhi this will be very amazing tourhi this will be very amazing tourhi this will be very amazing hi this will be very amazing tourhi this will be very amazing tourhi this will be very amazing tourhi this will be very amazing tourhi this will be very amazing tour tour', 17, N'January', 222, N'kaliftan2', N'4', N'not showing222', NULL, N'/images/team-320182858.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (3, N'dadas', N'asdadsad', 17, N'January', 2, N'asdasda', N'aa', N'asdas', N'sd', N'/images/team-420011759.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (4, N'muree', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.', 12, N'september', 4, N'hillss', N'4', N'not showing', N'03319186108', N'/images/960x020320074.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (6, N'rome', N'Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry''s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.v', 12, N'september', 6, N'Italy ', N'4', N'not showing', N'03319186108', N'/images/No_Image_Available.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (20, N'romeaa', N'adsads', 11, N'asda', 222, N'asdasd', N'2', N'sasad', N'222', N'/images/p120411810.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (24, N'asd', N'asdada', 12, N'11', 11, N'as', N'sa', N'11sa', N'asdas', N'/images/No_Image_Available.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (25, N'romeaa', N'cvcvc', 12, N'Januaryyyyyyyyyyyyy', 6, N'aaa', N'4', N'not showing', N'03319186108', N'/images/hunzadrone-scaled20242072.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (26, N'rome', N'vv', 12, N'september', 6, N'Italy ', N'4', N'not showing', N'03319186108', N'/images/No_Image_Available.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (27, N'rome', N'/''''/''//', 12, N'september', 6, N'Italy ', N'4', N'not showing', N'03319186108', N'/images/leaves-68-scaled20514998.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (28, N'rome', N'waww', 12, N'september', 4, N'Italy ', N'4', N'not showing', N'03319186108', N'/images/No_Image_Available.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (29, N'rome', N'a', 12, N'1', 6, N'Italy ', N'4', N'not showing', N'03319186108', N'/images/japan20095333.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (30, N'rome', N'asa', 12, N'september', 6, N'Italy ', N'4', N'not showing', N'222', N'/images/No_Image_Available.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (31, N'rome', N';p;pp;', 12, N'september', 6, N'a', N'1', N'not showing', N'03319186108', N'/images/No_Image_Available.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (32, N'rome', N'lll', 12, N'september', 6, N'Italy ', N'4', N'not showing', N'03319186108', N'/images/hunzadrone-scaled20304367.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (1001, N'kkkk', N'ss', 11, N'11', 1, N'xx', N'2', N'yes', N's', N'/images/No_Image_Available.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (1002, N'kkkk', N'dsd', 11, N'11', 1, N'xx', N'2', N'yes', N's', N'/images/No_Image_Available.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (1003, N'kkkk', N'asa', 11, N'11', 1, N'xx', N'2', N'yes', N's', N'/images/No_Image_Available.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (1004, N'kkkk', N'kkk', 11, N'11', 1, N'xx', N'2', N'yes', N's', N'/images/No_Image_Available.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (1005, N'kkkk', N'kjkk', 11, N'11', 1, N'xx', N'2', N'yes', N's', N'/images/No_Image_Available.jpg')
INSERT [dbo].[tbl_Packages] ([ID], [PackageName], [PackageDescription], [Date], [Month], [NoOfDays], [Location], [Standard], [SpotSiteSeeing], [Contact], [ImagePath]) VALUES (1006, N'kkkk', N'xz', 11, N'11', 1, N'xx', N'2', N'yes', N's', N'/images/No_Image_Available.jpg')
SET IDENTITY_INSERT [dbo].[tbl_Packages] OFF
SET IDENTITY_INSERT [dbo].[tbl_user] ON 

INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (1, N'Ali Haider', N'ali@gmail.com', N'cr7', N'Male', 1, 1, 1, NULL, NULL, NULL, N'Admin')
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (2, N'ali abbas', N'alibhai@gmail.com', N'aliii', N'female', 1, 1, 1, NULL, NULL, NULL, N'User')
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (3, N'haider', N'ali@gmail.com', N'cr7', N'male', NULL, NULL, NULL, NULL, NULL, NULL, N'User')
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (1002, N'koko', N'ali@gmail.com', N'cr7', N'Male', NULL, NULL, NULL, NULL, NULL, NULL, N'User')
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (1003, N'hello', N'hi', N'helohi@gmail.comk', N'Female', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (1006, N'adil', N'adil@gmail.com', N'jookok', N'Male', 1, 1, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (1007, N'koko', N'jojo@gmail.com', N'bb', N'Female', 1, 1, 1, 4, NULL, NULL, NULL)
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (1008, N'man', N'man@gmail.com', N'kakaka', N'Male', 1, 0, 0, 1, NULL, NULL, NULL)
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (1009, N'koko', N'man@gmail.com', N'bb', N'Female', 1, 1, 1, 2, CAST(N'2020-05-05' AS Date), NULL, NULL)
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (1010, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (1011, N'ali', N'adsa@gmail.com', N'adsaad', N'Male', 1, 0, 0, 4, CAST(N'2020-08-04' AS Date), NULL, NULL)
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (1012, N'jj', N'a@gmail.com', NULL, NULL, 0, 0, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (1013, N'kk', NULL, NULL, NULL, 0, 0, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (1014, NULL, NULL, NULL, NULL, 1, 1, 1, NULL, NULL, N'/images/DNRI191520165948.jpg', NULL)
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (1015, N'abba', N'abba@gmail.com', N'bbb', N'Male', 1, 1, 1, 2, CAST(N'2020-07-04' AS Date), N'/images/DNRI191520295585.jpg', NULL)
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (1016, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (1017, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (1018, N'sa', N';', N'sad', N'Female', 0, 1, 0, 1, CAST(N'2020-06-06' AS Date), N'/images/20595554Cat0320471574.jpg', NULL)
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (1019, N'sa', N';', N'sad', N'Female', 0, 1, 0, 1, CAST(N'2020-01-06' AS Date), N'/images/20580866Cat0320492768.jpg', NULL)
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (2019, N'n', N'n', N'n', N'Male', 1, 0, 0, 1, CAST(N'2020-10-06' AS Date), N'/images/20595554Cat0320280598.jpg', NULL)
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (2020, N'n', N's', N'n', N'Male', 1, 0, 0, 1, CAST(N'2020-06-06' AS Date), N'/images/20580866Cat0320352451.jpg', NULL)
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (2021, N's', N'ss', N'ss', N'Female', 1, 0, 0, 1, CAST(N'2020-06-07' AS Date), N'/images/20423711Cat0320362250.jpg', NULL)
INSERT [dbo].[tbl_user] ([User_id], [Name], [Email], [Password], [Gender], [Csharp], [Java], [Python], [CityId], [DBO], [ImagePath], [Role]) VALUES (2022, N'n', N'n', N'n', N'Male', 1, 0, 0, 1, CAST(N'2020-06-06' AS Date), N'/images/20580866Cat0320371979.jpg', NULL)
SET IDENTITY_INSERT [dbo].[tbl_user] OFF
ALTER TABLE [dbo].[tbl_user]  WITH CHECK ADD  CONSTRAINT [FK_tbl_user_tbl_city] FOREIGN KEY([CityId])
REFERENCES [dbo].[tbl_city] ([CityId])
GO
ALTER TABLE [dbo].[tbl_user] CHECK CONSTRAINT [FK_tbl_user_tbl_city]
GO
/****** Object:  StoredProcedure [dbo].[Package_Confirmation_Email]    Script Date: 10/26/2020 6:18:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Package_Confirmation_Email]
( 
	@ID INT
)
AS
BEGIN 
 	
BEGIN TRY 

	SELECT tbl_Packages.PackageName , tbl_Guide.name ,tbl_Hotels.Name  FROM tbl_MakeMyTrip 
	INNER JOIN tbl_Packages ON tbl_Packages.ID = tbl_MakeMyTrip.Package_ID 
	INNER JOIN tbl_Guide ON tbl_Guide.ID = tbl_MakeMyTrip.Guide_ID
	INNER JOIN tbl_Hotels ON tbl_Hotels.ID = tbl_MakeMyTrip.Hotel_ID WHERE tbl_MakeMyTrip.ID=@ID


	
END TRY

BEGIN CATCH 
END CATCH

END
-----------------------------------
GO
/****** Object:  StoredProcedure [dbo].[Package_Confirmation_Email2]    Script Date: 10/26/2020 6:18:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[Package_Confirmation_Email2]
( 
	@ID INT
)
AS
BEGIN 
 	
BEGIN TRY 

	SELECT tbl_Packages.PackageName , tbl_Guide.name ,tbl_Hotels.Name  FROM tbl_MakeMyTrip 
	INNER JOIN tbl_Packages ON tbl_Packages.ID = tbl_MakeMyTrip.Package_ID 
	INNER JOIN tbl_Guide ON tbl_Guide.ID = tbl_MakeMyTrip.Guide_ID
	INNER JOIN tbl_Hotels ON tbl_Hotels.ID = tbl_MakeMyTrip.Hotel_ID WHERE tbl_MakeMyTrip.ID=@ID


	
END TRY

BEGIN CATCH 
END CATCH

END
-----------------------------------
GO
/****** Object:  StoredProcedure [dbo].[Select_All_Hotels_with_images]    Script Date: 10/26/2020 6:18:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Select_All_Hotels_with_images]

AS
BEGIN 
 	
BEGIN TRY 

	SELECT  H.ID , H.Name  ,H.Location  ,H.Gov_License,  H.Standard,  H.Charges, 
	        h.Location,  HM.ID,HM.ImagePath   FROM tbl_Hotels as H 
	        INNER JOIN tbl_Hotel_images as HM ON H.ID = HM.Hotel_ID 


	
END TRY

BEGIN CATCH 
END CATCH

END
-----------------------------------
GO
/****** Object:  StoredProcedure [dbo].[Select_Data_With_First_image]    Script Date: 10/26/2020 6:18:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Select_Data_With_First_image]
( 
	@ID INT
)
AS
BEGIN 
 	
BEGIN TRY

  select * from tbl_Hotels as AD INNER JOIN tbl_Hotel_images as Img on AD.ID=Img.Hotel_ID 
  WHERE Img.ID = (select top 1  M.id from tbl_Hotel_images as M where M.Hotel_ID=Img.Hotel_ID order by M.ID asc  ) 
    select * from tbl_Hotels
	  select * from tbl_Hotel_images


  END TRY

BEGIN CATCH 
END CATCH

END
GO
USE [master]
GO
ALTER DATABASE [Sarhad] SET  READ_WRITE 
GO
