using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace wjjq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void login_Click(object sender, EventArgs e)
        {
            Utility u = new Utility();
            VisitLogManager vManager = new VisitLogManager();
            UserManager uManager = new UserManager();
            UserInfo temp = new UserInfo();
            temp.Account = textbox_Account.Text;
            temp.Password = textbox_Password.Text;
            u.USER=uManager.UserLogin(temp);
            if (u.USER != null)
            {
                MessageBox.Show(u.USER.Account + "登陆成功!");
                //vManager.AddVisitLog();
                //Form2 f2 = new Form2();
                //f2.Show();
                this.Hide();
            }
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

        private void notice_Click(object sender, EventArgs e)
        {

        }
        
        
    }
}
