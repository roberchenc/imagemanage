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
    public partial class SA3 : Form
    {
        public SA3()
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

            u.AddAll(img, productList, companyList, c1List, c2List, c3List);

        }

        public List<Connect3> GetConnect3(Images img)              //部门选择判断
        {

            List<Connect3> c3List = new List<Connect3>();
            Connect3 c3 = new Connect3();
            for (int i = 0; i < LvsModifyDeportments.CheckedItems.Count; i++)
            {
                if (LvsModifyDeportments.CheckedItems[i].Checked)
                    c3.DepartmentNumber=LvsModifyDeportments.CheckedItems[i].SubItems[2].Text;
                c3.ImageNumber = img.ImageNumber;


                c3List.Add(c3);
                c3 = null;

            }
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

        public List<Connect1> GetConnect1(Images img, List<Product> tempList)              //产品选择
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

        private void addDepartment_Click(object sender, EventArgs e)
        {
            addDepartment ad = new addDepartment();
            ad.Show();
        }

        private void LvsModifyDeportments_Load(object sender, EventArgs e)
        {
            DepartmentManager dManager = new DepartmentManager();
            List<Department> dList = new List<Department>();
            dList = dManager.AllDepartments();
            //先清空列表中的项
            this.LvsModifyDeportments.Items.Clear();
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

        private void deleteDepartment_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in LvsModifyDeportments.SelectedItems)  //选中项遍历 
            {
                LvsModifyDeportments.Items.RemoveAt(lvi.Index); // 按索引移除 
                //listView1.Items.Remove(lvi);   //按项移除 
                //MessageBox.Show(lvi.SubItems[1].Text);
                MessageBox.Show("删除之后将不能恢复，确定要删除？");
                DepartmentManager dManager = new DepartmentManager();
                Department temp = new Department();
                temp.DepartmentName = lvi.SubItems[1].Text;
                temp.DepartmentNumber= lvi.SubItems[2].Text;
                

                if (dManager.RemoveDepartment(temp))
                    MessageBox.Show("删除成功");
            }
        }


    }
}
