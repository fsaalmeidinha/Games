CREATE TABLE archeryUsuario
(
	Id INT CONSTRAINT PK_archeryUsuario_Id PRIMARY KEY IDENTITY(1,1), 
	Nome NVARCHAR(100) NOT NULL,
	Email NVARCHAR(100) NOT NULL CONSTRAINT UQ_archeryUsuario_Email UNIQUE (Email),
	PontuacaoMaximaJogo INT NOT NULL,
	PontuacaoTotal INT NOT NULL
);

GO
CREATE NONCLUSTERED INDEX [Index_archeryUsuario_Email]
ON [dbo].[archeryUsuario] ([Email])

GO
CREATE TABLE archeryStatusJogo
(
	Id INT CONSTRAINT PK_archeryStatusJogo_Id PRIMARY KEY IDENTITY(1,1),
	Email NVARCHAR(100) NOT NULL CONSTRAINT UQ_archeryStatusJogo_Email UNIQUE (Email),
	Pontuacao INT NOT NULL,
	Flechas INT NOT NULL,
	Nivel INT NOT NULL
);

GO
CREATE NONCLUSTERED INDEX [Index_archeryStatusJogo_Email]
ON [dbo].[archeryStatusJogo] ([Email])

GO
CREATE TABLE tblLog (
	Id INT CONSTRAINT PK_Log_Id PRIMARY KEY IDENTITY(1,1), 
	DataAcao DATETIME NOT NULL,
	Acao NVARCHAR(255) NOT NULL,
	Mensagem TEXT NOT NULL
);