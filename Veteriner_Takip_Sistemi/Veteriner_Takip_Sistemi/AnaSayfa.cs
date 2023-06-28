using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using FontAwesome.Sharp;
using Npgsql;
using Color = System.Drawing.Color;

namespace Veteriner_Takip_Sistemi
{
    public partial class AnaSayfa : Form
    {

        //Fields
        private IconButton currnetBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        //Constructor
        public AnaSayfa()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7,40);
            panelMenu.Controls.Add(leftBorderBtn);

            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=vtsDB; user ID=postgres; password=1234");

        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(34, 47, 218);
            public static Color color2 = Color.FromArgb(34, 47, 218);
            public static Color color3 = Color.FromArgb(200, 195, 49);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.FromArgb(17, 129, 181);
            public static Color color8 = Color.FromArgb(217, 221, 29);
            public static Color color9 = Color.FromArgb(221, 29, 29);
            public static Color color10 = Color.FromArgb(34, 47, 218);
        }

        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currnetBtn = (IconButton)senderBtn;
                currnetBtn.BackColor = Color.FromArgb(39, 147, 10);
                currnetBtn.ForeColor = color;
                currnetBtn.TextAlign = ContentAlignment.MiddleCenter;
                currnetBtn.IconColor = color;
                currnetBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currnetBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0,currnetBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Icon Currnet Child Form
                iconCurrentChildForm.IconChar = currnetBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void randevulistele()
        {
            try
            {
                string sorgu = "select * from randevu";
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

        private void randevusil(int kimlik)
        {
            try
            {
                string sorgu = "delete from randevu where randevu_id=@p1";
                NpgsqlCommand komut = new NpgsqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@p1", kimlik);
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Randevu Silme İşlemi Başarılı.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisableButton()
        {
            if (currnetBtn!=null)
            {
                currnetBtn.BackColor = Color.FromArgb(39, 147, 10);
                currnetBtn.ForeColor = Color.White;
                currnetBtn.TextAlign = ContentAlignment.MiddleLeft;
                currnetBtn.IconColor = Color.White;
                currnetBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currnetBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }

        private void btnHastaKayit_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new HastaKayit());
        }

        private void btnDoktorKayit_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            OpenChildForm(new DoktorKayit());
        }

        private void btnRandavuVer_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            OpenChildForm(new RandevuVer());
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new Satis());
        }

        private void btnMuhasebe_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new Muhasebe());
        }

        private void btnStok_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new Stok());
        }

        private void btnHastaListele_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color9);
            OpenChildForm(new HastaBilgileri());
        }

        private void btnHastaSahipListele_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color9);
            OpenChildForm(new HastaSahipBilgileri());
        }

        private void btnDoktorListele_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color9);
            OpenChildForm(new DoktorBilgileri());
        }

        private void btnHastaSahipKayit_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color10);
            OpenChildForm(new HastaSahipKayit());
        }

        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            DisableButton();
            randevulistele();

            dataGridView1.ForeColor = Color.Black; 
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildForm!=null)
            {
                currentChildForm.Close();
                Reset();
            }

            else
            {
                Reset();
            }
            
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.White;
            lblTitleChildForm.Text = "Ev";
            randevulistele();
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AnaSayfa_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                FormBorderStyle = FormBorderStyle.None;
            else
                FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void txtAra_KeyPress(object sender, KeyPressEventArgs e)
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
                randevulistele();
            }

            else
            {
                try
                {
                    DataTable veritablosu = new DataTable();
                    baglanti.Open();
                    NpgsqlDataAdapter ara = new NpgsqlDataAdapter("select * from randevu where randevu_sahibi_tc like '" + txtAra.Text + "'", baglanti);
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (txtSil.Text == "")
            {
                MessageBox.Show("Silinecek Randevuyu Seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                randevusil(Convert.ToInt32(txtSil.Text));
                randevulistele();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSil.Text = dataGridView1.CurrentRow.Cells["randevu_id"].Value.ToString();
        }
    }
}
