CREATE TABLE [dbo].[Project]
(
    [Id] INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [OrganizationId] INT NOT NULL,
    [ProjectId] NVARCHAR(100) NOT NULL UNIQUE, 
    [Name] VARCHAR(50) NOT NULL, 
    [State] INT NULL, 
    [Visibility] VARCHAR(50) NULL, 
    [LastUpdateTime] DATETIME NULL, 
    [Url] VARCHAR(200) NOT NULL,
    CONSTRAINT FKOrganisationProject 
        FOREIGN KEY (OrganizationId) 
        REFERENCES [dbo].[Organization] (Id) 
        ON DELETE CASCADE
        ON UPDATE CASCADE 
);