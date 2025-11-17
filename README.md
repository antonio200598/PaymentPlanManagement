# PaymentPlanManagement API

API construída em .NET 6 (.NET 6.0) seguindo Clean Architecture para o desafio prático.

## Tecnologias
- .NET 6
- Entity Framework Core 6
- PostgreSQL (padrão) / SQL Server (opcional)

## Estrutura
- Domain
- Application
- Infrastructure
- WebApi

## ⚙️ Configuração e Execução Local

### 🧩 Pré-requisitos

Antes de executar o projeto, você precisará ter instalado:

- [SDK .NET 6+](https://dotnet.microsoft.com/download)
- Banco de dados: Postgres ou Sql Server
- Editor recomendado: [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)

### ▶️ Passos para execução

1. Clone este repositório:
   ```bash
   git clone https://github.com/antonio200598/PaymentPlanManagement.git
   cd PaymentPlanManagement/PaymentPlanManagement_API
2. Para Comunicação com o banco de dados, crie uma banco com o nome Kedu e coloque suas credenciais na classe [appsettings.Development.json](/PaymentPlanManagement_API/appsettings.Development.json).
3. Segue o link dos scripts das tabelas usadas: [Scripts](scripts).
4. Após tudo configurado, rode a aplicação.

### Observações:

1. Exemplo de possível configuração de credencial:

 `appsettings.Development.json`:

```json

"Database": { "Provider": "Postgres" },

"ConnectionStrings": {
  "DefaultConnection": "Host=;Port=;Database=;Username=;Password="
}

/* Caso use o SQL Server, descomente a linha abaixo e comente a linha acima
  
  "Database": { "Provider": "SqlServer" },

  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=;Trusted_Connection=True;TrustServerCertificate=True;
},
*/

```

2. Exemplos de requisições:

 1. POST /api/responsaveis — cria responsável

```json
{
  "name": "ana" //Nome do responsável
}

```

3. POST /api/planos-de-pagamento — cria plano com cobranças

```json
{
  "client_Id": 0, //id do responsavel
  "costsCentral_Id": 0, // Id do centro de custo. Caso não tenha, pode ser nulo ou 0
  "costsCentral_enum": "material", //nome do centro de custo
  "charges": [ //cobranças
    {
      "value": 0, //valor
      "dueDate": "2025-11-17T17:18:56.387Z", // Data de vencimento
      "paymentMethod": 1 // Boleto - 1, Pix - 2
    }
  ]
}


```

4. POST /api/cobrancas/{id}/pagamentos — registrar o pagamento da cobrança

No Aba de Params do postman ou insomnia preencha da seguinte forma:

| KEY          | VALUE               |
| ------------ | ------------------- |
| paymentValue | 50.75               |
| paymentDate  | 2025-11-17T10:00:00 |

e depois envie a requisição

