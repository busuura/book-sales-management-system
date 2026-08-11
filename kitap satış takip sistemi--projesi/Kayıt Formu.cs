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
    public partial class Kayıt_Formu : Form
    {
        public Kayıt_Formu()
        {
            InitializeComponent();
        }

        private void Kayıt_Formu_Load(object sender, EventArgs e)
        {


        }

        private void btn_uye_ol_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Tc.Text) ||
        string.IsNullOrWhiteSpace(ad.Text) ||
        string.IsNullOrWhiteSpace(txtsoyad.Text) ||
        string.IsNullOrWhiteSpace(txttel.Text) ||
        string.IsNullOrWhiteSpace(sifre.Text))
            {
              
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

     

            SqlConnection baglanti = new SqlConnection(@"Data Source=BERAT\SQLEXPRESS;Initial Catalog=görsel_proje;Integrated Security=True");

            try
            {
                baglanti.Open();

                string sorgu = "INSERT INTO Personeller (tc, ad, soyad, tel, sifre) VALUES (@tc, @ad, @soyad, @tel, @sifre)";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@tc", Tc.Text);
                komut.Parameters.AddWithValue("@ad", ad.Text);
                komut.Parameters.AddWithValue("@soyad", txtsoyad.Text);
                komut.Parameters.AddWithValue("@tel", txttel.Text);
                komut.Parameters.AddWithValue("@sifre", sifre.Text);

                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Personel hesabı başarıyla oluşturuldu! Şimdi giriş yapabilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form giris = Application.OpenForms["Form1"];
                if (giris != null)
                {
                    giris.Show();
                }
                else
                {
                    Form1 yeniGiris = new Form1();
                    yeniGiris.Show();
                }

                this.Hide();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Veritabanına kaydedilirken bir hata oluştu: " + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }
    }
}
