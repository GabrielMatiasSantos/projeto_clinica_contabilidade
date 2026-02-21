using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contabilidade_clínica
{
    public partial class frmAluguelAlterarDeletar : Form
    {       
        public string Mes
        {
            set { cbContabilidadeMes.Text = value; }
        }

        public string Ano
        {
            set { txtContabilidadeAno.Text = value; }
        }


        public frmAluguelAlterarDeletar(string mes, string ano, string nome, string periodo, string valor, string id)
        {
            InitializeComponent();

            cbAluguelMes.Text = mes;
            txtAluguelAno.Text = ano;

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

            cbAluguelNome.Text = nome;
            cbAluguelPeriodo.Text = periodo;
            txtAluguelValor.Text = valor;
            txtId.Text = id;
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

                    SqlCommand pesquisar = new SqlCommand("SELECT membro_id, membro_nome FROM tb_pagamentos_valor_bruto INNER JOIN tb_membros ON tb_pagamentos_valor_bruto.pagamento_bruto_membro = tb_membros.membro_id WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano AND membro_relacao_clinica = 'Não sócio' AND NOT membro_funcao = 'Secretaria';", conexao);

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

        private void frmAluguelAlterarDeletar_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmContabilidade contabilidade = new frmContabilidade();

            contabilidade.AbrirAba = 4;

            if (cbContabilidadeMes.Text != "" && txtContabilidadeAno.Text != "")
            {
                contabilidade.Mes = cbContabilidadeMes.Text;
                contabilidade.Ano = txtContabilidadeAno.Text;
            }

            contabilidade.Show();
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (cbAluguelMes.Text == "" || txtAluguelAno.Text == "" || cbAluguelNome.Text == "" || cbAluguelPeriodo.Text == "" || txtAluguelValor.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var botao = MessageBox.Show("Confirmar a inserção de dados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (botao == DialogResult.Yes)
                {
                    SqlConnection conexao = null;

                    try
                    {
                        Aluguel aluguel = new Aluguel(Convert.ToInt32(cbAluguelNome.SelectedValue), cbAluguelPeriodo.Text, Convert.ToDecimal(txtAluguelValor.Text), cbAluguelMes.Text, txtAluguelAno.Text, Convert.ToInt32(txtId.Text));

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_aluguel WHERE aluguel_membro = @membro AND aluguel_mes = @mes AND aluguel_ano = @ano AND NOT aluguel_id = @id", conexao);

                        pesquisar.Parameters.AddWithValue("@membro", aluguel.Membro);
                        pesquisar.Parameters.AddWithValue("@mes", aluguel.Mes);
                        pesquisar.Parameters.AddWithValue("@ano", aluguel.Ano);
                        pesquisar.Parameters.AddWithValue("@id", aluguel.Id);

                        conexao.Open();

                        SqlDataReader registros = pesquisar.ExecuteReader();

                        if (registros.HasRows)
                        {
                            MessageBox.Show("Já existe um pagamento deste nome nesta data", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            registros.Close();
                            conexao.Close();
                        }
                        else
                        {
                            registros.Close();

                            SqlCommand pesquisar2 = new SqlCommand("SELECT * FROM tb_pagamentos_nao_socios WHERE desconto_aluguel = @id;", conexao);

                            pesquisar2.Parameters.AddWithValue("@id", aluguel.Id);

                            SqlDataReader registros2 = pesquisar2.ExecuteReader();
                           
                            if (registros2.HasRows)
                            {
                                MessageBox.Show("Um registro na tabela de pagamentos (valor líquido) está fazendo uso destas informações. Apague-o para poder fazer alterações neste registro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                registros2.Close();
                                conexao.Close();
                            }
                            else
                            {
                                registros2.Close();

                                SqlCommand alterar = new SqlCommand("UPDATE tb_aluguel SET aluguel_membro = @membro, aluguel_periodo = @periodo, aluguel_valor = @valor, aluguel_mes = @mes, aluguel_ano = @ano WHERE aluguel_id = @id;", conexao);

                                alterar.Parameters.AddWithValue("@membro", aluguel.Membro);
                                alterar.Parameters.AddWithValue("@periodo", aluguel.Periodo);
                                alterar.Parameters.AddWithValue("@valor", aluguel.Valor);
                                alterar.Parameters.AddWithValue("@Mes", aluguel.Mes);
                                alterar.Parameters.AddWithValue("@ano", aluguel.Ano);
                                alterar.Parameters.AddWithValue("@id", aluguel.Id);

                                alterar.ExecuteNonQuery();

                                MessageBox.Show("Inserção feita com sucesso", "Operação bem sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.Close();
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

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            var botao = MessageBox.Show("Confirmar a remoção do registro?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (botao == DialogResult.Yes)
            {
                SqlConnection conexao = null;

                try
                {
                    Aluguel aluguel = new Aluguel(Convert.ToInt32(txtId.Text));

                    conexao = new SqlConnection(StringConexao.stringConexao);

                    SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_pagamentos_nao_socios WHERE desconto_aluguel = @id;", conexao);

                    pesquisar.Parameters.AddWithValue("@id", aluguel.Id);

                    conexao.Open();

                    SqlDataReader registros = pesquisar.ExecuteReader();

                    if (registros.HasRows)
                    {
                        MessageBox.Show("Um registro na tabela de pagamentos (valor líquido) está fazendo uso destas informações. Apague-o para poder remover este registro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        registros.Close();
                        conexao.Close();
                    }
                    else
                    {
                        registros.Close();

                        SqlCommand deletar = new SqlCommand("DELETE FROM tb_aluguel WHERE aluguel_id = @id", conexao);

                        deletar.Parameters.AddWithValue("@id", aluguel.Id);

                        deletar.ExecuteNonQuery();

                        conexao.Close();

                        MessageBox.Show("Remoção feita com sucesso", "Operação bem sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
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
