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
    public partial class DoktorBilgileri : Form
    {
        public DoktorBilgileri()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=vtsDB; user ID=postgres; password=1234");

        private void doktorlistele()
        {
            try
            {
                string sorgu = "select * from doktor_kayit";
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

        private void doktorsil(string kimlik)
        {
            try
            {
                string sorgu = "delete from doktor_kayit where tc=@p1";
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", kimlik);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Doktor Silme İşlemi Başarılı.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void doktorguncelle(string kimlik)
        {
            try
            {
                NpgsqlCommand kmt2 = new NpgsqlCommand("update doktor_kayit set ad=@p2,soyad=@p3,cinsiyet=@p4,telefon=@p5,email=@p6 where tc=@p1", baglanti);
                kmt2.Parameters.AddWithValue("@p1", kimlik);
                kmt2.Parameters.AddWithValue("@p2", txtAd.Text);
                kmt2.Parameters.AddWithValue("@p3", txtSoyad.Text);
                kmt2.Parameters.AddWithValue("@p4", comboCinsiyet.Text);
                kmt2.Parameters.AddWithValue("@p5", txtTel.Text);
                kmt2.Parameters.AddWithValue("@p6", txtMail.Text);

                baglanti.Open();
                kmt2.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Doktor Güncelleme İşlemi Başarılı.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoktorBilgileri_Load(object sender, EventArgs e)
        {
            doktorlistele();
            dataGridView1.ForeColor = Color.Black;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (txtAra.Text == "")
            {
                doktorlistele();
            }

            else
            {
                try
                {
                    DataTable veritablosu = new DataTable();
                    baglanti.Open();
                    NpgsqlDataAdapter ara = new NpgsqlDataAdapter("select * from doktor_kayit where tc like '" + txtAra.Text + "'", baglanti);
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

        /*private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtTC.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboCinsiyet.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTel.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtMail.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }*/

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtTC.Text == "")
            {
                MessageBox.Show("Silinecek Doktor Seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                doktorsil(txtTC.Text);
                doktorlistele();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtTC.Text == "")
            {
                MessageBox.Show("Güncellenecek Doktor Seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                doktorguncelle(txtTC.Text);
                doktorlistele();
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
                    doktorlistele();
                }

                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("select * from doktor_kayit where tc= '" + txtTC.Text + "' ", baglanti);
                //select * from uye where tc like '"+ txtTCara.Text +"', baglanti);
                NpgsqlDataReader read = komut.ExecuteReader();

                while (read.Read())
                {
                    txtAd.Text = read["ad"].ToString();
                    txtSoyad.Text = read["soyad"].ToString();
                    comboCinsiyet.Text = read["cinsiyet"].ToString();
                    txtTel.Text = read["telefon"].ToString();
                    txtMail.Text = read["email"].ToString();
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
