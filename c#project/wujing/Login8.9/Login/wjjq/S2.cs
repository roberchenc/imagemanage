using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace wjjq
{
    public partial class S2 : Form
    {
        public S2()
        {
            InitializeComponent();
        }
        public string richtext;
        
       

        private void label1_Click(object sender, EventArgs e)
        {
            S1 s1 = new S1();
            s1.Show();
            this.Hide();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            S3 s3 = new S3();
            s3.Show();
            this.Hide();
        }
        private void panel1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richtext = this.richTextBox1.Text;
        }
    }
}
