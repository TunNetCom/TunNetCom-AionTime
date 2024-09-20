CREATE TABLE [dbo].[UserPathOrganizations] (
    [PathId] INT NOT NULL,
    [OrganizationId] INT NOT NULL,
    [CreationDate] DATETIME
    PRIMARY KEY ([PathId], [OrganizationId]) NOT NULL,
    FOREIGN KEY ([PathId]) REFERENCES [dbo].[UserPath]([Id]),
    FOREIGN KEY ([OrganizationId]) REFERENCES [dbo].[Organization]([Id])
);