# BAE-Brasil
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
