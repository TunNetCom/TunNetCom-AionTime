CREATE TABLE [dbo].[WorkItemTimeLog]
(
	[WorkItemTimeLogId] INT NOT NULL PRIMARY KEY,
	[LogDescription] varchar(200) null,
	[LogTime] date null,
	[WorkItemId] int not null,
	CONSTRAINT FKProjectTicketLog
    FOREIGN KEY (WorkItemId) 
    REFERENCES [dbo].[WorkItem] (WorkItemId) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
)
