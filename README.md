# DG Bar

Sistema de compra de produtos.

# Front-End

O Front-end foi desenvolvido em React com TypeScript, tem um layout responsivo bem simples utilizando o Material UI. Como padrão no código foi definido a porta 3000 para acesso.

# BackEnd

## Arquitetura

O Back-End é uma Web API desenvolvida em .NET Core, foi feito utilizando o padrão DDD, como é um sistema que pode ser ampliado e é baseado em domínios, foi escolhida essa arquitetura.
Em cada camada desse padrão é feito com injeção de dependências utilizando a biblioteca Autofac.

## API

Foi utilizado Swagger para realização de testes e validações podendo ser aberto por [http://localhost:3333/swagger/index.html](http://localhost:3333/swagger/index.html)

![Chamadas API](https://i.imgur.com/ZJyDcC6.png)

## Autenticação

O sistema ainda não tem funcionalidade de login e criação de usuários, por isso foi feito uma autenticação simples por JWT, a tela inicial da aplicação mostra um botão de autenticar simulando o login, enquanto não for autenticado não consegue navegar pela aplicação nem utilizar as chamadas API.

![Autenticação](https://i.imgur.com/UTXcEvX.jpg)

## Base de Dados

Foi utilizado uma base SQLite local, ela utiliza a ORM Entity Framework Core e para criação do banco foi utilizada Migrations. Ao roda-las é criado o banco, as tabelas e é populado inicialmente a tabela produtos (para a criação de novos produtos é necessário utilizar o Swagger).

## Resiliência

Para resiliência foi criado um limite de acessos, esses são parametrizáveis no appsettings.json, e estão com limite de 3 requisições de diferentes IPs a cada 5 segundos.

## Utilização

Pela parte Web é possível vincular produtos a ordens utilizando o número da comanda (para criar uma comanda nova é necessário utilizar o Swagger).

![enter image description here](https://i.imgur.com/JpVVucb.jpg)

Após vincular os produtos necessários basta ir para a seção de finalizar a ordem utilizando o Menu e colocar o número da comanda, ao clicar no botão Visualizar NF é mostrado os produtos vinculados junto com os totais, podendo assim Resetar essa comanda ou Finaliza-la.

![Comanda](https://i.imgur.com/bnYSt46.jpg)

## Testes

Foram feitos testes utilizando o xUnit e Fluent Assertions para garantir a qualidade da aplicação
![Testes](https://i.imgur.com/IHL5loz.jpg)

# Pontos para evolução

Alguns pontos de melhoria que levantados durante o desenvolvimento

- Login e Criação de usuários;
- Página de cadastro de produtos;
- Permitir upload de imagem no momento do cadastro de produto;
- Página para cadastro de limite de cada produto por pedido;
- Página para cadastro de descontos;
- Ao iniciar um novo pedido, criar uma ordem automaticamente;
- Melhoria de Layout no Front-End;
- Testes unitários de Front-End;
- Coverage Test no Back-End.
