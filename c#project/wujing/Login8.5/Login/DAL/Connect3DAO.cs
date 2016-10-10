using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Connect3DAO
    {
        public string exception;

        public string AddConnect3(Connect3 connect3)   //表中增加一行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect3DataBasesql1;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@departmentNumber", connect3.DepartmentNumber));
                cmd.Parameters.Add(new SqlParameter("@imageNumber", connect3.ImageNumber));



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

        public string RemoveConnect3(Connect3 connect3)   //   表中删除一行   
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect3DataBasesql2;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@imageNumber", connect3.ImageNumber));



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

        public string RemoveConnect31(Connect3 connect3)   //   表中删除一行   
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect3DataBasesql6;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@departmentNumber", connect3.DepartmentNumber));



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

        public List<Connect3> SelectConnect3(Connect3 c3)   //按要求查找表并返回结果   
        {
            Connect3 temp = null;
            List<Connect3> connect3List = null;
            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect3DataBasesql3;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@imageNumber", c3.ImageNumber));
                cmd.Parameters.Add(new SqlParameter("@departmentNumber", c3.DepartmentNumber));


                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())      //开始读取数据
                {
                    temp.ImageNumber = reader.GetString(reader.GetOrdinal("imageNumber"));
                    temp.DepartmentNumber = reader.GetString(reader.GetOrdinal("departmentNumber"));
                   
                    connect3List.Add(temp);
                }

                conn.Close();
            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

            //Console.WriteLine(image.ToString());
            return connect3List;
        }

        public List<Connect3> SelectConnect31(string departmentNumber)   //根据 ui 选择返回一个image
        {
            Connect3 temp = null;
            List<Connect3> connect3List = null;
            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect3DataBasesql4;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@departmentNumber", departmentNumber));



                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())      //开始读取数据
                {
                    temp.ImageNumber = reader.GetString(reader.GetOrdinal("imageNumber"));
                    temp.DepartmentNumber = reader.GetString(reader.GetOrdinal("departmentNumber"));
                    
                    connect3List.Add(temp);
                }

                conn.Close();
            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

            //Console.WriteLine(image.ToString());
            return connect3List;
        }

        public List<Connect3> SelectConnect311(string imageNumber)   //根据 ui 选择返回一个image
        {
            Connect3 temp = null;
            List<Connect3> connect3List = null;
            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect3DataBasesql7;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@imageNumber", imageNumber));



                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())      //开始读取数据
                {
                    temp.ImageNumber = reader.GetString(reader.GetOrdinal("imageNumber"));
                    temp.DepartmentNumber = reader.GetString(reader.GetOrdinal("departmentNumber"));

                    connect3List.Add(temp);
                }

                conn.Close();
            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

            //Console.WriteLine(image.ToString());
            return connect3List;
        }

        public string UpdateConnect3(Connect3 connect3)   //   更新表中某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect3DataBasesql5;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@departmentNumber", connect3.DepartmentNumber));
                cmd.Parameters.Add(new SqlParameter("@imageNumber", connect3.ImageNumber));



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
