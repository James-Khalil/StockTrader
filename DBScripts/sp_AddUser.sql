USE [XYZDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_AddUser]    Script Date: 5/1/2023 10:27:47 AM ******/
DROP PROCEDURE [dbo].[sp_AddUser]
GO

/****** Object:  StoredProcedure [dbo].[sp_AddUser]    Script Date: 5/1/2023 10:27:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_AddUser] 	@Login varchar(25), @Name varchar(50), @ArchiveFlag bit, @RecordID int OUTPUT
AS
Set XACT_ABORT OFF

Insert into tbl_User
(Login, Name, ActiveFlag)
values 
(@Login, @Name, @ActiveFlag)

IF @@ERROR <> 0
    Set @RecordID = 0
ELSE
    Set @RecordID=@@Identity
GO
