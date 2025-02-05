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
    public partial class DoktorDetayi : Form
    {
        public DoktorDetayi()
        {
            InitializeComponent();
        }
        sqlbaglantisi sqlbaglantisi = new sqlbaglantisi();
        public string tc;
        private void DoktorDetayi_Load(object sender, EventArgs e)
        {
            label3.Text=tc;

            //Doktor Ad soyad çekme 
            SqlCommand komut = new SqlCommand("select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorTC=@p1",sqlbaglantisi.baglanti());
            komut.Parameters.AddWithValue("@p1",label3.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {

                label4.Text= dr[0]+ " "+ dr[1];
            }
            sqlbaglantisi.baglanti().Close();

            // Randevular
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Table_Randevular where RandevuDoktor ='"+label4.Text+"'",sqlbaglantisi.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoktorBilgiDuzenle doktorBilgiDuzenle= new DoktorBilgiDuzenle();
            doktorBilgiDuzenle.tc = label3.Text;
            doktorBilgiDuzenle.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Duyurular duyurular = new Duyurular();
            duyurular.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
