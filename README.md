1. Apresentação do projeto


    .Aplicativo de contabilidade para uma pequena clínica de psicologia

    .Aplicativo Windows Forms (C#) com banco de dados SQL, sendo a comunicação com o banco de dados feita com ADO.NET






2. Descrição geral do projeto


    .Todo o projeto tem como base o cálculo do saldo final. Os valores de entrada são o valores recebidos pelos convênios médicos e os débitos são os gastos de escritório e os pagamentos dos membros da clínica

    .As características do funcionamento da clínica demandaram um banco de dados de 15 tabelas

    .O aplicativo consiste de uma janela de introdução, seguida por uma janela na qual o usuário faz a informação dos dados financeiros da clínica, em um processo dividido em nove abas






3. Detalhes e desafios do projeto


    .O pessoal da clínica possui a seguinte configuração: profissionais de saúde mental (psicólogos e psiquiatras) que podem ser ou não sócios da clínica, e a pessoa responsável pela secretária. Todos recebem um pagamento todo o mês

    .Os profissionais de saúde mental devem descontar dois valores dos seus pagamentos: imposto e uma parcela dos gastos de condomínio

    .Os profissionais de saúde mental que não sejam sócios da clínica devem descontar mais um valor: o aluguel pelo uso da clínica, cujo valor é influenciado pelo período em que o profissional trabalha

    .Todos os campos Textbox foram colocados limitações de caracteres aceitos. Por exemplo, no campo para informar o nome de um membro da clínica só são aceitos letras e espaços, e nos campos para informar valores monetários só são aceitos valores numéricos

    .Todo código de contato com o banco de dados é colocado dentro de estruturas 'try-catch'

    .Na primeira aba (Membros da clínica) deve-se informar os nomes dos membros da clínica, suas funções, relação com a clínica (se são sócios ou não), e se estão ativos (se estão ainda trabalhando na clínica)

    .Na segunda aba (Pagamentos - valor bruto) deve-se informar o pagamento (valor bruto) de um mês e ano de todos os membros da clínica. Os nomes disponíveis no menu para informar o nome são os nomes informados na primeira aba que estão com o status 'ativo'

    .Para diminuir o esforço do usuário, o mês e ano informados na segunda aba são copiados para todas as seguintes abas

    .Na terceira aba (Imposto) é informado a taxa de imposto que cada profissional de saúde mental deve pagar sobre seu pagamento (valor bruto) em um mês e ano. Os nomes disponíveis no menu para informar o nome são os nomes dos profissionais de saúde mental que receberam um pagamento no mês e ano informados

    .Na quarta aba (Condomínio) é calculado o valor de condomínio que cada profissional de saúde mental deve retornar para a clínica. A aba é dividida em três partes:


      -Na primeira parte (radio buttom 'Condomínio (gastos)') são informados os gastos de condomínio (água, energia, etc.) de um mês e ano

      -Na segunda parte (radio buttom 'Horas (membros)') são informados as horas trabalhadas na clínica pelos profissionais de saúde mental em um mês e ano. Os nomes disponíveis no menu são os nomes dos profissionais de saúde mental que receberam um pagamento (valor bruto) no mês e ano informados

      -Na terceira parte (radio buttom 'Condomínio (membros)') é feito o cálculo de cada valor que deverá ser retornado. O cálculo é feito da seguinte maneira: O valor total dos gastos de condomínio de um mês e ano é dividido pela soma de todas as horas trabalhadas nesta mesma data, assim determinando o valor de condomínio de uma hora trabalhada. Após isto, o valor da hora é multiplicada pela quantidade de horas trabalhadas de cada profissional de saúde mental


    .Na quinta aba (Aluguel) é informado o valor de aluguel que cada profissional de saúde mental que não seja sócio da clínica deve retornar em um mês e ano. Os nomes disponíveis no menu são os nomes dos profissionais de saúde mental que estejam registrados como 'Não sócio' na primeira aba que receberam um pagamento (valor bruto) no mês e ano informados. O valor é fortemente influenciado pelo período do dia que o profissional trabalha, por isso a informação do período é registrada

    .Na sexta aba (Pagamentos - valor líquido) são feitos os cálculos dos valores líquidos que todos receberam em um mês e ano. Ocorre o seguinte processo:


      -Primeiro são verificados todos os pagamentos (valor bruto) em uma data

      -Se o membro da clínica estiver registrado como a função de 'Secretaria', nenhum desconto do valor bruto será realizado

      -Se o membro da clínica estiver registrado como função 'Psicologia' ou 'Psiquiatria', e sua relação com a clínica estiver como 'Sócio', serão descontados do valor bruto os valores de imposto e condomínio calculados e registrados na data informada

      -Se o membro da clínica estiver registrado como função 'Psicologia' ou 'Psiquiatria', e sua relação com a clínica estiver como 'Não sócio', serão descontados do valor burto os valores de imposto, condomínio e aluguel registrados na data informada

 

    .Na sétima aba (Escritório) são informados os gastos de escritório (ISS, INSS, etc.) de um mês e ano

    .Na oitava aba (Convênios) são informados os valores recebidos pelos convênios em um mês e ano. A aba é dividida em duas partes:


      -Na primeira parte (radio buttom 'Convênios') são informados os convênios que a clínica trabalha

      -Na segunda parte (radio buttom 'Valores') são informados os valores recebidos por cada convênio, e a porcentagem de desconto de cada valor recebido, em um mês e ano 


    .Na nona aba (Saldo mensal) é calculado o saldo mensal. Isto é feito da seguinte maneira:


      -Os valores recebidos dos convênios de um mês e ano são somados

      -Desta soma são subtraídos a soma do valor dos pagamentos (valor líquido) e os gastos de escritório da mesma data



    .Em todas as abas é possível fazer uma busca nas informações registradas:


      -Na aba 'Membros da clínica': busca por nome ou por status ('Ativo', 'Inativo')

      -Nas abas 'Pagamentos - valor bruto', 'Imposto', 'Condomínio (radio buttom 'Horas (membros)', radio buttom 'Condomínio (membros)')', 'Aluguel', 'Pagamentos - valor líquido': busca por nome e por data (mês e ano)

      -Nas abas radio buttom 'Condomínio (radio buttom 'Condomínio (gastos)')', 'Escritório', 'Saldo mensal': busca por data (ano, e mês e ano)

      -Na aba 'Convênios (radio buttom 'Convênios'): busca pelo nome do convênio

      -Na aba 'Convênios (radio buttom 'Valores'): busca pelo nome do convênio e por data (mês e ano)



    .Em todos os registros informados pelo usuário, é possível alterar e deletar. Para isto, basta fazer um duplo clique no registro no DataGridView que irá abrir outra janela que fornecerá uma opção para alterar ou deletar o registro

    .Em registros que são apenas resultados de cálculos ('Saldo mensal', 'Condomínio (radio buttom 'Condomínio (membros)')'), só há a opção de deletar os registros

    .Para manter a integridade dos dados, não é possível deletar e atualizar um registro caso um outro registro de outra tabela dependa do primeiro. E a dependência pode não envolver chave estrangeira. Por exemplo: Na tabela da aba 'Saldo mensal', o valor de pagamento total de um mês e ano é uma soma de todos os pagamentos (valor líquido) da mesma data, mas esta dependência não tem como ser representada usando chave estrangeira no banco de dados. E permitir o usuário deletar em cascada poderia causar imprevistos, como, por exemplo, ele apagar um valor bruto de pagamento, mas ele se esquecendo que para manter a integridade dos dados seria necessário também apagar automaticamente registros em 'Impostos', 'Pagamentos - valor líquido', e 'Saldo mensal'

    .Também para manter a integridade de dados foi colocado limite de inserções, impedindo duplicatas indevidas. Por exemplo, não se pode informar mais de um pagamento de um membro da clínica em um mês e ano, ou registrar mais de uma despesa com condomínio na mesma data

    .Nas abas radio buttom 'Condomínio (radio buttom 'Condomínio (gastos)')', 'Pagamentos - valor líquido', e 'Saldo Mensal', é possível imprimir os registros. É possível tanto imprimir todos os registros, quanto imprimir o resultado de uma busca do usuário. Para isto se fez uso da biblioteca 'iText'

    .Estrutura do banco de dados:


      -Tabela 'tb_membros': Registrar as informações dos membros da clínica
   
      -Tabela 'tb_pagamentos_valor_bruto': Registrar os valores de pagamento (valor bruto) de um mês e ano. Possui relação com a tabela 'tb_membros'

      -Tabela 'tb_impostos': Registrar os valores de impostos que cada profissional de saúde mental deve pagar em um mês e ano. Possui relação com as tabelas 'tb_membros' e 'tb_pagamentos_valor_bruto'

      -Tabela 'tb_condominio': Registrar os gastos de condomínio de um mês e ano

      -Tabela 'tb_horas_trabalhadas' Registrar as horas trabalhadas na clínica de cada profissional de saúde mental em um mês e ano. Possui relação com a tabela 'tb_membros'

      -Tabela 'tb_condominio_hora_valor': Registrar o valor a ser pago por hora trabalhada no pagamento de condomínio em um mês e ano. Possui relação com a tabela 'tb_condominio'

      -Tabela 'tb_membros_condominio': Registrar o valor que deve ser retornado por cada profissional de saúde mental em relação ao pagamento aos gastos de condomínio em um mês e ano. Possui relações com as tabelas 'tb_membros', 'tb_horas_trabalhadas', e 'tb_condominio_hora_valor'

      -Tabela 'tb_aluguel': Registrar o valor que cada profissional de saúde mental que não seja sócio da clínica deve retornar em um mês e ano. Possui relação com a tabela 'tb_membros'

      -Tabela 'tb_pagamentos_secretaria': Registrar os pagamentos (valor líquido) dos membros da clínica que atuam na secretaria em um mês e ano. Pussui relação com as tabelas 'tb_membros', e 'tb_pagamentos_valor_bruto'

      -Tabela 'tb_pagamentos_socios': Registrar os pagamentos (valor líquido) dos profissionais de saúde mental que são sócios da clínica. Possui relação com as tabelas 'tb_membros', 'tb_pagamentos_valor_bruto', 'tb_impostos', e 'tb_membros_condominio'

      -Tabela 'tb_pagamentos_nao_socios': Registrar os pagamentos (valor líquido) dos profissionais de saúde mental que não são sócios da clínica. Possui relação com as tabelas 'tb_membros', 'tb_pagamentos_valor_bruto', 'tb_impostos', 'tb_aluguel', e 'tb_membros_condominio'

      -Tabela 'tb_escritório': Registrar os gastos de escritório de um mês e ano

      -Tabela 'tb_convenios': Registrar os convênios que a clínica trabalha

      -Tabela 'tb_convenios_valores': Registrar os valores recebidos por cada convênio em um mês e ano

      -Tabela 'tb_saldos': Registrar o saldo de um mês e ano

      -Todas as tabelas usam chaves substitutas (identity)


    .Tudo aqui mencionado consta no 'commit 1'






4. Refatorações planejadas no futuro


    .Aplicar o padrão repositório e remover o código de dentro dos eventos []

    .Usar métodos assíncronos em processos que envolvam banco de dados []

    .Aplicar transações SQL em processos de inserção de registros que envolvam múltiplas inserções de uma vez []

    .Inserir a criação de arquivos de log em caso de alguma falha (catch) []
