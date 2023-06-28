namespace Veteriner_Takip_Sistemi
{
    partial class AnaSayfa
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaSayfa));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnDoktorListele = new FontAwesome.Sharp.IconButton();
            this.btnHastaSahipKayit = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.btnMuhasebe = new FontAwesome.Sharp.IconButton();
            this.btnHastaSahipListele = new FontAwesome.Sharp.IconButton();
            this.btnStok = new FontAwesome.Sharp.IconButton();
            this.btnHastaListele = new FontAwesome.Sharp.IconButton();
            this.btnSatis = new FontAwesome.Sharp.IconButton();
            this.btnHastaKayit = new FontAwesome.Sharp.IconButton();
            this.btnDoktorKayit = new FontAwesome.Sharp.IconButton();
            this.btnRandavuVer = new FontAwesome.Sharp.IconButton();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.btnMaximize = new FontAwesome.Sharp.IconButton();
            this.btnMinimize = new FontAwesome.Sharp.IconButton();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.btnAra = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.btnSil = new FontAwesome.Sharp.IconButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtSil = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(147)))), ((int)(((byte)(10)))));
            this.panelMenu.Controls.Add(this.btnDoktorListele);
            this.panelMenu.Controls.Add(this.btnHastaSahipKayit);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Controls.Add(this.btnMuhasebe);
            this.panelMenu.Controls.Add(this.btnHastaSahipListele);
            this.panelMenu.Controls.Add(this.btnStok);
            this.panelMenu.Controls.Add(this.btnHastaListele);
            this.panelMenu.Controls.Add(this.btnSatis);
            this.panelMenu.Controls.Add(this.btnHastaKayit);
            this.panelMenu.Controls.Add(this.btnDoktorKayit);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 561);
            this.panelMenu.TabIndex = 0;
            // 
            // btnDoktorListele
            // 
            this.btnDoktorListele.FlatAppearance.BorderSize = 0;
            this.btnDoktorListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoktorListele.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDoktorListele.ForeColor = System.Drawing.Color.White;
            this.btnDoktorListele.IconChar = FontAwesome.Sharp.IconChar.UserMd;
            this.btnDoktorListele.IconColor = System.Drawing.Color.White;
            this.btnDoktorListele.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDoktorListele.IconSize = 40;
            this.btnDoktorListele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoktorListele.Location = new System.Drawing.Point(0, 470);
            this.btnDoktorListele.Name = "btnDoktorListele";
            this.btnDoktorListele.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDoktorListele.Size = new System.Drawing.Size(200, 40);
            this.btnDoktorListele.TabIndex = 10;
            this.btnDoktorListele.Text = "Doktor Bilgileri";
            this.btnDoktorListele.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoktorListele.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDoktorListele.UseVisualStyleBackColor = true;
            this.btnDoktorListele.Click += new System.EventHandler(this.btnDoktorListele_Click);
            // 
            // btnHastaSahipKayit
            // 
            this.btnHastaSahipKayit.FlatAppearance.BorderSize = 0;
            this.btnHastaSahipKayit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHastaSahipKayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHastaSahipKayit.ForeColor = System.Drawing.Color.White;
            this.btnHastaSahipKayit.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnHastaSahipKayit.IconColor = System.Drawing.Color.White;
            this.btnHastaSahipKayit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHastaSahipKayit.IconSize = 40;
            this.btnHastaSahipKayit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHastaSahipKayit.Location = new System.Drawing.Point(0, 140);
            this.btnHastaSahipKayit.Name = "btnHastaSahipKayit";
            this.btnHastaSahipKayit.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHastaSahipKayit.Size = new System.Drawing.Size(200, 40);
            this.btnHastaSahipKayit.TabIndex = 11;
            this.btnHastaSahipKayit.Text = "Hasta Sahip Kayıt";
            this.btnHastaSahipKayit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHastaSahipKayit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHastaSahipKayit.UseVisualStyleBackColor = true;
            this.btnHastaSahipKayit.Click += new System.EventHandler(this.btnHastaSahipKayit_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.btnHome);
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 100);
            this.panelLogo.TabIndex = 1;
            // 
            // btnHome
            // 
            this.btnHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(0, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(200, 100);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnMuhasebe
            // 
            this.btnMuhasebe.FlatAppearance.BorderSize = 0;
            this.btnMuhasebe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMuhasebe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMuhasebe.ForeColor = System.Drawing.Color.White;
            this.btnMuhasebe.IconChar = FontAwesome.Sharp.IconChar.Calculator;
            this.btnMuhasebe.IconColor = System.Drawing.Color.White;
            this.btnMuhasebe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMuhasebe.IconSize = 40;
            this.btnMuhasebe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMuhasebe.Location = new System.Drawing.Point(0, 270);
            this.btnMuhasebe.Name = "btnMuhasebe";
            this.btnMuhasebe.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnMuhasebe.Size = new System.Drawing.Size(200, 40);
            this.btnMuhasebe.TabIndex = 6;
            this.btnMuhasebe.Text = "Muhasebe";
            this.btnMuhasebe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMuhasebe.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMuhasebe.UseVisualStyleBackColor = true;
            this.btnMuhasebe.Click += new System.EventHandler(this.btnMuhasebe_Click);
            // 
            // btnHastaSahipListele
            // 
            this.btnHastaSahipListele.FlatAppearance.BorderSize = 0;
            this.btnHastaSahipListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHastaSahipListele.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHastaSahipListele.ForeColor = System.Drawing.Color.White;
            this.btnHastaSahipListele.IconChar = FontAwesome.Sharp.IconChar.Person;
            this.btnHastaSahipListele.IconColor = System.Drawing.Color.White;
            this.btnHastaSahipListele.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHastaSahipListele.IconSize = 40;
            this.btnHastaSahipListele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHastaSahipListele.Location = new System.Drawing.Point(0, 430);
            this.btnHastaSahipListele.Name = "btnHastaSahipListele";
            this.btnHastaSahipListele.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHastaSahipListele.Size = new System.Drawing.Size(200, 40);
            this.btnHastaSahipListele.TabIndex = 9;
            this.btnHastaSahipListele.Text = "Hasta Sahip Bilgileri";
            this.btnHastaSahipListele.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHastaSahipListele.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHastaSahipListele.UseVisualStyleBackColor = true;
            this.btnHastaSahipListele.Click += new System.EventHandler(this.btnHastaSahipListele_Click);
            // 
            // btnStok
            // 
            this.btnStok.FlatAppearance.BorderSize = 0;
            this.btnStok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStok.ForeColor = System.Drawing.Color.White;
            this.btnStok.IconChar = FontAwesome.Sharp.IconChar.Box;
            this.btnStok.IconColor = System.Drawing.Color.White;
            this.btnStok.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnStok.IconSize = 40;
            this.btnStok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStok.Location = new System.Drawing.Point(0, 350);
            this.btnStok.Name = "btnStok";
            this.btnStok.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnStok.Size = new System.Drawing.Size(200, 40);
            this.btnStok.TabIndex = 7;
            this.btnStok.Text = "Stok";
            this.btnStok.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStok.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStok.UseVisualStyleBackColor = true;
            this.btnStok.Click += new System.EventHandler(this.btnStok_Click);
            // 
            // btnHastaListele
            // 
            this.btnHastaListele.FlatAppearance.BorderSize = 0;
            this.btnHastaListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHastaListele.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHastaListele.ForeColor = System.Drawing.Color.White;
            this.btnHastaListele.IconChar = FontAwesome.Sharp.IconChar.Dog;
            this.btnHastaListele.IconColor = System.Drawing.Color.White;
            this.btnHastaListele.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHastaListele.IconSize = 40;
            this.btnHastaListele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHastaListele.Location = new System.Drawing.Point(0, 390);
            this.btnHastaListele.Name = "btnHastaListele";
            this.btnHastaListele.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHastaListele.Size = new System.Drawing.Size(200, 40);
            this.btnHastaListele.TabIndex = 8;
            this.btnHastaListele.Text = "Hasta Bilgileri";
            this.btnHastaListele.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHastaListele.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHastaListele.UseVisualStyleBackColor = true;
            this.btnHastaListele.Click += new System.EventHandler(this.btnHastaListele_Click);
            // 
            // btnSatis
            // 
            this.btnSatis.FlatAppearance.BorderSize = 0;
            this.btnSatis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSatis.ForeColor = System.Drawing.Color.White;
            this.btnSatis.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.btnSatis.IconColor = System.Drawing.Color.White;
            this.btnSatis.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSatis.IconSize = 40;
            this.btnSatis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSatis.Location = new System.Drawing.Point(0, 310);
            this.btnSatis.Name = "btnSatis";
            this.btnSatis.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnSatis.Size = new System.Drawing.Size(200, 40);
            this.btnSatis.TabIndex = 5;
            this.btnSatis.Text = "Satış";
            this.btnSatis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSatis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSatis.UseVisualStyleBackColor = true;
            this.btnSatis.Click += new System.EventHandler(this.btnSatis_Click);
            // 
            // btnHastaKayit
            // 
            this.btnHastaKayit.FlatAppearance.BorderSize = 0;
            this.btnHastaKayit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHastaKayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHastaKayit.ForeColor = System.Drawing.Color.White;
            this.btnHastaKayit.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnHastaKayit.IconColor = System.Drawing.Color.White;
            this.btnHastaKayit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHastaKayit.IconSize = 40;
            this.btnHastaKayit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHastaKayit.Location = new System.Drawing.Point(0, 100);
            this.btnHastaKayit.Name = "btnHastaKayit";
            this.btnHastaKayit.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnHastaKayit.Size = new System.Drawing.Size(200, 40);
            this.btnHastaKayit.TabIndex = 2;
            this.btnHastaKayit.Text = "Hasta Kayıt";
            this.btnHastaKayit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHastaKayit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHastaKayit.UseVisualStyleBackColor = true;
            this.btnHastaKayit.Click += new System.EventHandler(this.btnHastaKayit_Click);
            // 
            // btnDoktorKayit
            // 
            this.btnDoktorKayit.FlatAppearance.BorderSize = 0;
            this.btnDoktorKayit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoktorKayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDoktorKayit.ForeColor = System.Drawing.Color.White;
            this.btnDoktorKayit.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.btnDoktorKayit.IconColor = System.Drawing.Color.White;
            this.btnDoktorKayit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDoktorKayit.IconSize = 40;
            this.btnDoktorKayit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoktorKayit.Location = new System.Drawing.Point(0, 180);
            this.btnDoktorKayit.Name = "btnDoktorKayit";
            this.btnDoktorKayit.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDoktorKayit.Size = new System.Drawing.Size(200, 40);
            this.btnDoktorKayit.TabIndex = 3;
            this.btnDoktorKayit.Text = "Doktor Kayıt";
            this.btnDoktorKayit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoktorKayit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDoktorKayit.UseVisualStyleBackColor = true;
            this.btnDoktorKayit.Click += new System.EventHandler(this.btnDoktorKayit_Click);
            // 
            // btnRandavuVer
            // 
            this.btnRandavuVer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(147)))), ((int)(((byte)(10)))));
            this.btnRandavuVer.FlatAppearance.BorderSize = 0;
            this.btnRandavuVer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRandavuVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRandavuVer.ForeColor = System.Drawing.Color.White;
            this.btnRandavuVer.IconChar = FontAwesome.Sharp.IconChar.CalendarDays;
            this.btnRandavuVer.IconColor = System.Drawing.Color.White;
            this.btnRandavuVer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRandavuVer.IconSize = 40;
            this.btnRandavuVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRandavuVer.Location = new System.Drawing.Point(0, 230);
            this.btnRandavuVer.Name = "btnRandavuVer";
            this.btnRandavuVer.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnRandavuVer.Size = new System.Drawing.Size(200, 40);
            this.btnRandavuVer.TabIndex = 4;
            this.btnRandavuVer.Text = "Randevu Ver";
            this.btnRandavuVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRandavuVer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRandavuVer.UseVisualStyleBackColor = false;
            this.btnRandavuVer.Click += new System.EventHandler(this.btnRandavuVer_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(120)))), ((int)(((byte)(10)))));
            this.panelTitleBar.Controls.Add(this.panelButtons);
            this.panelTitleBar.Controls.Add(this.lblTitleChildForm);
            this.panelTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(200, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(784, 100);
            this.panelTitleBar.TabIndex = 5;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.Controls.Add(this.btnExit);
            this.panelButtons.Controls.Add(this.btnMaximize);
            this.panelButtons.Controls.Add(this.btnMinimize);
            this.panelButtons.Location = new System.Drawing.Point(652, 12);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(120, 40);
            this.panelButtons.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(120)))), ((int)(((byte)(10)))));
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnExit.IconColor = System.Drawing.Color.White;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 40;
            this.btnExit.Location = new System.Drawing.Point(80, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 40);
            this.btnExit.TabIndex = 4;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(120)))), ((int)(((byte)(10)))));
            this.btnMaximize.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btnMaximize.IconColor = System.Drawing.Color.White;
            this.btnMaximize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMaximize.IconSize = 40;
            this.btnMaximize.Location = new System.Drawing.Point(40, 0);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(40, 40);
            this.btnMaximize.TabIndex = 5;
            this.btnMaximize.UseVisualStyleBackColor = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(120)))), ((int)(((byte)(10)))));
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMinimize.IconSize = 40;
            this.btnMinimize.Location = new System.Drawing.Point(0, 0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(40, 40);
            this.btnMinimize.TabIndex = 6;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitleChildForm.Location = new System.Drawing.Point(90, 33);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(57, 39);
            this.lblTitleChildForm.TabIndex = 1;
            this.lblTitleChildForm.Text = "Ev";
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(120)))), ((int)(((byte)(12)))));
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.White;
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.IconSize = 60;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(24, 24);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(60, 60);
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(165)))), ((int)(((byte)(12)))));
            this.panelDesktop.Controls.Add(this.label2);
            this.panelDesktop.Controls.Add(this.txtSil);
            this.panelDesktop.Controls.Add(this.btnAra);
            this.panelDesktop.Controls.Add(this.label1);
            this.panelDesktop.Controls.Add(this.txtAra);
            this.panelDesktop.Controls.Add(this.btnSil);
            this.panelDesktop.Controls.Add(this.dataGridView1);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(200, 100);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(784, 461);
            this.panelDesktop.TabIndex = 7;
            // 
            // btnAra
            // 
            this.btnAra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAra.ForeColor = System.Drawing.Color.White;
            this.btnAra.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnAra.IconColor = System.Drawing.Color.White;
            this.btnAra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAra.IconSize = 22;
            this.btnAra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAra.Location = new System.Drawing.Point(627, 6);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(145, 30);
            this.btnAra.TabIndex = 48;
            this.btnAra.Text = "Ara";
            this.btnAra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAra.UseVisualStyleBackColor = true;
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 15);
            this.label1.TabIndex = 47;
            this.label1.Text = "Sahip TC ile Randavu Ara";
            // 
            // txtAra
            // 
            this.txtAra.Location = new System.Drawing.Point(197, 11);
            this.txtAra.MaxLength = 11;
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(424, 20);
            this.txtAra.TabIndex = 46;
            this.txtAra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAra_KeyPress);
            // 
            // btnSil
            // 
            this.btnSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSil.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.Color.White;
            this.btnSil.IconChar = FontAwesome.Sharp.IconChar.Backspace;
            this.btnSil.IconColor = System.Drawing.Color.White;
            this.btnSil.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSil.Location = new System.Drawing.Point(642, 389);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(130, 60);
            this.btnSil.TabIndex = 45;
            this.btnSil.Text = "Sil";
            this.btnSil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(766, 316);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // txtSil
            // 
            this.txtSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSil.Location = new System.Drawing.Point(516, 429);
            this.txtSil.Name = "txtSil";
            this.txtSil.ReadOnly = true;
            this.txtSil.Size = new System.Drawing.Size(120, 20);
            this.txtSil.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(486, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 15);
            this.label2.TabIndex = 50;
            this.label2.Text = "Sil";
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.btnRandavuVer);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnaSayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AnaSayfa";
            this.Load += new System.EventHandler(this.AnaSayfa_Load);
            this.Resize += new System.EventHandler(this.AnaSayfa_Resize);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.panelDesktop.ResumeLayout(false);
            this.panelDesktop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton btnDoktorListele;
        private FontAwesome.Sharp.IconButton btnHastaSahipListele;
        private FontAwesome.Sharp.IconButton btnHastaListele;
        private FontAwesome.Sharp.IconButton btnStok;
        private FontAwesome.Sharp.IconButton btnMuhasebe;
        private FontAwesome.Sharp.IconButton btnSatis;
        private FontAwesome.Sharp.IconButton btnRandavuVer;
        private FontAwesome.Sharp.IconButton btnDoktorKayit;
        private FontAwesome.Sharp.IconButton btnHastaKayit;
        private FontAwesome.Sharp.IconButton btnHastaSahipKayit;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Label lblTitleChildForm;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Panel panelButtons;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private FontAwesome.Sharp.IconButton btnMaximize;
        private FontAwesome.Sharp.IconButton btnExit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private FontAwesome.Sharp.IconButton btnSil;
        private System.Windows.Forms.TextBox txtAra;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnAra;
        private System.Windows.Forms.TextBox txtSil;
        private System.Windows.Forms.Label label2;
    }
}

