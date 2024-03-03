CREATE TABLE [dbo].[WorkItem]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Discription] varchar(1000) null,
    [ProjectId] int not null,
	CONSTRAINT FKProjectTicket 
        FOREIGN KEY (ProjectId) 
        REFERENCES [dbo].[Project] (Id) 
        ON DELETE CASCADE
        ON UPDATE CASCADE
)
