CREATE TABLE [dbo].[Project]
(
    [Id] INT NOT NULL PRIMARY KEY,
    [OrganisationId] INT NOT NULL,
    CONSTRAINT FKOrganisationProject 
        FOREIGN KEY (OrganisationId) 
        REFERENCES [dbo].[Organisation] (Id) 
        ON DELETE CASCADE
        ON UPDATE CASCADE
);