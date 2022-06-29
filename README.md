# Publicando a Aplicação

* ```dotnet publish -c Release -o dist```
  * ```-c``` equivale ao comando ```--configuration````
  * **Release** para publicar a versão de produção
  * ```-o``` de ```output```, para ejetar os arquivos gerados pela publicação na pasta **dist**

# Dockerfile

* ```FROM mcr.microsoft.com/dotnet/aspnet:6.0```
  * imagem base
* ```LABEL version="1.0.1" description="Aplicacao ASP .NET MVC"```
  * versão e descrição da imagem
* ```COPY dist /app```
  * instrução para copiar os arquivos da pasta **dist** no **host**, para a pasta **app** no container
* ```WORKDIR /app```
  * definindo o diretório de trabalho dentro do container
* ```EXPOSE 80/tcp```
  * expondo a porta do container que ficará acessível para acesso externo
* ```ENTRYPOINT ["dotnet", "mvc1.dll"]```
  * definindo o ponto de entrada para execução do container

# Build da Imagem

* ```docker image build -t asp-net-mvc/app1:1.0 .```
  * ```docker image build``` para executar o comando relativo ao **build** da **imagem**
  * ```-t``` indica a **tag** que é o nome da imagem que vem logo à frente
  * ```asp-net-mvc/app1:1.0``` é o nome ou **tag** da imagem