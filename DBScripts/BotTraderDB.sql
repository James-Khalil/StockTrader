USE [master]
GO
/****** Object:  Database [BotTrader]    Script Date: 2023-05-29 4:16:18 PM ******/
CREATE DATABASE [BotTrader]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BotTrader', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BotTrader.mdf' , SIZE = 98496KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BotTrader_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\BotTrader_log.ldf' , SIZE = 5960KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
/****** Object:  UserDefinedFunction [dbo].[fn_GetPower]    Script Date: 2023-05-29 4:16:18 PM ******/
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
/****** Object:  UserDefinedFunction [dbo].[fn_Split]    Script Date: 2023-05-29 4:16:18 PM ******/
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
/****** Object:  Table [dbo].[tbl_User]    Script Date: 2023-05-29 4:16:18 PM ******/
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
/****** Object:  Table [dbo].[tbl_Security]    Script Date: 2023-05-29 4:16:18 PM ******/
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
/****** Object:  View [dbo].[vw_User]    Script Date: 2023-05-29 4:16:18 PM ******/
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
/****** Object:  Table [dbo].[tbl_AppConst]    Script Date: 2023-05-29 4:16:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_AppConst](
	[AppConstID] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyCode] [varchar](3) NOT NULL,
 CONSTRAINT [PK_tbl_AppConst] PRIMARY KEY CLUSTERED 
(
	[AppConstID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_AssetClass]    Script Date: 2023-05-29 4:16:18 PM ******/
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
/****** Object:  Table [dbo].[tbl_Order]    Script Date: 2023-05-29 4:16:18 PM ******/
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
/****** Object:  Table [dbo].[tbl_OrderClass]    Script Date: 2023-05-29 4:16:18 PM ******/
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
/****** Object:  Table [dbo].[tbl_OrderSide]    Script Date: 2023-05-29 4:16:18 PM ******/
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
/****** Object:  Table [dbo].[tbl_OrderStatus]    Script Date: 2023-05-29 4:16:18 PM ******/
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
/****** Object:  Table [dbo].[tbl_OrderType]    Script Date: 2023-05-29 4:16:18 PM ******/
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
/****** Object:  Table [dbo].[tbl_symbol]    Script Date: 2023-05-29 4:16:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_symbol](
	[SymbolID] [int] IDENTITY(1,1) NOT NULL,
	[Symbol] [varchar](10) NOT NULL,
	[CompanyName] [varchar](100) NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_tbl_symbol] PRIMARY KEY CLUSTERED 
(
	[SymbolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TimeInForce]    Script Date: 2023-05-29 4:16:18 PM ******/
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
ALTER TABLE [dbo].[tbl_User]  WITH CHECK ADD  CONSTRAINT [FK_tbl_User_tbl_Security] FOREIGN KEY([SecurityID])
REFERENCES [dbo].[tbl_Security] ([SecurityID])
GO
ALTER TABLE [dbo].[tbl_User] CHECK CONSTRAINT [FK_tbl_User_tbl_Security]
GO
/****** Object:  StoredProcedure [dbo].[sp_AddAppUser]    Script Date: 2023-05-29 4:16:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_AddAppUser] 	@Login varchar(50), @Name varchar(50), @Email varchar(100), @SecurityID int, @ActiveFlag bit, @RecordID int OUTPUT
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
/****** Object:  StoredProcedure [dbo].[sp_DeleteUser_ID]    Script Date: 2023-05-29 4:16:18 PM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetUser_Login]    Script Date: 2023-05-29 4:16:18 PM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_RefreshAllViews]    Script Date: 2023-05-29 4:16:18 PM ******/
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
/****** Object:  StoredProcedure [dbo].[sp_UpdateUser_ID]    Script Date: 2023-05-29 4:16:18 PM ******/
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
USE [master]
GO
ALTER DATABASE [BotTrader] SET  READ_WRITE 
GO
