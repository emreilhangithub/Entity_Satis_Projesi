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
    public partial class Form1 : Form
    {
        public Form1()
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
    }
}
