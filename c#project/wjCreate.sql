USE [master]
GO
/****** Object:  Database [wujing]    Script Date: 2016/8/10 15:08:16 ******/
CREATE DATABASE [wujing]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'wujing', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\wujing.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'wujing_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\wujing_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [wujing] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [wujing].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [wujing] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [wujing] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [wujing] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [wujing] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [wujing] SET ARITHABORT OFF 
GO
ALTER DATABASE [wujing] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [wujing] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [wujing] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [wujing] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [wujing] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [wujing] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [wujing] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [wujing] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [wujing] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [wujing] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [wujing] SET  DISABLE_BROKER 
GO
ALTER DATABASE [wujing] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [wujing] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [wujing] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [wujing] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [wujing] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [wujing] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [wujing] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [wujing] SET RECOVERY FULL 
GO
ALTER DATABASE [wujing] SET  MULTI_USER 
GO
ALTER DATABASE [wujing] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [wujing] SET DB_CHAINING OFF 
GO
ALTER DATABASE [wujing] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [wujing] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'wujing', N'ON'
GO
USE [wujing]
GO
/****** Object:  Table [dbo].[company]    Script Date: 2016/8/10 15:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[company](
	[companyName] [varchar](50) NOT NULL,
	[companyNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_company] PRIMARY KEY CLUSTERED 
(
	[companyNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[connect1]    Script Date: 2016/8/10 15:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[connect1](
	[imageNumber] [nvarchar](50) NOT NULL,
	[productType] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[connect2]    Script Date: 2016/8/10 15:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[connect2](
	[imageNumber] [nvarchar](50) NOT NULL,
	[companyNumber] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[connect3]    Script Date: 2016/8/10 15:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[connect3](
	[imageNumber] [nvarchar](50) NOT NULL,
	[departmentNumber] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[department]    Script Date: 2016/8/10 15:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[department](
	[departmentNumber] [nvarchar](50) NOT NULL,
	[departmentName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_department] PRIMARY KEY CLUSTERED 
(
	[departmentNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[image]    Script Date: 2016/8/10 15:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[image](
	[imageNumber] [nvarchar](50) NOT NULL,
	[partsName] [varchar](50) NOT NULL,
	[path] [varchar](50) NOT NULL,
	[updateTime] [datetime] NOT NULL,
	[image] [image] NULL,
 CONSTRAINT [PK_image] PRIMARY KEY CLUSTERED 
(
	[imageNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[notices]    Script Date: 2016/8/10 15:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[notices](
	[noticeId] [int] IDENTITY(1,1) NOT NULL,
	[noticeType] [nvarchar](50) NOT NULL,
	[noticeDepartment] [nvarchar](50) NOT NULL,
	[noticeContent] [varchar](max) NOT NULL,
	[noticeTime] [datetime] NOT NULL,
	[noticeFlag] [bit] NOT NULL,
 CONSTRAINT [PK_notices] PRIMARY KEY CLUSTERED 
(
	[noticeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[product]    Script Date: 2016/8/10 15:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[product](
	[productType] [nvarchar](50) NOT NULL,
	[productName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[productType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[users]    Script Date: 2016/8/10 15:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[users](
	[account] [nvarchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[permission] [nvarchar](50) NULL,
	[departmentNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[visitLog]    Script Date: 2016/8/10 15:08:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[visitLog](
	[account] [nvarchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[time] [nvarchar](50) NOT NULL,
	[imageNumber] [nvarchar](50) NULL,
	[productType] [nvarchar](50) NULL,
 CONSTRAINT [PK_visitLog] PRIMARY KEY CLUSTERED 
(
	[account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [wujing] SET  READ_WRITE 
GO
