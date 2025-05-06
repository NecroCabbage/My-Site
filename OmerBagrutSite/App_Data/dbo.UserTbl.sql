CREATE TABLE [dbo].[UserTbl] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Username] NVARCHAR(30)  NOT NULL,
    [Password] NVARCHAR (50) NOT NULL,
    [Age]      INT           NOT NULL,
    [Gender] VARCHAR(10) NOT NULL, 
    [Email] NVARCHAR(30) NOT NULL, 
    [PhoneNumber] NVARCHAR(40) NOT NULL, 
    [City] NVARCHAR(20) NOT NULL, 
    [FirstName] VARCHAR(20) NOT NULL, 
    [LastName] VARCHAR(20) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

