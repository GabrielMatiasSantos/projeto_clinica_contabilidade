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

namespace Contabilidade_clínica
{
    public partial class frmMembrosAlterarDeletar: Form
    {
        public frmMembrosAlterarDeletar(string nome, string funcao, string relacao, string situacao, string id)
        {
            InitializeComponent();

            txtNome.Text = nome;
            cbFuncao.Text = funcao;            
            cbRelacao.Text = relacao;
            cbSituacao.Text = situacao;
            txtId.Text = id;
        }
        
        public string Mes
        {
            set {cbContabilidadeMes.Text = value;}
        }

        public string Ano
        {
            set { txtContabilidadeAno.Text = value; }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNome.Text == "")
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
            if (txtNome.Text == "" || cbFuncao.Text == ""|| cbRelacao.Text == "" || cbSituacao.Text == "")
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
                        Membros membros = new Membros(txtNome.Text, cbFuncao.Text, cbRelacao.Text, cbSituacao.Text, Convert.ToInt32(txtId.Text));

                        conexao = new SqlConnection(StringConexao.stringConexao);

                        SqlCommand pesquisar = new SqlCommand("SELECT membro_nome FROM tb_membros WHERE membro_nome = @nome AND NOT membro_id = @id", conexao);

                        pesquisar.Parameters.AddWithValue("@nome", membros.Nome);
                        pesquisar.Parameters.AddWithValue("@id", membros.Id);

                        conexao.Open();

                        SqlDataReader registros = pesquisar.ExecuteReader();

                        if (registros.HasRows)
                        {
                            MessageBox.Show("Já há um registro com este nome", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            registros.Close();
                            conexao.Close();
                        }
                        else
                        {
                            registros.Close();

                            SqlCommand alterar = new SqlCommand("UPDATE tb_membros SET membro_nome = @nome, membro_funcao = @funcao, membro_relacao_clinica = @relacao, membro_situacao = @situacao WHERE membro_id = @id;", conexao);

                            alterar.Parameters.AddWithValue("@nome", membros.Nome);
                            alterar.Parameters.AddWithValue("@funcao", membros.Funcao);                            
                            alterar.Parameters.AddWithValue("@relacao", membros.Relacao);
                            alterar.Parameters.AddWithValue("@situacao", membros.Situacao);
                            alterar.Parameters.AddWithValue("@id", membros.Id);

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

        private void frmMembrosAlterarDeletar_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmContabilidade contabilidade = new frmContabilidade();

            contabilidade.AbrirAba = 0;

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
                    Membros membros = new Membros(Convert.ToInt32(txtId.Text));

                    conexao = new SqlConnection(StringConexao.stringConexao);

                    SqlCommand pesquisar = new SqlCommand("SELECT * FROM tb_pagamentos_valor_bruto WHERE pagamento_bruto_membro = @id;", conexao);

                    pesquisar.Parameters.AddWithValue("@id", membros.Id);

                    conexao.Open();

                    SqlDataReader registros = pesquisar.ExecuteReader();

                    if (registros.HasRows)
                    {
                        MessageBox.Show("Pelo menos um registro na tabela de pagamentos (valor bruto) está fazendo uso destas informações. Apague-os para remover este registro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        registros.Close();
                        conexao.Close();
                    }
                    else
                    {
                        registros.Close();

                        SqlCommand deletar = new SqlCommand("DELETE FROM tb_membros WHERE membro_id = @id", conexao);

                        deletar.Parameters.AddWithValue("@id", membros.Id);

                        deletar.ExecuteNonQuery();

                        conexao.Close();

                        MessageBox.Show("Remoção feita com sucesso", "Operação bem sucedida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }                   
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
    }
}
