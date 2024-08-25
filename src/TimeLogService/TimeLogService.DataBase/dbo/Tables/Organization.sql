CREATE TABLE [dbo].[Organization]
(
	[Id] INT  IDENTITY (1, 1) PRIMARY KEY NOT NULL,
	[Name] Varchar(255) not null
)

GO

CREATE UNIQUE INDEX [IX_Organization_Name_Unique] ON [dbo].[Organization] ([Name])
