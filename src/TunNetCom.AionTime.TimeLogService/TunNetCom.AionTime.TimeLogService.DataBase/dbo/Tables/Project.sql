CREATE TABLE [dbo].[Project]
(
    [Id] INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [OrganizationId] INT NOT NULL,
    CONSTRAINT FKOrganisationProject 
        FOREIGN KEY (OrganizationId) 
        REFERENCES [dbo].[Organization] (Id) 
        ON DELETE CASCADE
        ON UPDATE CASCADE
);