IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Ingredients] (
    [Id] int NOT NULL IDENTITY,
    CONSTRAINT [PK_Ingredients] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221116093651_InitialCreate', N'7.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [StockProducts] (
    [Id] int NOT NULL IDENTITY,
    [IngredientId] int NOT NULL,
    [Count] int NOT NULL,
    [LastRevisionDate] datetime2 NULL,
    CONSTRAINT [PK_StockProducts] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221116153805_AddStockProductTable', N'7.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE UNIQUE INDEX [IX_StockProducts_IngredientId] ON [StockProducts] ([IngredientId]);
GO

ALTER TABLE [StockProducts] ADD CONSTRAINT [FK_StockProducts_Ingredients_IngredientId] FOREIGN KEY ([IngredientId]) REFERENCES [Ingredients] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221117061303_AddPropertiesInIngredientTableAndPropertiesIntStockProductTable', N'7.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Dishes] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_Dishes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Contents] (
    [Id] int NOT NULL IDENTITY,
    [DishId] int NOT NULL,
    [IngredientId] int NOT NULL,
    [Count] int NOT NULL,
    CONSTRAINT [PK_Contents] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contents_Dishes_DishId] FOREIGN KEY ([DishId]) REFERENCES [Dishes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Contents_Ingredients_IngredientId] FOREIGN KEY ([IngredientId]) REFERENCES [Ingredients] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [DishId] int NOT NULL,
    [OpenDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Dishes_DishId] FOREIGN KEY ([DishId]) REFERENCES [Dishes] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Contents_DishId] ON [Contents] ([DishId]);
GO

CREATE INDEX [IX_Contents_IngredientId] ON [Contents] ([IngredientId]);
GO

CREATE INDEX [IX_Orders_DishId] ON [Orders] ([DishId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221117133742_AddTableDishTableContentTableOrder', N'7.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Contents] DROP CONSTRAINT [FK_Contents_Ingredients_IngredientId];
GO

ALTER TABLE [Orders] DROP CONSTRAINT [FK_Orders_Dishes_DishId];
GO

DROP INDEX [IX_Orders_DishId] ON [Orders];
GO

DROP INDEX [IX_Contents_IngredientId] ON [Contents];
GO

ALTER TABLE [Ingredients] ADD [ContentId] int NULL;
GO

ALTER TABLE [Dishes] ADD [OrderId] int NULL;
GO

CREATE INDEX [IX_Ingredients_ContentId] ON [Ingredients] ([ContentId]);
GO

CREATE INDEX [IX_Dishes_OrderId] ON [Dishes] ([OrderId]);
GO

ALTER TABLE [Dishes] ADD CONSTRAINT [FK_Dishes_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]);
GO

ALTER TABLE [Ingredients] ADD CONSTRAINT [FK_Ingredients_Contents_ContentId] FOREIGN KEY ([ContentId]) REFERENCES [Contents] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221117134503_UpdatePropertiesOrderAndContent', N'7.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Dishes] DROP CONSTRAINT [FK_Dishes_Orders_OrderId];
GO

ALTER TABLE [Ingredients] DROP CONSTRAINT [FK_Ingredients_Contents_ContentId];
GO

DROP INDEX [IX_Ingredients_ContentId] ON [Ingredients];
GO

DROP INDEX [IX_Dishes_OrderId] ON [Dishes];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ingredients]') AND [c].[name] = N'ContentId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Ingredients] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Ingredients] DROP COLUMN [ContentId];
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Dishes]') AND [c].[name] = N'OrderId');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Dishes] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Dishes] DROP COLUMN [OrderId];
GO

CREATE UNIQUE INDEX [IX_Orders_DishId] ON [Orders] ([DishId]);
GO

CREATE INDEX [IX_Contents_IngredientId] ON [Contents] ([IngredientId]);
GO

ALTER TABLE [Contents] ADD CONSTRAINT [FK_Contents_Ingredients_IngredientId] FOREIGN KEY ([IngredientId]) REFERENCES [Ingredients] ([Id]) ON DELETE CASCADE;
GO

ALTER TABLE [Orders] ADD CONSTRAINT [FK_Orders_Dishes_DishId] FOREIGN KEY ([DishId]) REFERENCES [Dishes] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221117143552_UpdatePropertiesTables', N'7.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Orders] ADD [Sum] decimal(18,2) NOT NULL DEFAULT 0.0;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221118131358_UpdatePropitesOrderSum', N'7.0.0');
GO

COMMIT;
GO