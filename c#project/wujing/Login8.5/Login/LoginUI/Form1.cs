
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LoginUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            login.Enabled = false;
        }
        
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void login_Click(object sender, EventArgs e)
        {
            Model.UserInfo user = new Model.UserInfo();
            user.Account = textbox_Account.Text;
            user.Password = textbox_Password.Text;
            
            //Form2 f2 = new Form2();
            //f2.Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void notice_TextChanged(object sender, EventArgs e)
        {
            //S2 stwo = new S2();
            //this.notice.Text = stwo.richtext; 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        
        
    }
}
