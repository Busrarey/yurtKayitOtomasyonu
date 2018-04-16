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


namespace YurtKayitSistemi
{
    public partial class FrmOgrliste : Form
    {
        public FrmOgrliste()
        {
            InitializeComponent();
        }


        SqlBaglantim bgl = new SqlBaglantim();

       public void ogrenciGetir()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Ogrenci", bgl.baglanti()); 
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void FrmOgrliste_Load(object sender, EventArgs e)
        {
            ogrenciGetir();          
        

        }


        int secilen;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Seçilen öğrencileri Öğrenci Düzenle formunun textlerine aktarma

            secilen = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
           
            FrmOgrDuzenle fr = new FrmOgrDuzenle();
            fr.id = secilen.ToString();
          //  fr.id = dataGridView1.SelectedCells[1].Value.ToString();
            fr.ad = dataGridView1.SelectedCells[1].Value.ToString();
            fr.soyad = dataGridView1.SelectedCells[2].Value.ToString();
            fr.TC = dataGridView1.SelectedCells[3].Value.ToString();
            fr.telefon = dataGridView1.SelectedCells[4].Value.ToString();
            fr.dogum= dataGridView1.SelectedCells[5].Value.ToString();
            fr.bolum=dataGridView1.SelectedCells[6].Value.ToString();
            fr.mail = dataGridView1.SelectedCells[7].Value.ToString();
            fr.odano = dataGridView1.SelectedCells[8].Value.ToString();
            fr.veliad = dataGridView1.SelectedCells[9].Value.ToString();
            fr.velitel = dataGridView1.SelectedCells[10].Value.ToString();
            fr.adres = dataGridView1.SelectedCells[11].Value.ToString();
            fr.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
