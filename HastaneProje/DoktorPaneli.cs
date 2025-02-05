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
    public partial class DoktorPaneli : Form
    {
        public DoktorPaneli()
        {
            InitializeComponent();
        }
        sqlbaglantisi sqlbaglantisi = new sqlbaglantisi();

        private void DoktorPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter dv = new SqlDataAdapter("Select * from Tbl_Doktorlar ", sqlbaglantisi.baglanti());
            dv.Fill(dt2);
            dataGridView1.DataSource = dt2;




            //Branşı combobaxa aktarma 

            SqlCommand komut3 = new SqlCommand("Select BransAd from Tbl_Branslar ", sqlbaglantisi.baglanti());
            SqlDataReader dr = komut3.ExecuteReader();
            while (dr.Read()) {

                comboBox1.Items.Add(dr[0]);
            
            
            }
            sqlbaglantisi.baglanti().Close();


        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into Tbl_Doktorlar (DoktorAd, DoktorSoyad, DoktorBrans ,DoktorTC, DoktorSifre) values (@d1,@d2,@d3,@d4,@d5)",sqlbaglantisi.baglanti());
            komut.Parameters.AddWithValue("@d1",textBox1.Text);
            komut.Parameters.AddWithValue("@d2", textBox2.Text);
            komut.Parameters.AddWithValue("@d3", comboBox1.Text);
            komut.Parameters.AddWithValue("@d4", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@d5", textBox3.Text);
            komut.ExecuteNonQuery();
            sqlbaglantisi.baglanti().Close();
            MessageBox.Show("Doktor eklendi");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Delete  from Tbl_Doktorlar  where DoktorTC =@p1", sqlbaglantisi.baglanti());
            komut1.Parameters.AddWithValue("@p1",maskedTextBox1.Text);
            komut1.ExecuteNonQuery();
            sqlbaglantisi.baglanti().Close();
            MessageBox.Show("kayıt silindi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@d1 , DoktorSoyad=@d2,DoktorBrans=@d3,DoktorSifre=@d5 where DoktorTC=@d4 ",sqlbaglantisi.baglanti());

            komut2.Parameters.AddWithValue("@d1", textBox1.Text);
            komut2.Parameters.AddWithValue("@d2", textBox2.Text);
            komut2.Parameters.AddWithValue("@d3", comboBox1.Text);
            komut2.Parameters.AddWithValue("@d4", maskedTextBox1.Text);
            komut2.Parameters.AddWithValue("@d5", textBox3.Text);
            komut2.ExecuteNonQuery();
            sqlbaglantisi.baglanti().Close();
            MessageBox.Show("Doktor güncellendi");
        }

    }
}
