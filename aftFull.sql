USE [master]
GO
/****** Object:  Database [afthotel]    Script Date: 28/12/2021 17:38:14 ******/
CREATE DATABASE [afthotel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'afthotel', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\afthotel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'afthotel_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\afthotel_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [afthotel] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [afthotel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [afthotel] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [afthotel] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [afthotel] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [afthotel] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [afthotel] SET ARITHABORT OFF 
GO
ALTER DATABASE [afthotel] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [afthotel] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [afthotel] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [afthotel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [afthotel] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [afthotel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [afthotel] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [afthotel] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [afthotel] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [afthotel] SET  DISABLE_BROKER 
GO
ALTER DATABASE [afthotel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [afthotel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [afthotel] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [afthotel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [afthotel] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [afthotel] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [afthotel] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [afthotel] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [afthotel] SET  MULTI_USER 
GO
ALTER DATABASE [afthotel] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [afthotel] SET DB_CHAINING OFF 
GO
ALTER DATABASE [afthotel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [afthotel] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [afthotel] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [afthotel] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [afthotel] SET QUERY_STORE = OFF
GO
USE [afthotel]
GO
/****** Object:  Table [dbo].[aft_booking]    Script Date: 28/12/2021 17:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aft_booking](
	[bid] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[customername] [nvarchar](100) NOT NULL,
	[customeremail] [nvarchar](100) NOT NULL,
	[customerphone] [nvarchar](50) NOT NULL,
	[croomtype] [nvarchar](50) NOT NULL,
	[croomnumber] [nvarchar](50) NOT NULL,
	[cdate] [datetime] NOT NULL,
	[ctotalprice] [int] NOT NULL,
 CONSTRAINT [PK_aft_booking] PRIMARY KEY CLUSTERED 
(
	[bid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aft_customer]    Script Date: 28/12/2021 17:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aft_customer](
	[cid] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[cname] [nvarchar](100) NOT NULL,
	[cemail] [nvarchar](100) NOT NULL,
	[cphone] [nvarchar](20) NOT NULL,
	[caddress] [nvarchar](500) NOT NULL,
	[ccreateat] [datetime] NOT NULL,
 CONSTRAINT [PK_aft_customer] PRIMARY KEY CLUSTERED 
(
	[cid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aft_room]    Script Date: 28/12/2021 17:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aft_room](
	[roomtype] [nvarchar](50) NOT NULL,
	[roomprice] [int] NOT NULL,
	[rid] [int] IDENTITY(1,1) NOT NULL,
	[roomnumber] [int] NULL,
	[roomsize] [int] NULL,
 CONSTRAINT [PK_aft_room] PRIMARY KEY CLUSTERED 
(
	[rid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[aft_users]    Script Date: 28/12/2021 17:38:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[aft_users](
	[userid] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[createat] [datetime] NULL,
	[fullname] [nvarchar](50) NULL,
 CONSTRAINT [PK_aft_users] PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[aft_booking] ON 

INSERT [dbo].[aft_booking] ([bid], [customername], [customeremail], [customerphone], [croomtype], [croomnumber], [cdate], [ctotalprice]) VALUES (CAST(2 AS Decimal(18, 0)), N'Atiq', N'atiq@gmail.com', N'1231223', N'Family', N'160', CAST(N'2021-12-31T00:00:00.000' AS DateTime), 180)
INSERT [dbo].[aft_booking] ([bid], [customername], [customeremail], [customerphone], [croomtype], [croomnumber], [cdate], [ctotalprice]) VALUES (CAST(3 AS Decimal(18, 0)), N'Atiq', N'atiq@gmail.com', N'1231223', N'Family', N'160', CAST(N'2021-12-31T00:00:00.000' AS DateTime), 180)
INSERT [dbo].[aft_booking] ([bid], [customername], [customeremail], [customerphone], [croomtype], [croomnumber], [cdate], [ctotalprice]) VALUES (CAST(4 AS Decimal(18, 0)), N'Atiq', N'atiq@gmail.com', N'1231223', N'Deluxe', N'650', CAST(N'2022-01-08T00:00:00.000' AS DateTime), 6050)
INSERT [dbo].[aft_booking] ([bid], [customername], [customeremail], [customerphone], [croomtype], [croomnumber], [cdate], [ctotalprice]) VALUES (CAST(5 AS Decimal(18, 0)), N'Atiq', N'atiq@gmail.com', N'1231223', N'Family', N'160', CAST(N'2021-12-30T00:00:00.000' AS DateTime), 120)
INSERT [dbo].[aft_booking] ([bid], [customername], [customeremail], [customerphone], [croomtype], [croomnumber], [cdate], [ctotalprice]) VALUES (CAST(6 AS Decimal(18, 0)), N'Atiq', N'atiq@gmail.com', N'1231223', N'Family', N'160', CAST(N'2021-12-31T00:00:00.000' AS DateTime), 180)
INSERT [dbo].[aft_booking] ([bid], [customername], [customeremail], [customerphone], [croomtype], [croomnumber], [cdate], [ctotalprice]) VALUES (CAST(7 AS Decimal(18, 0)), N'Test Name', N'test@gmail.com', N'789789', N'Family', N'160', CAST(N'2021-12-28T00:00:00.000' AS DateTime), 60)
INSERT [dbo].[aft_booking] ([bid], [customername], [customeremail], [customerphone], [croomtype], [croomnumber], [cdate], [ctotalprice]) VALUES (CAST(8 AS Decimal(18, 0)), N'Test Name', N'test@gmail.com', N'789789', N'Standard', N'440', CAST(N'2021-12-28T00:00:00.000' AS DateTime), 250)
INSERT [dbo].[aft_booking] ([bid], [customername], [customeremail], [customerphone], [croomtype], [croomnumber], [cdate], [ctotalprice]) VALUES (CAST(9 AS Decimal(18, 0)), N'Test Name', N'test@gmail.com', N'789789', N'Family', N'160', CAST(N'2021-12-28T00:00:00.000' AS DateTime), 60)
INSERT [dbo].[aft_booking] ([bid], [customername], [customeremail], [customerphone], [croomtype], [croomnumber], [cdate], [ctotalprice]) VALUES (CAST(10 AS Decimal(18, 0)), N'Test Name', N'test@gmail.com', N'789789', N'Deluxe', N'650', CAST(N'2021-12-31T00:00:00.000' AS DateTime), 1650)
SET IDENTITY_INSERT [dbo].[aft_booking] OFF
GO
SET IDENTITY_INSERT [dbo].[aft_customer] ON 

INSERT [dbo].[aft_customer] ([cid], [cname], [cemail], [cphone], [caddress], [ccreateat]) VALUES (CAST(2 AS Decimal(18, 0)), N'Atiq', N'atiq@gmail.com', N'1231223', N'Dhaka, Bangladesh.', CAST(N'2021-12-27T17:07:27.357' AS DateTime))
INSERT [dbo].[aft_customer] ([cid], [cname], [cemail], [cphone], [caddress], [ccreateat]) VALUES (CAST(5 AS Decimal(18, 0)), N'Test Name', N'test@gmail.com', N'789789', N'City, Country', CAST(N'2021-12-27T23:06:40.443' AS DateTime))
INSERT [dbo].[aft_customer] ([cid], [cname], [cemail], [cphone], [caddress], [ccreateat]) VALUES (CAST(6 AS Decimal(18, 0)), N'New User', N'new@gmail.com', N'123456789', N'New City, USA', CAST(N'2021-12-28T17:27:23.117' AS DateTime))
SET IDENTITY_INSERT [dbo].[aft_customer] OFF
GO
SET IDENTITY_INSERT [dbo].[aft_room] ON 

INSERT [dbo].[aft_room] ([roomtype], [roomprice], [rid], [roomnumber], [roomsize]) VALUES (N'Standard', 300, 3, 435, 4)
INSERT [dbo].[aft_room] ([roomtype], [roomprice], [rid], [roomnumber], [roomsize]) VALUES (N'Family', 50, 4, 135, 2)
INSERT [dbo].[aft_room] ([roomtype], [roomprice], [rid], [roomnumber], [roomsize]) VALUES (N'Family', 60, 5, 160, 4)
INSERT [dbo].[aft_room] ([roomtype], [roomprice], [rid], [roomnumber], [roomsize]) VALUES (N'Deluxe', 550, 6, 650, 2)
INSERT [dbo].[aft_room] ([roomtype], [roomprice], [rid], [roomnumber], [roomsize]) VALUES (N'Standard', 250, 7, 440, 4)
INSERT [dbo].[aft_room] ([roomtype], [roomprice], [rid], [roomnumber], [roomsize]) VALUES (N'Standard', 100, 8, 210, 2)
SET IDENTITY_INSERT [dbo].[aft_room] OFF
GO
SET IDENTITY_INSERT [dbo].[aft_users] ON 

INSERT [dbo].[aft_users] ([userid], [username], [password], [createat], [fullname]) VALUES (CAST(2 AS Decimal(18, 0)), N'test', N'test', CAST(N'2021-12-27T00:40:28.307' AS DateTime), N'Test User')
SET IDENTITY_INSERT [dbo].[aft_users] OFF
GO
USE [master]
GO
ALTER DATABASE [afthotel] SET  READ_WRITE 
GO
