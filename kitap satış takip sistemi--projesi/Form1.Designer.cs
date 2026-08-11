namespace kitap_satış_takip_sistemi__projesi
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.giris_ad = new System.Windows.Forms.TextBox();
            this.giris_sifre = new System.Windows.Forms.TextBox();
            this.ad = new System.Windows.Forms.Label();
            this.sifre = new System.Windows.Forms.Label();
            this.btngiris = new System.Windows.Forms.Button();
            this.btnkayit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(967, 100);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(43, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(180, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(732, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "PERSONEL GİRİŞİ - KİTAP SATIŞ TAKİP SİSTEMİ";
            // 
            // giris_ad
            // 
            this.giris_ad.Location = new System.Drawing.Point(344, 180);
            this.giris_ad.Name = "giris_ad";
            this.giris_ad.Size = new System.Drawing.Size(253, 22);
            this.giris_ad.TabIndex = 1;
            // 
            // giris_sifre
            // 
            this.giris_sifre.Location = new System.Drawing.Point(343, 243);
            this.giris_sifre.Name = "giris_sifre";
            this.giris_sifre.Size = new System.Drawing.Size(254, 22);
            this.giris_sifre.TabIndex = 2;
            this.giris_sifre.UseSystemPasswordChar = true;
            // 
            // ad
            // 
            this.ad.AutoSize = true;
            this.ad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ad.Location = new System.Drawing.Point(155, 177);
            this.ad.Name = "ad";
            this.ad.Size = new System.Drawing.Size(139, 25);
            this.ad.TabIndex = 3;
            this.ad.Text = "Kullanıcı Adı:";
            // 
            // sifre
            // 
            this.sifre.AutoSize = true;
            this.sifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifre.Location = new System.Drawing.Point(230, 243);
            this.sifre.Name = "sifre";
            this.sifre.Size = new System.Drawing.Size(64, 25);
            this.sifre.TabIndex = 4;
            this.sifre.Text = "Şifre:";
            // 
            // btngiris
            // 
            this.btngiris.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btngiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btngiris.Location = new System.Drawing.Point(478, 356);
            this.btngiris.Name = "btngiris";
            this.btngiris.Size = new System.Drawing.Size(165, 64);
            this.btngiris.TabIndex = 5;
            this.btngiris.Text = "Giriş";
            this.btngiris.UseVisualStyleBackColor = false;
            this.btngiris.Click += new System.EventHandler(this.btngiris_Click_1);
            // 
            // btnkayit
            // 
            this.btnkayit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnkayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnkayit.Location = new System.Drawing.Point(224, 356);
            this.btnkayit.Name = "btnkayit";
            this.btnkayit.Size = new System.Drawing.Size(158, 64);
            this.btnkayit.TabIndex = 6;
            this.btnkayit.Text = "Yeni Kayıt";
            this.btnkayit.UseVisualStyleBackColor = false;
            this.btnkayit.Click += new System.EventHandler(this.btnkayit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 532);
            this.Controls.Add(this.btnkayit);
            this.Controls.Add(this.btngiris);
            this.Controls.Add(this.sifre);
            this.Controls.Add(this.ad);
            this.Controls.Add(this.giris_sifre);
            this.Controls.Add(this.giris_ad);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Giriş Formu";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox giris_ad;
        private System.Windows.Forms.TextBox giris_sifre;
        private System.Windows.Forms.Label ad;
        private System.Windows.Forms.Label sifre;
        private System.Windows.Forms.Button btngiris;
        private System.Windows.Forms.Button btnkayit;
    }
}

