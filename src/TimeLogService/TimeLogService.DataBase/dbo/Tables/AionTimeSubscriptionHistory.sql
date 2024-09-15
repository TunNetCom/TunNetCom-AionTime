CREATE TABLE [dbo].[AionTimeSubscriptionHistory]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [SubscriptionId] int NOT NULL,
	[SubscriptionDate] DATE NOT NULL, 

    CONSTRAINT FKSubscriptionSubscriptionHistory 
        FOREIGN KEY (SubscriptionId) 
        REFERENCES [dbo].[AionTimeSubscription] (Id)
        ON DELETE CASCADE
        ON UPDATE CASCADE, 

)
