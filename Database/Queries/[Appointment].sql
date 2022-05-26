/****** Script for SelectTopNRows command from SSMS  ******/
SELECT 
Appointments.Id,
Appointments.AppointmentTime,
Appointments.AppointmentTime,
Appointments.Advice,
Appointments.Comment,
Doctors.FirstName,
Patients.FirsName,
Patients.PatientCode,
Patients.Agreement
FROM [dbo].[Appointments]
JOIN Doctors On doctorId = Doctors.Id
JOIN Patients on PatientId = Patients.Id