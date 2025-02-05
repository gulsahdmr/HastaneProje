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
    public partial class UyeOl : Form
    {
        public UyeOl()
        {
            InitializeComponent();
        }
        sqlbaglantisi sqlbaglantisi = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into Tbl_Hastalar (HastaAd,HastaSoyad,HastaTC,HastaTelefon,HastaSifre,HastaCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)",sqlbaglantisi.baglanti());
            cmd.Parameters.AddWithValue("@p1",textBox1.Text);
            cmd.Parameters.AddWithValue("@p2",textBox2.Text);
            cmd.Parameters.AddWithValue("@p3",maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("@p4",maskedTextBox2.Text);
            cmd.Parameters.AddWithValue("@p5",maskedTextBox3.Text);
            cmd.Parameters.AddWithValue("@p6",comboBox1.Text);
            cmd.ExecuteNonQuery();
            sqlbaglantisi.baglanti().Close();
            MessageBox.Show("Kaydınız tamamlandı. Şifreniz:  " +maskedTextBox3.Text);
            this.Hide();
        }
    }
}
