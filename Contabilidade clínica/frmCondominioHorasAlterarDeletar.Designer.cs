namespace Contabilidade_clínica
{
    partial class frmCondominioHorasAlterarDeletar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCondominioHorasAlterarDeletar));
            this.txtCondominioHoras = new System.Windows.Forms.TextBox();
            this.txtCondominioAno = new System.Windows.Forms.TextBox();
            this.cbCondominioMes = new System.Windows.Forms.ComboBox();
            this.cbCondominioNome = new System.Windows.Forms.ComboBox();
            this.lblCondominioMes = new System.Windows.Forms.Label();
            this.lblCondominioHorasNome = new System.Windows.Forms.Label();
            this.lblCondominioHorasTrabalhadas = new System.Windows.Forms.Label();
            this.lblCondominioAno = new System.Windows.Forms.Label();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtContabilidadeAno = new System.Windows.Forms.TextBox();
            this.cbContabilidadeMes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtCondominioHoras
            // 
            this.txtCondominioHoras.Location = new System.Drawing.Point(769, 64);
            this.txtCondominioHoras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCondominioHoras.Name = "txtCondominioHoras";
            this.txtCondominioHoras.Size = new System.Drawing.Size(63, 22);
            this.txtCondominioHoras.TabIndex = 41;
            // 
            // txtCondominioAno
            // 
            this.txtCondominioAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCondominioAno.Location = new System.Drawing.Point(217, 59);
            this.txtCondominioAno.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtCondominioAno.Name = "txtCondominioAno";
            this.txtCondominioAno.ShortcutsEnabled = false;
            this.txtCondominioAno.Size = new System.Drawing.Size(72, 27);
            this.txtCondominioAno.TabIndex = 40;
            this.txtCondominioAno.TextChanged += new System.EventHandler(this.txtCondominioAno_TextChanged);
            // 
            // cbCondominioMes
            // 
            this.cbCondominioMes.BackColor = System.Drawing.SystemColors.Window;
            this.cbCondominioMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondominioMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCondominioMes.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cbCondominioMes.FormattingEnabled = true;
            this.cbCondominioMes.Items.AddRange(new object[] {
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
            this.cbCondominioMes.Location = new System.Drawing.Point(41, 60);
            this.cbCondominioMes.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbCondominioMes.Name = "cbCondominioMes";
            this.cbCondominioMes.Size = new System.Drawing.Size(56, 28);
            this.cbCondominioMes.TabIndex = 39;
            this.cbCondominioMes.SelectedIndexChanged += new System.EventHandler(this.cbCondominioMes_SelectedIndexChanged);
            // 
            // cbCondominioNome
            // 
            this.cbCondominioNome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondominioNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCondominioNome.FormattingEnabled = true;
            this.cbCondominioNome.Location = new System.Drawing.Point(409, 58);
            this.cbCondominioNome.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbCondominioNome.Name = "cbCondominioNome";
            this.cbCondominioNome.Size = new System.Drawing.Size(240, 28);
            this.cbCondominioNome.TabIndex = 38;
            this.cbCondominioNome.DropDown += new System.EventHandler(this.cbCondominioNome_DropDown);
            // 
            // lblCondominioMes
            // 
            this.lblCondominioMes.AutoSize = true;
            this.lblCondominioMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondominioMes.Location = new System.Drawing.Point(37, 21);
            this.lblCondominioMes.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCondominioMes.Name = "lblCondominioMes";
            this.lblCondominioMes.Size = new System.Drawing.Size(46, 20);
            this.lblCondominioMes.TabIndex = 42;
            this.lblCondominioMes.Text = "Mês:";
            // 
            // lblCondominioHorasNome
            // 
            this.lblCondominioHorasNome.AutoSize = true;
            this.lblCondominioHorasNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondominioHorasNome.Location = new System.Drawing.Point(405, 21);
            this.lblCondominioHorasNome.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCondominioHorasNome.Name = "lblCondominioHorasNome";
            this.lblCondominioHorasNome.Size = new System.Drawing.Size(58, 20);
            this.lblCondominioHorasNome.TabIndex = 43;
            this.lblCondominioHorasNome.Text = "Nome:";
            // 
            // lblCondominioHorasTrabalhadas
            // 
            this.lblCondominioHorasTrabalhadas.AutoSize = true;
            this.lblCondominioHorasTrabalhadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondominioHorasTrabalhadas.Location = new System.Drawing.Point(765, 21);
            this.lblCondominioHorasTrabalhadas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCondominioHorasTrabalhadas.Name = "lblCondominioHorasTrabalhadas";
            this.lblCondominioHorasTrabalhadas.Size = new System.Drawing.Size(78, 40);
            this.lblCondominioHorasTrabalhadas.TabIndex = 44;
            this.lblCondominioHorasTrabalhadas.Text = "Horas na\r\nclínica:";
            // 
            // lblCondominioAno
            // 
            this.lblCondominioAno.AutoSize = true;
            this.lblCondominioAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCondominioAno.Location = new System.Drawing.Point(213, 22);
            this.lblCondominioAno.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCondominioAno.Name = "lblCondominioAno";
            this.lblCondominioAno.Size = new System.Drawing.Size(43, 20);
            this.lblCondominioAno.TabIndex = 45;
            this.lblCondominioAno.Text = "Ano:";
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Location = new System.Drawing.Point(528, 159);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(147, 42);
            this.btnExcluir.TabIndex = 47;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(199, 159);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(147, 42);
            this.btnAlterar.TabIndex = 46;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(41, 112);
            this.txtId.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtId.Name = "txtId";
            this.txtId.ShortcutsEnabled = false;
            this.txtId.Size = new System.Drawing.Size(56, 27);
            this.txtId.TabIndex = 48;
            this.txtId.Visible = false;
            // 
            // txtContabilidadeAno
            // 
            this.txtContabilidadeAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContabilidadeAno.Location = new System.Drawing.Point(315, 114);
            this.txtContabilidadeAno.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtContabilidadeAno.Name = "txtContabilidadeAno";
            this.txtContabilidadeAno.ShortcutsEnabled = false;
            this.txtContabilidadeAno.Size = new System.Drawing.Size(72, 26);
            this.txtContabilidadeAno.TabIndex = 50;
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
            this.cbContabilidadeMes.Location = new System.Drawing.Point(217, 112);
            this.cbContabilidadeMes.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cbContabilidadeMes.Name = "cbContabilidadeMes";
            this.cbContabilidadeMes.Size = new System.Drawing.Size(56, 28);
            this.cbContabilidadeMes.TabIndex = 49;
            this.cbContabilidadeMes.Visible = false;
            // 
            // frmCondominioHorasAlterarDeletar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 225);
            this.Controls.Add(this.txtContabilidadeAno);
            this.Controls.Add(this.cbContabilidadeMes);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.lblCondominioAno);
            this.Controls.Add(this.lblCondominioHorasTrabalhadas);
            this.Controls.Add(this.lblCondominioHorasNome);
            this.Controls.Add(this.lblCondominioMes);
            this.Controls.Add(this.txtCondominioHoras);
            this.Controls.Add(this.txtCondominioAno);
            this.Controls.Add(this.cbCondominioMes);
            this.Controls.Add(this.cbCondominioNome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCondominioHorasAlterarDeletar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Condomínio - Horas trabalhadas pelos membros da clínica - Alterar/excluir";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCondominioHorasAlterarDeletar_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCondominioHoras;
        private System.Windows.Forms.TextBox txtCondominioAno;
        private System.Windows.Forms.ComboBox cbCondominioMes;
        private System.Windows.Forms.ComboBox cbCondominioNome;
        private System.Windows.Forms.Label lblCondominioMes;
        private System.Windows.Forms.Label lblCondominioHorasNome;
        private System.Windows.Forms.Label lblCondominioHorasTrabalhadas;
        private System.Windows.Forms.Label lblCondominioAno;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtContabilidadeAno;
        private System.Windows.Forms.ComboBox cbContabilidadeMes;
    }
}