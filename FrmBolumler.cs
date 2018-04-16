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
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();

        public void Bolumgetir()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select BolumId, BolumAd from Bolumler order by BolumId asc", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource= dt;


        }

        private void PcBolumEkle_Click(object sender, EventArgs e)
        {

            // Bölümler tablosuna bölüm ekler
            
            try
            {
               
                SqlCommand komut = new SqlCommand("insert into Bolumler (BolumAd) values (@p1)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtBolumAd.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Bölüm Eklendi");
                TxtBolumId.Clear();
                TxtBolumAd.Clear();
                TxtBolumAd.Focus();
                Bolumgetir();
            }
            catch
            {
                MessageBox.Show("Hatalı Bölüm Girişi");

            }
            
        }
            
            

        private void FrmBolumler_Load(object sender, EventArgs e)
        {
            Bolumgetir();

        }

        private void PcbBolumSil_Click(object sender, EventArgs e)
        {
            // Bölümler tablosundan bölüm siler

            try
            {
                
                SqlCommand komut1 = new SqlCommand("Delete from Bolumler where BolumId=@p1", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", TxtBolumId.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Silme İşlemi Gerçekleşti");
                TxtBolumId.Clear();
                TxtBolumAd.Clear();
                TxtBolumAd.Focus();
                Bolumgetir();

            }
            catch (Exception)
            {
                MessageBox.Show("Hata, İşlem Gerçekleşmedi");
               
            } 
                                     
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        
        {
            // Seçilen bölümler textboxlarda listelenir

            int secilen;
            string id, bolumad;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            bolumad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

            TxtBolumId.Text = id;
            TxtBolumAd.Text = bolumad;
        }

        private void PcbBolumDüzenle_Click(object sender, EventArgs e)
        {

            // Seçilen bölüm üzerinde güncelleme yapar

            try
            {
               
                SqlCommand komut2 = new SqlCommand("update Bolumler set BolumAd=@p1 where BolumId=@p2", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p2", TxtBolumId.Text);
                komut2.Parameters.AddWithValue("@p1", TxtBolumAd.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme İşlemi Başarıyla Gerçekleşti");
                TxtBolumId.Clear();
                TxtBolumAd.Clear();
                TxtBolumAd.Focus();
                Bolumgetir();


            }
            catch (Exception)
            {
                MessageBox.Show("Hata, Güncelleme İşlemi Gerçekleşmedi");

            }
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
