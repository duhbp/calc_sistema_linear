namespace SistemasLineares
{
    partial class frmSistemasLineares
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSistemasLineares));
            this.gridTabela = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nr_Variavel = new System.Windows.Forms.NumericUpDown();
            this.bntCalcular = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnArquivo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridTabela)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nr_Variavel)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridTabela
            // 
            this.gridTabela.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTabela.Location = new System.Drawing.Point(31, 54);
            this.gridTabela.Name = "gridTabela";
            this.gridTabela.Size = new System.Drawing.Size(781, 222);
            this.gridTabela.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Insira nos campos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(818, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "N° variavel:";
            // 
            // nr_Variavel
            // 
            this.nr_Variavel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nr_Variavel.Location = new System.Drawing.Point(944, 50);
            this.nr_Variavel.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nr_Variavel.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nr_Variavel.Name = "nr_Variavel";
            this.nr_Variavel.Size = new System.Drawing.Size(79, 31);
            this.nr_Variavel.TabIndex = 3;
            this.nr_Variavel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nr_Variavel.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nr_Variavel.ValueChanged += new System.EventHandler(this.NrVariavel_ValueChanged);
            // 
            // bntCalcular
            // 
            this.bntCalcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntCalcular.Location = new System.Drawing.Point(823, 103);
            this.bntCalcular.Name = "bntCalcular";
            this.bntCalcular.Size = new System.Drawing.Size(200, 52);
            this.bntCalcular.TabIndex = 4;
            this.bntCalcular.Text = "CALCULAR";
            this.bntCalcular.UseVisualStyleBackColor = true;
            this.bntCalcular.Click += new System.EventHandler(this.BtnCalcular);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.btnArquivo);
            this.groupBox1.Location = new System.Drawing.Point(823, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // btnArquivo
            // 
            this.btnArquivo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArquivo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnArquivo.Location = new System.Drawing.Point(22, 19);
            this.btnArquivo.Name = "btnArquivo";
            this.btnArquivo.Size = new System.Drawing.Size(156, 67);
            this.btnArquivo.TabIndex = 6;
            this.btnArquivo.Text = "IMPORTAR E CALCULAR";
            this.btnArquivo.UseVisualStyleBackColor = false;
            this.btnArquivo.Click += new System.EventHandler(this.BtnArquivo);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Resultados:";
            // 
            // txtResultado
            // 
            this.txtResultado.Font = new System.Drawing.Font("Monospac821 BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultado.Location = new System.Drawing.Point(31, 310);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResultado.Size = new System.Drawing.Size(992, 287);
            this.txtResultado.TabIndex = 10;
            this.txtResultado.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(2, 610);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Calculadora de Sistemas Lineres - @2021";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(868, 610);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Duarte Pires e Marcos Felipe Sampaio";
            // 
            // frmSistemasLineares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 627);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bntCalcular);
            this.Controls.Add(this.nr_Variavel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridTabela);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSistemasLineares";
            this.Text = "Sistemas Lineares";
            ((System.ComponentModel.ISupportInitialize)(this.gridTabela)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nr_Variavel)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTabela;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nr_Variavel;
        private System.Windows.Forms.Button bntCalcular;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnArquivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

