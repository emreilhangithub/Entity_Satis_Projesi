using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity_Satis_Projesi
{
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void btnListele_Click(object sender, EventArgs e)
        {
            var kategoriler = db.TBLKATEGORI.ToList();
            //kategori adında bir değişken oluşturduk ve bu değişkende kategorileri listeledik
            dataGridView1.DataSource = kategoriler;
          
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            //tablonun sütünlarına erişmek için nesne türettik
            TBLKATEGORI t = new TBLKATEGORI();
            t.AD = txtKategoriAd.Text; //aktar
            db.TBLKATEGORI.Add(t); //t den gelen değerleri ekle
            db.SaveChanges(); //değişikleri kaydet sorguyu calıstır ExecuteNonQuery(); gibi
            MessageBox.Show("Kategori Eklendi");


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtKategoriId.Text);
            var ktgr = db.TBLKATEGORI.Find(x); // x değişkenini hafızaya al
            db.TBLKATEGORI.Remove(ktgr); //ktgr den gelene değeri kaldır
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtKategoriId.Text);
            var ktgr = db.TBLKATEGORI.Find(x);
            ktgr.AD = txtKategoriAd.Text; //ktgr den bulmus oldugumuz ad değişkenine değeri ata
            db.SaveChanges();
            MessageBox.Show("Kategori Güncellendi");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
