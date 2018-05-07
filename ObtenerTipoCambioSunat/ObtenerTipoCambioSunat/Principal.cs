using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObtenerTipoCambioSunat
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(new Uri("http://www.sunat.gob.pe/cl-at-ittipcam/tcS01Alias"));
            comboBox1.SelectedIndex = (DateTime.Now.Month - 1);
            numericUpDown1.Value = DateTime.Now.Year;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            dataGridView1.Rows.Clear();

            string str = webBrowser1.Document.Body.OuterText;
            int x = 0;
            string vi_mes = "";
            string vi_periodo = "";

            foreach (var linea in str.Split('\r'))
            {
                if (x == 0)
                {
                    if (linea.IndexOf('-') > 0)
                    {
                        vi_mes = linea.Substring(0, linea.IndexOf('-') - 1).ToUpper().MonthGet().ToString();
                        vi_periodo = linea.Right(4);
                    }
                    break;
                }
            }

            DateTime vi_fch_inicio = new DateTime(int.Parse(vi_periodo), int.Parse(vi_mes), 1);
            DateTime vi_fch_termin = vi_fch_inicio.AddMonths(1).AddDays(-1);

            while (vi_fch_inicio<=vi_fch_termin) {
                dataGridView1.Rows.Add(vi_fch_inicio.ToShortDateString(), 0.000, 0.000);
                vi_fch_inicio = vi_fch_inicio.AddDays(1);
            }

            //MessageBox.Show(str);

        }
    }
}
