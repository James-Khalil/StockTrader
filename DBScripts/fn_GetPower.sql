USE [BotTrader]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_GetPower]    Script Date: 5/1/2023 10:25:00 AM ******/
DROP FUNCTION IF EXISTS [dbo].[fn_GetPower]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_GetPower]    Script Date: 5/1/2023 10:25:00 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[fn_GetPower] (@Num1 int, @Num2 int)
RETURNS float AS  
BEGIN 
	Declare @Result float = @Num1
	Declare @Loop int = 0

	While @Loop < @Num2
	Begin
		Set @Result = @Result * @Num2 
	End

	Return(@Result)
END

GO
