USE [BotTrader]
GO

SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO


CREATE OR ALTER PROCEDURE [dbo].[sp_RefreshAllViews] 
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


