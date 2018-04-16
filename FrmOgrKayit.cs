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
    public partial class FrmOgrKayit : Form
    {
        public FrmOgrKayit()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();

        private void FrmOgrKayit_Load(object sender, EventArgs e)
        {
            //Bölümleri comboboxa listeleme metodu

            
            SqlCommand komut = new SqlCommand("Select BolumAd from Bolumler", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                CmbBolum.Items.Add(oku[0].ToString());
            }

            

            //Odaları comboboxa listeleme metodu

            
            SqlCommand komut2 = new SqlCommand("Select OdaNo from Odalar  where OdaKapasite != OdaAktif", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                CmbOdaNo.Items.Add(oku2[0].ToString());
            }

            bgl.baglanti().Close();

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //Öğrenci bilgilerinin kayıt edilme komutları
            try
            {
               
                SqlCommand komutkaydet = new SqlCommand("Insert into Ogrenci (OgrAd,OgrSoyad,OgrTc,OgrTelefon,OgrDogum,OgrBolum,OgrMail,OgrOdaNo,OgrVeliAdSoyad,OgrVeliTelefon,OgrVeliAdres) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
                komutkaydet.Parameters.AddWithValue("@p1", TxtOgrAd.Text);
                komutkaydet.Parameters.AddWithValue("@p2", TxtOgrSoyad.Text);
                komutkaydet.Parameters.AddWithValue("@p3", MsdTC.Text);
                komutkaydet.Parameters.AddWithValue("@p4", MskOgrTelefon.Text);
                komutkaydet.Parameters.AddWithValue("@p5", MskDogum.Text);
                komutkaydet.Parameters.AddWithValue("@p6", CmbBolum.Text);
                komutkaydet.Parameters.AddWithValue("@p7", TxtMail.Text);
                komutkaydet.Parameters.AddWithValue("@p8", CmbOdaNo.Text);
                komutkaydet.Parameters.AddWithValue("@p9", TxtVeliAdSoyad.Text);
                komutkaydet.Parameters.AddWithValue("@p10", MskVeliTelefon.Text);
                komutkaydet.Parameters.AddWithValue("@p11", RchAdres.Text);
                komutkaydet.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kayıt İşlemi Gerçekleştirildi");
                

               
    

                //Öğrenci id labele çekme 

                SqlCommand komut = new SqlCommand("Select max(Ogrid) as Ogrid from Ogrenci", bgl.baglanti());
                object oku = komut.ExecuteScalar();//tek bir hücrelik veri geldiğinde
                label12.Text = oku.ToString();
                label12.Visible = true;




                //Öğrenci Borç Alanı Oluşturma

                SqlCommand komutkaydet2 = new SqlCommand("insert into Borclar (Ogrid, OgrAd, OgrSoyad) values (@b1,@b2,@b3)", bgl.baglanti());
                komutkaydet2.Parameters.AddWithValue("@b1", label12.Text);
                komutkaydet2.Parameters.AddWithValue("@b2", TxtOgrAd.Text);
                komutkaydet2.Parameters.AddWithValue("@b3", TxtOgrSoyad.Text);
                komutkaydet2.ExecuteNonQuery();
               

            }

            catch (Exception ex)
            {
                MessageBox.Show("HATA,lütfen yeniden deneyin!");
               
            }


            //Öğrenci oda kontenjanı arttırma

            SqlCommand komutoda = new SqlCommand("Update Odalar set OdaAktif= 1 where OdaNo=@p1", bgl.baglanti());
            komutoda.Parameters.AddWithValue("@p1", CmbOdaNo.Text);
            komutoda.ExecuteNonQuery();
            bgl.baglanti().Close();

            


        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            TxtOgrAd.Clear();
            TxtOgrAd.Clear();
            TxtOgrSoyad.Clear();
            MsdTC.Clear();
            MskOgrTelefon.Clear();
            MskDogum.Clear();
            CmbBolum.Text = "";
            TxtMail.Clear();
            CmbOdaNo.Text = "";
            TxtVeliAdSoyad.Clear();
            MskVeliTelefon.Clear();
            RchAdres.Clear();
            TxtOgrAd.Focus();
        }
    }
}

