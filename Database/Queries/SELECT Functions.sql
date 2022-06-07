  --Getting Patient Informations using IN
SELECT TOP (1000) [Id]
      ,[PatientType]
      ,[AppointmentTime]
      ,[NextVisitDate]
      ,[Advice]
      ,[Comment]
      ,[doctorId]
      ,[PatientId]
      ,[CreatedDate]
	  
FROM  [PrescriptionsDB].[dbo].[Appointments]
WHERE AppointmentTime  BETWEEN  '08:00' and '08:30'
	  AND 
	 CreatedDate IN ('2022-06-02', '2022-02-10'); 
	

-----

