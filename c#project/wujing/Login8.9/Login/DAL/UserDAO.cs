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
    public class UserDAO
    {
        public string exception;

        public string AddUsers(UserInfo user)   //增加表中一行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.userDataBasesql1;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@account", user.Account));
                cmd.Parameters.Add(new SqlParameter("@name", user.Name));
                cmd.Parameters.Add(new SqlParameter("@password", user.Password));
                cmd.Parameters.Add(new SqlParameter("@permission", user.Permission));
                cmd.Parameters.Add(new SqlParameter("@departmentNumber", user.Department));


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

        public string RemoveUsers(UserInfo user)   //删除表中一行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.userDataBasesql2;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@account", user.Account)); 


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

        public UserInfo SelectUser(string userName)   //查询表并返回结果
        {
            UserInfo user = null;    //用于保存读取的数据
            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);
                //创建一个命令对象，并添加命令
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.userDataBasesql3;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@account", userName));

                //cmd.Parameters.Add(new SqlParameter("@account", "%" + userName + "%"));

                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();

               

                while (reader.Read())      //开始读取数据
                {
                    if (user == null)    //如果没有，则重新生成一个
                    {
                        user = new UserInfo();
                    }
                    user.Account = reader.GetString(reader.GetOrdinal("account"));
                    user.Name = reader.GetString(reader.GetOrdinal("name"));
                    user.Password = reader.GetString(reader.GetOrdinal("password"));
                    user.Permission = reader.GetString(reader.GetOrdinal("permission"));
                    user.Department = reader.GetString(reader.GetOrdinal("department"));
                    
                }
            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

            //Console.WriteLine(image.ToString());
            return user;
        }

        public List<UserInfo> SelectAllUser()   //查询表并返回结果
        {
            List<UserInfo> userList = new List<UserInfo>();  //用于保存读取的数据
            
            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);
                //创建一个命令对象，并添加命令
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.userDataBasesql5;
                cmd.CommandType = CommandType.Text;
               

                //cmd.Parameters.Add(new SqlParameter("@account", "%" + userName + "%"));

                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())      //开始读取数据
                {
                    UserInfo user = new UserInfo();
                    user.Account = reader.GetString(reader.GetOrdinal("account"));
                    user.Name = reader.GetString(reader.GetOrdinal("name"));
                    user.Password = reader.GetString(reader.GetOrdinal("password"));
                    user.Permission = reader.GetString(reader.GetOrdinal("permission"));
                    user.Department = reader.GetString(reader.GetOrdinal("departmentNumber"));
                    userList.Add(user);
                    user = null;
                }
            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

            //Console.WriteLine(image.ToString());
            return userList;
        }

        public string UpdateUsers(UserInfo user)   //更新表中某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.userDataBasesql4;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@account", user.Account));
                cmd.Parameters.Add(new SqlParameter("@name", user.Name));
                cmd.Parameters.Add(new SqlParameter("@password", user.Password));
                cmd.Parameters.Add(new SqlParameter("@permission", user.Permission));
                cmd.Parameters.Add(new SqlParameter("@department", user.Department));


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

