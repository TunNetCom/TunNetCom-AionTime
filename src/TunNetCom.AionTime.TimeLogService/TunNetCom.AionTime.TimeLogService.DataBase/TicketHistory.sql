CREATE TABLE [dbo].[TicketHistory]
(
	[TicketHistoryId] INT NOT NULL PRIMARY KEY,
	[TicketHistory] varchar(1000) not null,
	[TicketId] int not null,
	CONSTRAINT FKTicketHistory 
    FOREIGN KEY (TicketId) 
    REFERENCES [dbo].[Ticket] (TicketId) 
    ON DELETE CASCADE
    ON UPDATE CASCADE
)
