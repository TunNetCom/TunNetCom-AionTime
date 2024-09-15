CREATE TABLE [dbo].[AionTimeSubscription]
(
	[Id] INT  IDENTITY (1, 1) PRIMARY KEY NOT NULL, 
    [SubsecriptionDate] DATETIME NULL, 
    [ExpirationDate] DATETIME NULL, 
    [OrganizationId] INT NOT NULL,

    CONSTRAINT FKOrganizationSubscription 
        FOREIGN KEY (OrganizationId) 
        REFERENCES [dbo].[Organization] (Id) 
        ON DELETE CASCADE
        ON UPDATE CASCADE, 
)
