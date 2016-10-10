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
    public class VisitLogDAO
    {
        public string exception;

        public string AddVisitLog(VisitLog visitlog)   //表中增加一行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.visitlogDataBasesql1;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@account", visitlog.Account));
                cmd.Parameters.Add(new SqlParameter("@name", visitlog.Name));
                cmd.Parameters.Add(new SqlParameter("@time", DateTime.Now.ToString()));
                cmd.Parameters.Add(new SqlParameter("@imageNumber", visitlog.ImageNumber));
                cmd.Parameters.Add(new SqlParameter("@productType", visitlog.ProductType));


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

        public string RemoveVisitLog(VisitLog visitlog)   //表中删除某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.visitlogDataBasesql2;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@account", visitlog.Account));


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

        public List<VisitLog> SelectVisitLog(string account)   //查找表 返回结果
        {

            VisitLog visitlog = new VisitLog();
            List<VisitLog> visitlogList = null;

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.visitlogDataBasesql3;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@account", account));


                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())      //开始读取数据
                {
                    visitlog.Account = reader.GetString(reader.GetOrdinal("account"));
                    visitlog.Name = reader.GetString(reader.GetOrdinal("name"));
                    visitlog.Time = reader.GetString(reader.GetOrdinal("time"));
                    visitlog.ImageNumber = reader.GetString(reader.GetOrdinal("imageNumber"));
                    visitlog.ProductType = reader.GetString(reader.GetOrdinal("productType"));
                    visitlogList.Add(visitlog);

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
            return visitlogList;
        }

        public List<VisitLog> SelectNVisitLog(int number)   //查找表 返回结果
        {
            VisitLog visitlog=new VisitLog();
            List<VisitLog> visitlogList = null;

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.visitlogDataBasesql5;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@num", number));


                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())      //开始读取数据
                {

                    visitlog.Account = reader.GetString(reader.GetOrdinal("account"));
                    visitlog.Name = reader.GetString(reader.GetOrdinal("name"));
                    visitlog.Time = reader.GetString(reader.GetOrdinal("time"));
                    visitlog.ImageNumber = reader.GetString(reader.GetOrdinal("imageNumber"));
                    visitlog.ProductType = reader.GetString(reader.GetOrdinal("productType"));
                    visitlogList.Add(visitlog);

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
            return visitlogList;
        }

        public string UpdateVisitLog(VisitLog visitlog)        //更新某条访问记录
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.visitlogDataBasesql4;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@account", visitlog.Account));
                cmd.Parameters.Add(new SqlParameter("@name", visitlog.Name));
                cmd.Parameters.Add(new SqlParameter("@time", visitlog.Time));
                cmd.Parameters.Add(new SqlParameter("@imageNumber", visitlog.ImageNumber));
                cmd.Parameters.Add(new SqlParameter("@departmentNumber", visitlog.ProductType));
               

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
