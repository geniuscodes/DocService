/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[NormalizedName]
      ,[ConcurrencyStamp]
      ,[Name]
  FROM [PrescriptionsDB].[dbo].[AspNetRoles]