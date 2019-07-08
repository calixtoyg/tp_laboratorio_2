using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomExceptions;
using TP_04;

namespace Forms
{
    public partial class Form1 : Form
    {
        private Correo correo;


        public Form1()
        {
            InitializeComponent();
            this.Text = "Correo UTN por Calixto Gonzalez 2C";
            this.correo = new Correo();
        }

        private void btnAgregar_Click(object sender, EventArgs args)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.txtTrackingId.Text);
            paquete.InformarEstado += this.PaqueteInformarEstado;
            try
            {
                this.correo += paquete;
            }
            catch (TrackingIdRepetidoException e)
            {
                MessageBox.Show(e.Message, "Paquete repetido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DatoNoCompletadoException e)
            {
                MessageBox.Show(e.Message, "El paquete que intenta agregar necesita mas informacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.ActualizarEstados();
        }

        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();
            using (List<Paquete>.Enumerator enumerator = this.correo.Paquetes.GetEnumerator())
            {
                while (true)
                {
                    if (!enumerator.MoveNext())
                    {
                        break;
                    }

                    Paquete current = enumerator.Current;
                    switch (current.Estado)
                    {
                        case EEstado.Ingresado:
                        {
                            this.lstEstadoIngresado.Items.Add(current);
                            continue;
                        }

                        case EEstado.EnViaje:
                        {
                            this.lstEstadoEnViaje.Items.Add(current);
                            continue;
                        }

                        case EEstado.Entregado:
                        {
                            this.lstEstadoEntregado.Items.Add(current);
                            continue;
                        }
                    }
                }
            }
        }

        private void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>(this.correo);
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!ReferenceEquals(elemento, null))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text.Guardar("salida.txt");
            }
        }


        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MostrarInformacion((IMostrar<Paquete>) lstEstadoEntregado.SelectedItem);
        }

        private void PaqueteInformarEstado(object sender, EventArgs eventArgs)
        {
            if (!InvokeRequired)
            {
                ActualizarEstados();
            }
            else
            {
                Paquete.DelegadoEstado method = PaqueteInformarEstado;
                object[] args = new object[] {sender, eventArgs};
                Invoke(method, args);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }
    }
}