CREATE TABLE [dbo].[Enrollment] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [StudentId]   UNIQUEIDENTIFIER NOT NULL,
    [CourseId]    UNIQUEIDENTIFIER NOT NULL,
    [CreatedDate] DATETIME         NOT NULL,
    CONSTRAINT [PK_Enrollment] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Enrollment_Course] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Course] ([Id]),
    CONSTRAINT [FK_Enrollment_Student] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Student] ([Id])
);

