# FCG
Fiap Cloud Games 


Regras GIT
  - Criar sempre um branch do develop.  O branch deve seguir o seguinte padrao: feature/[projeto]/XX_descricao_da_mudança, onde XX são as iniciais de quem criou.
  - Sempre criar PR para dar merge do branch do feature no develop.

Base de Dados:
  - Script de criação da base de dados em Infrastructure/Scripts.
  - appsettings.json considerando integrated security e base dedados com nome FCG: Caso vc tenha criado uma base com nome diferente ou autenticacao diferente, precisa modificar aqui:
      "ConnectionString": "Data Source=localhost; Initial Catalog=FCG; Integrated Security=true;TrustServerCertificate=true"
