CREATE TABLE [dbo].[Organization]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(255) NOT NULL, 
    [Pat] NVARCHAR(150) NOT NULL 
)

GO

CREATE UNIQUE INDEX [IX_Organization_Name_Unique] ON [dbo].[Organization] ([Name])
