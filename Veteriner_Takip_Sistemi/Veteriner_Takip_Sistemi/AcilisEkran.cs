using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veteriner_Takip_Sistemi
{
    public partial class AcilisEkran : Form
    {
        public AcilisEkran()
        {
            InitializeComponent();
        }

        int sayac = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac = sayac + 1;

            if (sayac == 3)
            {
                timer1.Enabled = false;
                this.Close();
            }
        }
    }
}
