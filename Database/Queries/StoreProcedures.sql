-- ================================================
-- Stored Procedures to Find the Doctors Using the Filters
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getAppointmentsOfDocById
	--  parameter
	@Id int 
AS
BEGIN
	
	SET NOCOUNT ON;

    
 SELECT
docs.FirstName,
COUNT(*) AS 'Patients'
FROM PrescriptionsDB.[dbo].Appointments A
Join PrescriptionsDB.[dbo].Doctors docs
ON  A.doctorId = docs.Id

WHERE doctorId = @Id
GROUP BY docs.FirstName, docs.LastName

END
GO


EXECUTE getAppointmentsOfDocById @Id = 3004;


select * from Appointments d
where d.doctorId = 3004

SELECT * FROM Doctors d
WHERE d.Id = 4002



--Docs Patients
SELECT 
	d.FirstName as 'DOCTORS NAME',
	COUNT(*) Appointments
	FROM Appointments a
	JOIN Doctors d 
	ON a.doctorId = d.Id
	JOIN Patients p 
	ON a.PatientId = p.Id
	where d.Id  = 3004
	Group by d.Id, d.FirstName



 SELECT
docs.FirstName,
COUNT(*) AS 'Patients'


FROM PrescriptionsDB.[dbo].Appointments A
Join PrescriptionsDB.[dbo].Doctors docs
ON  A.doctorId = docs.Id

WHERE doctorId = 3004
GROUP BY docs.FirstName, docs.LastName