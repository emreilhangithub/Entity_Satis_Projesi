﻿using System;
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
            dataGridView1.DataSource = db.TBLURUN.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {                              
            TBLURUN t = new TBLURUN();
            t.URUNAD = txtUrunAd.Text;
            t.MARKA = txtUrunMarka.Text;
            t.STOK = short.Parse(txtUrunStok.Text);
            t.KATEGORI = int.Parse(cmbKategori.Text);
            t.FIYAT = decimal.Parse(txtUrunFiyat.Text);
            t.DURUM = true;

            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün sisteme kayıt edildi");

        }
    }
}
