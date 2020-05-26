CREATE TABLE [dbo].[UserInfoes] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [NamaLengkap]    NVARCHAR (MAX) NULL,
    [BeratBadan]     INT            NOT NULL,
    [TinggiBadan]    INT            NOT NULL,
    [Dada]           BIT            NOT NULL,
    [Bahu]           BIT            NOT NULL,
    [Punggung]       BIT            NOT NULL,
    [Kaki]           BIT            NOT NULL,
    [Bokong]         BIT            NOT NULL,
    [Perut]          BIT            NOT NULL,
    [LenganBicep]    BIT            NOT NULL,
    [LenganTricep]   BIT            NOT NULL,
    [tanggal_update] DATETIME       NOT NULL,
    [tanggal_lahir]  DATETIME       NOT NULL,
    [UserId]         NVARCHAR (128) NULL,
    [Tingkatan]      INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_dbo.UserInfoes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.UserInfoes_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[UserInfoes]([UserId] ASC);

