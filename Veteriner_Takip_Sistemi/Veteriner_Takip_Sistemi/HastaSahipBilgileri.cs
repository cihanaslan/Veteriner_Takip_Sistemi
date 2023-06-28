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
    public partial class HastaSahipBilgileri : Form
    {
        public HastaSahipBilgileri()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=vtsDB; user ID=postgres; password=1234");

        private void hastaSahiplistele()
        {
            try
            {
                string sorgu = "select * from hasta_sahip_kayit";
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

        private void hastaSahipsil(string kimlik)
        {
            try
            {
                string sorgu = "delete from hasta_sahip_kayit where tc=@p1";
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", kimlik);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Hasta Sahip Silme İşlemi Başarılı.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hastaSahipguncelle(string kimlik)
        {
            try
            {
                NpgsqlCommand kmt2 = new NpgsqlCommand("update hasta_sahip_kayit set ad=@p2,soyad=@p3,telefon=@p4,email=@p5,adres=@p6 where tc=@p1", baglanti);
                kmt2.Parameters.AddWithValue("@p1", kimlik);
                kmt2.Parameters.AddWithValue("@p2", txtAd.Text);
                kmt2.Parameters.AddWithValue("@p3", txtSoyad.Text);
                kmt2.Parameters.AddWithValue("@p4", txtTel.Text);
                kmt2.Parameters.AddWithValue("@p5", txtMail.Text);
                kmt2.Parameters.AddWithValue("@p6", txtAdres.Text);

                baglanti.Open();
                kmt2.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Hasta Sahip Güncelleme İşlemi Başarılı.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HastaSahipBilgileri_Load(object sender, EventArgs e)
        {
            hastaSahiplistele();
            dataGridView1.ForeColor = Color.Black;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (txtAra.Text == "")
            {
                hastaSahiplistele();
            }

            else
            {
                try
                {
                    DataTable veritablosu = new DataTable();
                    baglanti.Open();
                    NpgsqlDataAdapter ara = new NpgsqlDataAdapter("select * from hasta_sahip_kayit where tc like '" + txtAra.Text + "'", baglanti);
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

        private void txtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtTC.Text == "")
            {
                MessageBox.Show("Silinecek Hasta Sahibi Seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                hastaSahipsil(txtTC.Text);
                hastaSahiplistele();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtTC.Text == "")
            {
                MessageBox.Show("Güncellenecek Hasta Sahibi Seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                hastaSahipguncelle(txtTC.Text);
                hastaSahiplistele();
            }
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTC.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
        }

        private void txtTC_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //textbox boş olduğunda hata vermesin diye.
                if (txtTC.Text == "")
                {
                    hastaSahiplistele();
                }

                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("select * from hasta_sahip_kayit where tc= '" + txtTC.Text + "' ", baglanti);
                //select * from uye where tc like '"+ txtTCara.Text +"', baglanti);
                NpgsqlDataReader read = komut.ExecuteReader();

                while (read.Read())
                {
                    txtAd.Text = read["ad"].ToString();
                    txtSoyad.Text = read["soyad"].ToString();
                    txtTel.Text = read["telefon"].ToString();
                    txtMail.Text = read["email"].ToString();
                    txtAdres.Text = read["adres"].ToString();
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
