SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
GO
IF (NOT EXISTS ( SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Entries'))
BEGIN

	CREATE TABLE dbo.Entries(
		Id BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
		Name NVARCHAR(100) NOT NULL,
		PhoneNumber NVARCHAR(50) NOT NULL,
		DateCreated DateTime  NOT NULL,
		DateModified DateTime NULL,
	)

CREATE  UNIQUE INDEX IXU_Name_PhoneNumber ON dbo.Entries (Name,PhoneNumber)

INSERT INTO dbo.Entries(Name,PhoneNumber,DateCreated,DateModified)
VALUES	('Donald Asante','0860037566',GETDATE(),GETDATE()),
		('Michael Asante','0820776910',GETDATE(),GETDATE()),
		('Ama Akyeampong','0128110069',GETDATE(),GETDATE()),
		('Donald Asante','0118864227',GETDATE(),GETDATE()),
		('Eddie Nketiah','0233423390',GETDATE(),GETDATE()),
		('Donald Asante','0117868101',GETDATE(),GETDATE()),
		('Michael Asante','0219488412',GETDATE(),GETDATE()),
		('Ama Akyeampong','0828044026',GETDATE(),GETDATE()),
		('Donald Asante','0119545972',GETDATE(),GETDATE()),
		('Michael Asante','0218418300',GETDATE(),GETDATE()),
		('Matt Nketiah','0114256578',GETDATE(),GETDATE()),
		('Eddie Nketiah','0114755934',GETDATE(),GETDATE()),
		('Michael Asante','0216745710',GETDATE(),GETDATE()),
		('Ama Akyeampong','0117086660',GETDATE(),GETDATE()),
		('Ama Akyeampong','0114064000',GETDATE(),GETDATE()),
		('Super Man','0861000374',GETDATE(),GETDATE()),
		('Marco Polo','0118234181',GETDATE(),GETDATE()),
		('Donald Asante','0115468790',GETDATE(),GETDATE()),
		('Donald Asante','0117044324',GETDATE(),GETDATE()),
		('Ama Akyeampong','0219055028',GETDATE(),GETDATE()),
		('Michael Asante','0233421732',GETDATE(),GETDATE()),
		('Ama Akyeampong','0115526000',GETDATE(),GETDATE()),
		('Shaun Michaels','0832835399',GETDATE(),GETDATE()),
		('Michael Asante','0120040218',GETDATE(),GETDATE())
END
