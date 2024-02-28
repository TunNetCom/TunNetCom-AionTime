CREATE TABLE [dbo].[WorkItemHistory]
(
	[WorkItemHistoryId] INT NOT NULL PRIMARY KEY,
	[WorkItemHistory] varchar(1000) null,
	[WorkItemId] int not null,
	CONSTRAINT FKTicketHistory 
    FOREIGN KEY (WorkItemId) 
    REFERENCES [dbo].[WorkItem] (WorkItemId) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
)
