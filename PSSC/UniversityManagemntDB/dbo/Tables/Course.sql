CREATE TABLE [dbo].[Course] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [Name]        VARCHAR (50)     NOT NULL,
    [Description] VARCHAR (200)    NULL,
    [ProfessorId] UNIQUEIDENTIFIER NOT NULL,
    [CreatedDate] DATETIME         CONSTRAINT [DF_Course_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Course_Professor] FOREIGN KEY ([ProfessorId]) REFERENCES [dbo].[Professor] ([Id])
);

