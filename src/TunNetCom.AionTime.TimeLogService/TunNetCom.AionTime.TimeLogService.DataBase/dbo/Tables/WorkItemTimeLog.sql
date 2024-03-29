﻿CREATE TABLE [dbo].[WorkItemTimeLog]
(
	[Id] INT IDENTITY (1, 1) PRIMARY KEY NOT NULL,
	[Description] varchar(200) null,
	[Time] datetime null,
	[WorkItemId] int not null,
	CONSTRAINT FKProjectTicketLog
    FOREIGN KEY (WorkItemId) 
    REFERENCES [dbo].[WorkItem] (Id) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
)
