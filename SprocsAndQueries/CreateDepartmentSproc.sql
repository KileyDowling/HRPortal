USE [SWCCorp]
GO

/****** Object:  StoredProcedure [dbo].[CreateDepartment]    Script Date: 8/1/2015 2:19:28 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[CreateDepartment]
(
@dptName varchar(20)
)
as 
insert into Departments(DepartmentName) 
values(@dptName)
GO


