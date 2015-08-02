USE [SWCCorp]
GO

/****** Object:  StoredProcedure [dbo].[UpdateDepartment]    Script Date: 8/2/2015 12:50:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[UpdateEmployee]
(
@firstName varchar(20),
@lastName varchar(30),
@locationId int,
@managerId int,
@status char(12),
@deptId int,
@empId int
)
as 
update Employee
set  FirstName = @firstName,
LastName = @lastName,
LocationID = @locationId,
ManagerID = @managerId,
[Status] = @status,
DepartmentID = @deptId
where EmpID = @empId

GO


