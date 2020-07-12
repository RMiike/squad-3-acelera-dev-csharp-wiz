
 <p align="center">

 [![Build Status](https://travis-ci.com/RMiike/newrepo.svg?branch=master)](https://travis-ci.com/RMiike/newrepo)
 
 [![codecov](https://codecov.io/gh/RMiike/newrepo/branch/master/graph/badge.svg)](https://codecov.io/gh/RMiike/newrepo)
 </p>
# squad-3-acelera-dev-csharp-wiz

<h1 align="center">Projeto final - Acelera Dev</h1>


<h2 align="center">Central de Erros</h2>

:question: Objetivo

<p>Em projetos modernos é cada vez mais comum o uso de arquiteturas baseadas em serviços ou microsserviços. </br>
Nestes ambientes complexos, erros podem surgir em diferentes camadas da aplicação (backend, frontend, mobile, desktop) e mesmo em serviços distintos. </br> Desta forma, é muito importante que os desenvolvedores possam centralizar todos os registros de erros em um local, de onde podem monitorar e tomar decisões mais acertadas. </br> Neste projeto vamos implementar um sistema para centralizar registros de erros de aplicações.
</p>

A arquitetura do projeto é formada por:


### :computer: Backend - API
 criar endpoints para serem usados pelo frontend da aplicação
criar um endpoint que será usado para gravar os logs de erro em um banco de dados relacional
a API deve ser segura, permitindo acesso apenas com um token de autenticação válido

###  :computer:  Frontend
deve implementar as funcionalidades apresentadas nos wireframes
deve ser acessada adequadamente tanto por navegadores desktop quanto mobile
deve consumir a API do produto
desenvolvida na forma de uma Single Page Application
Observações
Se a aceleração tiver ênfase no backend (Java, Python, C#, Go, PHP, etc) a equipe deve obrigatoriamente implementar a API. A implementação do frontend não é necessária
Se a aceleração tiver ênfase em frontend (React, Vue, Angular, etc) a equipe deve obrigatoriamente implementar o frontend da aplicação e o backend pode ser substituido por uma aplicação mock. A implementação da API não é necessária, caso o time deseje podem ser utilizados mocks.
Wireframes
Os wireframes a seguir servem para ilustrar as funcionalidades básicas que a aplicação deverá ter, porém o time terá total liberdade para definir os detalhes de implementação e estratégia a ser utilizada no desenvolvimento.



<p align="center">
    <img alt="img" src="https://codenation-challenges.s3-us-west-1.amazonaws.com/central-erros/1-cadastro.png" />
  <img alt="img" src="https://codenation-challenges.s3-us-west-1.amazonaws.com/central-erros/2-login.png" />
   <img alt="img" src="https://codenation-challenges.s3-us-west-1.amazonaws.com/central-erros/3-dashboard.png" />
 <img alt="img" src="https://codenation-challenges.s3-us-west-1.amazonaws.com/central-erros/4-ambientes.png" />
 <img alt="img" src="https://codenation-challenges.s3-us-west-1.amazonaws.com/central-erros/5-order.png" />
 <img alt="img" src="https://codenation-challenges.s3-us-west-1.amazonaws.com/central-erros/6-filtro.png" />
 <img alt="img" src="https://codenation-challenges.s3-us-west-1.amazonaws.com/central-erros/7-detalhes.png" />
</p>

