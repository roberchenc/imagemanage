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
    public partial class User2 : Form
    {
        public User2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            User1 u1 = new User1();
            u1.Show();
            this.Hide();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
