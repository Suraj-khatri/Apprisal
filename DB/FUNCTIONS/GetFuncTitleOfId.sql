SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
GO


CREATE function [dbo].[GetFuncTitleOfId](@functionalTitle int)
returns char(1000)
as 
begin
	declare @Functional varchar(100)
		set @Functional =  (select detail_title from StaticDataDetail where ROWID = @functionaltitle)
	return @Functional
end



GO