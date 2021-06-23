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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.TBLURUN.ToList();
            //TABLONUN İSTENİLEN KOLONLARINI GÖSTERME
            dataGridView1.DataSource = (from x in db.TBLURUN
                                        select new
                                        {
                                            x.URUNID,
                                            x.URUNAD,
                                            x.MARKA,
                                            x.STOK,
                                            x.FIYAT,
                                            x.TBLKATEGORI.AD,//BURADA JOİNLİ TABLODAN ADI CEKTİK
                                            x.DURUM
                                        }
                                        ).ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {                              
            TBLURUN t = new TBLURUN();
            t.URUNAD = txtUrunAd.Text;
            t.MARKA = txtUrunMarka.Text;
            t.STOK = short.Parse(txtUrunStok.Text);
            t.KATEGORI = int.Parse(cmbKategori.SelectedValue.ToString());
            t.FIYAT = decimal.Parse(txtUrunFiyat.Text);
            t.DURUM = true;

            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün sisteme kayıt edildi");

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            var urun = db.TBLURUN.Find(x);
            db.TBLURUN.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün sistemden silindi");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtId.Text);
            var urun = db.TBLURUN.Find(x);
            urun.URUNAD = txtUrunAd.Text;
            urun.STOK = short.Parse(txtUrunStok.Text);
            urun.MARKA = txtUrunMarka.Text;
            db.SaveChanges();
            MessageBox.Show("Ürün sistemden güncellendi");

        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.TBLKATEGORI
                               select new { x.ID, x.AD }).ToList();
            //x isminde bir değişken olustur bu değerleri tblkategori tablosundan al
            //select new alacagın alanlar {} içine yazılır
            //tolist bunları bana listele
            cmbKategori.ValueMember="ID";
            cmbKategori.DisplayMember = "AD";
            cmbKategori.DataSource = kategoriler;
            //datasource veri kaynağı 
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtUrunAd.Text = cmbKategori.SelectedValue.ToString();
        }
    }
}
