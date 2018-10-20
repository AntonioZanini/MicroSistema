CREATE SCHEMA logistica;

CREATE TABLE logistica.Fornecedor (
	CdFornecedor        int IDENTITY(1,1),
	RazaoSocial         varchar(100) NOT NULL,
    CNPJ                char() NOT NULL,
    AreaComercio        varchar(35) NOT NULL
);

ALTER TABLE logistica.Fornecedor ADD CONSTRAINT PK_CdFornecedor PRIMARY KEY (CdFornecedor);

CREATE TABLE logistica.PlanoPagamento
(
	CdPlano             int IDENTITY(1,1),
	CdFornecedor        int NOT NULL,
	Descricao           varchar(35) NOT NULL
);

ALTER TABLE logistica.PlanoPagamento ADD CONSTRAINT PK_PP_CdPlano_CdFornecedor PRIMARY KEY (CdPlano, CdFornecedor);
ALTER TABLE logistica.PlanoPagamento ADD CONSTRAINT FK_PP_FN_CdFornecedor FOREIGN KEY (CdFornecedor) REFERENCES logistica.Fornecedor(CdFornecedor);

CREATE TABLE logistica.EnderecoFornecedor (
	CdEndereco          int IDENTITY(1,1),
	CdFornecedor        int NOT NULL,
	Rua                 varchar(150) NOT NULL,
	Numero              varchar(8) NOT NULL,
	Complemento         varchar(12),
	Bairro              varchar(25) NOT NULL,
	Cidade              varchar(25) NOT NULL,
	UF                  char(2) NOT NULL
);

ALTER TABLE logistica.EnderecoFornecedor ADD CONSTRAINT PK_EF_CdEndereco_CdFornecedor PRIMARY KEY (CdEndereco, CdFornecedor);
ALTER TABLE logistica.EnderecoFornecedor ADD CONSTRAINT FK_EF_FN_CdFornecedor FOREIGN KEY (CdFornecedor) REFERENCES logistica.Fornecedor(CdFornecedor);

CREATE TABLE logistica.Contato (
	CdContato           int IDENTITY(1,1),
	CdFornecedor        int NOT NULL,
	Nome                varchar(60) NOT NULL,
	Funcao              varchar(40),
	Email               varchar(60),
	Observacoes         varchar(80)
);

ALTER TABLE logistica.Contato ADD CONSTRAINT PK_CT_CdContato_CdFornecedor PRIMARY KEY (CdContato, CdFornecedor);
ALTER TABLE logistica.Contato ADD CONSTRAINT FK_CT_FN_CdFornecedor FOREIGN KEY (CdFornecedor) REFERENCES logistica.Fornecedor(CdFornecedor);

CREATE TABLE logistica.Telefone (
	CdTelefone          int IDENTITY(1,1),
	CdContato           int NOT NULL,
	Numero              varchar(12) NOT NULL,
	Complemento         varchar(15)
);

ALTER TABLE logistica.Telefone ADD CONSTRAINT PK_TL_CdTelefone_CdContato PRIMARY KEY (CdTelefone, CdContato);
ALTER TABLE logistica.Telefone ADD CONSTRAINT FK_TL_CT_CdContato FOREIGN KEY (CdContato) REFERENCES logistica.Contato(CdContato);

CREATE TABLE logistica.Material (
	CdMaterial          int IDENTITY(1,1),
	Descricao           varchar(25) NOT NULL,
	Categoria           varchar(20) NOT NULL,
);

ALTER TABLE logistica.Material ADD CONSTRAINT PK_CdMaterial PRIMARY KEY (CdMaterial);

CREATE TABLE logistica.Embalagem (
	CdEmbalagem         int IDENTITY(1, 1),
	CdMaterial          int NOT NULL,
	QtdUnidades         int NOT NULL,
	Volume              decimal(3,3) NOT NULL,
	Peso                decimal(5,3) NOT NULL
);

ALTER TABLE logistica.Embalagem ADD CONSTRAINT PK_EM_CdEmbalagem_CdMaterial PRIMARY KEY (CdEmbalagem, CdMaterial);
ALTER TABLE logistica.Embalagem ADD CONSTRAINT FK_EM_MT_CdMaterial FOREIGN KEY (CdMaterial) REFERENCES logistica.Material(CdMaterial);

CREATE TABLE logistica.MovimentacaoMaterial(
	CdMovimentacao      int IDENTITY(1, 1),
	CdEmbalagem         int NOT NULL,
	DataMovimentacao    date NOT NULL,
    Quantidade          int NOT NULL,
    Operação            bit NOT NULL,
    Descricao           varchar(20) NOT NULL,
    Armazenamento       varchar(20) NOT NULL,
    OrigemDestino       varchar(20) NOT NULL
)

ALTER TABLE logistica.MovimentacaoMaterial ADD CONSTRAINT PK_MM_CdMovimentacao_CdEmbalagem PRIMARY KEY (CdMovimentacao, CdEmbalagem);
ALTER TABLE logistica.MovimentacaoMaterial ADD CONSTRAINT DF_Data DEFAULT GETDATE() FOR [DataMovimentacao];
