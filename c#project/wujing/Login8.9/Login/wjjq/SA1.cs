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
    public partial class SA1 : Form
    {
        public SA1()
        {
            InitializeComponent();
        }
        public List<ImageInformation> list = new List<ImageInformation>();
        private void label3_Click(object sender, EventArgs e)
        {
            SA3 sa3 = new SA3();
            sa3.Show();
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
        private void panel1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void search_Click(object sender, EventArgs e)
        {
            ImageManager iManager = new ImageManager();
            ImageInformation temp = new ImageInformation();

            temp.ImageNumber = textbox_ImageNumber.Text.Trim();
            temp.PartsName = textbox_PartsName.Text;
            temp.CompanyNumber = textbox_CompanyNumber.Text.Trim();
            temp.ProductType = textbox_ProductType.Text.Trim();
            list = iManager.SearchImageInformation(temp);
            //先清空列表中的项
            this.image_listView.Items.Clear();

            this.image_listView.BeginUpdate();
           
            for (int i = 0; i < list.Count; i++)
            {

                ListViewItem[] listViewItem = new ListViewItem[100];
                listViewItem[i] = new ListViewItem();
                //listViewItem[i].ImageIndex = i;      

                listViewItem[i].Text = i.ToString();
                //第2列
                listViewItem[i].SubItems.Add(list[i].ImageNumber);
                //第3列 
                listViewItem[i].SubItems.Add(list[i].PartsName);
                //第4列 
                listViewItem[i].SubItems.Add(list[i].UpdateTime.ToString());
                //第5列  
                listViewItem[i].SubItems.Add(list[i].CompanyName);
                //第6列
                listViewItem[i].SubItems.Add(list[i].CompanyNumber);
                //第7列
                listViewItem[i].SubItems.Add(list[i].ProductName);
                //第8列
                listViewItem[i].SubItems.Add(list[i].ProductType);

                listViewItem[i].SubItems.Add(list[i].Path);
                this.image_listView.Items.Add(listViewItem[i]);

            }

            this.image_listView.EndUpdate();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textbox_ImageNumber.Text = null;
            textbox_PartsName.Text = null;
            textbox_CompanyNumber.Text = null;
            textbox_ProductType.Text = null;
        }

        private void lv_Click(object sender, EventArgs e)//lv的Click事件。
        {
            ImageInformation tempInformation = new ImageInformation();
            foreach (ListViewItem lvi in image_listView.SelectedItems)  //选中项遍历 
            {
                tempInformation.ImageNumber = lvi.SubItems[1].Text;
                tempInformation.PartsName = lvi.SubItems[2].Text;
                tempInformation.UpdateTime = DateTime.Parse(lvi.SubItems[3].Text);
                tempInformation.CompanyName = lvi.SubItems[4].Text;
                tempInformation.CompanyNumber = lvi.SubItems[5].Text;
                tempInformation.ProductName = lvi.SubItems[6].Text;
                tempInformation.ProductType = lvi.SubItems[7].Text;
                tempInformation.Path = lvi.SubItems[8].Text;

            }
            Spaper spaper = new Spaper();
            spaper.GetPaper(tempInformation);
            //this.Hide();

            spaper.Show();

        }
        
    }
}
