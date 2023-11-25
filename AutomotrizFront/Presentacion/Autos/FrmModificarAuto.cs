using AutomotrizBack.Entidades.AutosCarpeta;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutomotrizFront.Consultas
{
    public partial class FrmModificarAuto : Form
    {
        IServicio servicio = null;
        Autos nuevo = null;
        Autos b = null;
        int id = 0;

        public FrmModificarAuto(FabricaServicios fab, int id)
        {
            InitializeComponent();
            Autos b = new Autos();
            servicio = fab.CrearServicio();
            this.id = id;
        }


        private async void CargarCombos()
        {

            await CargarModelosAsync();
            await CargarColoresAsync();
            await CargarMarcasAsync();
            await CargarCombustibleAsync();
            await CargarCombustibleAsync();
            await CargarMotoresAsync();
            await CargarTiposAsync();
            await CargarTransmisionAsync();
        }

        private async Task<bool> GuardarAutoAsync(Autos oAuto)
        {
            string url = "https://localhost:7288/autos";
            string facturaJson = JsonConvert.SerializeObject(oAuto);
            var dataJson = await ClienteSingleton.GetInstance().PostAsync(url, facturaJson);
            if (dataJson.Equals(""))
                return true;
            else
                return false;

        }
        private async Task CargarModelosAsync()
        {
            string url = "https://localhost:7288/autos/modelos";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Modelos> lModelos = JsonConvert.DeserializeObject<List<Modelos>>(dataJson);
            cboModelo.DataSource = lModelos;
            cboModelo.ValueMember = "ModeloId";
            cboModelo.DisplayMember = "Modelo";


            cboModelo.SelectedValue = b.Modelo.ModeloId;
            cboModelo.SelectedItem = b.Modelo;

        }

        private async Task CargarColoresAsync()
        {
            string url = "https://localhost:7288/autos/colores";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Colores> lColores = JsonConvert.DeserializeObject<List<Colores>>(dataJson);
            cboColor.DataSource = lColores;
            cboColor.ValueMember = "ColorId";
            cboColor.DisplayMember = "Color";

            cboColor.SelectedValue = b.Color.ColorId;
            cboColor.SelectedItem = b.Color;

        }

        private async Task CargarMarcasAsync()
        {
            string url = "https://localhost:7288/autos/marcas";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Marcas> lMarcas = JsonConvert.DeserializeObject<List<Marcas>>(dataJson);
            cboMarca.DataSource = lMarcas;
            cboMarca.ValueMember = "MarcaId";
            cboMarca.DisplayMember = "Marca";

            cboMarca.SelectedValue = b.Marca.MarcaId;
            cboMarca.SelectedItem = b.Marca;

        }

        private async Task CargarCombustibleAsync()
        {
            string url = "https://localhost:7288/autos/combustibles";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Tipos_Combustible> lCombuestible = JsonConvert.DeserializeObject<List<Tipos_Combustible>>(dataJson);
            cboCombustible.DataSource = lCombuestible;
            cboCombustible.ValueMember = "TipoCombustibleID";
            cboCombustible.DisplayMember = "TipoCombustible";

            cboCombustible.SelectedValue = b.Combustible.TipoCombustibleID;
            cboCombustible.SelectedItem = b.Combustible;

        }

        private async Task CargarMotoresAsync()
        {
            string url = "https://localhost:7288/autos/motores";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Tipos_Motor> lMotor = JsonConvert.DeserializeObject<List<Tipos_Motor>>(dataJson);
            cboMotor.DataSource = lMotor;
            cboMotor.ValueMember = "MotorID";
            cboMotor.DisplayMember = "Motor";

            cboMotor.SelectedValue = b.Motor.MotorID;
            cboMotor.SelectedItem = b.Motor;
        }

        private async Task CargarTransmisionAsync()
        {
            string url = "https://localhost:7288/autos/transmision";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Tipo_Transmision> lTransmision = JsonConvert.DeserializeObject<List<Tipo_Transmision>>(dataJson);
            cboTranmision.DataSource = lTransmision;
            cboTranmision.ValueMember = "TipoTransmisionId";
            cboTranmision.DisplayMember = "TipoTransmision";

            cboTranmision.SelectedValue = b.Transmision.TipoTransmisionId;
            cboTranmision.SelectedItem = b.Transmision;

        }

        private async Task CargarTiposAsync()
        {
            string url = "https://localhost:7288/autos/tipos";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Tipos> lTipos = JsonConvert.DeserializeObject<List<Tipos>>(dataJson);
            cboTipo.DataSource = lTipos;
            cboTipo.ValueMember = "TipoId";
            cboTipo.DisplayMember = "Tipo";

            cboTipo.SelectedValue = b.Tipo.TipoId;
            cboTipo.SelectedItem = b.Tipo;

        }

        private async void FrmActulizarAutos_Load(object sender, EventArgs e)
        {
            CargarCombos();
            List<Autos> autos = servicio.TraerAutosCbo();
            foreach (Autos a in autos)
            {
                if (id == a.AutoId)
                {
                    b = a;
                    break;
                }

            }


            txtCilindros.Text = b.NroCiliendros.ToString();
            txtPuertas.Text = b.NroPuertas.ToString();
            txtPrecio.Text = b.PrecioUnitario.ToString();
            txtAño.Text = b.Año.ToString();
            txtCapacidad.Text = b.Capacidad.ToString();


        }

        public bool ValidarTextBox(System.Windows.Forms.TextBox textBox)
        {

            if (string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Error de validacion! El campo " + textBox.Name.Substring(3) + " Debe ser no nulo", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(textBox.Text, out _))
            {
                MessageBox.Show("Error de validacion! El campo " + textBox.Name.Substring(3) + " Debe ser numerico entero", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        public bool ValidarTextBoxFloat(System.Windows.Forms.TextBox textBox)
        {

            if (string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show("Error de validacion! El campo " + textBox.Name.Substring(3) + " Debe ser no nulo", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!float.TryParse(textBox.Text, out _))
            {
                MessageBox.Show("Error de validacion! El campo " + textBox.Name.Substring(3) + " Debe ser numerico decimal", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (ValidarTextBox(txtAño) && ValidarTextBoxFloat(txtCapacidad) && ValidarTextBox(txtPuertas) && ValidarTextBox(txtCilindros) && ValidarTextBox(txtPrecio))
            {
                Console.WriteLine("Carga de auto completa !.");
                b.Marca = (Marcas)cboMarca.SelectedItem;
                b.Motor = (Tipos_Motor)cboMotor.SelectedItem;
                b.NroCiliendros = Convert.ToInt32(txtCilindros.Text);
                b.NroPuertas = Convert.ToInt32(txtPuertas.Text);
                b.PrecioUnitario = float.Parse(txtPrecio.Text);
                b.Transmision = (Tipo_Transmision)cboTranmision.SelectedItem;
                b.Año = Convert.ToInt32(txtAño.Text);
                b.Combustible = (Tipos_Combustible)cboCombustible.SelectedItem;
                b.Capacidad = Convert.ToDecimal(txtCapacidad.Text);
                b.Tipo = (Tipos)cboTipo.SelectedItem;
                b.Color = (Colores)cboColor.SelectedItem;
                b.Modelo = (Modelos)cboModelo.SelectedItem;
                ActualizarAutoAsync();
            }
            else
            {
                Console.WriteLine("ERROR !.", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            Console.WriteLine("No se pudo cargar el auto !.");

        }

        private async Task<bool> ActualizarAutoAsync1(Autos oAuto)
        {
            string url = "https://localhost:7288/autos/actualizar";
            string facturaJson = JsonConvert.SerializeObject(oAuto);
            var dataJson = await ClienteSingleton.GetInstance().PutAsync(url, facturaJson);
            if (dataJson.Equals(""))
                return true;
            else
                return false;

        }



        private async Task ActualizarAutoAsync()
        {

            if (await ActualizarAutoAsync1(b))
            {
                MessageBox.Show("No se actualizó con éxito el auto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Se pudo actualizar el auto.", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas cancelar?", "Confirmar cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (resultado == DialogResult.Yes)
            {

                MessageBox.Show("Operación cancelada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }
    }
}
