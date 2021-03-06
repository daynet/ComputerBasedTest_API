USE [master]
GO
/****** Object:  Database [ComputerBasedTest]    Script Date: 9/12/2019 2:59:04 PM ******/
CREATE DATABASE [ComputerBasedTest]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ComputerBasedTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ComputerBasedTest.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ComputerBasedTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ComputerBasedTest_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ComputerBasedTest] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ComputerBasedTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ComputerBasedTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ComputerBasedTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ComputerBasedTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ComputerBasedTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ComputerBasedTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET RECOVERY FULL 
GO
ALTER DATABASE [ComputerBasedTest] SET  MULTI_USER 
GO
ALTER DATABASE [ComputerBasedTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ComputerBasedTest] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ComputerBasedTest] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ComputerBasedTest] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ComputerBasedTest] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ComputerBasedTest', N'ON'
GO
USE [ComputerBasedTest]
GO
/****** Object:  Table [dbo].[CorrectAnswer]    Script Date: 9/12/2019 2:59:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CorrectAnswer](
	[CorrectAnswerId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionBankId] [int] NOT NULL,
	[QuestionOptionId] [int] NOT NULL,
	[QuestionOptionTypeId] [int] NOT NULL,
 CONSTRAINT [PK_CurrectAnswer] PRIMARY KEY CLUSTERED 
(
	[CorrectAnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoginActivity]    Script Date: 9/12/2019 2:59:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoginActivity](
	[LoginActivityId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Username] [varchar](100) NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[Gender] [nvarchar](100) NULL,
	[Email] [nvarchar](50) NULL,
	[IsEmailConfirmed] [bit] NULL,
	[emailConfirmationCode] [nvarchar](50) NULL,
	[PasswordHash] [varbinary](max) NULL,
	[PasswordSalt] [varbinary](max) NULL,
	[IsFirstLoginAttempt] [bit] NULL,
	[IsLockoutEnabled] [bit] NULL,
	[IsLocked] [bit] NULL,
	[FailedLoginAttempt] [int] NULL,
	[IsActive] [bit] NULL,
	[DeactivationDate] [datetime] NULL,
	[LastLoginDate] [datetime] NULL,
	[IsLogout] [bit] NULL,
	[CreationDate] [datetime] NULL,
 CONSTRAINT [PK_LoginActivity] PRIMARY KEY CLUSTERED 
(
	[LoginActivityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OptionType]    Script Date: 9/12/2019 2:59:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OptionType](
	[OptionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[OptionTypeName] [nvarchar](50) NULL,
 CONSTRAINT [PK__OptionTy__96A2FCCE429A1382] PRIMARY KEY CLUSTERED 
(
	[OptionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PublishedQuestion]    Script Date: 9/12/2019 2:59:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PublishedQuestion](
	[PublishedQuestionId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionBankId] [int] NULL,
	[TestSetupId] [int] NOT NULL,
 CONSTRAINT [PK_PublishedQuestions] PRIMARY KEY CLUSTERED 
(
	[PublishedQuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuestionBank]    Script Date: 9/12/2019 2:59:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QuestionBank](
	[QuestionBankId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionTypeId] [int] NOT NULL,
	[Question] [varchar](max) NOT NULL,
	[TestCategoryId] [int] NOT NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[DateOfCreation] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DateOfDeletion] [datetime] NULL,
	[DeletedBy] [nvarchar](50) NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[QuestionBankId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QuestionOption]    Script Date: 9/12/2019 2:59:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionOption](
	[QuetionOptionId] [int] IDENTITY(1,1) NOT NULL,
	[OptionTypeId] [int] NULL,
	[QuestionBankId] [int] NULL,
	[QuetionOptionName] [nvarchar](max) NULL,
 CONSTRAINT [PK_QuestionOptions] PRIMARY KEY CLUSTERED 
(
	[QuetionOptionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QuestionType]    Script Date: 9/12/2019 2:59:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionType](
	[QuestionTypeId] [int] IDENTITY(1,1) NOT NULL,
	[QuestionTypeName] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestCategory]    Script Date: 9/12/2019 2:59:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestCategory](
	[TestCategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](200) NULL,
	[DateCreated] [datetime] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[IsDelete] [bit] NULL,
	[DateOfDeletion] [datetime] NULL,
	[DeletedBy] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TestSetup]    Script Date: 9/12/2019 2:59:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestSetup](
	[TestSetupId] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[StartTime] [time](7) NULL,
	[StopTime] [time](7) NULL,
	[DisplayResult] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[TestSetupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserClaim]    Script Date: 9/12/2019 2:59:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaim](
	[UserClaimsId] [int] IDENTITY(1,1) NOT NULL,
	[ClaimType] [nvarchar](50) NULL,
	[ClaimValue] [nvarchar](100) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_UserClaim] PRIMARY KEY CLUSTERED 
(
	[UserClaimsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [ComputerBasedTest] SET  READ_WRITE 
GO
