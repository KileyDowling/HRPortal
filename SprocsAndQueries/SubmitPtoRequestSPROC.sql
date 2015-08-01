create procedure SubmitPtoRequest
(
	@EmpId int,
	@HoursRequested int,
	@Date Date
)AS

INSERt INto PaidTimeOff ([status], EmpID, HoursRequested, [Date])
Values ('Submitted', @EmpId, @HoursRequested, @Date)