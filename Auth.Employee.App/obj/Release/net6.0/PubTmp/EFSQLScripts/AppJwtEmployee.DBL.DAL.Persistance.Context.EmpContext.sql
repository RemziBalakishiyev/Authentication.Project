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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230116113035_migrate_2')
BEGIN
    CREATE TABLE [Department] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Department] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230116113035_migrate_2')
BEGIN
    CREATE TABLE [Employee] (
        [Id] int NOT NULL IDENTITY,
        [FIRS_NAME] nvarchar(max) NOT NULL,
        [LAST_NAME] nvarchar(max) NOT NULL,
        [BIRTH_DATE] datetime2 NULL,
        [SALARY] real NULL,
        [DepartmentId] int NOT NULL,
        CONSTRAINT [PK_Employee] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Employee_Department_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Department] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230116113035_migrate_2')
BEGIN
    CREATE INDEX [IX_Employee_DepartmentId] ON [Employee] ([DepartmentId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230116113035_migrate_2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230116113035_migrate_2', N'6.0.12');
END;
GO

COMMIT;
GO

