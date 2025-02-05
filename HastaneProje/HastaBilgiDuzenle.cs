using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneProje
{
    public partial class HastaBilgiDuzenle : Form
    {
        public HastaBilgiDuzenle()
        {
            InitializeComponent();
        }
        public string tcno;
        sqlbaglantisi sqlbaglantisi= new sqlbaglantisi();
        private void HastaBilgiDuzenle_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = tcno;

            SqlCommand komut = new SqlCommand("Select * from Tbl_Hastalar Where HastaTC=@p1 ",sqlbaglantisi.baglanti());
            komut.Parameters.Add(new SqlParameter("@p1", maskedTextBox1.Text));
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()) {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                maskedTextBox2.Text = dr[4].ToString();
                maskedTextBox3.Text = dr[5].ToString();
                comboBox1.Text = dr[6].ToString();
            
            }
            sqlbaglantisi.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Update Tbl_Hastalar set HastaAd=@p1, HastaSoyad=@p2,HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 where HastaTC=@p6 ", sqlbaglantisi.baglanti());
            komut2.Parameters.AddWithValue("@p1", textBox1.Text);
            komut2.Parameters.AddWithValue("@p2", textBox2.Text);
            komut2.Parameters.AddWithValue("@p3", maskedTextBox2.Text);
            komut2.Parameters.AddWithValue("@p4", maskedTextBox3.Text);
            komut2.Parameters.AddWithValue("@p5", comboBox1.Text);
            komut2.Parameters.AddWithValue("@p6", maskedTextBox1.Text);

            komut2.ExecuteNonQuery();
            sqlbaglantisi.baglanti().Close();
            MessageBox.Show("Bilgileriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        
    }
}
