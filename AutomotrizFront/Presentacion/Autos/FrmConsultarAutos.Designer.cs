namespace AutomotrizFront.Presentacion
{
    partial class FrmConsultarAutos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultarAutos));
            btnSalir=new Button();
            dgvAutos=new DataGridView();
            lblMarca=new Label();
            cboMarca=new ComboBox();
            btnConsultar=new Button();
            groupBox1=new GroupBox();
            pbToyota=new PictureBox();
            pbVolks=new PictureBox();
            pbFord=new PictureBox();
            pbHonda=new PictureBox();
            pbNissan=new PictureBox();
            btnNuevo=new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAutos).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbToyota).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbVolks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFord).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbHonda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbNissan).BeginInit();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Image=Properties.Resources.SALRR__1_;
            btnSalir.Location=new Point(607, 428);
            btnSalir.Name="btnSalir";
            btnSalir.Size=new Size(107, 44);
            btnSalir.TabIndex=1;
            btnSalir.UseVisualStyleBackColor=true;
            btnSalir.Click+=button1_Click_1;
            // 
            // dgvAutos
            // 
            dgvAutos.AllowUserToAddRows=false;
            dgvAutos.ColumnHeadersHeightSizeMode=DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAutos.Location=new Point(40, 101);
            dgvAutos.Name="dgvAutos";
            dgvAutos.ReadOnly=true;
            dgvAutos.RowTemplate.Height=25;
            dgvAutos.Size=new Size(674, 315);
            dgvAutos.TabIndex=4;
            dgvAutos.CellContentClick+=dgvAutos_CellContentClickAsync;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize=true;
            lblMarca.Location=new Point(20, 26);
            lblMarca.Name="lblMarca";
            lblMarca.Size=new Size(48, 17);
            lblMarca.TabIndex=6;
            lblMarca.Text="Marca:";
            // 
            // cboMarca
            // 
            cboMarca.DropDownStyle=ComboBoxStyle.DropDownList;
            cboMarca.FormattingEnabled=true;
            cboMarca.Location=new Point(73, 23);
            cboMarca.Name="cboMarca";
            cboMarca.Size=new Size(160, 25);
            cboMarca.TabIndex=0;
            cboMarca.SelectedIndexChanged+=cboMarca_SelectedIndexChanged;
            // 
            // btnConsultar
            // 
            btnConsultar.Font=new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btnConsultar.Location=new Point(239, 23);
            btnConsultar.Name="btnConsultar";
            btnConsultar.Size=new Size(75, 25);
            btnConsultar.TabIndex=1;
            btnConsultar.Text="Consultar";
            btnConsultar.UseVisualStyleBackColor=true;
            btnConsultar.Click+=btnConsultar_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnConsultar);
            groupBox1.Controls.Add(cboMarca);
            groupBox1.Controls.Add(lblMarca);
            groupBox1.Font=new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location=new Point(40, 20);
            groupBox1.Name="groupBox1";
            groupBox1.Size=new Size(339, 60);
            groupBox1.TabIndex=9;
            groupBox1.TabStop=false;
            groupBox1.Text="Filtros";
            // 
            // pbToyota
            // 
            pbToyota.Image=Properties.Resources.toyota;
            pbToyota.Location=new Point(591, 15);
            pbToyota.Name="pbToyota";
            pbToyota.Size=new Size(123, 74);
            pbToyota.SizeMode=PictureBoxSizeMode.StretchImage;
            pbToyota.TabIndex=10;
            pbToyota.TabStop=false;
            // 
            // pbVolks
            // 
            pbVolks.Image=Properties.Resources.volks;
            pbVolks.Location=new Point(621, 24);
            pbVolks.Name="pbVolks";
            pbVolks.Size=new Size(74, 60);
            pbVolks.SizeMode=PictureBoxSizeMode.StretchImage;
            pbVolks.TabIndex=11;
            pbVolks.TabStop=false;
            // 
            // pbFord
            // 
            pbFord.Image=Properties.Resources.Ford;
            pbFord.Location=new Point(595, 33);
            pbFord.Name="pbFord";
            pbFord.Size=new Size(100, 50);
            pbFord.SizeMode=PictureBoxSizeMode.StretchImage;
            pbFord.TabIndex=12;
            pbFord.TabStop=false;
            // 
            // pbHonda
            // 
            pbHonda.Image=Properties.Resources.honda;
            pbHonda.Location=new Point(599, 18);
            pbHonda.Name="pbHonda";
            pbHonda.Size=new Size(106, 71);
            pbHonda.SizeMode=PictureBoxSizeMode.StretchImage;
            pbHonda.TabIndex=13;
            pbHonda.TabStop=false;
            // 
            // pbNissan
            // 
            pbNissan.Image=Properties.Resources.nissan;
            pbNissan.Location=new Point(605, 20);
            pbNissan.Name="pbNissan";
            pbNissan.Size=new Size(100, 66);
            pbNissan.SizeMode=PictureBoxSizeMode.StretchImage;
            pbNissan.TabIndex=14;
            pbNissan.TabStop=false;
            // 
            // btnNuevo
            // 
            btnNuevo.Image=Properties.Resources.NUEVO__1_2;
            btnNuevo.Location=new Point(494, 428);
            btnNuevo.Name="btnNuevo";
            btnNuevo.Size=new Size(107, 44);
            btnNuevo.TabIndex=0;
            btnNuevo.UseVisualStyleBackColor=true;
            btnNuevo.Click+=btnNuevo_Click;
            // 
            // FrmConsultarAutos
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.White;
            ClientSize=new Size(738, 489);
            Controls.Add(btnNuevo);
            Controls.Add(pbNissan);
            Controls.Add(pbHonda);
            Controls.Add(pbFord);
            Controls.Add(pbVolks);
            Controls.Add(pbToyota);
            Controls.Add(groupBox1);
            Controls.Add(dgvAutos);
            Controls.Add(btnSalir);
            Icon=(Icon)resources.GetObject("$this.Icon");
            Name="FrmConsultarAutos";
            StartPosition=FormStartPosition.CenterParent;
            Text="Consultar Automoviles";
            Load+=FrConsultar_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAutos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbToyota).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbVolks).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFord).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbHonda).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbNissan).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnSalir;
        private DataGridView dgvAutos;
        private Label lblMarca;
        private ComboBox cboMarca;
        private Button btnConsultar;
        private GroupBox groupBox1;
        private PictureBox pbToyota;
        private PictureBox pbVolks;
        private PictureBox pbFord;
        private PictureBox pbHonda;
        private PictureBox pbNissan;
        private Button btnNuevo;
    }
}