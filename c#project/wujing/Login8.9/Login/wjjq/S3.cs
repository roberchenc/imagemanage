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
    public partial class S3 : Form
    {
        public S3()
        {
            InitializeComponent();
        }
        
        private void S3_load(object sender, EventArgs e)
        {
            tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel1, true, null);
            tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel2, true, null);
            tableLayoutPanel3.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel3, true, null);
            tableLayoutPanel4.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel4, true, null);
            tableLayoutPanel5.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel5, true, null); 
        }

        private void path_Click(object sender, EventArgs e)
        {
             if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                intextBox_path.Text = openFileDialog1.FileName;
                this.picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                picture.Image = Image.FromFile(openFileDialog1.FileName);
            }

        }
         private void ok_Click(object sender, EventArgs e)
        {
            Images img = new Images();
            img.ImageNumber = intextbox_ImageNumber.Text;
            img.PartsName = intextbox_PartsName.Text;
            img.Path = intextBox_path.Text;

            string strCompanyName = intextbox_CompanyName.Text;
            string strCompanyNumber = intextbox_CompanyNumber.Text;

            string strProductName = intextbox_ProductName.Text;
            string strProductType = intextbox_ProductType.Text;

            Utility u = new Utility();
            List<Company> companyList = u.cutstrCompany(strCompanyName, strCompanyNumber);
            List<Product> productList = u.cutstrProduct(strProductName, strProductType);

            List<Connect3> c3List = GetConnect3(img);
            List<Connect2> c2List = GetConnect2(img, companyList);
            List<Connect1> c1List = GetConnect1(img, productList);

            u.AddAll(img,productList,companyList,c1List,c2List,c3List);

        }

         private void label1_Click(object sender, EventArgs e)
         {
             S1 s1 = new S1();
             s1.Show();
             this.Hide();
         }

         private void label2_Click(object sender, EventArgs e)
         {
             S2 s2 = new S2();
             s2.Show();
             this.Hide();
         }

         private void panel1_Click(object sender, EventArgs e)
         {
             Form1 f1 = new Form1();
             f1.Show();
             this.Hide();
         }

         public List<Connect3> GetConnect3(Images img)              //部门选择判断
         {
             
             List<Connect3> c3List = new List<Connect3>();
             /*if (DepartmentName1.Checked == true)
             {
                 Connect3 c3 = new Connect3();
                 c3.DepartmentNumber = "11";
                 c3.ImageNumber = img.ImageNumber;
                 c3List.Add(c3);
             }
            
             if (DepartmentName2.Checked == true)
             {
                 Connect3 c3 = new Connect3();
                 c3.DepartmentNumber = "12";
                 c3.ImageNumber = img.ImageNumber;
                 c3List.Add(c3);
             }
            
             if (DepartmentName3.Checked == true)
             {
                 Connect3 c3 = new Connect3();
                 c3.DepartmentNumber = "13";
                 c3.ImageNumber = img.ImageNumber;
                 c3List.Add(c3);
             }
             
             if (!(DepartmentName1.Checked || DepartmentName2.Checked || DepartmentName3.Checked))
             {
                 MessageBox.Show("请至少选择一个发放部门！");
             }*/
             return c3List;
         }

         public List<Connect2> GetConnect2(Images img, List<Company> tempList)              //公司选择判断
         {
             
             List<Connect2> c2List = new List<Connect2>();

             for (int i = 0; i < tempList.Count; i++)
             {
                 Connect2 c2 = new Connect2();
                 c2.CompanyNumber = tempList[i].CompanyNumber;
                 c2.ImageNumber = img.ImageNumber;
                 c2List.Add(c2);
             }
                 return c2List;
         }

         public List<Connect1> GetConnect1(Images img, List<Product> tempList)              //部门选择判断
         {
             
             List<Connect1> c1List = new List<Connect1>();

             for (int i = 0; i < tempList.Count; i++)
             {
                 Connect1 c1 = new Connect1();
                 c1.ProductType = tempList[i].ProductType;
                 c1.ImageNumber = img.ImageNumber;
                 c1List.Add(c1);
             }
             return c1List;
         }

         private void intextbox_CompanyName_TextChanged(object sender, EventArgs e)
         {

         }


         private void LvsModifyDeportments_Load(object sender, EventArgs e)
         {
             DepartmentManager dManager = new DepartmentManager();
             List<Department> dList = new List<Department>();
             dList = dManager.AllDepartments();

             //  this.LvsDeleteUsers.Columns.Add("Account",typeof(string));
             this.LvsModifyDeportments.BeginUpdate();
             for (int i = 0; i < dList.Count; i++)
             {

                 ListViewItem[] listViewItem = new ListViewItem[100];
                 listViewItem[i] = new ListViewItem();
                 //listViewItem[i].ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标 

                 //listViewItem[i].Text = i.ToString();
                 //第2列
                 listViewItem[i].SubItems.Add(dList[i].DepartmentName);
                 //第3列 
                 listViewItem[i].SubItems.Add(dList[i].DepartmentNumber);

                 this.LvsModifyDeportments.Items.Add(listViewItem[i]);
             }
 
             this.LvsModifyDeportments.EndUpdate();
         }
         

         

    }
}
