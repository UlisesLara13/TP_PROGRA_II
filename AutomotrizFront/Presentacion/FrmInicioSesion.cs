using AutomotrizFront.Servicios.Implementacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomotrizFront.Presentacion
{
    public partial class FrmInicioSesion : Form
    {
        private Dictionary<string, string> usuarios = new Dictionary<string, string>();
        FabricaServicios fabrica = null;
        public FrmInicioSesion(FabricaServicios fabrica)
        {
            InitializeComponent();
            this.fabrica = fabrica;
            cbMostrar.CheckedChanged += cbMostrar_CheckedChanged;
            usuarios.Add("Ulises", "1234");
            usuarios.Add("Santi", "1234");
            usuarios.Add("Pili", "1234");
            usuarios.Add("Luca", "1234");

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContraseña.Text;

            if (usuarios.ContainsKey(usuario) && usuarios[usuario] == contrasena)
            {
                MessageBox.Show("Inicio de sesión exitoso");
                this.Hide();


                FrmPrincipal nuevo = new FrmPrincipal(fabrica);
                nuevo.ShowDialog();

            }
            else
            {
                MessageBox.Show("Error ! Credenciales incorrectas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Question);
                txtUsuario.Text = "";
                txtContraseña.Text = "";
            }


        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (resultado == DialogResult.Yes)
            {

                Application.Exit();
            }

        }

        private void cbMostrar_CheckedChanged(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = !cbMostrar.Checked;
        }

        private void FrmInicioSesion_Load(object sender, EventArgs e)
        {
            txtContraseña.UseSystemPasswordChar = !cbMostrar.Checked;
        }
    }
}
