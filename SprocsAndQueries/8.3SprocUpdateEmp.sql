USE [SWCCorp]
GO

/****** Object:  StoredProcedure [dbo].[UpdateEmployee]    Script Date: 8/3/2015 8:47:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[UpdateEmployee]
(
@firstName varchar(20),
@lastName varchar(30),
@locationId int,
@managerId int,
@status char(12),
@deptId int,
@empId int,
@hireDate datetime
)
as 
update Employee
set  FirstName = @firstName,
LastName = @lastName,
LocationID = @locationId,
ManagerID = @managerId,
[Status] = @status,
DepartmentID = @deptId,
HireDate = @hireDate
where EmpID = @empId


GO


