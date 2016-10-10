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
    public partial class S1 : Form
    { 
            
        public S1()
        {
            InitializeComponent();
            SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
            SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void search_Click(object sender, EventArgs e)
        {
            ImageManager iManager = new ImageManager();
            ImageInformation temp = new ImageInformation();
            List<ImageInformation> list = new List<ImageInformation>();
            temp.ImageNumber = textbox_ImageNumber.Text.Trim();
            temp.PartsName = textbox_PartsName.Text;
            temp.CompanyNumber = textbox_CompanyNumber.Text.Trim();
            temp.ProductType = textbox_ProductType.Text.Trim();
            list=iManager.SearchImageInformation(temp);

        }
        private void label2_Click(object sender, EventArgs e)
        {
            S2 s2 = new S2();
            s2.Show();
            this.Hide();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            S3 s3 = new S3();
            s3.Show();
            this.Hide();
        } 
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void S1_load(object sender, EventArgs e)
        {
            tableLayoutPanel1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel1, true, null);
            tableLayoutPanel2.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel2, true, null);
            tableLayoutPanel3.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel3, true, null);
            tableLayoutPanel4.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel4, true, null);
            tableLayoutPanel5.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(tableLayoutPanel5, true, null);
            p1.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(p1, true, null);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_UpdateTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textbox_CompanyName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
