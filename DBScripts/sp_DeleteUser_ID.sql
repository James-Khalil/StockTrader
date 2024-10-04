USE [XYZDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_DeleteUser_ID]    Script Date: 5/1/2023 10:30:03 AM ******/
DROP PROCEDURE [dbo].[sp_DeleteUser_ID]
GO

/****** Object:  StoredProcedure [dbo].[sp_DeleteUser_ID]    Script Date: 5/1/2023 10:30:03 AM ******/
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


