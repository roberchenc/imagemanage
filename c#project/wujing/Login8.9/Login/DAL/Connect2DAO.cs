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
    public class Connect2DAO
    {
        public string exception;

        public string AddConnect2(Connect2 connect2)   //增加表中一行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect2DataBasesql1;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@companyNumber", connect2.CompanyNumber));
                cmd.Parameters.Add(new SqlParameter("@imageNumber", connect2.ImageNumber));



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

        public string RemoveConnect2(Connect2 connect2)   //删除表中某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect2DataBasesql2;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@imageNumber", connect2.ImageNumber));



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

        public string RemoveConnect21(Connect2 connect2)   //删除表中某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect2DataBasesql6;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@companyNumber", connect2.CompanyNumber));



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

        public List<Connect2> SelectConnect2(Connect2 c2)   //查询表，并返回结果
        {
            Connect2 temp = null;
            List<Connect2> connect2List = null;
            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect2DataBasesql3;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@imageNumber", c2.ImageNumber));
                cmd.Parameters.Add(new SqlParameter("@companyNumber", c2.CompanyNumber));


                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())      //开始读取数据
                {

                    temp.ImageNumber = reader.GetString(reader.GetOrdinal("imageNumber"));
                    temp.CompanyNumber = reader.GetString(reader.GetOrdinal("companyNumber"));
                    connect2List.Add(temp);
                }

                conn.Close();
            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

            //Console.WriteLine(image.ToString());
            return connect2List;
        }

        public List<Connect2> SelectConnect21(string companyNumber)   //查
        {
            Connect2 temp = null;
            List<Connect2> connect2List = null;
            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect2DataBasesql4;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@companyNumber", companyNumber));



                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())      //开始读取数据
                {
                    temp.ImageNumber = reader.GetString(reader.GetOrdinal("imageNumber"));
                    temp.CompanyNumber = reader.GetString(reader.GetOrdinal("companyNumber"));
                    connect2List.Add(temp);
                }

                conn.Close();
            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

            //Console.WriteLine(image.ToString());
            return connect2List;
        }

        public List<Connect2> SelectConnect211(string imageNumber)   //查
        {
            Connect2 temp = null;
            List<Connect2> connect2List = null;
            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect2DataBasesql7;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@imageNumber", imageNumber));



                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())      //开始读取数据
                {
                    temp.ImageNumber = reader.GetString(reader.GetOrdinal("imageNumber"));
                    temp.CompanyNumber = reader.GetString(reader.GetOrdinal("companyNumber"));
                    connect2List.Add(temp);
                }

                conn.Close();
            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

            //Console.WriteLine(image.ToString());
            return connect2List;
        }

        public string UpdateConnect2(Connect2 connect2)   //更新表中某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.connect2DataBasesql5;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@companyNumber", connect2.CompanyNumber));
                cmd.Parameters.Add(new SqlParameter("@imageNumber", connect2.ImageNumber));



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
