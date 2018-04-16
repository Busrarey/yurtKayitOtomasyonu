using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YurtKayitSistemi
{
    public partial class FrmOdemeler : Form
    {
        public FrmOdemeler()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();

        public void OdemeGetir()
        {
           SqlDataAdapter da = new SqlDataAdapter("Select * from Borclar", bgl.baglanti());
           DataTable dt = new DataTable();
           da.Fill(dt);
           dataGridView1.DataSource = dt;
        }


        private void FrmOdemeler_Load(object sender, EventArgs e)
        {
            OdemeGetir();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // Datagrid içerisinde seçilen verilerin textboxlara yazılması

            int secilen;
            string id, ad, soyad, kalan;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            kalan = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            TxtAd.Text = ad;
            TxtSoyad.Text = soyad;
            TxtKalan.Text = kalan;
            TxtOgrenciId.Text = id;
            OdemeGetir();

        
        }

        private void BtnOdemeAl_Click(object sender, EventArgs e)
        {
            //Ödenen tutarı kalan tutardan düşme 

            int kalan, odenen, yeniborc;
            odenen = Convert.ToInt32(TxtOdenen.Text);
            kalan = Convert.ToInt32(TxtKalan.Text);
            yeniborc = kalan-odenen;
            TxtKalan.Text = yeniborc.ToString();
            

            //Yeni tutarı veritabanına kaydetme

            SqlCommand komut = new SqlCommand("Update Borclar set OgrKalanBorc=@p1 where Ogrid=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p2", TxtOgrenciId.Text);
            komut.Parameters.AddWithValue("@p1", TxtKalan.Text);
            komut.ExecuteNonQuery(); 
            bgl.baglanti().Close();
            MessageBox.Show("Ödeme Alındı");
            OdemeGetir();

            //Kasa tablosuna ekleme yapma 

            SqlCommand komut2 = new SqlCommand("insert into Kasa (OdemeAy, OdemeMiktar) values (@k1,@k2)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@k1", OdenenAy.Text);
            komut2.Parameters.AddWithValue("@k2", TxtOdenen.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            



        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtOgrenciId.Clear();
            TxtAd.Clear();
            TxtSoyad.Clear();
            TxtOdenen.Clear();
            TxtKalan.Clear();
            OdenenAy.Clear();
            TxtAd.Focus();
        }
    }
}
