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
    public partial class FrmGelirIstatistik : Form
    {
        public FrmGelirIstatistik()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();

        private void FrmGelirIstatistik_Load(object sender, EventArgs e)
        {

            //Kasada ki toplam para hesaplama

            SqlCommand komut = new SqlCommand("Select sum(OdemeMiktar) from Kasa", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read()) 
            {
                LblPara.Text = oku[0].ToString() + " TL ";

            }

            bgl.baglanti().Close();



            // Tekrarsız olarak ayları listeleme

            SqlCommand komut2 = new SqlCommand("Select distinct(OdemeAy) from Kasa", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while(oku2.Read())
            {
                CmbAy.Items.Add(oku2[0].ToString()); 
            }
            bgl.baglanti().Close();



            //Grafiklere veri tabanından veri çekme

            SqlCommand komut3 = new SqlCommand("Select OdemeAy, sum(OdemeMiktar) from kasa group by OdemeAy order by OdemeAy desc", bgl.baglanti());
            SqlDataReader oku3 = komut3.ExecuteReader();
            while(oku3.Read())
            {
                this.chart1.Series["Aylık"].Points.AddXY(oku3[0], oku3[1]);
            }
            bgl.baglanti().Close();


        }

        private void CmbAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçilen ayın gelirini hesaplama

            SqlCommand komut = new SqlCommand("Select sum(OdemeMiktar) from Kasa where OdemeAy=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbAy.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                SecilenAy.Text = oku[0].ToString()+ "TL";
            }
            bgl.baglanti().Close();

        }
    }
}
