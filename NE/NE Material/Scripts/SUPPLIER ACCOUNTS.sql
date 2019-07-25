CREATE TABLE [dbo].[SupplierAccount] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [AccountTitle]  VARCHAR (15) NOT NULL,
    [AccountNumber] VARCHAR (25) NULL,
    [SupplierId]    INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);
SET IDENTITY_INSERT [dbo].[SupplierAccount] ON
INSERT INTO [dbo].[SupplierAccount] ([Id], [AccountTitle], [AccountNumber], [SupplierId]) VALUES (1, N'HBL', N'H-B-L-LINK WEL PVT LAMTET', 13)
INSERT INTO [dbo].[SupplierAccount] ([Id], [AccountTitle], [AccountNumber], [SupplierId]) VALUES (2, N'HBL', N'H-B-L,00106179000295603', 14)
INSERT INTO [dbo].[SupplierAccount] ([Id], [AccountTitle], [AccountNumber], [SupplierId]) VALUES (3, N'HBL', N'H-B-L', 15)
INSERT INTO [dbo].[SupplierAccount] ([Id], [AccountTitle], [AccountNumber], [SupplierId]) VALUES (4, N'HBL', N'H-B L', 18)
INSERT INTO [dbo].[SupplierAccount] ([Id], [AccountTitle], [AccountNumber], [SupplierId]) VALUES (5, N'HBL', N'H-B-L', 19)
INSERT INTO [dbo].[SupplierAccount] ([Id], [AccountTitle], [AccountNumber], [SupplierId]) VALUES (6, N'HBL', N'H-B-L10610008542901', 20)
SET IDENTITY_INSERT [dbo].[SupplierAccount] OFF


