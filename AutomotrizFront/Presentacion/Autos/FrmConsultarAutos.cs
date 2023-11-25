using AutomotrizBack.Datos;
using AutomotrizBack.Entidades.AutosCarpeta;
using AutomotrizFront.Consultas;
using AutomotrizFront.Servicios.Implementacion;
using AutomotrizFront.Servicios.Interfaz;
using CarpinteriaFront.Servicios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutomotrizFront.Presentacion
{
    public partial class FrmConsultarAutos : Form
    {
        FabricaServicios fabrica = null;
        IServicio servicio = null;
        Autos nuevo = null;

        public FrmConsultarAutos(FabricaServicios fabrica)
        {
            nuevo = new Autos();
            this.fabrica = fabrica;
            servicio = fabrica.CrearServicio();
            InitializeComponent();
        }

        private async Task CargarMarcasAsync()
        {
            string url = "https://localhost:7288/autos/marcas";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Marcas> lMarcas = JsonConvert.DeserializeObject<List<Marcas>>(dataJson);
            cboMarca.DataSource = lMarcas;
            cboMarca.ValueMember = "MarcaId";
            cboMarca.DisplayMember = "Marca";

        }

        private void OcultarTodasLasImagenes()
        {
            pbFord.Visible = false;
            pbHonda.Visible = false;
            pbVolks.Visible = false;
            pbToyota.Visible = false;
            pbNissan.Visible = false;
        }

        private void MostrarImagenSegunID(int id)
        {

            switch (id)
            {
                case 1:
                    pbToyota.Visible = true;
                    break;
                case 2:
                    pbHonda.Visible = true;
                    break;
                case 3:
                    pbNissan.Visible = true;
                    break;
                case 4:
                    pbVolks.Visible = true;
                    break;
                case 5:
                    pbFord.Visible = true;
                    break;
                default:

                    break;
            }
        }

        private void CargarAutos()
        {

            dgvAutos.Columns.Clear();

            int id = Convert.ToInt32(cboMarca.SelectedValue);


            DataTable tabla = servicio.ObtenerConsultaID("SP_CONSULTAR_AUTOS_GRILLA_MARCA", id);

            dgvAutos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvAutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAutos.DataSource = tabla;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();


            buttonColumn.Name = "ButtonColumn";
            buttonColumn.HeaderText = "Eliminar";
            buttonColumn.Text = "Eliminar";
            buttonColumn.UseColumnTextForButtonValue = true;


            dgvAutos.Columns.Add(buttonColumn);

            DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();



            buttonColumn2.Name = "ButtonColumn2";
            buttonColumn2.HeaderText = "Modificar";
            buttonColumn2.Text = "Modificar";
            buttonColumn2.UseColumnTextForButtonValue = true;


            dgvAutos.Columns.Add(buttonColumn2);


        }

        private async void CargarCombos()
        {

            await CargarMarcasAsync();

        }

        private void FrConsultar_Load(object sender, EventArgs e)
        {


            cboMarca.SelectedValue = 1;
            CargarCombos();

        }

        private async void button1_Click(object sender, EventArgs e)
        {



            int id = Convert.ToInt32(dgvAutos.Rows[0].Cells[0].Value);
            await EliminarAutoAsync(id);
        }

        private async Task<bool> EliminarAutoAsync(int id)
        {
            string url = "https://localhost:7288/autos/eliminar/" + id;
            var dataJson = await ClienteSingleton.GetInstance().DeleteAsync(url);
            if (dataJson.Equals(""))
                return true;
            else
                return false;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (resultado == DialogResult.Yes)
            {

                this.Close();
            }

        }

        private void dgvAutos_CellContentClickAsync(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAutos.CurrentCell.ColumnIndex == 5)
            {


                int id = Convert.ToInt32(dgvAutos.Rows[dgvAutos.CurrentRow.Index].Cells[0].Value);
                EliminarAutoAsync(id);
                MessageBox.Show("Auto eliminado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvAutos.Rows.RemoveAt(dgvAutos.CurrentRow.Index);

            }

            if (dgvAutos.CurrentCell.ColumnIndex == 6)
            {


                int id = Convert.ToInt32(dgvAutos.Rows[dgvAutos.CurrentRow.Index].Cells[0].Value);

                FrmModificarAuto nuevo = new FrmModificarAuto(fabrica, id);
                this.Dispose();
                nuevo.ShowDialog();

            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarAutos();
        }

        private void cboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvAutos.DataSource = null;
            dgvAutos.Rows.Clear();
            dgvAutos.Columns.Clear();

            if (cboMarca.SelectedValue != null)
            {

                if (int.TryParse(cboMarca.SelectedValue.ToString(), out int idSeleccionado))
                {
                    OcultarTodasLasImagenes();

                    MostrarImagenSegunID(idSeleccionado);
                }
                else
                {

                }
            }



        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevoAuto nuevo = new FrmNuevoAuto(fabrica);
            nuevo.ShowDialog();
        }
    }
}


