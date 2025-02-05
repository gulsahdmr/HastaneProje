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
    public partial class SekreterGiris : Form
    {
        public SekreterGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi sqlbaglantisi = new sqlbaglantisi();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * from Tbl_Sekreter where SekreterTc=@p1 and SekreterSifre=@p2 ",sqlbaglantisi.baglanti());
            komut.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2",maskedTextBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                SekreterDetay sekreterDetay = new SekreterDetay();
                sekreterDetay.tc = maskedTextBox1.Text;
                sekreterDetay.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Bilgileri yanlış girdiniz");
            }
            sqlbaglantisi.baglanti().Close();

        }
    }
}
