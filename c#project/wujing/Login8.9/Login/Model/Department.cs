using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Department
    {
        private string departmentName;

        public string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }
        private string departmentNumber;

        public string DepartmentNumber
        {
            get { return departmentNumber; }
            set { departmentNumber = value; }
        }
    }
}
