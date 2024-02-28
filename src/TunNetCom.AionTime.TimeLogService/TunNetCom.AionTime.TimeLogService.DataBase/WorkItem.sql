CREATE TABLE [dbo].[WorkItem]
(
	[WorkItemId] INT NOT NULL PRIMARY KEY,
	[WorkItemDiscription] varchar(1000) null,
    [ProjectId] int not null,
	CONSTRAINT FKProjectTicket 
        FOREIGN KEY (ProjectId) 
        REFERENCES [dbo].[Project] (ProjectId) 
        ON DELETE CASCADE
        ON UPDATE CASCADE
)
