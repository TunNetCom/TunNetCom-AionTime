CREATE TABLE [dbo].[User]
(
	[Id] INT  IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [UserId] NVARCHAR(100) NOT NULL UNIQUE, 
    [EmailAddress] VARCHAR(50) NOT NULL, 
    [PublicAlias] NVARCHAR(100) NOT NULL, 
    [CoreRevision] INT NOT NULL, 
    [TimeStamp] DATETIME NOT NULL, 
    [Revision] INT NOT NULL
)
