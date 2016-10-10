using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class NoticesDAO
    {
        public string exception;

        public string AddNotices(Notices notice)   //增加表中一行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.noticesDataBasesql1;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@noticeType", notice.NoticeType));
                cmd.Parameters.Add(new SqlParameter("@noticeDepartment", notice.NoticeDepartment));
                cmd.Parameters.Add(new SqlParameter("@noticeContent", notice.NoticeContent));
                cmd.Parameters.Add(new SqlParameter("@noticeTime", DateTime.Now));
                cmd.Parameters.Add(new SqlParameter("@noticeFlag", notice.Flag));
               

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

        public string RemoveNotices()   //删除表中某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.noticesDataBasesql2;
                cmd.CommandType = CommandType.Text;
                


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

        public List<Notices> SelectNotices(string noticeType)   //查找表并返回结果
        {

            List<Notices> noticeList = new List<Notices>();

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.noticesDataBasesql3;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@noticeType", noticeType));


                conn.Open();        //打开数据链接
                SqlDataReader reader = cmd.ExecuteReader();

                Notices notice = new Notices();
                while (reader.Read())      //开始读取数据
                {
                    if (notice == null)    //如果没有，则重新生成一个
                    {
                        notice = new Notices();
                    }
                    notice.NoticeId = reader.GetInt32(reader.GetOrdinal("noticeId"));
                    notice.NoticeType = reader.GetString(reader.GetOrdinal("noticeType"));
                    notice.NoticeDepartment = reader.GetString(reader.GetOrdinal("noticeDepartment"));
                    notice.NoticeContent = reader.GetString(reader.GetOrdinal("noticeContent"));
                    notice.NoticeTime = reader.GetDateTime(reader.GetOrdinal("noticeTime")).ToString();
                    notice.Flag = reader.GetBoolean(reader.GetOrdinal("noticeFlag"));
                    noticeList.Add(notice);
                    notice = null;

                }

            }
            catch (Exception ee)
            {
                exception = ee.ToString();
                //Console.WriteLine(ee.ToString());
            }

      
            return noticeList;
        }

       



        public string UpdateNotices(int id)  //更新表中某行
        {

            try
            {
                SqlConnection conn = new SqlConnection(DbUtil.ConnString);

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = DbUtil.noticesDataBasesql4;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("@noticeFlag", 1));
               


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
