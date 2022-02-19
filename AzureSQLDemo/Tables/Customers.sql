CREATE TABLE [dbo].[Customers]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(150) NULL, 
    [LastName] NVARCHAR(150) NULL, 
    [Email] VARCHAR(50) NULL
)
