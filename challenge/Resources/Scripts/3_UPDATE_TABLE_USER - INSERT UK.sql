USE [NessHealthChallenge]
GO

ALTER TABLE [dbo].[User]  
ADD CONSTRAINT UK_Name UNIQUE (name);
GO  

ALTER TABLE [dbo].[User]  
ADD CONSTRAINT UK_CPF UNIQUE (cpf);
GO  