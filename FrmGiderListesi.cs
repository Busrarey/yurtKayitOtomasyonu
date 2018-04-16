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
    public partial class FrmGiderListesi : Form
    {
        public FrmGiderListesi()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();

        public void GiderGetir()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Giderler", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void FrmGiderListesi_Load(object sender, EventArgs e)
        {
            GiderGetir();

        }

        int secilen;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Datagrid içerisinde seçilen gidere göre gidergüncelle sayfasının açılması
            secilen = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            FrmGiderGuncelle frg = new FrmGiderGuncelle();
            frg.id = secilen.ToString();
           // frg.id = dataGridView1.SelectedCells[1].Value.ToString();
            frg.elektrik = dataGridView1.SelectedCells[1].Value.ToString();
            frg.su = dataGridView1.SelectedCells[2].Value.ToString();
            frg.dogalgaz= dataGridView1.SelectedCells[3].Value.ToString();
            frg.internet = dataGridView1.SelectedCells[4].Value.ToString();
            frg.gida = dataGridView1.SelectedCells[5].Value.ToString();
            frg.personel = dataGridView1.SelectedCells[6].Value.ToString();
            frg.diger = dataGridView1.SelectedCells[7].Value.ToString();         
            frg.Show();

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

