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

namespace HastaneProje
{
    public partial class SekreterDetay : Form
    {
        public SekreterDetay()
        {
            InitializeComponent();
        }
        public string tc;
        sqlbaglantisi sqlbaglantisi= new sqlbaglantisi();
        private void SekreterDetay_Load(object sender, EventArgs e)
        {
            tc = label3.Text;


            SqlCommand komut = new SqlCommand("Select SekreterAdSoyad from Tbl_Sekreter where SekreterTC=@p1",sqlbaglantisi.baglanti());
            komut.Parameters.AddWithValue("@p1",label3.Text);
            SqlDataReader dr1 = komut.ExecuteReader();
            while (dr1.Read())
            {
                label4.Text = dr1[0].ToString();

            }
            sqlbaglantisi.baglanti().Close();

            //Branşları Datagride aktarma
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branslar",sqlbaglantisi.baglanti());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;

            // Doktorları Datagride çekme 

            DataTable dt2 = new DataTable();
            SqlDataAdapter dv = new SqlDataAdapter("Select (DoktorAd+ ' ' + DoktorSoyad) as 'Doktor', DoktorBrans from Tbl_Doktorlar ",sqlbaglantisi.baglanti());
            dv.Fill(dt2);
            dataGridView2.DataSource = dt2;


            //Branşları comoboxa getirme 

            SqlCommand komut3 = new SqlCommand("Select BransAd from Tbl_Branslar ",sqlbaglantisi.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                comboBox1.Items.Add(dr3[0]);
            }
            sqlbaglantisi.baglanti().Close();






        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand(" insert into Table_Randevular (RandevuTarih , RandevuSaat,RandevuBrans,RandevuDoktor) values (@r1,@r2,@r3,@r4)",sqlbaglantisi.baglanti());
            komutkaydet.Parameters.AddWithValue("@r1",maskedTextBox1.Text);
            komutkaydet.Parameters.AddWithValue("@r2",maskedTextBox2.Text);
            komutkaydet.Parameters.AddWithValue("@r3",comboBox1.Text);
            komutkaydet.Parameters.AddWithValue("@r4",comboBox2.Text);
            komutkaydet.ExecuteNonQuery();
            sqlbaglantisi.baglanti().Close();
            MessageBox.Show("Randevunuz Oluşturuldu","Bilgi",MessageBoxButtons.OK);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            SqlCommand komut = new SqlCommand("Select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1",sqlbaglantisi.baglanti());
            komut.Parameters.AddWithValue("@p1",comboBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0] + " " + dr[1]);

            }
            sqlbaglantisi.baglanti().Close();

      

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand(" Insert into Tbl_Duyurular (Duyuru) values @p1 ",sqlbaglantisi.baglanti());
            komut1.Parameters.AddWithValue("@p1",richTextBox1.Text);
            komut1.ExecuteNonQuery();
            sqlbaglantisi.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DoktorPaneli doktorPaneli = new DoktorPaneli();
            doktorPaneli.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BransPaneli bransPaneli = new BransPaneli();
            bransPaneli.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RandevuListesi randevuListesi = new RandevuListesi();
            randevuListesi.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Duyurular duyurular = new Duyurular();
            duyurular.Show();
        }
    }
}
