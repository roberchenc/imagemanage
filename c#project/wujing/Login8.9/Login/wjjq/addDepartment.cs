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
    public partial class addDepartment : Form
    {
        public addDepartment()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            Department department=new Department();
            DepartmentManager dManager=new DepartmentManager();
            department.DepartmentName= textBox1_DepartmentName.Text;
            department .DepartmentNumber= textBox2_DepartmentID.Text.Trim();
            if (dManager.AddDepartment(department))
                MessageBox.Show("添加成功！");

                this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

       
    }
}
