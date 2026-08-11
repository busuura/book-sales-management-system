using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace kitap_satış_takip_sistemi__projesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnkayit_Click(object sender, EventArgs e)
        {
            Kayıt_Formu kayitEkrani = new Kayıt_Formu();
            this.Hide();
            kayitEkrani.Show();
        }

        private void btngiris_Click_1(object sender, EventArgs e)
        {
           
            
            if (string.IsNullOrWhiteSpace(giris_ad.Text) || string.IsNullOrWhiteSpace(giris_sifre.Text))
            {
                MessageBox.Show("Lütfen Ad Soyad ve Şifre alanlarını boş bırakmayınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection baglanti = new SqlConnection(@"Data Source=BERAT\SQLEXPRESS;Initial Catalog=görsel_proje;Integrated Security=True");

            try
            {
                baglanti.Open();

                
                string sorgu = "SELECT * FROM Personeller WHERE (ad + ' ' + soyad) = @adSoyad AND sifre=@sifre";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@adSoyad", giris_ad.Text.Trim());
                komut.Parameters.AddWithValue("@sifre", giris_sifre.Text.Trim());

                SqlDataReader oku = komut.ExecuteReader();

                if (oku.Read())
                {
                    MessageBox.Show("Giriş Başarılı! Hoş geldiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Anasayfa ana = new Anasayfa();
                    ana.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Ad Soyad veya Şifre hatalı! Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Giriş yapılırken sistemsel bir hata oluştu: " + hata.Message, "Sistem Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }
    }
        
  }  
    
    

