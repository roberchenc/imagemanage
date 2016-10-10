using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class NoticesManager
    {
        public NoticesDAO nDAO = new NoticesDAO();

        public bool AddNotices(Notices notice)        //增加
        {
            bool flag = false;
            if (nDAO.AddNotices(notice) == null)
            {
                
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        public bool DeleteNotices()      //删除
        {
            bool flag = false;
            if (nDAO.RemoveNotices() == null)
            {
               
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        public List<Notices>  CheckNotices(string noticeType)        //查找
        {
            return nDAO.SelectNotices(noticeType);
        }

        public bool EditProduct(Notices notice)            //修改
        {
            bool flag = false;
            if (nDAO.UpdateNotices(notice.NoticeId) == null)
            {
               
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

    }
}
