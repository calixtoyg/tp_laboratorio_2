namespace MiCalculadora
{
    partial class Form1
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
            System.Windows.Forms.Button btnConvertirABinario;
            this.btnOperar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnConvertirADecimal = new System.Windows.Forms.Button();
            this.txtNumero1 = new System.Windows.Forms.TextBox();
            this.txtNumero2 = new System.Windows.Forms.TextBox();
            this.cmbOperador = new System.Windows.Forms.ComboBox();
            this.lblResultado = new System.Windows.Forms.Label();
            btnConvertirABinario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            btnConvertirABinario.Location = new System.Drawing.Point(13, 106);
            btnConvertirABinario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnConvertirABinario.Name = "btnConvertirABinario";
            btnConvertirABinario.Size = new System.Drawing.Size(155, 23);
            btnConvertirABinario.TabIndex = 3;
            btnConvertirABinario.Text = "Convertir a Binario";
            btnConvertirABinario.UseVisualStyleBackColor = true;
            btnConvertirABinario.Click += new System.EventHandler(this.btnConvertirABinario_Click);
            this.btnOperar.Location = new System.Drawing.Point(13, 77);
            this.btnOperar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnOperar.Name = "btnOperar";
            this.btnOperar.Size = new System.Drawing.Size(100, 23);
            this.btnOperar.TabIndex = 0;
            this.btnOperar.Text = "Operar";
            this.btnOperar.UseVisualStyleBackColor = true;
            this.btnOperar.Click += new System.EventHandler(this.btnOperar_Click);
            this.btnLimpiar.Location = new System.Drawing.Point(118, 77);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(121, 23);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            this.btnCerrar.Location = new System.Drawing.Point(247, 77);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 23);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            this.btnConvertirADecimal.Location = new System.Drawing.Point(192, 106);
            this.btnConvertirADecimal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnConvertirADecimal.Name = "btnConvertirADecimal";
            this.btnConvertirADecimal.Size = new System.Drawing.Size(155, 23);
            this.btnConvertirADecimal.TabIndex = 4;
            this.btnConvertirADecimal.Text = "Convertir a Decimal";
            this.btnConvertirADecimal.UseVisualStyleBackColor = true;
            this.btnConvertirADecimal.Click += new System.EventHandler(this.btnConvertirADecimal_Click);
            this.txtNumero1.Location = new System.Drawing.Point(13, 30);
            this.txtNumero1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNumero1.Name = "txtNumero1";
            this.txtNumero1.Size = new System.Drawing.Size(100, 23);
            this.txtNumero1.TabIndex = 5;
            this.txtNumero2.Location = new System.Drawing.Point(247, 30);
            this.txtNumero2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNumero2.Name = "txtNumero2";
            this.txtNumero2.Size = new System.Drawing.Size(100, 23);
            this.txtNumero2.TabIndex = 6;
            this.cmbOperador.FormattingEnabled = true;
            this.cmbOperador.Location = new System.Drawing.Point(118, 30);
            this.cmbOperador.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbOperador.Name = "cmbOperador";
            this.cmbOperador.Size = new System.Drawing.Size(121, 23);
            this.cmbOperador.TabIndex = 7;
            this.lblResultado.Location = new System.Drawing.Point(13, 3);
            this.lblResultado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(334, 23);
            this.lblResultado.TabIndex = 8;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 141);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.cmbOperador);
            this.Controls.Add(this.txtNumero2);
            this.Controls.Add(this.txtNumero1);
            this.Controls.Add(this.btnConvertirADecimal);
            this.Controls.Add(btnConvertirABinario);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnOperar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculadora de Calixto Gonzalez del curso 2 C";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnOperar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TextBox txtNumero1;
        private System.Windows.Forms.TextBox txtNumero2;
        private System.Windows.Forms.ComboBox cmbOperador;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Button btnConvertirADecimal;
    }
}