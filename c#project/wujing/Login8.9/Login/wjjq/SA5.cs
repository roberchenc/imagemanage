using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace wjjq
{
    public partial class SA5 : Form
    {
       
        public SA5()
        {
            InitializeComponent();
            List<Department> dList = new List<Department>();
            DepartmentManager dManager = new DepartmentManager();
            
            dList = dManager.AllDepartments();
            this.comboBox1.Items.Clear();
            this.comboBox1.DataSource = dList;
            this.comboBox1.DisplayMember = "departmentName";
            this.comboBox1.ValueMember = "departmentNumber";

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
        private void panel1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
        private void delete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in LvsDeleteUsers.SelectedItems)  //选中项遍历 
            {
                LvsDeleteUsers.Items.RemoveAt(lvi.Index); // 按索引移除 
                //listView1.Items.Remove(lvi);   //按项移除 
                MessageBox.Show(lvi.SubItems[1].Text);
                MessageBox.Show("删除之后将不能恢复，确定要删除？");
                UserManager uManager = new UserManager();
                UserInfo temp = new UserInfo();
                temp.Account = lvi.SubItems[1].Text;
                temp.Department = lvi.SubItems[2].Text;
                temp.Name = lvi.SubItems[3].Text;
                temp.Permission = lvi.SubItems[4].Text;
             
                if (uManager.DeleteUser(temp))
                    MessageBox.Show("删除成功");
                 
            }
            
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

            temp.Department = this.comboBox1.SelectedValue.ToString();
            
            if (uManager.AddUser(temp))
                MessageBox.Show("创建成功");
        }

        private void LvsDeleteUsers_Load(object sender, EventArgs e)
        {
            UserManager uManager = new UserManager();
            List<UserInfo> uList = new List<UserInfo>();
            uList = uManager.AllUsers();
            //先清空列表中的项
            this.LvsDeleteUsers.Items.Clear();
            this.LvsDeleteUsers.BeginUpdate();
            for (int i = 0; i < uList.Count; i++)
            {
                
                ListViewItem [] listViewItem = new  ListViewItem[100] ;
                listViewItem[i]=new  ListViewItem();
                //listViewItem[i].ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标 

                listViewItem[i].Text = i.ToString();
                //第2列
                listViewItem[i].SubItems.Add(uList[i].Account);
                //第3列 
                listViewItem[i].SubItems.Add(uList[i].Department);
               //第4列 
                listViewItem[i].SubItems.Add(uList[i].Name);
                //第5列  
                listViewItem[i].SubItems.Add(uList[i].Permission);

                this.LvsDeleteUsers.Items.Add(listViewItem[i]);
               
            }
            this.LvsDeleteUsers.EndUpdate();


            /*foreach (ListViewItem item in this.LvsDeleteUsers.Items)
            {
                for (int i = 0; i < uList.Count; i++)
                {
                    MessageBox.Show(item.SubItems[i].Text);
                }
            }*/

            
        }

       
    }
}
