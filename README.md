# Publicando a Aplicação

* ```dotnet publish -c Release -o dist```
  * ```-c``` equivale ao comando ```--configuration```
  * **Release** para publicar a versão de produção
  * ```-o``` de ```output```, para ejetar os arquivos gerados pela publicação na pasta **dist**

# Dockerfile

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

# Build da Imagem

* ```docker image build -t asp-net-mvc/app1:1.0 .```
  * ```docker image build``` comando relativo ao **build** da **imagem**
  * ```-t``` indica a **tag**, que é o nome da imagem que vem logo à frente
  * ```asp-net-mvc/app1:1.0``` é o nome ou **tag** da imagem
  * ``` . ``` indica que a imagem está sendo criada no diretório atual que deve conter o arquivo **Dockerfile**

# Criando o Container

* ```docker container create -p 4000:80 --name mvc-produtos asp-net-mvc/app1:1.0```
  * ```create``` é o comando que cria o container
  * ```-p 4000:80``` para mapear a porta do container **à direita dos dois pontos**, que será exposta pela porta do **host**, **à esquerda dos dois pontos**, ou seja, a porta **80** do container será servida na porta **4000** da máquina **host** neste exemplo.
  * ```--name``` usado para dar nome aos containers
  * ```asp-net-mvc/app1:1.0``` especificando a imagem que foi criada como origem do container