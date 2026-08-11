using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kitap_satış_takip_sistemi__projesi
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            Müşteri_işlemleri musteriEkrani = new Müşteri_işlemleri();
            musteriEkrani.Show();
            this.Hide();
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {

        }

        private void btnkitap_Click(object sender, EventArgs e)
        {

            kitap_işlemleri kitapEkrani = new kitap_işlemleri();
            kitapEkrani.Show();
            this.Hide();
        }

        private void btnsatıs_Click(object sender, EventArgs e)
        {
            
            Satış satisEkrani = new Satış();
            satisEkrani.Show();
            this.Hide();
        }

        private void btnkapat_Click(object sender, EventArgs e)
        {
            
            Form1 girisEkrani = new Form1();
            girisEkrani.Show();
            this.Close();
        }
    }
}
