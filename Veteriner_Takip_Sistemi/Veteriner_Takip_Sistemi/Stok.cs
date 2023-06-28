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
    public partial class Stok : Form
    {
        public Stok()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=vtsDB; user ID=postgres; password=1234");
        string adet;

        private void stoklistele()
        {
            try
            {
                string sorgu = "select * from stok";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }

            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void urunsil(string kimlik)
        {
            try
            {
                string sorgu = "delete from stok where urun_kodu=@p1";
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", kimlik);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ürün Silme İşlemi Başarılı.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ekranTemizle();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void urunguncelle(string kimlik)
        {
            try
            {
                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("select * from stok where urun_kodu= '" + txtUrunKodu.Text + "' ", baglanti);
                //select * from uye where tc like '"+ txtTCara.Text +"', baglanti);
                NpgsqlDataReader read = komut.ExecuteReader();

                while (read.Read())
                {
                    adet = read["urun_adet"].ToString();
                }
                read.Close();
                baglanti.Close();

                double sonFiyat = Convert.ToInt32(txtFiyat.Text) + (Convert.ToInt64(txtFiyat.Text) * 0.20);
                NpgsqlCommand kmt2 = new NpgsqlCommand("update stok set urun_adi=@p2,urun_fiyat=@p3,urun_adet=@p4,urun_son_fiyat=@p5 where urun_kodu=@p1", baglanti);
                kmt2.Parameters.AddWithValue("@p1", kimlik);
                kmt2.Parameters.AddWithValue("@p2", txtUrunAdi.Text);
                kmt2.Parameters.AddWithValue("@p3", Convert.ToInt32(txtFiyat.Text));
                kmt2.Parameters.AddWithValue("@p4", Convert.ToInt32(txtAdet.Text));
                kmt2.Parameters.AddWithValue("@p5", sonFiyat);

                baglanti.Open();
                kmt2.ExecuteNonQuery();
                baglanti.Close();

                double mevcutAdet = Convert.ToInt64(adet);
                double yeniAdet = mevcutAdet - Convert.ToInt64(txtAdet.Text);
                yeniAdet=Math.Abs(yeniAdet);

                if (Convert.ToInt64(txtAdet.Text) < mevcutAdet)
                {
                    MessageBox.Show("Stoktan ürün eksildi. Satış işlemi olarak değerlendirilmedi.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }

                else
                {
                    double harcananFiyat = Convert.ToInt64(txtFiyat.Text) * yeniAdet;
                    NpgsqlCommand kmt3 = new NpgsqlCommand("update muhasebe set harcanan=harcanan+@p1", baglanti);
                    kmt3.Parameters.AddWithValue("@p1", harcananFiyat);
                    baglanti.Open();
                    kmt3.ExecuteNonQuery();
                    baglanti.Close();
                }

                MessageBox.Show("Ürün Güncelleme İşlemi Başarılı.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                stoklistele();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUrunKodu.Text == "" || txtUrunAdi.Text == "")
                {
                    MessageBox.Show("Gerekli Alanları Doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (VarMi(txtUrunKodu.Text) != 0)
                    {
                        MessageBox.Show("Bu Ürün Zaten Kayıtlı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {

                        double sonFiyat = Convert.ToInt32(txtFiyat.Text) + (Convert.ToInt64(txtFiyat.Text) * 0.20);

                        NpgsqlCommand kmt1 = new NpgsqlCommand("insert into stok(urun_kodu,urun_adi,urun_fiyat,urun_adet,urun_son_fiyat) values(@p1,@p2,@p3,@p4,@p5)", baglanti);
                        kmt1.Parameters.AddWithValue("@p1", txtUrunKodu.Text);
                        kmt1.Parameters.AddWithValue("@p2", txtUrunAdi.Text);
                        kmt1.Parameters.AddWithValue("@p3", Convert.ToInt32(txtFiyat.Text));
                        kmt1.Parameters.AddWithValue("@p4", Convert.ToInt32(txtAdet.Text));
                        kmt1.Parameters.AddWithValue("@p5", sonFiyat);

                        baglanti.Open();
                        kmt1.ExecuteNonQuery();
                        baglanti.Close();

                        double harcananFiyat = Convert.ToInt64(txtFiyat.Text) * Convert.ToInt64(txtAdet.Text);
                        NpgsqlCommand kmt2 = new NpgsqlCommand("update muhasebe set harcanan=harcanan+@p1", baglanti);
                        kmt2.Parameters.AddWithValue("@p1", harcananFiyat);
                        baglanti.Open();
                        kmt2.ExecuteNonQuery();
                        baglanti.Close();

                        MessageBox.Show("Ürün Ekleme İşlemi Başarılı.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ekranTemizle();
                        stoklistele();
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
            NpgsqlCommand sorgu = new NpgsqlCommand("select count(urun_kodu) from stok where urun_kodu='" + aranan + "'", baglanti);
            sorgu.ExecuteNonQuery();
            sonuc = Convert.ToInt32(sorgu.ExecuteScalar());
            baglanti.Close();

            return sonuc;
        }

        private void txtFiyat_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtUrunKodu.Text == "")
            {
                MessageBox.Show("Güncellenecek Ürün Seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                urunguncelle(txtUrunKodu.Text);
                stoklistele();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtUrunKodu.Text == "")
            {
                MessageBox.Show("Silinecek Ürün Seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                urunsil(txtUrunKodu.Text);
                stoklistele();
            }
        }

        private void Stok_Load(object sender, EventArgs e)
        {
            stoklistele();
            dataGridView1.ForeColor = Color.Black;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (txtUrunKoduAra.Text == "")
            {
                stoklistele();
            }

            else
            {
                try
                {
                    DataTable veritablosu = new DataTable();
                    baglanti.Open();
                    NpgsqlDataAdapter ara = new NpgsqlDataAdapter("select * from stok where urun_kodu like '" + txtUrunKoduAra.Text + "'", baglanti);
                    ara.Fill(veritablosu);
                    dataGridView1.DataSource = veritablosu;
                    baglanti.Close();
                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtUrunKodu.Text = dataGridView1.CurrentRow.Cells["urun_kodu"].Value.ToString();
        }

        private void txtUrunKodu_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //textbox boş olduğunda hata vermesin diye.
                if (txtUrunKodu.Text == "")
                {
                    stoklistele();
                }

                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("select * from stok where urun_kodu= '" + txtUrunKodu.Text + "' ", baglanti);
                //select * from uye where tc like '"+ txtTCara.Text +"', baglanti);
                NpgsqlDataReader read = komut.ExecuteReader();

                while (read.Read())
                {
                    txtUrunAdi.Text = read["urun_adi"].ToString();
                    txtFiyat.Text = read["urun_fiyat"].ToString();
                    txtAdet.Text = read["urun_adet"].ToString();
                }
                read.Close();
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }
    }
}
