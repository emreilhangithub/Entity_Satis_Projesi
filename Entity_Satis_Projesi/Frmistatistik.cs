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
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            lblToplamKategoriSayisi.Text = db.TBLKATEGORI.Count().ToString();
            lblUrunSayisi.Text = db.TBLURUN.Count().ToString();
            lblAktifMusteriSayisi.Text = db.TBLMUSTERI.Count(x=>x.DURUM==true).ToString();
            lblPasifMusteriSayisi.Text = db.TBLMUSTERI.Count(x => x.DURUM == false).ToString();
            // x landa(öyleki) x soyut bir değişken burada
            lblToplamStok.Text = db.TBLURUN.Sum(x=> x.STOK).ToString();
            lblKasadakiTutar.Text = db.TBLSATIS.Sum(x => x.FIYAT).ToString()+" TL ";
            //lblEnYuksekFiyatliUrunn.Text = db.TBLURUN.Max(x=>x.FIYAT).ToString() + "TL";
            lblEnYuksekFiyatliUrunn.Text = (from x in db.TBLURUN orderby x.FIYAT descending select x.URUNAD).FirstOrDefault();   //fiyata göre sırala descending first ilk satırı al
            lblEnDusukFiyatliUrunn.Text = (from x in db.TBLURUN orderby x.FIYAT ascending select x.URUNAD).FirstOrDefault();
            lblBeyazEsyaSayisi.Text = db.TBLURUN.Count(x => x.KATEGORI == 1).ToString();
            lblToplamBuzbolabiSayisi.Text = db.TBLURUN.Count(x=> x.URUNAD=="BUZDOLABI").ToString();
            lblSehirSayisi.Text = (from x in db.TBLMUSTERI select x.SEHIR).Distinct().Count().ToString();
            lblEnFazlaUrunluMarka.Text = db.MARKAGETIR().FirstOrDefault();
        }
    }
}
