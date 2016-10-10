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
    public partial class SA3 : Form
    {
        public SA3()
        {
            InitializeComponent();
        }

       
        
        private void label1_Click(object sender, EventArgs e)
        {
            SA1 sa1 = new SA1();
            sa1.Show();
            this.Hide();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            SA2 sa2 = new SA2();
            sa2.Show();
            this.Hide();
        }
        

        private void label4_Click(object sender, EventArgs e)
        {
            SA4 sa4 = new SA4();
            sa4.Show();
            this.Hide();
        }
        private void label5_Click(object sender, EventArgs e)
        {
            SA5 sa5 = new SA5();
            sa5.Show();
            this.Hide();
        }
    }
}
