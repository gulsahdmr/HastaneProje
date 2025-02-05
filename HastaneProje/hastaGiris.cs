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
    public partial class HastaGiris : Form
    {
        public HastaGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi sqlbaglantisi = new sqlbaglantisi();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UyeOl uyeOl = new UyeOl();
            uyeOl.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("Select * From Tbl_Hastalar Where HastaTC=@p1 and HastaSifre=@p2",sqlbaglantisi.baglanti());
            sqlCommand.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            sqlCommand.Parameters.AddWithValue("@p2",maskedTextBox2.Text);
            SqlDataReader dr= sqlCommand.ExecuteReader();
            if (dr.Read())
            {
                HastaDetay hastaDetay = new HastaDetay();
                hastaDetay.tc = maskedTextBox1.Text;
                hastaDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("hasta giriş bilgileri yanlış kontrol ediniz");
            }
            sqlbaglantisi.baglanti().Close();




        }
    }
}
