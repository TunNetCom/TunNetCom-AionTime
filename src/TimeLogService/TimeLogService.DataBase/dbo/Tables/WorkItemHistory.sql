CREATE TABLE [dbo].[WorkItemHistory]
(
	[Id] INT  IDENTITY (1, 1) PRIMARY KEY NOT NULL,
	[History] varchar(1000) null,
	[WorkItemId] int not null,
	CONSTRAINT FKTicketHistory 
    FOREIGN KEY (WorkItemId) 
    REFERENCES [dbo].[WorkItem] (Id) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
)
