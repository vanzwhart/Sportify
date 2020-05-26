CREATE TABLE [dbo].[JenisPrograms] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [NamaProgram]  NVARCHAR (255) NOT NULL,
    [JenisAlat]    NVARCHAR (MAX) NULL,
    [JenisKelamin] NVARCHAR (MAX) NULL,
    [Dada]         BIT            NOT NULL,
    [Bahu]         BIT            NOT NULL,
    [Punggung]     BIT            NOT NULL,
    [Kaki]         BIT            NOT NULL,
    [Bokong]       BIT            NOT NULL,
    [Perut]        BIT            NOT NULL,
    [LenganBicep]  BIT            NOT NULL,
    [LenganTricep] BIT            NOT NULL,
    [FotoGerakan]  NVARCHAR (MAX) NULL,
    [Deskripsi]    NVARCHAR (MAX) NULL,
    [Tingkatan]    INT            NOT NULL,
    CONSTRAINT [PK_dbo.JenisPrograms] PRIMARY KEY CLUSTERED ([Id] ASC)
);

