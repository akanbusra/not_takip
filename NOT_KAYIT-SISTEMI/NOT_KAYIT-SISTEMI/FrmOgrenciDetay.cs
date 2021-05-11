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

namespace NOT_KAYIT_SISTEMI
{
    public partial class FrmOgrenciDetay : Form
    {
        public FrmOgrenciDetay()
        {
            InitializeComponent();
        }
        public string numara;

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-6QDVVSR\SQLEXPRESS;Initial Catalog=DbNotKayıt;Integrated Security=True");

        
        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {
            LBLNUMARA.Text = numara;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBLDERS where OGRNUMARA=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LBLADSOYAD.Text = dr[2].ToString()+" " + dr[3].ToString() ;
                LBLSINAV1.Text = dr[4].ToString();
                LBLSINAV2.Text = dr[5].ToString();
                LBLSINAV3.Text = dr[6].ToString();
                LBLORTALAMA .Text = dr[7].ToString();
                LBLDURUM .Text = dr[8].ToString();

                if (LBLDURUM.Text == "True")
                {
                    LBLDURUM.Text = "GEÇTİ";
                }
                else
                {
                    LBLDURUM.Text = "KALDI";
                }
            }
            baglanti.Close();

        }
    }
}
