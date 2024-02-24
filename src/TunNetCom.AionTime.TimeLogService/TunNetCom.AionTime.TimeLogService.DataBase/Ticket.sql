CREATE TABLE [dbo].[Ticket]
(
	[TicketId] INT NOT NULL PRIMARY KEY,
	[TicketDiscription] varchar(1000) null,
    [ProjectId] int not null,
	CONSTRAINT FKProjectTicket 
        FOREIGN KEY (ProjectId) 
        REFERENCES [dbo].[Project] (ProjectId) 
        ON DELETE CASCADE
        ON UPDATE CASCADE
)
