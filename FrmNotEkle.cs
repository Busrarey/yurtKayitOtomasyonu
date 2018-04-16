using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace YurtKayitSistemi
{
    public partial class FrmNotEkle : Form
    {
        public FrmNotEkle()
        {
            InitializeComponent();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //Yazılan notun kodda belirlenen yere kaydedilmesi

            saveFileDialog1.Title = "Kayıt Yeri Seçin";
            saveFileDialog1.Filter = "Metin Dosyası | *.txt";
           // saveFileDialog1.InitialDirectory = @"‪D:\\ Notlar";
            saveFileDialog1.ShowDialog();
            
            if (saveFileDialog1.FileName != null) { 
            StreamWriter kaydet= new StreamWriter(saveFileDialog1.FileName);
            kaydet.WriteLine(richTextBox1.Text);
            MessageBox.Show("Kayıt Yapıldı");
            kaydet.Close();}
        }
    }
}
