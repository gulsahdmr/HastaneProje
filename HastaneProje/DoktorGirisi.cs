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
    public partial class DoktorGirisi : Form
    {
        public DoktorGirisi()
        {
            InitializeComponent();
        }
        sqlbaglantisi sqlbaglantisi=new sqlbaglantisi();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Tbl_Doktorlar where DoktorTC=@p1 and DoktorSifre=@p2",sqlbaglantisi.baglanti());
            komut.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p2",maskedTextBox2.Text);
            SqlDataReader dr =komut.ExecuteReader();
            if (dr.Read())
            {
                DoktorDetayi doktorDetayi = new DoktorDetayi();
                doktorDetayi.tc = maskedTextBox1.Text;
                doktorDetayi.Show();
               
                this.Hide();
            }
            else
            {
                MessageBox.Show("hatalı tc veya şifre");
            }
            sqlbaglantisi.baglanti().Close();
        }
    }
}
