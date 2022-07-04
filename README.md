## Publicando a Aplicação

* ```dotnet publish -c Release -o dist```
  * ```-c``` equivale ao comando ```--configuration```
  * **Release** para publicar a versão de produção
  * ```-o``` de ```output```, para ejetar os arquivos gerados pela publicação na pasta **dist**

## Dockerfile

* ```FROM mcr.microsoft.com/dotnet/aspnet:6.0```
  * imagem base
* ```LABEL version="1.0" description="Aplicacao ASP .NET MVC"```
  * versão e descrição da imagem
* ```COPY dist /app```
  * instrução para copiar os arquivos da pasta **dist** no **host**, para a pasta **app** no container
* ```WORKDIR /app```
  * definindo o diretório de trabalho dentro do container
* ```EXPOSE 80/tcp```
  * expondo a porta do container que ficará acessível externamente
* ```ENTRYPOINT ["dotnet", "mvc1.dll"]```
  * definindo o ponto de entrada para execução do container

## Build da Imagem

* ```docker image build -t asp-net-mvc/app1:1.0 .```
  * ```docker image build``` comando relativo ao **build** da **imagem**
  * ```-t``` indica a **tag**, que é o nome da imagem que vem logo à frente
  * ```asp-net-mvc/app1:1.0``` é o nome ou **tag** da imagem
  * ``` . ``` indica que a imagem está sendo criada no diretório atual que deve conter o arquivo **Dockerfile**

## Criando o Container

* ```docker container create -p 4000:80 --name mvc-produtos asp-net-mvc/app1:1.0```
  * ```create``` é o comando que cria o container
  * ```-p 4000:80``` para mapear a porta do container
    * **À esquerda dos dois pontos**, é a porta do **host**
    * **À direita dos dois pontos**, é a porta do container
  * ```--name``` usado para dar nome aos containers
  * ```asp-net-mvc/app1:1.0``` especificando a imagem que foi criada anteriormente como a origem do container

* ```docker container start mvc-produtos```
  * em seguida, a instrução acima executa o container

## Publicando a Imagem
  * ```docker image tag asp-net-mvc/app1:1.0 username/mvc-produtos```
    * comando para definir uma nova **tag** para a imagem no **host**, associada a um usuário do **Docker Hub**
  * ```docker login -u username```
    * comando para logar no **Docker Hub**
  * ```docker image push username/mvc-produtos:1.0```
    * executa o envio da imagem para o repositório remoto do usuário logado
  * ```docker container run -p 4000:80 --name mvc-produtos username/mvc-produtos:1.0```
    * executa um container com base na imagem publicada