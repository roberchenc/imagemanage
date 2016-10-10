using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserManager
    {
        
        public UserDAO uDAO=new UserDAO();



        public bool AddUser(UserInfo user)        //增加
        {
            bool flag = false;
            if (uDAO.SelectUser(user.Account) == null)
            {
                uDAO.AddUsers(user);
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        public bool DeleteUser(UserInfo user)      //删除
        {
            bool flag = false;
            if (uDAO.SelectUser(user.Account) != null)
            {
                uDAO.RemoveUsers(user);
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        public UserInfo SearchUser(UserInfo user)        //查找
        {
            UserInfo temp = new UserInfo();
            temp=uDAO.SelectUser(user.Account);
            return temp;
        }

        public bool EditUser(UserInfo user)            //修改
        {
            bool flag = false;
            if (uDAO.SelectUser(user.Account) != null)
            {
                uDAO.UpdateUsers(user);
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        public List<UserInfo> AllUsers()
        {
            List<UserInfo> Users = new List<UserInfo>();
            Users = uDAO.SelectAllUser();
            return Users;
        }

    }
}
