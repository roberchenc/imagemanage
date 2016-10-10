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
            tableLayoutPanel6.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel5, true, null);
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
            Model.Image img = new Model.Image();
            img.ImageNumber = intextbox_ImageNumber.Text;
            img.PartsName = intextbox_PartsName.Text;
            img.Path = intextBox_path.Text;
            Model.Company com = new Model.Company();
            com.CompanyName = intextbox_CompanyName.Text;
            com.CompanyNumber = intextbox_CompanyNumber.Text;
            Model.Product pro = new Model.Product();
            pro.ProductName = intextbox_ProductName.Text;
            pro.ProductType = intextbox_ProductType.Text;

            //DepartmentName

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

        

    }
}
