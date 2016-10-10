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
    public class ImageDAO
    {
        public string exception;

        public string AddImage(Images image)   //增加表中一行
        {
            
            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.imageDataBasesql1;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@imageNumber", image.ImageNumber));
                cmd.Parameters.Add(new SqlParameter("@partsName", image.PartsName));
                cmd.Parameters.Add(new SqlParameter("@path", image.Path));
                cmd.Parameters.Add(new SqlParameter("@updateTime", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@image", image.ImageContent));


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

        public string RemoveImage(string imageNumber)   //删除表中某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.imageDataBasesql2;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@imageNumber", imageNumber));


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

        public Images  SelectImage(string imageNumber)   //查询表并返回结果
        {
           
            Images image = null;
            
            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.imageDataBasesql3;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@imageNumber", imageNumber));
                

                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();

              
                while (reader.Read())      //开始读取数据
                {
                    if (image == null)    //如果没有，则重新生成一个
                    {
                        image = new Images();
                    }
                    image.ImageNumber = reader.GetString(reader.GetOrdinal("imageNumber"));
                    image.PartsName = reader.GetString(reader.GetOrdinal("partsName"));
                    image.Path = reader.GetString(reader.GetOrdinal("path"));
                    image.UpdateTime = reader.GetDateTime(reader.GetOrdinal("updateTime"));
                    image.ImageContent = new Byte[8];
                    
                   
                }

             }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

            
            return image;
        }

        

        public string UpdateImage(Images image)   //更新表中某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.imageDataBasesql4;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@imageNumber", image.ImageNumber));
                cmd.Parameters.Add(new SqlParameter("@partsName", image.PartsName));
                cmd.Parameters.Add(new SqlParameter("@path", image.Path));
                cmd.Parameters.Add(new SqlParameter("@updateTime", image.UpdateTime));
                cmd.Parameters.Add(new SqlParameter("@image", image.ImageContent));

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


        public List<Images> FuzzySelect(string imageNumber)      //模糊查找
        {
            List<Images> imageList = new List<Images>();
            

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.imageDataBasesql5;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@imageNumber", "%" + imageNumber + "%"));


                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())      //开始读取数据
                {
                    /*if (image == null)    //如果没有，则重新生成一个
                    {
                        image = new Images();
                    }*/
                    Images image = new Images();
                    image.ImageNumber = reader.GetString((reader.GetOrdinal("imageNumber")));
                    image.PartsName = reader.GetString((reader.GetOrdinal("partsName")));
                    image.Path = reader.GetString((reader.GetOrdinal("path")));
                    image.UpdateTime = reader.GetDateTime((reader.GetOrdinal("updateTime")));
                    image.ImageContent = new Byte [8];
                    imageList.Add(image);
                    image = null;

                }

            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }


            return imageList;
        }


        public List<ImageInformation> FuzzyAll(string imageNumber,string productType,string partsName,string companyNumber)      //模糊查找
        {

            List<ImageInformation> tempList = new List<ImageInformation>();
            
            
            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.imageDataBasesql7;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@imageNumber", "%" + imageNumber + "%"));
                cmd.Parameters.Add(new SqlParameter("@productNumber", "%" + productType + "%"));
                cmd.Parameters.Add(new SqlParameter("@partsName", "%" + partsName + "%"));
                cmd.Parameters.Add(new SqlParameter("@companyNumber", "%" + companyNumber + "%"));


                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())      //开始读取数据
                {
                    /*if (image == null)    //如果没有，则重新生成一个
                    {
                        image = new Images();
                    }*/
                    ImageInformation image = new ImageInformation();
                    image.ImageNumber = reader.GetString((reader.GetOrdinal("imageNumber")));
                    image.PartsName = reader.GetString((reader.GetOrdinal("partsName")));
                    image.Path = reader.GetString((reader.GetOrdinal("path")));
                    image.UpdateTime = reader.GetDateTime((reader.GetOrdinal("updateTime")));
                    image.CompanyName = reader.GetString((reader.GetOrdinal("companyName")));
                    image.CompanyNumber = reader.GetString((reader.GetOrdinal("companyNumber")));
                    image.ProductName = reader.GetString((reader.GetOrdinal("productName")));
                    image.ProductType = reader.GetString((reader.GetOrdinal("productType")));

                    image.ImageContent = new Byte[8];
                    tempList.Add(image);
                    image = null;

                }

            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }


            return tempList;
        }

    }
}
