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
    public partial class Müşteri_işlemleri : Form
    {
        public Müşteri_işlemleri()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void mus_tel_TextChanged(object sender, EventArgs e)
        {

        }

        private void mus_soyad_TextChanged(object sender, EventArgs e)
        {

        }
        private void Listele()
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=BERAT\SQLEXPRESS;Initial Catalog=görsel_proje;Integrated Security=True");
            try
            {
                if (baglanti.State == ConnectionState.Closed) baglanti.Open();

              
                SqlDataAdapter da = new SqlDataAdapter("SELECT musteriId, ad, soyad, tel, email FROM Musteriler", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Veriler listelenirken hata oluştu: " + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }

        private void Temizle()
        {
            id.Clear();
            mus_ad.Clear();
            mus_soyad.Clear();
            mus_tel.Clear();
            eposta.Clear();
            mus_ara.Clear();
        }
        private void btnmus_ekle_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(mus_ad.Text) || string.IsNullOrWhiteSpace(mus_soyad.Text))
            {
                MessageBox.Show("Lütfen Müşteri Adı ve Soyadı alanlarını boş bırakmayınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection baglanti = new SqlConnection(@"Data Source=BERAT\SQLEXPRESS;Initial Catalog=görsel_proje;Integrated Security=True");
            try
            {
                baglanti.Open();

                string sorgu = "INSERT INTO musteriler (ad, soyad, tel, email) VALUES (@ad, @soyad, @tel, @mail)";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@ad", mus_ad.Text.Trim());
                komut.Parameters.AddWithValue("@soyad", mus_soyad.Text.Trim());
                komut.Parameters.AddWithValue("@tel", mus_tel.Text.Trim());
                komut.Parameters.AddWithValue("@mail", eposta.Text.Trim());

                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Müşteri başarıyla sisteme eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Temizle(); 
                Listele(); 
            }
            catch (Exception hata)
            {
                MessageBox.Show("Müşteri eklenirken hata oluştu: " + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }
        

        private void btnmus_guncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(id.Text))
            {
                MessageBox.Show("Lütfen tablodan çift tıklayarak güncellenecek müşteriyi seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection baglanti = new SqlConnection(@"Data Source=BERAT\SQLEXPRESS;Initial Catalog=görsel_proje;Integrated Security=True");
            try
            {
                baglanti.Open();
              
                string sorgu = "UPDATE musteriler SET ad=@ad, soyad=@soyad, tel=@tel, email=@mail WHERE musteriId=@id";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@id", id.Text);
                komut.Parameters.AddWithValue("@ad", mus_ad.Text.Trim());
                komut.Parameters.AddWithValue("@soyad", mus_soyad.Text.Trim());
                komut.Parameters.AddWithValue("@tel", mus_tel.Text.Trim());
                komut.Parameters.AddWithValue("@mail", eposta.Text.Trim());

                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Müşteri bilgileri başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Temizle(); 
                Listele();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Güncelleme yapılırken hata oluştu: " + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }

        private void btnmus_sil_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(id.Text))
            {
                MessageBox.Show("Lütfen tablodan çift tıklayarak silinecek müşteriyi seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection baglanti = new SqlConnection(@"Data Source=BERAT\SQLEXPRESS;Initial Catalog=görsel_proje;Integrated Security=True");
            try
            {
                baglanti.Open();

              
                string sorgu = "DELETE FROM musteriler WHERE musteriId=@id";

              
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@id", id.Text);

                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Müşteri kaydı başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Temizle(); 
                Listele(); 
            }
            catch (Exception hata)
            {
                MessageBox.Show("Müşteri silinirken hata oluştu: " + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }

        private void btnanasayfa_Click(object sender, EventArgs e)
        {
            Anasayfa anaEkrani = new Anasayfa();
            anaEkrani.Show();
            this.Hide();
        }

        private void btnmus_ara_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=BERAT\SQLEXPRESS;Initial Catalog=görsel_proje;Integrated Security=True");

            try
            {
                baglanti.Open();


                string sorgu = "SELECT * FROM Musteriler WHERE ad LIKE @arama OR (ad + ' ' + soyad) LIKE @arama";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@arama", "%" + mus_ara.Text + "%");

                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
                else
                {

                    MessageBox.Show("Aranan isimde bir müşteri bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataGridView1.DataSource = null;
                }

                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Müşteri aranırken bir hata oluştu: " + hata.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (baglanti.State == ConnectionState.Open) baglanti.Close();
            }
        }
       

        private void Müşteri_işlemleri_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow satir = dataGridView1.Rows[e.RowIndex];
                id.Text = satir.Cells["musteriId"].Value.ToString();
                mus_ad.Text = satir.Cells["ad"].Value.ToString();
                mus_soyad.Text = satir.Cells["soyad"].Value.ToString();
                mus_tel.Text = satir.Cells["tel"].Value.ToString();
                eposta.Text = satir.Cells["email"].Value.ToString();
            }
        }
    }
}
