USE [XYZDB]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetUser_Login]    Script Date: 5/1/2023 10:36:48 AM ******/
DROP PROCEDURE [dbo].[sp_GetUser_Login]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetUser_Login]    Script Date: 5/1/2023 10:36:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_GetUser_Login]  	@Login varchar(25)
AS
Set XACT_ABORT OFF 

Select U.*
Where Login=@Login

IF @@ERROR <> 0
    return (1)
ELSE
    return (0)
GO


