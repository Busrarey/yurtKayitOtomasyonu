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
    public partial class FrmGiderGuncelle : Form
    {
        public FrmGiderGuncelle()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        public void GiderGetir()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Gİderler", bgl.baglanti());
            DataSet dt = new DataSet();
            da.Fill(dt);
           
        }

        // Gider tanımlama

        public string elektrik, su, dogalgaz, gida, diger, internet, personel, id;

        private void button1_Click(object sender, EventArgs e)
        {

            // Yönetici Silme
            try
            {
                SqlCommand komut = new SqlCommand("Delete from Giderler where (Odemeid=@p1)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtGiderId.Text);
                komut.ExecuteNonQuery();
                TxtGiderId.Clear();
                TxtElektrik.Clear();
                TxtSu.Clear();
                TxtDogalgaz.Clear();
                TxtInternet.Clear();
                TxtGida.Clear();
                TxtPersonel.Clear();
                TxtDiger.Clear();
                TxtElektrik.Focus();
                bgl.baglanti().Close();
                MessageBox.Show("Silme işlemi Gerçekleşti");
               
            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Silme İşlemi");
            }

        }

        private void FrmGiderGuncelle_Load(object sender, EventArgs e)
        {
            // Tanımlanan giderlerin hangi textboxlardan alınacağı bilgisi

            TxtGiderId.Text = id;
            TxtElektrik.Text = elektrik;
            TxtSu.Text = su;
            TxtDogalgaz.Text = dogalgaz;
            TxtInternet.Text = internet;
            TxtGida.Text = gida;
            TxtPersonel.Text = personel;
            TxtDiger.Text = diger;
        
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            // Gider Güncelleme

            try
            {
                SqlCommand komut = new SqlCommand("Update Giderler set Elektrik=@p1, Su=@p2, Doğalgaz=@p3, intenet=@p4, Gıda=@p5, Personel=@p5, Diğer=@p6 where Odemeid=1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtElektrik.Text);
                komut.Parameters.AddWithValue("@p2", TxtSu.Text);
                komut.Parameters.AddWithValue("@p3", TxtDogalgaz.Text);
                komut.Parameters.AddWithValue("@p4", TxtInternet.Text);
                komut.Parameters.AddWithValue("@p5", TxtGida.Text);
                komut.Parameters.AddWithValue("@p6", TxtPersonel.Text);
                komut.Parameters.AddWithValue("@p7", TxtDiger.Text);
                komut.Parameters.AddWithValue("@p8", TxtGiderId.Text);
                komut.ExecuteNonQuery();
                TxtGiderId.Clear();
                TxtElektrik.Clear();
                TxtSu.Clear();
                TxtDogalgaz.Clear();
                TxtInternet.Clear();
                TxtGida.Clear();
                TxtPersonel.Clear();
                TxtDiger.Clear();
                TxtElektrik.Focus();               
                bgl.baglanti().Close();
                MessageBox.Show("Gider Güncellendi");
            }
            catch (Exception)
            {

                MessageBox.Show("Hatalı Güncelleme İşlemi");
            }
           

        }

    }
}
