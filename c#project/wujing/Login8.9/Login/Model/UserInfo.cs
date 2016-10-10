using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//用户账户类，分为一般管理员（可以增删查改图纸）和超级管理员（除管理员权限外，可以分配管理员和普通管理员），和普通用户（查看图纸），对应数据库中user表

namespace Model
{
    public class UserInfo
    {
        private string account;

        public string Account
        {
            get { return account; }
            set { account = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string permission;

        public string Permission
        {
            get { return permission; }
            set { permission = value; }
        }

        private string department;

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public override String ToString() 
        { 
            return  this.Account + Name + Password + Permission + Department; 
        } 
 


    }
}
