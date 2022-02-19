CREATE TABLE [dbo].[StarbucksOrders]
(
	[Id] INT IDENTITY NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(150) NULL, 
    [Date] DATETIMEOFFSET NULL, 
    [CustomerId]INT NULL,
    Constraint CustomerForeignKey Foreign Key (CustomerId) References dbo.Customers(Id)
)
