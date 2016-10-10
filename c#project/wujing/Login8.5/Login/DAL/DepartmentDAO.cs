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

            //Console.WriteLine(image.ToString());
            //return exception;

            //Console.WriteLine(image.ToString());
            return department;
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
