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
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
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
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void öğrenciLİsteleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrliste fr = new FrmOgrliste();
            fr.Show();
        }

        private void giderİstatistikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGiderListesi fr = new FrmGiderListesi();
            fr.Show();
            
        }

        private void FrmAnaForm_Load(object sender, EventArgs e)
        {

            // Form yüklenirken zamanlayıcı çalışmaya başlıyor


            ogrenciGetir();
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Labeş 1'e gün Label 2'ye saat yazılıyor

            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void hesapMakinesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Diagnosytics= hesap makinesi tanımlıyoruz

            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void paintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Paint tanımlıyoruz

            System.Diagnostics.Process.Start("Mspaint.exe");
        }

        private void radyo1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Media playeri url kaynağıyla ekliyoruz

            axWindowsMediaPlayer1.URL = " http://cast1.taksim.fm:8000";
        }

        private void raydToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Media playeri url kaynağıyla ekliyoruz

            axWindowsMediaPlayer1.URL = "http://radyo.itu.edu.tr/ITU_Radio_Classic.asx";
        }

        private void radyo3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Media playeri url kaynağıyle ekliyoruz

            axWindowsMediaPlayer1.URL = "http://88.255.140.50:88/broadwave.m3u?src=1&rate=1 ";
        }

        private void öğrenciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // form içerisinden farklı forma geçiş

            FrmOgrKayit fr = new FrmOgrKayit();
            fr.Show();
        }

        private void öğrenciDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOgrliste fr = new FrmOgrliste();
            fr.Show();
        }

        private void bölümEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBolumler fr = new FrmBolumler();
            fr.Show();
        }

        private void ödemeAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOdemeler fr = new FrmOdemeler();
            fr.ShowDialog();
        }

        private void giderEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGider fr = new FrmGider();
            fr.Show();
        }

        private void gelirİstatistikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGelirIstatistik fr = new FrmGelirIstatistik();
            fr.Show();
        }

        private void giderİstatistikleriToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmGiderListesi fr = new FrmGiderListesi();
            fr.Show();
        }

        private void şifreDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmYoneticiDuzenle fr = new FrmYoneticiDuzenle();
            fr.Show();
        }

        private void personelDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonel fr = new FrmPersonel();
            fr.Show();
        }

        private void öğrenciToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void notEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNotEkle fr = new FrmNotEkle();
            fr.Show();
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // MessageBox'ın parametlerini kullanarak otomasyon bilgisi veriyoruz

            MessageBox.Show("Bu program 28 Şubat 2018'de Büşra ŞAHİN tarafından hazırlanmıştır.", "Yurt Otomasyon Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bölümDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
    }
}
