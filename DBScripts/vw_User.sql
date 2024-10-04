USE [XYZDB]
GO

/****** Object:  View [dbo].[vw_User]    Script Date: 5/1/2023 10:22:54 AM ******/
DROP VIEW [dbo].[vw_User]
GO

/****** Object:  View [dbo].[vw_User]    Script Date: 5/1/2023 10:22:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[vw_User]
AS

Select * From tbl_User

GO


