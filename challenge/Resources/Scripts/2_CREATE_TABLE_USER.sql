USE [NessHealthChallenge]
GO

CREATE TABLE [dbo].[User](
    [id] [int] IDENTITY(1,1) NOT NULL,
    [name] [varchar](100) DEFAULT '' NOT NULL,
    [cpf] [varchar](11) DEFAULT '' NOT NULL,
    [phoneNumber] [varchar](20)  NOT NULL,
PRIMARY KEY ([id])
    )
GO