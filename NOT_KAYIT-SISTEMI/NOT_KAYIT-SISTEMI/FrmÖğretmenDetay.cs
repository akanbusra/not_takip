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
    public partial class FrmÖğretmenDetay : Form
    {
        public FrmÖğretmenDetay()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-6QDVVSR\SQLEXPRESS;Initial Catalog=DbNotKayıt;Integrated Security=True");
        private void FrmÖğretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotKayıtDataSet.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD) values (@P1,@P2,@P3) ",baglanti);
            komut.Parameters.AddWithValue("@P1", msknumara.Text);
            komut.Parameters.AddWithValue("@P2", txtad.Text );
            komut.Parameters.AddWithValue("@P3", txtsoyad.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Öğrenci sisteme kaydedildi", "Biligilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);
            baglanti.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            msknumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtsınav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsınav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtsınav3.Text= dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double ort, s1, s2, s3;
            string durum;

            s1 = Convert.ToDouble(txtsınav1.Text);
            s2 = Convert.ToDouble(txtsınav2.Text);
            s3 = Convert.ToDouble(txtsınav3.Text);
            ort = (s1 + s2 + s3) / 3;

            lblortalama.Text = ort.ToString();

            if (ort >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }

            if (durum == "True")
            {
                lbldurum.Text = "GEÇTİ";
            }
            else
            {
                lbldurum.Text = "KALDI";
            }


            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE TBLDERS SET OGRAD=@P1,OGRSOYAD=@P2,OGRS1=@P3,OGRS2=@P4,OGRS3=@P5,ORTALAMA=@P6,DURUM=@P8 WHERE OGRNUMARA=@P7", baglanti);
            komut.Parameters.AddWithValue("@P1",txtad.Text);
            komut.Parameters.AddWithValue("@P2",txtsoyad.Text);
            komut.Parameters.AddWithValue("@P3",txtsınav1 .Text);
            komut.Parameters.AddWithValue("@P4",txtsınav2 .Text);
            komut.Parameters.AddWithValue("@P5",txtsınav3.Text);
            komut.Parameters.AddWithValue("@P6",Decimal.Parse( lblortalama.Text));
            komut.Parameters.AddWithValue("@P7",msknumara.Text);
            komut.Parameters.AddWithValue("@P8",durum);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci bilgileri güncellendi", "Biligilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.tBLDERSTableAdapter.Fill(this.dbNotKayıtDataSet.TBLDERS);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            msknumara.Text = "";
            txtad.Text = " ";
            txtsoyad.Text = " ";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtsınav1.Text = " ";
            txtsınav2.Text = " ";
            txtsınav3.Text = " ";
        }
    }
}
