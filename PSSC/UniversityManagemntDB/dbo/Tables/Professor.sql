CREATE TABLE [dbo].[Professor] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        NVARCHAR (50)    NOT NULL,
    [Interests]   VARCHAR (200)    NULL,
    [CreatedDate] DATETIME         CONSTRAINT [DF_Professor_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Professor] PRIMARY KEY CLUSTERED ([Id] ASC)
);

