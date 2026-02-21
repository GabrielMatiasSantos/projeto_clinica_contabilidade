namespace Contabilidade_clínica
{
    partial class frmMembrosAlterarDeletar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMembrosAlterarDeletar));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.cbSituacao = new System.Windows.Forms.ComboBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblSitucao = new System.Windows.Forms.Label();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.lblVinculo = new System.Windows.Forms.Label();
            this.cbRelacao = new System.Windows.Forms.ComboBox();
            this.lblFuncao = new System.Windows.Forms.Label();
            this.cbFuncao = new System.Windows.Forms.ComboBox();
            this.txtContabilidadeAno = new System.Windows.Forms.TextBox();
            this.cbContabilidadeMes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(24, 53);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(210, 26);
            this.txtNome.TabIndex = 2;
            this.txtNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNome_KeyPress);
            // 
            // cbSituacao
            // 
            this.cbSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSituacao.FormattingEnabled = true;
            this.cbSituacao.Items.AddRange(new object[] {
            "Ativa",
            "Inativa"});
            this.cbSituacao.Location = new System.Drawing.Point(709, 51);
            this.cbSituacao.Margin = new System.Windows.Forms.Padding(4);
            this.cbSituacao.Name = "cbSituacao";
            this.cbSituacao.Size = new System.Drawing.Size(74, 28);
            this.cbSituacao.TabIndex = 9;
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(26, 98);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(43, 26);
            this.txtId.TabIndex = 10;
            this.txtId.Visible = false;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(21, 19);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(58, 20);
            this.lblNome.TabIndex = 11;
            this.lblNome.Text = "Nome:";
            // 
            // lblSitucao
            // 
            this.lblSitucao.AutoSize = true;
            this.lblSitucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSitucao.Location = new System.Drawing.Point(707, 19);
            this.lblSitucao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSitucao.Name = "lblSitucao";
            this.lblSitucao.Size = new System.Drawing.Size(79, 20);
            this.lblSitucao.TabIndex = 13;
            this.lblSitucao.Text = "Situação:";
            // 
            // btnAlterar
            // 
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(213, 150);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(110, 34);
            this.btnAlterar.TabIndex = 19;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(456, 150);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(110, 34);
            this.btnExcluir.TabIndex = 20;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // lblVinculo
            // 
            this.lblVinculo.AutoSize = true;
            this.lblVinculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVinculo.Location = new System.Drawing.Point(521, 17);
            this.lblVinculo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVinculo.Name = "lblVinculo";
            this.lblVinculo.Size = new System.Drawing.Size(120, 40);
            this.lblVinculo.TabIndex = 24;
            this.lblVinculo.Text = "Vínculo com a \r\nclínica:";
            // 
            // cbRelacao
            // 
            this.cbRelacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRelacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRelacao.FormattingEnabled = true;
            this.cbRelacao.Items.AddRange(new object[] {
            "Sócio",
            "Não sócio"});
            this.cbRelacao.Location = new System.Drawing.Point(524, 53);
            this.cbRelacao.Margin = new System.Windows.Forms.Padding(4);
            this.cbRelacao.Name = "cbRelacao";
            this.cbRelacao.Size = new System.Drawing.Size(86, 28);
            this.cbRelacao.TabIndex = 23;
            // 
            // lblFuncao
            // 
            this.lblFuncao.AutoSize = true;
            this.lblFuncao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuncao.Location = new System.Drawing.Point(330, 17);
            this.lblFuncao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFuncao.Name = "lblFuncao";
            this.lblFuncao.Size = new System.Drawing.Size(145, 20);
            this.lblFuncao.TabIndex = 22;
            this.lblFuncao.Text = "Função na clínica:";
            // 
            // cbFuncao
            // 
            this.cbFuncao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuncao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFuncao.FormattingEnabled = true;
            this.cbFuncao.Items.AddRange(new object[] {
            "Psiquiatria ",
            "Psicologia",
            "Secretaria"});
            this.cbFuncao.Location = new System.Drawing.Point(333, 53);
            this.cbFuncao.Margin = new System.Windows.Forms.Padding(4);
            this.cbFuncao.Name = "cbFuncao";
            this.cbFuncao.Size = new System.Drawing.Size(92, 28);
            this.cbFuncao.TabIndex = 21;
            // 
            // txtContabilidadeAno
            // 
            this.txtContabilidadeAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContabilidadeAno.Location = new System.Drawing.Point(179, 100);
            this.txtContabilidadeAno.Margin = new System.Windows.Forms.Padding(4);
            this.txtContabilidadeAno.Name = "txtContabilidadeAno";
            this.txtContabilidadeAno.ShortcutsEnabled = false;
            this.txtContabilidadeAno.Size = new System.Drawing.Size(55, 26);
            this.txtContabilidadeAno.TabIndex = 26;
            this.txtContabilidadeAno.Visible = false;
            // 
            // cbContabilidadeMes
            // 
            this.cbContabilidadeMes.BackColor = System.Drawing.SystemColors.Window;
            this.cbContabilidadeMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbContabilidadeMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbContabilidadeMes.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cbContabilidadeMes.FormattingEnabled = true;
            this.cbContabilidadeMes.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cbContabilidadeMes.Location = new System.Drawing.Point(106, 98);
            this.cbContabilidadeMes.Margin = new System.Windows.Forms.Padding(4);
            this.cbContabilidadeMes.Name = "cbContabilidadeMes";
            this.cbContabilidadeMes.Size = new System.Drawing.Size(43, 28);
            this.cbContabilidadeMes.TabIndex = 25;
            this.cbContabilidadeMes.Visible = false;
            // 
            // frmMembrosAlterarDeletar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 207);
            this.Controls.Add(this.txtContabilidadeAno);
            this.Controls.Add(this.cbContabilidadeMes);
            this.Controls.Add(this.lblVinculo);
            this.Controls.Add(this.cbRelacao);
            this.Controls.Add(this.lblFuncao);
            this.Controls.Add(this.cbFuncao);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.lblSitucao);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.cbSituacao);
            this.Controls.Add(this.txtNome);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMembrosAlterarDeletar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Membros da clínica - Alterar/excluir";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMembrosAlterarDeletar_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.ComboBox cbSituacao;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblSitucao;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Label lblVinculo;
        private System.Windows.Forms.ComboBox cbRelacao;
        private System.Windows.Forms.Label lblFuncao;
        private System.Windows.Forms.ComboBox cbFuncao;
        private System.Windows.Forms.TextBox txtContabilidadeAno;
        private System.Windows.Forms.ComboBox cbContabilidadeMes;
    }
}