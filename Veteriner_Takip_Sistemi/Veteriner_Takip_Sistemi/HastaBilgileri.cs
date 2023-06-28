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
    public partial class HastaBilgileri : Form
    {
        public HastaBilgileri()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=vtsDB; user ID=postgres; password=1234");
        private void hastalistele()
        {
            try
            {
                string sorgu = "select * from hasta_kayit";
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

        private void hastasil(string kimlik)
        {
            try
            {
                string sorgu = "delete from hasta_kayit where sahip_tc=@p1";
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", kimlik);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Hasta Silme İşlemi Başarılı.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hastaguncelle(string kimlik)
        {
            try
            {
                NpgsqlCommand kmt2 = new NpgsqlCommand("update hasta_kayit set adi=@p2,dogum_tarihi=@p3,tur=@p4,irk=@p5,cinsiyet=@p6,rengi=@p7,agirlik=@p8,allerji=@p9 where sahip_tc=@p1", baglanti);
                kmt2.Parameters.AddWithValue("@p1", kimlik);
                kmt2.Parameters.AddWithValue("@p2", txtAd.Text);
                kmt2.Parameters.AddWithValue("@p3", Convert.ToDateTime(dateDogumTarih.Text));
                kmt2.Parameters.AddWithValue("@p4", comboTur.Text);
                kmt2.Parameters.AddWithValue("@p5", txtIrk.Text);
                kmt2.Parameters.AddWithValue("@p6", comboCinsiyet.Text);
                kmt2.Parameters.AddWithValue("@p7", txtRenk.Text);
                kmt2.Parameters.AddWithValue("@p8", Convert.ToInt32(txtAgirlik.Text));
                kmt2.Parameters.AddWithValue("@p9", txtAllerji.Text);

                baglanti.Open();
                kmt2.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Hasta Güncelleme İşlemi Başarılı.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HastaBilgileri_Load(object sender, EventArgs e)
        {
            hastalistele();
            dataGridView1.ForeColor = Color.Black;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (txtAra.Text == "")
            {
                hastalistele();
            }

            else
            {
                try
                {
                    DataTable veritablosu = new DataTable();
                    baglanti.Open();
                    NpgsqlDataAdapter ara = new NpgsqlDataAdapter("select * from hasta_kayit where sahip_tc like '" + txtAra.Text + "'", baglanti);
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

        private void txtAra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtSahipTc.Text == "")
            {
                MessageBox.Show("Silinecek Hastayı Seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                hastasil(txtSahipTc.Text);
                hastalistele();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtSahipTc.Text == "")
            {
                MessageBox.Show("Güncellenecek Hastayı Seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                hastaguncelle(txtSahipTc.Text);
                hastalistele();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSahipTc.Text = dataGridView1.CurrentRow.Cells["sahip_tc"].Value.ToString();
        }

        private void txtSahipTc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //textbox boş olduğunda hata vermesin diye.
                if (txtSahipTc.Text == "")
                {
                    hastalistele();
                }

                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("select * from hasta_kayit where sahip_tc= '" + txtSahipTc.Text + "' ", baglanti);
                //select * from uye where tc like '"+ txtTCara.Text +"', baglanti);
                NpgsqlDataReader read = komut.ExecuteReader();

                while (read.Read())
                {
                    txtAd.Text = read["adi"].ToString();
                    dateDogumTarih.Text = read["dogum_tarihi"].ToString();
                    comboTur.Text = read["tur"].ToString();
                    txtIrk.Text = read["irk"].ToString();
                    comboCinsiyet.Text = read["cinsiyet"].ToString();
                    txtRenk.Text = read["rengi"].ToString();
                    txtAgirlik.Text = read["agirlik"].ToString();
                    txtAllerji.Text = read["allerji"].ToString();
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
