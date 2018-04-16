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
    public partial class FrmGider : Form
    {
        public FrmGider()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();

        
            
        


        private void BtnKaydet_Click(object sender, EventArgs e)
        {

                // Gider ekleme
            try
            {
                SqlCommand komut = new SqlCommand("insert into Gİderler (Elektrik, Su, Doğalgaz, intenet, Gıda, Personel, Diğer) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtElektrik.Text);
                komut.Parameters.AddWithValue("@p2", TxtSu.Text);
                komut.Parameters.AddWithValue("@p3", TxtDogalgaz.Text);
                komut.Parameters.AddWithValue("@p4", TxtInternet.Text);
                komut.Parameters.AddWithValue("@p5", TxtGida.Text);
                komut.Parameters.AddWithValue("@p6", TxtPersonel.Text);
                komut.Parameters.AddWithValue("@p7", TxtDiger.Text);
                komut.ExecuteNonQuery();     
                bgl.baglanti().Close();
                MessageBox.Show("Kayıtar Eklendi");


               
            }

            catch (Exception)
            {

                MessageBox.Show("Hatalı Kayıt Girişi");
            }

          

        }

        private void FrmOgrGider_Load(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TxtElektrik.Clear();
            TxtSu.Clear();
            TxtDogalgaz.Clear();
            TxtInternet.Clear();
            TxtGida.Clear();
            TxtPersonel.Clear();
            TxtDiger.Clear();
            TxtElektrik.Focus();
        }
    }
}
