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
    public partial class Satış : Form
    {
        public Satış()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            Anasayfa anaEkrani = new Anasayfa();
            anaEkrani.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void TutarHesapla()
        {
            if (cmbkitap.SelectedItem != null && numsatıs.Value > 0)
            {
                SqlConnection baglanti = new SqlConnection(@"Data Source=BERAT\SQLEXPRESS;Initial Catalog=görsel_proje;Integrated Security=True");
                try
                {
                    if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                    SqlCommand komut = new SqlCommand("SELECT fiyat FROM Kitaplar WHERE kitapAdi=@ad", baglanti);
                    komut.Parameters.AddWithValue("@ad", cmbkitap.SelectedItem.ToString());
                    object sonuc = komut.ExecuteScalar();

                    if (sonuc != null)
                    {
                        decimal kitapFiyati = Convert.ToDecimal(sonuc);
                        int adet = Convert.ToInt32(numsatıs.Value);

                        toplam.Text = (kitapFiyati * adet).ToString("0.00");
                    }
                    baglanti.Close();
                }
                catch (Exception)
                {
                    if (baglanti.State == ConnectionState.Open) baglanti.Close();
                }
            }
            else
            {
                toplam.Text = "0.00";
            }
        }
        private void Satış_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=BERAT\SQLEXPRESS;Initial Catalog=görsel_proje;Integrated Security=True");
            try
            {
       
                SqlCommand komutMus = new SqlCommand("SELECT ad + ' ' + soyad AS Musteri FROM Musteriler", baglanti);
                baglanti.Open();
                SqlDataReader okuMus = komutMus.ExecuteReader();
                cmbmus.Items.Clear();
                while (okuMus.Read()) { cmbmus.Items.Add(okuMus["Musteri"].ToString()); }
                baglanti.Close();

             
                SqlCommand komutKitap = new SqlCommand("SELECT kitapAdi FROM Kitaplar", baglanti);
                baglanti.Open();
                SqlDataReader okuKitap = komutKitap.ExecuteReader();
                cmbkitap.Items.Clear();
                while (okuKitap.Read()) { cmbkitap.Items.Add(okuKitap["kitapAdi"].ToString()); }
                baglanti.Close();

            
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT barkod, kitapAdi, fiyat, stok FROM Kitaplar", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            catch (Exception) { if (baglanti.State == ConnectionState.Open) baglanti.Close(); }
        }

        private void cmbkitap_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=BERAT\SQLEXPRESS;Initial Catalog=görsel_proje;Integrated Security=True");

            if (cmbkitap.SelectedItem != null && numsatıs.Value > 0)
            {
                try
                {
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("SELECT fiyat FROM Kitaplar WHERE kitapAdi=@ad", baglanti);
                    komut.Parameters.AddWithValue("@ad", cmbkitap.SelectedItem.ToString());
                    object sonuc = komut.ExecuteScalar();

                    if (sonuc != null)
                    {
                        decimal kitapFiyati = Convert.ToDecimal(sonuc);
                        int adet = Convert.ToInt32(numsatıs.Value);
                        toplam.Text = (kitapFiyati * adet).ToString("0.00");
                    }
                    baglanti.Close();
                }
                catch (Exception) 
                { 
                    if (baglanti.State == ConnectionState.Open) baglanti.Close(); 
                }

            }
            TutarHesapla();
        }

        private void btnmus_ekle_Click(object sender, EventArgs e)
        {
            if (cmbkitap.SelectedItem == null || cmbmus.SelectedItem == null)
            {
                MessageBox.Show("Lütfen müşteri ve kitap seçimini yapın!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numsatıs.Value <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir satış adedi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            TutarHesapla();

            SqlConnection baglanti = new SqlConnection(@"Data Source=BERAT\SQLEXPRESS;Initial Catalog=görsel_proje;Integrated Security=True");
            try
            {
                baglanti.Open();

     
                SqlCommand kontrolKomut = new SqlCommand("SELECT stok FROM Kitaplar WHERE kitapAdi=@kitapAd", baglanti);
                kontrolKomut.Parameters.AddWithValue("@kitapAd", cmbkitap.SelectedItem.ToString());
                int mevcutStok = Convert.ToInt32(kontrolKomut.ExecuteScalar());
                int istenenAdet = Convert.ToInt32(numsatıs.Value);

                if (mevcutStok < istenenAdet)
                {
                    MessageBox.Show("Yetersiz stok! Depoda sadece " + mevcutStok + " adet bu kitaptan var.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    baglanti.Close();
                    return;
                }

   
                string stokSorgusu = "UPDATE Kitaplar SET stok = stok - @satilan WHERE kitapAdi=@kitapAd";
                SqlCommand stokKomut = new SqlCommand(stokSorgusu, baglanti);
                stokKomut.Parameters.AddWithValue("@satilan", istenenAdet);
                stokKomut.Parameters.AddWithValue("@kitapAd", cmbkitap.SelectedItem.ToString());
                stokKomut.ExecuteNonQuery();

                MessageBox.Show("Satış başarıyla gerçekleştirildi! Toplam Tutar: " + toplam.Text + " TL\nStok güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

             
                SqlDataAdapter da = new SqlDataAdapter("SELECT barkod, kitapAdi, fiyat, stok FROM Kitaplar", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                baglanti.Close();

           
                cmbkitap.SelectedIndex = -1;
                cmbmus.SelectedIndex = -1;
                numsatıs.Value = 0;
                toplam.Text = "0.00";
            }
            catch (Exception hata)
            {
                MessageBox.Show("Satış yapılırken hata oluştu: " + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }
    }
}
