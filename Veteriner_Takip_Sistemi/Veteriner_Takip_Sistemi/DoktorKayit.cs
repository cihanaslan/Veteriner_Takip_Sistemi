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
    public partial class DoktorKayit : Form
    {
        public DoktorKayit()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=vtsDB; user ID=postgres; password=1234");

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAd.Text == "" || txtTC.Text == "")
                {
                    MessageBox.Show("Gerekli Alanları Doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (VarMi(txtTC.Text) != 0)
                    {
                        MessageBox.Show("Bu Doktor Zaten Kayıtlı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        baglanti.Open();
                        NpgsqlCommand kmt1 = new NpgsqlCommand("insert into doktor_kayit(tc,ad,soyad,cinsiyet,telefon,email) values(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
                        kmt1.Parameters.AddWithValue("@p1", txtTC.Text);
                        kmt1.Parameters.AddWithValue("@p2", txtAd.Text);
                        kmt1.Parameters.AddWithValue("@p3", txtSoyad.Text);
                        kmt1.Parameters.AddWithValue("@p4", comboCinsiyet.Text);
                        kmt1.Parameters.AddWithValue("@p5", txtTel.Text);
                        kmt1.Parameters.AddWithValue("@p6", txtMail.Text);
                        kmt1.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Doktor Ekleme İşlemi Başarılı.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ekranTemizle();
                    }
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

        public int VarMi(string aranan)
        {            
            int sonuc;

            baglanti.Open();
            NpgsqlCommand sorgu = new NpgsqlCommand("select count(tc) from doktor_kayit where tc='" + aranan + "'", baglanti);
            sorgu.ExecuteNonQuery();
            sonuc = Convert.ToInt32(sorgu.ExecuteScalar());
            baglanti.Close();

            return sonuc;
        }

        private void txtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}
