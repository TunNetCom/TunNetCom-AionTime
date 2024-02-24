CREATE TABLE [dbo].[Project]
(
    [ProjectId] INT NOT NULL PRIMARY KEY,
    [OrganisationId] INT NOT NULL,
    CONSTRAINT FKOrganisationProject 
        FOREIGN KEY (OrganisationId) 
        REFERENCES [dbo].[Organisation] (OrganisationId) 
        ON DELETE CASCADE
        ON UPDATE CASCADE
);