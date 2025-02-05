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
    public partial class HastaDetay : Form
    {
        public HastaDetay()
        {
            InitializeComponent();
        }
        public string tc;
        sqlbaglantisi sqlbaglantisi = new sqlbaglantisi();    

     

        private void HastaDetay_Load(object sender, EventArgs e)
        {
            label3.Text= tc;




            SqlCommand komut = new SqlCommand("Select HastaAd,HastaSoyad from Tbl_Hastalar where HastaTc=@p1",sqlbaglantisi.baglanti());
            komut.Parameters.AddWithValue("@p1",label3.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label4.Text = dr[0] + " "+  dr[1];
            }
            sqlbaglantisi.baglanti().Close();


            //Randevu geçmişi 
            DataTable dt = new DataTable();
            SqlDataAdapter da= new SqlDataAdapter("Select * from Table_Randevular where HastaTc="+ tc,sqlbaglantisi.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //Branş çekme 
            SqlCommand komut2 = new SqlCommand("Select BransAd from Tbl_Branslar",sqlbaglantisi.baglanti());
            SqlDataReader dr2= komut2.ExecuteReader();
            while (dr2.Read()) { 
            
            comboBox1.Items.Add(dr2[0]);
            }
            sqlbaglantisi.baglanti().Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            SqlCommand komut3 = new SqlCommand("Select DoktorAd, DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1",sqlbaglantisi.baglanti());
            komut3.Parameters.AddWithValue("@p1",comboBox1.Text);
            SqlDataReader  dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                comboBox2.Items.Add(dr3[0] + "  " + dr3[1]);

            }
            sqlbaglantisi.baglanti().Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Table_Randevular where RandevuBrans='"+ comboBox1.Text  + "'" + "and RandevuDoktor ='"+ comboBox2.Text +"' and RandevuDurum=0",sqlbaglantisi.baglanti());

            da.Fill(dt);
            dataGridView2.DataSource = dt;


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaBilgiDuzenle hastaBilgiDuzenle = new HastaBilgiDuzenle();
            hastaBilgiDuzenle.tcno= label3.Text;
            hastaBilgiDuzenle.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen= dataGridView2.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Table_Randevular set RandevuDurum=1,HastaTC=@p1,HastaSikayet=@p2 where Randevuid=@p3",sqlbaglantisi.baglanti());
            komut.Parameters.AddWithValue("@p1",label3.Text);
            komut.Parameters.AddWithValue("@p2",richTextBox1.Text);
            komut.Parameters.AddWithValue("@p3",textBox1.Text);
            komut.ExecuteNonQuery();
            sqlbaglantisi.baglanti().Close();
            MessageBox.Show("randevu alındı");
        }
    }
}
