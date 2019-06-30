using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;

namespace MiCalculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("/");
            cmbOperador.Items.Add("*");
            txtNumero1.Text = String.Empty;
            txtNumero2.Text = String.Empty;
            lblResultado.Text = String.Empty;
//            this. = "Hola que tal";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbOperador.Text = String.Empty;
            txtNumero1.Text = String.Empty;
            txtNumero2.Text = String.Empty;
            lblResultado.Text = String.Empty;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double valorDeRetorno = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.SelectedItem.ToString());
            if (valorDeRetorno == Double.MinValue)
            {
                
               lblResultado.Text = "No se puede divir por 0";

            }
            else
            {
                lblResultado.Text = valorDeRetorno.ToString();
            }
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Numero(numero1), new Numero(numero2), operador);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text == String.Empty || txtNumero2.Text == String.Empty || lblResultado.Text == String.Empty)
            {
                lblResultado.Text = "Error. Algun campo esta vacio";
            }
            else
            {
                lblResultado.Text = new Numero(lblResultado.Text).DecimalBinario(lblResultado.Text);
            }
            
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (txtNumero1.Text == String.Empty || txtNumero2.Text == String.Empty || lblResultado.Text == String.Empty)
            {
                lblResultado.Text = "Error. Algun campo esta vacio";
            }
            else
            {
                lblResultado.Text = new Numero(lblResultado.Text).BinarioDecimal(lblResultado.Text);
            }
        }
    }
}