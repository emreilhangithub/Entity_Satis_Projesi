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
        }
    }
}
