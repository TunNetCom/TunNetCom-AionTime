CREATE TABLE [dbo].[TicketTimeLog]
(
	[TicketTimeLogId] INT NOT NULL PRIMARY KEY,
	[LogDescription] varchar(200) not null,
	[LogTime] date not null,
	[TicketId] int not null,
	CONSTRAINT FKProjectTicketLog
    FOREIGN KEY (TicketId) 
    REFERENCES [dbo].[Ticket] (TicketId) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
)
