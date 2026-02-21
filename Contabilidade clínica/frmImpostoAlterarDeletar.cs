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
    public partial class frmImpostoAlterarDeletar: Form
    {       
        public string Mes
        {
            set { cbContabilidadeMes.Text = value; }
        }

        public string Ano
        {
            set { txtContabilidadeAno.Text = value; }
        }


        public frmImpostoAlterarDeletar(string mes, string ano, string membro, string taxa, string id)
        {
            InitializeComponent();

            cbImpostoMes.Text = mes;
            txtImpostoAno.Text = ano;

            SqlConnection conexao = null;

            try
            {
                PagamentosBruto pagamentos = new PagamentosBruto(cbImpostoMes.Text, txtImpostoAno.Text);

                conexao = new SqlConnection(StringConexao.stringConexao);

                SqlCommand pesquisar = new SqlCommand("SELECT membro_id, membro_nome FROM tb_pagamentos_valor_bruto INNER JOIN tb_membros ON tb_pagamentos_valor_bruto.pagamento_bruto_membro = tb_membros.membro_id WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano AND NOT membro_funcao = 'Secretaria' ORDER BY membro_nome;", conexao);

                pesquisar.Parameters.AddWithValue("@mes", pagamentos.Mes);
                pesquisar.Parameters.AddWithValue("@ano", pagamentos.Ano);

                SqlDataAdapter registros2 = new SqlDataAdapter(pesquisar);

                DataTable tabela = new DataTable();

                conexao.Close();

                registros2.Fill(tabela);

                cbImpostoNome.ValueMember = "membro_id";
                cbImpostoNome.DisplayMember = "membro_nome";
                cbImpostoNome.DataSource = tabela;
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

            cbImpostoNome.Text = membro;
            txtImpostoTaxa.Text = taxa;
            txtId.Text = id;
        }
       

        private void frmImpostoAlterarDeletar_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmContabilidade contabilidade = new frmContabilidade();

            contabilidade.AbrirAba = 2;

            if (cbContabilidadeMes.Text != "" && txtContabilidadeAno.Text != "")
            {
                contabilidade.Mes = cbContabilidadeMes.Text;
                contabilidade.Ano = txtContabilidadeAno.Text;
            }

            contabilidade.Show();
        }   

        private void cbImpostoMes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cbImpostoNome.SelectedIndex = -1;
        }

        private void txtImpostoAno_TextChanged_1(object sender, EventArgs e)
        {
            cbImpostoNome.SelectedIndex = -1;
        }

        private void cbImpostoNome_DropDown_1(object sender, EventArgs e)
        {
            if (cbImpostoMes.Text == "" || txtImpostoAno.Text == "")
            {
                MessageBox.Show("Informe o mês e o ano no qual o imposto se refere", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDecimal(txtImpostoAno.Text) < 2000 || Convert.ToDecimal(txtImpostoAno.Text) > 2099)
            {
                MessageBox.Show("Informe um ano válido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                cbImpostoNome.Items.Clear();
            }
            else
            {
                SqlConnection conexao = null;

                try
                {
                    PagamentosBruto pagamentos = new PagamentosBruto(cbImpostoMes.Text, txtImpostoAno.Text);

                    conexao = new SqlConnection(StringConexao.stringConexao);

                    SqlCommand pesquisar = new SqlCommand("SELECT membro_id, membro_nome FROM tb_pagamentos_valor_bruto INNER JOIN tb_membros ON tb_pagamentos_valor_bruto.pagamento_bruto_membro = tb_membros.membro_id WHERE pagamento_bruto_mes = @mes AND pagamento_bruto_ano = @ano AND NOT membro_funcao = 'Secretaria';", conexao);

                    pesquisar.Parameters.AddWithValue("@mes", pagamentos.Mes);
                    pesquisar.Parameters.AddWithValue("@ano", pagamentos.Ano);

                    SqlDataAdapter registros2 = new SqlDataAdapter(pesquisar);

                    DataTable tabela = new DataTable();

                    conexao.Close();

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

        private void txtImpostoAno_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 || txtImpostoAno.Text.Length == 4 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtImpostoTaxa_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void btnAlterar_Click_1(object sender, EventArgs e)
        {
            if (cbImpostoMes.Text == "" || txtImpostoAno.Text == "" || cbImpostoNome.Text == "" || txtImpostoTaxa.Text == "")
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
                        PagamentosBruto pagamento = new PagamentosBruto(Convert.ToInt32(cbImpostoNome.SelectedValue), cbImpostoMes.Text, txtImpostoAno.Text);

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

                        decimal calculo = Convert.ToDecimal(txtImpostoTaxa.Text) / 100;
                        decimal impostoValor = pagamentoMensal * calculo;

                        Impostos imposto = new Impostos(Convert.ToInt32(cbImpostoNome.SelectedValue), Convert.ToDecimal(txtImpostoTaxa.Text), id, impostoValor, id, id, Convert.ToInt32(txtId.Text));

                        SqlCommand pesquisar2 = new SqlCommand("SELECT * FROM tb_impostos WHERE imposto_membro = @membro AND imposto_mes = @mes AND imposto_ano = @ano AND NOT imposto_id = @id", conexao);

                        pesquisar2.Parameters.AddWithValue("@membro", imposto.Membro);
                        pesquisar2.Parameters.AddWithValue("@mes", imposto.Mes);
                        pesquisar2.Parameters.AddWithValue("@ano", imposto.Ano);
                        pesquisar2.Parameters.AddWithValue("@id", imposto.Id);

                        SqlDataReader registros2 = pesquisar2.ExecuteReader();

                        if (registros2.HasRows)
                        {
                            MessageBox.Show("O imposto deste membro da clínica desta data já foi informado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            registros2.Close();
                            conexao.Close();
                        }
                        else
                        {
                            registros2.Close();

                            SqlCommand pesquisar3 = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_nao_socios WHERE desconto_imposto = @id;", conexao);

                            pesquisar3.Parameters.AddWithValue("@id", imposto.Id);

                            SqlCommand pesquisar4 = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_socios WHERE desconto_imposto = @id;", conexao);                            

                            pesquisar4.Parameters.AddWithValue("@id", imposto.Id);

                            int quantidade = Convert.ToInt32(pesquisar3.ExecuteScalar());
                            int quantidade2 = Convert.ToInt32(pesquisar4.ExecuteScalar());

                            if (quantidade > 0 || quantidade2 > 0)
                            {
                                MessageBox.Show("Um registro na tabela de pagamentos (valor líquido) está fazendo uso desta informação. Apague-o para poder fazer uma alteração neste registro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                
                                conexao.Close();
                            }
                            else
                            {
                                SqlCommand alterar = new SqlCommand("UPDATE tb_impostos SET imposto_membro = @membro, imposto_taxa = @taxa, pagamento_mensal_bruto = @pagamento, imposto_valor = @imposto, imposto_mes = @mes, imposto_ano = @ano WHERE imposto_id = @id;", conexao);

                                alterar.Parameters.AddWithValue("@membro", imposto.Membro);
                                alterar.Parameters.AddWithValue("@taxa", imposto.Taxa);
                                alterar.Parameters.AddWithValue("@pagamento", imposto.Pagamento);
                                alterar.Parameters.AddWithValue("@imposto", imposto.Valor);
                                alterar.Parameters.AddWithValue("@mes", imposto.Mes);
                                alterar.Parameters.AddWithValue("@ano", imposto.Ano);
                                alterar.Parameters.AddWithValue("@id", imposto.Id);

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

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            var botao = MessageBox.Show("Confirmar a remoção do registro?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (botao == DialogResult.Yes)
            {
                SqlConnection conexao = null;

                try
                {
                    Impostos imposto = new Impostos(Convert.ToInt32(txtId.Text));

                    conexao = new SqlConnection(StringConexao.stringConexao);

                    SqlCommand pesquisar = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_nao_socios WHERE desconto_imposto = @id;", conexao);

                    pesquisar.Parameters.AddWithValue("@id", imposto.Id);

                    SqlCommand pesquisar2 = new SqlCommand("SELECT COUNT(*) FROM tb_pagamentos_socios WHERE desconto_imposto = @id;", conexao);

                    pesquisar2.Parameters.AddWithValue("@id", imposto.Id);

                    conexao.Open();

                    int quantidade = Convert.ToInt32(pesquisar.ExecuteScalar());
                    int quantidade2 = Convert.ToInt32(pesquisar2.ExecuteScalar());


                    if (quantidade > 0 || quantidade2 > 0)
                    {
                        MessageBox.Show("Um registro na tabela de pagamentos (valor líquido) está fazendo uso desta informação. Apague-o para poder remover este registro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        conexao.Close();
                    }
                    else
                    {
                        SqlCommand deletar = new SqlCommand("DELETE FROM tb_impostos WHERE imposto_id = @id", conexao);

                        deletar.Parameters.AddWithValue("@id", imposto.Id);

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
