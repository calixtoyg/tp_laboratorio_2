namespace Forms
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEstadoEntregado = new System.Windows.Forms.Label();
            this.lblEstadoEnViaje = new System.Windows.Forms.Label();
            this.lblEstadoIngresado = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblTrackingID = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            this.groupBox1.Controls.Add(this.lblEstadoEntregado);
            this.groupBox1.Controls.Add(this.lblEstadoEnViaje);
            this.groupBox1.Controls.Add(this.lblEstadoIngresado);
            this.groupBox1.Controls.Add(this.listBox3);
            this.groupBox1.Controls.Add(this.listBox2);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(2351, 711);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estado Paquetes";
            this.lblEstadoEntregado.Location = new System.Drawing.Point(1603, 51);
            this.lblEstadoEntregado.Name = "lblEstadoEntregado";
            this.lblEstadoEntregado.Size = new System.Drawing.Size(687, 54);
            this.lblEstadoEntregado.TabIndex = 4;
            this.lblEstadoEntregado.Text = "Entregado:";
            this.lblEstadoEnViaje.Location = new System.Drawing.Point(826, 51);
            this.lblEstadoEnViaje.Name = "lblEstadoEnViaje";
            this.lblEstadoEnViaje.Size = new System.Drawing.Size(687, 54);
            this.lblEstadoEnViaje.TabIndex = 3;
            this.lblEstadoEnViaje.Text = "En Viaje:";
            this.lblEstadoIngresado.Location = new System.Drawing.Point(45, 51);
            this.lblEstadoIngresado.Name = "lblEstadoIngresado";
            this.lblEstadoIngresado.Size = new System.Drawing.Size(687, 54);
            this.lblEstadoIngresado.TabIndex = 2;
            this.lblEstadoIngresado.Text = "Ingresado:";
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 48;
            this.listBox3.Location = new System.Drawing.Point(1603, 108);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(687, 580);
            this.listBox3.TabIndex = 1;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 48;
            this.listBox2.Location = new System.Drawing.Point(826, 108);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(687, 580);
            this.listBox2.TabIndex = 1;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 48;
            this.listBox1.Location = new System.Drawing.Point(45, 108);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(687, 580);
            this.listBox1.TabIndex = 0;
            this.groupBox2.Controls.Add(this.txtDireccion);
            this.groupBox2.Controls.Add(this.lblDireccion);
            this.groupBox2.Controls.Add(this.lblTrackingID);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(1467, 729);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(896, 357);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Paquetes";
            this.txtDireccion.Location = new System.Drawing.Point(15, 248);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(550, 55);
            this.txtDireccion.TabIndex = 4;
            this.lblDireccion.Location = new System.Drawing.Point(15, 184);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(337, 52);
            this.lblDireccion.TabIndex = 3;
            this.lblDireccion.Text = "Direccion";
            this.lblTrackingID.Location = new System.Drawing.Point(15, 51);
            this.lblTrackingID.Name = "lblTrackingID";
            this.lblTrackingID.Size = new System.Drawing.Size(337, 52);
            this.lblTrackingID.TabIndex = 2;
            this.lblTrackingID.Text = "TrackingID";
            this.button2.Location = new System.Drawing.Point(602, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(269, 92);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button1.Location = new System.Drawing.Point(602, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(269, 92);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.richTextBox1.Location = new System.Drawing.Point(57, 741);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1404, 330);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 48F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2375, 1098);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEstadoEntregado;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lblEstadoEnViaje;
        private System.Windows.Forms.Label lblEstadoIngresado;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTrackingID;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.ListBox listBox1;
    }
}

