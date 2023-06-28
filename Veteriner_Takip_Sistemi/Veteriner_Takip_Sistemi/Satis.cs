using Microsoft.VisualBasic;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Veteriner_Takip_Sistemi
{
    public partial class Satis : Form
    {
        public Satis()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=vtsDB; user ID=postgres; password=1234");

        string fiyat;
        string adet;

        private void stoklistele()
        {
            try
            {
                string sorgu = "select urun_kodu,urun_adi,urun_adet,urun_son_fiyat AS " + "  Fiyat  " + " from stok";
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

        private void btnSat_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUrunKodu.Text == "" || txtUrunAdi.Text == "" || txtAdet.Text == "")
                {
                    MessageBox.Show("Gerekli Alanları Doldurunuz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                tekrar: string MusteriGir = Interaction.InputBox("Müşteri TC Giriniz", "Müşteri Gir", "", 700, 400);

                    if (MusteriGir == "")
                    {
                        DialogResult sonuc = new DialogResult();
                        sonuc = MessageBox.Show("Müşteri TC Giriniz!", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                        if (sonuc == DialogResult.Cancel)
                        {

                        }

                        else
                        {
                            goto tekrar;
                        }
                    }

                    else
                    {
                        if (VarMi(MusteriGir) == 0)
                        {
                            MessageBox.Show("Belirtilen Müşteri Bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            goto tekrar;
                        }

                        else
                        {
                            int adet2 = Convert.ToInt32(txtAdet.Text);

                            baglanti.Open();
                            NpgsqlCommand komut = new NpgsqlCommand("select * from stok where urun_kodu= '" + txtUrunKodu.Text + "' ", baglanti);
                            //select * from uye where tc like '"+ txtTCara.Text +"', baglanti);
                            NpgsqlDataReader read = komut.ExecuteReader();

                            while (read.Read())
                            {
                                fiyat = read["urun_fiyat"].ToString();
                                adet = read["urun_adet"].ToString();

                            }
                            read.Close();
                            baglanti.Close();

                            int adet3 = Convert.ToInt32(adet);
                            int fiyat2 = Convert.ToInt32(fiyat);

                            if (adet2 > adet3)
                            {
                                MessageBox.Show("Belirtilen Adette Ürün Yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            else
                            {
                                int harcama = adet2 * fiyat2;
                                double sonFiyat = harcama + (harcama * 0.20);

                                NpgsqlCommand satisKomut = new NpgsqlCommand("update hasta_sahip_kayit set harcama=harcama+@p2 where tc=@p1", baglanti);
                                satisKomut.Parameters.AddWithValue("@p1", MusteriGir);
                                satisKomut.Parameters.AddWithValue("@p2", sonFiyat);

                                NpgsqlCommand stokKomut = new NpgsqlCommand("update stok set urun_adet=urun_adet-@p2 where urun_kodu=@p1", baglanti);
                                stokKomut.Parameters.AddWithValue("@p1", txtUrunKodu.Text);
                                stokKomut.Parameters.AddWithValue("@p2", adet2);

                                

                                NpgsqlCommand muhasebeKomut = new NpgsqlCommand("update muhasebe set kazanilan=kazanilan+@p1", baglanti);
                                muhasebeKomut.Parameters.AddWithValue("@p1", sonFiyat);



                                baglanti.Open();
                                satisKomut.ExecuteNonQuery();
                                stokKomut.ExecuteNonQuery();
                                muhasebeKomut.ExecuteNonQuery();
                                baglanti.Close();

                                MessageBox.Show("Satış Gerçekleştirildi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                stoklistele();
                            }

                        }
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void Satis_Load(object sender, EventArgs e)
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

        public int VarMi(string aranan)
        {
            int sonuc;

            baglanti.Open();
            NpgsqlCommand sorgu = new NpgsqlCommand("select count(tc) from hasta_sahip_kayit where tc='" + aranan + "'", baglanti);
            sorgu.ExecuteNonQuery();
            sonuc = Convert.ToInt32(sorgu.ExecuteScalar());
            baglanti.Close();

            return sonuc;
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
                }
                read.Close();
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
