CREATE TABLE [dbo].[usertable] (
    [Id]              INT        NOT NULL,
    [username]        NCHAR (10) NULL,
    [password]        NCHAR (10) NULL,
    [confirmpassword] NCHAR (10) NULL,
    [email]           NCHAR (30) NULL,
    [secretquestion]  NCHAR (30) NULL,
    [secretanwser]    NCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

