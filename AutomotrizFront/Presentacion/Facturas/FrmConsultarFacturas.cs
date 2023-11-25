using AutomotrizBack.Entidades.AutosCarpeta;
using AutomotrizBack.Entidades.ClientesCarpeta;
using AutomotrizBack.Entidades.Facturas;
using AutomotrizFront.Consultas;
using AutomotrizFront.Servicios.Implementacion;
using AutomotrizFront.Servicios.Interfaz;
using CarpinteriaFront.Servicios;
using Newtonsoft.Json;
using ScottPlot.Palettes;
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
    public partial class FrmConsultarFacturas : Form
    {
        FabricaServicios fabrica = null;
        IServicio servicio = null;
        Factura_Autos factura = null;
        public FrmConsultarFacturas(FabricaServicios fabrica)
        {
            factura = new Factura_Autos();
            this.fabrica = fabrica;
            servicio = fabrica.CrearServicio();
            InitializeComponent();

        }

        private void FrmConsultarFacturas_Load(object sender, EventArgs e)
        {
            CargarCombos();
            cboCliente.SelectedValue = 1;
            dtpDesde.Value = DateTime.Now.AddDays(-7);
            dtpHasta.Value = DateTime.Now;
        }

        private async void CargarCombos()
        {

            await CargarClientesAsync();

        }


        private async Task CargarClientesAsync()
        {
            string url = "https://localhost:7288/facturas/clientes";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<ClientesAPI> lClientesAPI = JsonConvert.DeserializeObject<List<ClientesAPI>>(dataJson);
            cboCliente.DataSource = lClientesAPI;
            cboCliente.ValueMember = "ClienteId";
            cboCliente.DisplayMember = "alias";
        }

        private void CargarFacturas()
        {
            dgvFacturas.Columns.Clear();

            int id = Convert.ToInt32(cboCliente.SelectedValue);

            DataTable tabla = servicio.ObtenerEscalarFecha("SP_CONSULTAR_FACTURA_FECHA", id, dtpDesde.Value, dtpHasta.Value);

            dgvFacturas.DataSource = tabla;
            dgvFacturas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();

            buttonColumn.Name = "ButtonColumn";
            buttonColumn.HeaderText = "Eliminar";
            buttonColumn.Text = "Eliminar";
            buttonColumn.UseColumnTextForButtonValue = true;

            dgvFacturas.Columns.Add(buttonColumn);

            DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();


            buttonColumn2.Name = "ButtonColumn2";
            buttonColumn2.HeaderText = "Modificar";
            buttonColumn2.Text = "Modificar";
            buttonColumn2.UseColumnTextForButtonValue = true;

            dgvFacturas.Columns.Add(buttonColumn2);



        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private async Task<bool> EliminarFacturaAsync(int id)
        {
            string url = "https://localhost:7288/facturas/eliminar/" + id;
            var dataJson = await ClienteSingleton.GetInstance().DeleteAsync(url);
            if (dataJson.Equals(""))
                return true;
            else
                return false;

        }

        private void dgvFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFacturas.CurrentCell.ColumnIndex == 4)
            {

                int id = Convert.ToInt32(dgvFacturas.Rows[dgvFacturas.CurrentRow.Index].Cells[0].Value);
                EliminarFacturaAsync(id);
                MessageBox.Show("Factura eliminada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvFacturas.Rows.RemoveAt(dgvFacturas.CurrentRow.Index);

            }

            if (dgvFacturas.CurrentCell.ColumnIndex == 5)
            {


                int id = Convert.ToInt32(dgvFacturas.Rows[dgvFacturas.CurrentRow.Index].Cells[0].Value);

                FrmModificarFactura nuevo = new FrmModificarFactura(fabrica, id);
                this.Dispose();
                nuevo.ShowDialog();

            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (resultado == DialogResult.Yes)
            {

                this.Close();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevaFactura nuevo = new FrmNuevaFactura(fabrica);
            nuevo.ShowDialog();
        }

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvFacturas.DataSource = null;
            dgvFacturas.Rows.Clear();
            dgvFacturas.Columns.Clear();
        }
    }
}
