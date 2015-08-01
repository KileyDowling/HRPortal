USE [SWCCorp]
GO

/****** Object:  StoredProcedure [dbo].[TimeTrackerSummary]    Script Date: 7/28/2015 11:09:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[TimeTrackerSummary]
(
@empID int
)
as

select * from TimeSheet
inner join Employee on TimeSheet.EmpId = Employee.EmpID
inner join EntryType et on TimeSheet.EntryTypeID = et.EntryTypeID
where TimeSheet.EmpId = @empID
order by DateOfTimesheet desc



GO


