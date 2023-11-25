using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutomotrizBack.Datos;
using AutomotrizBack.Entidades.Facturas;
using AutomotrizFront.Servicios.Implementacion;
using AutomotrizFront.Servicios.Interfaz;
using CarpinteriaFront.Servicios;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Http.Headers;
using AutomotrizBack.Entidades.AutosCarpeta;
using AutomotrizBack.Entidades.ClientesCarpeta;

namespace AutomotrizFront.Presentacion
{
    public partial class FrmNuevaFactura : Form
    {
        IServicio servicio = null;
        Factura_Autos nuevo = null;
        public FrmNuevaFactura(FabricaServicios fabrica)
        {
            InitializeComponent();
            nuevo = new Factura_Autos();
            servicio = fabrica.CrearServicio();
        }

        private void FrmNuevaFactura_Load(object sender, EventArgs e)
        {
            CargarCombos();
            dtpFechaFactura.Value = DateTime.Now;
            dtpFechaPago.Value = DateTime.Now.AddDays(30);
            txtInteres.Text = "10";
            txtDescuento.Text = "5";
            txtCantidad.Text = "1";
            lblFacturaNro.Text = lblFacturaNro.Text + " " + servicio.TraerProximaFactura().ToString();
        }

        private Detalle_Factura_Autos BuscarDetallePorAuto(int idAuto)
        {
            foreach (Detalle_Factura_Autos detalle in nuevo.Detalles)
            {
                if (detalle.Auto.AutoId == idAuto)
                {
                    return detalle;
                }
            }
            return null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out _))
            {
                MessageBox.Show("Debe ingresar una cantidad válida...", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!(int.TryParse(txtInteres.Text, out int interes) && interes >= 0 && interes <= 100))
            {
                MessageBox.Show("El valor de Interés debe estar entre 0 y 100...", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!(int.TryParse(txtDescuento.Text, out int descuento) && descuento >= 0 && descuento <= 100))
            {
                MessageBox.Show("El valor de Descuento debe estar entre 0 y 100...", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            AutosAPI autoSeleccionado = (AutosAPI)cboAuto.SelectedItem;

            Detalle_Factura_Autos detalleExistente = BuscarDetallePorAuto(autoSeleccionado.AutoId);

            if (detalleExistente != null)
            {
                MessageBox.Show("Ya existe un detalle con el mismo auto", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }


            Autos b = null;
            List<Autos> autos = servicio.TraerAutosCbo();
            foreach (Autos a in autos)
            {
                if (Convert.ToInt32(cboAuto.SelectedValue) == a.AutoId)
                {
                    b = a;
                    break;
                }

            }

            bool autoExistente = false;
            int cant = Convert.ToInt32(txtCantidad.Text);



            if (!autoExistente)
            {
                float desc = 0;
                float inte = 0;

                desc = float.Parse(txtDescuento.Text);
                inte = float.Parse(txtInteres.Text);

                Detalle_Factura_Autos detalle = new Detalle_Factura_Autos(cant, b);
                float subtotal = detalle.CalcularSubtotal(desc, inte);


                nuevo.AgregarDetalle(detalle);

                dgvDetalles.Rows.Add(new object[] { b.AutoId, b.ToString(), b.PrecioUnitario, cant, subtotal, "Quitar" });

                CalcularTotales(desc, inte);


            }



        }

        private void CalcularTotales(float desc, float inte)
        {
            if (!string.IsNullOrEmpty(txtDescuento.Text) && int.TryParse(txtDescuento.Text, out _))
            {
                txtTotal.Text = (nuevo.CalcularTotal(desc, inte)).ToString();
            }
        }




        private async void CargarCombos()
        {
            await CargarPagosAsync();
            await CargarEnviosAsync();
            await CargarClientesAsync();
            await CargarAutosAsync();

        }

        private async Task CargarPagosAsync()
        {
            string url = "https://localhost:7288/facturas/pagos";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Forma_Pago> lPagos = JsonConvert.DeserializeObject<List<Forma_Pago>>(dataJson);
            cboFormaPago.DataSource = lPagos;
            cboFormaPago.ValueMember = "FormaPagoId";
            cboFormaPago.DisplayMember = "FormaPago";
        }

        private async Task CargarAutosAsync()
        {
            string url = "https://localhost:7288/facturas/autos";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<AutosAPI> lAutosAPI = JsonConvert.DeserializeObject<List<AutosAPI>>(dataJson);
            cboAuto.DataSource = lAutosAPI;
            cboAuto.ValueMember = "AutoId";
            cboAuto.DisplayMember = "alias";
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

        private async Task CargarEnviosAsync()
        {
            string url = "https://localhost:7288/facturas/envios";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Forma_Envio> lEnvios = JsonConvert.DeserializeObject<List<Forma_Envio>>(dataJson);
            cboFormaEnvio.DataSource = lEnvios;
            cboFormaEnvio.ValueMember = "FormaEnvioId";
            cboFormaEnvio.DisplayMember = "FormaEnvio";
        }

        private async Task<bool> GuardarFacturaAsync(Factura_Autos nueva)
        {
            string url = "https://localhost:7288/facturas";
            string facturaJson = JsonConvert.SerializeObject(nueva);
            var dataJson = await ClienteSingleton.GetInstance().PostAsync(url, facturaJson);
            if (dataJson.Equals(""))
                return true;
            else
                return false;

        }

        private async Task<bool> ActualizarFacturaAsync(int idFactura, List<Parametro> parametros)
        {

            var json = JsonConvert.SerializeObject(parametros);
            string url = "https://localhost:7268/presupuesto" + "/" + idFactura;
            var dataJson = await ClienteSingleton.GetInstance().PutAsync(url, json);

            if (dataJson.Equals(""))
                return true;
            else
                return false;
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

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            float desc = 0;
            float inte = 0;

            desc = float.Parse(txtDescuento.Text);
            inte = float.Parse(txtInteres.Text);

            if (dgvDetalles.CurrentCell.ColumnIndex == 5)
            {
                nuevo.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.RemoveAt(dgvDetalles.CurrentRow.Index);
                CalcularTotales(desc, inte);

            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (dgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un detalle.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GrabarFactura();
        }

        private async void GrabarFactura()
        {
            nuevo.FechaFactura = Convert.ToDateTime(dtpFechaFactura.Value);
            nuevo.FechaPago = Convert.ToDateTime(dtpFechaPago.Value);
            nuevo.Descuentos = float.Parse(txtDescuento.Text);
            nuevo.Intereses = float.Parse(txtInteres.Text);
            nuevo.FormaEnvio = (Forma_Envio)cboFormaEnvio.SelectedItem;
            nuevo.FormaPago = (Forma_Pago)cboFormaPago.SelectedItem;

            List<Clientes> Clientes = servicio.ObtenerClientesCbo();
            foreach (Clientes a in Clientes)
            {
                if (Convert.ToInt32(cboCliente.SelectedValue) == a.ClienteId)
                {
                    nuevo.Cliente = a;
                    break;
                }

            }


            if (await GuardarFacturaAsync(nuevo))
            {
                MessageBox.Show("No se registró con éxito la Factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Se pudo registrar la factura con éxito.", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();

            }
        }
    }
}
