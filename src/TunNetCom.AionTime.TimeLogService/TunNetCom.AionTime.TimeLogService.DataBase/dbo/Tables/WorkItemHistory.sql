CREATE TABLE [dbo].[WorkItemHistory]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[History] varchar(1000) null,
	[WorkItemId] int not null,
	CONSTRAINT FKTicketHistory 
    FOREIGN KEY (WorkItemId) 
    REFERENCES [dbo].[WorkItem] (Id) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
)
