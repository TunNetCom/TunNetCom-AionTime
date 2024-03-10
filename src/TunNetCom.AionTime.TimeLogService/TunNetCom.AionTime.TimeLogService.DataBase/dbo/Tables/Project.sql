CREATE TABLE [dbo].[Project]
(
    [Id] INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
    [OrganisationId] INT NOT NULL,
    CONSTRAINT FKOrganisationProject 
        FOREIGN KEY (OrganisationId) 
        REFERENCES [dbo].[Organisation] (Id) 
        ON DELETE CASCADE
        ON UPDATE CASCADE
);