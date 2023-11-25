namespace AutomotrizFront.Consultas
{
    partial class FrmConsultas
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
            components = new System.ComponentModel.Container();
            dgvConsulta = new DataGridView();
            cboCliente = new ComboBox();
            dtpDesde = new DateTimePicker();
            dtpHasta = new DateTimePicker();
            servicioBindingSource = new BindingSource(components);
            frmConsultasBindingSource = new BindingSource(components);
            btnConsultar = new Button();
            rbTotalPromedio = new RadioButton();
            rbConsumidoresFinales = new RadioButton();
            rbNoVendidos = new RadioButton();
            rbTotalVenta = new RadioButton();
            lblDesde = new Label();
            lblHasta = new Label();
            lblCliente = new Label();
            button1 = new Button();
            groupBox1 = new GroupBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvConsulta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)servicioBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)frmConsultasBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvConsulta
            // 
            dgvConsulta.AllowUserToAddRows = false;
            dgvConsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsulta.Location = new Point(12, 277);
            dgvConsulta.Name = "dgvConsulta";
            dgvConsulta.ReadOnly = true;
            dgvConsulta.RowTemplate.Height = 25;
            dgvConsulta.Size = new Size(726, 143);
            dgvConsulta.TabIndex = 0;
            dgvConsulta.CellContentClick += dataGridView1_CellContentClick;
            // 
            // cboCliente
            // 
            cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCliente.FormattingEnabled = true;
            cboCliente.Location = new Point(341, 207);
            cboCliente.Name = "cboCliente";
            cboCliente.Size = new Size(239, 23);
            cboCliente.TabIndex = 1;
            cboCliente.SelectedIndexChanged += cboCliente_SelectedIndexChanged;
            // 
            // dtpDesde
            // 
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(179, 207);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(86, 23);
            dtpDesde.TabIndex = 2;
            dtpDesde.Value = new DateTime(2023, 11, 1, 0, 0, 0, 0);
            // 
            // dtpHasta
            // 
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(178, 235);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(87, 23);
            dtpHasta.TabIndex = 3;
            dtpHasta.ValueChanged += dtpHasta_ValueChanged;
            // 
            // servicioBindingSource
            // 
            servicioBindingSource.DataSource = typeof(Servicios.Implementacion.Servicio);
            // 
            // frmConsultasBindingSource
            // 
            frmConsultasBindingSource.DataSource = typeof(FrmConsultas);
            // 
            // btnConsultar
            // 
            btnConsultar.Font = new Font("Gadugi", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnConsultar.Location = new Point(619, 203);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(87, 30);
            btnConsultar.TabIndex = 7;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += button3_Click;
            // 
            // rbTotalPromedio
            // 
            rbTotalPromedio.AutoSize = true;
            rbTotalPromedio.Location = new Point(61, 38);
            rbTotalPromedio.Name = "rbTotalPromedio";
            rbTotalPromedio.Size = new Size(416, 24);
            rbTotalPromedio.TabIndex = 8;
            rbTotalPromedio.TabStop = true;
            rbTotalPromedio.Text = "Total y promedio en un  periodo de Facturación de Autos";
            rbTotalPromedio.UseVisualStyleBackColor = true;
            rbTotalPromedio.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // rbConsumidoresFinales
            // 
            rbConsumidoresFinales.AutoSize = true;
            rbConsumidoresFinales.Location = new Point(61, 63);
            rbConsumidoresFinales.Name = "rbConsumidoresFinales";
            rbConsumidoresFinales.Size = new Size(518, 24);
            rbConsumidoresFinales.TabIndex = 9;
            rbConsumidoresFinales.TabStop = true;
            rbConsumidoresFinales.Text = "Listar Consumidores Finales con total de Facturación mayor al Promedio";
            rbConsumidoresFinales.UseVisualStyleBackColor = true;
            rbConsumidoresFinales.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // rbNoVendidos
            // 
            rbNoVendidos.AutoSize = true;
            rbNoVendidos.Location = new Point(61, 88);
            rbNoVendidos.Name = "rbNoVendidos";
            rbNoVendidos.Size = new Size(195, 24);
            rbNoVendidos.TabIndex = 10;
            rbNoVendidos.TabStop = true;
            rbNoVendidos.Text = "Listar Autos no Vendidos";
            rbNoVendidos.UseVisualStyleBackColor = true;
            rbNoVendidos.CheckedChanged += radioButton3_CheckedChanged;
            // 
            // rbTotalVenta
            // 
            rbTotalVenta.AutoSize = true;
            rbTotalVenta.Location = new Point(61, 113);
            rbTotalVenta.Name = "rbTotalVenta";
            rbTotalVenta.Size = new Size(330, 24);
            rbTotalVenta.TabIndex = 11;
            rbTotalVenta.TabStop = true;
            rbTotalVenta.Text = "Monto total de la venta de Autos por Cliente";
            rbTotalVenta.UseVisualStyleBackColor = true;
            rbTotalVenta.CheckedChanged += radioButton4_CheckedChanged;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblDesde.Location = new Point(124, 210);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(48, 17);
            lblDesde.TabIndex = 13;
            lblDesde.Text = "Desde:";
            lblDesde.Click += label2_Click;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            lblHasta.Location = new Point(126, 239);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(46, 17);
            lblHasta.TabIndex = 14;
            lblHasta.Text = "Hasta:";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblCliente.Location = new Point(286, 211);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(51, 15);
            lblCliente.TabIndex = 15;
            lblCliente.Text = "Clientes:";
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Image = Properties.Resources.salir_removebg_preview1;
            button1.Location = new Point(688, 426);
            button1.Name = "button1";
            button1.Size = new Size(50, 42);
            button1.TabIndex = 16;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(rbTotalVenta);
            groupBox1.Controls.Add(rbTotalPromedio);
            groupBox1.Controls.Add(rbConsumidoresFinales);
            groupBox1.Controls.Add(rbNoVendidos);
            groupBox1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(50, 31);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(656, 164);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "Consultas";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(50, 210);
            label1.Name = "label1";
            label1.Size = new Size(48, 17);
            label1.TabIndex = 18;
            label1.Text = "Filtros:";
            // 
            // FrmConsultas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(762, 480);
            Controls.Add(lblCliente);
            Controls.Add(cboCliente);
            Controls.Add(label1);
            Controls.Add(lblHasta);
            Controls.Add(lblDesde);
            Controls.Add(dtpHasta);
            Controls.Add(dtpDesde);
            Controls.Add(btnConsultar);
            Controls.Add(button1);
            Controls.Add(dgvConsulta);
            Controls.Add(groupBox1);
            Name = "FrmConsultas";
            Text = "Consultas";
            TransparencyKey = Color.WhiteSmoke;
            Load += FrmConsultas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvConsulta).EndInit();
            ((System.ComponentModel.ISupportInitialize)servicioBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)frmConsultasBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvConsulta;
        private ComboBox cboCliente;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Button button1;
        private Button button2;
        private BindingSource servicioBindingSource;
        private BindingSource frmConsultasBindingSource;
        private Button btnConsultar;
        private RadioButton rbTotalPromedio;
        private RadioButton rbConsumidoresFinales;
        private RadioButton rbNoVendidos;
        private RadioButton rbTotalVenta;
        private Label lblDesde;
        private Label lblHasta;
        private Label lblCliente;
        private GroupBox groupBox1;
        private Label label1;
    }
}