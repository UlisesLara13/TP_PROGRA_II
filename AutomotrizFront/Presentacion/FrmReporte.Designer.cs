namespace AutomotrizFront.Presentacion
{
    partial class FrmReporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporte));
            rpvReporte=new Microsoft.Reporting.WinForms.ReportViewer();
            label1=new Label();
            label2=new Label();
            gpxFiltros=new GroupBox();
            label3=new Label();
            dtpFechaHasta=new DateTimePicker();
            dtpFechaDesde=new DateTimePicker();
            btnGenerar=new Button();
            gpxFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // rpvReporte
            // 
            rpvReporte.AllowDrop=true;
            rpvReporte.Anchor=AnchorStyles.Top|AnchorStyles.Bottom|AnchorStyles.Left|AnchorStyles.Right;
            rpvReporte.Location=new Point(10, 100);
            rpvReporte.Name="ReportViewer";
            rpvReporte.ServerReport.BearerToken=null;
            rpvReporte.Size=new Size(649, 482);
            rpvReporte.TabIndex=0;
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(169, 158);
            label1.Name="label1";
            label1.Size=new Size(48, 20);
            label1.TabIndex=0;
            label1.Text="label1";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Font=new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location=new Point(264, 35);
            label2.Name="label2";
            label2.Size=new Size(83, 17);
            label2.TabIndex=2;
            label2.Text="Fecha hasta:";
            // 
            // gpxFiltros
            // 
            gpxFiltros.Controls.Add(label3);
            gpxFiltros.Controls.Add(dtpFechaHasta);
            gpxFiltros.Controls.Add(dtpFechaDesde);
            gpxFiltros.Controls.Add(btnGenerar);
            gpxFiltros.Controls.Add(label2);
            gpxFiltros.Controls.Add(label1);
            gpxFiltros.Font=new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            gpxFiltros.Location=new Point(18, 10);
            gpxFiltros.Name="gpxFiltros";
            gpxFiltros.Size=new Size(639, 81);
            gpxFiltros.TabIndex=3;
            gpxFiltros.TabStop=false;
            gpxFiltros.Text="Filtros";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Font=new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location=new Point(60, 35);
            label3.Name="label3";
            label3.Size=new Size(86, 17);
            label3.TabIndex=6;
            label3.Text="Fecha desde:";
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Font=new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dtpFechaHasta.Format=DateTimePickerFormat.Short;
            dtpFechaHasta.Location=new Point(353, 31);
            dtpFechaHasta.Name="dtpFechaHasta";
            dtpFechaHasta.Size=new Size(102, 25);
            dtpFechaHasta.TabIndex=1;
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Font=new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dtpFechaDesde.Format=DateTimePickerFormat.Short;
            dtpFechaDesde.Location=new Point(152, 31);
            dtpFechaDesde.Name="dtpFechaDesde";
            dtpFechaDesde.Size=new Size(102, 25);
            dtpFechaDesde.TabIndex=0;
            // 
            // btnGenerar
            // 
            btnGenerar.Location=new Point(504, 26);
            btnGenerar.Name="btnGenerar";
            btnGenerar.Size=new Size(103, 33);
            btnGenerar.TabIndex=2;
            btnGenerar.Text="Generar";
            btnGenerar.UseVisualStyleBackColor=true;
            btnGenerar.Click+=btnGenerar_Click;
            // 
            // FrmReporte
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.White;
            ClientSize=new Size(675, 593);
            Controls.Add(gpxFiltros);
            Controls.Add(rpvReporte);
            Icon=(Icon)resources.GetObject("$this.Icon");
            Location=new Point(10, 100);
            MaximumSize=new Size(691, 632);
            Name="FrmReporte";
            StartPosition=FormStartPosition.CenterScreen;
            Text="Reporte";
            Load+=FrmReporte_Load;
            gpxFiltros.ResumeLayout(false);
            gpxFiltros.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvReporte;
        private Label label1;
        private Label label2;
        private GroupBox gpxFiltros;
        private Button btnGenerar;
        private DateTimePicker dtpFechaHasta;
        private DateTimePicker dtpFechaDesde;
        private Label label3;
    }
}