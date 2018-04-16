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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();

        public void PersonelGetir()
        {
            SqlDataAdapter dt = new SqlDataAdapter("Select * from Personel", bgl.baglanti());
            DataTable ds = new DataTable();
            dt.Fill(ds);
            dataGridView1.DataSource = ds;
        

        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            PersonelGetir();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            try
            {

                // Personel Ekleme

                SqlCommand komut = new SqlCommand("insert into Personel (PersonelAdSoyad, PersonelDepartman) values (@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtPersonelAd.Text);
                komut.Parameters.AddWithValue("@P2", TxtPersonelDepartman.Text);
                komut.ExecuteNonQuery();      
                bgl.baglanti().Close();
                PersonelGetir();
                MessageBox.Show("Personel Kaydedildi");
                
            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Ekleme İşlemi");
            }           

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                // Personel silme

                SqlCommand komut = new SqlCommand("Delete from Personel where Personelid=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtPersonelId.Text);
                komut.ExecuteNonQuery();
                TxtPersonelId.Clear();
                TxtPersonelAd.Clear();
                TxtPersonelDepartman.Clear();
                TxtPersonelAd.Focus();
                bgl.baglanti().Close();
                PersonelGetir();
                MessageBox.Show("Personel Silme İşlemi Gerçekleşti");
          
            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Silme İşlemi");
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Datagridde seçilen verileri Textboxlarda listeleme

            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string id, ad, departman;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            departman = dataGridView1.Rows[secilen].Cells[2].Value.ToString();


            TxtPersonelId.Text = id;
            TxtPersonelAd.Text = ad;
            TxtPersonelDepartman.Text = departman;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

                // Personel Güncelleme
            try
            {
                SqlCommand komut = new SqlCommand("Update Personel set PersonelAdSoyad=@p1, PersonelDepartman=@p2 where Personelid=@p3", bgl.baglanti());
                komut.Parameters.AddWithValue("@p3", TxtPersonelId.Text);
                komut.Parameters.AddWithValue("@p1", TxtPersonelAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtPersonelDepartman.Text);
                komut.ExecuteNonQuery();         
                PersonelGetir();
                bgl.baglanti().Close();
            
                MessageBox.Show("Güncelleme işlemi Gerçekleşti");
            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Güncelleme İşlemi");
            }
            



        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtPersonelId.Clear();
            TxtPersonelAd.Clear();
            TxtPersonelDepartman.Clear();
            TxtPersonelAd.Focus();
        }
    }
}
