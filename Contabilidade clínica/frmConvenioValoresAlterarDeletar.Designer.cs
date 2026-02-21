namespace Contabilidade_clínica
{
    partial class frmConvenioValoresAlterarDeletar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConvenioValoresAlterarDeletar));
            this.lblConvenioAno = new System.Windows.Forms.Label();
            this.txtConvenioAno = new System.Windows.Forms.TextBox();
            this.lblConvenioMes = new System.Windows.Forms.Label();
            this.cbConvenioMes = new System.Windows.Forms.ComboBox();
            this.lblConvenioDesconto = new System.Windows.Forms.Label();
            this.txtConvenioDesconto = new System.Windows.Forms.TextBox();
            this.lblConvenioGlosa = new System.Windows.Forms.Label();
            this.txtConvenioGlosa = new System.Windows.Forms.TextBox();
            this.lblConvenioValor = new System.Windows.Forms.Label();
            this.txtConvenioValor = new System.Windows.Forms.TextBox();
            this.cbConvenios = new System.Windows.Forms.ComboBox();
            this.lblConvenio = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.txtContabilidadeAno = new System.Windows.Forms.TextBox();
            this.cbContabilidadeMes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblConvenioAno
            // 
            this.lblConvenioAno.AutoSize = true;
            this.lblConvenioAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvenioAno.Location = new System.Drawing.Point(953, 28);
            this.lblConvenioAno.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblConvenioAno.Name = "lblConvenioAno";
            this.lblConvenioAno.Size = new System.Drawing.Size(43, 20);
            this.lblConvenioAno.TabIndex = 59;
            this.lblConvenioAno.Text = "Ano:";
            // 
            // txtConvenioAno
            // 
            this.txtConvenioAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConvenioAno.Location = new System.Drawing.Point(957, 66);
            this.txtConvenioAno.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtConvenioAno.Name = "txtConvenioAno";
            this.txtConvenioAno.ShortcutsEnabled = false;
            this.txtConvenioAno.Size = new System.Drawing.Size(72, 27);
            this.txtConvenioAno.TabIndex = 58;
            this.txtConvenioAno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConvenioAno_KeyPress);
            // 
            // lblConvenioMes
            // 
            this.lblConvenioMes.AutoSize = true;
            this.lblConvenioMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvenioMes.Location = new System.Drawing.Point(816, 26);
            this.lblConvenioMes.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblConvenioMes.Name = "lblConvenioMes";
            this.lblConvenioMes.Size = new System.Drawing.Size(46, 20);
            this.lblConvenioMes.TabIndex = 57;
            this.lblConvenioMes.Text = "Mês:";
            // 
            // cbConvenioMes
            // 
            this.cbConvenioMes.BackColor = System.Drawing.SystemColors.Window;
            this.cbConvenioMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConvenioMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbConvenioMes.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cbConvenioMes.FormattingEnabled = true;
            this.cbConvenioMes.Items.AddRange(new object[] {
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
            this.cbConvenioMes.Location = new System.Drawing.Point(820, 66);
            this.cbConvenioMes.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbConvenioMes.Name = "cbConvenioMes";
            this.cbConvenioMes.Size = new System.Drawing.Size(55, 28);
            this.cbConvenioMes.TabIndex = 56;
            // 
            // lblConvenioDesconto
            // 
            this.lblConvenioDesconto.AutoSize = true;
            this.lblConvenioDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvenioDesconto.Location = new System.Drawing.Point(653, 28);
            this.lblConvenioDesconto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblConvenioDesconto.Name = "lblConvenioDesconto";
            this.lblConvenioDesconto.Size = new System.Drawing.Size(118, 20);
            this.lblConvenioDesconto.TabIndex = 55;
            this.lblConvenioDesconto.Text = "Desconto (%):";
            // 
            // txtConvenioDesconto
            // 
            this.txtConvenioDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConvenioDesconto.Location = new System.Drawing.Point(657, 70);
            this.txtConvenioDesconto.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtConvenioDesconto.Name = "txtConvenioDesconto";
            this.txtConvenioDesconto.ShortcutsEnabled = false;
            this.txtConvenioDesconto.Size = new System.Drawing.Size(80, 27);
            this.txtConvenioDesconto.TabIndex = 54;
            this.txtConvenioDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConvenioDesconto_KeyPress);
            // 
            // lblConvenioGlosa
            // 
            this.lblConvenioGlosa.AutoSize = true;
            this.lblConvenioGlosa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvenioGlosa.Location = new System.Drawing.Point(476, 28);
            this.lblConvenioGlosa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblConvenioGlosa.Name = "lblConvenioGlosa";
            this.lblConvenioGlosa.Size = new System.Drawing.Size(58, 20);
            this.lblConvenioGlosa.TabIndex = 53;
            this.lblConvenioGlosa.Text = "Glosa:";
            // 
            // txtConvenioGlosa
            // 
            this.txtConvenioGlosa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConvenioGlosa.Location = new System.Drawing.Point(480, 68);
            this.txtConvenioGlosa.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtConvenioGlosa.Name = "txtConvenioGlosa";
            this.txtConvenioGlosa.ShortcutsEnabled = false;
            this.txtConvenioGlosa.Size = new System.Drawing.Size(95, 26);
            this.txtConvenioGlosa.TabIndex = 52;
            this.txtConvenioGlosa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConvenioGlosa_KeyPress);
            // 
            // lblConvenioValor
            // 
            this.lblConvenioValor.AutoSize = true;
            this.lblConvenioValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvenioValor.Location = new System.Drawing.Point(299, 26);
            this.lblConvenioValor.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblConvenioValor.Name = "lblConvenioValor";
            this.lblConvenioValor.Size = new System.Drawing.Size(91, 20);
            this.lblConvenioValor.TabIndex = 51;
            this.lblConvenioValor.Text = "Valor (R$):";
            // 
            // txtConvenioValor
            // 
            this.txtConvenioValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConvenioValor.Location = new System.Drawing.Point(303, 68);
            this.txtConvenioValor.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtConvenioValor.Name = "txtConvenioValor";
            this.txtConvenioValor.ShortcutsEnabled = false;
            this.txtConvenioValor.Size = new System.Drawing.Size(95, 26);
            this.txtConvenioValor.TabIndex = 50;
            this.txtConvenioValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConvenioValor_KeyPress);
            // 
            // cbConvenios
            // 
            this.cbConvenios.BackColor = System.Drawing.SystemColors.Window;
            this.cbConvenios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConvenios.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbConvenios.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cbConvenios.FormattingEnabled = true;
            this.cbConvenios.Location = new System.Drawing.Point(23, 64);
            this.cbConvenios.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbConvenios.Name = "cbConvenios";
            this.cbConvenios.Size = new System.Drawing.Size(197, 28);
            this.cbConvenios.TabIndex = 49;
            // 
            // lblConvenio
            // 
            this.lblConvenio.AutoSize = true;
            this.lblConvenio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConvenio.Location = new System.Drawing.Point(19, 26);
            this.lblConvenio.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblConvenio.Name = "lblConvenio";
            this.lblConvenio.Size = new System.Drawing.Size(83, 20);
            this.lblConvenio.TabIndex = 48;
            this.lblConvenio.Text = "Convênio:";
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(23, 121);
            this.txtId.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtId.Name = "txtId";
            this.txtId.ShortcutsEnabled = false;
            this.txtId.Size = new System.Drawing.Size(55, 27);
            this.txtId.TabIndex = 60;
            this.txtId.Visible = false;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(623, 176);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(147, 42);
            this.btnExcluir.TabIndex = 62;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(224, 176);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(147, 42);
            this.btnAlterar.TabIndex = 61;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // txtContabilidadeAno
            // 
            this.txtContabilidadeAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContabilidadeAno.Location = new System.Drawing.Point(203, 124);
            this.txtContabilidadeAno.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtContabilidadeAno.Name = "txtContabilidadeAno";
            this.txtContabilidadeAno.ShortcutsEnabled = false;
            this.txtContabilidadeAno.Size = new System.Drawing.Size(72, 26);
            this.txtContabilidadeAno.TabIndex = 64;
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
            this.cbContabilidadeMes.Location = new System.Drawing.Point(105, 122);
            this.cbContabilidadeMes.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbContabilidadeMes.Name = "cbContabilidadeMes";
            this.cbContabilidadeMes.Size = new System.Drawing.Size(56, 28);
            this.cbContabilidadeMes.TabIndex = 63;
            this.cbContabilidadeMes.Visible = false;
            // 
            // frmConvenioValoresAlterarDeletar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 241);
            this.Controls.Add(this.txtContabilidadeAno);
            this.Controls.Add(this.cbContabilidadeMes);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblConvenioAno);
            this.Controls.Add(this.txtConvenioAno);
            this.Controls.Add(this.lblConvenioMes);
            this.Controls.Add(this.cbConvenioMes);
            this.Controls.Add(this.lblConvenioDesconto);
            this.Controls.Add(this.txtConvenioDesconto);
            this.Controls.Add(this.lblConvenioGlosa);
            this.Controls.Add(this.txtConvenioGlosa);
            this.Controls.Add(this.lblConvenioValor);
            this.Controls.Add(this.txtConvenioValor);
            this.Controls.Add(this.cbConvenios);
            this.Controls.Add(this.lblConvenio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConvenioValoresAlterarDeletar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Convênio - Valores - Alterar/excluir";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmConvenioValoresAlterarDeletar_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConvenioAno;
        private System.Windows.Forms.TextBox txtConvenioAno;
        private System.Windows.Forms.Label lblConvenioMes;
        private System.Windows.Forms.ComboBox cbConvenioMes;
        private System.Windows.Forms.Label lblConvenioDesconto;
        private System.Windows.Forms.TextBox txtConvenioDesconto;
        private System.Windows.Forms.Label lblConvenioGlosa;
        private System.Windows.Forms.TextBox txtConvenioGlosa;
        private System.Windows.Forms.Label lblConvenioValor;
        private System.Windows.Forms.TextBox txtConvenioValor;
        private System.Windows.Forms.ComboBox cbConvenios;
        private System.Windows.Forms.Label lblConvenio;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.TextBox txtContabilidadeAno;
        private System.Windows.Forms.ComboBox cbContabilidadeMes;
    }
}