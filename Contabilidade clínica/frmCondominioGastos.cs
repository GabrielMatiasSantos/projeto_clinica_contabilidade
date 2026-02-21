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
    public partial class frmCondominioGastos: Form
    {
        public frmCondominioGastos()
        {
            InitializeComponent();
        }

        public frmCondominioGastos(string cpfl, string sanebavi, string vivo, string correio, string aguaParaBeber, string copos, string papelHigienico, string papelToalha, string cafe, string acucar, string produtosLimpeza, string faxina, string recargaCelular, string outros, string mes, string ano, string id)
        {
            InitializeComponent();

            txtCpfl.Text = cpfl;
            txtSanebavi.Text = sanebavi;
            txtVivo.Text = vivo;
            txtCorreio.Text = correio;
            txtAguaParaBeber.Text = aguaParaBeber;
            txtCopos.Text = copos;
            txtPapelHigienico.Text = papelHigienico;
            txtPapelToalha.Text = papelToalha;
            txtCafe.Text = cafe;
            txtAcucar.Text = acucar;
            txtProdutosLimpeza.Text = produtosLimpeza;
            txtFaxina.Text = faxina;
            txtRecargaCelular.Text = recargaCelular;
            txtOutros.Text = outros;
            cbMes.Text = mes;
            txtAno.Text = ano;
            txtId.Text = id;
        }        

        public bool Salvar
        {
            set {btnSalvar.Visible = value;}
        }

        public bool Alterar
        {
            set {btnAlterar.Visible = value;}
        }

        public bool Deletar
        {
            set {btnDeletar.Visible = false;}
        }

        public string Texto
        {
            set {this.Text = value;}
        }

        public string Mes
        {
            set {cbMes.Text = value;}
        }

        public string Ano
        {
            set {txtAno.Text = value;}
        }

        public string MesContabilidade
        {
            set { cbContabilidadeMes.Text = value; }
        }

        public string AnoContabilidade
        {
            set { txtContabilidadeAno.Text = value; }
        }


        private void txtCpfl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCpfl.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtCpfl.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtCpfl.Text.Substring(txtCpfl.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtCpfl.Text == "0")
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

        private void txtSanebavi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSanebavi.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtSanebavi.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtSanebavi.Text.Substring(txtSanebavi.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtSanebavi.Text == "0")
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

        private void txtVivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtVivo.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtVivo.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtVivo.Text.Substring(txtVivo.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtVivo.Text == "0")
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

        private void txtCorreio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCorreio.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtCorreio.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtCorreio.Text.Substring(txtCorreio.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtCorreio.Text == "0")
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

        private void txtAguaParaBeber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAguaParaBeber.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtAguaParaBeber.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtAguaParaBeber.Text.Substring(txtAguaParaBeber.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtAguaParaBeber.Text == "0")
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

        private void txtCopos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCopos.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtCopos.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtCopos.Text.Substring(txtCopos.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtCopos.Text == "0")
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

        private void txtPapelHigienico_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPapelHigienico.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtPapelHigienico.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtPapelHigienico.Text.Substring(txtPapelHigienico.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtPapelHigienico.Text == "0")
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

        private void txtPapelToalha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPapelToalha.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtPapelToalha.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtPapelToalha.Text.Substring(txtPapelToalha.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtPapelToalha.Text == "0")
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

        private void txtCafe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtCafe.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtCafe.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtCafe.Text.Substring(txtCafe.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtCafe.Text == "0")
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

        private void txtAcucar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAcucar.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtAcucar.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtAcucar.Text.Substring(txtAcucar.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtAcucar.Text == "0")
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

        private void txtProdutosLimpeza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtProdutosLimpeza.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtProdutosLimpeza.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtProdutosLimpeza.Text.Substring(txtProdutosLimpeza.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtProdutosLimpeza.Text == "0")
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

        private void txtFaxina_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtFaxina.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtFaxina.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtFaxina.Text.Substring(txtFaxina.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtFaxina.Text == "0")
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

        private void txtRecargaCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtRecargaCelular.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtRecargaCelular.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtRecargaCelular.Text.Substring(txtRecargaCelular.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtRecargaCelular.Text == "0")
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

        private void txtOutros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtOutros.Text == "")
            {
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (txtOutros.Text.Contains(','))
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }

                if (txtOutros.Text.Substring(txtOutros.Text.IndexOf(',')).Length == 3)
                {
                    if (e.KeyChar != 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            else if (txtOutros.Text == "0")
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

        private void frmCondominioGastos_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmContabilidade contabilidade = new frmContabilidade();

            if (cbContabilidadeMes.Text != "" && txtContabilidadeAno.Text != "")
            {
                contabilidade.Mes = cbContabilidadeMes.Text;
                contabilidade.Ano = txtContabilidadeAno.Text;
            }

            contabilidade.AbrirAba = 3;     
            contabilidade.Show();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtCpfl.Text == "" || txtSanebavi.Text == "" || txtVivo.Text == "" || txtCorreio.Text == "" || txtAguaParaBeber.Text == "" || txtCopos.Text == "" || txtPapelHigienico.Text == "" || txtPapelToalha.Text == "" || txtCafe.Text == "" || txtAcucar.Text == "" || txtProdutosLimpeza.Text == "" || txtFaxina.Text == "" || txtRecargaCelular.Text == "" || txtOutros.Text == "" || cbMes.Text == "" || txtAno.Text == "")
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
                        CondominioGastos condominio = new CondominioGastos(Convert.ToDecimal(txtCpfl.Text), Convert.ToDecimal(txtSanebavi.Text), Convert.ToDecimal(txtVivo.Text), Convert.ToDecimal(txtCorreio.Text), Convert.ToDecimal(txtAguaParaBeber.Text), Convert.ToDecimal(txtCopos.Text), Convert.ToDecimal(txtPapelHigienico.Text), Convert.ToDecimal(txtPapelToalha.Text), Convert.ToDecimal(txtCafe.Text), Convert.ToDecimal(txtAcucar.Text), Convert.ToDecimal(txtProdutosLimpeza.Text), Convert.ToDecimal(txtFaxina.Text), Convert.ToDecimal(txtRecargaCelular.Text), Convert.ToDecimal(txtOutros.Text), Convert.ToDecimal(txtCpfl.Text) + Convert.ToDecimal(txtSanebavi.Text) + Convert.ToDecimal(txtVivo.Text) + Convert.ToDecimal(txtCorreio.Text) + Convert.ToDecimal(txtAguaParaBeber.Text) + Convert.ToDecimal(txtCopos.Text) + Convert.ToDecimal(txtPapelHigienico.Text) + Convert.ToDecimal(txtPapelToalha.Text) + Convert.ToDecimal(txtCafe.Text) + Convert.ToDecimal(txtAcucar.Text) + Convert.ToDecimal(txtProdutosLimpeza.Text) + Convert.ToDecimal(txtFaxina.Text) + Convert.ToDecimal(txtRecargaCelular.Text) + Convert.ToDecimal(txtOutros.Text), cbMes.Text, txtAno.Text);

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_condominio WHERE condominio_mes = @mes AND condominio_ano = @ano;", conexao);

                        pesquisar.Parameters.AddWithValue("@mes", condominio.Mes);
                        pesquisar.Parameters.AddWithValue("@ano", condominio.Ano);

                        conexao.Open();

                        SqlDataReader registros = pesquisar.ExecuteReader();

                        if (registros.HasRows)
                        {
                            MessageBox.Show("Os gastos de condomínio deste mês e ano já foram informados", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            registros.Close();
                            conexao.Close();
                        }
                        else
                        {
                            registros.Close();

                            SqlCommand inserir = new SqlCommand("INSERT INTO tb_condominio VALUES(@cpfl, @sanebavi, @vivo, @correio, @aguaBeber, @copos, @papelHigienico, @papelToalha, @cafe, @acucar, @produtosLimpeza, @faxina, @recargaCelular, @outros, @total, @mes, @ano);", conexao);

                            inserir.Parameters.AddWithValue("@cpfl", condominio.Cpfl);
                            inserir.Parameters.AddWithValue("@sanebavi", condominio.Sanebavi);
                            inserir.Parameters.AddWithValue("@vivo", condominio.Vivo);
                            inserir.Parameters.AddWithValue("@correio", condominio.Correio);
                            inserir.Parameters.AddWithValue("@aguaBeber", condominio.AguaBeber);
                            inserir.Parameters.AddWithValue("@copos", condominio.Copos);
                            inserir.Parameters.AddWithValue("@papelHigienico", condominio.PapelHigienico);
                            inserir.Parameters.AddWithValue("@papelToalha", condominio.PapelToalha);
                            inserir.Parameters.AddWithValue("@cafe", condominio.Cafe);
                            inserir.Parameters.AddWithValue("@acucar", condominio.Acucar);
                            inserir.Parameters.AddWithValue("@produtosLimpeza", condominio.ProdutosLimpeza);
                            inserir.Parameters.AddWithValue("@faxina", condominio.Faxina);
                            inserir.Parameters.AddWithValue("@recargaCelular", condominio.RecargaCelular);
                            inserir.Parameters.AddWithValue("@outros", condominio.Outros);
                            inserir.Parameters.AddWithValue("@total", condominio.Total);
                            inserir.Parameters.AddWithValue("@mes", condominio.Mes);
                            inserir.Parameters.AddWithValue("@ano", condominio.Ano);

                            inserir.ExecuteNonQuery();

                            conexao.Close();

                            MessageBox.Show("Novo gasto mensal de condomínio inserido com sucesso", "Operação bem sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            if (txtCpfl.Text == "" || txtSanebavi.Text == "" || txtVivo.Text == "" || txtCorreio.Text == "" || txtAguaParaBeber.Text == "" || txtCopos.Text == "" || txtPapelHigienico.Text == "" || txtPapelToalha.Text == "" || txtCafe.Text == "" || txtAcucar.Text == "" || txtProdutosLimpeza.Text == "" || txtFaxina.Text == "" || txtRecargaCelular.Text == "" || txtOutros.Text == "" || cbMes.Text == "" || txtAno.Text == "")
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
                        CondominioGastos condominio = new CondominioGastos(Convert.ToInt32(txtId.Text), Convert.ToDecimal(txtCpfl.Text), Convert.ToDecimal(txtSanebavi.Text), Convert.ToDecimal(txtVivo.Text), Convert.ToDecimal(txtCorreio.Text), Convert.ToDecimal(txtAguaParaBeber.Text), Convert.ToDecimal(txtCopos.Text), Convert.ToDecimal(txtPapelHigienico.Text), Convert.ToDecimal(txtPapelToalha.Text), Convert.ToDecimal(txtCafe.Text), Convert.ToDecimal(txtAcucar.Text), Convert.ToDecimal(txtProdutosLimpeza.Text), Convert.ToDecimal(txtFaxina.Text), Convert.ToDecimal(txtRecargaCelular.Text), Convert.ToDecimal(txtOutros.Text), Convert.ToDecimal(txtCpfl.Text) + Convert.ToDecimal(txtSanebavi.Text) + Convert.ToDecimal(txtVivo.Text) + Convert.ToDecimal(txtCorreio.Text) + Convert.ToDecimal(txtAguaParaBeber.Text) + Convert.ToDecimal(txtCopos.Text) + Convert.ToDecimal(txtPapelHigienico.Text) + Convert.ToDecimal(txtPapelToalha.Text) + Convert.ToDecimal(txtCafe.Text) + Convert.ToDecimal(txtAcucar.Text) + Convert.ToDecimal(txtProdutosLimpeza.Text) + Convert.ToDecimal(txtFaxina.Text) + Convert.ToDecimal(txtRecargaCelular.Text) + Convert.ToDecimal(txtOutros.Text), cbMes.Text, txtAno.Text);

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_condominio WHERE condominio_mes = @mes AND condominio_ano = @ano AND NOT condominio_id = @id", conexao);

                        pesquisar.Parameters.AddWithValue("@mes", condominio.Mes);
                        pesquisar.Parameters.AddWithValue("@ano", condominio.Ano);
                        pesquisar.Parameters.AddWithValue("@id", condominio.Id);

                        conexao.Open();

                        SqlDataReader registros = pesquisar.ExecuteReader();

                        if (registros.HasRows)
                        {
                            MessageBox.Show("Os gastos de condomínio deste mês e ano já foram informados", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            registros.Close();
                            conexao.Close();
                        }
                        else
                        {
                            registros.Close();

                            SqlCommand pesquisar2 = new SqlCommand("SELECT * FROM tb_condominio_hora_valor WHERE condominio_total = @id;", conexao);

                            pesquisar2.Parameters.AddWithValue("@id", condominio.Id);

                            SqlDataReader registros2 = pesquisar2.ExecuteReader();

                            if (registros2.HasRows)
                            {
                                MessageBox.Show("Registros na tabela de valores de condomínio dos membros da clínica estão fazendo uso destas informações. Apague-os para poder fazer uma alteração neste registro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                registros2.Close();
                                conexao.Close();
                            }
                            else
                            {
                                registros2.Close();

                                SqlCommand alterar = new SqlCommand("UPDATE tb_condominio SET condominio_cpfl = @cpfl, condominio_sanebavi = @sanebavi, condominio_vivo = @vivo, condominio_correio = @correio, condominio_agua_para_beber = @aguaBeber, condominio_copos = @copos, condominio_papel_higienico = @papelHigienico, condominio_papel_toalha = @papelToalha, condominio_cafe = @cafe, condominio_acucar = @acucar, condominio_produtos_limpeza = @produtosLimpeza, condominio_faxina = @faxina, condominio_recarga_celular = @recargaCelular, condominio_outros = @outros, condominio_valor_total = @total, condominio_mes = @mes, condominio_ano = @ano WHERE condominio_id = @id;", conexao);

                                alterar.Parameters.AddWithValue("@cpfl", condominio.Cpfl);
                                alterar.Parameters.AddWithValue("@sanebavi", condominio.Sanebavi);
                                alterar.Parameters.AddWithValue("@vivo", condominio.Vivo);
                                alterar.Parameters.AddWithValue("@correio", condominio.Correio);
                                alterar.Parameters.AddWithValue("@aguaBeber", condominio.AguaBeber);
                                alterar.Parameters.AddWithValue("@copos", condominio.Copos);
                                alterar.Parameters.AddWithValue("@papelHigienico", condominio.PapelHigienico);
                                alterar.Parameters.AddWithValue("@papelToalha", condominio.PapelToalha);
                                alterar.Parameters.AddWithValue("@cafe", condominio.Cafe);
                                alterar.Parameters.AddWithValue("@acucar", condominio.Acucar);
                                alterar.Parameters.AddWithValue("@produtosLimpeza", condominio.ProdutosLimpeza);
                                alterar.Parameters.AddWithValue("@faxina", condominio.Faxina);
                                alterar.Parameters.AddWithValue("@recargaCelular", condominio.RecargaCelular);
                                alterar.Parameters.AddWithValue("@outros", condominio.Outros);
                                alterar.Parameters.AddWithValue("@total", condominio.Total);
                                alterar.Parameters.AddWithValue("@mes", condominio.Mes);
                                alterar.Parameters.AddWithValue("@ano", condominio.Ano);
                                alterar.Parameters.AddWithValue("@id", condominio.Id);

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
                    CondominioGastos condominio = new CondominioGastos(Convert.ToInt32(txtId.Text));

                    conexao = new SqlConnection(StringConexao.stringConexao);

                    SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_condominio_hora_valor WHERE condominio_total = @id;", conexao);

                    pesquisar.Parameters.AddWithValue("@id", condominio.Id);

                    conexao.Open();

                    SqlDataReader registros = pesquisar.ExecuteReader();

                    if (registros.HasRows)
                    {
                        MessageBox.Show("Registros na tabela de valores de condomínio dos membros da clínica estão fazendo uso destas informações. Apague-os para poder remover este registro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        registros.Close();
                        conexao.Close();
                    }
                    else
                    {
                        registros.Close();

                        SqlCommand deletar = new SqlCommand("DELETE FROM tb_condominio WHERE condominio_id = @id", conexao);

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
