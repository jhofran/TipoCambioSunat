using System;
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

            while (vi_fch_inicio <= vi_fch_termin)
            {
                dataGridView1.Rows.Add(vi_fch_inicio.ToShortDateString(), 0.0d, 0.0d);
                vi_fch_inicio = vi_fch_inicio.AddDays(1);
            }

            HtmlElementCollection pulledtags = webBrowser1.Document.GetElementsByTagName("td");
            int n_r = 0;
            int n_fila_ult = -1;
            int n_fila_grid = dataGridView1.RowCount;

            foreach (HtmlElement item in pulledtags)
            {
                if (item.OuterHtml.IndexOf("class=H3") > 0)
                {
                    for (x = n_fila_ult; x <= n_fila_grid - 1; x++)
                    {
                        n_fila_ult += 1;
                        if (dataGridView1.Rows[n_fila_ult].Cells[0].Value.Equals(item.InnerText.Trim().PadLeft(2, '0') + '/' + vi_mes.PadLeft(2, '0') + '/' + vi_periodo))
                        {
                            break;
                        }
                    }
                }

                if (item.OuterHtml.IndexOf("class=tne10") > 0)
                {
                    if (n_r == 0)
                    {
                        dataGridView1.Rows[n_fila_ult].Cells[1].Value = item.InnerText;
                        n_r += 1;
                    }
                    else
                    {
                        dataGridView1.Rows[n_fila_ult].Cells[2].Value = item.InnerText;
                        n_r = 0;
                    }
                }
            }

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.GetElementById("mes").SetAttribute("value", (comboBox1.SelectedIndex + 1).ToString().PadLeft(2, '0'));
            webBrowser1.Document.GetElementById("anho").SetAttribute("value", numericUpDown1.Value.ToString());
            webBrowser1.Document.GetElementById("B1").InvokeMember("Click");
        }
    }
}
