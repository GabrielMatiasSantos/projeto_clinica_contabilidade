namespace Contabilidade_clínica
{
    partial class frmImpostoAlterarDeletar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImpostoAlterarDeletar));
            this.txtContabilidadeAno = new System.Windows.Forms.TextBox();
            this.cbContabilidadeMes = new System.Windows.Forms.ComboBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblImpostoTaxa = new System.Windows.Forms.Label();
            this.lblImpostoNome = new System.Windows.Forms.Label();
            this.lblImpostoAno = new System.Windows.Forms.Label();
            this.lblImpostoMes = new System.Windows.Forms.Label();
            this.txtImpostoTaxa = new System.Windows.Forms.TextBox();
            this.cbImpostoNome = new System.Windows.Forms.ComboBox();
            this.txtImpostoAno = new System.Windows.Forms.TextBox();
            this.cbImpostoMes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtContabilidadeAno
            // 
            this.txtContabilidadeAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContabilidadeAno.Location = new System.Drawing.Point(256, 92);
            this.txtContabilidadeAno.Margin = new System.Windows.Forms.Padding(4);
            this.txtContabilidadeAno.Name = "txtContabilidadeAno";
            this.txtContabilidadeAno.ShortcutsEnabled = false;
            this.txtContabilidadeAno.Size = new System.Drawing.Size(55, 26);
            this.txtContabilidadeAno.TabIndex = 41;
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
            this.cbContabilidadeMes.Location = new System.Drawing.Point(183, 90);
            this.cbContabilidadeMes.Margin = new System.Windows.Forms.Padding(4);
            this.cbContabilidadeMes.Name = "cbContabilidadeMes";
            this.cbContabilidadeMes.Size = new System.Drawing.Size(43, 28);
            this.cbContabilidadeMes.TabIndex = 40;
            this.cbContabilidadeMes.Visible = false;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(417, 126);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(110, 34);
            this.btnExcluir.TabIndex = 39;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click_1);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(183, 126);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(110, 34);
            this.btnAlterar.TabIndex = 38;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click_1);
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(31, 91);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(42, 27);
            this.txtId.TabIndex = 37;
            this.txtId.Visible = false;
            // 
            // lblImpostoTaxa
            // 
            this.lblImpostoTaxa.AutoSize = true;
            this.lblImpostoTaxa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImpostoTaxa.Location = new System.Drawing.Point(634, 19);
            this.lblImpostoTaxa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImpostoTaxa.Name = "lblImpostoTaxa";
            this.lblImpostoTaxa.Size = new System.Drawing.Size(82, 20);
            this.lblImpostoTaxa.TabIndex = 36;
            this.lblImpostoTaxa.Text = "Taxa (%):";
            // 
            // lblImpostoNome
            // 
            this.lblImpostoNome.AutoSize = true;
            this.lblImpostoNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImpostoNome.Location = new System.Drawing.Point(345, 19);
            this.lblImpostoNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImpostoNome.Name = "lblImpostoNome";
            this.lblImpostoNome.Size = new System.Drawing.Size(58, 20);
            this.lblImpostoNome.TabIndex = 35;
            this.lblImpostoNome.Text = "Nome:";
            // 
            // lblImpostoAno
            // 
            this.lblImpostoAno.AutoSize = true;
            this.lblImpostoAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImpostoAno.Location = new System.Drawing.Point(180, 19);
            this.lblImpostoAno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImpostoAno.Name = "lblImpostoAno";
            this.lblImpostoAno.Size = new System.Drawing.Size(43, 20);
            this.lblImpostoAno.TabIndex = 34;
            this.lblImpostoAno.Text = "Ano:";
            // 
            // lblImpostoMes
            // 
            this.lblImpostoMes.AutoSize = true;
            this.lblImpostoMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImpostoMes.Location = new System.Drawing.Point(28, 19);
            this.lblImpostoMes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblImpostoMes.Name = "lblImpostoMes";
            this.lblImpostoMes.Size = new System.Drawing.Size(46, 20);
            this.lblImpostoMes.TabIndex = 33;
            this.lblImpostoMes.Text = "Mês:";
            // 
            // txtImpostoTaxa
            // 
            this.txtImpostoTaxa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImpostoTaxa.Location = new System.Drawing.Point(637, 48);
            this.txtImpostoTaxa.Margin = new System.Windows.Forms.Padding(4);
            this.txtImpostoTaxa.Name = "txtImpostoTaxa";
            this.txtImpostoTaxa.ShortcutsEnabled = false;
            this.txtImpostoTaxa.Size = new System.Drawing.Size(59, 26);
            this.txtImpostoTaxa.TabIndex = 32;
            this.txtImpostoTaxa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImpostoTaxa_KeyPress_1);
            // 
            // cbImpostoNome
            // 
            this.cbImpostoNome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImpostoNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbImpostoNome.FormattingEnabled = true;
            this.cbImpostoNome.Location = new System.Drawing.Point(348, 50);
            this.cbImpostoNome.Margin = new System.Windows.Forms.Padding(4);
            this.cbImpostoNome.Name = "cbImpostoNome";
            this.cbImpostoNome.Size = new System.Drawing.Size(179, 28);
            this.cbImpostoNome.TabIndex = 31;
            this.cbImpostoNome.DropDown += new System.EventHandler(this.cbImpostoNome_DropDown_1);
            // 
            // txtImpostoAno
            // 
            this.txtImpostoAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImpostoAno.Location = new System.Drawing.Point(183, 48);
            this.txtImpostoAno.Margin = new System.Windows.Forms.Padding(4);
            this.txtImpostoAno.Name = "txtImpostoAno";
            this.txtImpostoAno.ShortcutsEnabled = false;
            this.txtImpostoAno.Size = new System.Drawing.Size(55, 26);
            this.txtImpostoAno.TabIndex = 30;
            this.txtImpostoAno.TextChanged += new System.EventHandler(this.txtImpostoAno_TextChanged_1);
            this.txtImpostoAno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImpostoAno_KeyPress_1);
            // 
            // cbImpostoMes
            // 
            this.cbImpostoMes.BackColor = System.Drawing.SystemColors.Window;
            this.cbImpostoMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImpostoMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbImpostoMes.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cbImpostoMes.FormattingEnabled = true;
            this.cbImpostoMes.Items.AddRange(new object[] {
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
            this.cbImpostoMes.Location = new System.Drawing.Point(31, 46);
            this.cbImpostoMes.Margin = new System.Windows.Forms.Padding(4);
            this.cbImpostoMes.Name = "cbImpostoMes";
            this.cbImpostoMes.Size = new System.Drawing.Size(42, 28);
            this.cbImpostoMes.TabIndex = 29;
            this.cbImpostoMes.SelectedIndexChanged += new System.EventHandler(this.cbImpostoMes_SelectedIndexChanged_1);
            // 
            // frmImpostoAlterarDeletar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 181);
            this.Controls.Add(this.txtContabilidadeAno);
            this.Controls.Add(this.cbContabilidadeMes);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblImpostoTaxa);
            this.Controls.Add(this.lblImpostoNome);
            this.Controls.Add(this.lblImpostoAno);
            this.Controls.Add(this.lblImpostoMes);
            this.Controls.Add(this.txtImpostoTaxa);
            this.Controls.Add(this.cbImpostoNome);
            this.Controls.Add(this.txtImpostoAno);
            this.Controls.Add(this.cbImpostoMes);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImpostoAlterarDeletar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imposto Alterar/excluir";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmImpostoAlterarDeletar_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContabilidadeAno;
        private System.Windows.Forms.ComboBox cbContabilidadeMes;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblImpostoTaxa;
        private System.Windows.Forms.Label lblImpostoNome;
        private System.Windows.Forms.Label lblImpostoAno;
        private System.Windows.Forms.Label lblImpostoMes;
        private System.Windows.Forms.TextBox txtImpostoTaxa;
        private System.Windows.Forms.ComboBox cbImpostoNome;
        private System.Windows.Forms.TextBox txtImpostoAno;
        private System.Windows.Forms.ComboBox cbImpostoMes;
    }
}