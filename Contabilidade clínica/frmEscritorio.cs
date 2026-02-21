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
    public partial class frmEscritorio: Form
    {
        public frmEscritorio()
        {
            InitializeComponent();
        }

        public frmEscritorio(string pis, string cofins, string iss, string inss, string ir, string cs, string ciee, string aluguel, string escritorio, string mes, string ano, string id)
        {
            InitializeComponent();

            txtPis.Text = pis;
            txtCofins.Text = cofins;
            txtIss.Text = iss;
            txtInss.Text = inss;
            txtIr.Text = ir;
            txtCs.Text = cs;
            txtCiee.Text = ciee;
            txtAluguel.Text = aluguel;
            txtEscritorio.Text = escritorio;
            cbMes.Text = mes;
            txtAno.Text = ano;
            txtId.Text = id;
        }        

        public string MesContabilidade
        {
            set { cbContabilidadeMes.Text = value; }
        }

        public string AnoContabilidade
        {
            set { txtContabilidadeAno.Text = value; }
        }


        public bool Alterar
        {
            set {btnAlterar.Visible = value;}
        }

        public bool Salvar
        {
            set {btnSalvar.Visible = value;}
        }

        public bool Deletar
        {
            set {btnDeletar.Visible = value;}
        }

        public string Texto
        {
            set { this.Text = value;}
        }

        public string Mes
        {
            set {cbMes.Text = value;}
        }

        public string Ano
        {
            set { txtAno.Text = value; }
        }


        private void txtPis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPis.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtPis.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtPis.Text.Substring(txtPis.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtPis.Text == "0")
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

        private void txtCofins_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCofins.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtCofins.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtCofins.Text.Substring(txtCofins.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtCofins.Text == "0")
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

        private void txtIss_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtIss.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtIss.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtIss.Text.Substring(txtIss.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtIss.Text == "0")
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

        private void txtInss_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtInss.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtInss.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtInss.Text.Substring(txtInss.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtInss.Text == "0")
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

        private void txtIr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtIr.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtIr.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtIr.Text.Substring(txtIr.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtIr.Text == "0")
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

        private void txtCs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCs.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtCs.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtCs.Text.Substring(txtCs.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtCs.Text == "0")
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

        private void txtCiee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCiee.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtCiee.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtCiee.Text.Substring(txtCiee.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtCiee.Text == "0")
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

        private void txtAluguel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAluguel.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtAluguel.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtAluguel.Text.Substring(txtAluguel.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtAluguel.Text == "0")
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

        private void txtEscritorio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtEscritorio.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtEscritorio.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtEscritorio.Text.Substring(txtEscritorio.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtEscritorio.Text == "0")
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

        private void txtAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 || txtAno.Text.Length == 4 && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void frmEscritorio_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmContabilidade contabilidade = new frmContabilidade();

            contabilidade.AbrirAba = 6;

            if (cbContabilidadeMes.Text != "" && txtContabilidadeAno.Text != "")
            {
                contabilidade.Mes = cbContabilidadeMes.Text;
                contabilidade.Ano = txtContabilidadeAno.Text;
            }

            contabilidade.Show();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtPis.Text == "" || txtCofins.Text == "" || txtIss.Text == "" || txtInss.Text == "" || txtIr.Text == "" || txtCs.Text == "" || txtCiee.Text == "" || txtAluguel.Text == "" || txtEscritorio.Text == "" || cbMes.Text == "" || txtAno.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDecimal(txtAno.Text) < 2000 || Convert.ToDecimal(txtAno.Text) > 2099)
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
                        Escritorio escritorio = new Escritorio(Convert.ToDecimal(txtPis.Text), Convert.ToDecimal(txtCofins.Text), Convert.ToDecimal(txtIss.Text), Convert.ToDecimal(txtInss.Text), Convert.ToDecimal(txtIr.Text), Convert.ToDecimal(txtCs.Text), Convert.ToDecimal(txtCiee.Text), Convert.ToDecimal(txtAluguel.Text), Convert.ToDecimal(txtEscritorio.Text), Convert.ToDecimal(txtPis.Text) + Convert.ToDecimal(txtCofins.Text) + Convert.ToDecimal(txtIss.Text) + Convert.ToDecimal(txtInss.Text) + Convert.ToDecimal(txtIr.Text) + Convert.ToDecimal(txtCs.Text) + Convert.ToDecimal(txtCiee.Text) + Convert.ToDecimal(txtAluguel.Text) + Convert.ToDecimal(txtEscritorio.Text), cbMes.Text, txtAno.Text);

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_escritorio WHERE escritorio_mes = @mes AND escritorio_ano = @ano;", conexao);

                        pesquisar.Parameters.AddWithValue("@mes", escritorio.Mes);
                        pesquisar.Parameters.AddWithValue("@ano", escritorio.Ano);

                        conexao.Open();

                        SqlDataReader registros = pesquisar.ExecuteReader();

                        if (registros.HasRows)
                        {
                            MessageBox.Show("Já há um registro com esta data", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            registros.Close();
                            conexao.Close();
                        }
                        else
                        {
                            registros.Close();

                            SqlCommand inserir = new SqlCommand("INSERT INTO tb_escritorio VALUES (@pis, @cofins, @iss, @inss, @ir, @cs, @ciee, @aluguel, @escritorio, @total, @mes, @ano);", conexao);

                            inserir.Parameters.AddWithValue("@pis", escritorio.Pis);
                            inserir.Parameters.AddWithValue("@cofins", escritorio.Cofins);
                            inserir.Parameters.AddWithValue("@iss", escritorio.Iss);
                            inserir.Parameters.AddWithValue("@inss", escritorio.Inss);
                            inserir.Parameters.AddWithValue("@ir", escritorio.Ir);
                            inserir.Parameters.AddWithValue("@cs", escritorio.Cs);
                            inserir.Parameters.AddWithValue("@ciee", escritorio.Ciee);
                            inserir.Parameters.AddWithValue("@aluguel", escritorio.Aluguel);
                            inserir.Parameters.AddWithValue("@escritorio", escritorio.Escritorio1);
                            inserir.Parameters.AddWithValue("@total", escritorio.Total);
                            inserir.Parameters.AddWithValue("@mes", escritorio.Mes);
                            inserir.Parameters.AddWithValue("@ano", escritorio.Ano);                            

                            inserir.ExecuteNonQuery();

                            conexao.Close();

                            MessageBox.Show("Novos gastos de escritório inseridos com sucesso", "Operação bem sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtPis.Text == "" || txtCofins.Text == "" || txtIss.Text == "" || txtInss.Text == "" || txtIr.Text == "" || txtCs.Text == "" || txtCiee.Text == "" || txtAluguel.Text == "" || txtEscritorio.Text == "" || txtAno.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToDecimal(txtAno.Text) < 2000 || Convert.ToDecimal(txtAno.Text) > 2099)
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
                        Escritorio escritorio = new Escritorio(Convert.ToInt32(txtId.Text), Convert.ToDecimal(txtPis.Text), Convert.ToDecimal(txtCofins.Text), Convert.ToDecimal(txtIss.Text), Convert.ToDecimal(txtInss.Text), Convert.ToDecimal(txtIr.Text), Convert.ToDecimal(txtCs.Text), Convert.ToDecimal(txtCiee.Text), Convert.ToDecimal(txtEscritorio.Text), Convert.ToDecimal(txtEscritorio.Text), Convert.ToDecimal(txtPis.Text) + Convert.ToDecimal(txtCofins.Text) + Convert.ToDecimal(txtIss.Text) + Convert.ToDecimal(txtInss.Text) + Convert.ToDecimal(txtIr.Text) + Convert.ToDecimal(txtCs.Text) + Convert.ToDecimal(txtCiee.Text) + Convert.ToDecimal(txtAluguel.Text) + Convert.ToDecimal(txtEscritorio.Text), cbMes.Text, txtAno.Text);

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_escritorio WHERE escritorio_mes = @mes AND escritorio_ano = @ano AND NOT escritorio_id = @id", conexao);

                        pesquisar.Parameters.AddWithValue("@mes", escritorio.Mes);
                        pesquisar.Parameters.AddWithValue("@ano", escritorio.Ano);
                        pesquisar.Parameters.AddWithValue("@id", escritorio.Id);

                        conexao.Open();

                        SqlDataReader registros = pesquisar.ExecuteReader();

                        if (registros.HasRows)
                        {
                            MessageBox.Show("Já há um registro com esta data", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            registros.Close();
                            conexao.Close();
                        }
                        else
                        {
                            registros.Close();

                            SqlCommand pesquisar2 = new SqlCommand("SELECT * FROM tb_saldos WHERE escritorio_valor = @id;", conexao);

                            pesquisar2.Parameters.AddWithValue("@id", escritorio.Id);

                            SqlDataReader registros2 = pesquisar2.ExecuteReader();

                            if (registros2.HasRows)
                            {
                                MessageBox.Show("Um registro na tabela de saldos está fazendo uso desta informação. Apague-o para poder fazer uma alteração neste registro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                registros2.Close();
                                conexao.Close();
                            }
                            else
                            {
                                registros2.Close();

                                SqlCommand alterar = new SqlCommand("Update tb_escritorio SET escritorio_pis = @pis, escritorio_cofins = @cofins, escritorio_iss = @iss, escritorio_inss = @inss, escritorio_ir = @ir, escritorio_cs = @cs, escritorio_ciee = @ciee, escritorio_aluguel = @aluguel, escritorio_escritorio = @escritorio, escritorio_total = @total, escritorio_mes = @mes, escritorio_ano = @ano WHERE escritorio_id = @id;", conexao);

                                alterar.Parameters.AddWithValue("@pis", escritorio.Pis);
                                alterar.Parameters.AddWithValue("@cofins", escritorio.Cofins);
                                alterar.Parameters.AddWithValue("@iss", escritorio.Iss);
                                alterar.Parameters.AddWithValue("@inss", escritorio.Inss);
                                alterar.Parameters.AddWithValue("@ir", escritorio.Ir);
                                alterar.Parameters.AddWithValue("@cs", escritorio.Cs);
                                alterar.Parameters.AddWithValue("@ciee", escritorio.Ciee);
                                alterar.Parameters.AddWithValue("@aluguel", escritorio.Aluguel);
                                alterar.Parameters.AddWithValue("@escritorio", escritorio.Escritorio1);
                                alterar.Parameters.AddWithValue("@total", escritorio.Total);
                                alterar.Parameters.AddWithValue("@mes", escritorio.Mes);
                                alterar.Parameters.AddWithValue("@ano", escritorio.Ano);
                                alterar.Parameters.AddWithValue("@id", escritorio.Id);

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

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            var botao = MessageBox.Show("Confirmar a remoção do registro?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (botao == DialogResult.Yes)
            {
                SqlConnection conexao = null;

                try
                {
                    Escritorio escritorio = new Escritorio(Convert.ToInt32(txtId.Text));

                    conexao = new SqlConnection(StringConexao.stringConexao);

                    SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_saldos WHERE escritorio_valor = @id;", conexao);

                    pesquisar.Parameters.AddWithValue("@id", escritorio.Id);

                    conexao.Open();

                    SqlDataReader registros = pesquisar.ExecuteReader();

                    if (registros.HasRows)
                    {
                        MessageBox.Show("Um registro na tabela de saldos está fazendo uso desta informação. Apague-o para poder remover este registro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        registros.Close();
                        conexao.Close();
                    }
                    else
                    {
                        registros.Close();

                        SqlCommand deletar = new SqlCommand("DELETE FROM tb_escritorio WHERE escritorio_id = @id", conexao);

                        deletar.Parameters.AddWithValue("@id", escritorio.Id);

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
