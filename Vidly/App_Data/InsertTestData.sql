--Test data

TRUNCATE TABLE [dbo].[Movies]

SET IDENTITY_INSERT [dbo].[Movies] ON
INSERT INTO [dbo].[Movies] ([Id], [Name], [MovieGenreTypeId], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (1, N'Hangover', 1, N'2009-10-06 00:00:00', N'2018-03-02 13:34:37', 5)
INSERT INTO [dbo].[Movies] ([Id], [Name], [MovieGenreTypeId], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (2, N'Die Hard', 2, N'1988-12-15 00:00:00', N'2018-03-02 13:34:37', 2)
INSERT INTO [dbo].[Movies] ([Id], [Name], [MovieGenreTypeId], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (4, N'The Terminator', 2, N'1985-04-18 00:00:00', N'2018-03-02 13:34:37', 10)
INSERT INTO [dbo].[Movies] ([Id], [Name], [MovieGenreTypeId], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (5, N'Toy Story', 3, N'1996-03-14 00:00:00', N'2018-03-02 13:34:37', 5)
INSERT INTO [dbo].[Movies] ([Id], [Name], [MovieGenreTypeId], [ReleaseDate], [DateAdded], [NumberInStock]) VALUES (6, N'Titanic', 4, N'1998-02-05 00:00:00', N'2018-03-02 13:34:37', 8)
SET IDENTITY_INSERT [dbo].[Movies] OFF
