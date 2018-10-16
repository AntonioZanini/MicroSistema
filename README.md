# MicroSistema
Um pequeno sistema com funcionalidades básicas.

## Especificações

O projeto tem por objetivo estudo e demonstração de capacidades curriculares, sendo este um sistema de tamanho mínimo para explorar conceitos e técnicas de programação. Neste mesmo documento será documentado o progresso periódico do sistema, segmentado por telas e classificado pelo dia.

## Índice

- [Tela de Login](#tela-de-login).
- [Tela do Menu Principal](#tela-do-menu-principal).
- [Tela de Gerenciamento de Usuários](#tela-de-gerenciamento-de-usu%C3%A1rios).
- [Tela de Adicionar e Alterar Usuários](#tela-de-adicionar-e-alterar-usu%C3%A1rios).
- [Tela de Alteração de Senha](#tela-de-altera%C3%A7%C3%A3o-de-senha).
- [Tela de Mensagem de Suporte](#tela-de-mensagem-de-suporte).
- [Banco de Dados](#banco-de-dados).

## Tela de Login 

### 7º Dia - 16/10/2018

![image](https://user-images.githubusercontent.com/9437498/47047829-1fce7800-d16f-11e8-815b-e777acc28d45.png)

Versão final da tela de entrada no sistema.

### 3º Dia - 08/10/2018

![image](https://user-images.githubusercontent.com/9437498/46628313-84f0f080-cb13-11e8-896d-2ba0f292a2e1.png)

Tela de entrada no sistema através da confimação das credenciais do usuário.

A tela possui funcionalidade parcial, juntamente com a classe ContaUsuario ela executa uma verificação de senha, entretanto, esta verificação é limitada dado ao acesso ainda não implementado ao banco de dados.

Nas questões visuais, há pleno espaço para aperfeiçoamento. 
- Criei um botão redondo, mas pequenas falhas acontecem dependendo do modo de utilização;
- Frames foram utilizados como auxiliares visuais das caixas de texto, concedendo uma ilusão de unidade juntamente com efeitos de enchimento e cantos arredondados;
- Fonte alterada para ter uma tipografia mais agradável;
- Foto adicionada para ilustrar a tela e torná-la mais amigável;

A classe ContaUsuario possui forte ligação com a tela de login, portanto é necessário seu funcionamento adequado para que a tela possa ter todas as suas características funcionando.

## Tela do Menu Principal

### 7º Dia - 16/10/2018

![image](https://user-images.githubusercontent.com/9437498/47048633-5d340500-d171-11e8-9119-299fb8ebed2a.png)
![image](https://user-images.githubusercontent.com/9437498/47049164-edbf1500-d172-11e8-81a2-49d5bb56df10.png)
![image](https://user-images.githubusercontent.com/9437498/47049194-00d1e500-d173-11e8-98a4-fffb3fb7b682.png)

Esta é uma tela simples, exibindo apenas os menus que serão utilizados no projeto. Ao final do projeto, em meio a adições finais, é possível que sejam incluidas novas opções.

## Tela de Gerenciamento de Usuários

### 7º Dia - 16/10/2018

![image](https://user-images.githubusercontent.com/9437498/47049352-67570300-d173-11e8-9440-0caad526cceb.png)

Esta é primeira versão da funcional da tela de gerenciamento de usuários, ela possui as seguintes funcionalidades:
- Grid com dados dos usuários;
- Filtro por nível de acesso, selecionado através de uma caixa de seleção;
- Chamada da tela de adição de usuários;
- Chamada da tela de alteração de usuários para o usuário selecionado no grid;
- Execução de exclusão de usuários selecionados;
- Chamada da tela de troca de senhas para o usuário selecionado no grid;

## Tela de Adicionar e Alterar Usuários

### 7º Dia - 16/10/2018

(Adicionar usuários)

![image](https://user-images.githubusercontent.com/9437498/47049904-00d2e480-d175-11e8-8571-2e7f68d7b53e.png)

(Alterar usuários)

![image](https://user-images.githubusercontent.com/9437498/47050067-7e96f000-d175-11e8-9b3a-bfb15e852623.png)

Esta tela cumpre função dupla, ao realizar os procedimentos de inclusão e modificação de usuários. Este comportamento é definido já no construtor da classe que é chamado pelo respectivo botão.

**Tela de Adicionar Usuários**
- Possui as entradas para E-mail (que efetivamente é o identificador da conta), Nome e Nível de Acesso (selecionado em uma caixa de seleção);
- O campo da senha recebe uma senha temporária gerada para o primeiro acesso de um usuário;
- Os outros campos recebem valores padrões;
- A gravação só é realizada se tanto o E-mail quanto a Senha seguirem as regras definidas:
- E-mail:
  - Não pode ter espaços em branco;
  - Deve pertencer a um dos domínios definidos;
- Senha:
  - Deve ter ao menos 6 caracteres;
  - Deve possuir ao menos um de cada entre: caracteres minúsculos, maiúsculos, números e simbolos;

**Tela de Alterar Usuários**
- Carrega os dados do usuário, permitindo a edição dos valores de Nome, E-mail, Nível de Acesso e Usuário Ativo;
- Pela natureza sigilosa da senha, ela não é exibida, e precisa ser chamada a tela específica para que possa ser alterada. Isso pode ser feito através do botão Reatribuir Senha;
- A gravação é realizada apenas se o novo valor de E-mail estiver de acordo com as regras definidas;

## Tela de Alteração de Senha
### 7º Dia - 16/10/2018

![image](https://user-images.githubusercontent.com/9437498/47051091-2c57ce00-d179-11e8-8b8b-15e41445c65b.png)

Esta tela é chamada em múltiplas oportunidades, ela executa a troca validada da senha do usuário.
- Logo após a entrada no sistema, caso o usuário utilize uma senha temporária, o menu principal utiliza esta tela para obrigar o usuário a definir uma nova senha;
- Na tela de gerenciamento de usuários, esta tela pode ser chamada para alterar a senha do usuário selecionado no grid;
- Na tela de alteração de usuários, esta tela pode ser chamada para alterar a senha do usuário sendo modificado;

## Tela de Mensagem de Suporte
### 3º Dia - 08/10/2018
![image](https://user-images.githubusercontent.com/9437498/46632575-832e2980-cb21-11e8-8218-ba4f88e09595.png)

Tela que possui a função de exibir mensagens informativas e de suporte de um modo mais suave e amigável.

Ela realiza uma transição suave "_fade in_" e fade "_fade out_", desse modo não causa uma interrupção tão abrupta no _**workflow**_ quanto uma caixa de mensagem. O texto de suas mensagens, posição e tamanho são passados por parâmetro do construtor, geralmente a posição enviada é relativa ao botão ou objeto que chama a execução da tela.
- O aparecimento gradual é ativado sempre que a tela é executada;
- O desaparecimento gradual é ativado sempre que a tela perde as coordenadas do mouse;
- Após o desaparecimento total da tela, a mesma é fechada;
- A tela possui a exibição de um ícone, provisoriamente um ícone de informação do sistema operacional;

![image](https://user-images.githubusercontent.com/9437498/46632485-2fbbdb80-cb21-11e8-8a3f-de52b777b7a1.png)

A tela em tempo de execução recebendo uma mensagem da tela de login para informá-la ao usuário.

## Banco de Dados
### 4º Dia - 09/10/2018
![image](https://user-images.githubusercontent.com/9437498/46707690-70931d80-cc11-11e8-9d24-1ab188362262.png)

Banco de dados, criado no MS SQLServer, parcialmente construído, o seguinte segmento corresponde ao conjunto de itens necessários para as funcionalidades de login.

Ainda faltam as tabelas principais do programa e possíveis rotinas e funções implementadas no banco de dados.
