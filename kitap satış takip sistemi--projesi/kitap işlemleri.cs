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
    public partial class kitap_işlemleri : Form
    {
        public kitap_işlemleri()
        {
            InitializeComponent();
        }

        private void Listele()
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=BERAT\SQLEXPRESS;Initial Catalog=görsel_proje;Integrated Security=True");
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT barkod, kitapAdi, yazar, fiyat, stok FROM Kitaplar", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kitaplar listelenirken hata oluştu: " + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void Temizle()
        {
            barkod.Clear();
            kita_ad.Clear();
            yazar.Clear();
            fiyat.Clear();
            stok.Clear();
            kitap_ara.Clear();
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(barkod.Text) || string.IsNullOrWhiteSpace(kita_ad.Text))
            {
                MessageBox.Show("Lütfen Barkod No ve Kitap Adı alanlarını boş bırakmayınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection baglanti = new SqlConnection(@"Data Source=BERAT\SQLEXPRESS;Initial Catalog=görsel_proje;Integrated Security=True");
            try
            {
                baglanti.Open();
               
                string sorgu = "INSERT INTO Kitaplar (barkod, kitapAdi, yazar, fiyat, stok) VALUES (@barkod, @ad, @yazar, @fiyat, @stok)";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);


                komut.Parameters.AddWithValue("@barkod", barkod.Text.Trim());
                komut.Parameters.AddWithValue("@ad", kita_ad.Text.Trim());
                komut.Parameters.AddWithValue("@yazar", yazar.Text.Trim());
                komut.Parameters.AddWithValue("@fiyat", Convert.ToDecimal(fiyat.Text));
                komut.Parameters.AddWithValue("@stok", Convert.ToInt32(stok.Text));

                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Kitap başarıyla stoğa eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Temizle();
                Listele(); 
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kitap eklenirken hata oluştu: " + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(barkod.Text))
            {
                MessageBox.Show("Lütfen güncellenecek kitabın barkod numarasını girin veya tablodan seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection baglanti = new SqlConnection(@"Data Source=BERAT\SQLEXPRESS;Initial Catalog=görsel_proje;Integrated Security=True");
            try
            {
                baglanti.Open();
                string sorgu = "UPDATE Kitaplar SET kitapAdi=@ad, yazar=@yazar, fiyat=@fiyat, stok=@stok WHERE barkod=@barkod";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@barkod", barkod.Text.Trim());
                komut.Parameters.AddWithValue("@ad", kita_ad.Text.Trim());
                komut.Parameters.AddWithValue("@yazar", yazar.Text.Trim());
                komut.Parameters.AddWithValue("@fiyat", Convert.ToDecimal(fiyat.Text));
                komut.Parameters.AddWithValue("@stok", Convert.ToInt32(stok.Text));

                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Kitap bilgileri başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Temizle(); 
                Listele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Güncelleme yapılırken hata oluştu: " + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(barkod.Text))
            {
                MessageBox.Show("Lütfen silinecek kitabın barkod numarasını girin veya tablodan seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection baglanti = new SqlConnection(@"Data Source=BERAT\SQLEXPRESS;Initial Catalog=görsel_proje;Integrated Security=True");
            try
            {
                baglanti.Open();
                string sorgu = "DELETE FROM Kitaplar WHERE barkod=@barkod";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@barkod", barkod.Text.Trim());

                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Kitap başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Temizle();
                Listele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kitap silinirken hata oluştu: " + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }

        private void btnara_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=BERAT\SQLEXPRESS;Initial Catalog=görsel_proje;Integrated Security=True");
            try
            {
                baglanti.Open();
                string sorgu = "SELECT barkod, kitapAdi, yazar, fiyat, stok FROM Kitaplar WHERE kitapAdi LIKE @arama";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.Parameters.AddWithValue("@arama", "%" + kitap_ara.Text.Trim() + "%");

                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Böyle bir kitap bulunmamaktadır!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Listele();
                }

                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Arama yapılırken bir hata oluştu: " + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }

        

        private void btnAnasayfa_Click(object sender, EventArgs e)
        {
           
            Anasayfa anaEkrani = new Anasayfa();
            anaEkrani.Show();
            this.Hide();
        }

        private void kitap_işlemleri_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dataGridView1.Rows[e.RowIndex];

                barkod.Text = satir.Cells["barkod"].Value.ToString();
                kita_ad.Text = satir.Cells["kitapAdi"].Value.ToString();
                yazar.Text = satir.Cells["yazar"].Value.ToString();
                fiyat.Text = satir.Cells["fiyat"].Value.ToString();
                stok.Text = satir.Cells["stok"].Value.ToString();
            }
        }
    }
}
