using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DepartmentDAO
    {
        public string exception;

        public string AddDepartment(Department department)   //增加表中一行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.departmentDataBasesql1;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@departmentName", department.DepartmentName));
                cmd.Parameters.Add(new SqlParameter("@departmentNumber", department.DepartmentNumber));



                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();

            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

            //Console.WriteLine(image.ToString());
            return exception;
        }

        public string RemoveDepartment(Department department)   //删除表中某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.departmentDataBasesql2;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@departmentNumber", department.DepartmentNumber));


                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

            //Console.WriteLine(image.ToString());
            return exception;
        }

        public Department SelectDepartment(string departmentnumber)   //查找表并返回结果
        {

            Department department = null;

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.departmentDataBasesql3;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@departmentNumber", departmentnumber));


                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())      //开始读取数据
                {
                    if (department == null)    //如果没有，则重新生成一个
                    {
                        department = new Department();
                    }
                    department.DepartmentName = reader.GetString(reader.GetOrdinal("departmentName"));
                    department.DepartmentNumber = reader.GetString(reader.GetOrdinal("departmentNumber"));
                   

                }

            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

            
            return department;
        }

        public List<Department> SelectAllDepartment()   //查询表并返回结果
        {
            List<Department> departmentList = new List<Department>();  //用于保存读取的数据

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);
                //创建一个命令对象，并添加命令
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.departmentDataBasesql5;
                cmd.CommandType = CommandType.Text;


                //cmd.Parameters.Add(new SqlParameter("@account", "%" + userName + "%"));

                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())      //开始读取数据
                {
                    Department Department = new Department();
                    Department.DepartmentName = reader.GetString(reader.GetOrdinal("departmentNumber"));
                    Department.DepartmentNumber = reader.GetString(reader.GetOrdinal("departmentName"));
                    departmentList.Add(Department);
                    Department = null;
                }
            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

            //Console.WriteLine(image.ToString());
            return departmentList;
        }


        public string UpdateDepartment(Department department)  //更新表中某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.departmentDataBasesql4;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@productName", department.DepartmentName));
                cmd.Parameters.Add(new SqlParameter("@productType", department.DepartmentNumber));


                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();
                conn.Close();
            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

            //Console.WriteLine(image.ToString());
            return exception;

        }




    }
}
