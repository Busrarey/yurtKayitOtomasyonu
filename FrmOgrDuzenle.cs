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
    public partial class FrmOgrDuzenle : Form
    {
        public FrmOgrDuzenle()
        {
            InitializeComponent();
        }

        public string id, ad, soyad, TC, telefon, dogum, bolum;

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
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

        private void BtnSil_Click(object sender, EventArgs e)
        {
                // Öğrenci Sİlme

            try
            {
                SqlCommand komut = new SqlCommand("Delete from Ogrenci where Ogrid=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Öğrenci Kaydı Silindi");
              
                ((FrmOgrliste)Application.OpenForms["FrmOgrliste"]).ogrenciGetir();
                bgl.baglanti().Close();
              

            }
            catch (Exception)
            {

                MessageBox.Show("Hata Gerçekleşti");
            }


            SqlCommand komutsil = new SqlCommand("Update Odalar set OdaAktif=OdaAktif-1 where OdaNo=@oda", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@oda", CmbOdaNo.Text);
            komutsil.ExecuteNonQuery();
           

            
        }

        public string mail, odano, veliad, velitel, adres;

         SqlBaglantim bgl = new SqlBaglantim();

        
        private void FrmOgrDuzenle_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select BolumAd from Bolumler", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                CmbBolum.Items.Add(oku[0].ToString());
            }

            SqlCommand komut2 = new SqlCommand("Select OdaNo from Odalar  where OdaKapasite != OdaAktif", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                CmbOdaNo.Items.Add(oku2[0].ToString());
            }

            bgl.baglanti().Close();
            

            // Yeni id atandıkça
            textBox1.Text = id;
            TxtOgrAd.Text = ad;
            TxtOgrSoyad.Text = soyad;
            MsdTC.Text = TC;
            MskOgrTelefon.Text = telefon;
            MskDogum.Text = dogum;
            CmbBolum.Text = bolum;
            TxtMail.Text = mail;
            CmbOdaNo.Text = odano;
            TxtVeliAdSoyad.Text = veliad;
            MskDogum.Text = dogum;
            RchAdres.Text = adres;
            
            

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

         

        }


        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

            // Seçili öğrencinin verilerini güncelleme
            try
            {

                SqlCommand komut = new SqlCommand("update Ogrenci set OgrAd=@p2, OgrSoyad=@p3, OgrTC=@p4, OgrTelefon=@p5, OgrDogum=@p6, OgrBolum=@p7, OgrMail=@p8, OgrOdaNo=@p9, OgrVeliAdSoyad=@p10, OgrVeliTelefon=@p11, OgrVeliAdres=@p12 where Ogrid=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", TxtOgrAd.Text);
                komut.Parameters.AddWithValue("@p3", TxtOgrSoyad.Text);
                komut.Parameters.AddWithValue("@p4", MsdTC.Text);
                komut.Parameters.AddWithValue("@p5", MskOgrTelefon.Text);
                komut.Parameters.AddWithValue("@p6", MskDogum.Text);
                komut.Parameters.AddWithValue("@p7", CmbBolum.Text);
                komut.Parameters.AddWithValue("@p8", TxtMail.Text);
                komut.Parameters.AddWithValue("@p9", CmbOdaNo.Text);
                komut.Parameters.AddWithValue("@p10", TxtVeliAdSoyad.Text);
                komut.Parameters.AddWithValue("@p11", MskVeliTelefon.Text);
                komut.Parameters.AddWithValue("@p12", RchAdres.Text);
               
                komut.ExecuteNonQuery();


                ((FrmOgrliste)Application.OpenForms["FrmOgrliste"]).ogrenciGetir();
                            
                



                bgl.baglanti().Close();
                MessageBox.Show("Kayıt Güncellendi");

            }

            catch (Exception ex)

            {
                MessageBox.Show("Hatalı Güncelleme Yeniden Deneyiniz");


            }

        }


        }


    }

