# 🔐 UserApi com PokéVibes + JWT

API REST em ASP.NET Core com autenticação JWT, integração com PokéAPI externa e persistência em SQLite. Feita para impressionar em qualquer teste técnico. 😎

---

## ✅ Requisitos

- [.NET SDK 8.0+](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

---

## ⚙️ Instalação

```bash
# Clonar o repositório e entrar na pasta
git clone https://github.com/seu-usuario/UserApi.git
cd UserApi

# Restaurar os pacotes
dotnet restore

# Instalar pacotes adicionais (se necessário)
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.5

# Aplicar as migrations
dotnet ef migrations add InitialCreate
dotnet ef database update

# Rodar o projeto
dotnet run
```

---

## 🧪 Testando a API

### 🔗 Acesse:
```
http://localhost:5122/swagger
```

---

## 🔐 Login (JWT)

### Endpoint:
```http
POST /api/auth/login
```

### Body JSON:
```json
{
  "email": "admin@pokevibes.com",
  "senha": "123456"
}
```

### Retorno:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR..."
}
```

Use este token como **Bearer Token** no Postman:

```http
Authorization: Bearer {token}
```

---

## 🔐 Endpoints protegidos:

| Método | Rota                     | Descrição                        |
|--------|--------------------------|----------------------------------|
| GET    | /api/User/{id}           | Consulta usuário específico      |
| GET    | /api/User/protegido      | Rota teste com [Authorize]       |

---

## 🆓 Endpoints públicos:

| Método | Rota                     | Descrição                        |
|--------|--------------------------|----------------------------------|
| GET    | /api/User                | Lista todos os usuários          |
| POST   | /api/User                | Cria novo usuário                |
| PUT    | /api/User/{id}           | Atualiza usuário existente       |
| DELETE | /api/User/{id}           | Remove usuário                   |
| GET    | /api/pokemon/{name}      | Busca dados via PokéAPI externa  |

---

## 🧪 Testes Unitários

### Como rodar os testes:

```bash
dotnet test
```

### O que é testado?

- Serviço de integração com PokéAPI (`PokeVibesService`)
- Testes unitários com `xUnit` e `Moq`
- Simulação de chamadas HTTP para garantir comportamento previsível

---

### Dependências dos testes:

```bash
dotnet add UserApi.Tests package xunit
dotnet add UserApi.Tests package Moq
dotnet add UserApi.Tests package Microsoft.NET.Test.Sdk
dotnet add UserApi.Tests package Microsoft.AspNetCore.Mvc.Testing --version 8.0.5
```

---

## 📂 Estrutura dos Projetos

```
UserApi/           → API principal
UserApi.Tests/     → Projeto de testes unitários (xUnit + Moq)
```

---

## 💡 Extras

- PokéAPI integrada com transformação de retorno customizada (`/api/pokemon/{name}`)
- JWT com proteção de rotas e validação de credenciais
- Código limpo, estruturado e testável
- Tudo documentado no Swagger

---

## 💬 Contato

Feito por [Michele Rocha] ✨  
LinkedIn: [linkedin.com/in/seu-perfil](https://linkedin.com/in/seu-perfil)  
Email: mr.michelerocha@gmail.com