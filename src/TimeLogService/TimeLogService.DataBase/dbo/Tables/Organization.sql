CREATE TABLE [dbo].[Organization]
(
	[Id] INT  IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [UserId] NVARCHAR(100) not null,
	[Name] Varchar(255) not null, 
    [AccountId] NVARCHAR(100) NOT NULL unique, 
    [AccountUri] VARCHAR(200) NOT NULL,
    [IsAionTimeApproved] BIT NOT NULL 

	CONSTRAINT FKUserOrganization 
        FOREIGN KEY (UserId) 
        REFERENCES [dbo].[User] (UserId) 
        ON DELETE CASCADE
        ON UPDATE CASCADE, 
)

GO

CREATE UNIQUE INDEX [IX_Organization_Name_Unique] ON [dbo].[Organization] ([Name])
