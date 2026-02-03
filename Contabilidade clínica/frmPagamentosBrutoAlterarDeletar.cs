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
    public partial class frmPagamentosBrutoAlterarDeletar: Form
    {      
        public string Mes
        {
            set { cbContabilidadeMes.Text = value; }
        }

        public string Ano
        {
            set { txtContabilidadeAno.Text = value; }
        }

        private void txtPagamentosBrutoValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPagamentosBrutoValor.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtPagamentosBrutoValor.Text.Contains(','))
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
            else if (txtPagamentosBrutoValor.Text == "0")
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

        private void txtPagamentosBrutoAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 || txtPagamentosBrutoAno.Text.Length == 4 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }


        public frmPagamentosBrutoAlterarDeletar(string membro, string valor, string mes, string ano, string id)
        {
            InitializeComponent();

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


            cbPagamentosBrutoMembros.Text = membro;
            txtPagamentosBrutoValor.Text = valor;
            cbPagamentosBrutoMes.Text = mes;
            txtPagamentosBrutoAno.Text = ano;
            txtId.Text = id;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
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

                if (botao == DialogResult.Yes)
                {
                    SqlConnection conexao = null;

                    try
                    {
                        PagamentosBruto pagamentos = new PagamentosBruto(Convert.ToInt32(cbPagamentosBrutoMembros.SelectedValue), Convert.ToDecimal(txtPagamentosBrutoValor.Text), cbPagamentosBrutoMes.Text, txtPagamentosBrutoAno.Text, Convert.ToInt32(txtId.Text));

                        conexao = new SqlConnection(StringConexao.stringConexao);                                                 

                        SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_membro = @membro AND pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano AND NOT pagamento_bruto_id = @id;", conexao);

                        pesquisar.Parameters.AddWithValue("@membro", pagamentos.Membro);
                        pesquisar.Parameters.AddWithValue("@mes", pagamentos.Mes);
                        pesquisar.Parameters.AddWithValue("@ano", pagamentos.Ano);
                        pesquisar.Parameters.AddWithValue("@id", pagamentos.Id);

                        conexao.Open();

                        SqlDataReader registros = pesquisar.ExecuteReader();

                        if (registros.HasRows)
                        {
                            MessageBox.Show("Já há um registro com este membro nesta data", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            registros.Close();
                            conexao.Close();
                        }
                        else
                        {
                            registros.Close();

                            SqlCommand pesquisar2 = new SqlCommand("SELECT * FROM tb_impostos WHERE pagamento_mensal_bruto = @id;", conexao);

                            pesquisar2.Parameters.AddWithValue("@id", pagamentos.Id);                            

                            SqlDataReader registros2 = pesquisar2.ExecuteReader();

                            if (registros2.HasRows)
                            {
                                MessageBox.Show("Um registro na tabela de impostos está fazendo uso desta informação. Apague-o para poder fazer uma alteração neste registro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                registros2.Close();
                                conexao.Close();
                            }
                            else
                            {
                                registros2.Close();

                                SqlCommand alterar = new SqlCommand("UPDATE tb_pagamentos_valor_bruto SET pagamento_bruto_membro = @membro, pagamento_bruto_valor = @valor, pagamento_bruto_mes = @mes, pagamento_bruto_ano = @ano WHERE pagamento_bruto_id = @id", conexao);

                                alterar.Parameters.AddWithValue("@membro", pagamentos.Membro);
                                alterar.Parameters.AddWithValue("@valor", pagamentos.Valor);
                                alterar.Parameters.AddWithValue("@mes", pagamentos.Mes);
                                alterar.Parameters.AddWithValue("@ano", pagamentos.Ano);
                                alterar.Parameters.AddWithValue("@id", pagamentos.Id);

                                alterar.ExecuteNonQuery();

                                conexao.Close();

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

        private void frmPagamentosBrutoAlterarDeletar_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmContabilidade contabilidade = new frmContabilidade();

            contabilidade.AbrirAba = 1;

            if (cbContabilidadeMes.Text != "" && txtContabilidadeAno.Text != "")
            {
                contabilidade.Mes = cbContabilidadeMes.Text;
                contabilidade.Ano = txtContabilidadeAno.Text;
            }

            contabilidade.Show();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var botao = MessageBox.Show("Confirmar a remoção do registro?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (botao == DialogResult.Yes)
            {
                SqlConnection conexao = null;

                try
                {
                    PagamentosBruto pagamentos = new PagamentosBruto(Convert.ToInt32(txtId.Text));

                    conexao = new SqlConnection(StringConexao.stringConexao);

                    SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_impostos WHERE pagamento_mensal_bruto = @id;", conexao);

                    pesquisar.Parameters.AddWithValue("@id", pagamentos.Id);

                    conexao.Open();

                    SqlDataReader registros = pesquisar.ExecuteReader();

                    if (registros.HasRows)
                    {
                        MessageBox.Show("Um registro na tabela de impostos está fazendo uso desta informação. Apague-o para remover este registro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        registros.Close();
                        conexao.Close();
                    }
                    else
                    {
                        registros.Close();

                        SqlCommand deletar = new SqlCommand("DELETE FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_id = @id", conexao);

                        deletar.Parameters.AddWithValue("@id", pagamentos.Id);

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
    

