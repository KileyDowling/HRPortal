create procedure GenerateManagerList
As
SELECT m.EmpID,m.FirstName  + ' ' + m.LastName as [EmployeeName], e.FirstName  + ' ' + e.LastName as [ManagerName], e.EmpID as [ManagerId] 
FROM Employee e INNER JOIN Employee M on e.EmpID = m.ManagerID ORDER BY m.ManagerID