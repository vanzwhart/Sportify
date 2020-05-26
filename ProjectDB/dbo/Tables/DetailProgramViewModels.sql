CREATE TABLE [dbo].[DetailProgramViewModels] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [FotoGerakan] NVARCHAR (255) NOT NULL,
    [Deskripsi]   NVARCHAR (MAX) NULL,
    [Langkah]     NVARCHAR (MAX) NULL,
    [ProgramId]   INT            NOT NULL,
    CONSTRAINT [PK_dbo.DetailProgramViewModels] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.DetailProgramViewModels_dbo.JenisPrograms_ProgramId] FOREIGN KEY ([ProgramId]) REFERENCES [dbo].[JenisPrograms] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ProgramId]
    ON [dbo].[DetailProgramViewModels]([ProgramId] ASC);

