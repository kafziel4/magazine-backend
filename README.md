# Magazine Hashtag Backend

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Vite](https://img.shields.io/badge/Vite-B73BFE?style=for-the-badge&logo=vite&logoColor=FFD62E)
![HTML](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white)
![Tailwind](https://img.shields.io/badge/Tailwind_CSS-38B2AC?style=for-the-badge&logo=tailwind-css&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-323330?style=for-the-badge&logo=javascript&logoColor=F7DF1E)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white)
![Redis](https://img.shields.io/badge/redis-%23DD0031.svg?&style=for-the-badge&logo=redis&logoColor=white)
![MongoDB](https://img.shields.io/badge/MongoDB-4EA94B?style=for-the-badge&logo=mongodb&logoColor=white)
![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)

## Descrição

Dos dias 28/08/23 a 01/09/23 ocorreu o Intensivão de JavaScript da escola [Hashtag](https://www.hashtagtreinamentos.com/). O objetivo foi construir o frontend de um e-commerce, ele usa Vite e Tailwind para facilitar o desenvolvimento, mas fora isso é HTML e JavaScript vanilla. Um amigo que havia me chamado para participar e me propôs de tentar criar um backend para o projeto e este foi o resultado.

Criei um projeto de microsserviços com 4 componentes:

- CatalogAPI: fornece os dados de produtos, usa banco de dados PostgreSQL.
- CartAPI: manipula os dados do carrinho do usuário, usa banco de dados Redis (inspirado no eShopOnContainers da Microsoft).
- OrderAPI: manipula os dados dos pedidos, usa banco de dados MongoDB.
- APIGateway: um API Gateway com Ocelot para facilitar o consumo das APIs pelo frontend.

Todos os componentes, incluindo o frontend, foram conteinerizados com Docker.

### Fluxo de venda

```mermaid
sequenceDiagram
  participant Usuário
  participant Frontend
  participant CatalogAPI
  participant CartAPI
  participant OrderAPI
  Usuário->>Frontend: Accessa homepage
  Frontend->>CatalogAPI: GET /products
  CatalogAPI-->>Frontend: 
  Frontend->>CartAPI: GET /cart/{customerId}
  CartAPI-->>Frontend: 
  Frontend-->>Usuário: 
  Usuário->>Frontend: Adiciona produto ao carrinho
  Frontend->>CartAPI: POST /cart
  CartAPI->>CatalogAPI: GET /product/{id}
  CatalogAPI-->>CartAPI: 
  CartAPI-->>Frontend: 
  Frontend-->>Usuário: 
  Usuário->>Frontend: Solicita o checkout
  Frontend->>CartAPI: GET /cart/{customerId} 
  CartAPI-->>Frontend: 
  Frontend-->>Usuário: 
  Usuário->>Frontend: Finaliza compra
  Frontend->>OrderAPI: POST /orders
  OrderAPI->>CartAPI: GET /cart/{customerId}
  CartAPI-->>OrderAPI: 
  OrderAPI-->>Frontend: 
  Frontend->>CartAPI: DELETE /cart/{customerId}
  CartAPI-->>Frontend: 
  Frontend->>OrderAPI: GET /orders/{customerId}
  OrderAPI-->>Frontend: 
  Frontend-->>Usuário: 
```

## Execução

Com Docker instalado, para rodar o projeto é só executar o comando `docker compose up` na pasta raiz. O projeto está configurado da seguinte forma:

- Frontend disponível na porta 4173.
- CatalogAPI disponível na porta 7183.
- CartAPI disponível na porta 7218.
- OrderAPI disponível na porta 7186.
- APIGateway disponível na porta 7198.
- PostgreSQL disponível na porta 5432.
- pgAdmin disponível na porta 8080, usuário: <me@example.com>, senha: 1234567.
- Redis disponível na porta 6379.
- Redis Commander disponível na porta 8081.
- MongoDB disponível na porta 27017.
- Mongo Express disponível na porta 8082.

Também é possível rodar o projeto em modo desenvolvimento, por exemplo:

- Com Node.js instalado, executar o comando `npm run dev` na pasta `frontend` para rodar o projeto frontend.
- Rodar os projetos da solução backend através do Visual Studio.

## Limitações

O projeto assume que há um usuário logado interagindo, como não há um sistema de login, um valor que é utilizado como id do usuário é adicionado ao código JavaScript do frontend.

- Executando em modo de desenvolvimento, o valor é passado através da variável `VITE_CUSTOMER_ID` no arquivo `.env`.
- Executando através do docker compose, o valor é passado através do argumento de build `CUSTOMER_ID`.

O projeto não contempla o formulário de checkout com os dados do usuário, pagamento e entrega.

## Imagens

- Homepage
![homepage](docs/images/homepage.png)
- Swagger CatalogAPI
![catalog-api](docs/images/catalog-api.png)
- Banco de dados PostgreSQL
![postgres](docs/images/postgres.png)
- Carrinho
![carrinho](docs/images/carrinho.png)
- Swagger CartAPI
![cart-api](docs/images/cart-api.png)
- Banco de dados Redis
![redis](docs/images/redis.png)
- Checkout
![checkout](docs/images/checkout.png)
- Pedidos
![pedidos](docs/images/pedidos.png)
- Swagger OrderAPI
![order-api](docs/images/order-api.png)
- Banco de dados MongoDB
![mongo](docs/images/mongo.png)
- Contêineres Docker
![docker](docs/images/docker.png)

## Referências

[.NET](https://dotnet.microsoft.com/pt-br/)  
[Node.js](https://nodejs.org/en)  
[Vite](https://vitejs.dev/)  
[Tailwind](https://tailwindcss.com/)  
[PostgreSQL](https://www.postgresql.org/)  
[pgAdmin](https://www.pgadmin.org/)  
[Redis](https://redis.io/)  
[Redis Commander](https://joeferner.github.io/redis-commander/)  
[MongoDB](https://www.mongodb.com/pt-br)  
[Mongo Express](https://github.com/mongo-express/mongo-express)  
[Ocelot](https://github.com/ThreeMammals/Ocelot)  
[Docker](https://www.docker.com/)  
[FluentValidation](https://github.com/FluentValidation/FluentValidation)  
[Axios](https://axios-http.com/)  
[eShopOnContainers](https://github.com/dotnet-architecture/eShopOnContainers)  
