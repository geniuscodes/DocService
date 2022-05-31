/****** Script for SelectTopNRows command from SSMS  ******/
-- Drop '[ColumnName]' from table '[TableName]' in schema '[dbo]'
-- Delete rows from table '[TableName]' in schema '[dbo]'
DELETE FROM [dbo].[Appointments]
WHERE  SerialNumber = 101/* add search conditions here */
GO