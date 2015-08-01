create procedure GenerateListOfMngrs
as
select distinct e.FirstName + ' ' + e.LastName as [ManagerName], e.EmpID
from Employee e
	inner join Employee em
	on e.EmpID = em.ManagerID