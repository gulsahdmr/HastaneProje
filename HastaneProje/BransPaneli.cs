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
    public partial class BransPaneli : Form
    {
        public BransPaneli()
        {
            InitializeComponent();
        }
        sqlbaglantisi sqlbaglantisi = new sqlbaglantisi();  

        private void BransPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branslar",sqlbaglantisi.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into Tbl_Branslar (BransAd) values(@p1)",sqlbaglantisi.baglanti());
            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.ExecuteNonQuery();
            sqlbaglantisi.baglanti().Close();
            MessageBox.Show("Branş eklendi");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen= dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text= dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Delete from Tbl_Branslar where Bransid=@b1 ",sqlbaglantisi.baglanti());
            komut1.Parameters.AddWithValue("@b1",textBox1.Text);
            komut1.ExecuteNonQuery();
            sqlbaglantisi.baglanti().Close();
            MessageBox.Show("Branş Silindi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Update Tbl_Branslar set BransAd =@p1 where Bransid=@p2",sqlbaglantisi.baglanti());
            komut2.Parameters.AddWithValue("@p1",textBox2.Text);
            komut2.Parameters.AddWithValue("@p2",textBox1.Text);
            komut2.ExecuteNonQuery();
            sqlbaglantisi.baglanti().Close();
            MessageBox.Show("Branş güncellendi");
        
        }
    }
}
