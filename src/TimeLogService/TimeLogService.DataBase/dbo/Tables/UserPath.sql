CREATE TABLE [dbo].[UserPath]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [UserId] INT NOT NULL,
    [PathType] NVARCHAR(150) NOT NULL,

    CONSTRAINT FK_UserPath_Uesr 
        FOREIGN KEY (UserId) 
        REFERENCES [dbo].[User] (Id) 
        ON DELETE CASCADE
        ON UPDATE CASCADE 
)
