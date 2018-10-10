# MicroSistema
Um pequeno sistema com funcionalidades básicas.

## Especificações

O projeto tem por objetivo estudo e demonstração de capacidades curriculares, sendo este um sistema de tamanho mínimo para explorar conceitos e técnicas de programação. Neste mesmo documento será documentado o progresso periódico do sistema, segmentado por telas e classificado pelo dia.

## Tela de Login 

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
