using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Notices
    {
        private int  noticeId;

        public int NoticeId
        {
            get { return noticeId; }
            set { noticeId = value; }
        }

        private string noticeType;

        public string NoticeType
        {
            get { return noticeType; }
            set { noticeType = value; }
        }

        private string noticeDepartment;

        public string NoticeDepartment
        {
            get { return noticeDepartment; }
            set { noticeDepartment = value; }
        }

        private string noticeContent;

        public string NoticeContent
        {
            get { return noticeContent; }
            set { noticeContent = value; }
        }

        private bool flag;

        public bool Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        private string noticeTime;

        public string NoticeTime
        {
            get { return noticeTime; }
            set { noticeTime = value; }
        }
        
    }
}
