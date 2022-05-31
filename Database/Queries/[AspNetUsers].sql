-- Drop '[ColumnName]' from table '[TableName]' in schema '[dbo]'
-- Add a new column '[NewColumnName]' to table '[TableName]' in schema '[dbo]'
-- Delete rows from table '[TableName]' in schema '[dbo]'
DELETE FROM [dbo].[Appointments]
WHERE Id  = 1145
GO

ALTER TABLE [Appointments] DROP CONSTRAINT UQ__Appointm__048A0008E091F511
ALTER TABLE Appointments ALTER COLUMN SerialNumber INT NOT NULL




-- Select rows from a Table or View '[TableOrViewName]' in schema '[dbo]'
SELECT * FROM [dbo].[Appointments]
GO