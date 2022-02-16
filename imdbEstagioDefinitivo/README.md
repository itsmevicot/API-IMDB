?? O que fazer?
Voc� deve realizar um fork deste reposit�rio e, ao finalizar, enviar o link do fork em nosso reposit�rio para a nossa equipe. Lembre-se, N�O � necess�rio criar um Pull Request para isso, n�s iremos avaliar e retornar por e-mail o resultado do teste.

?? Requisitos
A API deve ser constru�da em .NET Core 6; 
Implementar autentica��o e dever� seguir o padr�o JWT, lembrando que o token a ser recebido dever� ser no formato Bearer;
Implementar opera��es no banco de dados utilizando um ORM ou Micro ORM
ORM's/Micro ORM's permitidos:
Entity Framework Core

Bancos de dados:
SQL Server 

As entidades da sua API dever�o ser criadas utilizando Code First. Portanto, as Migrations para gera��o das tabelas tamb�m dever�o ser enviadas no teste.
Sua API dever� seguir os padr�es REST na constru��o das rotas e retornos
Sua API dever� conter documenta��o viva utilizando Swagger

Testes unit�rios

?? Extra
Estes itens n�o s�o obrigat�rios, por�m desejados.

AspNet Identity (Controle e autentica��o de usu�rios);
Teste de integra��o da API em linguagem de sua prefer�ncia (damos import�ncia para pir�mide de testes);
Utiliza��o de Docker (enviar todos os arquivos e instru��es necess�rias para execu��o do projeto);

??????? Itens a serem avaliados
Estrutura do projeto;
Utiliza��o de c�digo limpo e princ�pios SOLID;
Seguran�a da API, como autentica��o, senhas salvas no banco, SQL Injection e outros;
Boas pr�ticas da Linguagem/Framework;
?? O que desenvolver?
Voc� dever� criar uma API que o site IMDb ir� consultar para exibir seu conte�do, sua API dever� conter as seguintes funcionalidades:

Administrador
Cadastro 
Edi��o
Exclus�o l�gica (desativa��o)
Listagem de usu�rios n�o administradores ativos
Op��o de trazer registros paginados
Retornar usu�rios por ordem alfab�tica
Usu�rio
Cadastro
Edi��o
Exclus�o l�gica (desativa��o)
Filmes
Cadastro (somente um usu�rio administrador poder� realizar esse cadastro)
Voto (a contagem de votos ser� feita por usu�rio de 0-4 que indica quanto o usu�rio gostou do filme)
Listagem
Op��o de filtros por diretor, nome, g�nero e/ou atores
Op��o de trazer registros paginados
Retornar a lista ordenada por filmes mais votados e por ordem alfab�tica
Detalhes do filme trazendo todas as informa��es sobre o filme, inclusive a m�dia dos votos
Obs.:

Apenas os usu�rios poder�o votar nos filmes e a API dever� validar quem � o usu�rio que est� acessando, ou seja, se � um usu�rio administrador ou n�o.