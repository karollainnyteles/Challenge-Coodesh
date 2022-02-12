<h1 align="center">  Coodesh Challenge Api </h1>

<p align="center">
 <a href="#-sobre-o-projeto">Sobre</a> •
 <a href="#%EF%B8%8F-funcionalidades">Funcionalidades</a> •
 <a href="#-como-executar-o-projeto">Como executar</a> • 
 <a href="#-tecnologias">Tecnologias</a> • 
 <a href="#-recursos-utilizados">Recursos utilizados</a> • 
</p>


## 💻 Sobre o projeto


>  This is a challenge by [Coodesh](https://coodesh.com/)

>  Acesse a apresentação do [projeto](https://www.loom.com/share/8610efa74ac646e69369582b7f39627d)


Essa Api utiliza os dados do projeto [Space Flight News](https://api.spaceflightnewsapi.net/v3/documentation), realizando sincronização diária e permitindo gerenciamento dos dados.


## ⚙️ Funcionalidades

- [x] Articles
  - [x] Cadastro 
  - [x] Listagem paginada
  - [x] Busca por id
  - [x] Edição
  - [x] Remoção
- [x] Sincronização diária com os dados da [Space Flight News](https://api.spaceflightnewsapi.net/v3/documentation)



## 🚀 Como executar o projeto


### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Git](https://git-scm.com) e [docker](https://www.docker.com/) 


#### 🧭 Executanto a aplicação

```bash

# Clone este repositório
$ git clone https://github.com/karollainnyteles/Challenge-Coodesh.git

# Acesso a pasta docker
$ cd Challenge-Coodesh/docker

# Execute a aplicação utilizando docker compose
$ docker-compose up -d


# A aplicação será aberta na porta:5005 - acesse http://localhost:5005/swagger/index.html

```

## 🛠 Tecnologias

As seguintes ferramentes foram usadas na construção do projeto:


### **WebApi** ([dotnet 5](https://dotnet.microsoft.com/en-us/download/dotnet/5.0) + [docker](https://www.docker.com/) + [mysql](https://www.mysql.com/) )


## 📌 Recursos utilizados
 
- Injeção de Dependência
- Entity Framework Core
- Migrations
- MediatR
- Padrão CQRS
- Acesso ao banco de dados via Repositórios
- Mapeamento de entidades com Automapper
- Validação de utilizando fluent validation
- Tratamento de erros
- Documentação com o Swagger
- Hosted Service

