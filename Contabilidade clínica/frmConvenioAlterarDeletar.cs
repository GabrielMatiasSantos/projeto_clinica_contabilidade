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
    public partial class frmConvenioAlterarDeletar: Form
    {
        public frmConvenioAlterarDeletar(string convenio, string id)
        {
            InitializeComponent();

            txtConvenio.Text = convenio;
            txtId.Text = id;
        }        

        public string Mes
        {
            set { cbContabilidadeMes.Text = value; }
        }

        public string Ano
        {
            set { txtContabilidadeAno.Text = value; }
        }


        private void frmConvenioAlterarDeletar_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmContabilidade contabilidade = new frmContabilidade();

            contabilidade.AbrirAba = 7;

            if (cbContabilidadeMes.Text != "" && txtContabilidadeAno.Text != "")
            {
                contabilidade.Mes = cbContabilidadeMes.Text;
                contabilidade.Ano = txtContabilidadeAno.Text;
            }

            contabilidade.Show();
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {           
            if (txtConvenio.Text == "")
            {
                 MessageBox.Show("Informe o nome de um convênio", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var botao = MessageBox.Show("Confirmar a inserção de dados?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (botao == DialogResult.Yes)
                {
                    SqlConnection conexao = null;

                    try
                    {
                        Convenio convenio = new Convenio(Convert.ToInt32(txtId.Text), txtConvenio.Text);

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_convenios WHERE convenio_nome = @convenio AND NOT convenio_id = @id;", conexao);

                        pesquisar.Parameters.AddWithValue("@convenio", convenio.Convenio1);
                        pesquisar.Parameters.AddWithValue("@id", convenio.Id);

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

                            SqlCommand alterar = new SqlCommand("UPDATE tb_convenios SET convenio_nome = @convenio WHERE convenio_id = @id", conexao);

                            alterar.Parameters.AddWithValue("@convenio", convenio.Convenio1);
                            alterar.Parameters.AddWithValue("@id", convenio.Id);

                             alterar.ExecuteNonQuery();

                             conexao.Close();

                             MessageBox.Show("Inserção feita com sucesso", "Operação bem sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                    SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_convenios_valores WHERE convenio = @id;", conexao);

                    pesquisar.Parameters.AddWithValue("@id", convenio.Id);

                    conexao.Open();

                    SqlDataReader registros = pesquisar.ExecuteReader();

                    if (registros.HasRows)
                    {
                        MessageBox.Show("Pelo menos um registro na tabela de valores pagos pelos convênios está fazendo uso desta informação. Apague-os para poder remover este registro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        registros.Close();
                        conexao.Close();
                    }
                    else
                    {
                        registros.Close();

                        SqlCommand deletar = new SqlCommand("DELETE FROM tb_convenios WHERE convenio_id = @id", conexao);

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
