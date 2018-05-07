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
        }
    }
}
