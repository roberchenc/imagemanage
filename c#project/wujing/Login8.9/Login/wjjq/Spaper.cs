using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;

namespace wjjq
{
    public partial class Spaper : Form
    {
        public ImageInformation imageInformation = new ImageInformation();
        public Spaper()
        {
            InitializeComponent();
        }

        public void GetPaper(ImageInformation tempInformation)
        {
            this.imageInformation = tempInformation;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\Jackson\Desktop\3.jpg";
            System.Diagnostics.Process.Start(path); //打开此文件。


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        /*private void change_Click(object sender, EventArgs e)
        {
            //Form2 f2 = new Form2();//子窗体
            //f2.MdiParent = this;
            //f2.Show();
           outtextbox_ImageNumber.ReadOnly = false;
           outtextbox_PartsName.ReadOnly = false;
           outtextbox_CompanyName.ReadOnly = false;
           outtextbox_CompanyNumber.ReadOnly = false;
           outtextbox_ProductName.ReadOnly = false;
           outtextbox_ProductType.ReadOnly = false;
        }
        private void ok_Click(object sender, EventArgs e)
        {
            Images img = new Images();
            img.ImageNumber = outtextbox_ImageNumber.Text;
            img.PartsName = outtextbox_PartsName.Text;
            string strCompanyName = outtextbox_CompanyName.Text;
            string strCompanyNumber = outtextbox_CompanyNumber.Text;
            string strProductName = outtextbox_ProductName.Text;
            string strProductType = outtextbox_ProductType.Text;

            //... ...
        }*/
        private void ok_Click(object sender, EventArgs e)
        {
            Images image = new Images();
            Connect1 c1 = new Connect1();
            Connect2 c2 = new Connect2();
            Connect3 c3 = new Connect3();
            ImageManager iManager = new ImageManager();
            Connect1Manager c1Manager = new Connect1Manager();
            Connect2Manager c2Manager = new Connect2Manager();
            Connect3Manager c3Manager = new Connect3Manager();

            image.ImageNumber = outtextbox_ImageNumber.Text.Trim();
            image.PartsName = outtextbox_PartsName.Text;

            c1.ImageNumber = image.ImageNumber;
            c1.ProductType = outtextbox_ProductType.Text;

            c2.ImageNumber = image.ImageNumber;
            c2.CompanyNumber = outtextbox_CompanyNumber.Text;

            c3.ImageNumber = image.ImageNumber;

            iManager.DeleteImage(image);
            c1Manager.DeleteConnect1(c1);
            c2Manager.DeleteConnect2(c2);
            c3Manager.DeleteConnect3(c3);
        }
        

        private void Spaper_Load(object sender, EventArgs e)
        {
            /*this.IsMdiContainer=true;//设置父窗体是容器
            Form2 f2=new Form2();//实例化子窗体
            f2.MdiParent=this;//设置窗体的父子关系
            f2.Parent=panel2;//设置子窗体的容器为父窗体中的Panel
            f2.Show();*/
            //S1 s1 = new S1();
            //ImageInformation imageInformayion = new ImageInformation();
            //imageInformayion = s1.tempInformation;
            String path = imageInformation.Path;    //路径
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox.Image = Image.FromFile(@"E:\Desktop\1112.jpg");

            //Images img = new Images();
            outtextbox_ImageNumber.Text = imageInformation.ImageNumber;
            outtextbox_PartsName.Text = imageInformation.PartsName;
            outtextbox_UpdateTime.Text = imageInformation.UpdateTime.ToString(); ;
            //Company com = new Company();
            outtextbox_CompanyName.Text = imageInformation.CompanyName;
            outtextbox_CompanyNumber.Text = imageInformation.CompanyNumber;
           //Product pro = new Product();
            outtextbox_ProductName.Text = imageInformation.ProductName;
            outtextbox_ProductType.Text = imageInformation.ProductType;




            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).ReadOnly = true;
                }  
            }
        }

        private void tableLayoutPanel1_Load(object sender, PaintEventArgs e)
        {
            /*outtextbox_ImageNumber.ReadOnly = true;
            outtextbox_PartsName.ReadOnly = true;
            outtextbox_UpdateTime.ReadOnly = true;
            outtextbox_CompanyName.ReadOnly = true;
            outtextbox_CompanyNumber.ReadOnly = true;
            outtextbox_ProductName.ReadOnly = true;
            outtextbox_ProductType.ReadOnly = true;*/
        }

       
        private void outtextbox_ImageNumber_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
