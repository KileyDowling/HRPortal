select * from Departments

declare @dptName varchar(20)
set @dptName = 'Finance'

insert into Departments(DepartmentName)
values(@dptName)