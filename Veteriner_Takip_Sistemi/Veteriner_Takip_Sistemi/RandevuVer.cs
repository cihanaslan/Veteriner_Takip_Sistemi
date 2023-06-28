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
using System.Net.Mail;

namespace Veteriner_Takip_Sistemi
{
    public partial class RandevuVer : Form
    {
        public RandevuVer()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=vtsDB; user ID=postgres; password=1234");

        private void RandevuVer_Load(object sender, EventArgs e)
        {
            try
            {
                monthCalendar1.MinDate = DateTime.Now;
                monthCalendar1.MaxDate = new DateTime(2025, 12, 31);

                baglanti.Open();
                NpgsqlCommand komut = new NpgsqlCommand("select * from doktor_kayit ", baglanti);
                //select * from uye where tc like '"+ txtTCara.Text +"', baglanti);
                NpgsqlDataReader read = komut.ExecuteReader();

                while (read.Read())
                {
                    comboDoktor.Items.Add(read["ad"]);
                }
                read.Close();
                baglanti.Close();


                for (int j = 0; j < this.Controls.Count; j++)
                {
                    if (Controls[j] is PictureBox)
                    {
                        Controls[j].Visible = false;
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
                    monthCalendar1.SelectionStart = DateTime.Now;
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

        private void MailGonder(string Email, string Kisi, string Gun, string Saat,string Doktor)
        {
            MailMessage mesaj = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("mail adresi", "mail şifresi");
            istemci.Port = 587;
            istemci.Host = "smtp.office365.com";
            istemci.EnableSsl = true;
            mesaj.To.Add(Email);
            mesaj.From = new MailAddress("mail adresi");
            mesaj.Subject = "Randevu Bilgileri";
            mesaj.Body = "Merhaba Sayın " + Kisi + ". " + Gun + " tarihinde, saat " + Saat + "'da, " + Doktor + " adlı hekime randevunuz oluşturulmuştur. İyi günler dileriz. Veteriner Takip Sistemi.";
            istemci.Send(mesaj);
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            try
            {
                DateTime tarih = monthCalendar1.SelectionStart;
                string doktor = comboDoktor.Text;
                string hasta = txtHastaSahipTC.Text;

                #region saat9

                NpgsqlCommand komut1 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '09:00' ", baglanti);
                baglanti.Open();
                komut1.ExecuteNonQuery();
                int sonuc1 = Convert.ToInt32(komut1.ExecuteScalar());
                baglanti.Close();

                if (sonuc1 != 0)
                {
                    picBoxSaatDokuz.Visible = false;
                    lblSaatDokuz.Visible = false;
                }

                else
                {
                    picBoxSaatDokuz.Visible = true;
                    lblSaatDokuz.Visible = true;
                }

                #endregion

                #region saat9.30

                NpgsqlCommand komut2 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '09:30' ", baglanti);
                baglanti.Open();
                komut2.ExecuteNonQuery();
                int sonuc2 = Convert.ToInt32(komut2.ExecuteScalar());
                baglanti.Close();

                if (sonuc2 != 0)
                {
                    picBoxSaatDokuzBucuk.Visible = false;
                    lblSaatDokuzBucuk.Visible = false;
                }

                else
                {
                    picBoxSaatDokuzBucuk.Visible = true;
                    lblSaatDokuzBucuk.Visible = true;
                }
                #endregion

                #region saat10
                NpgsqlCommand komut3 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '10:00' ", baglanti);
                baglanti.Open();
                komut3.ExecuteNonQuery();
                int sonuc3 = Convert.ToInt32(komut3.ExecuteScalar());
                baglanti.Close();

                if (sonuc3 != 0)
                {
                    picBoxSaatOn.Visible = false;
                    lblSaatOn.Visible = false;
                }

                else
                {
                    picBoxSaatOn.Visible = true;
                    lblSaatOn.Visible = true;
                }
                #endregion

                #region saat10.30
                NpgsqlCommand komut4 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '10:30' ", baglanti);
                baglanti.Open();
                komut4.ExecuteNonQuery();
                int sonuc4 = Convert.ToInt32(komut4.ExecuteScalar());
                baglanti.Close();

                if (sonuc4 != 0)
                {
                    picBoxSaatOnBucuk.Visible = false;
                    lblSaatOnBucuk.Visible = false;
                }

                else
                {
                    picBoxSaatOnBucuk.Visible = true;
                    lblSaatOnBucuk.Visible = true;
                }
                #endregion

                #region saat11
                NpgsqlCommand komut5 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '11:00' ", baglanti);
                baglanti.Open();
                komut5.ExecuteNonQuery();
                int sonuc5 = Convert.ToInt32(komut5.ExecuteScalar());
                baglanti.Close();

                if (sonuc5 != 0)
                {
                    picBoxSaatOnBir.Visible = false;
                    lblSaatOnBir.Visible = false;
                }

                else
                {
                    picBoxSaatOnBir.Visible = true;
                    lblSaatOnBir.Visible = true;
                }
                #endregion

                #region saat11.30
                NpgsqlCommand komut6 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '11:30' ", baglanti);
                baglanti.Open();
                komut6.ExecuteNonQuery();
                int sonuc6 = Convert.ToInt32(komut6.ExecuteScalar());
                baglanti.Close();

                if (sonuc6 != 0)
                {
                    picBoxSaatOnBirBucuk.Visible = false;
                    lblSaatOnBirBucuk.Visible = false;
                }

                else
                {
                    picBoxSaatOnBirBucuk.Visible = true;
                    lblSaatOnBirBucuk.Visible = true;
                }
                #endregion

                #region saat12
                NpgsqlCommand komut7 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '12:00' ", baglanti);
                baglanti.Open();
                komut7.ExecuteNonQuery();
                int sonuc7 = Convert.ToInt32(komut7.ExecuteScalar());
                baglanti.Close();

                if (sonuc7 != 0)
                {
                    picBoxSaatOnİki.Visible = false;
                    lblSaatOnİki.Visible = false;
                }

                else
                {
                    picBoxSaatOnİki.Visible = true;
                    lblSaatOnİki.Visible = true;
                }
                #endregion

                #region saat12.30
                NpgsqlCommand komut8 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '12:30' ", baglanti);
                baglanti.Open();
                komut8.ExecuteNonQuery();
                int sonuc8 = Convert.ToInt32(komut8.ExecuteScalar());
                baglanti.Close();

                if (sonuc8 != 0)
                {
                    picBoxSaatOnİkiOtuz.Visible = false;
                    lblSaatOnİkiBucuk.Visible = false;
                }

                else
                {
                    picBoxSaatOnİkiOtuz.Visible = true;
                    lblSaatOnİkiBucuk.Visible = true;
                }
                #endregion

                #region saat13
                NpgsqlCommand komut9 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '13:00' ", baglanti);
                baglanti.Open();
                komut9.ExecuteNonQuery();
                int sonuc9 = Convert.ToInt32(komut9.ExecuteScalar());
                baglanti.Close();

                if (sonuc9 != 0)
                {
                    picBoxSaatOnUc.Visible = false;
                    lblSaatOnUc.Visible = false;
                }

                else
                {
                    picBoxSaatOnUc.Visible = true;
                    lblSaatOnUc.Visible = true;
                }
                #endregion

                #region saat13.30
                NpgsqlCommand komut10 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '13:30' ", baglanti);
                baglanti.Open();
                komut10.ExecuteNonQuery();
                int sonuc10 = Convert.ToInt32(komut10.ExecuteScalar());
                baglanti.Close();

                if (sonuc10 != 0)
                {
                    picBoxSaatOnUcOtuz.Visible = false;
                    lblSaatOnUcOtuz.Visible = false;
                }

                else
                {
                    picBoxSaatOnUcOtuz.Visible = true;
                    lblSaatOnUcOtuz.Visible = true;
                }
                #endregion

                #region saat14
                NpgsqlCommand komut11 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '14:00' ", baglanti);
                baglanti.Open();
                komut11.ExecuteNonQuery();
                int sonuc11 = Convert.ToInt32(komut11.ExecuteScalar());
                baglanti.Close();

                if (sonuc11 != 0)
                {
                    picBoxSaatOnDört.Visible = false;
                    lblSaatOnDört.Visible = false;
                }

                else
                {
                    picBoxSaatOnDört.Visible = true;
                    lblSaatOnDört.Visible = true;
                }
                #endregion

                #region saat14.30
                NpgsqlCommand komut12 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '14:30' ", baglanti);
                baglanti.Open();
                komut12.ExecuteNonQuery();
                int sonuc12 = Convert.ToInt32(komut12.ExecuteScalar());
                baglanti.Close();

                if (sonuc12 != 0)
                {
                    picBoxSaatOnDörtOtuz.Visible = false;
                    lblSaatOnDörtOtuz.Visible = false;
                }

                else
                {
                    picBoxSaatOnDörtOtuz.Visible = true;
                    lblSaatOnDörtOtuz.Visible = true;
                }
                #endregion

                #region saat15
                NpgsqlCommand komut13 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '15:00' ", baglanti);
                baglanti.Open();
                komut13.ExecuteNonQuery();
                int sonuc13 = Convert.ToInt32(komut13.ExecuteScalar());
                baglanti.Close();

                if (sonuc13 != 0)
                {
                    picBoxSaatOnBes.Visible = false;
                    lblSaatOnBes.Visible = false;
                }

                else
                {
                    picBoxSaatOnBes.Visible = true;
                    lblSaatOnBes.Visible = true;
                }
                #endregion

                #region saat15.30
                NpgsqlCommand komut14 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '15:30' ", baglanti);
                baglanti.Open();
                komut14.ExecuteNonQuery();
                int sonuc14 = Convert.ToInt32(komut14.ExecuteScalar());
                baglanti.Close();

                if (sonuc14 != 0)
                {
                    picBoxSaatOnBesOtuz.Visible = false;
                    lblSaatOnBesOtuz.Visible = false;
                }

                else
                {
                    picBoxSaatOnBesOtuz.Visible = true;
                    lblSaatOnBesOtuz.Visible = true;
                }
                #endregion

                #region saat16
                NpgsqlCommand komut15 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '16:00' ", baglanti);
                baglanti.Open();
                komut15.ExecuteNonQuery();
                int sonuc15 = Convert.ToInt32(komut15.ExecuteScalar());
                baglanti.Close();

                if (sonuc15 != 0)
                {
                    picBoxSaatOnAltı.Visible = false;
                    lblSaatOnAltı.Visible = false;
                }

                else
                {
                    picBoxSaatOnAltı.Visible = true;
                    lblSaatOnAltı.Visible = true;
                }
                #endregion
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void comboDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime tarih = monthCalendar1.SelectionStart;
                string doktor = comboDoktor.Text;
                string hasta = txtHastaSahipTC.Text;

                #region saat9

                NpgsqlCommand komut1 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '09:00' ", baglanti);
                baglanti.Open();
                komut1.ExecuteNonQuery();
                int sonuc1 = Convert.ToInt32(komut1.ExecuteScalar());
                baglanti.Close();

                if (sonuc1 != 0)
                {
                    picBoxSaatDokuz.Visible = false;
                    lblSaatDokuz.Visible = false;
                }

                else
                {
                    picBoxSaatDokuz.Visible = true;
                    lblSaatDokuz.Visible = true;
                }

                #endregion

                #region saat9.30

                NpgsqlCommand komut2 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '09:30' ", baglanti);
                baglanti.Open();
                komut2.ExecuteNonQuery();
                int sonuc2 = Convert.ToInt32(komut2.ExecuteScalar());
                baglanti.Close();

                if (sonuc2 != 0)
                {
                    picBoxSaatDokuzBucuk.Visible = false;
                    lblSaatDokuzBucuk.Visible = false;
                }

                else
                {
                    picBoxSaatDokuzBucuk.Visible = true;
                    lblSaatDokuzBucuk.Visible = true;
                }
                #endregion

                #region saat10
                NpgsqlCommand komut3 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '10:00' ", baglanti);
                baglanti.Open();
                komut3.ExecuteNonQuery();
                int sonuc3 = Convert.ToInt32(komut3.ExecuteScalar());
                baglanti.Close();

                if (sonuc3 != 0)
                {
                    picBoxSaatOn.Visible = false;
                    lblSaatOn.Visible = false;
                }

                else
                {
                    picBoxSaatOn.Visible = true;
                    lblSaatOn.Visible = true;
                }
                #endregion

                #region saat10.30
                NpgsqlCommand komut4 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '10:30' ", baglanti);
                baglanti.Open();
                komut4.ExecuteNonQuery();
                int sonuc4 = Convert.ToInt32(komut4.ExecuteScalar());
                baglanti.Close();

                if (sonuc4 != 0)
                {
                    picBoxSaatOnBucuk.Visible = false;
                    lblSaatOnBucuk.Visible = false;
                }

                else
                {
                    picBoxSaatOnBucuk.Visible = true;
                    lblSaatOnBucuk.Visible = true;
                }
                #endregion

                #region saat11
                NpgsqlCommand komut5 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '11:00' ", baglanti);
                baglanti.Open();
                komut5.ExecuteNonQuery();
                int sonuc5 = Convert.ToInt32(komut5.ExecuteScalar());
                baglanti.Close();

                if (sonuc5 != 0)
                {
                    picBoxSaatOnBir.Visible = false;
                    lblSaatOnBir.Visible = false;
                }

                else
                {
                    picBoxSaatOnBir.Visible = true;
                    lblSaatOnBir.Visible = true;
                }
                #endregion

                #region saat11.30
                NpgsqlCommand komut6 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '11:30' ", baglanti);
                baglanti.Open();
                komut6.ExecuteNonQuery();
                int sonuc6 = Convert.ToInt32(komut6.ExecuteScalar());
                baglanti.Close();

                if (sonuc6 != 0)
                {
                    picBoxSaatOnBirBucuk.Visible = false;
                    lblSaatOnBirBucuk.Visible = false;
                }

                else
                {
                    picBoxSaatOnBirBucuk.Visible = true;
                    lblSaatOnBirBucuk.Visible = true;
                }
                #endregion

                #region saat12
                NpgsqlCommand komut7 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '12:00' ", baglanti);
                baglanti.Open();
                komut7.ExecuteNonQuery();
                int sonuc7 = Convert.ToInt32(komut7.ExecuteScalar());
                baglanti.Close();

                if (sonuc7 != 0)
                {
                    picBoxSaatOnİki.Visible = false;
                    lblSaatOnİki.Visible = false;
                }

                else
                {
                    picBoxSaatOnİki.Visible = true;
                    lblSaatOnİki.Visible = true;
                }
                #endregion

                #region saat12.30
                NpgsqlCommand komut8 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '12:30' ", baglanti);
                baglanti.Open();
                komut8.ExecuteNonQuery();
                int sonuc8 = Convert.ToInt32(komut8.ExecuteScalar());
                baglanti.Close();

                if (sonuc8 != 0)
                {
                    picBoxSaatOnİkiOtuz.Visible = false;
                    lblSaatOnİkiBucuk.Visible = false;
                }

                else
                {
                    picBoxSaatOnİkiOtuz.Visible = true;
                    lblSaatOnİkiBucuk.Visible = true;
                }
                #endregion

                #region saat13
                NpgsqlCommand komut9 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '13:00' ", baglanti);
                baglanti.Open();
                komut9.ExecuteNonQuery();
                int sonuc9 = Convert.ToInt32(komut9.ExecuteScalar());
                baglanti.Close();

                if (sonuc9 != 0)
                {
                    picBoxSaatOnUc.Visible = false;
                    lblSaatOnUc.Visible = false;
                }

                else
                {
                    picBoxSaatOnUc.Visible = true;
                    lblSaatOnUc.Visible = true;
                }
                #endregion

                #region saat13.30
                NpgsqlCommand komut10 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '13:30' ", baglanti);
                baglanti.Open();
                komut10.ExecuteNonQuery();
                int sonuc10 = Convert.ToInt32(komut10.ExecuteScalar());
                baglanti.Close();

                if (sonuc10 != 0)
                {
                    picBoxSaatOnUcOtuz.Visible = false;
                    lblSaatOnUcOtuz.Visible = false;
                }

                else
                {
                    picBoxSaatOnUcOtuz.Visible = true;
                    lblSaatOnUcOtuz.Visible = true;
                }
                #endregion

                #region saat14
                NpgsqlCommand komut11 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '14:00' ", baglanti);
                baglanti.Open();
                komut11.ExecuteNonQuery();
                int sonuc11 = Convert.ToInt32(komut11.ExecuteScalar());
                baglanti.Close();

                if (sonuc11 != 0)
                {
                    picBoxSaatOnDört.Visible = false;
                    lblSaatOnDört.Visible = false;
                }

                else
                {
                    picBoxSaatOnDört.Visible = true;
                    lblSaatOnDört.Visible = true;
                }
                #endregion

                #region saat14.30
                NpgsqlCommand komut12 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '14:30' ", baglanti);
                baglanti.Open();
                komut12.ExecuteNonQuery();
                int sonuc12 = Convert.ToInt32(komut12.ExecuteScalar());
                baglanti.Close();

                if (sonuc12 != 0)
                {
                    picBoxSaatOnDörtOtuz.Visible = false;
                    lblSaatOnDörtOtuz.Visible = false;
                }

                else
                {
                    picBoxSaatOnDörtOtuz.Visible = true;
                    lblSaatOnDörtOtuz.Visible = true;
                }
                #endregion

                #region saat15
                NpgsqlCommand komut13 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '15:00' ", baglanti);
                baglanti.Open();
                komut13.ExecuteNonQuery();
                int sonuc13 = Convert.ToInt32(komut13.ExecuteScalar());
                baglanti.Close();

                if (sonuc13 != 0)
                {
                    picBoxSaatOnBes.Visible = false;
                    lblSaatOnBes.Visible = false;
                }

                else
                {
                    picBoxSaatOnBes.Visible = true;
                    lblSaatOnBes.Visible = true;
                }
                #endregion

                #region saat15.30
                NpgsqlCommand komut14 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '15:30' ", baglanti);
                baglanti.Open();
                komut14.ExecuteNonQuery();
                int sonuc14 = Convert.ToInt32(komut14.ExecuteScalar());
                baglanti.Close();

                if (sonuc14 != 0)
                {
                    picBoxSaatOnBesOtuz.Visible = false;
                    lblSaatOnBesOtuz.Visible = false;
                }

                else
                {
                    picBoxSaatOnBesOtuz.Visible = true;
                    lblSaatOnBesOtuz.Visible = true;
                }
                #endregion

                #region saat16
                NpgsqlCommand komut15 = new NpgsqlCommand("SELECT COUNT(randevu_saati) FROM randevu WHERE randevu_doktoru = '" + doktor + "' AND randevu_tarihi = '" + tarih + "' AND randevu_saati = '16:00' ", baglanti);
                baglanti.Open();
                komut15.ExecuteNonQuery();
                int sonuc15 = Convert.ToInt32(komut15.ExecuteScalar());
                baglanti.Close();

                if (sonuc15 != 0)
                {
                    picBoxSaatOnAltı.Visible = false;
                    lblSaatOnAltı.Visible = false;
                }

                else
                {
                    picBoxSaatOnAltı.Visible = true;
                    lblSaatOnAltı.Visible = true;
                }
                #endregion
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void picBoxSaatDokuz_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHastaSahipTC.Text == "" || comboDoktor.Text == "" || comboDoktor.Text == "Seçiniz...")
                {
                    MessageBox.Show("Gerekli Alanları Doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (VarMi(txtHastaSahipTC.Text) == 0)
                    {
                        MessageBox.Show("Böyle Bir Hasta Yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        baglanti.Open();
                        NpgsqlCommand komut = new NpgsqlCommand("select ad from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        NpgsqlCommand komut2 = new NpgsqlCommand("select email from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        komut.ExecuteNonQuery();
                        komut2.ExecuteNonQuery();
                        string sahipIsim = komut.ExecuteScalar().ToString();
                        string email = komut2.ExecuteScalar().ToString();
                        baglanti.Close();

                        NpgsqlCommand command = new NpgsqlCommand("insert into randevu(randevu_saati, randevu_tarihi, randevu_doktoru, randevu_sahibi_tc, hasta_sahip_ad) values(@p1,@p2,@p3,@p4,@p5);", baglanti);
                        command.Parameters.AddWithValue("@p1", lblSaatDokuz.Text);
                        command.Parameters.AddWithValue("@p2", monthCalendar1.SelectionStart);
                        command.Parameters.AddWithValue("@p3", comboDoktor.Text);
                        command.Parameters.AddWithValue("@p4", txtHastaSahipTC.Text);
                        command.Parameters.AddWithValue("@p5", sahipIsim);

                        baglanti.Open();
                        command.ExecuteNonQuery();
                        baglanti.Close();

                        MailGonder(email,sahipIsim,monthCalendar1.SelectionStart.ToString("d"),lblSaatDokuz.Text,comboDoktor.Text);
                        ekranTemizle();
                        MessageBox.Show("Randevu Verildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception hata)
            {
               MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                       
        }

        private void txtHastaSahipTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void picBoxSaatDokuzBucuk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHastaSahipTC.Text == "" || comboDoktor.Text == "" || comboDoktor.Text == "Seçiniz...")
                {
                    MessageBox.Show("Gerekli Alanları Doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (VarMi(txtHastaSahipTC.Text) == 0)
                    {
                        MessageBox.Show("Böyle Bir Hasta Yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        baglanti.Open();
                        NpgsqlCommand komut = new NpgsqlCommand("select ad from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        NpgsqlCommand komut2 = new NpgsqlCommand("select email from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        komut.ExecuteNonQuery();
                        komut2.ExecuteNonQuery();
                        string sahipIsim = komut.ExecuteScalar().ToString();
                        string email = komut2.ExecuteScalar().ToString();
                        baglanti.Close();

                        NpgsqlCommand command = new NpgsqlCommand("insert into randevu(randevu_saati, randevu_tarihi, randevu_doktoru, randevu_sahibi_tc, hasta_sahip_ad) values(@p1,@p2,@p3,@p4,@p5);", baglanti);
                        command.Parameters.AddWithValue("@p1", lblSaatDokuzBucuk.Text);
                        command.Parameters.AddWithValue("@p2", monthCalendar1.SelectionStart);
                        command.Parameters.AddWithValue("@p3", comboDoktor.Text);
                        command.Parameters.AddWithValue("@p4", txtHastaSahipTC.Text);
                        command.Parameters.AddWithValue("@p5", sahipIsim);

                        baglanti.Open();
                        command.ExecuteNonQuery();
                        baglanti.Close();

                        MailGonder(email, sahipIsim, monthCalendar1.SelectionStart.ToString("d"), lblSaatDokuzBucuk.Text,comboDoktor.Text);
                        ekranTemizle();
                        MessageBox.Show("Randevu Verildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void picBoxSaatOn_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHastaSahipTC.Text == "" || comboDoktor.Text == "" || comboDoktor.Text == "Seçiniz...")
                {
                    MessageBox.Show("Gerekli Alanları Doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (VarMi(txtHastaSahipTC.Text) == 0)
                    {
                        MessageBox.Show("Böyle Bir Hasta Yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        baglanti.Open();
                        NpgsqlCommand komut = new NpgsqlCommand("select ad from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        NpgsqlCommand komut2 = new NpgsqlCommand("select email from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        komut.ExecuteNonQuery();
                        komut2.ExecuteNonQuery();
                        string sahipIsim = komut.ExecuteScalar().ToString();
                        string email = komut2.ExecuteScalar().ToString();
                        baglanti.Close();

                        NpgsqlCommand command = new NpgsqlCommand("insert into randevu(randevu_saati, randevu_tarihi, randevu_doktoru, randevu_sahibi_tc, hasta_sahip_ad) values(@p1,@p2,@p3,@p4,@p5);", baglanti);
                        command.Parameters.AddWithValue("@p1", lblSaatOn.Text);
                        command.Parameters.AddWithValue("@p2", monthCalendar1.SelectionStart);
                        command.Parameters.AddWithValue("@p3", comboDoktor.Text);
                        command.Parameters.AddWithValue("@p4", txtHastaSahipTC.Text);
                        command.Parameters.AddWithValue("@p5", sahipIsim);

                        baglanti.Open();
                        command.ExecuteNonQuery();
                        baglanti.Close();

                        MailGonder(email, sahipIsim, monthCalendar1.SelectionStart.ToString("d"), lblSaatOn.Text, comboDoktor.Text);
                        ekranTemizle();
                        MessageBox.Show("Randevu Verildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void picBoxSaatOnBucuk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHastaSahipTC.Text == "" || comboDoktor.Text == "" || comboDoktor.Text == "Seçiniz...")
                {
                    MessageBox.Show("Gerekli Alanları Doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (VarMi(txtHastaSahipTC.Text) == 0)
                    {
                        MessageBox.Show("Böyle Bir Hasta Yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        baglanti.Open();
                        NpgsqlCommand komut = new NpgsqlCommand("select ad from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        NpgsqlCommand komut2 = new NpgsqlCommand("select email from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        komut.ExecuteNonQuery();
                        komut2.ExecuteNonQuery();
                        string sahipIsim = komut.ExecuteScalar().ToString();
                        string email = komut2.ExecuteScalar().ToString();
                        baglanti.Close();

                        NpgsqlCommand command = new NpgsqlCommand("insert into randevu(randevu_saati, randevu_tarihi, randevu_doktoru, randevu_sahibi_tc, hasta_sahip_ad) values(@p1,@p2,@p3,@p4,@p5);", baglanti);
                        command.Parameters.AddWithValue("@p1", lblSaatOnBucuk.Text);
                        command.Parameters.AddWithValue("@p2", monthCalendar1.SelectionStart);
                        command.Parameters.AddWithValue("@p3", comboDoktor.Text);
                        command.Parameters.AddWithValue("@p4", txtHastaSahipTC.Text);
                        command.Parameters.AddWithValue("@p5", sahipIsim);

                        baglanti.Open();
                        command.ExecuteNonQuery();
                        baglanti.Close();

                        MailGonder(email, sahipIsim, monthCalendar1.SelectionStart.ToString("d"), lblSaatOnBucuk.Text, comboDoktor.Text);
                        ekranTemizle();
                        MessageBox.Show("Randevu Verildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void picBoxSaatOnBir_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHastaSahipTC.Text == "" || comboDoktor.Text == "" || comboDoktor.Text == "Seçiniz...")
                {
                    MessageBox.Show("Gerekli Alanları Doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (VarMi(txtHastaSahipTC.Text) == 0)
                    {
                        MessageBox.Show("Böyle Bir Hasta Yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        baglanti.Open();
                        NpgsqlCommand komut = new NpgsqlCommand("select ad from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        NpgsqlCommand komut2 = new NpgsqlCommand("select email from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        komut.ExecuteNonQuery();
                        komut2.ExecuteNonQuery();
                        string sahipIsim = komut.ExecuteScalar().ToString();
                        string email = komut2.ExecuteScalar().ToString();
                        baglanti.Close();

                        NpgsqlCommand command = new NpgsqlCommand("insert into randevu(randevu_saati, randevu_tarihi, randevu_doktoru, randevu_sahibi_tc, hasta_sahip_ad) values(@p1,@p2,@p3,@p4,@p5);", baglanti);
                        command.Parameters.AddWithValue("@p1", lblSaatOnBir.Text);
                        command.Parameters.AddWithValue("@p2", monthCalendar1.SelectionStart);
                        command.Parameters.AddWithValue("@p3", comboDoktor.Text);
                        command.Parameters.AddWithValue("@p4", txtHastaSahipTC.Text);
                        command.Parameters.AddWithValue("@p5", sahipIsim);

                        baglanti.Open();
                        command.ExecuteNonQuery();
                        baglanti.Close();

                        MailGonder(email, sahipIsim, monthCalendar1.SelectionStart.ToString("d"), lblSaatOnBir.Text, comboDoktor.Text);
                        ekranTemizle();
                        MessageBox.Show("Randevu Verildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void picBoxSaatOnBirBucuk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHastaSahipTC.Text == "" || comboDoktor.Text == "" || comboDoktor.Text == "Seçiniz...")
                {
                    MessageBox.Show("Gerekli Alanları Doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (VarMi(txtHastaSahipTC.Text) == 0)
                    {
                        MessageBox.Show("Böyle Bir Hasta Yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        baglanti.Open();
                        NpgsqlCommand komut = new NpgsqlCommand("select ad from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        NpgsqlCommand komut2 = new NpgsqlCommand("select email from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        komut.ExecuteNonQuery();
                        komut2.ExecuteNonQuery();
                        string sahipIsim = komut.ExecuteScalar().ToString();
                        string email = komut2.ExecuteScalar().ToString();
                        baglanti.Close();

                        NpgsqlCommand command = new NpgsqlCommand("insert into randevu(randevu_saati, randevu_tarihi, randevu_doktoru, randevu_sahibi_tc, hasta_sahip_ad) values(@p1,@p2,@p3,@p4,@p5);", baglanti);
                        command.Parameters.AddWithValue("@p1", lblSaatOnBirBucuk.Text);
                        command.Parameters.AddWithValue("@p2", monthCalendar1.SelectionStart);
                        command.Parameters.AddWithValue("@p3", comboDoktor.Text);
                        command.Parameters.AddWithValue("@p4", txtHastaSahipTC.Text);
                        command.Parameters.AddWithValue("@p5", sahipIsim);

                        baglanti.Open();
                        command.ExecuteNonQuery();
                        baglanti.Close();

                        MailGonder(email, sahipIsim, monthCalendar1.SelectionStart.ToString("d"), lblSaatOnBirBucuk.Text, comboDoktor.Text);
                        ekranTemizle();
                        MessageBox.Show("Randevu Verildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void picBoxSaatOnİki_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHastaSahipTC.Text == "" || comboDoktor.Text == "" || comboDoktor.Text == "Seçiniz...")
                {
                    MessageBox.Show("Gerekli Alanları Doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (VarMi(txtHastaSahipTC.Text) == 0)
                    {
                        MessageBox.Show("Böyle Bir Hasta Yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        baglanti.Open();
                        NpgsqlCommand komut = new NpgsqlCommand("select ad from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        NpgsqlCommand komut2 = new NpgsqlCommand("select email from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        komut.ExecuteNonQuery();
                        komut2.ExecuteNonQuery();
                        string sahipIsim = komut.ExecuteScalar().ToString();
                        string email = komut2.ExecuteScalar().ToString();
                        baglanti.Close();

                        NpgsqlCommand command = new NpgsqlCommand("insert into randevu(randevu_saati, randevu_tarihi, randevu_doktoru, randevu_sahibi_tc, hasta_sahip_ad) values(@p1,@p2,@p3,@p4,@p5);", baglanti);
                        command.Parameters.AddWithValue("@p1", lblSaatOnİki.Text);
                        command.Parameters.AddWithValue("@p2", monthCalendar1.SelectionStart);
                        command.Parameters.AddWithValue("@p3", comboDoktor.Text);
                        command.Parameters.AddWithValue("@p4", txtHastaSahipTC.Text);
                        command.Parameters.AddWithValue("@p5", sahipIsim);

                        baglanti.Open();
                        command.ExecuteNonQuery();
                        baglanti.Close();

                        MailGonder(email, sahipIsim, monthCalendar1.SelectionStart.ToString("d"), lblSaatOnİki.Text, comboDoktor.Text);
                        ekranTemizle();
                        MessageBox.Show("Randevu Verildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void picBoxSaatOnİkiOtuz_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHastaSahipTC.Text == "" || comboDoktor.Text == "" || comboDoktor.Text == "Seçiniz...")
                {
                    MessageBox.Show("Gerekli Alanları Doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (VarMi(txtHastaSahipTC.Text) == 0)
                    {
                        MessageBox.Show("Böyle Bir Hasta Yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        baglanti.Open();
                        NpgsqlCommand komut = new NpgsqlCommand("select ad from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        NpgsqlCommand komut2 = new NpgsqlCommand("select email from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        komut.ExecuteNonQuery();
                        komut2.ExecuteNonQuery();
                        string sahipIsim = komut.ExecuteScalar().ToString();
                        string email = komut2.ExecuteScalar().ToString();
                        baglanti.Close();

                        NpgsqlCommand command = new NpgsqlCommand("insert into randevu(randevu_saati, randevu_tarihi, randevu_doktoru, randevu_sahibi_tc, hasta_sahip_ad) values(@p1,@p2,@p3,@p4,@p5);", baglanti);
                        command.Parameters.AddWithValue("@p1", lblSaatOnİkiBucuk.Text);
                        command.Parameters.AddWithValue("@p2", monthCalendar1.SelectionStart);
                        command.Parameters.AddWithValue("@p3", comboDoktor.Text);
                        command.Parameters.AddWithValue("@p4", txtHastaSahipTC.Text);
                        command.Parameters.AddWithValue("@p5", sahipIsim);

                        baglanti.Open();
                        command.ExecuteNonQuery();
                        baglanti.Close();

                        MailGonder(email, sahipIsim, monthCalendar1.SelectionStart.ToString("d"), lblSaatOnİkiBucuk.Text, comboDoktor.Text);
                        ekranTemizle();
                        MessageBox.Show("Randevu Verildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void picBoxSaatOnUc_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHastaSahipTC.Text == "" || comboDoktor.Text == "" || comboDoktor.Text == "Seçiniz...")
                {
                    MessageBox.Show("Gerekli Alanları Doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (VarMi(txtHastaSahipTC.Text) == 0)
                    {
                        MessageBox.Show("Böyle Bir Hasta Yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        baglanti.Open();
                        NpgsqlCommand komut = new NpgsqlCommand("select ad from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        NpgsqlCommand komut2 = new NpgsqlCommand("select email from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        komut.ExecuteNonQuery();
                        komut2.ExecuteNonQuery();
                        string sahipIsim = komut.ExecuteScalar().ToString();
                        string email = komut2.ExecuteScalar().ToString();
                        baglanti.Close();

                        NpgsqlCommand command = new NpgsqlCommand("insert into randevu(randevu_saati, randevu_tarihi, randevu_doktoru, randevu_sahibi_tc, hasta_sahip_ad) values(@p1,@p2,@p3,@p4,@p5);", baglanti);
                        command.Parameters.AddWithValue("@p1", lblSaatOnUc.Text);
                        command.Parameters.AddWithValue("@p2", monthCalendar1.SelectionStart);
                        command.Parameters.AddWithValue("@p3", comboDoktor.Text);
                        command.Parameters.AddWithValue("@p4", txtHastaSahipTC.Text);
                        command.Parameters.AddWithValue("@p5", sahipIsim);

                        baglanti.Open();
                        command.ExecuteNonQuery();
                        baglanti.Close();

                        MailGonder(email, sahipIsim, monthCalendar1.SelectionStart.ToString("d"), lblSaatOnUc.Text, comboDoktor.Text);
                        ekranTemizle();
                        MessageBox.Show("Randevu Verildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void picBoxSaatOnUcOtuz_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHastaSahipTC.Text == "" || comboDoktor.Text == "" || comboDoktor.Text == "Seçiniz...")
                {
                    MessageBox.Show("Gerekli Alanları Doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (VarMi(txtHastaSahipTC.Text) == 0)
                    {
                        MessageBox.Show("Böyle Bir Hasta Yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        baglanti.Open();
                        NpgsqlCommand komut = new NpgsqlCommand("select ad from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        NpgsqlCommand komut2 = new NpgsqlCommand("select email from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        komut.ExecuteNonQuery();
                        komut2.ExecuteNonQuery();
                        string sahipIsim = komut.ExecuteScalar().ToString();
                        string email = komut2.ExecuteScalar().ToString();
                        baglanti.Close();

                        NpgsqlCommand command = new NpgsqlCommand("insert into randevu(randevu_saati, randevu_tarihi, randevu_doktoru, randevu_sahibi_tc, hasta_sahip_ad) values(@p1,@p2,@p3,@p4,@p5);", baglanti);
                        command.Parameters.AddWithValue("@p1", lblSaatOnUcOtuz.Text);
                        command.Parameters.AddWithValue("@p2", monthCalendar1.SelectionStart);
                        command.Parameters.AddWithValue("@p3", comboDoktor.Text);
                        command.Parameters.AddWithValue("@p4", txtHastaSahipTC.Text);
                        command.Parameters.AddWithValue("@p5", sahipIsim);

                        baglanti.Open();
                        command.ExecuteNonQuery();
                        baglanti.Close();

                        MailGonder(email, sahipIsim, monthCalendar1.SelectionStart.ToString("d"), lblSaatOnUcOtuz.Text, comboDoktor.Text);
                        ekranTemizle();
                        MessageBox.Show("Randevu Verildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void picBoxSaatOnDört_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtHastaSahipTC.Text == "" || comboDoktor.Text == "" || comboDoktor.Text == "Seçiniz...")
                {
                    MessageBox.Show("Gerekli Alanları Doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (VarMi(txtHastaSahipTC.Text) == 0)
                    {
                        MessageBox.Show("Böyle Bir Hasta Yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        baglanti.Open();
                        NpgsqlCommand komut = new NpgsqlCommand("select ad from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        NpgsqlCommand komut2 = new NpgsqlCommand("select email from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        komut.ExecuteNonQuery();
                        komut2.ExecuteNonQuery();
                        string sahipIsim = komut.ExecuteScalar().ToString();
                        string email = komut2.ExecuteScalar().ToString();
                        baglanti.Close();

                        NpgsqlCommand command = new NpgsqlCommand("insert into randevu(randevu_saati, randevu_tarihi, randevu_doktoru, randevu_sahibi_tc, hasta_sahip_ad) values(@p1,@p2,@p3,@p4,@p5);", baglanti);
                        command.Parameters.AddWithValue("@p1", lblSaatOnDört.Text);
                        command.Parameters.AddWithValue("@p2", monthCalendar1.SelectionStart);
                        command.Parameters.AddWithValue("@p3", comboDoktor.Text);
                        command.Parameters.AddWithValue("@p4", txtHastaSahipTC.Text);
                        command.Parameters.AddWithValue("@p5", sahipIsim);

                        baglanti.Open();
                        command.ExecuteNonQuery();
                        baglanti.Close();

                        MailGonder(email, sahipIsim, monthCalendar1.SelectionStart.ToString("d"), lblSaatOnDört.Text, comboDoktor.Text);
                        ekranTemizle();
                        MessageBox.Show("Randevu Verildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void picBoxSaatOnDörtOtuz_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHastaSahipTC.Text == "" || comboDoktor.Text == "" || comboDoktor.Text == "Seçiniz...")
                {
                    MessageBox.Show("Gerekli Alanları Doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (VarMi(txtHastaSahipTC.Text) == 0)
                    {
                        MessageBox.Show("Böyle Bir Hasta Yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        baglanti.Open();
                        NpgsqlCommand komut = new NpgsqlCommand("select ad from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        NpgsqlCommand komut2 = new NpgsqlCommand("select email from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        komut.ExecuteNonQuery();
                        komut2.ExecuteNonQuery();
                        string sahipIsim = komut.ExecuteScalar().ToString();
                        string email = komut2.ExecuteScalar().ToString();
                        baglanti.Close();

                        NpgsqlCommand command = new NpgsqlCommand("insert into randevu(randevu_saati, randevu_tarihi, randevu_doktoru, randevu_sahibi_tc, hasta_sahip_ad) values(@p1,@p2,@p3,@p4,@p5);", baglanti);
                        command.Parameters.AddWithValue("@p1", lblSaatOnDörtOtuz.Text);
                        command.Parameters.AddWithValue("@p2", monthCalendar1.SelectionStart);
                        command.Parameters.AddWithValue("@p3", comboDoktor.Text);
                        command.Parameters.AddWithValue("@p4", txtHastaSahipTC.Text);
                        command.Parameters.AddWithValue("@p5", sahipIsim);

                        baglanti.Open();
                        command.ExecuteNonQuery();
                        baglanti.Close();

                        MailGonder(email, sahipIsim, monthCalendar1.SelectionStart.ToString("d"), lblSaatOnDörtOtuz.Text, comboDoktor.Text);
                        ekranTemizle();
                        MessageBox.Show("Randevu Verildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void picBoxSaatOnBes_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHastaSahipTC.Text == "" || comboDoktor.Text == "" || comboDoktor.Text == "Seçiniz...")
                {
                    MessageBox.Show("Gerekli Alanları Doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (VarMi(txtHastaSahipTC.Text) == 0)
                    {
                        MessageBox.Show("Böyle Bir Hasta Yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        baglanti.Open();
                        NpgsqlCommand komut = new NpgsqlCommand("select ad from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        NpgsqlCommand komut2 = new NpgsqlCommand("select email from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        komut.ExecuteNonQuery();
                        komut2.ExecuteNonQuery();
                        string sahipIsim = komut.ExecuteScalar().ToString();
                        string email = komut2.ExecuteScalar().ToString();
                        baglanti.Close();

                        NpgsqlCommand command = new NpgsqlCommand("insert into randevu(randevu_saati, randevu_tarihi, randevu_doktoru, randevu_sahibi_tc, hasta_sahip_ad) values(@p1,@p2,@p3,@p4,@p5);", baglanti);
                        command.Parameters.AddWithValue("@p1", lblSaatOnBes.Text);
                        command.Parameters.AddWithValue("@p2", monthCalendar1.SelectionStart);
                        command.Parameters.AddWithValue("@p3", comboDoktor.Text);
                        command.Parameters.AddWithValue("@p4", txtHastaSahipTC.Text);
                        command.Parameters.AddWithValue("@p5", sahipIsim);

                        baglanti.Open();
                        command.ExecuteNonQuery();
                        baglanti.Close();

                        MailGonder(email, sahipIsim, monthCalendar1.SelectionStart.ToString("d"), lblSaatOnBes.Text, comboDoktor.Text);
                        ekranTemizle();
                        MessageBox.Show("Randevu Verildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void picBoxSaatOnBesOtuz_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHastaSahipTC.Text == "" || comboDoktor.Text == "" || comboDoktor.Text == "Seçiniz...")
                {
                    MessageBox.Show("Gerekli Alanları Doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (VarMi(txtHastaSahipTC.Text) == 0)
                    {
                        MessageBox.Show("Böyle Bir Hasta Yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        baglanti.Open();
                        NpgsqlCommand komut = new NpgsqlCommand("select ad from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        NpgsqlCommand komut2 = new NpgsqlCommand("select email from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        komut.ExecuteNonQuery();
                        komut2.ExecuteNonQuery();
                        string sahipIsim = komut.ExecuteScalar().ToString();
                        string email = komut2.ExecuteScalar().ToString();
                        baglanti.Close();

                        NpgsqlCommand command = new NpgsqlCommand("insert into randevu(randevu_saati, randevu_tarihi, randevu_doktoru, randevu_sahibi_tc, hasta_sahip_ad) values(@p1,@p2,@p3,@p4,@p5);", baglanti);
                        command.Parameters.AddWithValue("@p1", lblSaatOnBesOtuz.Text);
                        command.Parameters.AddWithValue("@p2", monthCalendar1.SelectionStart);
                        command.Parameters.AddWithValue("@p3", comboDoktor.Text);
                        command.Parameters.AddWithValue("@p4", txtHastaSahipTC.Text);
                        command.Parameters.AddWithValue("@p5", sahipIsim);

                        baglanti.Open();
                        command.ExecuteNonQuery();
                        baglanti.Close();

                        MailGonder(email, sahipIsim, monthCalendar1.SelectionStart.ToString("d"), lblSaatOnBesOtuz.Text, comboDoktor.Text);
                        ekranTemizle();
                        MessageBox.Show("Randevu Verildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void picBoxSaatOnAltı_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtHastaSahipTC.Text == "" || comboDoktor.Text == "" || comboDoktor.Text == "Seçiniz...")
                {
                    MessageBox.Show("Gerekli Alanları Doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (VarMi(txtHastaSahipTC.Text) == 0)
                    {
                        MessageBox.Show("Böyle Bir Hasta Yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        baglanti.Open();
                        NpgsqlCommand komut = new NpgsqlCommand("select ad from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        NpgsqlCommand komut2 = new NpgsqlCommand("select email from hasta_sahip_kayit where tc='" + txtHastaSahipTC.Text + "'", baglanti);
                        komut.ExecuteNonQuery();
                        komut2.ExecuteNonQuery();
                        string sahipIsim = komut.ExecuteScalar().ToString();
                        string email = komut2.ExecuteScalar().ToString();
                        baglanti.Close();

                        NpgsqlCommand command = new NpgsqlCommand("insert into randevu(randevu_saati, randevu_tarihi, randevu_doktoru, randevu_sahibi_tc, hasta_sahip_ad) values(@p1,@p2,@p3,@p4,@p5);", baglanti);
                        command.Parameters.AddWithValue("@p1", lblSaatOnAltı.Text);
                        command.Parameters.AddWithValue("@p2", monthCalendar1.SelectionStart);
                        command.Parameters.AddWithValue("@p3", comboDoktor.Text);
                        command.Parameters.AddWithValue("@p4", txtHastaSahipTC.Text);
                        command.Parameters.AddWithValue("@p5", sahipIsim);

                        baglanti.Open();
                        command.ExecuteNonQuery();
                        baglanti.Close();

                        MailGonder(email, sahipIsim, monthCalendar1.SelectionStart.ToString("d"), lblSaatOnAltı.Text, comboDoktor.Text);
                        ekranTemizle();
                        MessageBox.Show("Randevu Verildi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}
