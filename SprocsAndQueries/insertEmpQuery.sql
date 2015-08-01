insert into Employee(FirstName, LastName, HireDate,LocationID,ManagerID, [status], DepartmentID)
values('Mikey', 'Dragon', '07/27/2015', 4, 3, 'External', 2)

select * from Employee e inner join Departments d on e.DepartmentID = d.DepartmentID