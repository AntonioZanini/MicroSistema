CREATE SCHEMA usuario;

GO

CREATE TABLE usuario.Funcionalidade (
	CdFuncionalidade  int IDENTITY(1,1),
	Descricao         varchar(35)
);

ALTER TABLE usuario.Funcionalidade ADD CONSTRAINT PK_CdFuncionalidade PRIMARY KEY (CdFuncionalidade);

GO

CREATE TABLE usuario.NivelAcesso(
	CdNivelAcesso     int IDENTITY(1,1),
	Titulo            varchar(20)    NOT NULL
);

ALTER TABLE usuario.NivelAcesso ADD CONSTRAINT PK_CdNivelAcesso PRIMARY KEY (CdNivelAcesso);

GO

CREATE TABLE usuario.AcessoFuncionalidade (
	CdNivelAcesso     int            NOT NULL,
	CdFuncionalidade  int            NOT NULL
);

ALTER TABLE usuario.AcessoFuncionalidade ADD CONSTRAINT PK_AF_CdNivelAcesso_CdFuncionalidade PRIMARY KEY (CdNivelAcesso, CdFuncionalidade);
ALTER TABLE usuario.AcessoFuncionalidade ADD CONSTRAINT FK_AF_NA_CdNivelAcesso FOREIGN KEY (CdNivelAcesso) REFERENCES usuario.NivelAcesso(CdNivelAcesso);
ALTER TABLE usuario.AcessoFuncionalidade ADD CONSTRAINT FK_AF_FN_CdFuncionalidade FOREIGN KEY (CdFuncionalidade) REFERENCES usuario.Funcionalidade(CdFuncionalidade);

GO

CREATE TABLE usuario.Usuario (
	CdUsuario         int IDENTITY(1,1),
	Email             varchar(40)    NOT NULL,
	Nome              varchar(60)    NOT NULL,
	Senha             char(32)       NOT NULL,
	DataCadastro      date           NOT NULL,
	Ativo             bit            NOT NULL,
	CdNivelAcesso     int            NOT NULL
);

ALTER TABLE usuario.Usuario ADD CONSTRAINT PK_CdUsuario PRIMARY KEY (CdUsuario);
ALTER TABLE usuario.Usuario ADD CONSTRAINT AK_Usuario_Email UNIQUE (Email);
ALTER TABLE usuario.Usuario ADD CONSTRAINT DF_DataCadatro DEFAULT GETDATE() FOR [DataCadastro];
ALTER TABLE usuario.Usuario ADD CONSTRAINT DF_Ativo DEFAULT 1 FOR [Ativo];
ALTER TABLE usuario.Usuario ADD CONSTRAINT FK_US_NA_CdNivelAcesso FOREIGN KEY (CdNivelAcesso) REFERENCES usuario.NivelAcesso(CdNivelAcesso);

GO

CREATE INDEX IDX_Usuario_Email ON usuario.Usuario(Email);

GO
