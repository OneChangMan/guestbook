CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [name] NVARCHAR(35) NOT NULL, 
    [continent] INT NULL, 
    [comment] NVARCHAR(200) NOT NULL, 
    [date] TIMESTAMP NOT NULL, 
    [edited] DATETIME NULL, 
    [deleted] BIT NOT NULL DEFAULT 0 
)
