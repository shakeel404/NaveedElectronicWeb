
CREATE TABLE [dbo].[SupplierContact] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [ContactTitle] VARCHAR (15) NOT NULL,
    [Number]       VARCHAR (20) NULL,
    [SupplierId]   INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([SupplierId]) REFERENCES [dbo].[Supplier] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);


SET IDENTITY_INSERT [dbo].[SupplierContact] ON
INSERT INTO [dbo].[SupplierContact] ([Id], [ContactTitle], [Number], [SupplierId]) VALUES (1, N'Mobile', N'03005924295', 13)
INSERT INTO [dbo].[SupplierContact] ([Id], [ContactTitle], [Number], [SupplierId]) VALUES (2, N'Mobile', N'0912565886', 13)
INSERT INTO [dbo].[SupplierContact] ([Id], [ContactTitle], [Number], [SupplierId]) VALUES (3, N'Mobile', N'03338142324', 14)
INSERT INTO [dbo].[SupplierContact] ([Id], [ContactTitle], [Number], [SupplierId]) VALUES (4, N'Mobile', N'0553258406', 14)
INSERT INTO [dbo].[SupplierContact] ([Id], [ContactTitle], [Number], [SupplierId]) VALUES (5, N'Mobile', N'03005748300', 15)
INSERT INTO [dbo].[SupplierContact] ([Id], [ContactTitle], [Number], [SupplierId]) VALUES (6, N'Mobile', N'0946-700411', 15)
INSERT INTO [dbo].[SupplierContact] ([Id], [ContactTitle], [Number], [SupplierId]) VALUES (7, N'Mobile', N'024-37637113', 18)
INSERT INTO [dbo].[SupplierContact] ([Id], [ContactTitle], [Number], [SupplierId]) VALUES (8, N'Mobile', N'024-37376713', 18)
INSERT INTO [dbo].[SupplierContact] ([Id], [ContactTitle], [Number], [SupplierId]) VALUES (9, N'Mobile', N'0333-9484160', 19)
INSERT INTO [dbo].[SupplierContact] ([Id], [ContactTitle], [Number], [SupplierId]) VALUES (10, N'Mobile', N'0946-744160', 19)
INSERT INTO [dbo].[SupplierContact] ([Id], [ContactTitle], [Number], [SupplierId]) VALUES (11, N'Mobile', N'0300-9643800', 20)
INSERT INTO [dbo].[SupplierContact] ([Id], [ContactTitle], [Number], [SupplierId]) VALUES (12, N'Mobile', N'055-3731624', 20)
SET IDENTITY_INSERT [dbo].[SupplierContact] OFF
