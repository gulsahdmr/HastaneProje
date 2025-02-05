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
    public partial class DoktorBilgiDuzenle : Form
    {
        public DoktorBilgiDuzenle()
        {
            InitializeComponent();
        }
        sqlbaglantisi sqlbaglantisi=new sqlbaglantisi();
        public string tc;
        private void DoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text= tc;

            SqlCommand komut = new SqlCommand("Select *  from Tbl_Doktorlar where DoktorTC=@p1",sqlbaglantisi.baglanti());
            komut.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                comboBox1.Text = dr[3].ToString();
                maskedTextBox3.Text= dr[5].ToString();
            }
            sqlbaglantisi.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorSifre=@p3,DoktorBrans=@p4 where DoktorTC=@p5",sqlbaglantisi.baglanti());
            komut1.Parameters.AddWithValue("@p1",textBox1.Text);
            komut1.Parameters.AddWithValue("@p2",textBox2.Text);
            komut1.Parameters.AddWithValue("@p3",maskedTextBox3.Text);
            komut1.Parameters.AddWithValue("@p4",comboBox1.Text);
            komut1.Parameters.AddWithValue("@p5",maskedTextBox1.Text);
            komut1.ExecuteNonQuery();
            sqlbaglantisi.baglanti().Close();
        }
    }
}
