BAE Brasil
Conceito
Aplicação web destinada a oferecer um serviço de banco de vagas de empregos e currículos de profissionais, possibilitando a busca de vagas por candidatos e de currículos por empregadores.

Versão Atual
A versão atual consiste em um MVC que deverá servir como uma prova de conceito. Deste modo, não estão disponíveis todas as funcionalidades que aplicação se pretende a oferecer, mas apenas funcionalidades de leitura e escrita (e não de edição e deleção).

É possível para os usuários realizarem um cadastro inicial sinalizando o tipo de usuário que está sendo criado - Candidato ou Empregador. Após o cadastro e preenchimento do perfil com dados básicos, pertinentes ao tipo de usuário, é possível ao Candidato cadastrar seu currículo e ao Empregador buscar currículos de acordo com critérios de filtro. O cadastro e busca de vagas será implementado em uma próxima versão.

Rotas e Secões da Aplicação
Home:
Página principal:
    [HTTP Get] 
    "/home/index" 
    // ou  
    "/"
Usuários:
Registro de usuários:
    [HTTP Get]   "/user/register"       -> View
    [HTTP Post]  "/user/submitregister" -> Redirect
Login do usuário:
    [HTTP Get]   "/user/login"          -> View
    [HTTP Post]  "/user/submitlogin"    -> Redirect
Logout:
    [HTTP Get]  "/user/logout"           -> Redirect
Perfil:
Dados de perfil:
    [HTTP Get]  "/profile/index"
Registro de perfil:
    [HTTP Get]  "/profile/create"
    [HTTP Post] "/profile/submitcreate"
Cração de endereço:
    [HTTP Post] "/profile/submitcreateaddress"
Currículo:
Dados do currículo:
    [HttpGet]   "/resume/index"
Criação de currículo:
    [HttpGet]   "/resume/create"
    [HttpPost]   "/resume/submitcreate"
Adiconar experiencia profissional:
    [HttpGet]   "/resume/addprofessionalexperience"
    [HttpPost]  "/resume/submitaddprofessionalexperience"
Adicionar formação:
    [HttpGet]   "/resume/addDegree"
    [HttpPost]  "/resume/submitAddDegree"
Adicionar idioma:
    [HttpGet]   "/resume/addLanguage"
    [HttpPost]  "/resume/submitAddLanguage"
Empregador:
Buscar por currículos:
    [HTTP Get]  "/employer/searchResumes"
    [HttpPost]  "/employer/submitSearchResumes"
Modelagem e Persistência de Dados
Dado que o estado atual da aplicação consiste em um MVC, o sistema de gerenciamento de banco de dados em uso é o SQLite e os dados são persistidos em arquivo com extensão .db

Imagem Docker:
Baixar a imagem:
docker pull gubelleza/bae-br:latest
Executar aplicação com o comando:
docker run -p 8080:80 gubelleza/bae-br
Criação de Usuários de Teste
Para reduzir o impacto na inicialização da aplicação, a inserção dos usuários de teste é realizada por uma request GET ao endpoint:

/user/pop
O processo pode levar até 3 minutos a depender do ambiente de execução.
