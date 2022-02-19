/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO dbo.Customers(FirstName, LastName, Email) values ('Siddharth', 'Dhawan', 'siddharthdwn@gmail.com')
INSERT INTO dbo.Customers(FirstName, LastName, Email) values ('Shannon', 'Chow', 'shannon@gmail.com')


GO
