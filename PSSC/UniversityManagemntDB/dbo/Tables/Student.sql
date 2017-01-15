CREATE TABLE [dbo].[Student] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        VARCHAR (50)     NOT NULL,
    [StudyYear]   INT              NOT NULL,
    [CreatedDate] DATETIME         CONSTRAINT [DF_Student_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED ([Id] ASC)
);

