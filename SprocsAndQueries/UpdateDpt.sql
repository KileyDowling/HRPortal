create procedure [dbo].[UpdateDepartment]
(
@dptName varchar(20),
@dptId int
)
as 
update Departments
set DepartmentName = @dptName
where DepartmentId = @dptId
go



