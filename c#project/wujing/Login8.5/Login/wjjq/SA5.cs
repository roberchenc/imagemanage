using BLL;
using Model;
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
    public partial class SA5 : Form
    {
        public SA5()
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

        private void label3_Click(object sender, EventArgs e)
        {
            SA3 sa3 = new SA3();
            sa3.Show();
            this.Hide();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            SA4 sa4 = new SA4();
            sa4.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("删除之后将不能恢复，确定要删除？");
            UserManager uManager = new UserManager();
            UserInfo temp = new UserInfo();
            int rows = dataGridView1.CurrentCell.RowIndex;//获得选种行的索引 
            string str = this.dataGridView1.Rows[rows].Cells[1].Value.ToString();
            temp.Account = str;
            if (uManager.DeleteUser(temp))
                MessageBox.Show("删除成功");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserManager uManager = new UserManager();
            UserInfo temp = new UserInfo();
            temp.Account = account.Text.Trim();
            temp.Password = password.Text.Trim();
            temp.Name = name.Text;
            if (radioButton1.Checked == true)
            {
                temp.Permission = "look";
            }
            else
            {
                temp.Permission = "admin";
            }
            if (radioButton5.Checked == true)
            {
                temp.Department = "11";
            }
            else
            {
                temp.Department = "12";
            }
            if (uManager.AddUser(temp))
                MessageBox.Show("创建成功");
        }

       
    }
}
