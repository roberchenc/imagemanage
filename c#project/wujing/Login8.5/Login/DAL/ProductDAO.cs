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
    public class ProductDAO
    {
        public string exception;

        public string AddProduct(Product product)   //增加表中一行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.productDataBasesql1;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@productType", product.ProductType));
                cmd.Parameters.Add(new SqlParameter("@productName", product.ProductName));
               


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

        public string RemoveProduct(Product product)   //删除表中某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.productDataBasesql2;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@productType", product.ProductType));


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

        public Product SelectProduct(string producttype)   //查找表并返回结果
        {

            Product product = null;

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.productDataBasesql3;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@productType", producttype));


                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())      //开始读取数据
                {
                    if (product == null)    //如果没有，则重新生成一个
                    {
                        product = new Product();
                    }
                    product.ProductType = reader.GetString(reader.GetOrdinal("productType"));
                    product.ProductName = reader.GetString(reader.GetOrdinal("productName"));
                    

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
            return product;
        }



        public string UpdateProduct(Product product)  //更新表中某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.productDataBasesql4;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@productName", product.ProductName));
                cmd.Parameters.Add(new SqlParameter("@productType", product.ProductType));
                

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
