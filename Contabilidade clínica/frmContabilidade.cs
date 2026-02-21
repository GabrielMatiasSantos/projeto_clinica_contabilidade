using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Linq.Expressions;
using System.Reflection;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas.Draw;

namespace Contabilidade_clínica
{
    public partial class frmContabilidade : Form
    {
        public frmContabilidade()
        {
            InitializeComponent();
        }

        private void frmContabilidade_FormClosed(object sender, FormClosedEventArgs e)  //Este é o formulário principal, onde contém a maior parte de relevante no programa. Ao fechá-lo todo o programa se encerrará
        {
            Application.Exit();
        }   

       
        public void TabelaMembros()  
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_membros ORDER BY membro_nome", conexao);

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                dgvMembros.DataSource = tabela;

                dgvMembros.Columns[0].Visible = false;

                dgvMembros.Columns[1].HeaderText = "Nome";
                dgvMembros.Columns[2].HeaderText = "Função";
                dgvMembros.Columns[3].HeaderText = "Vínculo";
                dgvMembros.Columns[4].HeaderText = "Situação";

                dgvMembros.Columns[1].Width = 180;
                dgvMembros.Columns[2].Width = 100;
                dgvMembros.Columns[3].Width = 80;
                dgvMembros.Columns[4].Width = 75;

                dgvMembros.Columns[1].DisplayIndex = 0;
                dgvMembros.Columns[2].DisplayIndex = 1;
                dgvMembros.Columns[3].DisplayIndex = 2;
                dgvMembros.Columns[4].DisplayIndex = 3;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
           
        }

        public void TabelaPagamentosBruto()  
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT pagamento_bruto_id, membro_nome, pagamento_bruto_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_valor_bruto INNER JOIN tb_membros ON tb_pagamentos_valor_bruto.pagamento_bruto_membro = tb_membros.membro_id ORDER BY pagamento_bruto_ano, pagamento_bruto_mes, membro_nome;", conexao);

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                dgvPagamentosBruto.DataSource = tabela;

                dgvPagamentosBruto.Columns[0].Visible = false;

                dgvPagamentosBruto.Columns[1].HeaderText = "Nome";
                dgvPagamentosBruto.Columns[2].HeaderText = "Valor (R$)";
                dgvPagamentosBruto.Columns[3].HeaderText = "Mês";
                dgvPagamentosBruto.Columns[4].HeaderText = "Ano";

                dgvPagamentosBruto.Columns[1].Width = 180;
                dgvPagamentosBruto.Columns[2].Width = 100;
                dgvPagamentosBruto.Columns[3].Width = 50;
                dgvPagamentosBruto.Columns[4].Width = 50;

                dgvPagamentosBruto.Columns[1].DisplayIndex = 0;
                dgvPagamentosBruto.Columns[2].DisplayIndex = 1;
                dgvPagamentosBruto.Columns[3].DisplayIndex = 2;
                dgvPagamentosBruto.Columns[4].DisplayIndex = 3;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }


        public void TabelaImpostos()
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT imposto_id, membro_nome, imposto_taxa, pagamento_bruto_valor, imposto_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_impostos INNER JOIN tb_membros ON tb_impostos.imposto_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_impostos.pagamento_mensal_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id ORDER BY pagamento_bruto_ano, pagamento_bruto_mes, membro_nome;", conexao);

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                dgvImpostos.DataSource = tabela;

                dgvImpostos.Columns[0].Visible = false;

                dgvImpostos.Columns[1].HeaderText = "Nome";
                dgvImpostos.Columns[2].HeaderText = "Taxa (%)";
                dgvImpostos.Columns[3].HeaderText = "Pagamento (R$)";
                dgvImpostos.Columns[4].HeaderText = "Imposto (R$)";
                dgvImpostos.Columns[5].HeaderText = "Mês";
                dgvImpostos.Columns[6].HeaderText = "Ano";

                dgvImpostos.Columns[1].Width = 180;
                dgvImpostos.Columns[2].Width = 100;
                dgvImpostos.Columns[3].Width = 100;
                dgvImpostos.Columns[4].Width = 100;
                dgvImpostos.Columns[5].Width = 50;
                dgvImpostos.Columns[6].Width = 50;

                dgvImpostos.Columns[1].DisplayIndex = 0;
                dgvImpostos.Columns[2].DisplayIndex = 1;
                dgvImpostos.Columns[3].DisplayIndex = 2;
                dgvImpostos.Columns[4].DisplayIndex = 3;
                dgvImpostos.Columns[5].DisplayIndex = 4;
                dgvImpostos.Columns[6].DisplayIndex = 5;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
            
        }    

        public void TabelaCondominioGastos()
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT * From tb_condominio ORDER BY condominio_ano, condominio_mes", conexao);

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                dgvCondominio.DataSource = tabela;

                dgvCondominio.Columns[0].Visible = false;

                dgvCondominio.Columns[1].HeaderText = "CPFL";
                dgvCondominio.Columns[2].HeaderText = "SANEBAVI";
                dgvCondominio.Columns[3].HeaderText = "Vivo";
                dgvCondominio.Columns[4].HeaderText = "Correios";
                dgvCondominio.Columns[5].HeaderText = "Água para beber";
                dgvCondominio.Columns[6].HeaderText = "Copos";
                dgvCondominio.Columns[7].HeaderText = "Papel higiênico";
                dgvCondominio.Columns[8].HeaderText = "Papel toalha";
                dgvCondominio.Columns[9].HeaderText = "Café";
                dgvCondominio.Columns[10].HeaderText = "Açúcar";
                dgvCondominio.Columns[11].HeaderText = "Produtos de limpeza";
                dgvCondominio.Columns[12].HeaderText = "Faxina";
                dgvCondominio.Columns[13].HeaderText = "Recarga de celular";
                dgvCondominio.Columns[14].HeaderText = "Outros";
                dgvCondominio.Columns[15].HeaderText = "Total (R$)";
                dgvCondominio.Columns[16].HeaderText = "Mês";
                dgvCondominio.Columns[17].HeaderText = "Ano";

                dgvCondominio.Columns[1].Width = 100;
                dgvCondominio.Columns[2].Width = 100;
                dgvCondominio.Columns[3].Width = 100;
                dgvCondominio.Columns[4].Width = 100;
                dgvCondominio.Columns[5].Width = 100;
                dgvCondominio.Columns[6].Width = 100;
                dgvCondominio.Columns[7].Width = 100;
                dgvCondominio.Columns[8].Width = 100;
                dgvCondominio.Columns[9].Width = 100;
                dgvCondominio.Columns[10].Width = 100;
                dgvCondominio.Columns[11].Width = 100;
                dgvCondominio.Columns[12].Width = 100;
                dgvCondominio.Columns[13].Width = 100;
                dgvCondominio.Columns[14].Width = 100;
                dgvCondominio.Columns[15].Width = 100;
                dgvCondominio.Columns[16].Width = 50;
                dgvCondominio.Columns[17].Width = 50;

                dgvCondominio.Columns[1].DisplayIndex = 0;
                dgvCondominio.Columns[2].DisplayIndex = 1;
                dgvCondominio.Columns[3].DisplayIndex = 2;
                dgvCondominio.Columns[4].DisplayIndex = 3;
                dgvCondominio.Columns[5].DisplayIndex = 4;
                dgvCondominio.Columns[6].DisplayIndex = 5;
                dgvCondominio.Columns[7].DisplayIndex = 6;
                dgvCondominio.Columns[8].DisplayIndex = 7;
                dgvCondominio.Columns[9].DisplayIndex = 8;
                dgvCondominio.Columns[10].DisplayIndex = 9;
                dgvCondominio.Columns[11].DisplayIndex = 10;
                dgvCondominio.Columns[12].DisplayIndex = 11;
                dgvCondominio.Columns[13].DisplayIndex = 12;
                dgvCondominio.Columns[14].DisplayIndex = 13;
                dgvCondominio.Columns[15].DisplayIndex = 14;
                dgvCondominio.Columns[16].DisplayIndex = 15;
                dgvCondominio.Columns[17].DisplayIndex = 16;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }

        public void TabelaCondominioHoras()
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT horas_trabalhadas_id, membro_nome, horas_trabalhadas, horas_trabalhadas_mes, horas_trabalhadas_ano FROM tb_horas_trabalhadas INNER JOIN tb_membros ON tb_horas_trabalhadas.horas_trabalhadas_membro = tb_membros.membro_id ORDER BY horas_trabalhadas_ano, horas_trabalhadas_mes, membro_nome;", conexao);

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                dgvCondominio.DataSource = tabela;

                dgvCondominio.Columns[0].Visible = false;

                dgvCondominio.Columns[1].HeaderText = "Nome";
                dgvCondominio.Columns[2].HeaderText = "Horas na clínica";
                dgvCondominio.Columns[3].HeaderText = "Mês";
                dgvCondominio.Columns[4].HeaderText = "Ano";

                dgvCondominio.Columns[1].Width = 180;
                dgvCondominio.Columns[2].Width = 100;
                dgvCondominio.Columns[3].Width = 50;
                dgvCondominio.Columns[4].Width = 50;

                dgvCondominio.Columns[1].DisplayIndex = 0;
                dgvCondominio.Columns[2].DisplayIndex = 1;
                dgvCondominio.Columns[3].DisplayIndex = 2;
                dgvCondominio.Columns[4].DisplayIndex = 3;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }            
        }

        public void TabelaCondominioMembros()
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT membro_nome, horas_trabalhadas, hora_valor, membro_condominio_valor, horas_trabalhadas_mes, horas_trabalhadas_ano FROM tb_membros_condominio INNER JOIN tb_membros ON tb_membros_condominio.condominio_membro = tb_membros.Membro_id INNER JOIN tb_condominio_hora_valor ON tb_membros_condominio.condominio_hora_valor = tb_condominio_hora_valor.hora_valor_id INNER JOIN tb_horas_trabalhadas ON tb_membros_condominio.membro_horas_trabalhadas = tb_horas_trabalhadas.horas_trabalhadas_id ORDER BY horas_trabalhadas_ano, horas_trabalhadas_mes, membro_nome;", conexao);

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                dgvCondominio.DataSource = tabela;


                dgvCondominio.Columns[0].HeaderText = "Nome";
                dgvCondominio.Columns[1].HeaderText = "Horas na clínica";
                dgvCondominio.Columns[2].HeaderText = "Valor da hora (R$)";
                dgvCondominio.Columns[3].HeaderText = "Condomínio (R$)";
                dgvCondominio.Columns[4].HeaderText = "Mês";
                dgvCondominio.Columns[5].HeaderText = "Ano";

                dgvCondominio.Columns[0].Width = 180;
                dgvCondominio.Columns[1].Width = 100;
                dgvCondominio.Columns[2].Width = 100;
                dgvCondominio.Columns[3].Width = 100;
                dgvCondominio.Columns[4].Width = 50;
                dgvCondominio.Columns[5].Width = 50;

                dgvCondominio.Columns[0].DisplayIndex = 0;
                dgvCondominio.Columns[1].DisplayIndex = 1;
                dgvCondominio.Columns[2].DisplayIndex = 2;
                dgvCondominio.Columns[3].DisplayIndex = 3;
                dgvCondominio.Columns[4].DisplayIndex = 4;
                dgvCondominio.Columns[5].DisplayIndex = 5;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }            
        }


        public void TabelaAluguel()
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT aluguel_id, membro_nome, aluguel_periodo, aluguel_valor, aluguel_mes, aluguel_ano FROM tb_aluguel INNER JOIN tb_membros ON tb_aluguel.aluguel_membro = tb_membros.membro_id ORDER BY aluguel_ano, aluguel_mes, membro_nome;", conexao);

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                dgvAluguel.DataSource = tabela;

                dgvAluguel.Columns[0].Visible = false;

                dgvAluguel.Columns[1].HeaderText = "Nome";
                dgvAluguel.Columns[2].HeaderText = "Período";
                dgvAluguel.Columns[3].HeaderText = "Aluguel (R$)";
                dgvAluguel.Columns[4].HeaderText = "Mês";
                dgvAluguel.Columns[5].HeaderText = "Ano";

                dgvAluguel.Columns[1].Width = 180;
                dgvAluguel.Columns[2].Width = 100;
                dgvAluguel.Columns[3].Width = 100;
                dgvAluguel.Columns[4].Width = 50;
                dgvAluguel.Columns[5].Width = 50;

                dgvAluguel.Columns[1].DisplayIndex = 0;
                dgvAluguel.Columns[2].DisplayIndex = 1;
                dgvAluguel.Columns[3].DisplayIndex = 2;
                dgvAluguel.Columns[4].DisplayIndex = 3;
                dgvAluguel.Columns[5].DisplayIndex = 4;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }              
        }

       
        public void TabelaPagamentosLiquido()
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT membro_nome, pagamento_bruto_valor, imposto_valor, membro_condominio_valor, aluguel_valor, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_nao_socios INNER JOIN tb_membros ON tb_pagamentos_nao_socios.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_nao_socios.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id INNER JOIN tb_impostos ON tb_pagamentos_nao_socios.desconto_imposto = tb_impostos.imposto_id INNER JOIN tb_membros_condominio ON tb_pagamentos_nao_socios.desconto_condominio = tb_membros_condominio.membro_condominio_id INNER JOIN tb_aluguel ON tb_pagamentos_nao_socios.desconto_aluguel = tb_aluguel.aluguel_id UNION SELECT membro_nome, pagamento_bruto_valor, imposto_valor, membro_condominio_valor, desconto_aluguel, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_socios INNER JOIN tb_membros ON tb_pagamentos_socios.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_socios.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id INNER JOIN tb_impostos ON tb_pagamentos_socios.desconto_imposto = tb_impostos.imposto_id INNER JOIN tb_membros_condominio ON tb_pagamentos_socios.desconto_condominio = tb_membros_condominio.membro_condominio_id UNION SELECT membro_nome, pagamento_bruto_valor, desconto_imposto, desconto_condominio, desconto_aluguel, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_secretaria INNER JOIN tb_membros ON tb_pagamentos_secretaria.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_secretaria.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id ORDER BY pagamento_bruto_ano, pagamento_bruto_mes, membro_nome;", conexao);

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                dgvPagamentosLiquido.DataSource = tabela;

                dgvPagamentosLiquido.Columns[0].HeaderText = "Nome";
                dgvPagamentosLiquido.Columns[1].HeaderText = "Valor bruto (R$)";
                dgvPagamentosLiquido.Columns[2].HeaderText = "Imposto (R$)";
                dgvPagamentosLiquido.Columns[3].HeaderText = "Condomínio (R$)";
                dgvPagamentosLiquido.Columns[4].HeaderText = "Aluguel (R$)";
                dgvPagamentosLiquido.Columns[5].HeaderText = "Valor líquido (R$)";
                dgvPagamentosLiquido.Columns[6].HeaderText = "Mês";
                dgvPagamentosLiquido.Columns[7].HeaderText = "Ano";

                dgvPagamentosLiquido.Columns[0].Width = 180;
                dgvPagamentosLiquido.Columns[1].Width = 100;
                dgvPagamentosLiquido.Columns[2].Width = 100;
                dgvPagamentosLiquido.Columns[3].Width = 100;
                dgvPagamentosLiquido.Columns[4].Width = 100;
                dgvPagamentosLiquido.Columns[5].Width = 110;
                dgvPagamentosLiquido.Columns[6].Width = 50;
                dgvPagamentosLiquido.Columns[7].Width = 50;

                dgvPagamentosLiquido.Columns[0].DisplayIndex = 0;
                dgvPagamentosLiquido.Columns[1].DisplayIndex = 1;
                dgvPagamentosLiquido.Columns[2].DisplayIndex = 2;
                dgvPagamentosLiquido.Columns[3].DisplayIndex = 3;
                dgvPagamentosLiquido.Columns[4].DisplayIndex = 4;
                dgvPagamentosLiquido.Columns[5].DisplayIndex = 5;
                dgvPagamentosLiquido.Columns[6].DisplayIndex = 6;
                dgvPagamentosLiquido.Columns[7].DisplayIndex = 7;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }           
        }      

        public void TabelaEscritorio()
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_escritorio ORDER BY escritorio_ano, escritorio_mes", conexao);

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                dgvEscritorio.DataSource = tabela;

                dgvEscritorio.Columns[0].Visible = false;

                dgvEscritorio.Columns[1].HeaderText = "PIS";
                dgvEscritorio.Columns[2].HeaderText = "COFINS";
                dgvEscritorio.Columns[3].HeaderText = "ISS";
                dgvEscritorio.Columns[4].HeaderText = "INSS";
                dgvEscritorio.Columns[5].HeaderText = "IR";
                dgvEscritorio.Columns[6].HeaderText = "CS";
                dgvEscritorio.Columns[7].HeaderText = "CIEE";
                dgvEscritorio.Columns[8].HeaderText = "Aluguel";
                dgvEscritorio.Columns[9].HeaderText = "Escritório";
                dgvEscritorio.Columns[10].HeaderText = "Total (R$)";
                dgvEscritorio.Columns[11].HeaderText = "Mês";
                dgvEscritorio.Columns[12].HeaderText = "Ano";

                dgvEscritorio.Columns[1].Width = 100;
                dgvEscritorio.Columns[2].Width = 100;
                dgvEscritorio.Columns[3].Width = 100;
                dgvEscritorio.Columns[4].Width = 100;
                dgvEscritorio.Columns[5].Width = 100;
                dgvEscritorio.Columns[6].Width = 100;
                dgvEscritorio.Columns[7].Width = 100;
                dgvEscritorio.Columns[8].Width = 100;
                dgvEscritorio.Columns[9].Width = 100;
                dgvEscritorio.Columns[10].Width = 100;
                dgvEscritorio.Columns[11].Width = 50;
                dgvEscritorio.Columns[12].Width = 50;

                dgvEscritorio.Columns[1].DisplayIndex = 0;
                dgvEscritorio.Columns[2].DisplayIndex = 1;
                dgvEscritorio.Columns[3].DisplayIndex = 2;
                dgvEscritorio.Columns[4].DisplayIndex = 3;
                dgvEscritorio.Columns[5].DisplayIndex = 4;
                dgvEscritorio.Columns[6].DisplayIndex = 5;
                dgvEscritorio.Columns[7].DisplayIndex = 6;
                dgvEscritorio.Columns[8].DisplayIndex = 7;
                dgvEscritorio.Columns[9].DisplayIndex = 8;
                dgvEscritorio.Columns[10].DisplayIndex = 9;
                dgvEscritorio.Columns[11].DisplayIndex = 10;
                dgvEscritorio.Columns[12].DisplayIndex = 11;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }                        
        }

        public void TabelaConvenios()
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_convenios ORDER BY convenio_nome;", conexao);

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                dgvConvenio.DataSource = tabela;

                dgvConvenio.Columns[0].Visible = false;

                dgvConvenio.Columns[1].HeaderText = "Convênio";

                dgvConvenio.Columns[1].Width = 180;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }            
        }

        public void TabelaConveniosValores()
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT convenio_valor_id, convenio_nome, convenio_valor_inicial, convenio_valor_glosa, convenio_valor_desconto, convenio_valor_final, convenio_valor_mes, convenio_valor_ano FROM tb_convenios_valores INNER JOIN tb_convenios ON tb_convenios_valores.convenio = tb_convenios.convenio_id ORDER BY convenio_valor_ano, convenio_valor_mes, convenio_nome;", conexao);

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                dgvConvenio.DataSource = tabela;

                dgvConvenio.Columns[0].Visible = false;

                dgvConvenio.Columns[1].HeaderText = "Convênio";
                dgvConvenio.Columns[2].HeaderText = "Valor bruto (R$)";
                dgvConvenio.Columns[3].HeaderText = "Glosa (R$)";
                dgvConvenio.Columns[4].HeaderText = "Desconto (%)";
                dgvConvenio.Columns[5].HeaderText = "Valor líquido (R$)";
                dgvConvenio.Columns[6].HeaderText = "Mês";
                dgvConvenio.Columns[7].HeaderText = "Ano";

                dgvConvenio.Columns[1].Width = 150;
                dgvConvenio.Columns[2].Width = 110;
                dgvConvenio.Columns[3].Width = 110;
                dgvConvenio.Columns[4].Width = 110;
                dgvConvenio.Columns[5].Width = 110;
                dgvConvenio.Columns[6].Width = 50;
                dgvConvenio.Columns[7].Width = 50;

                dgvConvenio.Columns[1].DisplayIndex = 0;
                dgvConvenio.Columns[2].DisplayIndex = 1;
                dgvConvenio.Columns[3].DisplayIndex = 2;
                dgvConvenio.Columns[4].DisplayIndex = 3;
                dgvConvenio.Columns[5].DisplayIndex = 4;
                dgvConvenio.Columns[6].DisplayIndex = 5;
                dgvConvenio.Columns[7].DisplayIndex = 6;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }                      
        }

        public void TabelaSaldos()
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT saldo_id, saldo_valor_inicial, escritorio_total, pagamentos_valor, saldo_valor, saldo_mes, saldo_ano FROM tb_saldos INNER JOIN tb_escritorio ON tb_saldos.escritorio_valor = tb_escritorio.escritorio_id ORDER BY saldo_ano, saldo_mes;", conexao);

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                dgvSaldo.DataSource = tabela;

                dgvSaldo.Columns[0].Visible = false;

                dgvSaldo.Columns[1].HeaderText = "Rendimento (R$)";
                dgvSaldo.Columns[2].HeaderText = "Escritório (R$)";
                dgvSaldo.Columns[3].HeaderText = "Pagamentos (R$)";
                dgvSaldo.Columns[4].HeaderText = "Saldo (R$)";
                dgvSaldo.Columns[5].HeaderText = "Mês";
                dgvSaldo.Columns[6].HeaderText = "Ano";

                dgvSaldo.Columns[1].Width = 100;
                dgvSaldo.Columns[2].Width = 100;
                dgvSaldo.Columns[3].Width = 100;
                dgvSaldo.Columns[4].Width = 100;
                dgvSaldo.Columns[5].Width = 50;
                dgvSaldo.Columns[6].Width = 50;

                dgvSaldo.Columns[1].DisplayIndex = 0;
                dgvSaldo.Columns[2].DisplayIndex = 1;
                dgvSaldo.Columns[3].DisplayIndex = 2;
                dgvSaldo.Columns[4].DisplayIndex = 3;
                dgvSaldo.Columns[5].DisplayIndex = 4;
                dgvSaldo.Columns[6].DisplayIndex = 5;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }            
        }


        public int AbrirAba        //Determinar a aba que será carregada após fechar uma janela de alterar/deletar
        {
            set {tcContabilidade.SelectedIndex = value;}
        }

        public string Mes
        {
            set {cbPagamentosBrutoMes.Text = value;}
        }
        
        public string Ano
        {
            set {txtPagamentosBrutoAno.Text = value;}
        }

        public string CondominioAba
        {
            set {txtCondominioAba.Text = value;}
        }

        public string ConvenioAba
        {
            set {txtConvenioAba.Text = value;}
        }


        //Aba 'Membros da clínica'

       
        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)    //Restriçôes do que pode ser digitado na área de registrar os nomes dos membros da clínica
        {
            if (txtNome.Text == "")             //A primeira tecla só pode ser uma letra
            {
                if (!char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32)     //Após a primeira letra, as únicas teclas ue funcionarão são as de letras, backspace e barra de espaço
                {
                    e.Handled = true;
                }
            }
        }

        private void tabMembros_Enter(object sender, EventArgs e)    
        {
            txtNome.Focus();
            
            TabelaMembros();
                                              
            txtNome.Clear();                      
            cbFuncao.SelectedIndex = -1;                  
            cbRelacao.SelectedIndex = -1;                     
            cbMembrosPesquisar.SelectedIndex = -1;                  
            txtNomePesquisar.Clear();
            txtNomePesquisar.Visible = false;      
            cbSituacaoPesquisar.SelectedIndex = -1;         
            cbSituacaoPesquisar.Visible = false;            
        }

        private void btnMembrosSalvar_Click(object sender, EventArgs e)   //Salvar membros da clínica
        {
            if (txtNome.Text == "" || cbFuncao.Text == ""|| cbRelacao.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var botao = MessageBox.Show("Confirmar a inserção de um novo membro da clínica?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                SqlConnection conexao = null;

                if (botao == DialogResult.Yes)
                {
                    try
                    {
                        Membros membros = new Membros(txtNome.Text, cbFuncao.Text, cbRelacao.Text, "Ativa");

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT membro_nome FROM tb_membros WHERE membro_nome = @nome;", conexao);

                        pesquisar.Parameters.AddWithValue("@nome", membros.Nome);

                        conexao.Open();

                        SqlDataReader registros = pesquisar.ExecuteReader();

                        if (registros.HasRows)
                        {
                            MessageBox.Show("Nome já cadastrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);     //Serão barrados membros com nomes iguais

                            registros.Close();
                            conexao.Close();
                        }
                        else
                        {
                            registros.Close();

                            SqlCommand inserir = new SqlCommand("INSERT INTO tb_membros VALUES (@nome, @funcao, @relacao, @situacao);", conexao);

                            inserir.Parameters.AddWithValue("@nome", membros.Nome);
                            inserir.Parameters.AddWithValue("@funcao", membros.Funcao);                            
                            inserir.Parameters.AddWithValue("@relacao", membros.Relacao);
                            inserir.Parameters.AddWithValue("@situacao", membros.Situacao);

                            inserir.ExecuteNonQuery();

                            conexao.Close();

                            MessageBox.Show("Novo membro da clínica inserido com sucesso", "Operação bem sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtNome.Clear();
                            cbFuncao.SelectedIndex = -1;                            
                            cbRelacao.SelectedIndex = -1;

                            TabelaMembros();
                        }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conexao != null && conexao.State != ConnectionState.Closed)
                        {
                            conexao.Close();
                        }
                    }
                }
            }
        }

        private void dgvMembros_DoubleClick(object sender, EventArgs e)
        {
            if (dgvMembros.SelectedRows.Count == 1)
            {
                frmMembrosAlterarDeletar membrosAlterarDeletar = new frmMembrosAlterarDeletar(dgvMembros.SelectedRows[0].Cells[1].Value.ToString(), dgvMembros.SelectedRows[0].Cells[2].Value.ToString(), dgvMembros.SelectedRows[0].Cells[3].Value.ToString(), dgvMembros.SelectedRows[0].Cells[4].Value.ToString(), dgvMembros.SelectedRows[0].Cells[0].Value.ToString());

                if (cbPagamentosBrutoMes.Text != "" && txtPagamentosBrutoAno.Text  != "")
                {
                    membrosAlterarDeletar.Mes = cbPagamentosBrutoMes.Text;
                    membrosAlterarDeletar.Ano = txtPagamentosBrutoAno.Text;
                }

                membrosAlterarDeletar.Show();
                this.Hide();
            }            
        }

        private void cbMembrosPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMembrosPesquisar.Text == "Nome")
            {
                txtNomePesquisar.Visible = true;
                cbSituacaoPesquisar.Visible = false;

                txtNomePesquisar.Clear();
            }
            else if (cbMembrosPesquisar.Text == "Situação")
            {
                txtNomePesquisar.Visible = false;
                cbSituacaoPesquisar.Visible = true;

                cbSituacaoPesquisar.SelectedIndex = -1; 
            }
        }

        private void txtNomePesquisar_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("Select * FROM tb_membros WHERE membro_nome LIKE @nome ORDER BY membro_nome", conexao);

                pesquisar.Parameters.AddWithValue("@nome", '%' + txtNomePesquisar.Text + '%');

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                dgvMembros.DataSource = tabela;
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }

        private void cbSituacaoPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conexao = null;

            try
            {
                Membros membros = new Membros(cbSituacaoPesquisar.Text);

                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_Membros WHERE membro_situacao = @situacao ORDER BY membro_nome", conexao);

                pesquisar.Parameters.AddWithValue("@situacao", membros.Situacao);

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                dgvMembros.DataSource = tabela;
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }

        private void txtNomePesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNomePesquisar.Text == "")
            {
                if (!char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32)
                {
                    e.Handled = true;
                }
            }
        }


        //Aba 'Pagamentos - valor bruto'
       //Nesta aba serão informados os valores que cada membro da clínica recebe mensalmente

       
        private void tabPagamentosBruto_Enter(object sender, EventArgs e)
        {
           
            TabelaPagamentosBruto();
            
            cbPagamentosBrutoMembros.SelectedIndex = -1;                 
            txtPagamentosBrutoValor.Clear();                                   
            cbPagamentosBrutoPesquisar.SelectedIndex = -1;                    
            cbPagamentosBrutoPesquisarMes.SelectedIndex = -1;
            cbPagamentosBrutoPesquisarMes.Visible = false;
            txtPagamentosBrutoPesquisarAno.Clear();
            txtPagamentosBrutoPesquisarAno.Visible = false;
            txtPagamentosBrutoPesquisarNome.Clear();
            txtPagamentosBrutoPesquisarNome.Visible = false;
            btnPagamentosBrutoPesquisar.Visible = false;
        }

        private void cbPagamentosBrutoMembros_DropDown(object sender, EventArgs e)   //Os nomes a serem inseridos na tabela de pagamentos (valor bruto) serão carregados do banco de dados. É necessário que o membro esteja com a situação como 'Ativa' na tabela da aba 'Membros da clínica' para que seu nome apareça neste menu
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT membro_id, membro_nome FROM tb_membros WHERE membro_situacao = 'Ativa' ORDER BY membro_nome;", conexao);

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                cbPagamentosBrutoMembros.ValueMember = "membro_id";
                cbPagamentosBrutoMembros.DisplayMember = "membro_nome";
                cbPagamentosBrutoMembros.DataSource = tabela;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        } 

        private void txtPagamentosBrutoValor_KeyPress(object sender, KeyPressEventArgs e)     //Restrições no que pode ser digitado na área de informar o valor do pagamento
        {
            if (txtPagamentosBrutoValor.Text == "")      //Quando a área estiver vazia, só poderão ser informados números
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtPagamentosBrutoValor.Text.Contains(',')) //Quando houver uma vírgula, só serão aceitos números e o uso da tecla de backspace. E só poderá ser informado números com no máximo duas casas decimais     
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)   
                {
                    e.Handled = true;
                }

                if (txtPagamentosBrutoValor.Text.Substring(txtPagamentosBrutoValor.Text.IndexOf(',')).Length == 3)    
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtPagamentosBrutoValor.Text == "0")   //Caso o primeiro número informado for o número zero (0), as únicas teclas aceitas serão a vírgula e o backspace    
            {
                if (e.KeyChar != ',' && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
            else    //Após informar o primeiro número (que não seja o zero), só serão aceitas as teclas de número, vírgula, e backspace
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtPagamentosBrutoAno_KeyPress(object sender, KeyPressEventArgs e)   //Restrições no que pode ser digitado na área do ano do pagamento
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 || txtPagamentosBrutoAno.Text.Length == 4 && e.KeyChar != 8)  //Só será aceito números, e não poderão ter mais de quatro dígitos
            {
                e.Handled = true;
            }
        }

        private void btnPagamentosBrutoSalvar_Click(object sender, EventArgs e)
        {
            if (cbPagamentosBrutoMembros.Text == "" || txtPagamentosBrutoValor.Text == "" || cbPagamentosBrutoMes.Text == "" || txtPagamentosBrutoAno.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDecimal(txtPagamentosBrutoAno.Text) < 2000 || Convert.ToDecimal(txtPagamentosBrutoAno.Text) > 2099)
            {
                MessageBox.Show("O ano informado não é válido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var botao = MessageBox.Show("Confirmar a inserção de dados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                SqlConnection conexao = null;

                if (botao == DialogResult.Yes)
                {
                    try
                    {
                        PagamentosBruto pagamentos = new PagamentosBruto(Convert.ToInt32(cbPagamentosBrutoMembros.SelectedValue), Convert.ToDecimal(txtPagamentosBrutoValor.Text), cbPagamentosBrutoMes.Text, txtPagamentosBrutoAno.Text);

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        conexao.Open();
                        
                        SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_membro = @membro AND pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano", conexao);    //Um membro da clínica só pode ter um registro por mês

                        pesquisar.Parameters.AddWithValue("@membro", pagamentos.Membro);
                        pesquisar.Parameters.AddWithValue("@mes", pagamentos.Mes);
                        pesquisar.Parameters.AddWithValue("@ano", pagamentos.Ano);

                        SqlDataReader registros = pesquisar.ExecuteReader();

                        if (registros.HasRows)
                        {
                            MessageBox.Show("Já há um registro com este membro da clínica nesta data", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            registros.Close();
                            conexao.Close();
                        }
                        else
                        {
                            registros.Close();

                            SqlCommand pesquisar2 = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_socios WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                            pesquisar2.Parameters.AddWithValue("@mes", pagamentos.Mes);
                            pesquisar2.Parameters.AddWithValue("@ano", pagamentos.Ano);

                            SqlCommand pesquisar3 = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_nao_socios WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                            pesquisar3.Parameters.AddWithValue("@mes", pagamentos.Mes);
                            pesquisar3.Parameters.AddWithValue("@ano", pagamentos.Ano);

                            SqlCommand pesquisar4 = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_secretaria WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                            pesquisar4.Parameters.AddWithValue("@mes", pagamentos.Mes);
                            pesquisar4.Parameters.AddWithValue("@ano", pagamentos.Ano);

                            int quantidade = Convert.ToInt32(pesquisar2.ExecuteScalar());
                            int quantidade2 = Convert.ToInt32(pesquisar3.ExecuteScalar());
                            int quantidade3 = Convert.ToInt32(pesquisar4.ExecuteScalar());

                            if (quantidade > 0 || quantidade2 > 0 || quantidade3 > 0)
                            {
                                MessageBox.Show("Os pagamentos (valor líquido) deste mês e ano já foram calculados. Remova-os para poder adicionar outro pagamento (valor bruto)", "Atenção", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                
                                conexao.Close();
                            }
                            else
                            {                              
                                SqlCommand inserir = new SqlCommand("INSERT INTO tb_pagamentos_valor_bruto VALUES (@membro, @valor, @mes, @ano);", conexao);

                                inserir.Parameters.AddWithValue("@membro", pagamentos.Membro);
                                inserir.Parameters.AddWithValue("@valor", pagamentos.Valor);
                                inserir.Parameters.AddWithValue("@mes", pagamentos.Mes);
                                inserir.Parameters.AddWithValue("@ano", pagamentos.Ano);

                                inserir.ExecuteNonQuery();

                                conexao.Close();

                                MessageBox.Show("Novo pagamento inserido com sucesso", "Operação bem sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                cbPagamentosBrutoMembros.SelectedIndex = -1;
                                txtPagamentosBrutoValor.Clear();

                                TabelaPagamentosBruto();
                            }
                        }            
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conexao != null && conexao.State != ConnectionState.Closed)
                        {
                            conexao.Close();
                        }
                    }
                }
            }
        }

        private void dgvPagamentosBruto_DoubleClick(object sender, EventArgs e)
        {
            if (dgvPagamentosBruto.SelectedRows.Count == 1)
            {
                frmPagamentosBrutoAlterarDeletar pagamentos = new frmPagamentosBrutoAlterarDeletar(dgvPagamentosBruto.SelectedRows[0].Cells[1].Value.ToString(), dgvPagamentosBruto.SelectedRows[0].Cells[2].Value.ToString(), dgvPagamentosBruto.SelectedRows[0].Cells[3].Value.ToString(), dgvPagamentosBruto.SelectedRows[0].Cells[4].Value.ToString(), dgvPagamentosBruto.SelectedRows[0].Cells[0].Value.ToString());

                if (cbPagamentosBrutoMes.Text != "" && txtPagamentosBrutoAno.Text != "")
                {
                    pagamentos.Mes = cbPagamentosBrutoMes.Text;
                    pagamentos.Ano = txtPagamentosBrutoAno.Text;
                }

                pagamentos.Show();
                this.Hide();
            }           
        }

        private void cbPagamentosBrutoPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPagamentosBrutoPesquisar.Text == "Data")
            {
                cbPagamentosBrutoPesquisarMes.Visible = true;
                txtPagamentosBrutoPesquisarAno.Visible = true;
                txtPagamentosBrutoPesquisarNome.Visible = false;

                cbPagamentosBrutoPesquisarMes.SelectedIndex = -1;
                txtPagamentosBrutoPesquisarAno.Clear();

                btnPagamentosBrutoPesquisar.Visible = true;
            }
            else if (cbPagamentosBrutoPesquisar.Text == "Nome")
            {
                cbPagamentosBrutoPesquisarMes.Visible = false;
                txtPagamentosBrutoPesquisarAno.Visible = false;
                txtPagamentosBrutoPesquisarNome.Visible = true;

                txtPagamentosBrutoPesquisarNome.Clear();

                btnPagamentosBrutoPesquisar.Visible = false;
            }
        }

        private void txtPagamentosBrutoPesquisarAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 || txtPagamentosBrutoPesquisarAno.Text.Length == 4 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtPagamentosBrutoPesquisarNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPagamentosBrutoPesquisarNome.Text == "")
            {
                if (!char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32)
                {
                    e.Handled = true;
                }
            }
        }

        private void btnPagamentosBrutoPesquisar_Click(object sender, EventArgs e)
        {
             if (cbPagamentosBrutoPesquisarMes.Text == "" || txtPagamentosBrutoPesquisarAno.Text == "")
             {
                 MessageBox.Show("Informe todas as informações para a pesquisa", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
             else if (Convert.ToDecimal(txtPagamentosBrutoPesquisarAno.Text) < 2000 || Convert.ToDecimal(txtPagamentosBrutoPesquisarAno.Text) > 2099)
             {
                 MessageBox.Show("Informe um ano válido para pesquisar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
             else
             {
                SqlConnection conexao = null;

                try
                {
                     PagamentosBruto pagamentos = new PagamentosBruto(cbPagamentosBrutoPesquisarMes.Text, txtPagamentosBrutoPesquisarAno.Text);

                     conexao = new SqlConnection(StringConexao.stringConexao);

                     SqlCommand pesquisar = new SqlCommand("SELECT pagamento_bruto_id, membro_nome, pagamento_bruto_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_valor_bruto INNER JOIN tb_membros ON tb_pagamentos_valor_bruto.pagamento_bruto_membro = tb_membros.membro_id WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano ORDER BY membro_nome;", conexao);

                     pesquisar.Parameters.AddWithValue("@mes", pagamentos.Mes);
                     pesquisar.Parameters.AddWithValue("@ano", pagamentos.Ano);

                     conexao.Open();

                     SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                     conexao.Close();

                     DataTable tabela = new DataTable();

                     registros.Fill(tabela);

                     dgvPagamentosBruto.DataSource = tabela;
                }
                catch (Exception erro)
                {
                     MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conexao != null && conexao.State != ConnectionState.Closed)
                    {
                        conexao.Close();
                    }
                }
            }
                       
        }

        private void txtPagamentosBrutoPesquisarNome_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = conexao.CreateCommand();

                if (txtPagamentosBrutoPesquisarNome.Text != "")
                {
                    pesquisar.CommandText = "SELECT pagamento_bruto_id, membro_nome, pagamento_bruto_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_valor_bruto INNER JOIN tb_membros ON tb_pagamentos_valor_bruto.pagamento_bruto_membro = tb_membros.membro_id WHERE membro_nome LIKE @nome ORDER BY membro_nome, pagamento_bruto_ano, pagamento_bruto_mes";

                    pesquisar.Parameters.AddWithValue("@nome", '%' + txtPagamentosBrutoPesquisarNome.Text + '%');
                }
                else
                {
                    pesquisar.CommandText = "SELECT pagamento_bruto_id, membro_nome, pagamento_bruto_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_valor_bruto INNER JOIN tb_membros ON tb_pagamentos_valor_bruto.pagamento_bruto_membro = tb_membros.membro_id ORDER BY pagamento_bruto_ano, pagamento_bruto_mes, membro_nome;";
                }               

               conexao.Open();

               SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

               conexao.Close();

               DataTable tabela = new DataTable();

               registros.Fill(tabela);

               dgvPagamentosBruto.DataSource = tabela;
            }
            catch (Exception erro)
            {
              MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }


        //Aba 'Imposto'
        //Nesta aba, será calculado o valor do imposto sobre o pagamento (valor bruto), informado na aba 'Pagamentos - valor bruto' que consiste em uma porcentagem sobre o pagamento. O imposto é pago pelos psicólogos e psiquiatras

        private void tabImposto_Enter(object sender, EventArgs e)
        {
            TabelaImpostos();

            if (cbPagamentosBrutoMes.Text != "" && txtPagamentosBrutoAno.Text != "")
            {
                cbImpostoMes.Text = cbPagamentosBrutoMes.Text;
                txtImpostoAno.Text = txtPagamentosBrutoAno.Text;
            }
            else
            {
                cbImpostoMes.SelectedIndex = -1;
                txtImpostoAno.Clear();
            }

            cbImpostoNome.SelectedIndex = -1;
            txtImpostoTaxa.Clear();
            cbImpostoPesquisar.SelectedIndex = -1;
            cbImpostoPesquisarMes.SelectedIndex = -1;
            cbImpostoPesquisarMes.Visible = false;
            txtImpostoPesquisarAno.Clear();
            txtImpostoPesquisarAno.Visible = false;
            txtImpostoPesquisarNome.Clear();
            txtImpostoPesquisarNome.Visible = false;
            btnImpostoPesquisar.Visible = false;
        }

        private void txtImpostoAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 || txtImpostoAno.Text.Length == 4 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtImpostoTaxa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtImpostoTaxa.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtImpostoTaxa.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtImpostoTaxa.Text.Substring(txtImpostoTaxa.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtImpostoTaxa.Text == "0")
            {
                if (e.KeyChar != ',' && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtImpostoTaxa.Text.Length == 2 && txtImpostoTaxa.Text.EndsWith(",") == false)
                {
                    if (e.KeyChar != 8 && e.KeyChar != ',')
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void cbImpostoMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbImpostoNome.SelectedIndex != -1)
            {
                cbImpostoNome.SelectedIndex = -1;
            }
        }

        private void txtImpostoAno_TextChanged(object sender, EventArgs e)
        {
            if (cbImpostoNome.SelectedIndex != -1)
            {
                cbImpostoNome.SelectedIndex = -1;
            }
        }

        private void btnImpostoSalvar_Click(object sender, EventArgs e)
        {
            if (cbImpostoMes.Text == "" || txtImpostoAno.Text == "" || cbImpostoNome.Text == "" || txtImpostoTaxa.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var botao = MessageBox.Show("Confirmar a inserção de dados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                SqlConnection conexao = null;

                if (botao == DialogResult.Yes)
                {
                    try
                    {
                        PagamentosBruto pagamento = new PagamentosBruto(Convert.ToInt32(cbImpostoNome.SelectedValue), cbImpostoMes.Text, txtImpostoAno.Text);    //A data da tabela imposto é herdada da tabela de pagamentos (valor bruto). Também desta tabela de pagamentos será pego o valor do pagamento

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT pagamento_bruto_id, pagamento_bruto_valor FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_membro = @membro AND pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano", conexao);

                        pesquisar.Parameters.AddWithValue("@membro", pagamento.Membro);
                        pesquisar.Parameters.AddWithValue("@mes", pagamento.Mes);
                        pesquisar.Parameters.AddWithValue("@ano", pagamento.Ano);

                        conexao.Open();

                        SqlDataReader registros = pesquisar.ExecuteReader();

                        registros.Read();

                        int id = Convert.ToInt32(registros["pagamento_bruto_id"]);
                        decimal pagamentoMensal = Convert.ToDecimal(registros["pagamento_bruto_valor"]);

                        registros.Close();

                        decimal calculo = Convert.ToDecimal(txtImpostoTaxa.Text) / 100;    //Cálculo do imposto. Consiste em calcular a porcentagem informada em cima do valor informado na tabela de pagamentos (valor bruto) do mesmo mês, ano e nome
                        decimal impostoValor = pagamentoMensal * calculo;

                        Impostos imposto = new Impostos(Convert.ToInt32(cbImpostoNome.SelectedValue), Convert.ToDecimal(txtImpostoTaxa.Text), id, impostoValor, id, id);

                        SqlCommand pesquisar2 = new SqlCommand("SELECT * FROM tb_impostos WHERE imposto_membro = @membro AND imposto_mes = @mes AND imposto_ano = @ano", conexao);

                        pesquisar2.Parameters.AddWithValue("@membro", imposto.Membro);
                        pesquisar2.Parameters.AddWithValue("@mes", imposto.Mes);
                        pesquisar2.Parameters.AddWithValue("@ano", imposto.Ano);

                        SqlDataReader registros2 = pesquisar2.ExecuteReader();

                        if (registros2.HasRows)
                        {
                            MessageBox.Show("O imposto deste membro da clínica desta data já foi informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);   //O mesmo membro da clínica não pode ser inserido duas vezes na mesma data

                            registros2.Close();
                            conexao.Close();
                        }
                        else
                        {
                            registros2.Close();

                            SqlCommand inserir = new SqlCommand("INSERT INTO tb_impostos VALUES (@membro, @taxa, @pagamento, @imposto, @mes, @ano)", conexao);

                            inserir.Parameters.AddWithValue("@membro", imposto.Membro);
                            inserir.Parameters.AddWithValue("@taxa", imposto.Taxa);
                            inserir.Parameters.AddWithValue("@pagamento", imposto.Pagamento);
                            inserir.Parameters.AddWithValue("@imposto", imposto.Valor);
                            inserir.Parameters.AddWithValue("@mes", imposto.Mes);
                            inserir.Parameters.AddWithValue("@ano", imposto.Ano);

                            inserir.ExecuteNonQuery();

                            conexao.Close();

                            MessageBox.Show("Novo imposto inserido com sucesso", "Operação bem sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            cbImpostoNome.SelectedIndex = -1;
                            txtImpostoTaxa.Clear();

                            TabelaImpostos();
                        }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conexao != null && conexao.State != ConnectionState.Closed)
                        {
                            conexao.Close();
                        }
                    }
                }
            }
        }        

        private void cbImpostoNome_DropDown(object sender, EventArgs e)   //Os nomes dos membros da clínica disponíveis serão os que que estão registrados com a função de 'Psiquiatria e/ou psicologia' e possuem registros de pagamentos na aba 'Pagamentos - valor bruto' na data informada
        {
            if (cbImpostoMes.Text == "" || txtImpostoAno.Text == "")
            {
                MessageBox.Show("Informe o mês e o ano no qual o imposto se refere", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDecimal(txtImpostoAno.Text) < 2000 || Convert.ToDecimal(txtImpostoAno.Text) > 2099)
            {
                MessageBox.Show("Informe um ano válido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cbImpostoNome.DataSource = null;
            }
            else
            {
                SqlConnection conexao = null;

                try
                {
                    PagamentosBruto pagamentos = new PagamentosBruto(cbImpostoMes.Text, txtImpostoAno.Text);

                    conexao = new SqlConnection(StringConexao.stringConexao);

                    SqlCommand pesquisar = new SqlCommand("SELECT membro_id, membro_nome FROM tb_pagamentos_valor_bruto INNER JOIN tb_membros ON tb_pagamentos_valor_bruto.pagamento_bruto_membro = tb_membros.membro_id WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano AND NOT membro_funcao = 'Secretaria' ORDER BY membro_nome;", conexao);

                    pesquisar.Parameters.AddWithValue("@mes", pagamentos.Mes);
                    pesquisar.Parameters.AddWithValue("@ano", pagamentos.Ano);

                    SqlDataAdapter registros2 = new SqlDataAdapter(pesquisar);

                    conexao.Close();

                    DataTable tabela = new DataTable();

                    registros2.Fill(tabela);

                    cbImpostoNome.ValueMember = "membro_id";
                    cbImpostoNome.DisplayMember = "membro_nome";
                    cbImpostoNome.DataSource = tabela;

                    if (tabela.Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum pagamento desta data foi informado");
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conexao != null && conexao.State != ConnectionState.Closed)
                    {
                        conexao.Close();
                    }
                }
            }
        }

        private void dgvImpostos_DoubleClick(object sender, EventArgs e)
        {
            if (dgvImpostos.SelectedRows.Count == 1)
            {
                frmImpostoAlterarDeletar impostos = new frmImpostoAlterarDeletar(dgvImpostos.SelectedRows[0].Cells[5].Value.ToString(), dgvImpostos.SelectedRows[0].Cells[6].Value.ToString(), dgvImpostos.SelectedRows[0].Cells[1].Value.ToString(), dgvImpostos.SelectedRows[0].Cells[2].Value.ToString(), dgvImpostos.SelectedRows[0].Cells[0].Value.ToString());

                if (cbPagamentosBrutoMes.Text != "" && txtPagamentosBrutoAno.Text != "")
                {
                    impostos.Mes = cbPagamentosBrutoMes.Text;
                    impostos.Ano = txtPagamentosBrutoAno.Text;
                }

                impostos.Show();
                this.Hide();
            }           
        }

        private void cbImpostoPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbImpostoPesquisar.Text == "Data")
            {
                cbImpostoPesquisarMes.Visible = true;
                txtImpostoPesquisarAno.Visible = true;
                txtImpostoPesquisarNome.Visible = false;

                cbImpostoPesquisarMes.SelectedIndex = -1;
                txtImpostoPesquisarAno.Clear();

                btnImpostoPesquisar.Visible = true;
            }
            else if (cbImpostoPesquisar.Text == "Nome")
            {
                cbImpostoPesquisarMes.Visible = false;
                txtImpostoPesquisarAno.Visible = false;
                txtImpostoPesquisarNome.Visible = true;

                txtImpostoPesquisarNome.Clear();

                btnImpostoPesquisar.Visible = false;
            }
        }

        private void txtImpostoPesquisarAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 || txtImpostoPesquisarAno.Text.Length == 4 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtImpostoPesquisarNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtImpostoPesquisarNome.Text == "")
            {
                if (!char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32)
                {
                    e.Handled = true;
                }
            }
        }

        private void btnImpostoPesquisar_Click(object sender, EventArgs e)
        {
            if (cbImpostoPesquisarMes.Text == "" || txtImpostoPesquisarAno.Text == "")
            {
                MessageBox.Show("Informe todas as informações para a pesquisa", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDecimal(txtImpostoPesquisarAno.Text) < 2000 || (Convert.ToDecimal(txtImpostoPesquisarAno.Text) > 2099))
            {
                MessageBox.Show("Informe um ano válido para pesquisar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection conexao = null;

                try
                {
                    PagamentosBruto pagamentos = new PagamentosBruto(cbImpostoPesquisarMes.Text, txtImpostoPesquisarAno.Text);

                    conexao = new SqlConnection(StringConexao.stringConexao);

                    SqlCommand pesquisar = new SqlCommand("SELECT imposto_id, membro_nome, imposto_taxa, pagamento_bruto_valor, imposto_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_impostos INNER JOIN tb_membros ON tb_impostos.imposto_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_impostos.pagamento_mensal_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano ORDER BY membro_nome;", conexao);

                    pesquisar.Parameters.AddWithValue("@mes", pagamentos.Mes);
                    pesquisar.Parameters.AddWithValue("@ano", pagamentos.Ano);

                    conexao.Open();

                    SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                    conexao.Close();

                    DataTable tabela = new DataTable();

                    registros.Fill(tabela);

                    dgvImpostos.DataSource = tabela;
                }
                catch(Exception erro)
                {
                    MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conexao != null && conexao.State != ConnectionState.Closed)
                    {
                        conexao.Close();
                    }
                }
            }
        }

        private void txtImpostoPesquisarNome_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = conexao.CreateCommand();

                if (txtImpostoPesquisarNome.Text != "")
                {
                    pesquisar.CommandText = "SELECT imposto_id, membro_nome, imposto_taxa, pagamento_bruto_valor, imposto_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_impostos INNER JOIN tb_membros ON tb_impostos.imposto_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_impostos.pagamento_mensal_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id WHERE membro_nome LIKE @nome ORDER BY membro_nome, pagamento_bruto_ano, pagamento_bruto_mes;";

                    pesquisar.Parameters.AddWithValue("@nome", '%' + txtImpostoPesquisarNome.Text + '%');
                }
                else
                {
                    pesquisar.CommandText = "SELECT imposto_id, membro_nome, imposto_taxa, pagamento_bruto_valor, imposto_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_impostos INNER JOIN tb_membros ON tb_impostos.imposto_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_impostos.pagamento_mensal_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id ORDER BY pagamento_bruto_ano, pagamento_bruto_mes, membro_nome;";
                }                 

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                dgvImpostos.DataSource = tabela;
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }


        //Aba Condomínio
        //Cada membro da clínica que seja psicólogo/psiquiatra e não seja sócio deve pagar uma parcela dos gastos de condomínio. A aba conterá três partes

        private void tabCondominio_Enter(object sender, EventArgs e)
        {
            TabelaCondominioGastos();

            if (txtCondominioAba.Text == "parte2")
            {
                rbCondominioHoras.Checked = true;
            }
            else
            {
                rbCondominioMensal.Checked = true;
            }

            if (cbPagamentosBrutoMes.Text != "" && txtPagamentosBrutoAno.Text != "")
            {
                cbCondominioMes.Text = cbPagamentosBrutoMes.Text;
                txtCondominioAno.Text = txtPagamentosBrutoAno.Text;
            }
            else
            {
                cbCondominioMes.SelectedIndex = -1;
                txtCondominioAno.Clear();
            }

            cbCondominioNome.SelectedIndex = -1;
            txtCondominioHoras.Clear();
            cbCondominioPesquisarMes.SelectedIndex = -1;
            cbCondominioPesquisarMes.Visible = false;
            txtCondominioPesquisarAno.Clear();
            txtCondominioPesquisarAno.Visible = false;
            btnCondominioPesquisar.Visible = false;
            btnCondominioGastosPesquisarImprimir.Visible = false;
            cbCondominioPesquisar.SelectedIndex = -1;
        }

        private void tabCondominio_Leave(object sender, EventArgs e)
        {
            txtCondominioAba.Clear();
        }

        private void rbCondominioMensal_CheckedChanged(object sender, EventArgs e)   //Na primeira parte será informado os gastos de condomínio
        {
            lblCondominioGastos.Visible = true;
            lblCondominioHoras.Visible = false;
            lblCondominioMembros.Visible = false;         
                     
            lblCondominioInserir.Visible = true;
            btnCondominioInserir.Visible = true;

            lblCondominioMes.Visible = false;
            cbCondominioMes.Visible = false;
            lblCondominioAno.Visible = false;
            txtCondominioAno.Visible = false;
            lblCondominioHorasNome.Visible = false;
            cbCondominioNome.Visible = false;
            lblCondominioHorasTrabalhadas.Visible = false;
            txtCondominioHoras.Visible = false;

            dgvCondominio.Width = 848;
            dgvCondominio.Left = 31;

            btnCondominioSalvar.Visible = false;
            btnCondominioDeletar.Visible = false;

            btnCondominioGastosImprimir.Visible = true;

            cbCondominioPesquisar.SelectedIndex = -1;

            cbCondominioPesquisar.Items.Clear();
            cbCondominioPesquisar.Items.Add("Mês e ano");
            cbCondominioPesquisar.Items.Add("Ano");

            cbCondominioPesquisarMes.Visible = false;
            txtCondominioPesquisarAno.Visible = false;
            txtCondominioPesquisarNome.Visible = false;

            btnCondominioPesquisar.Visible = false;
            btnCondominioGastosPesquisarImprimir.Visible = false;

            txtCondominioAba.Clear();
 
            TabelaCondominioGastos();           
        }

        private void rbCondominioHoras_CheckedChanged(object sender, EventArgs e)    //Na segunda parte será informado as horas trabalhadas de cada membro da clínica
        {
            lblCondominioGastos.Visible = false;
            lblCondominioHoras.Visible = true;
            lblCondominioMembros.Visible = false;          
   
            lblCondominioInserir.Visible = false;
            btnCondominioInserir.Visible = false;

            lblCondominioMes.Visible = true;
            cbCondominioMes.Visible = true;
            lblCondominioAno.Visible = true;
            txtCondominioAno.Visible = true;
            lblCondominioHorasNome.Visible = true;
            cbCondominioNome.Visible = true;
            lblCondominioHorasTrabalhadas.Visible = true;
            txtCondominioHoras.Visible = true;
            
            cbCondominioNome.SelectedIndex = -1;
            txtCondominioHoras.Clear();

            dgvCondominio.Width = 433;
            dgvCondominio.Left = 235;

            btnCondominioSalvar.Left = 382;

            btnCondominioSalvar.Visible = true;
            btnCondominioDeletar.Visible = false;

            btnCondominioGastosImprimir.Visible = false;

            cbCondominioPesquisar.SelectedIndex = -1;
            
            cbCondominioPesquisar.Items.Clear();
            cbCondominioPesquisar.Items.Add("Data");
            cbCondominioPesquisar.Items.Add("Nome");

            cbCondominioPesquisarMes.Visible = false;
            txtCondominioPesquisarAno.Visible = false;
            txtCondominioPesquisarNome.Visible = false;

            btnCondominioPesquisar.Visible = false;
            btnCondominioGastosPesquisarImprimir.Visible = false;

            TabelaCondominioHoras();
        }

        private void rbCondominioMembros_CheckedChanged(object sender, EventArgs e)    //Na terceira parte será calculado o valor de condomínio que deverá ser pago por cada membro da clínica
        {
            lblCondominioGastos.Visible = false;
            lblCondominioHoras.Visible = false;
            lblCondominioMembros.Visible = true;

            lblCondominioInserir.Visible = false;
            btnCondominioInserir.Visible = false;

            lblCondominioMes.Visible = true;
            cbCondominioMes.Visible = true;
            lblCondominioAno.Visible = true;
            txtCondominioAno.Visible = true;
            lblCondominioHorasNome.Visible = false;
            cbCondominioNome.Visible = false;
            lblCondominioHorasTrabalhadas.Visible = false;
            txtCondominioHoras.Visible = false;           

            dgvCondominio.Width = 635;
            dgvCondominio.Left = 135;

            btnCondominioSalvar.Left = 135;

            btnCondominioSalvar.Visible = true;
            btnCondominioDeletar.Visible = true;

            btnCondominioGastosImprimir.Visible = false;

            cbCondominioPesquisar.SelectedIndex = -1;
            cbCondominioPesquisar.Items.Clear();
            cbCondominioPesquisar.Items.Add("Data");
            cbCondominioPesquisar.Items.Add("Nome");

            cbCondominioPesquisarMes.Visible = false;
            txtCondominioPesquisarAno.Visible = false;
            txtCondominioPesquisarNome.Visible = false;

            btnCondominioPesquisar.Visible = false;
            btnCondominioGastosPesquisarImprimir.Visible = false;

            txtCondominioAba.Clear();
         
            TabelaCondominioMembros();       
        }        

        private void btnCondominioInserir_Click(object sender, EventArgs e)
        {
            frmCondominioGastos condominio = new frmCondominioGastos();

            condominio.Alterar = false;
            condominio.Deletar = false;
            condominio.Text = "Condomínio - Gasto mensal";

            if (cbPagamentosBrutoMes.Text != "" && txtPagamentosBrutoAno.Text != "")
            {
                condominio.Mes = cbPagamentosBrutoMes.Text;
                condominio.Ano = txtPagamentosBrutoAno.Text;

                condominio.MesContabilidade = cbPagamentosBrutoMes.Text;
                condominio.AnoContabilidade = txtPagamentosBrutoAno.Text;
            }

            condominio.Show();
            this.Hide();
        }        

        private void cbPesquisarCondominioGastos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbCondominioMensal.Checked)
            {
                if (cbCondominioPesquisar.Text == "Mês e ano")
                {
                    cbCondominioPesquisarMes.Visible = true;
                    txtCondominioPesquisarAno.Visible = true;

                    cbCondominioPesquisarMes.SelectedIndex = -1;
                    txtCondominioPesquisarAno.Clear();

                    btnCondominioPesquisar.Visible = true;
                }
                else if (cbCondominioPesquisar.Text == "Ano")
                {
                    cbCondominioPesquisarMes.Visible = false;
                    txtCondominioPesquisarAno.Visible = true;

                    txtCondominioPesquisarAno.Clear();

                    btnCondominioPesquisar.Visible = true;
                }

                btnCondominioGastosPesquisarImprimir.Visible = false;
            }
            else if (rbCondominioHoras.Checked || rbCondominioMembros.Checked)
            {
                if (cbCondominioPesquisar.Text == "Data")
                {
                    cbCondominioPesquisarMes.Visible = true;
                    txtCondominioPesquisarAno.Visible = true;

                    cbCondominioPesquisarMes.SelectedIndex = -1;
                    txtCondominioPesquisarAno.Clear();

                    txtCondominioPesquisarNome.Visible = false;

                    btnCondominioPesquisar.Visible = true;
                }
                else if (cbCondominioPesquisar.Text == "Nome")
                {
                    cbCondominioPesquisarMes.Visible = false;
                    txtCondominioPesquisarAno.Visible = false;

                    txtCondominioPesquisarNome.Visible = true;

                    txtCondominioPesquisarNome.Clear();

                    btnCondominioPesquisar.Visible = false;
                }
            }            
        }

        private void txtCondominioPesquisarAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 || txtCondominioPesquisarAno.Text.Length == 4 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtCondominioPesquisarNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCondominioPesquisarNome.Text == "")
            {
                if (!char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32)
                {
                    e.Handled = true;
                }
            }
        }

        private void cbCondominioPesquisarMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCondominioGastosPesquisarImprimir.Visible = false;
        }

        private void txtCondominioPesquisarAno_TextChanged(object sender, EventArgs e)
        {
            btnCondominioGastosPesquisarImprimir.Visible = false;
        }

        private void btnCondominioSalvar_Click(object sender, EventArgs e)
        {
            if (rbCondominioHoras.Checked)   //Informar as horas trabalhadas de cada membro da clínica
            {
                if (cbCondominioMes.Text == "" || txtCondominioAno.Text == "" || cbCondominioNome.Text == "" || txtCondominioHoras.Text == "")
                {
                    MessageBox.Show("Preencha todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var botao = MessageBox.Show("Confirmar a inserção de dados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    SqlConnection conexao = null;

                    if (botao == DialogResult.Yes)
                    {
                        try
                        {
                            CondominioHoras condominio = new CondominioHoras(Convert.ToInt32(cbCondominioNome.SelectedValue), Convert.ToInt32(txtCondominioHoras.Text), cbCondominioMes.Text, txtCondominioAno.Text);

                            conexao = new SqlConnection(StringConexao.stringConexao);

                            SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_horas_trabalhadas WHERE horas_trabalhadas_membro = @membro AND horas_trabalhadas_mes = @mes AND horas_trabalhadas_ano = @ano;", conexao);

                            pesquisar.Parameters.AddWithValue("@membro", condominio.Membro);
                            pesquisar.Parameters.AddWithValue("@mes", condominio.Mes);
                            pesquisar.Parameters.AddWithValue("@ano", condominio.Ano);

                            conexao.Open();

                            SqlDataReader registros = pesquisar.ExecuteReader();

                            if (registros.HasRows)
                            {
                                MessageBox.Show("As horas trabalhadas deste membro da clínica já foi informada para esta data", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                registros.Close();
                                conexao.Close();
                            }
                            else
                            {
                                registros.Close();

                                SqlCommand inserir = new SqlCommand("INSERT INTO tb_horas_trabalhadas VALUES(@membro, @horas, @mes, @ano);", conexao);

                                inserir.Parameters.AddWithValue("@membro", condominio.Membro);
                                inserir.Parameters.AddWithValue("@horas", condominio.Horas);
                                inserir.Parameters.AddWithValue("@mes", condominio.Mes);
                                inserir.Parameters.AddWithValue("@ano", condominio.Ano);

                                inserir.ExecuteNonQuery();

                                conexao.Close();

                                MessageBox.Show("Informação sobre membro da clínica inserida com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                cbCondominioNome.SelectedIndex = -1;
                                txtCondominioHoras.Clear();

                                TabelaCondominioHoras();
                            }
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (conexao != null && conexao.State != ConnectionState.Closed)
                            {
                                conexao.Close();
                            }
                        }
                    }
                }
            }
            else if (rbCondominioMembros.Checked)   //Cálculo do valor de condomínio de cada membro da clínica
            {
                if (cbCondominioMes.Text == "" || txtCondominioAno.Text == "")
                {
                    MessageBox.Show("Preencha todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Convert.ToDecimal(txtCondominioAno.Text) < 2000 || Convert.ToDecimal(txtCondominioAno.Text) > 2099)
                {
                    MessageBox.Show("Informe um ano válido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var botao = MessageBox.Show("Confirmar a inserção de dados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    SqlConnection conexao = null;

                    if (botao == DialogResult.Yes)
                    {
                        try
                        {
                            CondominioHoras condominioHoras = new CondominioHoras(cbCondominioMes.Text, txtCondominioAno.Text);

                            conexao = new SqlConnection(StringConexao.stringConexao);

                            SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_condominio WHERE condominio_mes = @mes AND condominio_ano = @ano", conexao);

                            pesquisar.Parameters.AddWithValue("@mes", condominioHoras.Mes);
                            pesquisar.Parameters.AddWithValue("@ano", condominioHoras.Ano);

                            conexao.Open();

                            SqlDataReader registros = pesquisar.ExecuteReader();

                            if (registros.HasRows == false)
                            {
                                MessageBox.Show("Os gastos de condomínio deste mês e ano ainda não foram informados", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                registros.Close();
                                conexao.Close();
                            }
                            else
                            {
                                registros.Close();

                                SqlCommand pesquisarQuantidade = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_valor_bruto INNER JOIN tb_membros ON tb_pagamentos_valor_bruto.pagamento_bruto_membro = tb_membros.membro_id WHERE NOT membro_funcao = 'Secretaria' AND pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano;", conexao);

                                pesquisarQuantidade.Parameters.AddWithValue("@mes", condominioHoras.Mes);
                                pesquisarQuantidade.Parameters.AddWithValue("@ano", condominioHoras.Ano);

                                int pagamentosQuantidade = Convert.ToInt32(pesquisarQuantidade.ExecuteScalar());

                                SqlCommand pesquisarQuantidade2 = new SqlCommand("SELECT COUNT(*) FROM tb_horas_trabalhadas WHERE horas_trabalhadas_mes = @mes AND horas_trabalhadas_ano = @ano;", conexao);

                                pesquisarQuantidade2.Parameters.AddWithValue("@mes", condominioHoras.Mes);
                                pesquisarQuantidade2.Parameters.AddWithValue("@ano", condominioHoras.Ano);

                                int horasQuantidade = Convert.ToInt32(pesquisarQuantidade2.ExecuteScalar());

                                if (pagamentosQuantidade != horasQuantidade)
                                {
                                    MessageBox.Show("Faltam informar as horas trabalhadas de alguns membros da clínica deste mês e ano", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    conexao.Close();
                                }
                                else
                                {
                                    SqlCommand pesquisarCondominioTotal = new SqlCommand("SELECT condominio_id, condominio_valor_total FROM tb_condominio WHERE condominio_mes = @mes AND condominio_ano = @ano;", conexao);

                                    pesquisarCondominioTotal.Parameters.AddWithValue("@mes", condominioHoras.Mes);
                                    pesquisarCondominioTotal.Parameters.AddWithValue("@ano", condominioHoras.Ano);

                                    SqlDataReader registrosCondominioGastos = pesquisarCondominioTotal.ExecuteReader();

                                    registrosCondominioGastos.Read();

                                    CondominioGastos condominioGastos = new CondominioGastos(Convert.ToInt32(registrosCondominioGastos["condominio_id"]), Convert.ToDecimal(registrosCondominioGastos["condominio_valor_total"]), condominioHoras.Mes, condominioHoras.Ano);

                                    registrosCondominioGastos.Close();

                                    SqlCommand pesquisarHoras = new SqlCommand("SELECT SUM (horas_trabalhadas) FROM tb_horas_trabalhadas WHERE horas_trabalhadas_mes = @mes AND horas_trabalhadas_ano = @ano", conexao);    //Será tomado a soma das horas trabalhadas dos membros da clínica de um mês e ano

                                    pesquisarHoras.Parameters.AddWithValue("@mes", condominioHoras.Mes);
                                    pesquisarHoras.Parameters.AddWithValue("@ano", condominioHoras.Ano);

                                    CondominioHoraValor condominioHoraValor = new CondominioHoraValor(condominioGastos.Id, Convert.ToInt32(pesquisarHoras.ExecuteScalar()), condominioGastos.Total / Convert.ToDecimal(pesquisarHoras.ExecuteScalar()), condominioGastos.Id, condominioGastos.Id);    //O valor da hora de condomínio é determinado pela divisão do valor total de gastos de condomínio (informado na primeira parte) dividido pela soma das horas trabalhadas

                                    SqlCommand inserirHoraValor = new SqlCommand("INSERT INTO tb_condominio_hora_valor VALUES (@condominioTotal, @horasTotal, @valor, @mes, @ano);", conexao);

                                    inserirHoraValor.Parameters.AddWithValue("@condominioTotal", condominioHoraValor.CondominioTotal);
                                    inserirHoraValor.Parameters.AddWithValue("@horasTotal", condominioHoraValor.HorasTotal);
                                    inserirHoraValor.Parameters.AddWithValue("@valor", condominioHoraValor.Valor);
                                    inserirHoraValor.Parameters.AddWithValue("@mes", condominioHoraValor.Mes);
                                    inserirHoraValor.Parameters.AddWithValue("@ano", condominioHoraValor.Ano);

                                    inserirHoraValor.ExecuteNonQuery();


                                    SqlCommand pesquisarHoraValor = new SqlCommand("SELECT hora_valor_id FROM tb_condominio_hora_valor WHERE hora_valor_mes = @mes AND hora_valor_ano = @ano", conexao);

                                    pesquisarHoraValor.Parameters.AddWithValue("@mes", condominioGastos.Id);
                                    pesquisarHoraValor.Parameters.AddWithValue("@ano", condominioGastos.Id);

                                    condominioHoraValor.Id = Convert.ToInt32(pesquisarHoraValor.ExecuteScalar());


                                    CondominioMembros condominioMembros = new CondominioMembros(condominioHoraValor.Id);

                                    SqlCommand membrosQuantidade = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_valor_bruto INNER JOIN tb_membros ON tb_pagamentos_valor_bruto.pagamento_bruto_membro = tb_membros.membro_id WHERE NOT membro_funcao = 'Secretaria' AND pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano;", conexao);   //Coleta dos membros que pagarão condomínio

                                    membrosQuantidade.Parameters.AddWithValue("@mes", condominioGastos.Mes);
                                    membrosQuantidade.Parameters.AddWithValue("@ano", condominioGastos.Ano);

                                    int quantidade = Convert.ToInt32(membrosQuantidade.ExecuteScalar());

                                    SqlCommand membros = new SqlCommand("SELECT pagamento_bruto_membro FROM tb_pagamentos_valor_bruto INNER JOIN tb_membros ON tb_pagamentos_valor_bruto.pagamento_bruto_membro = tb_membros.membro_id WHERE NOT membro_funcao = 'Secretaria' AND pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano;", conexao);

                                    membros.Parameters.AddWithValue("@mes", condominioGastos.Mes);
                                    membros.Parameters.AddWithValue("@ano", condominioGastos.Ano);

                                    SqlDataReader registrosMembros = membros.ExecuteReader();

                                    int contador = 0;

                                    condominioMembros.Membro = new int[quantidade];

                                    while (registrosMembros.Read())
                                    {
                                        condominioMembros.Membro[contador] = Convert.ToInt32(registrosMembros["pagamento_bruto_membro"]);

                                        if (contador < quantidade - 1)
                                        {
                                            contador += 1;
                                        }
                                    }

                                    registrosMembros.Close();

                                    SqlCommand pesquisarMembroHoras = new SqlCommand("SELECT horas_trabalhadas_id, horas_trabalhadas FROM tb_horas_trabalhadas WHERE horas_trabalhadas_membro = @membro AND horas_trabalhadas_mes = @mes AND horas_trabalhadas_ano = @ano;", conexao);    //Coleta do número de horas trabalhadas de cada membro da clínica

                                    contador = 0;

                                    while (contador < quantidade)
                                    {
                                        pesquisarMembroHoras.Parameters.Clear();
                                        pesquisarMembroHoras.Parameters.AddWithValue("@membro", condominioMembros.Membro[contador]);
                                        pesquisarMembroHoras.Parameters.AddWithValue("@mes", condominioHoras.Mes);
                                        pesquisarMembroHoras.Parameters.AddWithValue("@ano", condominioHoras.Ano);

                                        SqlDataReader registrosMembrosHoras = pesquisarMembroHoras.ExecuteReader();

                                        registrosMembrosHoras.Read();

                                        condominioMembros.MembroHoras = Convert.ToInt32(registrosMembrosHoras["horas_trabalhadas_id"]);
                                        condominioMembros.Mes = Convert.ToInt32(registrosMembrosHoras["horas_trabalhadas_id"]);
                                        condominioMembros.Ano = Convert.ToInt32(registrosMembrosHoras["horas_trabalhadas_id"]);
                                        condominioMembros.Valor = Convert.ToDecimal(registrosMembrosHoras["horas_trabalhadas"]) * condominioHoraValor.Valor;    //O valor que um membro da clínica pagará será determinado pela multiplicação do valor da hora de condomínio pelo número de horas que cada membro trabalhou

                                        registrosMembrosHoras.Close();

                                        SqlCommand inserir = new SqlCommand("INSERT INTO tb_membros_condominio Values (@membro, @horas, @horaValor, @valor, @mes, @ano);", conexao);

                                        inserir.Parameters.Clear();
                                        inserir.Parameters.AddWithValue("@membro", condominioMembros.Membro[contador]);
                                        inserir.Parameters.AddWithValue("@horas", condominioMembros.MembroHoras);
                                        inserir.Parameters.AddWithValue("@horaValor", condominioMembros.HoraValor);
                                        inserir.Parameters.AddWithValue("@valor", condominioMembros.Valor);
                                        inserir.Parameters.AddWithValue("@mes", condominioMembros.Mes);
                                        inserir.Parameters.AddWithValue("@ano", condominioMembros.Ano);

                                        inserir.ExecuteNonQuery();

                                        contador += 1;
                                    }

                                    conexao.Close();

                                    MessageBox.Show("Valores de condomínio inseridos com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    cbCondominioMes.SelectedIndex = -1;
                                    txtCondominioAno.Clear();

                                    TabelaCondominioMembros();
                                }
                            }
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (conexao != null && conexao.State != ConnectionState.Closed)
                            {
                                conexao.Close();
                            }
                        }
                    }
                }
            }
        }

        private void btnCondominioPesquisar_Click(object sender, EventArgs e)
        {
            if (rbCondominioMensal.Checked)
            {
                if (cbCondominioPesquisar.Text == "Mês e ano")
                {
                    if (cbCondominioPesquisarMes.Text == "" || txtCondominioPesquisarAno.Text == "")
                    {
                        MessageBox.Show("Informe todas as informações para a pesquisa", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (Convert.ToDecimal(txtCondominioPesquisarAno.Text) < 2000 || Convert.ToDecimal(txtCondominioPesquisarAno.Text) > 2099)
                    {
                        MessageBox.Show("Informe um ano válido para pesquisar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        SqlConnection conexao = null;

                        try
                        {
                            CondominioGastos condominio = new CondominioGastos(cbCondominioPesquisarMes.Text, txtCondominioPesquisarAno.Text);

                            conexao = new SqlConnection(StringConexao.stringConexao);

                            SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_condominio WHERE condominio_mes = @mes AND condominio_ano = @ano;", conexao);

                            pesquisar.Parameters.AddWithValue("@mes", condominio.Mes);
                            pesquisar.Parameters.AddWithValue("@ano", condominio.Ano);

                            conexao.Open();

                            SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                            conexao.Close();

                            DataTable tabela = new DataTable();

                            registros.Fill(tabela);

                            dgvCondominio.DataSource = tabela;

                            if (tabela.Rows.Count > 0)
                            {
                                btnCondominioGastosPesquisarImprimir.Visible = true;
                            }
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (conexao != null && conexao.State != ConnectionState.Closed)
                            {
                                conexao.Close();
                            }
                        }
                    }
                }
                else if (cbCondominioPesquisar.Text == "Ano")
                {
                    if (txtCondominioPesquisarAno.Text == "")
                    {
                        MessageBox.Show("Informe um ano para a pesquisa", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (Convert.ToDecimal(txtCondominioPesquisarAno.Text) < 2000 || Convert.ToDecimal(txtCondominioPesquisarAno.Text) > 2099)
                    {
                        MessageBox.Show("Informe um ano válido para pesquisar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        SqlConnection conexao = null;

                        try
                        {
                            CondominioGastos condominio = new CondominioGastos(txtCondominioPesquisarAno.Text);

                            conexao = new SqlConnection(StringConexao.stringConexao);

                            SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_condominio WHERE condominio_ano = @ano ORDER BY condominio_mes;", conexao);

                            pesquisar.Parameters.AddWithValue("@ano", condominio.Ano);

                            conexao.Open();

                            SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                            conexao.Close();

                            DataTable tabela = new DataTable();

                            registros.Fill(tabela);

                            dgvCondominio.DataSource = tabela;

                            if (tabela.Rows.Count > 0)
                            {
                                btnCondominioGastosPesquisarImprimir.Visible = true;
                            }
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (conexao != null && conexao.State != ConnectionState.Closed)
                            {
                                conexao.Close();
                            }
                        }
                    }
                }
            }
            else if (rbCondominioHoras.Checked)
            {
                if (cbCondominioPesquisar.Text == "Data")
                {
                    if (txtCondominioPesquisarAno.Text == "")
                    {
                        MessageBox.Show("Informe um ano para a pesquisa", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (Convert.ToDecimal(txtCondominioPesquisarAno.Text) < 2000 || Convert.ToDecimal(txtCondominioPesquisarAno.Text) > 2099)
                    {
                        MessageBox.Show("Informe um ano válido para pesquisar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        SqlConnection conexao = null;

                        try
                        {
                            CondominioHoras condominio = new CondominioHoras(cbCondominioPesquisarMes.Text, txtCondominioPesquisarAno.Text);

                            conexao = new SqlConnection(StringConexao.stringConexao);

                            SqlCommand pesquisar = new SqlCommand("SELECT horas_trabalhadas_id, membro_nome, horas_trabalhadas, horas_trabalhadas_mes, horas_trabalhadas_ano FROM tb_horas_trabalhadas INNER JOIN tb_membros ON tb_horas_trabalhadas.horas_trabalhadas_membro = tb_membros.membro_id WHERE horas_trabalhadas_mes = @mes AND horas_trabalhadas_ano = @ano ORDER BY membro_nome;", conexao);

                            pesquisar.Parameters.AddWithValue("@mes", condominio.Mes);
                            pesquisar.Parameters.AddWithValue("@ano", condominio.Ano);

                            conexao.Open();

                            SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                            conexao.Close();

                            DataTable tabela = new DataTable();

                            registros.Fill(tabela);

                            dgvCondominio.DataSource = tabela;
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (conexao != null && conexao.State != ConnectionState.Closed)
                            {
                                conexao.Close();
                            }
                        }
                    }
                }
            }
            else if (rbCondominioMembros.Checked)
            {
                if (cbCondominioPesquisar.Text == "Data")
                {
                    if (txtCondominioPesquisarAno.Text == "")
                    {
                        MessageBox.Show("Informe um ano para a pesquisa", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (Convert.ToDecimal(txtCondominioPesquisarAno.Text) < 2000 || Convert.ToDecimal(txtCondominioPesquisarAno.Text) > 2099)
                    {
                        MessageBox.Show("Informe um ano válido para pesquisar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        SqlConnection conexao = null;

                        try
                        {
                            CondominioHoras condominio = new CondominioHoras(cbCondominioPesquisarMes.Text, txtCondominioPesquisarAno.Text);

                            conexao = new SqlConnection(StringConexao.stringConexao);

                            SqlCommand pesquisar = new SqlCommand("SELECT membro_nome, horas_trabalhadas, hora_valor, membro_condominio_valor, horas_trabalhadas_mes, horas_trabalhadas_ano FROM tb_membros_condominio INNER JOIN tb_membros ON tb_membros_condominio.condominio_membro = tb_membros.Membro_id INNER JOIN tb_condominio_hora_valor ON tb_membros_condominio.condominio_hora_valor = tb_condominio_hora_valor.hora_valor_id INNER JOIN tb_horas_trabalhadas ON tb_membros_condominio.membro_horas_trabalhadas = tb_horas_trabalhadas.horas_trabalhadas_id WHERE horas_trabalhadas_mes = @mes AND horas_trabalhadas_ano = @ano ORDER BY membro_nome;", conexao);

                            pesquisar.Parameters.AddWithValue("@mes", condominio.Mes);
                            pesquisar.Parameters.AddWithValue("@ano", condominio.Ano);

                            conexao.Open();

                            SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                            conexao.Close();

                            DataTable tabela = new DataTable();

                            registros.Fill(tabela);

                            dgvCondominio.DataSource = tabela;
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (conexao != null && conexao.State != ConnectionState.Closed)
                            {
                                conexao.Close();
                            }
                        }
                    }
                }
            }
        }

        private void txtCondominioAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 || txtCondominioAno.Text.Length == 4 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void cbCondominioMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCondominioNome.SelectedIndex != -1)
            {
                cbCondominioNome.SelectedIndex = -1;
            }
        }

        private void txtCondominioAno_TextChanged(object sender, EventArgs e)
        {
            if (cbCondominioNome.SelectedIndex != -1)
            {
                cbCondominioNome.SelectedIndex = -1;
            }
        }

        private void cbCondominioNome_DropDown(object sender, EventArgs e)    //Os nomes dos membros da clínica disponíneis serão os que estejam resgistrados como função de 'Psiquiatria e/ou psicologia' e vínculo com a clínica como 'Não sócio' na aba 'Membros da clínica', e tenham pagamentos registrados na aba 'Pagamentos - valor bruto' na data informada
        {
            if (cbCondominioMes.Text == "" || txtCondominioAno.Text == "")
            {
                MessageBox.Show("Informe o mês e o ano no qual o período trabalhado se refere", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDecimal(txtCondominioAno.Text) < 2000 || Convert.ToDecimal(txtCondominioAno.Text) > 2099)
            {
                MessageBox.Show("Informe um ano válido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                cbCondominioNome.DataSource = null;
            }
            else
            {
                SqlConnection conexao = null;

                try
                {
                    PagamentosBruto pagamentos = new PagamentosBruto(cbCondominioMes.Text, txtCondominioAno.Text);

                    conexao = new SqlConnection(StringConexao.stringConexao);

                    SqlCommand pesquisar = new SqlCommand("SELECT membro_id, membro_nome FROM tb_pagamentos_valor_bruto INNER JOIN tb_membros ON tb_pagamentos_valor_bruto.pagamento_bruto_membro = tb_membros.membro_id WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano AND NOT membro_funcao = 'Secretaria' ORDER BY membro_nome;", conexao);

                    pesquisar.Parameters.AddWithValue("@mes", pagamentos.Mes);
                    pesquisar.Parameters.AddWithValue("@ano", pagamentos.Ano);

                    SqlDataAdapter registros2 = new SqlDataAdapter(pesquisar);

                    conexao.Close();

                    DataTable tabela = new DataTable();

                    registros2.Fill(tabela);

                    cbCondominioNome.ValueMember = "membro_id";
                    cbCondominioNome.DisplayMember = "membro_nome";
                    cbCondominioNome.DataSource = tabela;

                    if (tabela.Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum pagamento desta data foi informado");
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conexao != null && conexao.State != ConnectionState.Closed)
                    {
                        conexao.Close();
                    }
                }
            }
        }

        private void txtCondominioHorasTrabalhadas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }       

        private void dgvCondominio_DoubleClick(object sender, EventArgs e)
        {
            if (dgvCondominio.SelectedRows.Count == 1)
            {
                if (rbCondominioMensal.Checked)
                {
                    frmCondominioGastos condominio = new frmCondominioGastos(dgvCondominio.SelectedRows[0].Cells[1].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[2].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[3].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[4].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[5].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[6].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[7].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[8].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[9].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[10].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[11].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[12].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[13].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[14].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[16].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[17].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[0].Value.ToString());

                    condominio.Salvar = false;
                    condominio.Texto = "Condomínio - Gasto mensal - Alterar/excluir";

                    if (cbPagamentosBrutoMes.Text != "" && txtPagamentosBrutoAno.Text != "")
                    {
                        condominio.MesContabilidade = cbPagamentosBrutoMes.Text;
                        condominio.AnoContabilidade = txtPagamentosBrutoAno.Text;
                    }

                    condominio.Show();
                    this.Hide();
                }
                else if (rbCondominioHoras.Checked)
                {
                    frmCondominioHorasAlterarDeletar condominio = new frmCondominioHorasAlterarDeletar(dgvCondominio.SelectedRows[0].Cells[3].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[4].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[1].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[2].Value.ToString(), dgvCondominio.SelectedRows[0].Cells[0].Value.ToString());

                    if (cbPagamentosBrutoMes.Text != "" && txtPagamentosBrutoAno.Text != "")
                    {
                        condominio.Mes = cbPagamentosBrutoMes.Text;
                        condominio.Ano = txtPagamentosBrutoAno.Text;
                    }

                    condominio.Show();
                    this.Hide();
                }
            }            
        }

        private void txtCondominioPesquisarNome_TextChanged(object sender, EventArgs e)
        {
            if (rbCondominioHoras.Checked)
            {
                SqlConnection conexao = null;

                try
                {
                    conexao = new SqlConnection(StringConexao.stringConexao);

                    SqlCommand pesquisar = conexao.CreateCommand();

                    if (txtCondominioPesquisarNome.Text != "")
                    {
                        pesquisar.CommandText = "SELECT horas_trabalhadas_id, membro_nome, horas_trabalhadas, horas_trabalhadas_mes, horas_trabalhadas_ano FROM tb_horas_trabalhadas INNER JOIN tb_membros ON tb_horas_trabalhadas.horas_trabalhadas_membro = tb_membros.membro_id WHERE membro_nome LIKE @nome ORDER BY membro_nome, horas_trabalhadas_ano, horas_trabalhadas_mes;";

                        pesquisar.Parameters.AddWithValue("@nome", '%' + txtCondominioPesquisarNome.Text + '%');
                    }
                    else
                    {
                        pesquisar.CommandText = "SELECT horas_trabalhadas_id, membro_nome, horas_trabalhadas, horas_trabalhadas_mes, horas_trabalhadas_ano FROM tb_horas_trabalhadas INNER JOIN tb_membros ON tb_horas_trabalhadas.horas_trabalhadas_membro = tb_membros.membro_id ORDER BY horas_trabalhadas_ano, horas_trabalhadas_mes, membro_nome;";
                    }                      

                    conexao.Open();

                    SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                    conexao.Close();

                    DataTable tabela = new DataTable();

                    registros.Fill(tabela);

                    dgvCondominio.DataSource = tabela;
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conexao != null && conexao.State != ConnectionState.Closed)
                    {
                        conexao.Close();
                    }
                }
            }
            else if (rbCondominioMembros.Checked)
            {
                SqlConnection conexao = null;

                try
                {
                    conexao = new SqlConnection(StringConexao.stringConexao);

                    SqlCommand pesquisar = conexao.CreateCommand();

                    if (txtCondominioPesquisarNome.Text != "")
                    {
                        pesquisar.CommandText = "SELECT membro_nome, horas_trabalhadas, hora_valor, membro_condominio_valor, horas_trabalhadas_mes, horas_trabalhadas_ano FROM tb_membros_condominio INNER JOIN tb_membros ON tb_membros_condominio.condominio_membro = tb_membros.Membro_id INNER JOIN tb_condominio_hora_valor ON tb_membros_condominio.condominio_hora_valor = tb_condominio_hora_valor.hora_valor_id INNER JOIN tb_horas_trabalhadas ON tb_membros_condominio.membro_horas_trabalhadas = tb_horas_trabalhadas.horas_trabalhadas_id WHERE membro_nome LIKE @nome ORDER BY membro_nome, horas_trabalhadas_ano, horas_trabalhadas_mes;";

                        pesquisar.Parameters.AddWithValue("@nome", '%' + txtCondominioPesquisarNome.Text + '%');
                    }
                    else
                    {
                        pesquisar.CommandText = "SELECT membro_nome, horas_trabalhadas, hora_valor, membro_condominio_valor, horas_trabalhadas_mes, horas_trabalhadas_ano FROM tb_membros_condominio INNER JOIN tb_membros ON tb_membros_condominio.condominio_membro = tb_membros.Membro_id INNER JOIN tb_condominio_hora_valor ON tb_membros_condominio.condominio_hora_valor = tb_condominio_hora_valor.hora_valor_id INNER JOIN tb_horas_trabalhadas ON tb_membros_condominio.membro_horas_trabalhadas = tb_horas_trabalhadas.horas_trabalhadas_id ORDER BY horas_trabalhadas_ano, horas_trabalhadas_mes, membro_nome;";
                    }                    

                    conexao.Open();

                    SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                    conexao.Close();

                    DataTable tabela = new DataTable();

                    registros.Fill(tabela);

                    dgvCondominio.DataSource = tabela;
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conexao != null && conexao.State != ConnectionState.Closed)
                    {
                        conexao.Close();
                    }
                }
            }
        }

        private void btnCondominioDeletar_Click(object sender, EventArgs e)
        {
            if (cbCondominioMes.Text == "" || txtCondominioAno.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDecimal(txtCondominioAno.Text) < 2000 || Convert.ToDecimal(txtCondominioAno.Text) > 2099)
            {
               MessageBox.Show("Informe todas as informações para a pesquisa", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var botao = MessageBox.Show("Confirmar a remoção de registros?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (botao == DialogResult.Yes)
                {
                    SqlConnection conexao = null;

                    try
                    {
                        CondominioHoras condominioHoras = new CondominioHoras(cbCondominioMes.Text, txtCondominioAno.Text);

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_socios WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                        pesquisar.Parameters.AddWithValue("@mes", condominioHoras.Mes);
                        pesquisar.Parameters.AddWithValue("@ano", condominioHoras.Ano);

                        SqlCommand pesquisar2 = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_nao_socios WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                        pesquisar2.Parameters.AddWithValue("@mes", condominioHoras.Mes);
                        pesquisar2.Parameters.AddWithValue("@ano", condominioHoras.Ano);

                        conexao.Open();

                        int quantidade = Convert.ToInt32(pesquisar.ExecuteScalar());
                        int quantidade2 = Convert.ToInt32(pesquisar2.ExecuteScalar());

                        if (quantidade > 0 || quantidade2 > 0)
                        {
                            MessageBox.Show("Registros na tabela de pagamentos (valor líquido) estão fazendo uso destas informações. Apague-os para poder remover estes registros", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            conexao.Close();
                        }
                        else
                        {
                            SqlCommand pesquisar3 = new SqlCommand("SELECT horas_trabalhadas_id FROM tb_horas_trabalhadas WHERE horas_trabalhadas_mes = @mes AND horas_trabalhadas_ano = @ano;", conexao);

                            pesquisar3.Parameters.AddWithValue("@mes", condominioHoras.Mes);
                            pesquisar3.Parameters.AddWithValue("@ano", condominioHoras.Ano);

                            SqlDataReader registros = pesquisar3.ExecuteReader();

                            if (registros.HasRows == false)
                            {
                                MessageBox.Show("Não há registros deste mês e ano", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                registros.Close();
                                conexao.Close();
                            }
                            else
                            {
                                registros.Close();

                                SqlCommand pesquisar4 = new SqlCommand("SELECT * FROM tb_membros_condominio WHERE membro_condominio_mes = any (SELECT horas_trabalhadas_id FROM tb_horas_trabalhadas WHERE horas_trabalhadas_mes = @mes AND horas_trabalhadas_ano = @ano);", conexao);

                                pesquisar4.Parameters.AddWithValue("@mes", condominioHoras.Mes);
                                pesquisar4.Parameters.AddWithValue("@ano", condominioHoras.Ano);

                                SqlDataReader registros2 = pesquisar4.ExecuteReader();

                                if (registros2.HasRows == false)
                                {
                                    MessageBox.Show("Não há registros deste mês e ano", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    registros2.Close();
                                    conexao.Close();
                                }
                                else
                                {
                                    registros2.Close();

                                    SqlCommand deletar = new SqlCommand("DELETE FROM tb_membros_condominio WHERE membro_condominio_mes = any (SELECT horas_trabalhadas_id FROM tb_horas_trabalhadas WHERE horas_trabalhadas_mes = @mes AND horas_trabalhadas_ano = @ano);", conexao);

                                    deletar.Parameters.AddWithValue("@mes", condominioHoras.Mes);
                                    deletar.Parameters.AddWithValue("@ano", condominioHoras.Ano);

                                    SqlCommand deletar2 = new SqlCommand("DELETE FROM tb_condominio_hora_valor WHERE hora_valor_mes = (SELECT condominio_id FROM tb_condominio WHERE condominio_mes = @mes AND condominio_ano = @ano);", conexao);

                                    deletar2.Parameters.AddWithValue("@mes", condominioHoras.Mes);
                                    deletar2.Parameters.AddWithValue("@ano", condominioHoras.Ano);

                                    deletar.ExecuteNonQuery();
                                    deletar2.ExecuteNonQuery();

                                    conexao.Close();

                                    MessageBox.Show("Remoção de registros feita com sucesso", "Operação bem sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    TabelaCondominioMembros();
                                }
                            }
                        }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conexao != null && conexao.State != ConnectionState.Closed)
                        {
                            conexao.Close();
                        }
                    }
                }
            }
        }

        private void btnCondominioGastosImprimir_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT COUNT(*) FROM tb_condominio;", conexao);

                conexao.Open();

                int quantidade = Convert.ToInt32(pesquisar.ExecuteScalar());

                if (quantidade == 0)
                {
                    conexao.Close();
                }
                else
                {
                    PdfWriter pdf = new PdfWriter("C:\\Clínica Contabilidade\\condominio.pdf");

                    PdfDocument documentoPdf = new PdfDocument(pdf);

                    Document documento = new Document(documentoPdf, PageSize.A4);

                    Paragraph cabecalho = new Paragraph("Espaço Entre Saúde Mental e Qualidade de Vida - Despesas de condomínio");
                    cabecalho.SetTextAlignment(TextAlignment.CENTER);
                    cabecalho.SetFontSize(16);

                    documento.Add(cabecalho);

                    Table tabela = new Table(17);
                    tabela.SetWidth(UnitValue.CreatePercentValue(100));

                    Paragraph cabecalhoCpfl = new Paragraph("CPFL");
                    cabecalhoCpfl.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoCpfl.SetFontSize(6);

                    tabela.AddCell(cabecalhoCpfl);

                    Paragraph cabecalhoSanebavi = new Paragraph("Sanebavi");
                    cabecalhoSanebavi.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoSanebavi.SetFontSize(6);

                    tabela.AddCell(cabecalhoSanebavi);

                    Paragraph cabecalhoVivo = new Paragraph("Vivo");
                    cabecalhoVivo.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoVivo.SetFontSize(6);

                    tabela.AddCell(cabecalhoVivo);

                    Paragraph cabecalhoCorreio = new Paragraph("Correio");
                    cabecalhoCorreio.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoCorreio.SetFontSize(6);

                    tabela.AddCell(cabecalhoCorreio);

                    Paragraph cabecalhoAguaBeber = new Paragraph("Água para beber");
                    cabecalhoAguaBeber.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoAguaBeber.SetFontSize(6);

                    tabela.AddCell(cabecalhoAguaBeber);

                    Paragraph cabecalhoCopos = new Paragraph("Copos");
                    cabecalhoCopos.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoCopos.SetFontSize(6);

                    tabela.AddCell(cabecalhoCopos);

                    Paragraph cabecalhoPapelHigienico = new Paragraph("Papel higiênico");
                    cabecalhoPapelHigienico.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoPapelHigienico.SetFontSize(6);

                    tabela.AddCell(cabecalhoPapelHigienico);

                    Paragraph cabecalhoPapelToalha = new Paragraph("Papel toalha");
                    cabecalhoPapelToalha.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoPapelToalha.SetFontSize(6);

                    tabela.AddCell(cabecalhoPapelToalha);

                    Paragraph cabecalhoCafe = new Paragraph("Café");
                    cabecalhoCafe.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoCafe.SetFontSize(6);

                    tabela.AddCell(cabecalhoCafe);

                    Paragraph cabecalhoAcucar = new Paragraph("Açúcar");
                    cabecalhoAcucar.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoAcucar.SetFontSize(6);

                    tabela.AddCell(cabecalhoAcucar);

                    Paragraph cabecalhoProdutosLimpeza = new Paragraph("Produtos de limpeza");
                    cabecalhoProdutosLimpeza.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoProdutosLimpeza.SetFontSize(6);

                    tabela.AddCell(cabecalhoProdutosLimpeza);

                    Paragraph cabecalhoFaxina = new Paragraph("Faxina");
                    cabecalhoFaxina.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoFaxina.SetFontSize(6);

                    tabela.AddCell(cabecalhoFaxina);

                    Paragraph cabecalhoRecargaCelular = new Paragraph("Recarga de celular");
                    cabecalhoRecargaCelular.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoRecargaCelular.SetFontSize(6);

                    tabela.AddCell(cabecalhoRecargaCelular);

                    Paragraph cabecalhoOutros = new Paragraph("Outros");
                    cabecalhoOutros.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoOutros.SetFontSize(6);

                    tabela.AddCell(cabecalhoOutros);

                    Paragraph cabecalhoTotal = new Paragraph("Total");
                    cabecalhoTotal.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoTotal.SetFontSize(6);

                    tabela.AddCell(cabecalhoTotal);

                    Paragraph cabecalhoMes = new Paragraph("Mês");
                    cabecalhoMes.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoMes.SetFontSize(6);

                    tabela.AddCell(cabecalhoMes);

                    Paragraph cabecalhoAno = new Paragraph("Ano");
                    cabecalhoAno.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoAno.SetFontSize(6);

                    tabela.AddCell(cabecalhoAno);

                    SqlCommand pesquisar2 = new SqlCommand("SELECT * FROM tb_condominio ORDER BY condominio_ano, condominio_mes", conexao);

                    SqlDataReader registros = pesquisar2.ExecuteReader();

                    while (registros.Read())
                    {
                        Paragraph cpfl = new Paragraph(registros["condominio_cpfl"].ToString());
                        cpfl.SetTextAlignment(TextAlignment.CENTER);
                        cpfl.SetFontSize(5);

                        tabela.AddCell(cpfl);

                        Paragraph sanebavi = new Paragraph(registros["condominio_sanebavi"].ToString());
                        sanebavi.SetTextAlignment(TextAlignment.CENTER);
                        sanebavi.SetFontSize(5);

                        tabela.AddCell(sanebavi);

                        Paragraph vivo = new Paragraph(registros["condominio_vivo"].ToString());
                        vivo.SetTextAlignment(TextAlignment.CENTER);
                        vivo.SetFontSize(5);

                        tabela.AddCell(vivo);

                        Paragraph correio = new Paragraph(registros["condominio_correio"].ToString());
                        correio.SetTextAlignment(TextAlignment.CENTER);
                        correio.SetFontSize(5);

                        tabela.AddCell(correio);

                        Paragraph aguaBeber = new Paragraph(registros["condominio_agua_para_beber"].ToString());
                        aguaBeber.SetTextAlignment(TextAlignment.CENTER);
                        aguaBeber.SetFontSize(5);

                        tabela.AddCell(aguaBeber);

                        Paragraph copos = new Paragraph(registros["condominio_copos"].ToString());
                        copos.SetTextAlignment(TextAlignment.CENTER);
                        copos.SetFontSize(5);

                        tabela.AddCell(copos);

                        Paragraph papelHigienico = new Paragraph(registros["condominio_papel_higienico"].ToString());
                        papelHigienico.SetTextAlignment(TextAlignment.CENTER);
                        papelHigienico.SetFontSize(5);

                        tabela.AddCell(papelHigienico);

                        Paragraph papelToalha = new Paragraph(registros["condominio_papel_toalha"].ToString());
                        papelToalha.SetTextAlignment(TextAlignment.CENTER);
                        papelToalha.SetFontSize(5);

                        tabela.AddCell(papelToalha);

                        Paragraph cafe = new Paragraph(registros["condominio_cafe"].ToString());
                        cafe.SetTextAlignment(TextAlignment.CENTER);
                        cafe.SetFontSize(5);

                        tabela.AddCell(cafe);

                        Paragraph acucar = new Paragraph(registros["condominio_acucar"].ToString());
                        acucar.SetTextAlignment(TextAlignment.CENTER);
                        acucar.SetFontSize(5);

                        tabela.AddCell(acucar);

                        Paragraph produtosLimpeza = new Paragraph(registros["condominio_produtos_limpeza"].ToString());
                        produtosLimpeza.SetTextAlignment(TextAlignment.CENTER);
                        produtosLimpeza.SetFontSize(5);

                        tabela.AddCell(produtosLimpeza);

                        Paragraph faxina = new Paragraph(registros["condominio_faxina"].ToString());
                        faxina.SetTextAlignment(TextAlignment.CENTER);
                        faxina.SetFontSize(5);

                        tabela.AddCell(faxina);

                        Paragraph recargaCelular = new Paragraph(registros["condominio_recarga_celular"].ToString());
                        recargaCelular.SetTextAlignment(TextAlignment.CENTER);
                        recargaCelular.SetFontSize(5);

                        tabela.AddCell(recargaCelular);

                        Paragraph outros = new Paragraph(registros["condominio_outros"].ToString());
                        outros.SetTextAlignment(TextAlignment.CENTER);
                        outros.SetFontSize(5);

                        tabela.AddCell(outros);

                        Paragraph total = new Paragraph(registros["condominio_valor_total"].ToString());
                        total.SetTextAlignment(TextAlignment.CENTER);
                        total.SetFontSize(5);

                        tabela.AddCell(total);

                        Paragraph mes = new Paragraph(registros["condominio_mes"].ToString());
                        mes.SetTextAlignment(TextAlignment.CENTER);
                        mes.SetFontSize(5);

                        tabela.AddCell(mes);

                        Paragraph ano = new Paragraph(registros["condominio_ano"].ToString());
                        ano.SetTextAlignment(TextAlignment.CENTER);
                        ano.SetFontSize(5);

                        tabela.AddCell(ano);
                    }

                    registros.Close();

                    documento.Add(tabela);

                    documento.Close();
                    documentoPdf.Close();

                    System.Diagnostics.Process.Start("C:\\Clínica Contabilidade\\condominio.pdf");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }

        private void btnCondominioGastosPesquisarImprimir_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = null;

            try
            {
                PdfWriter pdf = new PdfWriter("C:\\Clínica Contabilidade\\condominio.pdf");

                PdfDocument documentoPdf = new PdfDocument(pdf);

                Document documento = new Document(documentoPdf, PageSize.A4);

                Paragraph cabecalho = new Paragraph("Espaço Entre Saúde Mental e Qualidade de Vida - Despesas de condomínio");
                cabecalho.SetTextAlignment(TextAlignment.CENTER);
                cabecalho.SetFontSize(16);

                documento.Add(cabecalho);

                Table tabela = new Table(17);
                tabela.SetWidth(UnitValue.CreatePercentValue(100));

                Paragraph cabecalhoCpfl = new Paragraph("CPFL");
                cabecalhoCpfl.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoCpfl.SetFontSize(6);

                tabela.AddCell(cabecalhoCpfl);

                Paragraph cabecalhoSanebavi = new Paragraph("Sanebavi");
                cabecalhoSanebavi.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoSanebavi.SetFontSize(6);

                tabela.AddCell(cabecalhoSanebavi);

                Paragraph cabecalhoVivo = new Paragraph("Vivo");
                cabecalhoVivo.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoVivo.SetFontSize(6);

                tabela.AddCell(cabecalhoVivo);

                Paragraph cabecalhoCorreio = new Paragraph("Correio");
                cabecalhoCorreio.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoCorreio.SetFontSize(6);

                tabela.AddCell(cabecalhoCorreio);

                Paragraph cabecalhoAguaBeber = new Paragraph("Água para beber");
                cabecalhoAguaBeber.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoAguaBeber.SetFontSize(6);

                tabela.AddCell(cabecalhoAguaBeber);

                Paragraph cabecalhoCopos = new Paragraph("Copos");
                cabecalhoCopos.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoCopos.SetFontSize(6);

                tabela.AddCell(cabecalhoCopos);

                Paragraph cabecalhoPapelHigienico = new Paragraph("Papel higiênico");
                cabecalhoPapelHigienico.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoPapelHigienico.SetFontSize(6);

                tabela.AddCell(cabecalhoPapelHigienico);

                Paragraph cabecalhoPapelToalha = new Paragraph("Papel toalha");
                cabecalhoPapelToalha.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoPapelToalha.SetFontSize(6);

                tabela.AddCell(cabecalhoPapelToalha);

                Paragraph cabecalhoCafe = new Paragraph("Café");
                cabecalhoCafe.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoCafe.SetFontSize(6);

                tabela.AddCell(cabecalhoCafe);

                Paragraph cabecalhoAcucar = new Paragraph("Açúcar");
                cabecalhoAcucar.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoAcucar.SetFontSize(6);

                tabela.AddCell(cabecalhoAcucar);

                Paragraph cabecalhoProdutosLimpeza = new Paragraph("Produtos de limpeza");
                cabecalhoProdutosLimpeza.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoProdutosLimpeza.SetFontSize(6);

                tabela.AddCell(cabecalhoProdutosLimpeza);

                Paragraph cabecalhoFaxina = new Paragraph("Faxina");
                cabecalhoFaxina.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoFaxina.SetFontSize(6);

                tabela.AddCell(cabecalhoFaxina);

                Paragraph cabecalhoRecargaCelular = new Paragraph("Recarga de celular");
                cabecalhoRecargaCelular.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoRecargaCelular.SetFontSize(6);

                tabela.AddCell(cabecalhoRecargaCelular);

                Paragraph cabecalhoOutros = new Paragraph("Outros");
                cabecalhoOutros.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoOutros.SetFontSize(6);

                tabela.AddCell(cabecalhoOutros);

                Paragraph cabecalhoTotal = new Paragraph("Total");
                cabecalhoTotal.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoTotal.SetFontSize(6);

                tabela.AddCell(cabecalhoTotal);

                Paragraph cabecalhoMes = new Paragraph("Mês");
                cabecalhoMes.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoMes.SetFontSize(6);

                tabela.AddCell(cabecalhoMes);

                Paragraph cabecalhoAno = new Paragraph("Ano");
                cabecalhoAno.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoAno.SetFontSize(6);

                tabela.AddCell(cabecalhoAno);

                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = conexao.CreateCommand();

                if (cbCondominioPesquisar.Text == "Ano")
                {
                    CondominioGastos condominio = new CondominioGastos(txtCondominioPesquisarAno.Text);

                    pesquisar.CommandText = "SELECT * FROM tb_condominio WHERE condominio_ano = @ano ORDER BY condominio_mes;";

                    pesquisar.Parameters.AddWithValue("@ano", condominio.Ano);
                }
                else
                {
                    CondominioGastos condominio = new CondominioGastos(cbCondominioPesquisarMes.Text, txtCondominioPesquisarAno.Text);

                    pesquisar.CommandText = "SELECT * FROM tb_condominio WHERE condominio_mes = @mes AND condominio_ano = @ano;";

                    pesquisar.Parameters.AddWithValue("@mes", condominio.Mes);
                    pesquisar.Parameters.AddWithValue("@ano", condominio.Ano);
                }

                conexao.Open();

                SqlDataReader registros = pesquisar.ExecuteReader();

                while (registros.Read())
                {
                    Paragraph cpfl = new Paragraph(registros["condominio_cpfl"].ToString());
                    cpfl.SetTextAlignment(TextAlignment.CENTER);
                    cpfl.SetFontSize(5);

                    tabela.AddCell(cpfl);

                    Paragraph sanebavi = new Paragraph(registros["condominio_sanebavi"].ToString());
                    sanebavi.SetTextAlignment(TextAlignment.CENTER);
                    sanebavi.SetFontSize(5);

                    tabela.AddCell(sanebavi);

                    Paragraph vivo = new Paragraph(registros["condominio_vivo"].ToString());
                    vivo.SetTextAlignment(TextAlignment.CENTER);
                    vivo.SetFontSize(5);

                    tabela.AddCell(vivo);

                    Paragraph correio = new Paragraph(registros["condominio_correio"].ToString());
                    correio.SetTextAlignment(TextAlignment.CENTER);
                    correio.SetFontSize(5);

                    tabela.AddCell(correio);

                    Paragraph aguaBeber = new Paragraph(registros["condominio_agua_para_beber"].ToString());
                    aguaBeber.SetTextAlignment(TextAlignment.CENTER);
                    aguaBeber.SetFontSize(5);

                    tabela.AddCell(aguaBeber);

                    Paragraph copos = new Paragraph(registros["condominio_copos"].ToString());
                    copos.SetTextAlignment(TextAlignment.CENTER);
                    copos.SetFontSize(5);

                    tabela.AddCell(copos);

                    Paragraph papelHigienico = new Paragraph(registros["condominio_papel_higienico"].ToString());
                    papelHigienico.SetTextAlignment(TextAlignment.CENTER);
                    papelHigienico.SetFontSize(5);

                    tabela.AddCell(papelHigienico);

                    Paragraph papelToalha = new Paragraph(registros["condominio_papel_toalha"].ToString());
                    papelToalha.SetTextAlignment(TextAlignment.CENTER);
                    papelToalha.SetFontSize(5);

                    tabela.AddCell(papelToalha);

                    Paragraph cafe = new Paragraph(registros["condominio_cafe"].ToString());
                    cafe.SetTextAlignment(TextAlignment.CENTER);
                    cafe.SetFontSize(5);

                    tabela.AddCell(cafe);

                    Paragraph acucar = new Paragraph(registros["condominio_acucar"].ToString());
                    acucar.SetTextAlignment(TextAlignment.CENTER);
                    acucar.SetFontSize(5);

                    tabela.AddCell(acucar);

                    Paragraph produtosLimpeza = new Paragraph(registros["condominio_produtos_limpeza"].ToString());
                    produtosLimpeza.SetTextAlignment(TextAlignment.CENTER);
                    produtosLimpeza.SetFontSize(5);

                    tabela.AddCell(produtosLimpeza);

                    Paragraph faxina = new Paragraph(registros["condominio_faxina"].ToString());
                    faxina.SetTextAlignment(TextAlignment.CENTER);
                    faxina.SetFontSize(5);

                    tabela.AddCell(faxina);

                    Paragraph recargaCelular = new Paragraph(registros["condominio_recarga_celular"].ToString());
                    recargaCelular.SetTextAlignment(TextAlignment.CENTER);
                    recargaCelular.SetFontSize(5);

                    tabela.AddCell(recargaCelular);

                    Paragraph outros = new Paragraph(registros["condominio_outros"].ToString());
                    outros.SetTextAlignment(TextAlignment.CENTER);
                    outros.SetFontSize(5);

                    tabela.AddCell(outros);

                    Paragraph total = new Paragraph(registros["condominio_valor_total"].ToString());
                    total.SetTextAlignment(TextAlignment.CENTER);
                    total.SetFontSize(5);

                    tabela.AddCell(total);

                    Paragraph mes = new Paragraph(registros["condominio_mes"].ToString());
                    mes.SetTextAlignment(TextAlignment.CENTER);
                    mes.SetFontSize(5);

                    tabela.AddCell(mes);

                    Paragraph ano = new Paragraph(registros["condominio_ano"].ToString());
                    ano.SetTextAlignment(TextAlignment.CENTER);
                    ano.SetFontSize(5);

                    tabela.AddCell(ano);
                }

                registros.Close();

                documento.Add(tabela);

                documento.Close();
                documentoPdf.Close();

                System.Diagnostics.Process.Start("C:\\Clínica Contabilidade\\condominio.pdf");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }


        //Aba 'Aluguel'
        //Todos os membros da clínica que não forem sócios devem pagar um valor de aluguel, valor este influenciado pelo período que o membro trabalha


        private void tabAluguel_Enter(object sender, EventArgs e)
        {          
            TabelaAluguel();
           
            if (cbPagamentosBrutoMes.Text != "" && txtPagamentosBrutoAno.Text != "")
            {
                cbAluguelMes.Text = cbPagamentosBrutoMes.Text;
                txtAluguelAno.Text = txtPagamentosBrutoAno.Text;
            }
            else
            {
                cbAluguelMes.SelectedIndex = -1;
                txtAluguelAno.Clear();
            }

            cbAluguelNome.SelectedIndex = -1;
            cbAluguelPeriodo.SelectedIndex = -1;
            txtAluguelValor.Clear();
            cbAluguelPesquisar.SelectedIndex = -1;
            cbAluguelPesquisarMes.SelectedIndex = -1;
            cbAluguelPesquisarMes.Visible = false;
            txtAluguelPesquisarAno.Clear();
            txtAluguelPesquisarAno.Visible = false;
            txtAluguelPesquisarNome.Clear();
            txtAluguelPesquisarNome.Visible = false;
            btnAluguelPesquisar.Visible = false;
        }

        private void txtAluguelAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 || txtAluguelAno.Text.Length == 4 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtAluguelValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAluguelValor.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtAluguelValor.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtAluguelValor.Text.Substring(txtAluguelValor.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtAluguelValor.Text == "0")
            {
                if (e.KeyChar != ',' && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void cbAluguelMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbAluguelNome.SelectedIndex = -1;
        }

        private void txtAluguelAno_TextChanged(object sender, EventArgs e)
        {
            cbAluguelNome.SelectedIndex = -1;
        }

        private void cbAluguelNome_DropDown(object sender, EventArgs e)
        {
            if (cbAluguelMes.Text == "" || txtAluguelAno.Text == "")
            {
                MessageBox.Show("Informe o mês e o ano no qual o aluguel se refere", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDecimal(txtAluguelAno.Text) < 2000 || Convert.ToDecimal(txtAluguelAno.Text) > 2099)
            {
                MessageBox.Show("Informe um ano válido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cbAluguelNome.DataSource = null;
            }
            else
            {
                SqlConnection conexao = null;

                try
                {
                    PagamentosBruto pagamentos = new PagamentosBruto(cbAluguelMes.Text, txtAluguelAno.Text);

                    conexao = new SqlConnection(StringConexao.stringConexao);

                    SqlCommand pesquisar = new SqlCommand("SELECT membro_id, membro_nome FROM tb_pagamentos_valor_bruto INNER JOIN tb_membros ON tb_pagamentos_valor_bruto.pagamento_bruto_membro = tb_membros.membro_id WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano AND membro_relacao_clinica = 'Não sócio' AND NOT membro_funcao = 'Secretaria' ORDER BY membro_nome;", conexao);

                    pesquisar.Parameters.AddWithValue("@mes", pagamentos.Mes);
                    pesquisar.Parameters.AddWithValue("@ano", pagamentos.Ano);

                    SqlDataAdapter registros2 = new SqlDataAdapter(pesquisar);

                    conexao.Close();

                    DataTable tabela = new DataTable();

                    registros2.Fill(tabela);

                    cbAluguelNome.ValueMember = "membro_id";
                    cbAluguelNome.DisplayMember = "membro_nome";
                    cbAluguelNome.DataSource = tabela;

                    if (tabela.Rows.Count == 0)
                    {
                        MessageBox.Show("Nenhum pagamento desta data foi informado");
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conexao != null && conexao.State != ConnectionState.Closed)
                    {
                        conexao.Close();
                    }
                }
            }
        }

        private void btnAluguelSalvar_Click(object sender, EventArgs e)
        {
            if (cbAluguelMes.Text == "" || txtAluguelAno.Text == "" || cbAluguelNome.Text == "" || cbAluguelPeriodo.Text == "" || txtAluguelValor.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDecimal(txtAluguelAno.Text) < 2000 || Convert.ToDecimal(txtAluguelAno.Text) > 2099)
            {
                MessageBox.Show("O ano informado não é válido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var botao = MessageBox.Show("Confirmar a inserção de dados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (botao == DialogResult.Yes)
                {
                    SqlConnection conexao = null;

                    try
                    {
                        Aluguel aluguel = new Aluguel(Convert.ToInt32(cbAluguelNome.SelectedValue), cbAluguelPeriodo.Text, Convert.ToDecimal(txtAluguelValor.Text), cbAluguelMes.Text, txtAluguelAno.Text);

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_aluguel WHERE aluguel_membro = @membro AND aluguel_mes = @mes AND aluguel_ano = @ano", conexao);

                        pesquisar.Parameters.AddWithValue("@membro", aluguel.Membro);
                        pesquisar.Parameters.AddWithValue("@mes", aluguel.Mes);
                        pesquisar.Parameters.AddWithValue("@ano", aluguel.Ano);

                        conexao.Open();

                        SqlDataReader registros = pesquisar.ExecuteReader();

                        if (registros.HasRows)
                        {
                            MessageBox.Show("O valor de aluguel deste membro já foi registrado nesta data", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            registros.Close();
                            conexao.Close();
                        }
                        else
                        {
                            registros.Close();

                            SqlCommand inserir = new SqlCommand("INSERT INTO tb_aluguel VALUES (@membro, @periodo, @valor, @mes, @ano);", conexao);

                            inserir.Parameters.AddWithValue("@membro", aluguel.Membro);
                            inserir.Parameters.AddWithValue("@periodo", aluguel.Periodo);
                            inserir.Parameters.AddWithValue("@valor", aluguel.Valor);
                            inserir.Parameters.AddWithValue("@mes", aluguel.Mes);
                            inserir.Parameters.AddWithValue("@ano", aluguel.Ano);

                            inserir.ExecuteNonQuery();

                            conexao.Close();

                            MessageBox.Show("Novo valor de aluguel inserido com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            cbAluguelNome.SelectedIndex = -1;
                            cbAluguelPeriodo.SelectedIndex = -1;
                            txtAluguelValor.Clear();

                            TabelaAluguel();
                        }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conexao != null && conexao.State != ConnectionState.Closed)
                        {
                            conexao.Close();
                        }
                    }
                }
            }
        }

        private void dgvAluguel_DoubleClick(object sender, EventArgs e)
        {
            if (dgvAluguel.SelectedRows.Count == 1)
            {
                frmAluguelAlterarDeletar aluguel = new frmAluguelAlterarDeletar(dgvAluguel.SelectedRows[0].Cells[4].Value.ToString(), dgvAluguel.SelectedRows[0].Cells[5].Value.ToString(), dgvAluguel.SelectedRows[0].Cells[1].Value.ToString(), dgvAluguel.SelectedRows[0].Cells[2].Value.ToString(), dgvAluguel.SelectedRows[0].Cells[3].Value.ToString(), dgvAluguel.SelectedRows[0].Cells[0].Value.ToString());

                if (cbPagamentosBrutoMes.Text != "" && txtPagamentosBrutoAno.Text != "")
                {
                    aluguel.Mes = cbPagamentosBrutoMes.Text;
                    aluguel.Ano = txtPagamentosBrutoAno.Text;
                }

                aluguel.Show();
                this.Hide();
            }
        }

        private void cbAluguelPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAluguelPesquisar.Text == "Data")
            {
                cbAluguelPesquisarMes.Visible = true;
                txtAluguelPesquisarAno.Visible = true;

                cbAluguelPesquisarMes.SelectedIndex = -1;
                txtAluguelPesquisarAno.Clear();

                btnAluguelPesquisar.Visible = true;                

                txtAluguelPesquisarNome.Visible = false;
            }
            else if (cbAluguelPesquisar.Text == "Nome")
            {
                cbAluguelPesquisarMes.Visible = false;
                txtAluguelPesquisarAno.Visible = false;

                btnAluguelPesquisar.Visible = false;

                txtAluguelPesquisarNome.Visible = true;

                txtAluguelPesquisarNome.Clear();
            }
        }

        private void btnAluguelPesquisar_Click(object sender, EventArgs e)
        {
            
             if (cbAluguelPesquisarMes.Text == "" || txtAluguelPesquisarAno.Text == "")
             {
                 MessageBox.Show("Informe todas as informações para a pesquisa", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
             else if (Convert.ToDecimal(txtAluguelPesquisarAno.Text) < 2000 || Convert.ToDecimal(txtAluguelPesquisarAno.Text) > 2099)
             {
                 MessageBox.Show("Informe um ano válido para pesquisar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
             else
             {
                 SqlConnection conexao = null;

                 try
                 {
                     Aluguel aluguel = new Aluguel(cbAluguelPesquisarMes.Text, txtAluguelPesquisarAno.Text);

                     conexao = new SqlConnection(StringConexao.stringConexao);

                     SqlCommand pesquisar = new SqlCommand("SELECT aluguel_id, membro_nome, aluguel_periodo, aluguel_valor, aluguel_mes, aluguel_ano FROM tb_aluguel INNER JOIN tb_membros ON tb_aluguel.aluguel_membro = tb_membros.membro_id WHERE aluguel_mes = @mes AND aluguel_ano = @ano ORDER BY membro_nome;", conexao);

                     pesquisar.Parameters.AddWithValue("@mes", aluguel.Mes);
                     pesquisar.Parameters.AddWithValue("@ano", aluguel.Ano);

                     conexao.Open();

                     SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                     conexao.Close();

                     DataTable tabela = new DataTable();

                     registros.Fill(tabela);

                     dgvAluguel.DataSource = tabela;
                 }
                 catch (Exception erro)
                 {
                     MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                 finally
                 {
                    if (conexao != null && conexao.State != ConnectionState.Closed)
                    {
                        conexao.Close();
                    }
                 }
            }            
        }

        private void txtAluguelPesquisarNome_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = conexao.CreateCommand();

                if (txtAluguelPesquisarNome.Text != "")
                {
                    pesquisar.CommandText = "SELECT aluguel_id, membro_nome, aluguel_periodo, aluguel_valor, aluguel_mes, aluguel_ano FROM tb_aluguel INNER JOIN tb_membros ON tb_aluguel.aluguel_membro = tb_membros.membro_id  WHERE membro_nome LIKE @nome ORDER BY membro_nome, aluguel_ano, aluguel_mes;";

                    pesquisar.Parameters.AddWithValue("@nome", '%' + txtAluguelPesquisarNome.Text + '%');
                }
                else
                {
                    pesquisar.CommandText = "SELECT aluguel_id, membro_nome, aluguel_periodo, aluguel_valor, aluguel_mes, aluguel_ano FROM tb_aluguel INNER JOIN tb_membros ON tb_aluguel.aluguel_membro = tb_membros.membro_id ORDER BY aluguel_ano, aluguel_mes, membro_nome;";
                }               

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                dgvAluguel.DataSource = tabela;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }

        private void txtAluguelPesquisarAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 || txtAluguelPesquisarAno.Text.Length == 4 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtAluguelPesquisarNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAluguelPesquisarNome.Text == "")
            {
                if (!char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32)
                {
                    e.Handled = true;
                }
            }
        }


        //Aba 'Pagamentos - valor líquido'
        //Nesta aba serão apresentados os pagamentos (valor líquido) de todos os membros da clínica


        private void tabPagamentosLiquido_Enter(object sender, EventArgs e)
        {           
            TabelaPagamentosLiquido();
                              
            if (cbPagamentosBrutoMes.Text != "" && txtPagamentosBrutoAno.Text != "")
            {
                cbPagamentoLiquidoMes.Text = cbPagamentosBrutoMes.Text;
                txtPagamentoLiquidoAno.Text = txtPagamentosBrutoAno.Text;
            }
            else
            {
                cbPagamentoLiquidoMes.SelectedIndex = -1;
                txtPagamentoLiquidoAno.Clear();
            }

            cbPesquisarPagamentoLiquido.SelectedIndex = -1;        
            cbPesquisarPagamentoLiquidoMes.Visible = false;          
            cbPesquisarPagamentoLiquidoMes.SelectedIndex = -1;          
            txtPesquisarPagamentoLiquidoAno.Visible = false;          
            txtPesquisarPagamentoLiquidoAno.Clear();          
            txtPesquisarPagamentoLiquidoNome.Visible = false;          
            txtPesquisarPagamentoLiquidoNome.Clear();
            btnPesquisarPagamentoLiquido.Visible = false;
            btnPagamentosLiquidoPesquisarImprimir.Visible = false;
        }

        private void btnPagamentoLiquidoSalvar_Click(object sender, EventArgs e)
        {
            if (cbPagamentoLiquidoMes.Text == "" || txtPagamentoLiquidoAno.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDecimal(txtPagamentoLiquidoAno.Text) < 2000 || Convert.ToDecimal(txtPagamentoLiquidoAno.Text) > 2099)
            {
                MessageBox.Show("Informe um ano válido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var botao = MessageBox.Show("Confirmar inserção de dados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                

                if (botao == DialogResult.Yes)
                {
                    SqlConnection conexao = null;

                    try
                    {
                        PagamentosBruto pagamentosBruto = new PagamentosBruto(cbPagamentoLiquidoMes.Text, txtPagamentoLiquidoAno.Text);

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_socios WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                        pesquisar.Parameters.AddWithValue("@mes", pagamentosBruto.Mes);
                        pesquisar.Parameters.AddWithValue("@ano", pagamentosBruto.Ano);

                        SqlCommand pesquisar2 = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_nao_socios WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                        pesquisar2.Parameters.AddWithValue("@mes", pagamentosBruto.Mes);
                        pesquisar2.Parameters.AddWithValue("@ano", pagamentosBruto.Ano);

                        SqlCommand pesquisar3 = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_secretaria WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                        pesquisar3.Parameters.AddWithValue("@mes", pagamentosBruto.Mes);
                        pesquisar3.Parameters.AddWithValue("@ano", pagamentosBruto.Ano);

                        conexao.Open();

                        int quantidade = Convert.ToInt32(pesquisar.ExecuteScalar());
                        int quantidade2 = Convert.ToInt32(pesquisar2.ExecuteScalar());
                        int quantidade3 = Convert.ToInt32(pesquisar3.ExecuteScalar());

                        if (quantidade > 0 || quantidade2 > 0 || quantidade3 > 0)
                        {
                            MessageBox.Show("Os pagamentos deste mês e ano já foram informados", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            
                            conexao.Close();
                        }
                       else
                       {                         
                            SqlCommand pesquisar4 = new SqlCommand("SELECT * FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano", conexao);

                            pesquisar4.Parameters.AddWithValue("@mes", pagamentosBruto.Mes);
                            pesquisar4.Parameters.AddWithValue("@ano", pagamentosBruto.Ano);
                                

                            SqlDataReader registros = pesquisar4.ExecuteReader();

                            if (registros.HasRows == false)
                            {
                                MessageBox.Show("Os pagamentos (valor bruto) deste mês e ano não foram informados", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                registros.Close();
                                conexao.Close();
                            }
                            else
                            {
                                registros.Close();                                

                                SqlCommand pesquisar5 = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_valor_bruto INNER JOIN tb_membros ON tb_pagamentos_valor_bruto.pagamento_bruto_membro = tb_membros.membro_id  WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano AND NOT membro_funcao = 'Secretaria';", conexao);

                                pesquisar5.Parameters.AddWithValue("@mes", pagamentosBruto.Mes);
                                pesquisar5.Parameters.AddWithValue("@ano", pagamentosBruto.Ano);

                                int pagamentosQuantidade = Convert.ToInt32(pesquisar5.ExecuteScalar());

                                SqlCommand pesquisar6 = new SqlCommand("SELECT COUNT(*) FROM tb_impostos WHERE imposto_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                                pesquisar6.Parameters.AddWithValue("@mes", pagamentosBruto.Mes);
                                pesquisar6.Parameters.AddWithValue("@ano", pagamentosBruto.Ano);

                                int impostosQuantidade = Convert.ToInt32(pesquisar6.ExecuteScalar());

                                if (pagamentosQuantidade != impostosQuantidade)
                                {
                                    MessageBox.Show("Não foram informados todos os impostos desta data", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    conexao.Close();
                                }
                                else
                                {
                                    SqlCommand pesquisar7 = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_valor_bruto INNER JOIN tb_membros ON tb_pagamentos_valor_bruto.pagamento_bruto_membro = tb_membros.membro_id  WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano AND membro_relacao_clinica = 'Não Sócio' AND NOT membro_funcao = 'Secretaria';", conexao);

                                    pesquisar7.Parameters.AddWithValue("@mes", pagamentosBruto.Mes);
                                    pesquisar7.Parameters.AddWithValue("@ano", pagamentosBruto.Ano);

                                    int pagamentosQuantidade2 = Convert.ToInt32(pesquisar7.ExecuteScalar());

                                    SqlCommand pesquisar8 = new SqlCommand("SELECT COUNT(*) FROM tb_aluguel WHERE aluguel_mes = @mes AND aluguel_ano = @ano;", conexao);

                                    pesquisar8.Parameters.AddWithValue("@mes", pagamentosBruto.Mes);
                                    pesquisar8.Parameters.AddWithValue("@ano", pagamentosBruto.Ano);

                                    int alugueisQuantidade = Convert.ToInt32(pesquisar8.ExecuteScalar());

                                    if (pagamentosQuantidade2 != alugueisQuantidade)
                                    {
                                         MessageBox.Show("Não foram informados todos os valores de aluguel desta data", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            
                                         conexao.Close();
                                    }
                                    else
                                    {                                       
                                        SqlCommand pesquisar9 = new SqlCommand("SELECT COUNT(*) FROM tb_membros_condominio WHERE membro_condominio_mes = ANY (SELECT horas_trabalhadas_id FROM tb_horas_trabalhadas WHERE horas_trabalhadas_mes = @mes AND horas_trabalhadas_ano = @ano);", conexao);

                                        pesquisar9.Parameters.AddWithValue("@mes", pagamentosBruto.Mes);
                                        pesquisar9.Parameters.AddWithValue("@ano", pagamentosBruto.Ano);

                                        int condominioQuantidade = Convert.ToInt32(pesquisar9.ExecuteScalar());

                                        if (condominioQuantidade == 0)
                                        {
                                            MessageBox.Show("Os valores de condomínio deste mês e ano ainda não foram informados", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            
                                            conexao.Close();
                                        }
                                        else if (pagamentosQuantidade != condominioQuantidade)
                                        {
                                            MessageBox.Show("Há mais pagamentos (valor bruto) do que valores de condomínio. Informe as horas na clínica de todos os membros e refaça o cálculo de valores de condomínio desta data", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                            conexao.Close();
                                        }
                                        else
                                        {
                                            SqlCommand pesquisarMembrosQuantidade = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano;", conexao);

                                            pesquisarMembrosQuantidade.Parameters.AddWithValue("@mes", pagamentosBruto.Mes);
                                            pesquisarMembrosQuantidade.Parameters.AddWithValue("@ano", pagamentosBruto.Ano);

                                            int membrosQuantidade = Convert.ToInt32(pesquisarMembrosQuantidade.ExecuteScalar());

                                            SqlCommand pesquisarMembros = new SqlCommand("SELECT pagamento_bruto_membro FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano;", conexao);

                                            pesquisarMembros.Parameters.AddWithValue("@mes", pagamentosBruto.Mes);
                                            pesquisarMembros.Parameters.AddWithValue("@ano", pagamentosBruto.Ano);

                                            SqlDataReader membrosRegistros = pesquisarMembros.ExecuteReader();
                                            ;
                                            PagamentosLiquido pagamentos = new PagamentosLiquido();

                                            pagamentos.Membro = new int[membrosQuantidade];

                                            int contador = 0;

                                            while (membrosRegistros.Read())
                                            {
                                                pagamentos.Membro[contador] = Convert.ToInt32(membrosRegistros["pagamento_bruto_membro"]);

                                                if (contador < membrosQuantidade - 1)
                                                {
                                                    contador += 1;
                                                }
                                            }

                                            membrosRegistros.Close();

                                            contador = 0;

                                            while (contador < membrosQuantidade)
                                            {
                                                SqlCommand pesquisarPagamento = new SqlCommand("SELECT pagamento_bruto_id, pagamento_bruto_valor FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_membro = @membro AND pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano;", conexao);

                                                pesquisarPagamento.Parameters.AddWithValue("@membro", pagamentos.Membro[contador]);
                                                pesquisarPagamento.Parameters.AddWithValue("@mes", pagamentosBruto.Mes);
                                                pesquisarPagamento.Parameters.AddWithValue("@ano", pagamentosBruto.Ano);

                                                SqlDataReader registrosPagamento = pesquisarPagamento.ExecuteReader();

                                                registrosPagamento.Read();

                                                pagamentos.ValorBruto = Convert.ToInt32(registrosPagamento["pagamento_bruto_id"]);
                                                pagamentos.Valor = Convert.ToDecimal(registrosPagamento["pagamento_bruto_valor"]);
                                                pagamentos.Mes = Convert.ToInt32(registrosPagamento["pagamento_bruto_id"]);
                                                pagamentos.Ano = Convert.ToInt32(registrosPagamento["pagamento_bruto_id"]);

                                                registrosPagamento.Close();

                                                SqlCommand pesquisarMembro = new SqlCommand("SELECT membro_funcao, membro_relacao_clinica FROM tb_membros WHERE membro_id = @id;", conexao);

                                                pesquisarMembro.Parameters.AddWithValue("@id", pagamentos.Membro[contador]);

                                                SqlDataReader membroRegistros = pesquisarMembro.ExecuteReader();

                                                membroRegistros.Read();

                                                Membros membro = new Membros(membroRegistros["membro_funcao"].ToString(), membroRegistros["membro_relacao_clinica"].ToString());

                                                membroRegistros.Close();

                                                if (membro.Funcao == "Secretaria")
                                                {
                                                    pagamentos.Imposto = 0;
                                                    pagamentos.Condominio = 0;
                                                    pagamentos.Aluguel = 0;

                                                    SqlCommand inserir = new SqlCommand("INSERT INTO tb_pagamentos_secretaria VALUES (@membro, @valorBruto, @imposto, @condominio, @aluguel, @valor, @mes, @ano);", conexao);

                                                    inserir.Parameters.AddWithValue("@membro", pagamentos.Membro[contador]);
                                                    inserir.Parameters.AddWithValue("@valorBruto", pagamentos.ValorBruto);
                                                    inserir.Parameters.AddWithValue("@imposto", pagamentos.Imposto);
                                                    inserir.Parameters.AddWithValue("@condominio", pagamentos.Condominio);
                                                    inserir.Parameters.AddWithValue("@aluguel", pagamentos.Aluguel);
                                                    inserir.Parameters.AddWithValue("@valor", pagamentos.Valor);
                                                    inserir.Parameters.AddWithValue("@mes", pagamentos.Mes);
                                                    inserir.Parameters.AddWithValue("@ano", pagamentos.Ano);

                                                    inserir.ExecuteNonQuery();
                                                }
                                                else
                                                {
                                                    SqlCommand pesquisarImposto = new SqlCommand("SELECT imposto_id, imposto_valor FROM tb_impostos WHERE imposto_mes = @mes;", conexao);

                                                    pesquisarImposto.Parameters.AddWithValue("@mes", pagamentos.Mes);

                                                    SqlDataReader registrosImposto = pesquisarImposto.ExecuteReader();

                                                    registrosImposto.Read();

                                                    pagamentos.Imposto = Convert.ToInt32(registrosImposto["imposto_id"]);
                                                    pagamentos.Valor -= Convert.ToDecimal(registrosImposto["imposto_valor"]);

                                                    registrosImposto.Close();

                                                    SqlCommand pesquisarCondominio = new SqlCommand("SELECT membro_condominio_id, membro_condominio_valor FROM tb_membros_condominio WHERE membro_condominio_mes = (SELECT horas_trabalhadas_id FROM tb_horas_trabalhadas WHERE horas_trabalhadas_membro = @membro AND horas_trabalhadas_mes = @mes AND horas_trabalhadas_ano = @ano);", conexao);

                                                    pesquisarCondominio.Parameters.AddWithValue("@membro", pagamentos.Membro[contador]);
                                                    pesquisarCondominio.Parameters.AddWithValue("@mes", pagamentosBruto.Mes);
                                                    pesquisarCondominio.Parameters.AddWithValue("@ano", pagamentosBruto.Ano);

                                                    SqlDataReader registrosCondominio = pesquisarCondominio.ExecuteReader();

                                                    registrosCondominio.Read();

                                                    pagamentos.Condominio = Convert.ToInt32(registrosCondominio["membro_condominio_id"]);
                                                    pagamentos.Valor -= Convert.ToDecimal(registrosCondominio["membro_condominio_valor"]);

                                                    registrosCondominio.Close();

                                                    if (membro.Relacao == "Sócio")
                                                    {
                                                        pagamentos.Aluguel = 0;

                                                        SqlCommand inserir = new SqlCommand("INSERT INTO tb_pagamentos_socios VALUES (@membro, @valorBruto, @imposto, @condominio, @aluguel, @valor, @mes, @ano);", conexao);

                                                        inserir.Parameters.AddWithValue("@membro", pagamentos.Membro[contador]);
                                                        inserir.Parameters.AddWithValue("@valorBruto", pagamentos.ValorBruto);
                                                        inserir.Parameters.AddWithValue("@imposto", pagamentos.Imposto);
                                                        inserir.Parameters.AddWithValue("@condominio", pagamentos.Condominio);
                                                        inserir.Parameters.AddWithValue("@aluguel", pagamentos.Aluguel);
                                                        inserir.Parameters.AddWithValue("@valor", pagamentos.Valor);
                                                        inserir.Parameters.AddWithValue("@mes", pagamentos.Mes);
                                                        inserir.Parameters.AddWithValue("@ano", pagamentos.Ano);

                                                        inserir.ExecuteNonQuery();
                                                    }
                                                    else
                                                    {
                                                        SqlCommand pesquisarAluguel = new SqlCommand("SELECT aluguel_id, aluguel_valor FROM tb_aluguel WHERE aluguel_membro = @membro AND aluguel_mes = @mes AND aluguel_ano = @ano;", conexao);

                                                        pesquisarAluguel.Parameters.AddWithValue("@membro", pagamentos.Membro[contador]);
                                                        pesquisarAluguel.Parameters.AddWithValue("@mes", pagamentosBruto.Mes);
                                                        pesquisarAluguel.Parameters.AddWithValue("@ano", pagamentosBruto.Ano);

                                                        SqlDataReader registrosAluguel = pesquisarAluguel.ExecuteReader();

                                                        registrosAluguel.Read();

                                                        pagamentos.Aluguel = Convert.ToInt32(registrosAluguel["aluguel_id"]);
                                                        pagamentos.Valor -= Convert.ToDecimal(registrosAluguel["aluguel_valor"]);

                                                        registrosAluguel.Close();

                                                        SqlCommand inserir = new SqlCommand("INSERT INTO tb_pagamentos_nao_socios VALUES (@membro, @valorBruto, @imposto, @condominio, @aluguel, @valor, @mes, @ano);", conexao);

                                                        inserir.Parameters.AddWithValue("@membro", pagamentos.Membro[contador]);
                                                        inserir.Parameters.AddWithValue("@valorBruto", pagamentos.ValorBruto);
                                                        inserir.Parameters.AddWithValue("@imposto", pagamentos.Imposto);
                                                        inserir.Parameters.AddWithValue("@condominio", pagamentos.Condominio);
                                                        inserir.Parameters.AddWithValue("@aluguel", pagamentos.Aluguel);
                                                        inserir.Parameters.AddWithValue("@valor", pagamentos.Valor);
                                                        inserir.Parameters.AddWithValue("@mes", pagamentos.Mes);
                                                        inserir.Parameters.AddWithValue("@ano", pagamentos.Ano);

                                                        inserir.ExecuteNonQuery();
                                                    }
                                                }

                                                contador += 1;
                                            }

                                            conexao.Close();

                                            MessageBox.Show("Cálculos e inserções de pagamentos (valor líquido) feitos com sucesso", "Operação bem sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            cbPagamentoLiquidoMes.SelectedIndex = -1;
                                            txtPagamentoLiquidoAno.Clear();

                                            TabelaPagamentosLiquido();
                                        }
                                    }                                    
                                }
                            }                            
                       }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conexao != null && conexao.State != ConnectionState.Closed)
                        {
                            conexao.Close();
                        }
                    }
                }
            }
        }       

        private void btnPagamentoLiquidoDeletar_Click(object sender, EventArgs e)
        {
            if (cbPagamentoLiquidoMes.Text == "" || txtPagamentoLiquidoAno.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDecimal(txtPagamentoLiquidoAno.Text) < 2000 || Convert.ToDecimal(txtPagamentoLiquidoAno.Text) > 2099)
            {
                MessageBox.Show("Informe um ano válido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection conexao = null;

                try
                {
                    var botao = MessageBox.Show("Confirmar a remoção de registros?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (botao == DialogResult.Yes)
                    {
                        PagamentosBruto pagamento = new PagamentosBruto(cbPagamentoLiquidoMes.Text, txtPagamentoLiquidoAno.Text);

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_socios WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                        pesquisar.Parameters.AddWithValue("@mes", pagamento.Mes);
                        pesquisar.Parameters.AddWithValue("@ano", pagamento.Ano);

                        SqlCommand pesquisar2 = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_nao_socios WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                        pesquisar2.Parameters.AddWithValue("@mes", pagamento.Mes);
                        pesquisar2.Parameters.AddWithValue("@ano", pagamento.Ano);

                        SqlCommand pesquisar3 = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_secretaria WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                        pesquisar3.Parameters.AddWithValue("@mes", pagamento.Mes);
                        pesquisar3.Parameters.AddWithValue("@ano", pagamento.Ano);

                        conexao.Open();

                        int quantidade = Convert.ToInt32(pesquisar.ExecuteScalar());
                        int quantidade2 = Convert.ToInt32(pesquisar2.ExecuteScalar());
                        int quantidade3 = Convert.ToInt32(pesquisar3.ExecuteScalar());

                        if (quantidade == 0 && quantidade2 == 0 && quantidade3 == 0)
                        {
                            MessageBox.Show("Não há registros deste mês e ano", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                       
                            conexao.Close();
                        }
                        else
                        {
                            SqlCommand pesquisar4 = new SqlCommand("SELECT * FROM tb_saldos WHERE saldo_mes = @mes AND saldo_ano = @ano;", conexao);

                            pesquisar4.Parameters.AddWithValue("@mes", pagamento.Mes);
                            pesquisar4.Parameters.AddWithValue("@ano", pagamento.Ano);

                            SqlDataReader registros = pesquisar4.ExecuteReader();

                            if (registros.HasRows)
                            {
                                MessageBox.Show("Uma registro na tabela de saldos está fazendo uso destas informações. Apague-o para poder remover estes registros", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                registros.Close();
                                conexao.Close();
                            }
                            else
                            {
                                registros.Close();

                                SqlCommand deletar = new SqlCommand("DELETE FROM tb_pagamentos_socios WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                                deletar.Parameters.AddWithValue("@mes", pagamento.Mes);
                                deletar.Parameters.AddWithValue("@ano", pagamento.Ano);

                                deletar.ExecuteNonQuery();

                                SqlCommand deletar2 = new SqlCommand("DELETE FROM tb_pagamentos_nao_socios WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                                deletar2.Parameters.AddWithValue("@mes", pagamento.Mes);
                                deletar2.Parameters.AddWithValue("@ano", pagamento.Ano);

                                deletar2.ExecuteNonQuery();

                                SqlCommand deletar3 = new SqlCommand("DELETE FROM tb_pagamentos_secretaria WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                                deletar3.Parameters.AddWithValue("@mes", pagamento.Mes);
                                deletar3.Parameters.AddWithValue("@ano", pagamento.Ano);

                                deletar3.ExecuteNonQuery();

                                MessageBox.Show("Remoção de registros feita com sucesso", "Operação bem sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                TabelaPagamentosLiquido();
                            }                           
                        }
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conexao != null && conexao.State != ConnectionState.Closed)
                    {
                        conexao.Close();
                    }
                }
            }
        }

        private void txtPagamentoLiquidoAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 || txtPagamentoLiquidoAno.Text.Length == 4 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtPesquisarPagamentoLiquidoAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 || txtPesquisarPagamentoLiquidoAno.Text.Length == 4 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtPesquisarPagamentoLiquidoAno_TextChanged(object sender, EventArgs e)
        {
            btnPagamentosLiquidoPesquisarImprimir.Visible = false;
        }

        private void cbPesquisarPagamentoLiquidoMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnPagamentosLiquidoPesquisarImprimir.Visible = false;
        }

        private void txtPesquisarPagamentoLiquidoNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPesquisarPagamentoLiquidoNome.Text == "")             
            {
                if (!char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32)     
                {
                    e.Handled = true;
                }
            }
        }

        private void btnPesquisarPagamentoLiquido_Click(object sender, EventArgs e)
        {
            if (cbPesquisarPagamentoLiquidoMes.Text == "" || txtPesquisarPagamentoLiquidoAno.Text == "")
            {
                MessageBox.Show("Informe todas as informações para a pesquisa", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDecimal(txtPesquisarPagamentoLiquidoAno.Text) < 2000 || Convert.ToDecimal(txtPesquisarPagamentoLiquidoAno.Text) > 2099)
            {
                MessageBox.Show("Informe um ano válido para pesquisar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection conexao = null;

                try
                {
                    PagamentosBruto pagamentos = new PagamentosBruto(cbPesquisarPagamentoLiquidoMes.Text, txtPesquisarPagamentoLiquidoAno.Text);

                    conexao = new SqlConnection(StringConexao.stringConexao);

                    SqlCommand pesquisar = new SqlCommand("SELECT membro_nome, pagamento_bruto_valor, imposto_valor, membro_condominio_valor, aluguel_valor, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_nao_socios INNER JOIN tb_membros ON tb_pagamentos_nao_socios.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_nao_socios.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id INNER JOIN tb_impostos ON tb_pagamentos_nao_socios.desconto_imposto = tb_impostos.imposto_id INNER JOIN tb_membros_condominio ON tb_pagamentos_nao_socios.desconto_condominio = tb_membros_condominio.membro_condominio_id INNER JOIN tb_aluguel ON tb_pagamentos_nao_socios.desconto_aluguel = tb_aluguel.aluguel_id WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano UNION SELECT membro_nome, pagamento_bruto_valor, imposto_valor, membro_condominio_valor, desconto_aluguel, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_socios INNER JOIN tb_membros ON tb_pagamentos_socios.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_socios.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id INNER JOIN tb_impostos ON tb_pagamentos_socios.desconto_imposto = tb_impostos.imposto_id INNER JOIN tb_membros_condominio ON tb_pagamentos_socios.desconto_condominio = tb_membros_condominio.membro_condominio_id WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano UNION SELECT membro_nome, pagamento_bruto_valor, desconto_imposto, desconto_condominio, desconto_aluguel, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_secretaria INNER JOIN tb_membros ON tb_pagamentos_secretaria.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_secretaria.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano ORDER BY membro_nome;", conexao);

                    pesquisar.Parameters.AddWithValue("@mes", pagamentos.Mes);
                    pesquisar.Parameters.AddWithValue("@ano", pagamentos.Ano);

                    conexao.Open();

                    SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                    conexao.Close();

                    DataTable tabela = new DataTable();

                    registros.Fill(tabela);

                    dgvPagamentosLiquido.DataSource = tabela;

                    if (tabela.Rows.Count > 0)
                    {
                        btnPagamentosLiquidoPesquisarImprimir.Visible = true;
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conexao != null && conexao.State != ConnectionState.Closed)
                    {
                        conexao.Close();
                    }
                }
            }
        }

        private void cbPesquisarPagamentoLiquido_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPesquisarPagamentoLiquido.Text == "Data")
            {
                cbPesquisarPagamentoLiquidoMes.Visible = true;
                txtPesquisarPagamentoLiquidoAno.Visible = true;

                cbPesquisarPagamentoLiquidoMes.SelectedIndex = -1;
                txtPesquisarPagamentoLiquidoAno.Clear();

                btnPesquisarPagamentoLiquido.Visible = true;

                txtPesquisarPagamentoLiquidoNome.Visible = false;
            }
            else if (cbPesquisarPagamentoLiquido.Text == "Nome")
            {
                cbPesquisarPagamentoLiquidoMes.Visible = false;
                txtPesquisarPagamentoLiquidoAno.Visible = false;

                btnPesquisarPagamentoLiquido.Visible = false;

                txtPesquisarPagamentoLiquidoNome.Visible = true;
                txtPesquisarPagamentoLiquidoNome.Clear();
            }

            btnPagamentosLiquidoPesquisarImprimir.Visible = false;
        }

        private void txtPesquisarPagamentoLiquidoNome_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = conexao.CreateCommand();

                if (txtPesquisarPagamentoLiquidoNome.Text != "")
                {
                    pesquisar.CommandText = "SELECT membro_nome, pagamento_bruto_valor, imposto_valor, membro_condominio_valor, aluguel_valor, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_nao_socios INNER JOIN tb_membros ON tb_pagamentos_nao_socios.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_nao_socios.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id INNER JOIN tb_impostos ON tb_pagamentos_nao_socios.desconto_imposto = tb_impostos.imposto_id INNER JOIN tb_membros_condominio ON tb_pagamentos_nao_socios.desconto_condominio = tb_membros_condominio.membro_condominio_id INNER JOIN tb_aluguel ON tb_pagamentos_nao_socios.desconto_aluguel = tb_aluguel.aluguel_id WHERE membro_nome LIKE @membro UNION SELECT membro_nome, pagamento_bruto_valor, imposto_valor, membro_condominio_valor, desconto_aluguel, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_socios INNER JOIN tb_membros ON tb_pagamentos_socios.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_socios.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id INNER JOIN tb_impostos ON tb_pagamentos_socios.desconto_imposto = tb_impostos.imposto_id INNER JOIN tb_membros_condominio ON tb_pagamentos_socios.desconto_condominio = tb_membros_condominio.membro_condominio_id WHERE membro_nome LIKE @membro UNION SELECT membro_nome, pagamento_bruto_valor, desconto_imposto, desconto_condominio, desconto_aluguel, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_secretaria INNER JOIN tb_membros ON tb_pagamentos_secretaria.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_secretaria.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id WHERE membro_nome LIKE @membro ORDER BY membro_nome, pagamento_bruto_ano, pagamento_bruto_mes;";

                    pesquisar.Parameters.AddWithValue("@membro", '%' + txtPesquisarPagamentoLiquidoNome.Text + '%');
                }
                else
                {
                    pesquisar.CommandText = "SELECT membro_nome, pagamento_bruto_valor, imposto_valor, membro_condominio_valor, aluguel_valor, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_nao_socios INNER JOIN tb_membros ON tb_pagamentos_nao_socios.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_nao_socios.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id INNER JOIN tb_impostos ON tb_pagamentos_nao_socios.desconto_imposto = tb_impostos.imposto_id INNER JOIN tb_membros_condominio ON tb_pagamentos_nao_socios.desconto_condominio = tb_membros_condominio.membro_condominio_id INNER JOIN tb_aluguel ON tb_pagamentos_nao_socios.desconto_aluguel = tb_aluguel.aluguel_id UNION SELECT membro_nome, pagamento_bruto_valor, imposto_valor, membro_condominio_valor, desconto_aluguel, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_socios INNER JOIN tb_membros ON tb_pagamentos_socios.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_socios.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id INNER JOIN tb_impostos ON tb_pagamentos_socios.desconto_imposto = tb_impostos.imposto_id INNER JOIN tb_membros_condominio ON tb_pagamentos_socios.desconto_condominio = tb_membros_condominio.membro_condominio_id UNION SELECT membro_nome, pagamento_bruto_valor, desconto_imposto, desconto_condominio, desconto_aluguel, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_secretaria INNER JOIN tb_membros ON tb_pagamentos_secretaria.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_secretaria.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id ORDER BY pagamento_bruto_ano, pagamento_bruto_mes, membro_nome;";
                }                  

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                dgvPagamentosLiquido.DataSource = tabela;

                if (tabela.Rows.Count > 0 && txtPesquisarPagamentoLiquidoNome.Text != "")
                {
                    btnPagamentosLiquidoPesquisarImprimir.Visible = true;
                }
                else
                {
                    btnPagamentosLiquidoPesquisarImprimir.Visible = false;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }

        private void btnPagamentosLiquidoImprimir_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_socios;", conexao);

                SqlCommand pesquisar2 = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_nao_socios;", conexao);

                SqlCommand pesquisar3 = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_secretaria;", conexao);

                conexao.Open();               

                int quantidade = Convert.ToInt32(pesquisar.ExecuteScalar());
                int quantidade2 = Convert.ToInt32(pesquisar2.ExecuteScalar());
                int quantidade3 = Convert.ToInt32(pesquisar3.ExecuteScalar());

                if (quantidade == 0 && quantidade2 == 0 && quantidade3 == 0)
                {
                    conexao.Close();
                }
                else
                {
                    PdfWriter pdf = new PdfWriter("C:\\Clínica Contabilidade\\pagamentos.pdf");

                    PdfDocument documentoPdf = new PdfDocument(pdf);

                    Document documento = new Document(documentoPdf, PageSize.A4);

                    Paragraph cabecalho = new Paragraph("Espaço Entre Saúde Mental e Qualidade de Vida - Pagamentos");
                    cabecalho.SetTextAlignment(TextAlignment.CENTER);
                    cabecalho.SetFontSize(16);

                    documento.Add(cabecalho);

                    Table tabela = new Table(new float[] {15, 15, 15, 15, 15, 15, 5, 5});
                    tabela.SetWidth(UnitValue.CreatePercentValue(100));

                    Paragraph cabecalhoNome = new Paragraph("Nome");
                    cabecalhoNome.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoNome.SetFontSize(10);

                    tabela.AddCell(cabecalhoNome);

                    Paragraph cabecalhoValorBruto = new Paragraph("Valor bruto (R$)");
                    cabecalhoValorBruto.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoValorBruto.SetFontSize(10);

                    tabela.AddCell(cabecalhoValorBruto);

                    Paragraph cabecalhoImposto = new Paragraph("Imposto (R$)");
                    cabecalhoImposto.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoImposto.SetFontSize(10);

                    tabela.AddCell(cabecalhoImposto);

                    Paragraph cabecalhoCondominio = new Paragraph("Condominio (R$)");
                    cabecalhoCondominio.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoCondominio.SetFontSize(10);

                    tabela.AddCell(cabecalhoCondominio);

                    Paragraph cabecalhoAluguel = new Paragraph("Aluguel (R$)");
                    cabecalhoAluguel.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoAluguel.SetFontSize(10);

                    tabela.AddCell(cabecalhoAluguel);

                    Paragraph cabecalhoValorLiquido = new Paragraph("Valor líquido (R$)");
                    cabecalhoValorLiquido.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoValorLiquido.SetFontSize(10);

                    tabela.AddCell(cabecalhoValorLiquido);

                    Paragraph cabecalhoMes = new Paragraph("Mês");
                    cabecalhoMes.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoMes.SetFontSize(10);

                    tabela.AddCell(cabecalhoMes);

                    Paragraph cabecalhoAno = new Paragraph("Ano");
                    cabecalhoAno.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoAno.SetFontSize(10);

                    tabela.AddCell(cabecalhoAno);                    

                    
                    SqlCommand pesquisar4 = new SqlCommand("SELECT membro_nome, pagamento_bruto_valor, desconto_imposto, imposto_valor, desconto_condominio, membro_condominio_valor, desconto_aluguel, aluguel_valor, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_nao_socios INNER JOIN tb_membros ON tb_pagamentos_nao_socios.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_nao_socios.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id INNER JOIN tb_impostos ON tb_pagamentos_nao_socios.desconto_imposto = tb_impostos.imposto_id INNER JOIN tb_membros_condominio ON tb_pagamentos_nao_socios.desconto_condominio = tb_membros_condominio.membro_condominio_id INNER JOIN tb_aluguel ON tb_pagamentos_nao_socios.desconto_aluguel = tb_aluguel.aluguel_id UNION SELECT membro_nome, pagamento_bruto_valor, desconto_imposto, imposto_valor, desconto_condominio, membro_condominio_valor, desconto_aluguel, NULL AS aluguel_valor, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_socios INNER JOIN tb_membros ON tb_pagamentos_socios.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_socios.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id INNER JOIN tb_impostos ON tb_pagamentos_socios.desconto_imposto = tb_impostos.imposto_id INNER JOIN tb_membros_condominio ON tb_pagamentos_socios.desconto_condominio = tb_membros_condominio.membro_condominio_id UNION SELECT membro_nome, pagamento_bruto_valor, desconto_imposto, NULL AS imposto_valor, desconto_condominio, NULL AS membro_condominio_valor, desconto_aluguel, NULL AS aluguel_valor, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_secretaria INNER JOIN tb_membros ON tb_pagamentos_secretaria.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_secretaria.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id ORDER BY pagamento_bruto_ano, pagamento_bruto_mes, membro_nome;", conexao);

                    SqlDataReader registros = pesquisar4.ExecuteReader();

                    while (registros.Read())
                    {
                        Paragraph nome = new Paragraph(registros["membro_nome"].ToString());
                        nome.SetTextAlignment(TextAlignment.CENTER);
                        nome.SetFontSize(9);

                        tabela.AddCell(nome);

                        Paragraph valorBruto = new Paragraph(registros["pagamento_bruto_valor"].ToString());
                        valorBruto.SetTextAlignment(TextAlignment.CENTER);
                        valorBruto.SetFontSize(9);

                        tabela.AddCell(valorBruto);

                        Paragraph imposto = new Paragraph();
                        imposto.SetTextAlignment(TextAlignment.CENTER);
                        imposto.SetFontSize(9);

                        if (Convert.ToInt32(registros["desconto_imposto"]) > 0)
                        {
                            imposto.Add(registros["imposto_valor"].ToString());
                        }
                        else
                        {
                            imposto.Add(registros["desconto_imposto"].ToString());
                        }

                        tabela.AddCell(imposto);

                        Paragraph condominio = new Paragraph();
                        condominio.SetTextAlignment(TextAlignment.CENTER);
                        condominio.SetFontSize(9);

                        if (Convert.ToInt32(registros["desconto_condominio"]) > 0)
                        {
                            condominio.Add(registros["membro_condominio_valor"].ToString());
                        }
                        else
                        {
                            condominio.Add(registros["desconto_condominio"].ToString());
                        }

                        tabela.AddCell(condominio);

                        Paragraph aluguel = new Paragraph();
                        aluguel.SetTextAlignment(TextAlignment.CENTER);
                        aluguel.SetFontSize(9);

                        if (Convert.ToInt32(registros["desconto_aluguel"]) > 0)
                        {
                            aluguel.Add(registros["aluguel_valor"].ToString());
                        }
                        else
                        {
                            aluguel.Add(registros["desconto_aluguel"].ToString());
                        }

                        tabela.AddCell(aluguel);

                        Paragraph valorLiquido = new Paragraph(registros["pagamento_valor"].ToString());
                        valorLiquido.SetTextAlignment(TextAlignment.CENTER);
                        valorLiquido.SetFontSize(9);

                        tabela.AddCell(valorLiquido);

                        Paragraph mes = new Paragraph(registros["pagamento_bruto_mes"].ToString());
                        mes.SetTextAlignment(TextAlignment.CENTER);
                        mes.SetFontSize(9);

                        tabela.AddCell(mes);

                        Paragraph ano = new Paragraph(registros["pagamento_bruto_ano"].ToString());
                        ano.SetTextAlignment(TextAlignment.CENTER);
                        ano.SetFontSize(9);

                        tabela.AddCell(ano);

                    }

                    registros.Close();

                    conexao.Close();
                    documento.Add(tabela);
                    documento.Close();
                    documentoPdf.Close();

                    System.Diagnostics.Process.Start("C:\\Clínica Contabilidade\\pagamentos.pdf");                    
                }                
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }

        private void btnPagamentosLiquidoPesquisarImprimir_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = null;

            try
            {
                PdfWriter pdf = new PdfWriter("C:\\Clínica Contabilidade\\pagamentos.pdf");

                PdfDocument documentoPdf = new PdfDocument(pdf);

                Document documento = new Document(documentoPdf, PageSize.A4);

                Paragraph cabecalho = new Paragraph("Espaço Entre Saúde Mental e Qualidade de Vida - Pagamentos");
                cabecalho.SetTextAlignment(TextAlignment.CENTER);
                cabecalho.SetFontSize(16);

                documento.Add(cabecalho);

                Table tabela = new Table(new float[] { 15, 15, 15, 15, 15, 15, 5, 5 });
                tabela.SetWidth(UnitValue.CreatePercentValue(100));

                Paragraph cabecalhoNome = new Paragraph("Nome");
                cabecalhoNome.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoNome.SetFontSize(10);

                tabela.AddCell(cabecalhoNome);

                Paragraph cabecalhoValorBruto = new Paragraph("Valor bruto (R$)");
                cabecalhoValorBruto.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoValorBruto.SetFontSize(10);

                tabela.AddCell(cabecalhoValorBruto);

                Paragraph cabecalhoImposto = new Paragraph("Imposto (R$)");
                cabecalhoImposto.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoImposto.SetFontSize(10);

                tabela.AddCell(cabecalhoImposto);

                Paragraph cabecalhoCondominio = new Paragraph("Condominio (R$)");
                cabecalhoCondominio.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoCondominio.SetFontSize(10);

                tabela.AddCell(cabecalhoCondominio);

                Paragraph cabecalhoAluguel = new Paragraph("Aluguel (R$)");
                cabecalhoAluguel.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoAluguel.SetFontSize(10);

                tabela.AddCell(cabecalhoAluguel);

                Paragraph cabecalhoValorLiquido = new Paragraph("Valor líquido (R$)");
                cabecalhoValorLiquido.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoValorLiquido.SetFontSize(10);

                tabela.AddCell(cabecalhoValorLiquido);

                Paragraph cabecalhoMes = new Paragraph("Mês");
                cabecalhoMes.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoMes.SetFontSize(10);

                tabela.AddCell(cabecalhoMes);

                Paragraph cabecalhoAno = new Paragraph("Ano");
                cabecalhoAno.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoAno.SetFontSize(10);

                tabela.AddCell(cabecalhoAno);

                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = conexao.CreateCommand();

                if (cbPesquisarPagamentoLiquido.Text == "Data")
                {
                    PagamentosBruto pagamentos = new PagamentosBruto(cbPesquisarPagamentoLiquidoMes.Text, txtPesquisarPagamentoLiquidoAno.Text);

                    pesquisar.CommandText = "SELECT membro_nome, pagamento_bruto_valor, desconto_imposto, imposto_valor, desconto_condominio, membro_condominio_valor, desconto_aluguel, aluguel_valor, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_nao_socios INNER JOIN tb_membros ON tb_pagamentos_nao_socios.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_nao_socios.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id INNER JOIN tb_impostos ON tb_pagamentos_nao_socios.desconto_imposto = tb_impostos.imposto_id INNER JOIN tb_membros_condominio ON tb_pagamentos_nao_socios.desconto_condominio = tb_membros_condominio.membro_condominio_id INNER JOIN tb_aluguel ON tb_pagamentos_nao_socios.desconto_aluguel = tb_aluguel.aluguel_id WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano UNION SELECT membro_nome, pagamento_bruto_valor, desconto_imposto, imposto_valor, desconto_condominio, membro_condominio_valor, desconto_aluguel, NULL AS aluguel_valor, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_socios INNER JOIN tb_membros ON tb_pagamentos_socios.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_socios.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id INNER JOIN tb_impostos ON tb_pagamentos_socios.desconto_imposto = tb_impostos.imposto_id INNER JOIN tb_membros_condominio ON tb_pagamentos_socios.desconto_condominio = tb_membros_condominio.membro_condominio_id WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano UNION SELECT membro_nome, pagamento_bruto_valor, desconto_imposto, NULL AS imposto_valor, desconto_condominio, NULL AS membro_condominio_valor, desconto_aluguel, NULL AS aluguel_valor, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_secretaria INNER JOIN tb_membros ON tb_pagamentos_secretaria.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_secretaria.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano ORDER BY membro_nome;";

                    pesquisar.Parameters.AddWithValue("@mes", pagamentos.Mes);
                    pesquisar.Parameters.AddWithValue("@ano", pagamentos.Ano);
                }
                else
                {
                    pesquisar.CommandText = "SELECT membro_nome, pagamento_bruto_valor, desconto_imposto, imposto_valor, desconto_condominio, membro_condominio_valor, desconto_aluguel, aluguel_valor, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_nao_socios INNER JOIN tb_membros ON tb_pagamentos_nao_socios.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_nao_socios.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id INNER JOIN tb_impostos ON tb_pagamentos_nao_socios.desconto_imposto = tb_impostos.imposto_id INNER JOIN tb_membros_condominio ON tb_pagamentos_nao_socios.desconto_condominio = tb_membros_condominio.membro_condominio_id INNER JOIN tb_aluguel ON tb_pagamentos_nao_socios.desconto_aluguel = tb_aluguel.aluguel_id WHERE membro_nome LIKE @membro UNION SELECT membro_nome, pagamento_bruto_valor, desconto_imposto, imposto_valor, desconto_condominio, membro_condominio_valor, desconto_aluguel, NULL AS aluguel_valor, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_socios INNER JOIN tb_membros ON tb_pagamentos_socios.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_socios.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id INNER JOIN tb_impostos ON tb_pagamentos_socios.desconto_imposto = tb_impostos.imposto_id INNER JOIN tb_membros_condominio ON tb_pagamentos_socios.desconto_condominio = tb_membros_condominio.membro_condominio_id WHERE membro_nome LIKE @membro UNION SELECT membro_nome, pagamento_bruto_valor, desconto_imposto, NULL AS imposto_valor, desconto_condominio, NULL AS membro_condominio_valor, desconto_aluguel, NULL AS aluguel_valor, pagamento_valor, pagamento_bruto_mes, pagamento_bruto_ano FROM tb_pagamentos_secretaria INNER JOIN tb_membros ON tb_pagamentos_secretaria.pagamento_membro = tb_membros.membro_id INNER JOIN tb_pagamentos_valor_bruto ON tb_pagamentos_secretaria.pagamento_valor_bruto = tb_pagamentos_valor_bruto.pagamento_bruto_id WHERE membro_nome LIKE @membro ORDER BY membro_nome, pagamento_bruto_ano, pagamento_bruto_mes;";

                    pesquisar.Parameters.AddWithValue("@membro", '%' + txtPesquisarPagamentoLiquidoNome.Text + '%');
                }

                conexao.Open();

                SqlDataReader registros = pesquisar.ExecuteReader();

                while (registros.Read())
                {
                    Paragraph nome = new Paragraph(registros["membro_nome"].ToString());
                    nome.SetTextAlignment(TextAlignment.CENTER);
                    nome.SetFontSize(9);

                    tabela.AddCell(nome);

                    Paragraph valorBruto = new Paragraph(registros["pagamento_bruto_valor"].ToString());
                    valorBruto.SetTextAlignment(TextAlignment.CENTER);
                    valorBruto.SetFontSize(9);

                    tabela.AddCell(valorBruto);

                    Paragraph imposto = new Paragraph();
                    imposto.SetTextAlignment(TextAlignment.CENTER);
                    imposto.SetFontSize(9);

                    if (Convert.ToInt32(registros["desconto_imposto"]) > 0)
                    {
                        imposto.Add(registros["imposto_valor"].ToString());
                    }
                    else
                    {
                        imposto.Add(registros["desconto_imposto"].ToString());
                    }

                     tabela.AddCell(imposto);

                     Paragraph condominio = new Paragraph();
                     condominio.SetTextAlignment(TextAlignment.CENTER);
                     condominio.SetFontSize(9);

                     if (Convert.ToInt32(registros["desconto_condominio"]) > 0)
                     {
                         condominio.Add(registros["membro_condominio_valor"].ToString());
                     }
                     else
                     {
                         condominio.Add(registros["desconto_condominio"].ToString());
                     }

                     tabela.AddCell(condominio);

                     Paragraph aluguel = new Paragraph();
                     aluguel.SetTextAlignment(TextAlignment.CENTER);
                     aluguel.SetFontSize(9);

                     if (Convert.ToInt32(registros["desconto_aluguel"]) > 0)
                     {
                         aluguel.Add(registros["aluguel_valor"].ToString());
                     }
                     else
                     {
                         aluguel.Add(registros["desconto_aluguel"].ToString());
                     }

                     tabela.AddCell(aluguel);

                     Paragraph valorLiquido = new Paragraph(registros["pagamento_valor"].ToString());
                     valorLiquido.SetTextAlignment(TextAlignment.CENTER);
                     valorLiquido.SetFontSize(9);

                     tabela.AddCell(valorLiquido);

                     Paragraph mes = new Paragraph(registros["pagamento_bruto_mes"].ToString());
                     mes.SetTextAlignment(TextAlignment.CENTER);
                     mes.SetFontSize(9);

                     tabela.AddCell(mes);

                     Paragraph ano = new Paragraph(registros["pagamento_bruto_ano"].ToString());
                     ano.SetTextAlignment(TextAlignment.CENTER);
                     ano.SetFontSize(9);

                     tabela.AddCell(ano);
                }

                registros.Close();                 
                conexao.Close();
                
                documento.Add(tabela);

                documento.Close();
                documentoPdf.Close();

                System.Diagnostics.Process.Start("C:\\Clínica Contabilidade\\pagamentos.pdf");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }


        //Aba 'Escritório'
        //Nesta aba serão informados os gastos com escritório


        private void tabEscritorio_Enter(object sender, EventArgs e)
        {           
           TabelaEscritorio();
                     
           cbPesquisarEscritorio.SelectedIndex = -1;          
           cbPesquisarEscritorioMes.SelectedIndex = -1;          
           cbPesquisarEscritorioMes.Visible = false;         
           txtPesquisarEscritorioAno.Clear();          
           txtPesquisarEscritorioAno.Visible = false;          
           btnPesquisarEscritorio.Visible = false;           
        }

        private void btnEscritorioInserir_Click(object sender, EventArgs e)
        {
            frmEscritorio escritorio = new frmEscritorio();

            escritorio.Alterar = false;
            escritorio.Deletar = false;
            escritorio.Texto = "Escritório";

            if (cbPagamentosBrutoMes.Text != "" && txtPagamentosBrutoAno.Text != "")
            {
                escritorio.Mes = cbPagamentosBrutoMes.Text;
                escritorio.Ano = txtPagamentosBrutoAno.Text;

                escritorio.MesContabilidade = cbPagamentosBrutoMes.Text;
                escritorio.AnoContabilidade = txtPagamentosBrutoAno.Text;
            }

            escritorio.Show();
            this.Hide();
        }

        private void dgvEscritorio_DoubleClick(object sender, EventArgs e)
        {
            if (dgvEscritorio.SelectedRows.Count == 1)
            {
                frmEscritorio escritorio = new frmEscritorio(dgvEscritorio.SelectedRows[0].Cells[1].Value.ToString(), dgvEscritorio.SelectedRows[0].Cells[2].Value.ToString(), dgvEscritorio.SelectedRows[0].Cells[3].Value.ToString(), dgvEscritorio.SelectedRows[0].Cells[4].Value.ToString(), dgvEscritorio.SelectedRows[0].Cells[5].Value.ToString(), dgvEscritorio.SelectedRows[0].Cells[6].Value.ToString(), dgvEscritorio.SelectedRows[0].Cells[7].Value.ToString(), dgvEscritorio.SelectedRows[0].Cells[8].Value.ToString(), dgvEscritorio.SelectedRows[0].Cells[9].Value.ToString(), dgvEscritorio.SelectedRows[0].Cells[11].Value.ToString(), dgvEscritorio.SelectedRows[0].Cells[12].Value.ToString(),  dgvEscritorio.SelectedRows[0].Cells[0].Value.ToString());

                escritorio.Salvar = false;
                escritorio.Texto = "Escritório - Alterar/excluir";

                if (cbPagamentosBrutoMes.Text != "" && txtPagamentosBrutoAno.Text != "")
                {
                    escritorio.MesContabilidade = cbPagamentosBrutoMes.Text;
                    escritorio.AnoContabilidade = txtPagamentosBrutoAno.Text;
                }

                escritorio.Show();
                this.Hide();
            }            
        }

        private void cbPesquisarEscritorio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPesquisarEscritorio.Text == "Mês e ano")
            {
                cbPesquisarEscritorioMes.Visible = true;
                txtPesquisarEscritorioAno.Visible = true;
                btnPesquisarEscritorio.Visible = true;

                cbPesquisarEscritorioMes.SelectedIndex = -1;
                txtPesquisarEscritorioAno.Clear();
            }
            else if (cbPesquisarEscritorio.Text == "Ano")
            {
                cbPesquisarEscritorioMes.Visible = false;
                txtPesquisarEscritorioAno.Visible = true;
                btnPesquisarEscritorio.Visible = true;

                txtPesquisarEscritorioAno.Clear();
            }
        }

        private void txtPesquisarEscritorioAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 || txtPesquisarEscritorioAno.Text.Length == 4 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnPesquisarEscritorio_Click(object sender, EventArgs e)
        {
            if (cbPesquisarEscritorio.Text == "Mês e ano")
            {
                if (cbPesquisarEscritorioMes.Text == "" || txtPesquisarEscritorioAno.Text == "")
                {
                    MessageBox.Show("Informe todas as informações para a pesquisa", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Convert.ToDecimal(txtPesquisarEscritorioAno.Text) < 2000 || Convert.ToDecimal(txtPesquisarEscritorioAno.Text) > 2099)
                {
                    MessageBox.Show("Informe um ano válido para pesquisar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlConnection conexao = null;

                    try
                    {
                        Escritorio escritorio = new Escritorio(cbPesquisarEscritorioMes.Text, txtPesquisarEscritorioAno.Text);

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_escritorio WHERE escritorio_mes = @mes AND escritorio_ano = @ano;", conexao);

                        pesquisar.Parameters.AddWithValue("@mes", escritorio.Mes);
                        pesquisar.Parameters.AddWithValue("@ano", escritorio.Ano);

                        conexao.Open();

                        SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                        conexao.Close();

                        DataTable tabela = new DataTable();

                        registros.Fill(tabela);

                        dgvEscritorio.DataSource = tabela;
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conexao != null && conexao.State != ConnectionState.Closed)
                        {
                            conexao.Close();
                        }
                    }
                }
            }
            else if (cbPesquisarEscritorio.Text == "Ano")
            {
                if (txtPesquisarEscritorioAno.Text == "")
                {
                    MessageBox.Show("Informe um ano para a pesquisa", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Convert.ToDecimal(txtPesquisarEscritorioAno.Text) < 2000 || Convert.ToDecimal(txtPesquisarEscritorioAno.Text) > 2099)
                {
                    MessageBox.Show("Informe um ano válido para pesquisar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlConnection conexao = null;

                    try
                    {
                        Escritorio escritorio = new Escritorio(cbPesquisarEscritorioMes.Text, txtPesquisarEscritorioAno.Text);

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_escritorio WHERE escritorio_ano = @ano ORDER BY escritorio_mes", conexao);
                        
                        pesquisar.Parameters.AddWithValue("@ano", escritorio.Ano);

                        conexao.Open();

                        SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                        conexao.Close();

                        DataTable tabela = new DataTable();

                        registros.Fill(tabela);

                        dgvEscritorio.DataSource = tabela;
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conexao != null && conexao.State != ConnectionState.Closed)
                        {
                            conexao.Close();
                        }
                    }
                }
            }
        }


        //Aba 'Convênios'
       //Nesta aba serão informados os valores pagos pelos convênios em um mês e ano

        
        private void tabConvenios_Enter(object sender, EventArgs e)
        {
            TabelaConvenios();
            
            if (txtConvenioAba.Text == "parte2")
            {
                rbConveniosValores.Checked = true;
            }
            else
            {
                rbConvenios.Checked = true;
            }               
            
           txtConvenio.Clear();          
           cbConvenios.SelectedIndex = -1;           
           txtConvenioValor.Clear();           
           txtConvenioGlosa.Clear();           
           txtConvenioDesconto.Clear();           
           
           if (cbPagamentosBrutoMes.Text != "" && txtPagamentosBrutoAno.Text != "")
           {
                cbConvenioMes.Text = cbPagamentosBrutoMes.Text;
                txtConvenioAno.Text = txtPagamentosBrutoAno.Text;
           }
           else
           {
                cbConvenioMes.SelectedIndex = -1;
                txtConvenioAno.Clear();
           }
                     
           cbConvenioPesquisar.SelectedIndex = -1;           
           cbConvenioPesquisarMes.Visible = false;           
           cbConvenioPesquisarMes.SelectedIndex = -1;           
           txtConvenioPesquisarAno.Visible = false;           
           btnConvenioPesquisar.Visible = false;           
           cbPesquisarConvenio.Visible = false;           
           cbPesquisarConvenio.SelectedIndex = -1;            
        }

        private void rbConvenios_CheckedChanged(object sender, EventArgs e)
        {
            
            TabelaConvenios();

            lblConvenios.Visible = true;
            lblConveniosValores.Visible = false;

            lblConvenioValor.Visible = false;
            lblConvenioGlosa.Visible = false;
            lblConvenioDesconto.Visible = false;
            lblConvenioMes.Visible = false;
            lblConvenioAno.Visible = false;

            txtConvenio.Visible = true;
            cbConvenios.Visible = false;
            txtConvenioValor.Visible = false;
            txtConvenioGlosa.Visible = false;
            txtConvenioDesconto.Visible = false;
            cbConvenioMes.Visible = false;
            txtConvenioAno.Visible = false;

            dgvConvenio.Width = 234;
            dgvConvenio.Left = 327;

            lblConvenioPesquisar.Visible = false;
            cbConvenioPesquisar.Visible = false;
            cbConvenioPesquisarMes.Visible = false;
            txtConvenioPesquisarAno.Visible = false;
            btnConvenioPesquisar.Visible = false;
            cbPesquisarConvenio.Visible = false;

            txtConvenioAba.Clear();
        }

        private void rbConveniosValores_CheckedChanged(object sender, EventArgs e)
        {
            TabelaConveniosValores();
            
            lblConvenios.Visible = false;
            lblConveniosValores.Visible = true;

            lblConvenioValor.Visible = true;
            lblConvenioGlosa.Visible = true;
            lblConvenioDesconto.Visible = true;
            lblConvenioMes.Visible = true;
            lblConvenioAno.Visible = true;

            txtConvenio.Visible = false;
            cbConvenios.Visible = true;
            txtConvenioValor.Visible = true;
            txtConvenioGlosa.Visible = true;
            txtConvenioDesconto.Visible = true;
            cbConvenioMes.Visible = true;
            txtConvenioAno.Visible = true;

            dgvConvenio.Width = 745;
            dgvConvenio.Left = 80;

            lblConvenioPesquisar.Visible = true;
            cbConvenioPesquisar.Visible = true;
            cbConvenioPesquisar.SelectedIndex = -1;
            cbConvenioPesquisarMes.SelectedIndex = -1;
            txtConvenioPesquisarAno.Clear();
            cbPesquisarConvenio.SelectedIndex = -1;
        }

        private void txtConvenioValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtConvenioValor.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtConvenioValor.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtConvenioValor.Text.Substring(txtConvenioValor.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtConvenioValor.Text == "0")
            {
                if (e.KeyChar != ',' && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtConvenioGlosa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtConvenioGlosa.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtConvenioGlosa.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtConvenioGlosa.Text.Substring(txtConvenioGlosa.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtConvenioGlosa.Text == "0")
            {
                if (e.KeyChar != ',' && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        private void txtConvenioDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtConvenioDesconto.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtConvenioDesconto.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtConvenioDesconto.Text.Substring(txtConvenioDesconto.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtConvenioDesconto.Text == "0")
            {
                if (e.KeyChar != ',' && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtConvenioDesconto.Text.Length == 2 && txtConvenioDesconto.Text.EndsWith(",") == false)
                {
                    if (e.KeyChar != 8 && e.KeyChar != ',')
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtConvenioAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 || txtConvenioAno.Text.Length == 4 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtConvenio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtConvenio.Text == "")             
            {
                if (!char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 32)     
                {
                    e.Handled = true;
                }
            }
        }

        private void cbConvenios_DropDown(object sender, EventArgs e)
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_convenios ORDER BY convenio_nome;", conexao);

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                cbConvenios.ValueMember = "convenio_id";
                cbConvenios.DisplayMember = "convenio_nome";
                cbConvenios.DataSource = tabela;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }

        private void btnConvenioSalvar_Click(object sender, EventArgs e)
        {
            if (rbConvenios.Checked)
            {
                if (txtConvenio.Text == "")
                {
                    MessageBox.Show("Informe o nome de um convênio", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var botao = MessageBox.Show("Confirmar inserção de convênio", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (botao == DialogResult.Yes)
                    {
                        SqlConnection conexao = null;

                        try
                        {
                            Convenio convenio = new Convenio(txtConvenio.Text);

                            conexao = new SqlConnection(StringConexao.stringConexao);

                            SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_convenios WHERE convenio_nome = @convenio", conexao);

                            pesquisar.Parameters.AddWithValue("@convenio", convenio.Convenio1);

                            conexao.Open();

                            SqlDataReader registros = pesquisar.ExecuteReader();

                            if (registros.HasRows)
                            {
                                MessageBox.Show("Este convênio já foi registrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                registros.Close();
                                conexao.Close();
                            }
                            else
                            {
                                registros.Close();

                                SqlCommand inserir = new SqlCommand("INSERT INTO tb_convenios VALUES (@convenio);", conexao);

                                inserir.Parameters.AddWithValue("@convenio", convenio.Convenio1);

                                inserir.ExecuteNonQuery();

                                conexao.Close();

                                MessageBox.Show("Convênio inserido com sucesso", "Operação bem sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                txtConvenio.Clear();

                                TabelaConvenios();
                            }
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (conexao != null && conexao.State != ConnectionState.Closed)
                            {
                                conexao.Close();
                            }
                        }
                    }
                }
            }
            else if (rbConveniosValores.Checked)
            {
                if (cbConvenios.Text == "" || txtConvenioValor.Text == "" || txtConvenioGlosa.Text == "" || txtConvenioDesconto.Text == "" || cbConvenioMes.Text == "" || txtConvenioAno.Text == "")
                {
                    MessageBox.Show("Preencha todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Convert.ToDecimal(txtConvenioAno.Text) < 2000 || Convert.ToDecimal(txtConvenioAno.Text) > 2099)
                {
                    MessageBox.Show("Informe um ano válido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var botao = MessageBox.Show("Confirmar inserção de pagamento de convênio?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    SqlConnection conexao = null;

                    if (botao == DialogResult.Yes)
                    {
                        try
                        {
                            decimal calculo1 = Convert.ToDecimal(txtConvenioValor.Text) - Convert.ToDecimal(txtConvenioGlosa.Text);

                            decimal calculo2 = Convert.ToDecimal(txtConvenioDesconto.Text) / 100;

                            decimal calculo3 = calculo1 * calculo2;

                            Convenio convenio = new Convenio(Convert.ToInt32(cbConvenios.SelectedValue), Convert.ToDecimal(txtConvenioValor.Text), Convert.ToDecimal(txtConvenioGlosa.Text), Convert.ToDecimal(txtConvenioDesconto.Text), calculo1 - calculo3, cbConvenioMes.Text, txtConvenioAno.Text);

                            conexao = new SqlConnection(StringConexao.stringConexao);

                            SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_convenios_valores WHERE convenio = @convenio AND convenio_valor_mes = @mes AND convenio_valor_ano = @ano", conexao);

                            pesquisar.Parameters.AddWithValue("@convenio", convenio.Convenio2);
                            pesquisar.Parameters.AddWithValue("@mes", convenio.Mes);
                            pesquisar.Parameters.AddWithValue("@ano", convenio.Ano);

                            conexao.Open();

                            SqlDataReader registros = pesquisar.ExecuteReader();

                            if (registros.HasRows)
                            {
                                MessageBox.Show("O pagamento deste convênio deste mês e ano já foi informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                registros.Close();
                                conexao.Close();
                            }
                            else
                            {
                                registros.Close();

                                SqlCommand pesquisar2 = new SqlCommand("SELECT * FROM tb_saldos WHERE saldo_mes = @mes AND saldo_ano = @ano;", conexao);

                                pesquisar2.Parameters.AddWithValue("@mes", convenio.Mes);
                                pesquisar2.Parameters.AddWithValue("@ano", convenio.Ano);

                                SqlDataReader registros2 = pesquisar2.ExecuteReader();

                                if (registros2.HasRows)
                                {
                                    MessageBox.Show("O saldo deste mês e ano já foi calculado e registrado. Remova-o para poder adicionar outro recebimento desta data", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    registros2.Close();
                                    conexao.Close();
                                }
                                else
                                {
                                    registros2.Close();

                                    SqlCommand inserir = new SqlCommand("INSERT INTO tb_convenios_valores VALUES (@convenio, @valorInicial, @glosa, @desconto, @valor, @mes, @ano);", conexao);

                                    inserir.Parameters.AddWithValue("@convenio", convenio.Convenio2);
                                    inserir.Parameters.AddWithValue("@valorInicial", convenio.ValorInicial);
                                    inserir.Parameters.AddWithValue("@glosa", convenio.Glosa);
                                    inserir.Parameters.AddWithValue("@desconto", convenio.Desconto);
                                    inserir.Parameters.AddWithValue("@valor", convenio.Valor);
                                    inserir.Parameters.AddWithValue("@mes", convenio.Mes);
                                    inserir.Parameters.AddWithValue("@ano", convenio.Ano);

                                    inserir.ExecuteNonQuery();

                                    conexao.Close();

                                    MessageBox.Show("Pagamento de convênio inserido com sucesso", "Operação bem sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    cbConvenios.SelectedIndex = -1;
                                    txtConvenioValor.Clear();
                                    txtConvenioGlosa.Clear();
                                    txtConvenioDesconto.Clear();

                                    TabelaConveniosValores();
                                }
                            }                           
                        }
                        catch (Exception erro)
                        {
                            MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (conexao != null && conexao.State != ConnectionState.Closed)
                            {
                                conexao.Close();
                            }
                        }
                    }
                }
            }           
        }

        private void dgvConvenio_DoubleClick(object sender, EventArgs e)
        {
            if (dgvConvenio.SelectedRows.Count == 1)
            {
                if (rbConvenios.Checked)
                {
                    frmConvenioAlterarDeletar convenio = new frmConvenioAlterarDeletar(dgvConvenio.SelectedRows[0].Cells[1].Value.ToString(), dgvConvenio.SelectedRows[0].Cells[0].Value.ToString());

                    if (cbPagamentosBrutoMes.Text != "" && txtPagamentosBrutoAno.Text != "")
                    {
                        convenio.Mes = cbPagamentosBrutoMes.Text;
                        convenio.Ano = txtPagamentosBrutoAno.Text;
                    }

                    convenio.Show();
                    this.Hide();
                }
                else if (rbConveniosValores.Checked)
                {
                    frmConvenioValoresAlterarDeletar convenio = new frmConvenioValoresAlterarDeletar(dgvConvenio.SelectedRows[0].Cells[1].Value.ToString(), dgvConvenio.SelectedRows[0].Cells[2].Value.ToString(), dgvConvenio.SelectedRows[0].Cells[3].Value.ToString(), dgvConvenio.SelectedRows[0].Cells[4].Value.ToString(), dgvConvenio.SelectedRows[0].Cells[6].Value.ToString(), dgvConvenio.SelectedRows[0].Cells[7].Value.ToString(), dgvConvenio.SelectedRows[0].Cells[0].Value.ToString());

                    if (cbPagamentosBrutoMes.Text != "" && txtPagamentosBrutoAno.Text != "")
                    {
                        convenio.Mes = cbPagamentosBrutoMes.Text;
                        convenio.Ano = txtPagamentosBrutoAno.Text;
                    }

                    convenio.Show();
                    this.Hide();
                }
            }           
        }

        private void cbConvenioPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbConvenioPesquisar.Text == "Data")
            {
                cbConvenioPesquisarMes.Visible = true;
                txtConvenioPesquisarAno.Visible = true;

                cbConvenioPesquisarMes.SelectedIndex = -1;
                txtConvenioPesquisarAno.Clear();

                btnConvenioPesquisar.Visible = true;

                cbPesquisarConvenio.Visible = false;
            }
            else if (cbConvenioPesquisar.Text == "Convênio")
            {
                cbConvenioPesquisarMes.Visible = false;
                txtConvenioPesquisarAno.Visible = false;

                btnConvenioPesquisar.Visible = false;

                cbPesquisarConvenio.Visible = true;

                cbPesquisarConvenio.SelectedIndex = -1;
            }
        }

        private void cbPesquisarConvenio_DropDown(object sender, EventArgs e)
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_convenios;", conexao);

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                cbPesquisarConvenio.ValueMember = "convenio_id";
                cbPesquisarConvenio.DisplayMember = "convenio_nome";
                cbPesquisarConvenio.DataSource = tabela;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }

        private void txtConvenioPesquisarAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 || txtConvenioPesquisarAno.Text.Length == 4 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnConvenioPesquisar_Click(object sender, EventArgs e)
        {
            if (cbConvenioPesquisarMes.Text == "" || txtConvenioPesquisarAno.Text == "")
            {
                MessageBox.Show("Informe todas as informações para a pesquisa", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDecimal(txtConvenioPesquisarAno.Text) < 2000 || Convert.ToDecimal(txtConvenioPesquisarAno.Text) > 2099)
            {
                MessageBox.Show("Informe um ano válido para pesquisar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection conexao = null;

                try
                {
                    Convenio convenio = new Convenio(cbConvenioPesquisarMes.Text, txtConvenioPesquisarAno.Text);

                    conexao = new SqlConnection(StringConexao.stringConexao);

                    SqlCommand pesquisar = new SqlCommand("SELECT convenio_valor_id, convenio_nome, convenio_valor_inicial, convenio_valor_glosa, convenio_valor_desconto, convenio_valor_final, convenio_valor_mes, convenio_valor_ano FROM tb_convenios_valores INNER JOIN tb_convenios ON tb_convenios_valores.convenio = tb_convenios.convenio_id WHERE convenio_valor_mes = @mes AND convenio_valor_ano = @ano ORDER BY convenio_nome;", conexao);

                    pesquisar.Parameters.AddWithValue("@mes", convenio.Mes);
                    pesquisar.Parameters.AddWithValue("@ano", convenio.Ano);

                    conexao.Open();

                    SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                    conexao.Close();

                    DataTable tabela = new DataTable();

                    registros.Fill(tabela);

                    dgvConvenio.DataSource = tabela;
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (conexao != null && conexao.State != ConnectionState.Closed)
                    {
                        conexao.Close();
                    }
                }
            }
        }

        private void cbPesquisarConvenio_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conexao = null;

            try
            {
                Convenio convenio = new Convenio(cbPesquisarConvenio.Text);

                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT convenio_valor_id, convenio_nome, convenio_valor_inicial, convenio_valor_glosa, convenio_valor_desconto, convenio_valor_final, convenio_valor_mes, convenio_valor_ano FROM tb_convenios_valores INNER JOIN tb_convenios ON tb_convenios_valores.convenio = tb_convenios.convenio_id WHERE convenio_nome = @convenio ORDER BY convenio_valor_ano, convenio_valor_mes, convenio_nome;", conexao);

                pesquisar.Parameters.AddWithValue("@convenio", convenio.Convenio1);

                conexao.Open();

                SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                conexao.Close();

                DataTable tabela = new DataTable();

                registros.Fill(tabela);

                dgvConvenio.DataSource = tabela;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }


        //Aba 'Saldo Mensal'
       // Todos os dados introduzidos anteriormente serão combinados para calcular o saldo final


        private void tabSaldo_Enter(object sender, EventArgs e)
        {
            TabelaSaldos();
          
            if (cbPagamentosBrutoMes.Text != "" && txtPagamentosBrutoAno.Text != "")
            {
                cbSaldoMes.Text = cbPagamentosBrutoMes.Text;
                txtSaldoAno.Text = txtPagamentosBrutoAno.Text;
            }
            else
            {
                cbSaldoMes.SelectedIndex = -1;
                txtSaldoAno.Clear();
            }

            cbSaldoPesquisar.SelectedIndex = -1;           
            cbSaldoPesquisarMes.SelectedIndex = -1;           
            cbSaldoPesquisarMes.Visible = false;           
            txtSaldoPesquisarAno.Clear();          
            txtSaldoPesquisarAno.Visible = false;          
            btnSaldoPesquisar.Visible = false;
            btnSaldoPesquisarImprimir.Visible = false;
        }

        private void tabConvenios_Leave(object sender, EventArgs e)
        {
            txtConvenioAba.Clear();
        }

        private void txtSaldoAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 || txtSaldoAno.Text.Length == 4 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnSaldoSalvar_Click(object sender, EventArgs e)  //O cálculo do saldo mensal consiste em somar todos os valores recebidos pelos convênios no mês e ano informados, e subtrair os gastos de escritório e a soma de todos os pagamentos (valor líquido)
        {
            if (cbSaldoMes.Text == "" || txtSaldoAno.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDecimal(txtSaldoAno.Text) < 2000 || Convert.ToDecimal(txtSaldoAno.Text) > 2099)
            {
                MessageBox.Show("Informe um ano válido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var botao = MessageBox.Show("Confirmar cálculo e inserção de saldo?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (botao == DialogResult.Yes)
                {
                    SqlConnection conexao = null;

                    try
                    {
                        Saldo saldo = new Saldo(cbSaldoMes.Text, txtSaldoAno.Text);

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT COUNT(*) FROM tb_saldos WHERE saldo_mes = @mes AND saldo_ano = @ano;", conexao);

                        pesquisar.Parameters.AddWithValue("@mes", saldo.Mes);
                        pesquisar.Parameters.AddWithValue("@ano", saldo.Ano);

                        conexao.Open();

                        int quantidadeSaldo = Convert.ToInt32(pesquisar.ExecuteScalar());

                        if (quantidadeSaldo > 0)
                        {
                            MessageBox.Show("Já há um registro de saldo deste mês e ano", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            conexao.Close();
                        }
                        else
                        {
                            SqlCommand pesquisar2 = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_nao_socios WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                            pesquisar2.Parameters.AddWithValue("@mes", saldo.Mes);
                            pesquisar2.Parameters.AddWithValue("@ano", saldo.Ano);

                            SqlCommand pesquisar3 = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_socios WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                            pesquisar3.Parameters.AddWithValue("@mes", saldo.Mes);
                            pesquisar3.Parameters.AddWithValue("@ano", saldo.Ano);

                            SqlCommand pesquisar4 = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_secretaria WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                            pesquisar4.Parameters.AddWithValue("@mes", saldo.Mes);
                            pesquisar4.Parameters.AddWithValue("@ano", saldo.Ano);

                            int quantidadePagamentos = Convert.ToInt32(pesquisar2.ExecuteScalar());
                            int quantidadePagamentos2 = Convert.ToInt32(pesquisar3.ExecuteScalar());
                            int quantidadePagamentos3 = Convert.ToInt32(pesquisar4.ExecuteScalar());

                            if (quantidadePagamentos < 1 && quantidadePagamentos2 < 1 && quantidadePagamentos3 < 3)
                            {
                                MessageBox.Show("Os pagamentos (valor líquido) deste mês e ano não foram informados", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                conexao.Close();
                            }
                            else
                            {
                                SqlCommand pesquisar5 = new SqlCommand("SELECT COUNT(*) FROM tb_escritorio WHERE escritorio_mes = @mes AND escritorio_ano = @ano", conexao);

                                pesquisar5.Parameters.AddWithValue("@mes", saldo.Mes);
                                pesquisar5.Parameters.AddWithValue("@ano", saldo.Ano);

                                int quantidadeEscritorio = Convert.ToInt32(pesquisar5.ExecuteScalar());

                                if (quantidadeEscritorio < 1)
                                {
                                    MessageBox.Show("Os gastos de escritório deste mês e ano não foram informados", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    conexao.Close();
                                }
                                else
                                {
                                    SqlCommand pesquisar6 = new SqlCommand("SELECT COUNT(*) FROM tb_convenios_valores WHERE convenio_valor_mes = @mes AND convenio_valor_ano = @ano;", conexao);

                                    pesquisar6.Parameters.AddWithValue("@mes", saldo.Mes);
                                    pesquisar6.Parameters.AddWithValue("@ano", saldo.Ano);

                                    int quantidadeConvenios = Convert.ToInt32(pesquisar6.ExecuteScalar());

                                    if ( quantidadeConvenios < 1)
                                    {
                                        MessageBox.Show("Os valores pagos pelos convênios (e outras fontes de renda) deste mês e ano não foram informados", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                        conexao.Close();
                                    }
                                    else
                                    {
                                        if (quantidadePagamentos > 0)
                                        {
                                            SqlCommand pagamentosNaoSocios = new SqlCommand("SELECT SUM(pagamento_valor) FROM tb_pagamentos_nao_socios WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                                            pagamentosNaoSocios.Parameters.AddWithValue("@mes", saldo.Mes);
                                            pagamentosNaoSocios.Parameters.AddWithValue("@ano", saldo.Ano);

                                            saldo.Pagamentos += Convert.ToDecimal(pagamentosNaoSocios.ExecuteScalar());
                                            saldo.Saldo1 -= Convert.ToDecimal(pagamentosNaoSocios.ExecuteScalar());
                                        }

                                        if (quantidadePagamentos2 > 0)
                                        {
                                            SqlCommand pagamentosSocios = new SqlCommand("SELECT SUM(pagamento_valor) FROM tb_pagamentos_socios WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                                            pagamentosSocios.Parameters.AddWithValue("@mes", saldo.Mes);
                                            pagamentosSocios.Parameters.AddWithValue("@ano", saldo.Ano);

                                            saldo.Pagamentos += Convert.ToDecimal(pagamentosSocios.ExecuteScalar());
                                            saldo.Saldo1 -= Convert.ToDecimal(pagamentosSocios.ExecuteScalar());
                                        }

                                        if (quantidadePagamentos3 > 0)
                                        {
                                            SqlCommand pagamentosSecretaria = new SqlCommand("SELECT SUM(pagamento_valor) FROM tb_pagamentos_secretaria WHERE pagamento_mes = ANY (SELECT pagamento_bruto_id FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano);", conexao);

                                            pagamentosSecretaria.Parameters.AddWithValue("@mes", saldo.Mes);
                                            pagamentosSecretaria.Parameters.AddWithValue("@ano", saldo.Ano);

                                            saldo.Pagamentos += Convert.ToDecimal(pagamentosSecretaria.ExecuteScalar());
                                            saldo.Saldo1 -= Convert.ToDecimal(pagamentosSecretaria.ExecuteScalar());
                                        }

                                        
                                        SqlCommand pagamentosEscritorio = new SqlCommand("SELECT escritorio_id, escritorio_total FROM tb_escritorio WHERE escritorio_mes = @mes AND escritorio_ano = @ano;", conexao);

                                        pagamentosEscritorio.Parameters.AddWithValue("@mes", saldo.Mes);
                                        pagamentosEscritorio.Parameters.AddWithValue("@ano", saldo.Ano);

                                        SqlDataReader registrosEscritorio = pagamentosEscritorio.ExecuteReader();

                                        registrosEscritorio.Read();

                                        saldo.Escritorio = Convert.ToInt32(registrosEscritorio["escritorio_id"]);
                                        saldo.Saldo1 -= Convert.ToDecimal(registrosEscritorio["escritorio_total"]);

                                        registrosEscritorio.Close();

                                        SqlCommand pagamentosConvenios = new SqlCommand("SELECT SUM(convenio_valor_final) FROM tb_convenios_valores WHERE convenio_valor_mes = @mes AND convenio_valor_ano = @ano;", conexao);

                                        pagamentosConvenios.Parameters.AddWithValue("@mes", saldo.Mes);
                                        pagamentosConvenios.Parameters.AddWithValue("@ano", saldo.Ano);

                                        saldo.ValorInicial = Convert.ToDecimal(pagamentosConvenios.ExecuteScalar());
                                        saldo.Saldo1 += Convert.ToDecimal(pagamentosConvenios.ExecuteScalar());

                                        SqlCommand inserir = new SqlCommand("INSERT INTO tb_saldos VALUES (@valorInicial, @escritorio, @pagamentos, @saldo, @mes, @ano);", conexao);

                                        inserir.Parameters.AddWithValue("@valorInicial", saldo.ValorInicial);
                                        inserir.Parameters.AddWithValue("@escritorio", saldo.Escritorio);
                                        inserir.Parameters.AddWithValue("@pagamentos", saldo.Pagamentos);
                                        inserir.Parameters.AddWithValue("@saldo", saldo.Saldo1);
                                        inserir.Parameters.AddWithValue("@mes", saldo.Mes);
                                        inserir.Parameters.AddWithValue("@ano", saldo.Ano);

                                        inserir.ExecuteNonQuery();

                                        conexao.Close();

                                        MessageBox.Show("Novo valor de saldo calculado e inserido com sucesso", "Operação bem sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                        cbSaldoMes.SelectedIndex = -1;
                                        txtSaldoAno.Clear();

                                        TabelaSaldos();
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conexao != null && conexao.State != ConnectionState.Closed)
                        {
                            conexao.Close();
                        }
                    }
                }
            }
        }

        private void btnSaldoExcluir_Click(object sender, EventArgs e)
        {
            if (dgvSaldo.SelectedRows.Count == 1)
            {
                var botao = MessageBox.Show("Confirmar a remoção do registro?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (botao == DialogResult.Yes)
                {
                    SqlConnection conexao = null;

                    try
                    {
                        Saldo saldo = new Saldo(Convert.ToInt32(dgvSaldo.SelectedRows[0].Cells[0].Value));

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand deletar = new SqlCommand("DELETE FROM tb_saldos WHERE saldo_id = @id", conexao);

                        deletar.Parameters.AddWithValue("@id", saldo.Id);

                        conexao.Open();

                        deletar.ExecuteNonQuery();

                        conexao.Close();

                        MessageBox.Show("Remoção feita com sucesso", "Operação bem sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        TabelaSaldos();
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conexao != null && conexao.State != ConnectionState.Closed)
                        {
                            conexao.Close();
                        }
                    }
                }
            }
        }

        private void btnSaldoPesquisar_Click(object sender, EventArgs e)
        {
            if (cbSaldoPesquisar.Text == "Mês e ano")
            {
                if (cbSaldoPesquisarMes.Text == "" || txtSaldoPesquisarAno.Text == "")
                {
                    MessageBox.Show("Informe todas as informações para a pesquisa", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Convert.ToDecimal(txtSaldoPesquisarAno.Text) < 2000 || Convert.ToDecimal(txtSaldoPesquisarAno.Text) > 2099)
                {
                    MessageBox.Show("Informe um ano válido para pesquisar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlConnection conexao = null;

                    try
                    {
                        Saldo saldo = new Saldo(cbSaldoPesquisarMes.Text, txtSaldoPesquisarAno.Text);

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT saldo_id, saldo_valor_inicial, escritorio_total, pagamentos_valor, saldo_valor, saldo_mes, saldo_ano FROM tb_saldos INNER JOIN tb_escritorio ON tb_saldos.escritorio_valor = tb_escritorio.escritorio_id WHERE saldo_mes = @mes AND saldo_ano = @ano;", conexao);

                        pesquisar.Parameters.AddWithValue("@mes", saldo.Mes);
                        pesquisar.Parameters.AddWithValue("@ano", saldo.Ano);

                        conexao.Open();

                        SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                        conexao.Close();

                        DataTable tabela = new DataTable();

                        registros.Fill(tabela);

                        dgvSaldo.DataSource = tabela;

                        if (tabela.Rows.Count > 0)
                        {
                            btnSaldoPesquisarImprimir.Visible = true;
                        }                       
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conexao != null && conexao.State != ConnectionState.Closed)
                        {
                            conexao.Close();
                        }
                    }
                }
            }
            else if (cbSaldoPesquisar.Text == "Ano")
            {
                if (txtSaldoPesquisarAno.Text == "")
                {
                    MessageBox.Show("Informe um ano para a pesquisa", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Convert.ToDecimal(txtSaldoPesquisarAno.Text) < 2000 || Convert.ToDecimal(txtSaldoPesquisarAno.Text) > 2099)
                {
                    MessageBox.Show("Informe um ano válido para pesquisar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    SqlConnection conexao = null;

                    try
                    {
                        Saldo saldo = new Saldo(txtSaldoPesquisarAno.Text);

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT saldo_id, saldo_valor_inicial, escritorio_total, pagamentos_valor, saldo_valor, saldo_mes, saldo_ano FROM tb_saldos INNER JOIN tb_escritorio ON tb_saldos.escritorio_valor = tb_escritorio.escritorio_id WHERE saldo_ano = @ano ORDER BY saldo_mes;", conexao);
                        
                        pesquisar.Parameters.AddWithValue("@ano", saldo.Ano);

                        conexao.Open();

                        SqlDataAdapter registros = new SqlDataAdapter(pesquisar);

                        conexao.Close();

                        DataTable tabela = new DataTable();

                        registros.Fill(tabela);

                        dgvSaldo.DataSource = tabela;

                        if (tabela.Rows.Count > 0)
                        {
                            btnSaldoPesquisarImprimir.Visible = true;
                        }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (conexao != null && conexao.State != ConnectionState.Closed)
                        {
                            conexao.Close();
                        }
                    }
                }
            }
        }

        private void cbSaldoPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSaldoPesquisar.Text == "Mês e ano")
            {
                cbSaldoPesquisarMes.Visible = true;
                txtSaldoPesquisarAno.Visible = true;

                cbSaldoPesquisarMes.SelectedIndex = -1;
                txtSaldoPesquisarAno.Clear();

                btnSaldoPesquisar.Visible = true;
            }
            else if (cbSaldoPesquisar.Text == "Ano")
            {
                cbSaldoPesquisarMes.Visible = false;
                txtSaldoPesquisarAno.Visible = true;

                txtSaldoPesquisarAno.Clear();

                btnSaldoPesquisar.Visible = true;
            }

            btnSaldoPesquisarImprimir.Visible = false;
        }

        private void txtSaldoPesquisarAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 || txtSaldoPesquisarAno.Text.Length == 4 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void cbSaldoPesquisarMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSaldoPesquisarImprimir.Visible = false;
        }

        private void txtSaldoPesquisarAno_TextChanged(object sender, EventArgs e)
        {
            btnSaldoPesquisarImprimir.Visible = false;
        }

        private void btnSaldoImprimir_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT COUNT(*) FROM tb_saldos;", conexao);

                conexao.Open();

                int quantidade = Convert.ToInt32(pesquisar.ExecuteScalar());

                if (quantidade == 0)
                {
                    conexao.Close();
                }
                else
                {
                    PdfWriter pdf = new PdfWriter("C:\\Clínica Contabilidade\\saldo.pdf");

                    PdfDocument documentoPdf = new PdfDocument(pdf);

                    Document documento = new Document(documentoPdf, PageSize.A4);

                    Paragraph cabecalho = new Paragraph("Espaço Entre Saúde Mental e Qualidade de Vida - Saldo Mensal");
                    cabecalho.SetTextAlignment(TextAlignment.CENTER);
                    cabecalho.SetFontSize(16);

                    documento.Add(cabecalho);

                    Table tabela = new Table(new float[] { 22, 22, 22, 22, 6, 6 });

                    tabela.SetWidth(UnitValue.CreatePercentValue(100));

                    Paragraph cabecalhoConvenios = new Paragraph("Convenios (R$)");
                    cabecalhoConvenios.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoConvenios.SetFontSize(10);

                    tabela.AddCell(cabecalhoConvenios);

                    Paragraph cabecalhoEscritorio = new Paragraph("Escritório (R$)");
                    cabecalhoEscritorio.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoEscritorio.SetFontSize(10);

                    tabela.AddCell(cabecalhoEscritorio);

                    Paragraph cabecalhoPagamentos = new Paragraph("Pagamentos (R$)");
                    cabecalhoPagamentos.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoPagamentos.SetFontSize(10);

                    tabela.AddCell(cabecalhoPagamentos);

                    Paragraph cabecalhoSaldo = new Paragraph("Saldo (R$)");
                    cabecalhoSaldo.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoSaldo.SetFontSize(10);

                    tabela.AddCell(cabecalhoSaldo);

                    Paragraph cabecalhoMes = new Paragraph("Mês");
                    cabecalhoMes.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoMes.SetFontSize(10);

                    tabela.AddCell(cabecalhoMes);

                    Paragraph cabecalhoAno = new Paragraph("Ano");
                    cabecalhoAno.SetTextAlignment(TextAlignment.CENTER);
                    cabecalhoAno.SetFontSize(10);

                    tabela.AddCell(cabecalhoAno);


                    SqlCommand pesquisar2 = new SqlCommand("SELECT saldo_valor_inicial, escritorio_total, pagamentos_valor, saldo_valor, saldo_mes, saldo_ano FROM tb_saldos INNER JOIN tb_escritorio ON tb_saldos.escritorio_valor = tb_escritorio.escritorio_id ORDER BY saldo_ano, saldo_mes;", conexao);

                    SqlDataReader registros = pesquisar2.ExecuteReader();

                    while (registros.Read())
                    {
                        Paragraph convenios = new Paragraph(registros["saldo_valor_inicial"].ToString());
                        convenios.SetTextAlignment(TextAlignment.CENTER);
                        convenios.SetFontSize(9);

                        tabela.AddCell(convenios);

                        Paragraph escritorio = new Paragraph(registros["escritorio_total"].ToString());
                        escritorio.SetTextAlignment(TextAlignment.CENTER);
                        escritorio.SetFontSize(9);

                        tabela.AddCell(escritorio);

                        Paragraph pagamentos = new Paragraph(registros["pagamentos_valor"].ToString());
                        pagamentos.SetTextAlignment(TextAlignment.CENTER);
                        pagamentos.SetFontSize(9);

                        tabela.AddCell(pagamentos);

                        Paragraph saldo = new Paragraph(registros["saldo_valor"].ToString());
                        saldo.SetTextAlignment(TextAlignment.CENTER);
                        saldo.SetFontSize(9);

                        tabela.AddCell(saldo);

                        Paragraph mes = new Paragraph(registros["saldo_mes"].ToString());
                        mes.SetTextAlignment(TextAlignment.CENTER);
                        mes.SetFontSize(9);

                        tabela.AddCell(mes);

                        Paragraph ano = new Paragraph(registros["saldo_ano"].ToString());
                        ano.SetTextAlignment(TextAlignment.CENTER);
                        ano.SetFontSize(9);

                        tabela.AddCell(ano);
                    }

                    registros.Close();

                    conexao.Close();

                    documento.Add(tabela);

                    documento.Close();
                    documentoPdf.Close();

                    System.Diagnostics.Process.Start("C:\\Clínica Contabilidade\\saldo.pdf");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }

        private void btnSaldoPesquisarImprimir_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = null;

            try
            {
                PdfWriter pdf = new PdfWriter("C:\\Clínica Contabilidade\\saldo.pdf");

                PdfDocument documentoPdf = new PdfDocument(pdf);

                Document documento = new Document(documentoPdf, PageSize.A4);

                Paragraph cabecalho = new Paragraph("Espaço Entre Saúde Mental e Qualidade de Vida - Saldo Mensal");
                cabecalho.SetTextAlignment(TextAlignment.CENTER);
                cabecalho.SetFontSize(16);

                documento.Add(cabecalho);

                Table tabela = new Table(new float[] { 22, 22, 22, 22, 6, 6 });

                tabela.SetWidth(UnitValue.CreatePercentValue(100));

                Paragraph cabecalhoConvenios = new Paragraph("Convenios (R$)");
                cabecalhoConvenios.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoConvenios.SetFontSize(10);

                tabela.AddCell(cabecalhoConvenios);

                Paragraph cabecalhoEscritorio = new Paragraph("Escritório (R$)");
                cabecalhoEscritorio.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoEscritorio.SetFontSize(10);

                tabela.AddCell(cabecalhoEscritorio);

                Paragraph cabecalhoPagamentos = new Paragraph("Pagamentos (R$)");
                cabecalhoPagamentos.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoPagamentos.SetFontSize(10);

                tabela.AddCell(cabecalhoPagamentos);

                Paragraph cabecalhoSaldo = new Paragraph("Saldo (R$)");
                cabecalhoSaldo.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoSaldo.SetFontSize(10);

                tabela.AddCell(cabecalhoSaldo);

                Paragraph cabecalhoMes = new Paragraph("Mês");
                cabecalhoMes.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoMes.SetFontSize(10);

                tabela.AddCell(cabecalhoMes);

                Paragraph cabecalhoAno = new Paragraph("Ano");
                cabecalhoAno.SetTextAlignment(TextAlignment.CENTER);
                cabecalhoAno.SetFontSize(10);

                tabela.AddCell(cabecalhoAno);

                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = conexao.CreateCommand();

                if (cbSaldoPesquisar.Text == "Ano")
                {
                    Saldo saldo = new Saldo(txtSaldoPesquisarAno.Text);

                    pesquisar.CommandText = "SELECT saldo_id, saldo_valor_inicial, escritorio_total, pagamentos_valor, saldo_valor, saldo_mes, saldo_ano FROM tb_saldos INNER JOIN tb_escritorio ON tb_saldos.escritorio_valor = tb_escritorio.escritorio_id WHERE saldo_ano = @ano ORDER BY saldo_mes;";

                    pesquisar.Parameters.AddWithValue("@ano", saldo.Ano);
                }
                else
                {
                    Saldo saldo = new Saldo(cbSaldoPesquisarMes.Text, txtSaldoPesquisarAno.Text);

                    pesquisar.CommandText = "SELECT saldo_id, saldo_valor_inicial, escritorio_total, pagamentos_valor, saldo_valor, saldo_mes, saldo_ano FROM tb_saldos INNER JOIN tb_escritorio ON tb_saldos.escritorio_valor = tb_escritorio.escritorio_id WHERE saldo_mes = @mes AND saldo_ano = @ano;";

                    pesquisar.Parameters.AddWithValue("@mes", saldo.Mes);
                    pesquisar.Parameters.AddWithValue("@ano", saldo.Ano);
                }

                conexao.Open();                

                SqlDataReader registros = pesquisar.ExecuteReader();

                while (registros.Read())
                {
                    Paragraph convenios = new Paragraph(registros["saldo_valor_inicial"].ToString());
                    convenios.SetTextAlignment(TextAlignment.CENTER);
                    convenios.SetFontSize(9);

                    tabela.AddCell(convenios);

                    Paragraph escritorio = new Paragraph(registros["escritorio_total"].ToString());
                    escritorio.SetTextAlignment(TextAlignment.CENTER);
                    escritorio.SetFontSize(9);

                    tabela.AddCell(escritorio);

                    Paragraph pagamentos = new Paragraph(registros["pagamentos_valor"].ToString());
                    pagamentos.SetTextAlignment(TextAlignment.CENTER);
                    pagamentos.SetFontSize(9);

                    tabela.AddCell(pagamentos);

                    Paragraph saldo = new Paragraph(registros["saldo_valor"].ToString());
                    saldo.SetTextAlignment(TextAlignment.CENTER);
                    saldo.SetFontSize(9);

                    tabela.AddCell(saldo);

                    Paragraph mes = new Paragraph(registros["saldo_mes"].ToString());
                    mes.SetTextAlignment(TextAlignment.CENTER);
                    mes.SetFontSize(9);

                    tabela.AddCell(mes);

                    Paragraph ano = new Paragraph(registros["saldo_ano"].ToString());
                    ano.SetTextAlignment(TextAlignment.CENTER);
                    ano.SetFontSize(9);

                    tabela.AddCell(ano);
                }

                registros.Close();

                conexao.Close();

                documento.Add(tabela);

                documento.Close();
                documentoPdf.Close();

                System.Diagnostics.Process.Start("C:\\Clínica Contabilidade\\saldo.pdf");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao != null && conexao.State != ConnectionState.Closed)
                {
                    conexao.Close();
                }
            }
        }      
    }    
}
