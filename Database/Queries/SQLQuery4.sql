-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getDocsAppointment
	-- Add the parameters for the stored procedure here
	@Id int 
AS
BEGIN
	
	SET NOCOUNT ON;

    
	SELECT 
	d.FirstName as 'DOCTORS NAME',
	COUNT(a.Id) Appointments
	FROM Appointments a
	JOIN Doctors d 
	ON a.doctorId = d.Id
	JOIN Patients p 
	ON a.PatientId = p.Id
	where d.Id  = @Id
	Group by d.FirstName, NextVisitDate

END
GO


EXECUTE getDocsAppointment @Id = 3002;


