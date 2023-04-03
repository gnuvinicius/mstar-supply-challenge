# morning star supply

O Projeto é baseado em um sistema para registrar entra e saída de mercadorias. o sistema armazena uma lista de registros com a data e hora do registro, quantidade e local, com relacionamento com outra entidade chamada Mercadoria, e a mercadoria tem relacionamento com a entidade chamada Fabricante.

Nesta primeira versão, não foram implementados os testes unitários.

A primeira versão está com a TAG 1.0.0, o primeiro digito é o major, para a primeira release, o segundo digito são as novas features entregues na versão e o ultimo digito para correções de bug.

## Arquitetura

A arquitetura do projeto contem um webservice RESTFul em no ASP.NET Core com OpenAPI para documentação da API, um banco de dados PostgreSQL, um PgAdmin4 e um NGinx para rodar o frontend.

### devOps helpers

Para executar o ambiente de teste, é preciso renomear os arquivos **docker-compose_example.yml** para **docker-compose.yml** e escolher as senhas para o serviço de banco de dados.

o docker compose iria subir 4 serviços:

* o service **api**, com o build do container através do Dockerfile dentro do diretório api, configurado com a imagem do openJDK 17, irá realizar download e instalação do maven, clonar o repositorio git do projeto no GitHub, realizar o build e executar o jar.
* o service **db** e **pgadmin** irá subir o banco e a console de adminstração do banco de dados.
* o service **rabbitmq** para subir o serviço de mensageria, com o arquivo de configuração que registra a queue, o exchange e o routing key.

_Obs. No meu ambiente de desenvolvimento, a versão do Windows não permite instalar docker, para resolver isso, eu utilizei o Vagrant, mas se for possível rodar o docker diretamente no ambiente de testes, só precisa executar o docker compose._

_Obs 2. Se for criar uma VM com o Vagrant, é possível rodar o script install-docker.sh (dando a permissão de execução no linux)._

### acessos

<http://endereco-ip:8080/swagger-ui.html> para acessar a documentação da API

<http://endereco-ip:16543> para acessar o PgAdmin

