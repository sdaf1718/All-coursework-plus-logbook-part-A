CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [username] NCHAR(10) NULL, 
    [paswword] NCHAR(10) NULL, 
    [confirmpassword] NCHAR(10) NULL, 
    [email] NVARCHAR(MAX) NULL, 
    [secretquestion] NVARCHAR(MAX) NULL, 
    [secretanwser] NVARCHAR(MAX) NULL
)
