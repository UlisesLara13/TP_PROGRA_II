using AutomotrizBack.Datos;
using AutomotrizBack.Entidades.ClientesCarpeta;
using AutomotrizFront.Servicios.Implementacion;
using AutomotrizFront.Servicios.Interfaz;
using CarpinteriaFront.Servicios;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutomotrizFront.Consultas
{
    public partial class FrmConsultas : Form
    {
        IServicio servicio = null;
        public FrmConsultas(FabricaServicios fab)
        {
            servicio = fab.CrearServicio();
            InitializeComponent();
        }

        private async Task CargarClientesAsync()
        {
            string url = "https://localhost:7288/facturas/clientes";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<ClientesAPI> lClientesAPI = JsonConvert.DeserializeObject<List<ClientesAPI>>(dataJson);
            cboCliente.DataSource = lClientesAPI;
            cboCliente.ValueMember = "ClienteId";
            cboCliente.DisplayMember = "alias";
            cboCliente.Refresh();
        }

        private async void FrmConsultas_Load(object sender, EventArgs e)
        {
            btnConsultar.Enabled = false;
            //Ocultar();
            await CargarClientesAsync();
            cboCliente.SelectedIndex = -1;
            lblDesde.Enabled = false;
            lblHasta.Enabled = false;
            lblCliente.Enabled = false;
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;
            cboCliente.Enabled = false;



        }


        private void CargarGrillaVentaCliente()
        {
            if (cboCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Debe ingresar seleccionar un cliente.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dtpHasta.Value > DateTime.Today.AddDays(1))
            {
                MessageBox.Show("Debe ingresar seleccionar una fecha valida.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataTable tabla = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@fechaInicio", dtpDesde.Value.ToString("yyyyMMdd")));
            lst.Add(new Parametro("@fechaFin", dtpHasta.Value.ToString("yyyyMMdd")));
            lst.Add(new Parametro("@ClienteID", cboCliente.SelectedValue));
            tabla = servicio.ObtenerConsultaParametros("SP_MONTOTOTALVENTACLIENTE", lst);
            dgvConsulta.DataSource = tabla;
            dgvConsulta.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void Ocultar()
        {
            dtpDesde.Visible = false;
            dtpHasta.Visible = false;
            cboCliente.Visible = false;
            lblCliente.Visible = false;
            lblDesde.Visible = false;
            lblHasta.Visible = false;
        }

        private void CargarGrillaTotalFacturacionAuto()
        {

            if (dtpHasta.Value > DateTime.Today.AddDays(1))
            {
                MessageBox.Show("Debe ingresar seleccionar una fecha valida.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DataTable tabla = new DataTable();
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@periodo_inicio", dtpDesde.Value.ToString("yyyyMMdd")));
            lst.Add(new Parametro("@periodo_fin", dtpHasta.Value.ToString("yyyyMMdd")));
            tabla = servicio.ObtenerConsultaParametros("SP_TOTAL_FACTURACION_AUTO", lst);
            dgvConsulta.DataSource = tabla;
            dgvConsulta.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (rbNoVendidos.Checked)
            {
                DataTable tabla = new DataTable();
                tabla = servicio.ObtenerConsulta("SP_AUTOSNOVENDIDOS");
                dgvConsulta.DataSource = tabla;
                dgvConsulta.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

            if (rbTotalPromedio.Checked)
            {
                CargarGrillaTotalFacturacionAuto();
            }

            if (rbTotalVenta.Checked) CargarGrillaVentaCliente();

            if (rbConsumidoresFinales.Checked)
            {
                DataTable tabla = new DataTable();
                tabla = servicio.ObtenerConsulta("sp_facturasConImporteSuperiorPromedio");
                dgvConsulta.DataSource = tabla;
                dgvConsulta.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvConsulta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dgvConsulta.DataSource = null;

            dgvConsulta.Rows.Clear();
            //cboCliente.Visible = false;
            //lblCliente.Visible = false;
            //lblDesde.Visible = true;
            //lblHasta.Visible = true;
            //dtpHasta.Visible = true;
            //dtpDesde.Visible = true;
            //btnConsultar.Visible = true;
            dtpDesde.Enabled = true;
            dtpHasta.Enabled = true;
            cboCliente.Enabled = false;
            btnConsultar.Enabled = true;
            lblDesde.Enabled = true;
            lblHasta.Enabled = true;
            lblCliente.Enabled = false;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            dgvConsulta.DataSource = null;
            dgvConsulta.Rows.Clear();
            cboCliente.SelectedIndex = -1;
            btnConsultar.Visible = true;
            //Ocultar();
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;
            cboCliente.Enabled = false;
            btnConsultar.Enabled = true;
            lblDesde.Enabled = false;
            lblHasta.Enabled = false;
            lblCliente.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dgvConsulta.DataSource = null;
            dgvConsulta.Rows.Clear();
            cboCliente.SelectedIndex = -1;
            btnConsultar.Visible = true;
            //Ocultar();
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;
            cboCliente.Enabled = false;
            btnConsultar.Enabled = true;
            lblDesde.Enabled = false;
            lblHasta.Enabled = false;
            lblCliente.Enabled = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            dgvConsulta.DataSource = null;
            dgvConsulta.Rows.Clear();
            btnConsultar.Visible = true;

            //lblDesde.Visible = true;
            //lblHasta.Visible = true;
            //dtpHasta.Visible = true;
            //dtpDesde.Visible = true;
            //lblCliente.Visible = true;
            //cboCliente.Visible = true;
            dtpDesde.Enabled = true;
            dtpHasta.Enabled = true;
            cboCliente.Enabled = true;
            btnConsultar.Enabled = true;
            lblDesde.Enabled = false;
            lblHasta.Enabled = false;
            lblCliente.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
