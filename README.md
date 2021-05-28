# BAE Brasil
## Conceito
Aplicação web destinada a oferecer um serviço de banco de vagas de empregos e currículos
de profissionais, possibilitando a busca de vagas por candidatos e de currículos por empregadores.

## Versão Atual
A versão atual consiste em um MVC que deverá servir como uma prova de conceito. Deste modo, não estão 
disponíveis todas as funcionalidades que aplicação se pretende a oferecer, mas apenas funcionalidades
de leitura e escrita (e não de edição e deleção). 

É possível para os usuários realizarem um cadastro inicial sinalizando o tipo de usuário que
está sendo criado - Candidato ou Empregador. Após o cadastro e preenchimento do perfil com dados
básicos, pertinentes ao tipo de usuário, é possível ao Candidato cadastrar seu currículo e ao 
Empregador buscar currículos de acordo com critérios de filtro. O cadastro e busca de vagas será
implementado em uma próxima versão.

A aplicação pode ser acessada em:
https://bae-brasil.azurewebsites.net/

## Rotas e Seções da Aplicação
### __Home:__
1. Página principal: 
```C#
    [HTTP Get] 
    "/home/index" 
    // ou  
    "/"
```
### __Usuários:__
2. Registro de usuários: 
```C#
    [HTTP Get]   "/user/register"       -> View
    [HTTP Post]  "/user/submitregister" -> Redirect
``` 
3. Login do usuário:
```C#
    [HTTP Get]   "/user/login"          -> View
    [HTTP Post]  "/user/submitlogin"    -> Redirect
```
4. Logout:
```C#
    [HTTP Get]  "/user/logout" -> Redirect
```
### __Perfil:__
5. Dados de perfil:
```C#
    [HTTP Get]  "/profile/index" -> View
```
6. Registro de perfil:
```C#
    [HTTP Get]  "/profile/create"       -> View
    [HTTP Post] "/profile/submitcreate" -> Redirect
```
7. Cração de endereço:
```C#
    [HTTP Post] "/profile/submitcreateaddress"  -> Redirect
```
### __Currículo:__
8. Dados do currículo:
```C#
    [HTTP Get]   "/resume/index"  -> View
```
9. Criação de currículo:
```C#
    [HTTP Get]   "/resume/create"        -> View
    [HTTP Post]   "/resume/submitcreate" -> Redirect
```
10. Adiconar experiencia profissional:
```C#
    [HTTP Get]   "/resume/addprofessionalexperience"       -> View
    [HTTP Post]  "/resume/submitaddprofessionalexperience" -> Redirect
```
11. Adicionar formação:
```C#
    [HTTP Get]   "/resume/addDegree"         -> View
    [HTTP Post]  "/resume/submitAddDegree"   -> Redirect
```
12. Adicionar idioma:
```C#
    [HTTP Get]   "/resume/addLanguage"        -> View
    [HTTP Post]  "/resume/submitAddLanguage"  -> Redirect
```
### __Empregador:__
13. Buscar por currículos:
```C#
    [HTTP Get]   "/employer/searchResumes"       -> View
    [HTTP Post]  "/employer/submitSearchResumes" -> Redirect
```

## Modelagem e Persistência de Dados
Dado que o estado atual da aplicação consiste em um MVC, o sistema de gerenciamento de banco de dados em uso
é o SQLite e os dados são persistidos em arquivo com extensão ```.db```

### Diagrama de Entidades e Relações:
![DER](/src/BAE_Brasil/docs/er.png)

## Imagem Docker:
1. Baixar a imagem:
```
docker pull gubelleza/bae-br:latest
```
2. Executar aplicação com o comando:
```
docker run -p 8080:80 gubelleza/bae-br
```

## Criação de Usuários de Teste
Para reduzir o impacto na inicialização da aplicação, a inserção dos
usuários de teste é realizada por uma request GET ao endpoint:
```
/user/pop
```
O processo pode levar até 3 minutos a depender do ambiente de execução.
