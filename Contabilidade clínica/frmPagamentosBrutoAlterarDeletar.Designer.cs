namespace Contabilidade_clínica
{
    partial class frmPagamentosBrutoAlterarDeletar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagamentosBrutoAlterarDeletar));
            this.cbPagamentosBrutoMembros = new System.Windows.Forms.ComboBox();
            this.txtPagamentosBrutoNome = new System.Windows.Forms.Label();
            this.lblPagamentosBrutoValor = new System.Windows.Forms.Label();
            this.txtPagamentosBrutoValor = new System.Windows.Forms.TextBox();
            this.lblPagamentosBrutoMes = new System.Windows.Forms.Label();
            this.cbPagamentosBrutoMes = new System.Windows.Forms.ComboBox();
            this.txtPagamentosBrutoAno = new System.Windows.Forms.TextBox();
            this.lblPagamentosBrutoAno = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.txtContabilidadeAno = new System.Windows.Forms.TextBox();
            this.cbContabilidadeMes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbPagamentosBrutoMembros
            // 
            this.cbPagamentosBrutoMembros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPagamentosBrutoMembros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPagamentosBrutoMembros.FormattingEnabled = true;
            this.cbPagamentosBrutoMembros.Location = new System.Drawing.Point(28, 57);
            this.cbPagamentosBrutoMembros.Margin = new System.Windows.Forms.Padding(4);
            this.cbPagamentosBrutoMembros.Name = "cbPagamentosBrutoMembros";
            this.cbPagamentosBrutoMembros.Size = new System.Drawing.Size(181, 28);
            this.cbPagamentosBrutoMembros.TabIndex = 1;
            // 
            // txtPagamentosBrutoNome
            // 
            this.txtPagamentosBrutoNome.AutoSize = true;
            this.txtPagamentosBrutoNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagamentosBrutoNome.Location = new System.Drawing.Point(25, 24);
            this.txtPagamentosBrutoNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtPagamentosBrutoNome.Name = "txtPagamentosBrutoNome";
            this.txtPagamentosBrutoNome.Size = new System.Drawing.Size(58, 20);
            this.txtPagamentosBrutoNome.TabIndex = 4;
            this.txtPagamentosBrutoNome.Text = "Nome:";
            // 
            // lblPagamentosBrutoValor
            // 
            this.lblPagamentosBrutoValor.AutoSize = true;
            this.lblPagamentosBrutoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagamentosBrutoValor.Location = new System.Drawing.Point(307, 24);
            this.lblPagamentosBrutoValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPagamentosBrutoValor.Name = "lblPagamentosBrutoValor";
            this.lblPagamentosBrutoValor.Size = new System.Drawing.Size(53, 20);
            this.lblPagamentosBrutoValor.TabIndex = 8;
            this.lblPagamentosBrutoValor.Text = "Valor:";
            // 
            // txtPagamentosBrutoValor
            // 
            this.txtPagamentosBrutoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagamentosBrutoValor.Location = new System.Drawing.Point(310, 59);
            this.txtPagamentosBrutoValor.Margin = new System.Windows.Forms.Padding(4);
            this.txtPagamentosBrutoValor.Name = "txtPagamentosBrutoValor";
            this.txtPagamentosBrutoValor.ShortcutsEnabled = false;
            this.txtPagamentosBrutoValor.Size = new System.Drawing.Size(72, 26);
            this.txtPagamentosBrutoValor.TabIndex = 9;
            this.txtPagamentosBrutoValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPagamentosBrutoValor_KeyPress);
            // 
            // lblPagamentosBrutoMes
            // 
            this.lblPagamentosBrutoMes.AutoSize = true;
            this.lblPagamentosBrutoMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagamentosBrutoMes.Location = new System.Drawing.Point(480, 24);
            this.lblPagamentosBrutoMes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPagamentosBrutoMes.Name = "lblPagamentosBrutoMes";
            this.lblPagamentosBrutoMes.Size = new System.Drawing.Size(46, 20);
            this.lblPagamentosBrutoMes.TabIndex = 10;
            this.lblPagamentosBrutoMes.Text = "Mês:";
            // 
            // cbPagamentosBrutoMes
            // 
            this.cbPagamentosBrutoMes.BackColor = System.Drawing.SystemColors.Window;
            this.cbPagamentosBrutoMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPagamentosBrutoMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPagamentosBrutoMes.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cbPagamentosBrutoMes.FormattingEnabled = true;
            this.cbPagamentosBrutoMes.Items.AddRange(new object[] {
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
            this.cbPagamentosBrutoMes.Location = new System.Drawing.Point(483, 57);
            this.cbPagamentosBrutoMes.Margin = new System.Windows.Forms.Padding(4);
            this.cbPagamentosBrutoMes.Name = "cbPagamentosBrutoMes";
            this.cbPagamentosBrutoMes.Size = new System.Drawing.Size(42, 28);
            this.cbPagamentosBrutoMes.TabIndex = 11;
            // 
            // txtPagamentosBrutoAno
            // 
            this.txtPagamentosBrutoAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagamentosBrutoAno.Location = new System.Drawing.Point(626, 57);
            this.txtPagamentosBrutoAno.Margin = new System.Windows.Forms.Padding(4);
            this.txtPagamentosBrutoAno.Name = "txtPagamentosBrutoAno";
            this.txtPagamentosBrutoAno.ShortcutsEnabled = false;
            this.txtPagamentosBrutoAno.Size = new System.Drawing.Size(55, 26);
            this.txtPagamentosBrutoAno.TabIndex = 12;
            this.txtPagamentosBrutoAno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPagamentosBrutoAno_KeyPress);
            // 
            // lblPagamentosBrutoAno
            // 
            this.lblPagamentosBrutoAno.AutoSize = true;
            this.lblPagamentosBrutoAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagamentosBrutoAno.Location = new System.Drawing.Point(624, 24);
            this.lblPagamentosBrutoAno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPagamentosBrutoAno.Name = "lblPagamentosBrutoAno";
            this.lblPagamentosBrutoAno.Size = new System.Drawing.Size(43, 20);
            this.lblPagamentosBrutoAno.TabIndex = 13;
            this.lblPagamentosBrutoAno.Text = "Ano:";
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(28, 101);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(42, 26);
            this.txtId.TabIndex = 16;
            this.txtId.Visible = false;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(179, 129);
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
            this.btnExcluir.Location = new System.Drawing.Point(406, 129);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(110, 34);
            this.btnExcluir.TabIndex = 20;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // txtContabilidadeAno
            // 
            this.txtContabilidadeAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContabilidadeAno.Location = new System.Drawing.Point(154, 103);
            this.txtContabilidadeAno.Margin = new System.Windows.Forms.Padding(4);
            this.txtContabilidadeAno.Name = "txtContabilidadeAno";
            this.txtContabilidadeAno.ShortcutsEnabled = false;
            this.txtContabilidadeAno.Size = new System.Drawing.Size(55, 26);
            this.txtContabilidadeAno.TabIndex = 28;
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
            this.cbContabilidadeMes.Location = new System.Drawing.Point(91, 101);
            this.cbContabilidadeMes.Margin = new System.Windows.Forms.Padding(4);
            this.cbContabilidadeMes.Name = "cbContabilidadeMes";
            this.cbContabilidadeMes.Size = new System.Drawing.Size(43, 28);
            this.cbContabilidadeMes.TabIndex = 27;
            this.cbContabilidadeMes.Visible = false;
            // 
            // frmPagamentosBrutoAlterarDeletar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 185);
            this.Controls.Add(this.txtContabilidadeAno);
            this.Controls.Add(this.cbContabilidadeMes);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblPagamentosBrutoAno);
            this.Controls.Add(this.txtPagamentosBrutoAno);
            this.Controls.Add(this.cbPagamentosBrutoMes);
            this.Controls.Add(this.lblPagamentosBrutoMes);
            this.Controls.Add(this.txtPagamentosBrutoValor);
            this.Controls.Add(this.lblPagamentosBrutoValor);
            this.Controls.Add(this.txtPagamentosBrutoNome);
            this.Controls.Add(this.cbPagamentosBrutoMembros);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPagamentosBrutoAlterarDeletar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagamentos - Valor bruto - Alterar/excluir";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPagamentosBrutoAlterarDeletar_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPagamentosBrutoMembros;
        private System.Windows.Forms.Label txtPagamentosBrutoNome;
        private System.Windows.Forms.Label lblPagamentosBrutoValor;
        private System.Windows.Forms.TextBox txtPagamentosBrutoValor;
        private System.Windows.Forms.Label lblPagamentosBrutoMes;
        private System.Windows.Forms.ComboBox cbPagamentosBrutoMes;
        private System.Windows.Forms.TextBox txtPagamentosBrutoAno;
        private System.Windows.Forms.Label lblPagamentosBrutoAno;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.TextBox txtContabilidadeAno;
        private System.Windows.Forms.ComboBox cbContabilidadeMes;
    }
}