namespace Contabilidade_clínica
{
    partial class frmAluguelAlterarDeletar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAluguelAlterarDeletar));
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblAluguelPeriodo = new System.Windows.Forms.Label();
            this.cbAluguelPeriodo = new System.Windows.Forms.ComboBox();
            this.lblAluguelValor = new System.Windows.Forms.Label();
            this.txtAluguelValor = new System.Windows.Forms.TextBox();
            this.lblAluguelAno = new System.Windows.Forms.Label();
            this.txtAluguelAno = new System.Windows.Forms.TextBox();
            this.lblAluguelMes = new System.Windows.Forms.Label();
            this.cbAluguelMes = new System.Windows.Forms.ComboBox();
            this.lblAluguelNome = new System.Windows.Forms.Label();
            this.cbAluguelNome = new System.Windows.Forms.ComboBox();
            this.txtContabilidadeAno = new System.Windows.Forms.TextBox();
            this.cbContabilidadeMes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnAlterar
            // 
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(255, 172);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(147, 42);
            this.btnAlterar.TabIndex = 76;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletar.Location = new System.Drawing.Point(601, 172);
            this.btnDeletar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(147, 42);
            this.btnDeletar.TabIndex = 75;
            this.btnDeletar.Text = "Excluir";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(32, 123);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtId.Name = "txtId";
            this.txtId.ShortcutsEnabled = false;
            this.txtId.Size = new System.Drawing.Size(55, 27);
            this.txtId.TabIndex = 77;
            this.txtId.Visible = false;
            // 
            // lblAluguelPeriodo
            // 
            this.lblAluguelPeriodo.AutoSize = true;
            this.lblAluguelPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAluguelPeriodo.Location = new System.Drawing.Point(611, 28);
            this.lblAluguelPeriodo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAluguelPeriodo.Name = "lblAluguelPeriodo";
            this.lblAluguelPeriodo.Size = new System.Drawing.Size(205, 20);
            this.lblAluguelPeriodo.TabIndex = 87;
            this.lblAluguelPeriodo.Text = "Período em que trabalhou:";
            // 
            // cbAluguelPeriodo
            // 
            this.cbAluguelPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAluguelPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAluguelPeriodo.FormattingEnabled = true;
            this.cbAluguelPeriodo.Items.AddRange(new object[] {
            "Matutino",
            "Vespertino",
            "Matutino e vespertino"});
            this.cbAluguelPeriodo.Location = new System.Drawing.Point(615, 68);
            this.cbAluguelPeriodo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbAluguelPeriodo.Name = "cbAluguelPeriodo";
            this.cbAluguelPeriodo.Size = new System.Drawing.Size(215, 28);
            this.cbAluguelPeriodo.TabIndex = 86;
            // 
            // lblAluguelValor
            // 
            this.lblAluguelValor.AutoSize = true;
            this.lblAluguelValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAluguelValor.Location = new System.Drawing.Point(897, 28);
            this.lblAluguelValor.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAluguelValor.Name = "lblAluguelValor";
            this.lblAluguelValor.Size = new System.Drawing.Size(53, 20);
            this.lblAluguelValor.TabIndex = 85;
            this.lblAluguelValor.Text = "Valor:";
            // 
            // txtAluguelValor
            // 
            this.txtAluguelValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAluguelValor.Location = new System.Drawing.Point(901, 69);
            this.txtAluguelValor.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtAluguelValor.Name = "txtAluguelValor";
            this.txtAluguelValor.ShortcutsEnabled = false;
            this.txtAluguelValor.Size = new System.Drawing.Size(95, 26);
            this.txtAluguelValor.TabIndex = 84;
            this.txtAluguelValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAluguelValor_KeyPress);
            // 
            // lblAluguelAno
            // 
            this.lblAluguelAno.AutoSize = true;
            this.lblAluguelAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAluguelAno.Location = new System.Drawing.Point(155, 28);
            this.lblAluguelAno.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAluguelAno.Name = "lblAluguelAno";
            this.lblAluguelAno.Size = new System.Drawing.Size(43, 20);
            this.lblAluguelAno.TabIndex = 83;
            this.lblAluguelAno.Text = "Ano:";
            // 
            // txtAluguelAno
            // 
            this.txtAluguelAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAluguelAno.Location = new System.Drawing.Point(159, 69);
            this.txtAluguelAno.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtAluguelAno.Name = "txtAluguelAno";
            this.txtAluguelAno.ShortcutsEnabled = false;
            this.txtAluguelAno.Size = new System.Drawing.Size(72, 27);
            this.txtAluguelAno.TabIndex = 82;
            this.txtAluguelAno.TextChanged += new System.EventHandler(this.txtAluguelAno_TextChanged);
            this.txtAluguelAno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAluguelAno_KeyPress);
            // 
            // lblAluguelMes
            // 
            this.lblAluguelMes.AutoSize = true;
            this.lblAluguelMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAluguelMes.Location = new System.Drawing.Point(28, 28);
            this.lblAluguelMes.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAluguelMes.Name = "lblAluguelMes";
            this.lblAluguelMes.Size = new System.Drawing.Size(46, 20);
            this.lblAluguelMes.TabIndex = 81;
            this.lblAluguelMes.Text = "Mês:";
            // 
            // cbAluguelMes
            // 
            this.cbAluguelMes.BackColor = System.Drawing.SystemColors.Window;
            this.cbAluguelMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAluguelMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAluguelMes.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cbAluguelMes.FormattingEnabled = true;
            this.cbAluguelMes.Items.AddRange(new object[] {
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
            this.cbAluguelMes.Location = new System.Drawing.Point(32, 65);
            this.cbAluguelMes.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbAluguelMes.Name = "cbAluguelMes";
            this.cbAluguelMes.Size = new System.Drawing.Size(55, 28);
            this.cbAluguelMes.TabIndex = 80;
            this.cbAluguelMes.SelectedIndexChanged += new System.EventHandler(this.cbAluguelMes_SelectedIndexChanged);
            // 
            // lblAluguelNome
            // 
            this.lblAluguelNome.AutoSize = true;
            this.lblAluguelNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAluguelNome.Location = new System.Drawing.Point(299, 28);
            this.lblAluguelNome.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAluguelNome.Name = "lblAluguelNome";
            this.lblAluguelNome.Size = new System.Drawing.Size(58, 20);
            this.lblAluguelNome.TabIndex = 79;
            this.lblAluguelNome.Text = "Nome:";
            // 
            // cbAluguelNome
            // 
            this.cbAluguelNome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAluguelNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAluguelNome.FormattingEnabled = true;
            this.cbAluguelNome.Location = new System.Drawing.Point(303, 65);
            this.cbAluguelNome.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbAluguelNome.Name = "cbAluguelNome";
            this.cbAluguelNome.Size = new System.Drawing.Size(240, 28);
            this.cbAluguelNome.TabIndex = 78;
            this.cbAluguelNome.DropDown += new System.EventHandler(this.cbAluguelNome_DropDown);
            // 
            // txtContabilidadeAno
            // 
            this.txtContabilidadeAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContabilidadeAno.Location = new System.Drawing.Point(245, 127);
            this.txtContabilidadeAno.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtContabilidadeAno.Name = "txtContabilidadeAno";
            this.txtContabilidadeAno.ShortcutsEnabled = false;
            this.txtContabilidadeAno.Size = new System.Drawing.Size(72, 26);
            this.txtContabilidadeAno.TabIndex = 89;
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
            this.cbContabilidadeMes.Location = new System.Drawing.Point(148, 124);
            this.cbContabilidadeMes.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbContabilidadeMes.Name = "cbContabilidadeMes";
            this.cbContabilidadeMes.Size = new System.Drawing.Size(56, 28);
            this.cbContabilidadeMes.TabIndex = 88;
            this.cbContabilidadeMes.Visible = false;
            // 
            // frmAluguelAlterarDeletar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 239);
            this.Controls.Add(this.txtContabilidadeAno);
            this.Controls.Add(this.cbContabilidadeMes);
            this.Controls.Add(this.lblAluguelPeriodo);
            this.Controls.Add(this.cbAluguelPeriodo);
            this.Controls.Add(this.lblAluguelValor);
            this.Controls.Add(this.txtAluguelValor);
            this.Controls.Add(this.lblAluguelAno);
            this.Controls.Add(this.txtAluguelAno);
            this.Controls.Add(this.lblAluguelMes);
            this.Controls.Add(this.cbAluguelMes);
            this.Controls.Add(this.lblAluguelNome);
            this.Controls.Add(this.cbAluguelNome);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnDeletar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAluguelAlterarDeletar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aluguel - Alterar/excluir";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAluguelAlterarDeletar_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblAluguelPeriodo;
        private System.Windows.Forms.ComboBox cbAluguelPeriodo;
        private System.Windows.Forms.Label lblAluguelValor;
        private System.Windows.Forms.TextBox txtAluguelValor;
        private System.Windows.Forms.Label lblAluguelAno;
        private System.Windows.Forms.TextBox txtAluguelAno;
        private System.Windows.Forms.Label lblAluguelMes;
        private System.Windows.Forms.ComboBox cbAluguelMes;
        private System.Windows.Forms.Label lblAluguelNome;
        private System.Windows.Forms.ComboBox cbAluguelNome;
        private System.Windows.Forms.TextBox txtContabilidadeAno;
        private System.Windows.Forms.ComboBox cbContabilidadeMes;
    }
}