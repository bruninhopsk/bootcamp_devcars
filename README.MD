# Aplicação para gerenciamento de vendas de carros.

# Tecnologias e práticas utilizadas:
- ASP.NET Core com .NET 5
- Entity Framework Core
- Dapper
- Swagger
- Publicação na nuvem
- Injeção de Dependência

# Funcionalidades
- Cadastro, Listagem, Detalhes, Atualização e Remoção de Carros
- Cadastro e Detalhe de Venda de Carro, com items extras
- Cadastro de Cliente

# Rodando o projeto
- Para executar o projeto, tenha instalado o Entity Framework Core, Dapper e SQL Server. 
- Dentro do diretório /DevCars.Infrastructure rode o comando "dotnet ef migrations add <NomeMigration> para criar o esquema de dados com base no modelo de dominio.

PS: Caso possua outro banco de dados(relacional) que o EF dê suporte, pode mudar as configuraçõs para usa-lo, sendo necessário baixar o pacote do ef core com suporte ao DB desejado e alterando a string de conexão.
