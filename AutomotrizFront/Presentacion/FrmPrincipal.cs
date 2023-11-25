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
    public partial class FrmPrincipal : Form
    {
        private FabricaServicios fabrica;

        public FrmPrincipal(FabricaServicios fabrica)
        {
            InitializeComponent();
            PersonalizarDiseño();
            this.fabrica = fabrica;


        }

        private void OcultarSubemenu()
        {
            if (panelFacturas.Visible == true)
            {
                panelFacturas.Visible = false;
            }
            if (panelAutos.Visible == true)
            { panelAutos.Visible = false; }

            if (panelReportes.Visible == true)
            { panelReportes.Visible = false; }

            if (panelDesarolladores.Visible == true)
            { panelDesarolladores.Visible = false; }

        }

        private void MostrarSubmenu(Panel menu)
        {
            if (menu.Visible == false)
            {
                OcultarSubemenu();
                menu.Visible = true;
            }
            else
            { menu.Visible = false; }


        }

        private void PersonalizarDiseño()
        {
            panelFacturas.Visible = false;
            panelAutos.Visible = false;
            panelReportes.Visible = false;
            panelDesarolladores.Visible = false;

        }


        private void btnFactura_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelFacturas);
        }

        private void btnGestionarFactura_Click(object sender, EventArgs e)
        {
            FrmConsultarFacturas nuevo = new FrmConsultarFacturas(fabrica);
            nuevo.ShowDialog();
            OcultarSubemenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelAutos);
        }

        private void btnGestionarAutos_Click(object sender, EventArgs e)
        {
            FrmConsultarAutos nuevo = new FrmConsultarAutos(fabrica);
            nuevo.ShowDialog();
            OcultarSubemenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelReportes);
        }

        private void btnAcercade_Click(object sender, EventArgs e)
        {
            MostrarSubmenu(panelDesarolladores);
        }

        private void btnDesarolladores_Click_1(object sender, EventArgs e)
        {
            FrmDesarrolladores nuevo = new FrmDesarrolladores();
            nuevo.ShowDialog();
            OcultarSubemenu();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {

            DialogResult resultado = MessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (resultado == DialogResult.Yes)
            {

                Application.Exit();
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FrmReporte nuevo = new FrmReporte();
            nuevo.ShowDialog();
            OcultarSubemenu();
        }
    }
}
