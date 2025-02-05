using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HastaGiris hastaGiris = new HastaGiris();
            hastaGiris.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoktorGirisi doktorGirisi = new DoktorGirisi();
            doktorGirisi.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SekreterGiris sekretergiris= new SekreterGiris();
            sekretergiris.Show();
            this.Hide();
        }
    }
}
