CREATE TABLE [dbo].[FoodInfoes] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [NamaMakanan]   NVARCHAR (255) NOT NULL,
    [TotalCalories] INT            NOT NULL,
    [UserId]        NVARCHAR (128) NULL,
    CONSTRAINT [PK_dbo.FoodInfoes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.FoodInfoes_dbo.AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[FoodInfoes]([UserId] ASC);

