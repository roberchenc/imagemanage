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
        public const int ADMINFLAG = 1;
        public const int LOOKFLAG = 0;
        public const int SUPERADMINFLAG = -1;
 
        public UserDAO uDAO=new UserDAO();

        public UserInfo UserLogin(UserInfo pageUser)     //登录验证模块
        {
            UserDAO uDAO = new UserDAO();  
            UserInfo user = uDAO.SelectUser(pageUser.Account); 

            if (user.Password == pageUser.Password)       
            {
                return user;
            }
            else       //如果数据库中没有该用户名，则登陆失败
            {
                throw new Exception("登陆失败");
            }
            
        }

        public int User(UserInfo pageUser)            // 权限判断模块
        {
            int flag=LOOKFLAG;
            UserInfo user = null;
            user = UserLogin(pageUser);

            if (user.Permission == "look")
            {
                flag = LOOKFLAG;
            }
            else if (user.Permission == "admin")
            {
                flag = ADMINFLAG;
            }
            else
            {
                flag = SUPERADMINFLAG;
            }

            return flag;
        }

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

    }
}
