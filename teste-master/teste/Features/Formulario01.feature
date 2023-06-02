#language: pt-br

Funcionalidade: Submissão de Dados
Eu como usuário 
quero preencher meus dados 
para manter os dados atualizados


Cenário: Submeter os dados no formulário com sucesso
Dado que estou na principal
Quando preencher os dados com valores válidos
E submeto o formulário
Então devo receber uma modal com a mensagem de sucesso
E fecho a modal

Esquema do Cenário: Submeter dos dados no formulário informando dados incorretos nos campos
Dado que estou na principal
Quando preencher o nome "<nome>"
E preencher o sobrenome "<sobrenome>"
E preencher o dado telefone "<telefone>"
E submeto o formulário
Então devo receber uma modal com a "<mensagem>"
E fecho a modal
Exemplos: 
| nome   | sobrenome | telefone   | mensagem														|
| rodrigo| barbosa   |			  | Informe os campos obrigatórios									|
|        | sobrenome | 6199899890 | Informe o campo obrigatório nome								|
| nome   |           | 6199899890 | Informe o campo obrigatório sobrenome							|
| nome   | sobrenome |            | Informe o campo obrigatório telefone							|
| nome   | sobrenome | 619989     | Informe o campo telefone corretamente							|
| no     | so        | 619989     | Informe os campos nome e sobre nome com o minimo de caracters 3 |


Esquema do Cenário: Submeter alteração de cor de layout da homepage
Dado que estou na principal
Quando alterar o checkbox com a "<cor>"
Então deve ser alterada a "<cor_de_fundo>"
Exemplos:
|cor     | cor_de_fundo				 |
|Azul    | background-color: blue;	 |
|Amarelo | background-color: yellow; |
|Vermelho| background-color: red;	 |


Cenário: Submeter o formulário
Dado que estou na principal
Quando alterar submeter a saudacao
Então devo receber uma modal com mensagem de saudação
