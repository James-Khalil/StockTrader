USE [master]
GO
/****** Object:  Database [BotTrader]    Script Date: 2023-09-02 2:25:41 PM ******/
CREATE DATABASE [BotTrader]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BotTrader', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BotTrader.mdf' , SIZE = 532480KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BotTrader_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BotTrader_log.ldf' , SIZE = 268160KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BotTrader] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BotTrader].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BotTrader] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BotTrader] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BotTrader] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BotTrader] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BotTrader] SET ARITHABORT OFF 
GO
ALTER DATABASE [BotTrader] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BotTrader] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BotTrader] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BotTrader] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BotTrader] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BotTrader] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BotTrader] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BotTrader] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BotTrader] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BotTrader] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BotTrader] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BotTrader] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BotTrader] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BotTrader] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BotTrader] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BotTrader] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BotTrader] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BotTrader] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BotTrader] SET  MULTI_USER 
GO
ALTER DATABASE [BotTrader] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BotTrader] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BotTrader] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BotTrader] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BotTrader] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BotTrader] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BotTrader', N'ON'
GO
ALTER DATABASE [BotTrader] SET QUERY_STORE = ON
GO
ALTER DATABASE [BotTrader] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BotTrader]
GO
/****** Object:  UserDefinedFunction [dbo].[fn_GetPower]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_GetPower] (@Num1 int, @Num2 int)
RETURNS float AS  
BEGIN 
	Declare @Result float = @Num1
	Declare @Loop int = 0

	While @Loop < @Num2 -1
	Begin
		Set @Result = @Result * @Num1
		Set @Loop = @Loop + 1
	End

	Return(@Result)
END

GO
/****** Object:  UserDefinedFunction [dbo].[fn_Split]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[fn_Split] (@string VARCHAR(4000),@separator CHAR(1))
RETURNS @tbl_Value TABLE (row varchar(256) Primary Key, value varchar(256))
AS 
BEGIN
   DECLARE @Position int
   DECLARE @row int
   DECLARE @value varchar(256)

   SET @Position = 1
   SET @row = 0
   SET @string = @string + @separator
   WHILE charindex(@separator,@string,@Position) <> 0
      BEGIN
		 Set @value = LTrim(RTrim(substring(@string, @position, charindex(@separator,@string,@Position) - @Position)))
         SET @row = @row + 1

         INSERT into @tbl_Value
         Values (@row, @value)

         SET @position = charindex(@separator,@string,@Position) + 1
      END
     RETURN
END

GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[SecurityID] [int] NOT NULL,
	[ActiveFlag] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Security]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Security](
	[SecurityID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_Security] PRIMARY KEY CLUSTERED 
(
	[SecurityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_User]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_User]
AS

Select U.*, S.Description as SecurityDesc 
From tbl_User U
Inner Join tbl_Security S on U.SecurityID = S.SecurityID

GO
/****** Object:  Table [dbo].[tbl_Job]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Job](
	[JobID] [int] IDENTITY(1,1) NOT NULL,
	[JobTypeID] [int] NOT NULL,
	[JobStatusID] [int] NOT NULL,
	[Description] [varchar](200) NOT NULL,
	[CreateUser] [varchar](25) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[StartTime] [datetime] NULL,
	[FinishTime] [datetime] NULL,
 CONSTRAINT [PK_tbl_Job] PRIMARY KEY CLUSTERED 
(
	[JobID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_JobType]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_JobType](
	[JobTypeID] [int] NOT NULL,
	[Description] [varchar](255) NOT NULL,
	[NumThreads] [int] NOT NULL,
	[DaysRetainLog] [int] NOT NULL,
 CONSTRAINT [PK_tbl_JobType] PRIMARY KEY CLUSTERED 
(
	[JobTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_JobStatus]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_JobStatus](
	[JobStatusID] [int] NOT NULL,
	[Description] [varchar](250) NOT NULL,
 CONSTRAINT [PK_tbl_JobStatus] PRIMARY KEY CLUSTERED 
(
	[JobStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[vw_Job]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vw_Job]
AS
SELECT dbo.tbl_JobType.Description as Type, dbo.tbl_Job.JobID, dbo.tbl_Job.Description, dbo.tbl_Job.CreateUser, dbo.tbl_Job.CreateTime, dbo.tbl_Job.StartTime, dbo.tbl_Job.FinishTime, dbo.tbl_JobStatus.Description AS Status
FROM     dbo.tbl_Job INNER JOIN
                  dbo.tbl_JobStatus ON dbo.tbl_Job.JobStatusID = dbo.tbl_JobStatus.JobStatusID INNER JOIN
                  dbo.tbl_JobType ON dbo.tbl_Job.JobTypeID = dbo.tbl_JobType.JobTypeID
GO
/****** Object:  Table [dbo].[tbl_AppConst]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_AppConst](
	[AppConstID] [int] NOT NULL,
	[CurrencyCode] [varchar](3) NOT NULL,
	[Ind100EMA] [float] NOT NULL,
	[Ind100EMAFlag] [bit] NOT NULL,
	[Ind200EMA] [float] NOT NULL,
	[Ind200EMAFlag] [bit] NOT NULL,
	[Ind100vs200EMA] [float] NOT NULL,
	[Ind100vs200EMAFlag] [bit] NOT NULL,
	[IndMACDvs200EMA] [float] NOT NULL,
	[IndMACDvs200EMAFlag] [bit] NOT NULL,
	[Ind50vs200SMA] [float] NOT NULL,
	[Ind50vs200SMAFlag] [bit] NOT NULL,
	[IndRSI30] [float] NOT NULL,
	[IndRSI30Flag] [bit] NOT NULL,
	[IndSplit] [float] NOT NULL,
	[IndSplitTHold] [date] NOT NULL,
	[IndSplitFlag] [bit] NOT NULL,
	[IndDividend] [float] NOT NULL,
	[IndDividendTHold] [date] NOT NULL,
	[IndDividendFlag] [bit] NOT NULL,
	[IndPositiveNews] [float] NOT NULL,
	[IndPositiveNewsFlag] [bit] NOT NULL,
	[IndFGIndex] [float] NOT NULL,
	[IndFGIndexTHold] [float] NOT NULL,
	[IndFGIndexFlag] [bit] NOT NULL,
	[IndListedYear] [float] NOT NULL,
	[IndListedYearTHold] [date] NOT NULL,
	[IndListedYearFlag] [bit] NOT NULL,
	[IndEmployees] [float] NOT NULL,
	[IndEmployeesTHold] [int] NOT NULL,
	[IndEmployeesFlag] [bit] NOT NULL,
	[IndMarketCap] [float] NOT NULL,
	[IndMarketCapTHold] [float] NOT NULL,
	[IndMarketCapFlag] [bit] NOT NULL,
	[IndTechSic] [float] NOT NULL,
	[IndTechSicTHold] [int] NOT NULL,
	[IndTechSicFlag] [bit] NOT NULL,
	[BuyScore] [float] NOT NULL,
	[SellScore] [float] NOT NULL,
 CONSTRAINT [PK_tbl_AppConst] PRIMARY KEY CLUSTERED 
(
	[AppConstID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Asset]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Asset](
	[Symbol] [varchar](10) NOT NULL,
	[CompanyName] [varchar](100) NOT NULL,
	[CurrencyCode] [varchar](10) NOT NULL,
	[Price] [float] NOT NULL,
	[NumEmployees] [int] NOT NULL,
	[MarketCap] [float] NOT NULL,
	[Revenue] [float] NOT NULL,
	[Equity] [float] NOT NULL,
	[NetIncome] [float] NOT NULL,
	[ProfitMargin] [float] NOT NULL,
	[ROE] [float] NOT NULL,
	[NumShares] [int] NOT NULL,
	[EarnShare] [float] NOT NULL,
	[EarnSharePct] [float] NOT NULL,
	[SICCode] [varchar](10) NOT NULL,
	[SICDesc] [varchar](1000) NOT NULL,
	[Website] [varchar](256) NOT NULL,
	[Locale] [varchar](50) NOT NULL,
	[ListDate] [date] NOT NULL,
	[DelistDate] [date] NOT NULL,
	[TradableFlag] [bit] NOT NULL,
	[FracFlag] [bit] NOT NULL,
	[PolygonFlag] [bit] NOT NULL,
	[StrongScore] [float] NOT NULL,
	[SoftScore] [float] NOT NULL,
	[FinancialScore] [float] NOT NULL,
	[TotalScore] [float] NOT NULL,
 CONSTRAINT [PK_tbl_Asset] PRIMARY KEY CLUSTERED 
(
	[Symbol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Asset_Stage]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Asset_Stage](
	[Symbol] [varchar](10) NOT NULL,
	[CompanyName] [varchar](100) NOT NULL,
	[CurrencyCode] [varchar](10) NOT NULL,
	[NumEmployees] [int] NOT NULL,
	[MarketCap] [float] NOT NULL,
	[SICCode] [varchar](10) NOT NULL,
	[SICDesc] [varchar](1000) NOT NULL,
	[Website] [varchar](256) NOT NULL,
	[Locale] [varchar](50) NOT NULL,
	[ListDate] [datetime] NOT NULL,
	[DelistDate] [datetime] NOT NULL,
	[TradableFlag] [bit] NOT NULL,
	[FracFlag] [bit] NOT NULL,
	[PolygonFlag] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_Asset_Stage] PRIMARY KEY CLUSTERED 
(
	[Symbol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_AssetClass]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_AssetClass](
	[AssetClassID] [int] IDENTITY(0,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_AssetClass] PRIMARY KEY CLUSTERED 
(
	[AssetClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_AssetHistory]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_AssetHistory](
	[Symbol] [varchar](10) NOT NULL,
	[HistDate] [date] NOT NULL,
	[Price] [float] NOT NULL,
	[EMA100] [float] NOT NULL,
	[EMA200] [float] NOT NULL,
	[MACD] [float] NOT NULL,
	[RSI] [float] NOT NULL,
	[SMA50] [float] NOT NULL,
	[SMA200] [float] NOT NULL,
 CONSTRAINT [PK_tbl_AssetHistory] PRIMARY KEY CLUSTERED 
(
	[Symbol] ASC,
	[HistDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Dividend]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Dividend](
	[Symbol] [varchar](10) NOT NULL,
	[DeclarationDate] [date] NOT NULL,
	[CashAmount] [float] NOT NULL,
	[DividendType] [int] NOT NULL,
	[Currency] [varchar](10) NOT NULL,
	[ExDividendDate] [date] NOT NULL,
	[Frequency] [int] NOT NULL,
	[RecordDate] [date] NOT NULL,
	[PayDate] [date] NOT NULL,
 CONSTRAINT [PK_tbl_Dividend] PRIMARY KEY CLUSTERED 
(
	[Symbol] ASC,
	[DeclarationDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_DividendType]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DividendType](
	[DividendType] [int] NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_DividendType] PRIMARY KEY CLUSTERED 
(
	[DividendType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_HoldingsHistory]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_HoldingsHistory](
	[Symbol] [varchar](10) NOT NULL,
	[Shares] [float] NOT NULL,
 CONSTRAINT [PK_tbl_HoldingsHistory] PRIMARY KEY CLUSTERED 
(
	[Symbol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_JobError]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_JobError](
	[JobID] [int] NOT NULL,
	[SequenceID] [int] NOT NULL,
	[ErrorDate] [datetime] NOT NULL,
	[Error] [varchar](250) NOT NULL,
	[Exception] [varchar](max) NOT NULL,
 CONSTRAINT [PK_tbl_JobError_1] PRIMARY KEY CLUSTERED 
(
	[JobID] ASC,
	[SequenceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_JobSchedule]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_JobSchedule](
	[JobScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[JobTypeID] [int] NOT NULL,
	[LastJobID] [int] NOT NULL,
	[Monday] [bit] NOT NULL,
	[Tuesday] [bit] NOT NULL,
	[Wednesday] [bit] NOT NULL,
	[Thursday] [bit] NOT NULL,
	[Friday] [bit] NOT NULL,
	[Saturday] [bit] NOT NULL,
	[Sunday] [bit] NOT NULL,
	[ScheduleTime] [time](0) NOT NULL,
	[NextRunTime] [smalldatetime] NOT NULL,
	[LastRunTime] [smalldatetime] NOT NULL,
	[ActiveFlag] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_JobSchedule] PRIMARY KEY CLUSTERED 
(
	[JobScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Order]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[ServerOrderID] [uniqueidentifier] NOT NULL,
	[ReplacedByOrderId] [uniqueidentifier] NULL,
	[OrderStatusID] [int] NOT NULL,
	[AverageFillPrice] [float] NULL,
	[HighWaterMark] [float] NULL,
	[TrailOffsetInPercent] [float] NULL,
	[TrailOffsetInDollars] [float] NULL,
	[StopPrice] [float] NULL,
	[LimitPrice] [float] NULL,
	[TimeInForceID] [int] NOT NULL,
	[OrderSideID] [int] NOT NULL,
	[OrderClassID] [int] NOT NULL,
	[OrderTypeID] [int] NOT NULL,
	[IntegerFilledQuantity] [int] NOT NULL,
	[IntegerQuantity] [int] NOT NULL,
	[FilledQuantity] [float] NOT NULL,
	[Quantity] [float] NULL,
	[Notional] [float] NULL,
	[AssetClassID] [int] NOT NULL,
	[Symbol] [varchar](10) NOT NULL,
	[AssetId] [uniqueidentifier] NOT NULL,
	[ReplacedAtUTC] [date] NULL,
	[FailedAtUTC] [date] NULL,
	[CancelledAtUTC] [date] NULL,
	[ExpiredAtUTC] [date] NULL,
	[FilledAtUTC] [date] NULL,
	[SubmittedAtUTC] [date] NULL,
	[UpdatedAtUTC] [date] NULL,
	[CreatedAtUTC] [date] NULL,
	[ClientOrderId] [varchar](50) NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_OrderClass]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_OrderClass](
	[OrderClassID] [int] IDENTITY(0,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_OrderClass] PRIMARY KEY CLUSTERED 
(
	[OrderClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_OrderSide]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_OrderSide](
	[OrderSideID] [int] IDENTITY(0,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_OrderSide] PRIMARY KEY CLUSTERED 
(
	[OrderSideID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_OrderStatus]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_OrderStatus](
	[OrderStatusID] [int] IDENTITY(0,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[OrderStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_OrderType]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_OrderType](
	[OrderTypeID] [int] IDENTITY(0,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_OrderType] PRIMARY KEY CLUSTERED 
(
	[OrderTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Split]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Split](
	[Symbol] [varchar](10) NOT NULL,
	[ExecutionDate] [date] NOT NULL,
	[SplitFrom] [int] NOT NULL,
	[SplitTo] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Split] PRIMARY KEY CLUSTERED 
(
	[ExecutionDate] ASC,
	[Symbol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TimeInForce]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TimeInForce](
	[TimeInForceID] [int] IDENTITY(0,1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbl_TimeInForce] PRIMARY KEY CLUSTERED 
(
	[TimeInForceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TransactionHistory]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TransactionHistory](
	[Symbol] [varchar](10) NOT NULL,
	[TransDate] [datetime] NOT NULL,
	[Price] [float] NOT NULL,
	[Volume] [float] NOT NULL,
	[OrderTypeID] [int] NOT NULL,
	[OrderSideID] [int] NOT NULL,
 CONSTRAINT [PK_tbl_TransactionHistory] PRIMARY KEY CLUSTERED 
(
	[Symbol] ASC,
	[TransDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_Job]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Job_tbl_JobStatus] FOREIGN KEY([JobStatusID])
REFERENCES [dbo].[tbl_JobStatus] ([JobStatusID])
GO
ALTER TABLE [dbo].[tbl_Job] CHECK CONSTRAINT [FK_tbl_Job_tbl_JobStatus]
GO
ALTER TABLE [dbo].[tbl_Job]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Job_tbl_JobType] FOREIGN KEY([JobTypeID])
REFERENCES [dbo].[tbl_JobType] ([JobTypeID])
GO
ALTER TABLE [dbo].[tbl_Job] CHECK CONSTRAINT [FK_tbl_Job_tbl_JobType]
GO
ALTER TABLE [dbo].[tbl_JobError]  WITH CHECK ADD  CONSTRAINT [FK_tbl_JobError_tbl_Job] FOREIGN KEY([JobID])
REFERENCES [dbo].[tbl_Job] ([JobID])
GO
ALTER TABLE [dbo].[tbl_JobError] CHECK CONSTRAINT [FK_tbl_JobError_tbl_Job]
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Order_tbl_AssetClass] FOREIGN KEY([AssetClassID])
REFERENCES [dbo].[tbl_AssetClass] ([AssetClassID])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_tbl_Order_tbl_AssetClass]
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Order_tbl_OrderClass] FOREIGN KEY([OrderClassID])
REFERENCES [dbo].[tbl_OrderClass] ([OrderClassID])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_tbl_Order_tbl_OrderClass]
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Order_tbl_OrderSide] FOREIGN KEY([OrderSideID])
REFERENCES [dbo].[tbl_OrderSide] ([OrderSideID])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_tbl_Order_tbl_OrderSide]
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Order_tbl_OrderStatus] FOREIGN KEY([OrderStatusID])
REFERENCES [dbo].[tbl_OrderStatus] ([OrderStatusID])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_tbl_Order_tbl_OrderStatus]
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Order_tbl_OrderType] FOREIGN KEY([OrderTypeID])
REFERENCES [dbo].[tbl_OrderType] ([OrderTypeID])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_tbl_Order_tbl_OrderType]
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Order_tbl_TimeInForce] FOREIGN KEY([TimeInForceID])
REFERENCES [dbo].[tbl_TimeInForce] ([TimeInForceID])
GO
ALTER TABLE [dbo].[tbl_Order] CHECK CONSTRAINT [FK_tbl_Order_tbl_TimeInForce]
GO
ALTER TABLE [dbo].[tbl_TransactionHistory]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TransactionHistory_tbl_OrderType] FOREIGN KEY([OrderSideID])
REFERENCES [dbo].[tbl_OrderSide] ([OrderSideID])
GO
ALTER TABLE [dbo].[tbl_TransactionHistory] CHECK CONSTRAINT [FK_tbl_TransactionHistory_tbl_OrderType]
GO
ALTER TABLE [dbo].[tbl_User]  WITH CHECK ADD  CONSTRAINT [FK_tbl_User_tbl_Security] FOREIGN KEY([SecurityID])
REFERENCES [dbo].[tbl_Security] ([SecurityID])
GO
ALTER TABLE [dbo].[tbl_User] CHECK CONSTRAINT [FK_tbl_User_tbl_Security]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddAsset]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO










CREATE PROCEDURE [dbo].[sp_AddAsset] 	@Symbol varchar(10), @CompanyName varchar(100), @CurrencyCode varchar(10), @Price Float,
@NumEmployees int, @MarketCap float, @Revenue Float, @Equity Float, @NetIncome Float, @ProfitMargin Float, @ROE Float, @NumShares Int,
@EarnShare Float, @EarnSharePct Float,
@SICCode varchar(10), @SICDesc varchar(1000), @Website varchar(256), 
@Locale varchar(50), @ListDate datetime, @DelistDate datetime, @TradableFlag bit, @FracFlag bit, @PolygonFlag bit,
@StrongScore float, @SoftScore float, @FinancialScore float, @TotalScore float
AS
Set XACT_ABORT OFF

Insert into tbl_Asset
(Symbol, CompanyName, CurrencyCode, Price, NumEmployees, MarketCap, Revenue, Equity, NetIncome, ProfitMargin, ROE, NumShares, EarnShare, EarnSharePct, SICCode, SICDesc, Website, 
Locale, ListDate, DelistDate, TradableFlag, FracFlag, PolygonFlag, StrongScore, SoftScore, FinancialScore, TotalScore)
values 
(@Symbol, @CompanyName, @CurrencyCode, @Price, @NumEmployees, @MarketCap, @Revenue, @Equity, @NetIncome, @ProfitMargin, @ROE, 
@NumShares, @EarnShare, @EarnSharePct, @SICCode, @SICDesc, @Website, @Locale, @ListDate, @DelistDate, @TradableFlag, @FracFlag, @PolygonFlag,
@StrongScore, @SoftScore, @FinancialScore, @TotalScore)

IF @@ERROR <> 0
    Return 0
ELSE
    Return 1
GO
/****** Object:  StoredProcedure [dbo].[sp_AddAssetHist]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[sp_AddAssetHist] 	@Symbol varchar(10), @HistDate date, @Price float, @EMA100 float, @EMA200 float, @MACD float, @RSI float, @SMA_50 float, @SMA_200 float
AS
Set XACT_ABORT OFF

Insert into tbl_AssetHistory
(Symbol, HistDate, Price, EMA100, EMA200, MACD, RSI, SMA_50, SMA_200)
values 
(@Symbol, @HistDate, @Price, @EMA100, @EMA200, @MACD, @RSI, @SMA_50, @SMA_200)

IF @@ERROR <> 0
    Return 0
ELSE
    Return 1
GO
/****** Object:  StoredProcedure [dbo].[sp_AddDividend]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[sp_AddDividend] @Symbol varchar(10), @DeclarationDate date, @CashAmount float, @DividendType int, @Currency varchar(10),
@ExDividendDate date, @Frequency int, @RecordDate date, @PayDate date
AS
Set XACT_ABORT OFF

Insert into tbl_Dividend
(Symbol, DeclarationDate, CashAmount, DividendType, Currency,
ExDividendDate, Frequency, RecordDate, PayDate)
values 
(@Symbol, @DeclarationDate, @CashAmount, @DividendType, @Currency,
@ExDividendDate, @Frequency, @RecordDate, @PayDate)

IF @@ERROR <> 0
    Return 1
ELSE
    Return 0
GO
/****** Object:  StoredProcedure [dbo].[sp_AddHoldingHist]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[sp_AddHoldingHist] 	@Symbol varchar(10), @Shares float
AS
Set XACT_ABORT OFF

Insert into tbl_HoldingsHistory
(Symbol, Shares)
values 
(@Symbol, @Shares)

IF @@ERROR <> 0
    Return 0
ELSE
    Return 1
GO
/****** Object:  StoredProcedure [dbo].[sp_AddJob]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[sp_AddJob] 	@JobTypeID int, @Description varchar(200), @CreateUser varchar(25), @JobID int OUTPUT
AS
Set XACT_ABORT OFF

Insert into tbl_Job
(JobTypeID, JobStatusID, Description, CreateUser, CreateTime)
values 
(@JobTypeID, 1, @Description, @CreateUser, GETUTCDATE())

IF @@ERROR <> 0
    Set @JobID = 0
ELSE
    Set @JobID=@@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[sp_AddJobError]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[sp_AddJobError] 	@JobID int, @SequenceID int, @ErrorDate datetime, @Error varchar(250), @Exception varchar(max)
AS
Set XACT_ABORT OFF

Insert into tbl_JobError
(JobID, SequenceID, ErrorDate, Error, Exception)
values 
(@JobID, @SequenceID, @ErrorDate, @Error, @Exception)

IF @@ERROR <> 0
    return 1
ELSE
    return 0
GO
/****** Object:  StoredProcedure [dbo].[sp_AddJobSchedule]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_AddJobSchedule] 	@JobTypeID as int, @Monday as bit, @Tuesday as bit, @Wednesday as bit, @Thursday as bit, @Friday as bit, @Saturday as bit, 
@Sunday as bit, @ScheduleTime as time, @NextRunTime as smalldatetime, @SortOrder as int, @ActiveFlag as bit, @JobScheduleID as int output

AS
Set XACT_ABORT OFF

Insert into tbl_JobSchedule
(JobTypeID, LastJobID, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday, ScheduleTime, NextRunTime, LastRunTime, SortOrder, ActiveFlag)
values 
(@JobTypeID, 0, @Monday, @Tuesday, @Wednesday, @Thursday, @Friday, @Saturday, 
@Sunday, @ScheduleTime, @NextRunTime,  '1/1/1900', @SortOrder, @ActiveFlag)

IF @@ERROR <> 0
    Set @JobScheduleID = 0
ELSE
    Set @JobScheduleID=@@Identity
GO
/****** Object:  StoredProcedure [dbo].[sp_AddSplit]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[sp_AddSplit] 	@ExecutionDate date, @Symbol varchar(10), @SplitFrom int, @SplitTo int
AS
Set XACT_ABORT OFF

Insert into tbl_Split
(ExecutionDate, Symbol, SplitFrom, SplitTo)
values 
(@ExecutionDate, @Symbol, @SplitFrom, @SplitTo)

IF @@ERROR <> 0
    Return 1
ELSE
    Return 0
GO
/****** Object:  StoredProcedure [dbo].[sp_AddTransHist]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[sp_AddTransHist] 	@Symbol varchar(10), @TransDate datetime, @Price float, @Volume float, @OrderTypeID int, @OrderSideID int
AS
Set XACT_ABORT OFF

Insert into tbl_TransactionHistory
(Symbol, TransDate, Price, Volume, OrderTypeID, OrderSideID)
values 
(@Symbol, @TransDate, @Price, @Volume, @OrderTypeID, @OrderSideID)

IF @@ERROR <> 0
    Return 0
ELSE
    Return 1
GO
/****** Object:  StoredProcedure [dbo].[sp_AddUsers]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_AddUsers] 	@Login varchar(50), @Name varchar(50), @Email varchar(100), @SecurityID int, @ActiveFlag bit, @RecordID int OUTPUT
AS
Set XACT_ABORT OFF

Insert into tbl_User
(Login, Name, Email, SecurityID, ActiveFlag)
values 
(@Login, @Name, @Email, @SecurityID, @ActiveFlag)

IF @@ERROR <> 0
    Set @RecordID = 0
ELSE
    Set @RecordID=@@Identity
GO
/****** Object:  StoredProcedure [dbo].[sp_CleanJob]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_CleanJob]  	
AS
Set XACT_ABORT OFF 

BEGIN TRANSACTION

Select JobID
Into #tbl_JobID
From tbl_Job J
Inner Join tbl_JobType T on J.JobTypeID = T.JobTypeID
Where  datediff(day ,GetDate(), J.FinishTime) > T.DaysRetainLog

Delete E
From tbl_JobError E
Where E.JobID IN (Select JobID From #tbl_JobID)

Delete J
From tbl_Job J
Where J.JobID IN (Select JobID From #tbl_JobID)


Drop Table if exists #tbl_JobID

IF @@ERROR <> 0
BEGIN
	ROLLBACK TRANSACTION

    return @@ERROR
END
ELSE
BEGIN
	COMMIT TRANSACTION
    return (0)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteUser_ID]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_DeleteUser_ID]  	@UserID int
AS
Set XACT_ABORT OFF

Delete 
From tbl_User
Where UserID = @UserID

IF @@ERROR <> 0
    return (1)
ELSE
    return (0)





GO
/****** Object:  StoredProcedure [dbo].[sp_GetDividend]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO








CREATE PROCEDURE [dbo].[sp_GetDividend] @Symbol varchar(10), @EarliestPayDate Date
AS
Set XACT_ABORT OFF 

SET @EarliestPayDate = ISNULL(@EarliestPayDate, DATEADD(YEAR, -1, GETDATE()));
Select *
From tbl_Dividend S
Where S.Symbol = @Symbol And @EarliestPayDate < S.PayDate


IF @@ERROR <> 0
    return (1)
ELSE
    return (0)
GO
/****** Object:  StoredProcedure [dbo].[sp_GetJob]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[sp_GetJob]
AS
Set XACT_ABORT OFF 

Select J.JobID, T.Description as 'Type', S.Description as 'Status', J.Description, J.CreateUser, J.CreateTime,
J.StartTime, J.FinishTime
From tbl_Job J
Inner Join tbl_JobType T On J.JobTypeID = T.JobTypeID
Inner Join tbl_JobStatus S On J.JobTypeID = S.JobStatusID

IF @@ERROR <> 0
    return (1)
ELSE
    return (0)
GO
/****** Object:  StoredProcedure [dbo].[sp_GetJobError_JobID]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[sp_GetJobError_JobID]  	@JobID int 
AS
Set XACT_ABORT OFF 

Select *
from tbl_JobError
Where JobID = @JobID

IF @@ERROR <> 0
    return (1)
ELSE
    return (0)
GO
/****** Object:  StoredProcedure [dbo].[sp_GetJobSchedule]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_GetJobSchedule]
AS
Set XACT_ABORT OFF 

Select J.JobScheduleID, T.Description As 'Job Type', J.LastJobID, J.Monday, 
J.Tuesday, J.Wednesday, J.Thursday, J.Friday, J.Saturday, J.Sunday, J.ScheduleTime, J.NextRunTime,
J.LastRunTime, J.ActiveFlag
from tbl_JobSchedule J, tbl_JobType T
where NextRunTime < GETUTCDATE() AND J.JobTypeID = T.JobTypeID

IF @@ERROR <> 0
    return (1)
ELSE
    return (0)
GO
/****** Object:  StoredProcedure [dbo].[sp_GetJobSchedule_ID]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_GetJobSchedule_ID]  	@JobScheduleID int 
AS
Set XACT_ABORT OFF 

Select J.*
from tbl_JobSchedule J
Where JobScheduleID=@JobScheduleID

IF @@ERROR <> 0
    return (1)
ELSE
    return (0)
GO
/****** Object:  StoredProcedure [dbo].[sp_GetNextJob]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_GetNextJob] 
AS
Set XACT_ABORT OFF 

Select Top 1 *
From tbl_Job
Where JobStatusID = 1
Order By JobID

IF @@ERROR <> 0
    return (1)
ELSE
    return (0)
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSplit]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO







CREATE PROCEDURE [dbo].[sp_GetSplit] @Symbol varchar(10), @EarliestExecution Date
AS
Set XACT_ABORT OFF 

SET @EarliestExecution = ISNULL(@EarliestExecution, DATEADD(YEAR, -1, GETDATE()));
Select *
From tbl_Split S
Where S.Symbol = @Symbol And @EarliestExecution < S.ExecutionDate


IF @@ERROR <> 0
    return (1)
ELSE
    return (0)
GO
/****** Object:  StoredProcedure [dbo].[sp_GetTransHist_Symbol]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[sp_GetTransHist_Symbol]  	@Symbol varchar(10)
AS
Set XACT_ABORT OFF 

Select Top 1 *
from tbl_TransactionHistory
Where Symbol=@Symbol

IF @@ERROR <> 0
    return (1)
ELSE
    return (0)
GO
/****** Object:  StoredProcedure [dbo].[sp_GetUser_Login]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_GetUser_Login]  	@Login varchar(50)
AS
Set XACT_ABORT OFF 

Select U.*
from tbl_User U
Where Login=@Login

IF @@ERROR <> 0
    return (1)
ELSE
    return (0)
GO
/****** Object:  StoredProcedure [dbo].[sp_RefreshAllViews]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE   PROCEDURE [dbo].[sp_RefreshAllViews] 
AS 
SET NOCOUNT ON 

Declare @ViewName varchar(max)
Declare @DBName varchar(max)
Declare @sql nvarchar(max)

Declare @Views Table (DBName varchar(max),ViewName varchar(max))

Insert Into @Views (DBName,ViewName)
Select 'BotTrader',name From BotTrader.sys.views

While (Select COUNT(*) From @Views) > 0
Begin
	Select Top 1 @DBName = DBName, @ViewName = ViewName From @Views
	
	Set @sql = 'exec '+@DBName+'.dbo.sp_refreshview '''+@ViewName+''''
	exec sp_executesql @sql
	
	Delete @Views Where DBName=@DBName And ViewName=@ViewName
End
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchJobSchedules]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_SearchJobSchedules] 	@JobTypeID as int, @Monday as bit, @Tuesday as bit, @Wednesday as bit, @Thursday as bit, @Friday as bit, @Saturday as bit, 
@Sunday as bit, @ActiveFlag as bit
AS
Set XACT_ABORT OFF 

Select *
from tbl_JobSchedule
where JobTypeID = @JobTypeID AND ActiveFlag = 'true'
IF @@ERROR <> 0
    return (1)
ELSE
    return (0)
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAppConst]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[sp_UpdateAppConst] 	@JobID int, @JobStatusID int
AS
Set XACT_ABORT OFF

Update tbl_AppConst 	
	SET 
		Ind100EMA = @JobStatusID

		

IF @@ERROR <> 0
    Return 0
ELSE
    Return 1
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateAssetScores]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[sp_UpdateAssetScores] 	@Symbol varchar(10), @StrongScore float, @SoftScore float, @FinancialScore float, @TotalScore float
AS
Set XACT_ABORT OFF

	Update tbl_Asset 
	SET 
		StrongScore = @StrongScore,
		SoftScore = @SoftScore,
		FinancialScore = @FinancialScore,
		TotalScore = @TotalScore
	Where Symbol = @Symbol

IF @@ERROR <> 0
    Return 0
ELSE
    Return 1
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateHoldingsHist_Symbol]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[sp_UpdateHoldingsHist_Symbol] 	@Symbol varchar(10), @Shares float
AS
Set XACT_ABORT OFF
	Update tbl_HoldingsHistory SET Shares = @Shares Where Symbol = @Symbol

IF @@ERROR <> 0
    Return 0
ELSE
    Return 1
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateJob_ID]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[sp_UpdateJob_ID] 	@JobID int, @TimeStamp datetime, @StartFlag bit
AS
Set XACT_ABORT OFF

If (@StartFlag = 1)
	Update tbl_Job 	SET StartTime = @TimeStamp Where JobID = @JobID
Else
	Update tbl_Job SET FinishTime = @TimeStamp Where JobID = @JobID

IF @@ERROR <> 0
    Return 0
ELSE
    Return 1
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateJobStatus_ID]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[sp_UpdateJobStatus_ID] 	@JobID int, @JobStatusID int
AS
Set XACT_ABORT OFF

Update tbl_Job 	SET JobStatusID = @JobStatusID Where JobID = @JobID

IF @@ERROR <> 0
    Return 0
ELSE
    Return 1
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateLastJobSchedule]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[sp_UpdateLastJobSchedule] 	@JobScheduleID int, @LastJobID Integer, @NextRunTime smalldatetime
AS
Set XACT_ABORT OFF

Update tbl_JobSchedule
Set lastruntime = NextRunTime, NextRunTime = @NextRunTime, LastJobID = @LastJobID
Where JobScheduleID = @JobScheduleID

IF @@ERROR <> 0
    Return 0
ELSE
    Return 1
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateUser_ID]    Script Date: 2023-09-02 2:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_UpdateUser_ID] 	@UserID int, @Login varchar(50), @Name varchar(50), @Email varchar(100), @SecurityID int, @ActiveFlag bit
AS
Set XACT_ABORT OFF

Update tbl_User
SET Login = @Login, 
Name = @Name, 
Email = @Email, 
SecurityID = @SecurityID, 
ActiveFlag = @ActiveFlag
where UserID = @UserID

IF @@ERROR <> 0
    Return 0
ELSE
    Return 1
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tbl_Job"
            Begin Extent = 
               Top = 7
               Left = 49
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "tbl_JobStatus"
            Begin Extent = 
               Top = 228
               Left = 331
               Bottom = 347
               Right = 525
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbl_JobType"
            Begin Extent = 
               Top = 9
               Left = 341
               Bottom = 172
               Right = 535
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Job'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vw_Job'
GO
USE [master]
GO
ALTER DATABASE [BotTrader] SET  READ_WRITE 
GO
