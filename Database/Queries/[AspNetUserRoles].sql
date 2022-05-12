/****** Script for SelectTopNRows command from SSMS  ******/
GO
SELECT TOP (1000) 
     *
  FROM [PrescriptionsDB].[dbo].[AspNetUserRoles]
  
  Go