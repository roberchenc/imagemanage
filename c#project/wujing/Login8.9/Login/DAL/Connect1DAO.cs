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
    public class Connect1DAO
    {
        public string exception;

        public string AddConnect1(Connect1 connect1)   //增加表一行
        {
            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect1DataBasesql1;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@productType", connect1.ProductType));
                cmd.Parameters.Add(new SqlParameter("@imageNumber", connect1.ImageNumber));



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

        public string RemoveConnect1(Connect1 connect1)   //删除表中某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect1DataBasesql2;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@imageNumber", connect1.ImageNumber));



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

        public string RemoveConnect11(Connect1 connect1)   //删除表中某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect1DataBasesql6;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@productType", connect1.ProductType));



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

        public List<Connect1> SelectConnect1(Connect1 c1)   //查询表并返回结果
        {
            Connect1 temp = null;
            List<Connect1> connect1List = null;
            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect1DataBasesql3;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@imageNumber", c1.ImageNumber));
                cmd.Parameters.Add(new SqlParameter("@productType", c1.ProductType));


                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())      //开始读取数据
                {

                    temp.ProductType = reader.GetString(reader.GetOrdinal("productType"));
                    temp.ImageNumber = reader.GetString(reader.GetOrdinal("imageNumber"));
                    connect1List.Add(temp);
                }

                conn.Close();
            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

            //Console.WriteLine(image.ToString());
            return connect1List;
        }

        public List<Connect1> SelectConnect11(string productType)   //查
        {
            Connect1 temp = null;
            List<Connect1> connect1List = null;
            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect1DataBasesql4;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@productType", productType));



                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())      //开始读取数据
                {

                    temp.ProductType = reader.GetString(reader.GetOrdinal("productType"));
                    temp.ImageNumber = reader.GetString(reader.GetOrdinal("imageNumber"));
                    connect1List.Add(temp);
                }

                conn.Close();
            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

            //Console.WriteLine(image.ToString());
            return connect1List;
        }

        public List<Connect1> SelectConnect111(string imageNumber)   //查
        {
            Connect1 temp = null;
            List<Connect1> connect1List = null;
            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect1DataBasesql7;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@imageNumber", imageNumber));



                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())      //开始读取数据
                {

                    temp.ProductType = reader.GetString(reader.GetOrdinal("productType"));
                    temp.ImageNumber = reader.GetString(reader.GetOrdinal("imageNumber"));
                    connect1List.Add(temp);
                }

                conn.Close();
            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

            //Console.WriteLine(image.ToString());
            return connect1List;
        }

        public string UpdateConnect1(Connect1 connect1)   //更新表中某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect1DataBasesql5;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@productType", connect1.ProductType));
                cmd.Parameters.Add(new SqlParameter("@imageNumber", connect1.ImageNumber));



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
