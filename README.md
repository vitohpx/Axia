# Axia Veiculos API

API para gerenciamento de veículos, implementada com **.NET 8**, MediatR e arquitetura CQRS (Commands, Queries e Handlers).

---

## Repositório
[GitHub - Axia Veiculo API](https://github.com/vitohpx/Axia.git)

---

## Como executar o projeto

### Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- IDE (Visual Studio 2022/2023, VS Code ou Rider)
- Navegador para acessar Swagger

### Passos
1. Clone o repositório:
   ```bash
   git clone https://github.com/vitohpx/Axia.git
   cd Axia

2. dotnet restore

3. dotnet run

4. Acessar a documentação e testar os endpoints via Swagger em:
https://localhost:7077/swagger/index.html


## Endpoints da API

![Swagger UI](docs/images/swagger.png)

## Exemplos de uso


### Swagger - Exemplo de POST 400

### Adição de item
![Adicionar item](docs/images/add.png)

```json
{
  "descricao": "teste descrição",
  "marca": 1,
  "modelo": "ka",
  "valor": 20000
}
```

### Adição negada
![Exemplo de erro em POST](docs/images/swagger-post-negativo.png)
![Adição recusada](docs/images/add-negado.png)

### Atualização de item
![Atualizar item](docs/images/update.png)
```json
{
  "id": "6e26a287-f19f-4771-8b7b-9d647854c73c",
  "descricao": "atualiza descricao e preco ",
  "marca": 1,
  "modelo": "ka",
  "valor": 18000
}
```

### Atualização negada
![Atualização recusada](docs/images/update-not.png)

### Validação de atualização
![Validação na atualização](docs/images/update-validation.png)

### Busca de itens
![Buscar itens](docs/images/get.png)

### Busca por ID
![Buscar item por ID](docs/images/get-id.png)

### Exclusão negada
![Exclusão recusada](docs/images/delete-not.png)

### Enumeração das Marcas
![Exemplo de enumeração](docs/images/enum.png)




Observações

Validações de entrada são feitas com FluentValidation.

Em caso de erro de validação, a API retorna HTTP 400 com mensagens detalhadas.

CQRS + MediatR garante separação de responsabilidades entre Commands e Queries.

A documentação e testes da API podem ser feitos diretamente pelo Swagger UI em https://localhost:7077/swagger/index.html
