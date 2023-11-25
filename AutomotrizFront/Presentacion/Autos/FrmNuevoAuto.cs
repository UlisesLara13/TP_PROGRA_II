using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutomotrizBack.Datos;
using AutomotrizBack.Entidades.AutosCarpeta;
using AutomotrizBack.Entidades.Facturas;
using AutomotrizFront.Servicios.Implementacion;
using AutomotrizFront.Servicios.Interfaz;
using CarpinteriaFront.Servicios;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutomotrizFront.Presentacion
{
    public partial class FrmNuevoAuto : Form
    {
        IServicio servicio = null;
        Autos nuevo = null;
        public FrmNuevoAuto(FabricaServicios fab)
        {
            InitializeComponent();
            nuevo = new Autos();
            servicio = fab.CrearServicio();

        }


        private async void FrmNuevoAuto_Load(object sender, EventArgs e)
        {
            CargarCombos();
            lblAuto.Text = lblAuto.Text + " " + "N°: " + servicio.TraerProximoAuto().ToString();
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
        }

        private async Task CargarColoresAsync()
        {
            string url = "https://localhost:7288/autos/colores";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Colores> lColores = JsonConvert.DeserializeObject<List<Colores>>(dataJson);
            cboColor.DataSource = lColores;
            cboColor.ValueMember = "ColorId";
            cboColor.DisplayMember = "Color";
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

        private async Task CargarCombustibleAsync()
        {
            string url = "https://localhost:7288/autos/combustibles";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Tipos_Combustible> lCombuestible = JsonConvert.DeserializeObject<List<Tipos_Combustible>>(dataJson);
            cboCombustible.DataSource = lCombuestible;
            cboCombustible.ValueMember = "TipoCombustibleID";
            cboCombustible.DisplayMember = "TipoCombustible";
        }

        private async Task CargarMotoresAsync()
        {
            string url = "https://localhost:7288/autos/motores";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Tipos_Motor> lMotor = JsonConvert.DeserializeObject<List<Tipos_Motor>>(dataJson);
            cboMotor.DataSource = lMotor;
            cboMotor.ValueMember = "MotorID";
            cboMotor.DisplayMember = "Motor";
        }

        private async Task CargarTransmisionAsync()
        {
            string url = "https://localhost:7288/autos/transmision";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Tipo_Transmision> lTransmision = JsonConvert.DeserializeObject<List<Tipo_Transmision>>(dataJson);
            cboTranmision.DataSource = lTransmision;
            cboTranmision.ValueMember = "TipoTransmisionId";
            cboTranmision.DisplayMember = "TipoTransmision";
        }

        private async Task CargarTiposAsync()
        {
            string url = "https://localhost:7288/autos/tipos";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Tipos> lTipos = JsonConvert.DeserializeObject<List<Tipos>>(dataJson);
            cboTipo.DataSource = lTipos;
            cboTipo.ValueMember = "TipoId";
            cboTipo.DisplayMember = "Tipo";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidarTextBox(txtAño) && ValidarTextBoxFloat(txtCapacidad) && ValidarTextBox(txtPuertas) && ValidarTextBox(txtCilindros) && ValidarTextBox(txtPrecio))
            {
                Console.WriteLine("Carga de auto completa !.");
                GrabarAutoAsync();
            }
            else
            {
                Console.WriteLine("ERROR !.", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            Console.WriteLine("No se pudo cargar el auto !.");

        }

        private async Task GrabarAutoAsync()
        {

            nuevo.Marca = (Marcas)cboMarca.SelectedItem;
            nuevo.Motor = (Tipos_Motor)cboMotor.SelectedItem;
            nuevo.NroCiliendros = Convert.ToInt32(txtCilindros.Text);
            nuevo.NroPuertas = Convert.ToInt32(txtPuertas.Text);
            nuevo.PrecioUnitario = float.Parse(txtPrecio.Text);
            nuevo.Transmision = (Tipo_Transmision)cboTranmision.SelectedItem;
            nuevo.Año = Convert.ToInt32(txtAño.Text);
            nuevo.Combustible = (Tipos_Combustible)cboCombustible.SelectedItem;
            nuevo.Capacidad = Convert.ToDecimal(txtCapacidad.Text);
            nuevo.Tipo = (Tipos)cboTipo.SelectedItem;
            nuevo.Color = (Colores)cboColor.SelectedItem;
            nuevo.Modelo = (Modelos)cboModelo.SelectedItem;



            if (await GuardarAutoAsync(nuevo))
            {
                MessageBox.Show("No se registró con éxito el Auto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Se pudo registrar el Auto N°: " + (servicio.TraerProximoAuto() - 1).ToString(), "Informe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            else
            {
                MessageBox.Show("Operación no cancelada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
