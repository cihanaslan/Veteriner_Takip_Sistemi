using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace Veteriner_Takip_Sistemi
{
    public partial class Muhasebe : Form
    {
        public Muhasebe()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=vtsDB; user ID=postgres; password=1234");
        string kazanilan, harcanan;
        double kazanilan2, harcanan2;

        private void Muhasebe_Load(object sender, EventArgs e)
        {
            try
            {
                if (VarMi() != 0)
                {
                    baglanti.Open();
                    NpgsqlCommand komut = new NpgsqlCommand("select * from muhasebe", baglanti);
                    //select * from uye where tc like '"+ txtTCara.Text +"', baglanti);
                    NpgsqlDataReader read = komut.ExecuteReader();

                    while (read.Read())
                    {
                        kazanilan = read["kazanilan"].ToString();
                        harcanan = read["harcanan"].ToString();

                    }
                    read.Close();
                    baglanti.Close();

                    kazanilan2 = Convert.ToInt64(kazanilan);
                    harcanan2 = Convert.ToInt64(harcanan);
                    double kar = kazanilan2 - harcanan2;

                    NpgsqlCommand komut2 = new NpgsqlCommand("update muhasebe set kar=@p1", baglanti);
                    komut2.Parameters.AddWithValue("@p1", kar);
                    baglanti.Open();
                    komut2.ExecuteNonQuery();
                    baglanti.Close();

                    lblKar.Text = kar.ToString();
                    lblHarcama.Text = harcanan;
                    lblKazanilan.Text = kazanilan;

                    NpgsqlCommand komut3 = new NpgsqlCommand("select ad from hasta_sahip_kayit where harcama=(select max(harcama) from hasta_sahip_kayit)", baglanti);
                    NpgsqlCommand komut4 = new NpgsqlCommand("select ad from hasta_sahip_kayit where harcama=(select min(harcama) from hasta_sahip_kayit)", baglanti);
                    baglanti.Open();
                    string sonucB = komut3.ExecuteScalar().ToString();
                    string sonucK = komut4.ExecuteScalar().ToString();
                    baglanti.Close();

                    lblEnCok.Text = sonucB;
                    lblEnAz.Text = sonucK;

                    this.chartGrafik.Titles.Add("Müşteri Harcama Grafiği");

                    baglanti.Open();
                    NpgsqlCommand veriCek = new NpgsqlCommand("select * from hasta_sahip_kayit", baglanti);
                    NpgsqlDataReader okuyucu = veriCek.ExecuteReader();

                    while (okuyucu.Read())
                    {
                        this.chartGrafik.Series.Add(okuyucu["ad"].ToString());
                        this.chartGrafik.Series[okuyucu["ad"].ToString()].Points.AddXY("harcama", double.Parse(okuyucu["harcama"].ToString()));
                        this.chartGrafik.Series[okuyucu["ad"].ToString()].Points[0].Label = (okuyucu["harcama"].ToString());
                    }
                    baglanti.Close();
                }

                else
                {

                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                      
        }
        public int VarMi()
        {
            int sonuc;

            baglanti.Open();
            NpgsqlCommand sorgu = new NpgsqlCommand("select count(tc) from hasta_sahip_kayit", baglanti);
            sorgu.ExecuteNonQuery();
            sonuc = Convert.ToInt32(sorgu.ExecuteScalar());
            baglanti.Close();

            return sonuc;
        }
    }
}
