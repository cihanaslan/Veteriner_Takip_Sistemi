using FontAwesome.Sharp;
using Npgsql;
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
    public partial class HastaKayit : Form
    {
        public HastaKayit()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=vtsDB; user ID=postgres; password=1234");

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSahipTc.Text == "" || txtAd.Text == "")
                {
                    MessageBox.Show("Gerekli Alanları Doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    baglanti.Open();
                    NpgsqlCommand kmt1 = new NpgsqlCommand("insert into hasta_kayit(sahip_tc,adi,dogum_tarihi,tur,irk,cinsiyet,rengi,agirlik,allerji,asi_ismi,asi_suresi,asi_adet,asi_not) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13)", baglanti);
                    kmt1.Parameters.AddWithValue("@p1", txtSahipTc.Text);
                    kmt1.Parameters.AddWithValue("@p2", txtAd.Text);
                    kmt1.Parameters.AddWithValue("@p3", Convert.ToDateTime(dateDogumTarih.Text));
                    kmt1.Parameters.AddWithValue("@p4", comboTur.Text);
                    kmt1.Parameters.AddWithValue("@p5", txtIrk.Text);
                    kmt1.Parameters.AddWithValue("@p6", comboCinsiyet.Text);
                    kmt1.Parameters.AddWithValue("@p7", txtRenk.Text);
                    kmt1.Parameters.AddWithValue("@p8", Convert.ToInt32(txtAgirlik.Text));
                    kmt1.Parameters.AddWithValue("@p9", txtAllerji.Text);
                    kmt1.Parameters.AddWithValue("@p10", txtAsiİsmi.Text);
                    kmt1.Parameters.AddWithValue("@p11", Convert.ToInt32(txtEtkinSure.Text));
                    kmt1.Parameters.AddWithValue("@p12", Convert.ToInt32(txtAdet.Text));
                    kmt1.Parameters.AddWithValue("@p13", txtNot.Text);
                    kmt1.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Hasta Ekleme İşlemi Başarılı.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ekranTemizle();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void ekranTemizle()
        {
            for (int j = 0; j < this.Controls.Count; j++)
            {
                if (Controls[j] is TextBox || Controls[j] is ComboBox || Controls[j] is DateTimePicker)
                {
                    Controls[j].Text = "";
                }
            }
        }

        private void txtSahipTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtAgirlik_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtEtkinSure_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtAdet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
