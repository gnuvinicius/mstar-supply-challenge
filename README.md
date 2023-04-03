# morning star supply

O Projeto é baseado em um sistema para registrar entrada e saída de mercadorias. o sistema armazena uma lista de registros com a data e hora do registro, quantidade e local, com relacionamento com a entidade Mercadoria, e a mercadoria tem relacionamento com a entidade chamada Fabricante.

Nesta primeira versão, não foram implementados os testes unitários.

A primeira versão está com a TAG 1.0.0, o primeiro digito é o major, para a primeira release, o segundo digito são as novas features entregues na versão e o ultimo digito para correções de bug.

## Arquitetura

A arquitetura do projeto esta montada no docker, através do docker-compose, com 4 serviços:
um webservice RESTFul em ASP.NET Core 6.0 LTS com OpenAPI para documentação da API
um banco de dados PostgreSQL
o PgAdmin4 para administrar o banco e o frontend rodando com o package serve no NPM.

### devOps helpers

Para executar o ambiente de teste, é preciso renomear os arquivos **docker-compose_example.yml** para **docker-compose.yml** e escolher as senhas para o serviço de banco de dados e adicionar o endereço IP da maquina que vai rodar o docker.


_Obs. No meu ambiente de desenvolvimento, a versão do Windows não permite instalar docker, para resolver isso, eu utilizei o Vagrant, mas se for possível rodar o docker diretamente no ambiente de testes, só precisa executar o docker compose._

_Obs 2. Se for criar uma VM com o Vagrant, é possível rodar o script install-docker.sh (dando a permissão de execução no linux)._

### acessos

<http://endereco-ip:5000/swagger/index.html> para acessar a documentação da API

<http://endereco-ip:16543> para acessar o PgAdmin

<http://endereco-ip> para acessar a interface web


### comandos

docker-compose build --no-cache

docker-compose up -d