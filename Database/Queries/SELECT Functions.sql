  --Getting Patient Informations using IN
SELECT TOP (1000) [Id]
      ,[PatientType]
      ,[AppointmentTime]
      ,[NextVisitDate]
      ,[Advice]
      ,[Comment]
      ,[doctorId]
      ,[PatientId]
      ,[CreatedDate],
	  COALESCE(Advice,' ') Advice
	  
FROM  [PrescriptionsDB].[dbo].[Appointments]
WHERE AppointmentTime  BETWEEN  '09:00' and '10:30'
	  AND 
	 CreatedDate IN ('2022-06-02', '2022-02-10'); 
	

-----JOIN Procedure -




--FUction to For filtering 
