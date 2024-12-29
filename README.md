📚 Sistema de Gerenciamento de Pessoas e Endereços

📝 Descrição do Projeto

Aplicação desenvolvida em ASP.NET MVC com integração ao SQL Server utilizando Dapper para gerenciamento de pessoas e seus respectivos endereços. A aplicação permite realizar operações CRUD (Create, Read, Update, Delete) tanto para pessoas quanto para endereços, com suporte para consultas de CEP via API ViaCEP.

🚀 Funcionalidades

Gerenciamento de Pessoas: Cadastro, edição, listagem e exclusão de pessoas.

Gerenciamento de Endereços: Cadastro, edição, listagem e exclusão de endereços associados a uma pessoa.

Consulta CEP: Integração com a API ViaCEP para preenchimento automático de informações de endereço.

Interface Amigável: Modais para ações de cadastro e edição de endereços.

🛠️ Tecnologias Utilizadas

ASP.NET MVC

C#

SQL Server

Dapper

HTML5/CSS3

Bootstrap

JavaScript

⚙️ Configuração do Ambiente

Clone o repositório:

git clone https://github.com/seu-usuario/seu-repositorio.git

Configure a string de conexão no arquivo appsettings.json:

{
  "ConnectionStrings": {
    "ConexaoNuvem": "Server=SEU_SERVIDOR;Database=SEU_BANCO;Trusted_Connection=True;"
  }
}

Restaure os pacotes NuGet:

dotnet restore

Execute as migrações do banco de dados.

Inicie o projeto:

dotnet run

🧩 Endpoints Principais

/Pessoa/Listar → Lista todas as pessoas cadastradas.

/Pessoa/Editar/{id} → Edita informações de uma pessoa específica.

/Endereco/Cadastrar → Cadastra um novo endereço para uma pessoa.

/Endereco/Editar/{id} → Edita informações de um endereço específico.

💼 Autores

Eduardo Kauê Pereira Novais
