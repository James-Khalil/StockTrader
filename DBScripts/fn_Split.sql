USE [BotTrader]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Split]    Script Date: 5/1/2023 10:26:43 AM ******/
DROP FUNCTION IF EXISTS [dbo].[fn_Split]
GO

/****** Object:  UserDefinedFunction [dbo].[fn_Split]    Script Date: 5/1/2023 10:26:43 AM ******/
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
