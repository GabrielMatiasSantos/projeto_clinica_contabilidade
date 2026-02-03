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
    public partial class frmConvenioValoresAlterarDeletar: Form
    {      
        public string Mes
        {
            set { cbContabilidadeMes.Text = value; }
        }

        public string Ano
        {
            set { txtContabilidadeAno.Text = value; }
        }


        public frmConvenioValoresAlterarDeletar(string convenio, string valor, string glosa, string desconto, string mes, string ano, string id)
        {
            InitializeComponent();

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

            cbConvenios.Text = convenio;
            txtConvenioValor.Text = valor;
            txtConvenioGlosa.Text = glosa;
            txtConvenioDesconto.Text = desconto;
            cbConvenioMes.Text = mes;
            txtConvenioAno.Text = ano;
            txtId.Text = id;
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

        private void frmConvenioValoresAlterarDeletar_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmContabilidade contabilidade = new frmContabilidade();

            contabilidade.AbrirAba = 7;
            contabilidade.ConvenioAba = "parte2";

            if (cbContabilidadeMes.Text != "" && txtContabilidadeAno.Text != "")
            {
                contabilidade.Mes = cbContabilidadeMes.Text;
                contabilidade.Ano = txtContabilidadeAno.Text;
            }

            contabilidade.Show();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
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
                var botao = MessageBox.Show("Confirmar inserção de dados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (botao == DialogResult.Yes)
                {
                    SqlConnection conexao = null;

                    try
                    {
                        decimal calculo1 = Convert.ToDecimal(txtConvenioValor.Text) - Convert.ToDecimal(txtConvenioGlosa.Text);

                        decimal calculo2 = Convert.ToDecimal(txtConvenioDesconto.Text) / 100;

                        decimal calculo3 = calculo1 * calculo2;

                        Convenio convenio = new Convenio(Convert.ToInt32(txtId.Text), Convert.ToInt32(cbConvenios.SelectedValue), Convert.ToDecimal(txtConvenioValor.Text), Convert.ToDecimal(txtConvenioGlosa.Text), Convert.ToDecimal(txtConvenioDesconto.Text), calculo1 - calculo3, cbConvenioMes.Text, txtConvenioAno.Text);

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_convenios_valores WHERE convenio = @convenio AND convenio_valor_mes = @mes AND convenio_valor_ano = @ano AND NOT convenio_valor_id = @id", conexao);

                        pesquisar.Parameters.AddWithValue("@convenio", convenio.Convenio2);
                        pesquisar.Parameters.AddWithValue("@mes", convenio.Mes);
                        pesquisar.Parameters.AddWithValue("@ano", convenio.Ano);
                        pesquisar.Parameters.AddWithValue("@id", convenio.Id);

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

                            SqlCommand pesquisar2 = new SqlCommand("SELECT convenio_valor_mes, convenio_valor_ano FROM tb_convenios_valores WHERE convenio_valor_id = @id;", conexao);

                            pesquisar2.Parameters.AddWithValue("@id", convenio.Id);

                            SqlDataReader registros2 = pesquisar2.ExecuteReader();

                            registros2.Read();

                            string mes = registros2["convenio_valor_mes"].ToString();
                            string ano = registros2["convenio_valor_ano"].ToString();

                            registros2.Close();

                            SqlCommand pesquisar3 = new SqlCommand("SELECT * FROM tb_saldos WHERE saldo_mes = @mes AND saldo_ano = @ano;", conexao);

                            pesquisar3.Parameters.AddWithValue("@mes", mes);
                            pesquisar3.Parameters.AddWithValue("@ano", ano);

                            SqlDataReader registros3 = pesquisar3.ExecuteReader();

                            if (registros3.HasRows)
                            {
                                MessageBox.Show("Um registro na tabela de saldos está fazendo uso desta informação. Apague-o para poder fazer uma alteração neste registro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                registros3.Close();
                                conexao.Close();
                            }
                            else
                            {
                                registros3.Close();

                                SqlCommand alterar = new SqlCommand("UPDATE tb_convenios_valores SET convenio = @convenio, convenio_valor_inicial = @valorInicial, convenio_valor_glosa = @glosa, convenio_valor_desconto = @desconto, convenio_valor_final = @valor, convenio_valor_mes = @mes, convenio_valor_ano = @ano WHERE convenio_valor_id = @id", conexao);

                                alterar.Parameters.AddWithValue("@convenio", convenio.Convenio2);
                                alterar.Parameters.AddWithValue("@valorInicial", convenio.ValorInicial);
                                alterar.Parameters.AddWithValue("@glosa", convenio.Glosa);
                                alterar.Parameters.AddWithValue("@desconto", convenio.Desconto);
                                alterar.Parameters.AddWithValue("@valor", convenio.Valor);
                                alterar.Parameters.AddWithValue("@mes", convenio.Mes);
                                alterar.Parameters.AddWithValue("@ano", convenio.Ano);
                                alterar.Parameters.AddWithValue("@id", convenio.Id);

                                alterar.ExecuteNonQuery();

                                conexao.Close();

                                MessageBox.Show("Inserção feita com sucesso", "Operação bem sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.Close();
                            }
                        }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var botao = MessageBox.Show("Confirmar a remoção do registro?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (botao == DialogResult.Yes)
            {
                SqlConnection conexao = null;

                try
                {
                    Convenio convenio = new Convenio(Convert.ToInt32(txtId.Text));

                    conexao = new SqlConnection(StringConexao.stringConexao);

                    SqlCommand pesquisar = new SqlCommand("SELECT convenio_valor_mes, convenio_valor_ano FROM tb_convenios_valores WHERE convenio_valor_id = @id;", conexao);

                    pesquisar.Parameters.AddWithValue("@id", convenio.Id);

                    conexao.Open();

                    SqlDataReader registros = pesquisar.ExecuteReader();                    

                    registros.Read();

                    string mes = registros["convenio_valor_mes"].ToString();
                    string ano = registros["convenio_valor_ano"].ToString();

                    registros.Close();

                    SqlCommand pesquisar2 = new SqlCommand("SELECT * FROM tb_saldos WHERE saldo_mes = @mes AND saldo_ano = @ano;", conexao);

                    pesquisar2.Parameters.AddWithValue("@mes", mes);
                    pesquisar2.Parameters.AddWithValue("@ano", ano);

                    SqlDataReader registros2 = pesquisar2.ExecuteReader();

                    if (registros2.HasRows)
                    {
                        MessageBox.Show("Um registro na tabela de saldos está fazendo uso desta informação. Apague-o para poder remover este registro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        registros2.Close();
                        conexao.Close();
                    }
                    else
                    {
                        registros2.Close();

                        SqlCommand deletar = new SqlCommand("DELETE FROM tb_convenios_valores WHERE convenio_valor_id = @id", conexao);

                        deletar.Parameters.AddWithValue("@id", convenio.Id);

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
