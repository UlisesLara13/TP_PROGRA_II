using AutomotrizBack.Datos;
using AutomotrizBack.Entidades.AutosCarpeta;
using AutomotrizBack.Entidades.ClientesCarpeta;
using AutomotrizBack.Entidades.Facturas;
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

namespace AutomotrizFront.Presentacion
{
    public partial class FrmModificarFactura : Form
    {
        IServicio servicio = null;
        Factura_Autos nuevo = null;
        int id = 0;
        public FrmModificarFactura(FabricaServicios fabrica, int id)
        {
            InitializeComponent();
            Factura_Autos nuevo = new Factura_Autos();
            servicio = fabrica.CrearServicio();
            this.id = id;
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

            cboFormaPago.SelectedValue = nuevo.FormaPago.FormaPagoId;
            cboFormaPago.SelectedItem = nuevo.FormaPago;

        }

        private async Task CargarAutosAsync()
        {
            string url = "https://localhost:7288/facturas/autos";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<AutosAPI> lAutosAPI = JsonConvert.DeserializeObject<List<AutosAPI>>(dataJson);
            cboAuto.DataSource = lAutosAPI;
            cboAuto.ValueMember = "AutoId";
            cboAuto.DisplayMember = "alias";

            cboAuto.SelectedValue = nuevo.FormaEnvio.FormaEnvioId;
            cboAuto.SelectedItem = nuevo.FormaEnvio;

        }

        private async Task CargarClientesAsync()
        {
            string url = "https://localhost:7288/facturas/clientes";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<ClientesAPI> lClientesAPI = JsonConvert.DeserializeObject<List<ClientesAPI>>(dataJson);
            cboCliente.DataSource = lClientesAPI;
            cboCliente.ValueMember = "ClienteId";
            cboCliente.DisplayMember = "alias";

            cboCliente.SelectedValue = nuevo.Cliente.ClienteId;
            cboCliente.SelectedItem = nuevo.Cliente;

        }

        private async Task CargarEnviosAsync()
        {
            string url = "https://localhost:7288/facturas/envios";
            var dataJson = await ClienteSingleton.GetInstance().GetAsync(url);
            List<Forma_Envio> lEnvios = JsonConvert.DeserializeObject<List<Forma_Envio>>(dataJson);
            cboFormaEnvio.DataSource = lEnvios;
            cboFormaEnvio.ValueMember = "FormaEnvioId";
            cboFormaEnvio.DisplayMember = "FormaEnvio";

            cboFormaEnvio.SelectedValue = nuevo.FormaEnvio.FormaEnvioId;
            cboFormaEnvio.SelectedItem = nuevo.FormaEnvio;

        }

        private void FrmModificarFactura_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarGrilla();
            List<Factura_Autos> facturas = servicio.ObtenerFacturaAutosCbo();
            foreach (Factura_Autos f in facturas)
            {
                if (id == f.FacturaAutoId)
                {
                    nuevo = f;
                    break;
                }

            }

            float desc = 0;
            float inte = 0;



            txtDescuento.Text = nuevo.Descuentos.ToString();
            txtInteres.Text = nuevo.Intereses.ToString();
            dtpFechaFactura.Value = nuevo.FechaFactura;
            dtpFechaPago.Value = nuevo.FechaPago;
            txtCantidad.Text = "1";

            dtpFechaFactura.Enabled = false;
            lblFacturaNro.Text += " " + id;

            desc = float.Parse(txtDescuento.Text);
            inte = float.Parse(txtInteres.Text);

            CalcularTotales(desc, inte);



        }
        private void CalcularTotales(float desc, float inte)
        {
            if (!string.IsNullOrEmpty(txtDescuento.Text) && int.TryParse(txtDescuento.Text, out _))
            {
                txtTotal.Text = (nuevo.CalcularTotal(desc, inte)).ToString();
            }
        }
        private void CargarGrilla()
        {
            dgvDetalles.Columns.Clear();

            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@factura_nro", id));
            DataTable tabla = servicio.ObtenerConsultaParametros("SP_CONSULTAR_DETALLE_FACTURA_AUTO_GRILLA", lst);


            dgvDetalles.DataSource = tabla;
            dgvDetalles.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();


            buttonColumn.Name = "ButtonColumn";
            buttonColumn.HeaderText = "Eliminar";
            buttonColumn.Text = "Eliminar";
            buttonColumn.UseColumnTextForButtonValue = true;


            dgvDetalles.Columns.Add(buttonColumn);
            dgvDetalles.Columns[0].Visible = false;

        }

        private void CargarDetalles()
        {
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@factura_nro", id));
            DataTable tabla = servicio.ObtenerConsultaParametros("SP_CONSULTAR_DETALLE_FACTURA_AUTO", lst);

            foreach (DataRow fila in tabla.Rows)
            {
                Autos auto = new Autos();

                Modelos mo = new Modelos();
                Colores co = new Colores();
                Tipos_Motor tm = new Tipos_Motor();
                Tipo_Transmision tt = new Tipo_Transmision();
                Tipos_Combustible tc = new Tipos_Combustible();
                Marcas ma = new Marcas();
                Tipos t = new Tipos();


                int id = Convert.ToInt32(fila["AutoID"].ToString());
                int año = Convert.ToInt32(fila["Año"].ToString());
                decimal capacidad = Convert.ToDecimal(fila["Capacidad"].ToString());
                int nro_cilindros = Convert.ToInt32(fila["NroCilindros"].ToString());
                int nro_puertas = Convert.ToInt32(fila["NroPuertas"].ToString());

                mo.ModeloId = Convert.ToInt32(fila["ModeloID"].ToString());
                mo.Modelo = fila["Modelo"].ToString();

                co.ColorId = Convert.ToInt32(fila["ColorID"].ToString());
                co.Color = fila["Color"].ToString();

                tm.MotorID = Convert.ToInt32(fila["Motor_ID"].ToString());
                tm.Motor = fila["Motor"].ToString();

                tt.TipoTransmisionId = Convert.ToInt32(fila["Tipo_TransmisionID"].ToString());
                tt.TipoTransmision = fila["TipoTransmision"].ToString();

                tc.TipoCombustibleID = Convert.ToInt32(fila["Tipo_CombustibleID"].ToString());
                tc.TipoCombustible = fila["TipoCombustible"].ToString();

                ma.MarcaId = Convert.ToInt32(fila["MarcaID"].ToString());
                ma.Marca = fila["Marca"].ToString();

                t.TipoId = Convert.ToInt32(fila["TipoID"].ToString());
                t.Tipo = fila["Tipo"].ToString();

                float pre_unitario = float.Parse(fila["precio_unitario"].ToString());

                Autos a = new Autos(id, año, capacidad, nro_puertas, nro_cilindros, mo, co, tm, tt, tc, ma, t, pre_unitario);

                Detalle_Factura_Autos dfa = new Detalle_Factura_Autos();
                dfa.DetalleFacturaAutoId = int.Parse(fila["DetalleFacturaAutoID"].ToString());
                dfa.Subtotal = float.Parse(fila["Subtotal"].ToString());
                dfa.Cantidad = int.Parse(fila["Cantidad"].ToString());
                dfa.Auto = a;
                nuevo.AgregarDetalle(dfa);

            }

        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            float desc = 0;
            float inte = 0;

            desc = float.Parse(txtDescuento.Text);
            inte = float.Parse(txtInteres.Text);

            if (dgvDetalles.CurrentRow != null && dgvDetalles.CurrentRow.Index >= 0 && dgvDetalles.CurrentRow.Index < nuevo.Detalles.Count)
            {
                Console.WriteLine("Entró al if");
                nuevo.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.RemoveAt(dgvDetalles.CurrentRow.Index);
                CalcularTotales(desc, inte);
            }
        }

        private async Task<bool> EliminarDetalleAsync(int id)
        {
            string url = "https://localhost:7288/facturas/eliminar/detalle/" + id;
            var dataJson = await ClienteSingleton.GetInstance().DeleteAsync(url);
            if (dataJson.Equals(""))
                return true;
            else
                return false;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (dgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un detalle.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            ActualizarFactura();

        }

        private async void ActualizarFactura()
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

            ActualizarFacturaAsync();

        }

        private async Task<bool> ActualizarFacturaAsync1(Factura_Autos oFactura)
        {
            string url = "https://localhost:7288/facturas/actualizar";
            string facturaJson = JsonConvert.SerializeObject(oFactura);
            var dataJson = await ClienteSingleton.GetInstance().PutAsync(url, facturaJson);
            if (dataJson.Equals(""))
                return true;
            else
                return false;

        }

        private async Task ActualizarFacturaAsync()
        {

            if (await ActualizarFacturaAsync1(nuevo))
            {
                MessageBox.Show("No se actualizó con éxito el auto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Se pudo actualizar el auto.", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();

            }
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

            int cant = Convert.ToInt32(txtCantidad.Text);
            float desc = 0;
            float inte = 0;

            desc = float.Parse(txtDescuento.Text);
            inte = float.Parse(txtInteres.Text);

            Detalle_Factura_Autos detalle = new Detalle_Factura_Autos(cant, b);
            float subtotal = detalle.CalcularSubtotal(desc, inte);


            nuevo.AgregarDetalle(detalle);



            DataRow newRow = ((DataTable)dgvDetalles.DataSource).NewRow();
            newRow["Marca"] = b.Marca.Marca;
            newRow["Modelo"] = b.Modelo.Modelo;
            newRow["Año"] = b.Año;
            newRow["Cantidad"] = cant;
            newRow["Subtotal"] = subtotal;

            ((DataTable)dgvDetalles.DataSource).Rows.Add(newRow);

            CalcularTotales(desc, inte);
        }
    }
}
