# SampleApp.ApiService

## Visão Geral

API para consulta de previsões meteorológicas, construída com .NET 10, Entity Framework Core e SQLite. Permite listar todas as previsões ou consultar por data específica. O projeto está preparado para integração com aplicações Blazor.

---

## Como Executar

1. **Restaurar dependências**
2. **Aplicar migrations e criar o banco**
3. **Executar o projeto**

---

## Endpoints

### Listar todas as previsões

- **GET** `/weatherforecast`
- **Descrição:** Retorna todas as previsões meteorológicas cadastradas.
- **Resposta:**

# Response

```json
{
  "date": "2023-10-05",
  "temperatureC": 25,
  "temperatureF": 77,
  "summary": "Sunny"
}
```

### Buscar previsão por data

- **GET** `/`
- **Parâmetro:** `date` (formato YYYY-MM-DD)
- **Exemplo:** `/?date=2024-06-01`
- **Resposta:**

# Response
```
{"date":"2024-06-01","temperatureC":30,"temperatureF":86,"summary":"Hot"}
```

---

## Estrutura do Objeto

| Campo         | Tipo     | Descrição                |
|---------------|----------|--------------------------|
| date          | DateOnly | Data da previsão         |
| temperatureC  | int      | Temperatura em Celsius   |
| summary       | string   | Resumo do clima          |

---

## Exemplos de Uso

### Listar todas as previsões

---

## Observações

- Todos os endpoints retornam dados em JSON.
- Em caso de erro interno, o endpoint retorna status 500 e mensagem padrão.
- Para buscar por data, utilize o formato `YYYY-MM-DD`.
- O projeto está pronto para ser consumido por aplicações Blazor.

---

## Licença

Este projeto é distribuído sob a licença MIT.