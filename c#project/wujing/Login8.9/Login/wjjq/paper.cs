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
            string path = @"E:\Desktop\2.png";      //路径
            System.Diagnostics.Process.Start(path); //打开此文件。
        }

        private void paper_Load(object sender, EventArgs e)
        {
            /*this.IsMdiContainer=true;//设置父窗体是容器
            Form2 f2=new Form2();//实例化子窗体
            f2.MdiParent=this;//设置窗体的父子关系
            f2.Parent=panel2;//设置子窗体的容器为父窗体中的Panel
            f2.Show();*/

            
            String path = @"E:\Desktop\2.png";    //路径
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox.Image = Image.FromFile(path);
            
            Model.Images img = new Model.Images();
            outtextbox_ImageNumber.Text = img.ImageNumber;
            outtextbox_PartsName.Text = img.PartsName;
            outtextbox_UpdateTime.Text = img.UpdateTime.ToShortDateString().ToString(); ; 
            Model.Company com = new Model.Company();
            outtextbox_CompanyName.Text = com.CompanyName;
            outtextbox_CompanyNumber.Text = com.CompanyNumber;
            Model.Product pro = new Model.Product();
            outtextbox_ProductName.Text = pro.ProductName;
            outtextbox_ProductType.Text = pro.ProductType;
      
            
        }

        private void tableLayoutPanel1_Load(object sender, PaintEventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).ReadOnly = true;
                }   
            }        
        }

        private void outtextbox_PartsName_TextChanged(object sender, EventArgs e)
        {

        }

        private void outtextbox_ImageNumber_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
