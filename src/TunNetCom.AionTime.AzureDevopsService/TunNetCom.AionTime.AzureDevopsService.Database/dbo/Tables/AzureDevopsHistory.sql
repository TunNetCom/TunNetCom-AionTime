CREATE TABLE [dbo].[AzureDevopsHistory] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [ActionType] INT           NULL,
    [Email]      NVARCHAR (50) NULL,
    [ActionDate] DATE          NULL,
    CONSTRAINT [PK_AzureDevopsHistory] PRIMARY KEY CLUSTERED ([Id] ASC)
);

