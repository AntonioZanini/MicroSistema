USE MICROSISTEMA;

INSERT INTO usuario.Funcionalidade (Descricao) 
VALUES ('Cadastro de Usuários'), 
       ('Cadastro de Produtos'),
       ('Exclusão de Produtos');

INSERT INTO usuario.NivelAcesso (Titulo)
VALUES ('Administrador'),
       ('Operador');

INSERT INTO usuario.AcessoFuncionalidade 
VALUES (1, 1),
       (1, 2),
       (1, 3),
       (2, 2);

INSERT INTO usuario.Usuario (Email, Nome, Senha, CdNivelAcesso)
VALUES ('valdirsrios@empresa.com.br', 'Valdir Silveira Rios', 
	    '10CA25278C7CD10AA375D98EFAD44FBA', 1);