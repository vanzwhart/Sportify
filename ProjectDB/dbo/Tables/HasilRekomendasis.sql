CREATE TABLE [dbo].[HasilRekomendasis] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Hari]      INT            NOT NULL,
    [Set]       INT            NOT NULL,
    [Repetisi]  INT            NOT NULL,
    [ProgramId] INT            NOT NULL,
    [UserId]    NVARCHAR (128) NULL,
    CONSTRAINT [PK_dbo.HasilRekomendasis] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.HasilRekomendasis_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_dbo.HasilRekomendasis_dbo.JenisPrograms_ProgramId] FOREIGN KEY ([ProgramId]) REFERENCES [dbo].[JenisPrograms] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[HasilRekomendasis]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProgramId]
    ON [dbo].[HasilRekomendasis]([ProgramId] ASC);

