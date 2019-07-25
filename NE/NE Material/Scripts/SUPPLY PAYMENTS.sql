CREATE TABLE [dbo].[SupplyPayment] (
    [Id]         INT  IDENTITY (1, 1) NOT NULL,
    [SupplyId]   INT  NULL,
    [UserId]     NVARCHAR(128)  NULL,
    [AmountPaid] INT  NOT NULL,
    [DatePaid]   DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([SupplyId]) REFERENCES [dbo].[Supply] ([Id]) ON DELETE CASCADE,
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON UPDATE CASCADE
);

SET IDENTITY_INSERT [dbo].[SupplyPayment] ON
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (30, 34,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 111600, N'2014-12-13')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (32, 67,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 13200, N'2015-03-23')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (33, 68,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 6500, N'2015-03-23')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (34, 69,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 6300, N'2015-03-23')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (35, 72,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 3800, N'2015-03-23')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (36, 73,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 7050, N'2015-03-23')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (37, 74,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 27700, N'2015-03-23')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (38, 75,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 20925, N'2015-03-23')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (39, 76,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 15150, N'2015-03-23')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (40, 77,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 27850, N'2015-03-23')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (41, 78,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 2325, N'2015-03-23')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (42, 130,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 18000, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (43, 104,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 55000, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (44, 105,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 70000, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (45, 111,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 20160, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (46, 112,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 5000, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (47, 51,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 10500, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (48, 52,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 93500, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (49, 54,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 27600, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (50, 55,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 22000, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (51, 56,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 22000, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (52, 57,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 15600, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (53, 58,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 16500, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (54, 59,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 76800, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (55, 60,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 62700, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (56, 61,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 55200, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (57, 62,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 27400, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (58, 63,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 12800, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (59, 64,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 5000, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (60, 65,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 7600, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (61, 66,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 5700, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (62, 87,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 8100, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (63, 89,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 3800, N'2015-05-18')
INSERT INTO [dbo].[SupplyPayment] ([Id], [SupplyId], [UserId], [AmountPaid], [DatePaid]) VALUES (64, 90,  N'75290585-3eb4-4c75-ae27-89241138b59d' , 6400, N'2015-05-18')
SET IDENTITY_INSERT [dbo].[SupplyPayment] OFF

