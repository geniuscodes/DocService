 --Patients Per Doctor
 SELECT
docs.FirstName,
COUNT(*) AS 'Patients'
FROM PrescriptionsDB.[dbo].Appointments A
Join PrescriptionsDB.[dbo].Doctors docs
ON  A.doctorId = docs.Id
WHERE doctorId = 3004
GROUP BY docs.FirstName, docs.LastName 

---All Doctors ----


SELECT 
COUNT(*) TotalDoctors
FROM [PrescriptionsDB].[dbo].Doctors d
WHERE d.RegNumber IS NOT NULL


---Procedure


select * from PrescriptionsDB.[dbo].Doctors

SELECT

COUNT(*) AS 'Docs'
FROM PrescriptionsDB.[dbo].Doctors

SELECT

COUNT(*) AS 'Appointmrt'
FROM PrescriptionsDB.[dbo].Appointments


SELECT

COUNT(*) AS 'Patrons'

FROM PrescriptionsDB.[dbo].Patients


------
SELECT TOP (1000) [Id]
      ,[PatientType]
      ,[AppointmentTime]
      ,[NextVisitDate]
      ,[Advice]
      ,[Comment]
      ,[doctorId]
      ,[PatientId]
      ,[CreatedDate]
	  
	  
FROM  [PrescriptionsDB].[dbo].[Appointments] a
ORDER BY 
    Id 
    
SELECT 
*
FROM Doctors