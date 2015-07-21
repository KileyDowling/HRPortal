USE [SWCCorp]
GO

/****** Object:  Table [dbo].[PaidTimeOff]    Script Date: 7/21/2015 1:46:56 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PaidTimeOff](
	[PtoRequestID] [int] IDENTITY(1,1) NOT NULL,
	[Status] [varchar](20) NOT NULL,
	[EmpID] [int] NOT NULL,
	[HoursRequested] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_PaidTimeOff] PRIMARY KEY CLUSTERED 
(
	[PtoRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PaidTimeOff]  WITH CHECK ADD  CONSTRAINT [FK_PaidTimeOff_Employee] FOREIGN KEY([EmpID])
REFERENCES [dbo].[Employee] ([EmpID])
GO

ALTER TABLE [dbo].[PaidTimeOff] CHECK CONSTRAINT [FK_PaidTimeOff_Employee]
GO


