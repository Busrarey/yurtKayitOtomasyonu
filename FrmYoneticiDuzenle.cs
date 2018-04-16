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
    public partial class FrmYoneticiDuzenle : Form
    {
        public FrmYoneticiDuzenle()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();

       public void YoneticiGetir ()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select Yöneticiid, YöneticiAd, YöneticiŞifre from Admin", bgl.baglanti());
            DataTable ds = new DataTable();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            YoneticiGetir();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

             // Yönetici Ekleme
            try
            {
                SqlCommand komut = new SqlCommand("insert into Admin (YöneticiAd,YöneticiŞifre) values (@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@P2", TxtKulaniciSifre.Text);
                komut.ExecuteNonQuery();
                TxtYoneticiId.Clear();
                TxtKullaniciAdi.Clear();
                TxtKulaniciSifre.Clear();
                TxtKullaniciAdi.Focus();
                bgl.baglanti().Close();
                YoneticiGetir();
                MessageBox.Show("Yönetici Kaydedildi");
                
            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Kaydetme İşlemi");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

                // Datagridte olan verileri textboxa listeleme
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string id, ad, sifre;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            sifre = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            TxtYoneticiId.Text = id;
            TxtKullaniciAdi.Text = ad;
            TxtKulaniciSifre.Text = sifre;

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {

                // Yönetici Silme
            try
            {
                SqlCommand komut = new SqlCommand("Delete from Admin where (Yöneticiid=@p1)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtYoneticiId.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Silme işlemi Gerçekleşti");
                YoneticiGetir();
            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Silme İşlemi");
            }
            


        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update Admin set YöneticiAd=@p1, YöneticiŞifre=@p2 where Yöneticiid=@p3", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@p2", TxtKulaniciSifre.Text);
                komut.Parameters.AddWithValue("@p3", TxtYoneticiId.Text);
                komut.ExecuteNonQuery();           
                bgl.baglanti().Close();
                MessageBox.Show("Yönetici Güncellendi");
                YoneticiGetir();
            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Güncelleme işlemi");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtYoneticiId.Clear();
            TxtKullaniciAdi.Clear();
            TxtKulaniciSifre.Clear();
            TxtKullaniciAdi.Focus();
        }
    }
}
