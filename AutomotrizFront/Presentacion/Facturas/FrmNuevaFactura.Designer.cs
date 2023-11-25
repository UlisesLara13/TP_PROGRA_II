namespace AutomotrizFront.Presentacion
{
    partial class FrmNuevaFactura
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevaFactura));
            label5=new Label();
            txtInteres=new TextBox();
            label12=new Label();
            cboFormaPago=new ComboBox();
            label1=new Label();
            lblFacturaNro=new Label();
            label3=new Label();
            label4=new Label();
            label6=new Label();
            label7=new Label();
            dtpFechaFactura=new DateTimePicker();
            dtpFechaPago=new DateTimePicker();
            txtDescuento=new TextBox();
            cboCliente=new ComboBox();
            cboFormaEnvio=new ComboBox();
            dgvDetalles=new DataGridView();
            ID=new DataGridViewTextBoxColumn();
            ColAuto=new DataGridViewTextBoxColumn();
            ColPrecio=new DataGridViewTextBoxColumn();
            ColCantidad=new DataGridViewTextBoxColumn();
            CoSubtotal=new DataGridViewTextBoxColumn();
            ColAcciones=new DataGridViewButtonColumn();
            label8=new Label();
            cboAuto=new ComboBox();
            txtCantidad=new TextBox();
            label9=new Label();
            btnAgregar=new Button();
            btnCancelar=new Button();
            btnAceptar=new Button();
            txtTotal=new TextBox();
            label10=new Label();
            label13=new Label();
            label14=new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize=true;
            label5.Location=new Point(318, 90);
            label5.Margin=new Padding(4, 0, 4, 0);
            label5.Name="label5";
            label5.Size=new Size(66, 15);
            label5.TabIndex=57;
            label5.Text="Descuento:";
            // 
            // txtInteres
            // 
            txtInteres.Location=new Point(129, 87);
            txtInteres.Margin=new Padding(4, 3, 4, 3);
            txtInteres.Name="txtInteres";
            txtInteres.Size=new Size(106, 23);
            txtInteres.TabIndex=1;
            // 
            // label12
            // 
            label12.AutoSize=true;
            label12.Location=new Point(76, 157);
            label12.Margin=new Padding(4, 0, 4, 0);
            label12.Name="label12";
            label12.Size=new Size(47, 15);
            label12.TabIndex=54;
            label12.Text="Cliente:";
            // 
            // cboFormaPago
            // 
            cboFormaPago.DropDownStyle=ComboBoxStyle.DropDownList;
            cboFormaPago.FormattingEnabled=true;
            cboFormaPago.Location=new Point(391, 121);
            cboFormaPago.Margin=new Padding(4, 3, 4, 3);
            cboFormaPago.Name="cboFormaPago";
            cboFormaPago.Size=new Size(106, 23);
            cboFormaPago.TabIndex=5;
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(67, 90);
            label1.Margin=new Padding(4, 0, 4, 0);
            label1.Name="label1";
            label1.Size=new Size(56, 15);
            label1.TabIndex=52;
            label1.Text="Intereses:";
            // 
            // lblFacturaNro
            // 
            lblFacturaNro.AutoSize=true;
            lblFacturaNro.Font=new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblFacturaNro.Location=new Point(27, 19);
            lblFacturaNro.Margin=new Padding(4, 0, 4, 0);
            lblFacturaNro.Name="lblFacturaNro";
            lblFacturaNro.Size=new Size(96, 20);
            lblFacturaNro.TabIndex=58;
            lblFacturaNro.Text="Factura Nro:";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(313, 58);
            label3.Margin=new Padding(4, 0, 4, 0);
            label3.Name="label3";
            label3.Size=new Size(71, 15);
            label3.TabIndex=59;
            label3.Text="Fecha Pago:";
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new Point(40, 58);
            label4.Margin=new Padding(4, 0, 4, 0);
            label4.Name="label4";
            label4.Size=new Size(83, 15);
            label4.TabIndex=60;
            label4.Text="Fecha Factura:";
            // 
            // label6
            // 
            label6.AutoSize=true;
            label6.Location=new Point(47, 125);
            label6.Margin=new Padding(4, 0, 4, 0);
            label6.Name="label6";
            label6.Size=new Size(76, 15);
            label6.TabIndex=61;
            label6.Text="Forma envio:";
            // 
            // label7
            // 
            label7.AutoSize=true;
            label7.Location=new Point(296, 124);
            label7.Margin=new Padding(4, 0, 4, 0);
            label7.Name="label7";
            label7.Size=new Size(90, 15);
            label7.TabIndex=62;
            label7.Text="Forma de pago:";
            // 
            // dtpFechaFactura
            // 
            dtpFechaFactura.Enabled=false;
            dtpFechaFactura.Format=DateTimePickerFormat.Short;
            dtpFechaFactura.Location=new Point(129, 54);
            dtpFechaFactura.Name="dtpFechaFactura";
            dtpFechaFactura.Size=new Size(106, 23);
            dtpFechaFactura.TabIndex=0;
            // 
            // dtpFechaPago
            // 
            dtpFechaPago.Format=DateTimePickerFormat.Short;
            dtpFechaPago.Location=new Point(391, 54);
            dtpFechaPago.Name="dtpFechaPago";
            dtpFechaPago.Size=new Size(106, 23);
            dtpFechaPago.TabIndex=2;
            // 
            // txtDescuento
            // 
            txtDescuento.Location=new Point(392, 87);
            txtDescuento.Margin=new Padding(4, 3, 4, 3);
            txtDescuento.Name="txtDescuento";
            txtDescuento.Size=new Size(106, 23);
            txtDescuento.TabIndex=3;
            // 
            // cboCliente
            // 
            cboCliente.DropDownStyle=ComboBoxStyle.DropDownList;
            cboCliente.FormattingEnabled=true;
            cboCliente.Location=new Point(129, 154);
            cboCliente.Margin=new Padding(4, 3, 4, 3);
            cboCliente.Name="cboCliente";
            cboCliente.Size=new Size(368, 23);
            cboCliente.TabIndex=6;
            // 
            // cboFormaEnvio
            // 
            cboFormaEnvio.DropDownStyle=ComboBoxStyle.DropDownList;
            cboFormaEnvio.FormattingEnabled=true;
            cboFormaEnvio.Location=new Point(129, 121);
            cboFormaEnvio.Margin=new Padding(4, 3, 4, 3);
            cboFormaEnvio.Name="cboFormaEnvio";
            cboFormaEnvio.Size=new Size(159, 23);
            cboFormaEnvio.TabIndex=4;
            // 
            // dgvDetalles
            // 
            dgvDetalles.AllowUserToAddRows=false;
            dgvDetalles.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalles.Columns.AddRange(new DataGridViewColumn[] { ID, ColAuto, ColPrecio, ColCantidad, CoSubtotal, ColAcciones });
            dgvDetalles.Location=new Point(12, 255);
            dgvDetalles.Name="dgvDetalles";
            dgvDetalles.ReadOnly=true;
            dgvDetalles.RowTemplate.Height=25;
            dgvDetalles.Size=new Size(554, 150);
            dgvDetalles.TabIndex=67;
            dgvDetalles.CellContentClick+=dgvDetalles_CellContentClick;
            // 
            // ID
            // 
            ID.HeaderText="ID";
            ID.Name="ID";
            ID.ReadOnly=true;
            ID.Visible=false;
            // 
            // ColAuto
            // 
            ColAuto.HeaderText="Auto";
            ColAuto.Name="ColAuto";
            ColAuto.ReadOnly=true;
            ColAuto.Width=140;
            // 
            // ColPrecio
            // 
            ColPrecio.HeaderText="Precio";
            ColPrecio.Name="ColPrecio";
            ColPrecio.ReadOnly=true;
            // 
            // ColCantidad
            // 
            ColCantidad.HeaderText="Cantidad";
            ColCantidad.Name="ColCantidad";
            ColCantidad.ReadOnly=true;
            ColCantidad.Width=70;
            // 
            // CoSubtotal
            // 
            CoSubtotal.HeaderText="Subtotal";
            CoSubtotal.Name="CoSubtotal";
            CoSubtotal.ReadOnly=true;
            // 
            // ColAcciones
            // 
            ColAcciones.HeaderText="Acciones";
            ColAcciones.Name="ColAcciones";
            ColAcciones.ReadOnly=true;
            // 
            // label8
            // 
            label8.AutoSize=true;
            label8.Location=new Point(87, 190);
            label8.Margin=new Padding(4, 0, 4, 0);
            label8.Name="label8";
            label8.Size=new Size(36, 15);
            label8.TabIndex=68;
            label8.Text="Auto:";
            // 
            // cboAuto
            // 
            cboAuto.DropDownStyle=ComboBoxStyle.DropDownList;
            cboAuto.FormattingEnabled=true;
            cboAuto.Location=new Point(129, 187);
            cboAuto.Margin=new Padding(4, 3, 4, 3);
            cboAuto.Name="cboAuto";
            cboAuto.Size=new Size(368, 23);
            cboAuto.TabIndex=7;
            // 
            // txtCantidad
            // 
            txtCantidad.Location=new Point(129, 219);
            txtCantidad.Margin=new Padding(4, 3, 4, 3);
            txtCantidad.Name="txtCantidad";
            txtCantidad.Size=new Size(279, 23);
            txtCantidad.TabIndex=8;
            // 
            // label9
            // 
            label9.AutoSize=true;
            label9.Location=new Point(65, 223);
            label9.Margin=new Padding(4, 0, 4, 0);
            label9.Name="label9";
            label9.Size=new Size(58, 15);
            label9.TabIndex=70;
            label9.Text="Cantidad:";
            // 
            // btnAgregar
            // 
            btnAgregar.Font=new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAgregar.Location=new Point(415, 219);
            btnAgregar.Name="btnAgregar";
            btnAgregar.Size=new Size(83, 23);
            btnAgregar.TabIndex=9;
            btnAgregar.Text="Agregar";
            btnAgregar.UseVisualStyleBackColor=true;
            btnAgregar.Click+=btnAgregar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font=new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.Image=Properties.Resources.CANELARR__1_;
            btnCancelar.Location=new Point(296, 469);
            btnCancelar.Margin=new Padding(4, 3, 4, 3);
            btnCancelar.Name="btnCancelar";
            btnCancelar.Size=new Size(90, 27);
            btnCancelar.TabIndex=11;
            btnCancelar.UseVisualStyleBackColor=true;
            btnCancelar.Click+=btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Font=new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAceptar.Image=Properties.Resources.ACEPTAR__1___1_;
            btnAceptar.Location=new Point(198, 469);
            btnAceptar.Margin=new Padding(4, 3, 4, 3);
            btnAceptar.Name="btnAceptar";
            btnAceptar.Size=new Size(90, 27);
            btnAceptar.TabIndex=10;
            btnAceptar.UseVisualStyleBackColor=true;
            btnAceptar.Click+=btnAceptar_Click;
            // 
            // txtTotal
            // 
            txtTotal.Enabled=false;
            txtTotal.Location=new Point(449, 434);
            txtTotal.Margin=new Padding(4, 3, 4, 3);
            txtTotal.Name="txtTotal";
            txtTotal.Size=new Size(116, 23);
            txtTotal.TabIndex=76;
            // 
            // label10
            // 
            label10.AutoSize=true;
            label10.Location=new Point(392, 437);
            label10.Margin=new Padding(4, 0, 4, 0);
            label10.Name="label10";
            label10.Size=new Size(41, 15);
            label10.TabIndex=74;
            label10.Text="Total $";
            // 
            // label13
            // 
            label13.AutoSize=true;
            label13.Location=new Point(238, 90);
            label13.Margin=new Padding(4, 0, 4, 0);
            label13.Name="label13";
            label13.Size=new Size(17, 15);
            label13.TabIndex=79;
            label13.Text="%";
            // 
            // label14
            // 
            label14.AutoSize=true;
            label14.Location=new Point(506, 90);
            label14.Margin=new Padding(4, 0, 4, 0);
            label14.Name="label14";
            label14.Size=new Size(17, 15);
            label14.TabIndex=80;
            label14.Text="%";
            // 
            // FrmNuevaFactura
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.White;
            ClientSize=new Size(578, 523);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtTotal);
            Controls.Add(label10);
            Controls.Add(btnAgregar);
            Controls.Add(txtCantidad);
            Controls.Add(label9);
            Controls.Add(cboAuto);
            Controls.Add(label8);
            Controls.Add(dgvDetalles);
            Controls.Add(cboFormaEnvio);
            Controls.Add(txtDescuento);
            Controls.Add(dtpFechaPago);
            Controls.Add(dtpFechaFactura);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lblFacturaNro);
            Controls.Add(label5);
            Controls.Add(cboCliente);
            Controls.Add(txtInteres);
            Controls.Add(label12);
            Controls.Add(cboFormaPago);
            Controls.Add(label1);
            Icon=(Icon)resources.GetObject("$this.Icon");
            Name="FrmNuevaFactura";
            StartPosition=FormStartPosition.CenterScreen;
            Text="Factura Auto Nueva";
            Load+=FrmNuevaFactura_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalles).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private ComboBox cboTipo;
        private TextBox txtInteres;
        private Label label12;
        private ComboBox cboFormaPago;
        private Label label1;
        private Label lblFacturaNro;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private DateTimePicker dtpFechaFactura;
        private DateTimePicker dtpFechaPago;
        private TextBox txtDescuento;
        private ComboBox cboCliente;
        private ComboBox cboFormaEnvio;
        private DataGridView dgvDetalles;
        private Label label8;
        private ComboBox cboAuto;
        private TextBox txtCantidad;
        private Label label9;
        private Button btnAgregar;
        private Button btnCancelar;
        private Button btnAceptar;
        private TextBox txtTotal;
        private Label label10;
        private Label label13;
        private Label label14;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn ColAuto;
        private DataGridViewTextBoxColumn ColPrecio;
        private DataGridViewTextBoxColumn ColCantidad;
        private DataGridViewTextBoxColumn CoSubtotal;
        private DataGridViewButtonColumn ColAcciones;
    }
}