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
    public partial class frmCondominioHorasAlterarDeletar: Form
    {    
        public string Mes
        {
            set { cbContabilidadeMes.Text = value; }
        }

        public string Ano
        {
            set { txtContabilidadeAno.Text = value; }
        }


        public frmCondominioHorasAlterarDeletar(string mes, string ano, string membro, string horas, string id)
        {
            InitializeComponent();

            cbCondominioMes.Text = mes;
            txtCondominioAno.Text = ano;

            SqlConnection conexao = null;

            try
            {
                PagamentosBruto pagamentos = new PagamentosBruto(cbCondominioMes.Text, txtCondominioAno.Text);

                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT membro_id, membro_nome FROM tb_pagamentos_valor_bruto INNER JOIN tb_membros ON tb_pagamentos_valor_bruto.pagamento_bruto_membro = tb_membros.membro_id WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano AND NOT membro_funcao = 'Secretaria' ORDER BY membro_nome;", conexao);

                pesquisar.Parameters.AddWithValue("@mes", pagamentos.Mes);
                pesquisar.Parameters.AddWithValue("@ano", pagamentos.Ano);

                SqlDataAdapter registros2 = new SqlDataAdapter(pesquisar);

                DataTable tabela = new DataTable();

                conexao.Close();

                registros2.Fill(tabela);

                cbCondominioNome.ValueMember = "membro_id";
                cbCondominioNome.DisplayMember = "membro_nome";
                cbCondominioNome.DataSource = tabela;
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

            cbCondominioNome.Text = membro;
            txtCondominioHoras.Text = horas;
            txtId.Text = id;
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

        private void cbCondominioNome_DropDown(object sender, EventArgs e)
        {
            if (cbCondominioMes.Text == "" || txtCondominioAno.Text == "")
            {
                MessageBox.Show("Informe o mês e o ano no qual o imposto se refere", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDecimal(txtCondominioAno.Text) < 2000 || Convert.ToDecimal(txtCondominioAno.Text) > 2099)
            {
                MessageBox.Show("Informe um ano válido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cbCondominioNome.Items.Clear();
            }
            else
            {
                SqlConnection conexao = null;

                try
                {
                    PagamentosBruto pagamentos = new PagamentosBruto(cbCondominioMes.Text, txtCondominioAno.Text);

                    conexao = new SqlConnection(StringConexao.stringConexao);

                    SqlCommand pesquisar = new SqlCommand("SELECT membro_id, membro_nome FROM tb_pagamentos_valor_bruto INNER JOIN tb_membros ON tb_pagamentos_valor_bruto.pagamento_bruto_membro = tb_membros.membro_id WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano AND NOT membro_funcao = 'Secretaria';", conexao);

                    pesquisar.Parameters.AddWithValue("@mes", pagamentos.Mes);
                    pesquisar.Parameters.AddWithValue("@ano", pagamentos.Ano);

                    SqlDataAdapter registros2 = new SqlDataAdapter(pesquisar);

                    DataTable tabela = new DataTable();

                    conexao.Close();

                    registros2.Fill(tabela);

                    cbCondominioNome.ValueMember = "membro_id";
                    cbCondominioNome.DisplayMember = "membro_nome";
                    cbCondominioNome.DataSource = tabela;
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (cbCondominioMes.Text == "" || txtCondominioAno.Text == "" || cbCondominioNome.Text == "" || txtCondominioHoras.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDecimal(txtCondominioAno.Text) < 2000 || Convert.ToDecimal(txtCondominioAno.Text) > 2099)
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
                        CondominioHoras condominio = new CondominioHoras(Convert.ToInt32(txtId.Text), Convert.ToInt32(cbCondominioNome.SelectedValue), Convert.ToInt32(txtCondominioHoras.Text), cbCondominioMes.Text, txtCondominioAno.Text);

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_horas_trabalhadas WHERE horas_trabalhadas_membro = @membro AND horas_trabalhadas_mes = @mes AND horas_trabalhadas_ano = @ano AND NOT horas_trabalhadas_id = @id", conexao);

                        pesquisar.Parameters.AddWithValue("@membro", condominio.Membro);
                        pesquisar.Parameters.AddWithValue("@mes", condominio.Mes);
                        pesquisar.Parameters.AddWithValue("@ano", condominio.Ano);
                        pesquisar.Parameters.AddWithValue("@id", condominio.Id);

                        conexao.Open();

                        SqlDataReader registros = pesquisar.ExecuteReader();

                       if (registros.HasRows)
                       {
                            MessageBox.Show("Já há um registro desta data com este membro da clínica", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            registros.Close();
                            conexao.Close();
                       }
                       else
                       {
                            registros.Close();

                            SqlCommand pesquisar2 = new SqlCommand("SELECT * FROM tb_membros_condominio WHERE membro_horas_trabalhadas = @id;", conexao);

                            pesquisar2.Parameters.AddWithValue("@id", condominio.Id);

                            SqlDataReader registros2 = pesquisar2.ExecuteReader();

                            if (registros2.HasRows)
                            {
                                MessageBox.Show("Um registro na tabela de valores de condomínio dos membros da clínica está fazendo uso desta informação. Apague-o para poder fazer uma alteração neste registro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                registros2.Close();
                                conexao.Close();
                            }
                            else
                            {
                                registros2.Close();

                                SqlCommand alterar = new SqlCommand("UPDATE tb_horas_trabalhadas SET horas_trabalhadas_membro = @membro, horas_trabalhadas = @horas, horas_trabalhadas_mes = @mes, horas_trabalhadas_ano = @ano WHERE horas_trabalhadas_id = @id;", conexao);

                                alterar.Parameters.AddWithValue("@membro", condominio.Membro);
                                alterar.Parameters.AddWithValue("@horas", condominio.Horas);
                                alterar.Parameters.AddWithValue("@mes", condominio.Mes);
                                alterar.Parameters.AddWithValue("@ano", condominio.Ano);
                                alterar.Parameters.AddWithValue("@id", condominio.Id);

                                alterar.ExecuteNonQuery();

                                conexao.Close();

                                MessageBox.Show("Inserção feita com sucesso", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void frmCondominioHorasAlterarDeletar_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmContabilidade contabilidade = new frmContabilidade();

            contabilidade.AbrirAba = 3;
            contabilidade.CondominioAba = "parte2";

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
                    CondominioHoras condominio = new CondominioHoras(Convert.ToInt32(txtId.Text));

                    conexao = new SqlConnection(StringConexao.stringConexao);

                    SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_membros_condominio WHERE membro_horas_trabalhadas = @id;", conexao);

                    pesquisar.Parameters.AddWithValue("@id", condominio.Id);

                    conexao.Open();

                    SqlDataReader registros = pesquisar.ExecuteReader();

                    if (registros.HasRows)
                    {
                        MessageBox.Show("Um registro na tabela de valores de condomínio dos membros da clínica está fazendo uso desta informação. Apague-o para remover este registro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        registros.Close();
                        conexao.Close();
                    }
                    else
                    {
                        registros.Close();

                        SqlCommand deletar = new SqlCommand("DELETE FROM tb_horas_trabalhadas WHERE horas_trabalhadas_id = @id;", conexao);

                        deletar.Parameters.AddWithValue("@id", condominio.Id);

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
