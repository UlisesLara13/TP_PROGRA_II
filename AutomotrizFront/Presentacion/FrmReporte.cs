using AutomotrizBack.Datos;
using Microsoft.Reporting.WinForms;
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

namespace AutomotrizFront.Presentacion
{
    public partial class FrmReporte : Form
    {
        public FrmReporte()
        {
            InitializeComponent();
        }

        private void FrmReporte_Load(object sender, EventArgs e)
        {
            rpvReporte.LocalReport.ReportEmbeddedResource = "AutomotrizFront.Reporte.ReporteAutomotriz.rdlc";
            rpvReporte.LocalReport.ReportPath = @"C:\Users\Ulises\Desktop\prueba\TP Final\AutomotrizApp\AutomotrizFront\Reporte\ReporteAutomotriz.rdlc";
        }


        private void btnGenerar_Click(object sender, EventArgs e)
        {
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@fechaDesde", dtpFechaDesde.Value));
            lst.Add(new Parametro("@fechaHasta", dtpFechaHasta.Value));
            DataTable tabla = HelperDAO.ObtenerInstancia().ConsultarFechas("SP_MARCA_AUTO_MAS_VENDIDAS", lst);

            rpvReporte.LocalReport.DataSources.Add(new
                           ReportDataSource("DataSet1", HelperDAO.ObtenerInstancia().ConsultarFechas("SP_MARCA_AUTO_MAS_VENDIDAS", lst)));


            rpvReporte.RefreshReport();
        }
    }
}
