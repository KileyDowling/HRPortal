USE [SWCCorp]
GO

/****** Object:  StoredProcedure [dbo].[EmployeeDirectory]    Script Date: 7/29/2015 8:52:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[EmployeeDirectory]
as

select e.FirstName, e.LastName,e.HireDate, (m.FirstName + ' ' +  m.LastName) as [ManagerName], d.DepartmentName, l.[state], e.[Status]
 from Employee e inner join Departments d on e.DepartmentID = d.DepartmentID
inner join Employee m on m.EmpID = e.ManagerID
inner join Location l on e.LocationID = l.LocationID
order by e.LastName


GO


