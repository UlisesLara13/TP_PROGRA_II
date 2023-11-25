namespace AutomotrizFront.Presentacion
{
    partial class FrmConsultarFacturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultarFacturas));
            btnSalir=new Button();
            dgvFacturas=new DataGridView();
            dtpDesde=new DateTimePicker();
            dtpHasta=new DateTimePicker();
            label1=new Label();
            label2=new Label();
            btnConsultar=new Button();
            cboCliente=new ComboBox();
            label3=new Label();
            groupBox1=new GroupBox();
            btnNuevo=new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Image=Properties.Resources.SALRR__1_;
            btnSalir.Location=new Point(652, 409);
            btnSalir.Name="btnSalir";
            btnSalir.Size=new Size(107, 44);
            btnSalir.TabIndex=1;
            btnSalir.UseVisualStyleBackColor=true;
            btnSalir.Click+=btnSalir_Click;
            // 
            // dgvFacturas
            // 
            dgvFacturas.AllowUserToAddRows=false;
            dgvFacturas.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Location=new Point(24, 138);
            dgvFacturas.Name="dgvFacturas";
            dgvFacturas.ReadOnly=true;
            dgvFacturas.RowTemplate.Height=25;
            dgvFacturas.Size=new Size(735, 264);
            dgvFacturas.TabIndex=2;
            dgvFacturas.CellContentClick+=dgvFacturas_CellContentClick;
            // 
            // dtpDesde
            // 
            dtpDesde.Format=DateTimePickerFormat.Short;
            dtpDesde.Location=new Point(72, 65);
            dtpDesde.Name="dtpDesde";
            dtpDesde.Size=new Size(200, 23);
            dtpDesde.TabIndex=1;
            // 
            // dtpHasta
            // 
            dtpHasta.Format=DateTimePickerFormat.Short;
            dtpHasta.Location=new Point(368, 65);
            dtpHasta.Name="dtpHasta";
            dtpHasta.Size=new Size(200, 23);
            dtpHasta.TabIndex=2;
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(26, 69);
            label1.Name="label1";
            label1.Size=new Size(42, 15);
            label1.TabIndex=5;
            label1.Text="Desde:";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(322, 69);
            label2.Name="label2";
            label2.Size=new Size(40, 15);
            label2.TabIndex=6;
            label2.Text="Hasta:";
            // 
            // btnConsultar
            // 
            btnConsultar.Location=new Point(587, 65);
            btnConsultar.Name="btnConsultar";
            btnConsultar.Size=new Size(100, 23);
            btnConsultar.TabIndex=3;
            btnConsultar.Text="Consultar";
            btnConsultar.UseVisualStyleBackColor=true;
            btnConsultar.Click+=btnConsultar_Click;
            // 
            // cboCliente
            // 
            cboCliente.DropDownStyle=ComboBoxStyle.DropDownList;
            cboCliente.FormattingEnabled=true;
            cboCliente.Location=new Point(71, 27);
            cboCliente.Name="cboCliente";
            cboCliente.Size=new Size(200, 23);
            cboCliente.TabIndex=0;
            cboCliente.SelectedIndexChanged+=cboCliente_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(20, 30);
            label3.Name="label3";
            label3.Size=new Size(47, 15);
            label3.TabIndex=9;
            label3.Text="Cliente:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(cboCliente);
            groupBox1.Controls.Add(btnConsultar);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dtpHasta);
            groupBox1.Controls.Add(dtpDesde);
            groupBox1.Location=new Point(20, 13);
            groupBox1.Name="groupBox1";
            groupBox1.Size=new Size(739, 106);
            groupBox1.TabIndex=10;
            groupBox1.TabStop=false;
            groupBox1.Text="Filtros";
            // 
            // btnNuevo
            // 
            btnNuevo.Image=Properties.Resources.NUEVO__1_2;
            btnNuevo.Location=new Point(539, 409);
            btnNuevo.Name="btnNuevo";
            btnNuevo.Size=new Size(107, 44);
            btnNuevo.TabIndex=0;
            btnNuevo.UseVisualStyleBackColor=true;
            btnNuevo.Click+=btnNuevo_Click;
            // 
            // FrmConsultarFacturas
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.White;
            ClientSize=new Size(779, 469);
            Controls.Add(btnNuevo);
            Controls.Add(groupBox1);
            Controls.Add(dgvFacturas);
            Controls.Add(btnSalir);
            Icon=(Icon)resources.GetObject("$this.Icon");
            Name="FrmConsultarFacturas";
            StartPosition=FormStartPosition.CenterScreen;
            Text="Consultar Factura";
            Load+=FrmConsultarFacturas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnSalir;
        private DataGridView dgvFacturas;
        private DateTimePicker dtpDesde;
        private DateTimePicker dtpHasta;
        private Label label1;
        private Label label2;
        private Button btnConsultar;
        private ComboBox cboCliente;
        private Label label3;
        private GroupBox groupBox1;
        private Button btnNuevo;
    }
}