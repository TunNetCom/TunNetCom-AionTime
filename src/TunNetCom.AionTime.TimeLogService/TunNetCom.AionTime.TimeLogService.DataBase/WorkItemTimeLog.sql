CREATE TABLE [dbo].[WorkItemTimeLog]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Description] varchar(200) null,
	[Time] date null,
	[WorkItemId] int not null,
	CONSTRAINT FKProjectTicketLog
    FOREIGN KEY (WorkItemId) 
    REFERENCES [dbo].[WorkItem] (Id) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
)
