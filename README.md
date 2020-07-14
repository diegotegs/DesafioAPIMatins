## Automação

- Arquitetura Projeto
	- Linguagem		- [CSharp](https://docs.microsoft.com/pt-br/dotnet/csharp/ "CSharp")
	- Orquestrador de testes - [NUnit 3.12](https://github.com/nunit/nunit "NUnit 3.12")
	- Relatório de testes automatizados - [ExtentReports 4.0.3](http://extentreports.com/docs/versions/4/net/ "ExtentReports 4.0.3")
	- Framework interação com API - [Rest Sharp 106.6.10](http://restsharp.org/ "RestSharp 106.6.10") 


## Arquitetura

**Premissas de uma boa arquitetura de automação de testes:**
*  Facilitar o desenvolvimento dos testes automatizados (reuso).
*  Facilitar a manutenção dos testes (refatoração).
*  Tornar o fluxo do teste o mais legível possível (fácil entendimento do que está sendo testado).

**Arquitetura padrão Base2**

Para facilitar o entendimento da arquitetura do projeto de testes automatizados, o template segue a padronização utilizada para Testes Web para facilitar o entendimento e proporcionar uma melhor organização.

![alt text](https://i.imgur.com/NbiGGUL.png)

  - Bases ("contem as bases para requisições REST e SOAP alem da base para os testes")
  - DBSteps ("Contem exemplo de uso de queries")
  - Helpers ("Contem metodos auxiliares para os projetos inclusive serializacao e deserializacao de jsons, entre outros")
  - Jsons ("Diretorio para armazenar os jsons utilizados nas requisições do projeto")
  - Queries ("Diretorio para armazenar as queries utilizadas no projeto")
  - Requests ("Diretorio para armazenar as requisições do projeto")
  - Tests ("Diretorio para armazenar os testes do projeto")
  - Xmls ("Diretorio para armazenar os xmls utilizados nas requisições do projeto")


# Padrões de escrita de código

O padrão adotado para escrita é o “CamelCase” onde uma palavra é separada da outra através de letras maiúsculas. Este padrão é adotado para o nome de pastas, classes, métodos, variáveis e arquivos em geral exceto constantes. Constantes devem ser escritas com todas suas letras em maiúsculo separando as palavras com “_”.

Ex: `PreencherUsuario(), nomeUsuario, LoginPage etc.`

**Padrões por tipo de componente**

* Pastas: começam sempre com letra maiúscula. Ex: `Pages, DataBaseSteps, Queries, Bases`
* Classes: começam sempre com letra maiúscula. Ex: `LoginPage, LoginTests`
* Arquivos: começam sempre com letra maiúscula. Ex: `DataDrivenFile.csv`
* Métodos: começam sempre com letra maiúscula. Ex: `VerificarElementoXPTO()`
* Variáveis: começam sempre com letra minúscula. Ex: `botaoXPTO`
* Objetos: começam sempre com letra minúscula. Ex: `loginPage`


**Padrão de siglas e palavras com uma letra**

No caso de siglas, manter o padrão da primeira letra, de acordo com o padrão do tipo que será nomeado, ex:

```
cpfField (variável)
PreencherCPF() (método)
```

No caso de palavras com uma letra, as duas devem ser escritas juntas de acordo com o padrão do tipo que será nomeado, ex:`retornaSeValorEOEsperado()`



**Padrões de escrita: Classes e Arquivos**

Nomes de classes e arquivos devem terminar com o tipo de conteúdo que representam, em inglês, ex:

```
LoginPage (classe de PageObjects)
LoginTests (classe de testes)
LoginTestData.csv (planilha de dados)
```

OBS: Atenção ao plural e singular! Se a classe contém um conjunto do tipo que representa, esta deve ser escrita no plural, caso seja uma entidade, deve ser escrita no singular.


**Padrões de escrita: Geral**

Nunca utilizar acentos, caracteres especiais e “ç” para denominar pastas, classes, métodos, variáveis, objetos e arquivos.

**Padrões de escrita: Objetos**

Nomes dos objetos devem ser exatamente os mesmos nomes de suas classes, iniciando com letra minúscula, ex:

```
LoginPage (classe) loginPage (objeto)
LoginFlows (classe) loginFlows (objeto)
```

## Passo a passo para utilização em requisições SOAP

**1)Ao fazer o download do template e utilizá-lo pela primeira vez, deve-se primeiro obter as requisições com seus respectivos xmls.**
Para isso, aconselho o uso da ferramenta abaixo:

SOAPUI (https://www.soapui.org/downloads/soapui.html)
O SoapUi possui o recurso de anexar o arquivo wdsl e criar as requisições automaticamente. Isso facilita no momento de criação dos scripts.
		 
![alt text](https://imgur.com/NNHI4Lk.png)
		 
		 
(Obs: há outras ferramentas que auxiliam, como o WSDL Analyzer (https://www.wsdl-analyzer.com/)	mas não aconselho por ser um domínio público, podendo apresentar riscos de segurança dependendo da sensibilidade de informação contida no wsdl)	 



**2)Ao ter as requisições montadas pelo soapui, hora de adicionar os xmls de cada requisição no diretório "Xmls"**

-Copiar xml da requisição
 
![alt text](https://imgur.com/Y6aQ3z1.png)



-Criar um arquivo do tipo Xml File no diretorio "Xmls"

![alt text](https://imgur.com/NKAyDZn.png)



-Parametrizar os campos de valores do xmls conforme o padrao $nomeDaVariavel

![alt text](https://imgur.com/AaCnpk4.png)



**3)Criar as requisições**

-Criar uma classe no diretório "Requests" para cada requisição do seu projeto

-Cada classe será composta de um constructor e um método SetXmlBody

![alt text](https://imgur.com/VNyvt8r.png)



-Constructor (Onde haverá a definição do método HTTPS, adição de headers,cookies,etc. Como estamos utilizando SOAP, o método sempre sera POST)

![alt text](https://imgur.com/UnWmmIu.png)


-SetXmlBody (Onde vinculamos o arquivo xml relacionado a requisição e os parâmetros de acordo com o xml)
Repare que na primeira linha indicamos o diretório para o arquivo xml da requisição e na segunda linha fazemos um "Replace" para o parâmetro existente.

![alt text](https://imgur.com/1h0VadL.png)



**4) Criar os testes**

-Criar uma classe no diretório "Tests" para os testes do seu projeto

-Criar o método do teste contendo a região de parâmetros, a região de valores esperados o teste

![alt text](https://imgur.com/DmNI8Zt.png)


-Instanciar a requisição e configurar o xml passando os parametros necessarios
	  
![alt text](https://imgur.com/5QS5Bx7.png)
	  
	  
-Executar a requisição e armazenar o response em uma variável
	  
![alt text](https://imgur.com/nwB3GRT.png)
	  
	  
-Armazenar os nodes do xml em uma lista contendo os nodes com a tag do elemento desejado
	  
![alt text](https://imgur.com/XBHj6MD.png)
	  
	  
-Realizar o Assert conferindo o valor esperado com o valor encontrado no node
	  
![alt text](https://imgur.com/s2zVmxS.png)
	  
	  
	  
	  
	  
## Observações Finais

-Para as requisições SOAP do template, foi utilizado o wsdl (http://webservices.oorsprong.org/websamples.countryinfo/CountryInfoService.wso?WSDL ), por tanto pode ser testado os tres testes do "SoapTest.cs" caso queira verificar o funcionamento.

-Defina a sua url padrão em "Properties". Para o exemplo do template foi utilizado (http://webservices.oorsprong.org/websamples.countryinfo/CountryInfoService.wso)

-Caso tenha Headers que são comuns a todas as requisições, insira os no dicionário de headers em "RequestSoapBase"

-Caso tenha autenticação basic ou ntlm, altere os respectivos campos para "true" em "RequestSoapBase"

![alt text](https://imgur.com/dimR0zy.png)


-Os reports gerados ficam armazenados em "/bin/Debug/Reports"

![alt text](https://imgur.com/uModtXc.png)