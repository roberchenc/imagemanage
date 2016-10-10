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
    public class CompanyDAO
    {
        public string exception;

        public string AddCompany(Company company)   // 增加表中一行
        {
            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.companyDataBasesql1;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@companyName", company.CompanyName));
                cmd.Parameters.Add(new SqlParameter("@companyNumber", company.CompanyNumber));
                


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

        public string RemoveCompany(Company company)   //删除表中某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.companyDataBasesql2;
                cmd.CommandType = CommandType.Text;
           
                cmd.Parameters.Add(new SqlParameter("@companyNumber", company.CompanyNumber));



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

        public Company SelectCompany(string companyNumber)   //查询表，并返回结果
        {
            Company company=null;
            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.companyDataBasesql3;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@companyNumber", companyNumber));



                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())      //开始读取数据
                {
                    if (company == null)    //如果没有，则重新生成一个
                    {
                        company = new Company();
                    }

                    company.CompanyName = reader.GetString(reader.GetOrdinal("companyName"));
                    company.CompanyNumber = reader.GetString(reader.GetOrdinal("companyNumber"));
                }

                conn.Close();
            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

            //Console.WriteLine(image.ToString());
            return company;
        }

        public string UpdateCompany(Company company)   //更新表中某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.companyDataBasesql4;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@companyName", company.CompanyName));
                cmd.Parameters.Add(new SqlParameter("@companyNumber", company.CompanyNumber));



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
