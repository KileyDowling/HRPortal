USE [SWCCorp]
GO
/****** Object:  StoredProcedure [dbo].[TotalHoursWorked]    Script Date: 7/17/2015 12:06:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[TotalHoursWorked]
(
	@employeeID int
)AS


Select SUM(TotalHoursByDay) as TotalHoursWorked
From TimeSheet t
	INNER JOIN Employee e
	ON t.EmpId = e.EmpID
WHERE t.EmpId =@employeeID
group by t.EmpId, e.FirstName, e.LastName

