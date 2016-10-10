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
    public partial class paper : Form
    {
        public paper()
        {
            InitializeComponent();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            String path = @"E:\Desktop\2.png";
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox.Image = Image.FromFile(path);

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
