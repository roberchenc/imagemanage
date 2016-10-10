using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepartmentManager
    {
        public DepartmentDAO dDAO = new DepartmentDAO();

        public Department AccurateSearch(string departmentNumber)     //精确查找
        {
            ///throw new NotImplementedException();


            Department department = dDAO.SelectDepartment(departmentNumber);

            if (department.DepartmentNumber == String.Empty)      //如果数据库中没有该公司，则查找为空
            {
                throw new Exception("不存在该图号，请重新输入查询！");

            }
            else       //通过ui中填写的内容 返回来相应的数据
            {

                return department;
            }
        }


        public List<Department> AllDepartments()
        {
            List<Department> Departments = new List<Department>();
            Departments = dDAO.SelectAllDepartment();
            return Departments;
        }



        public Department InformationDisplay(string DepartmentNumber)     //信息展示
        {

            Department department = dDAO.SelectDepartment(DepartmentNumber);
            if (department.DepartmentNumber == String.Empty)      //如果数据库中没有该公司
            {
                throw new Exception("错误！本部门已不存在");

            }
            else       //通过ui中填写的内容 返回来相应的数据
            {

                return department;
            }
        }


        public bool RemoveDepartment(Department department)        //删除部门
        {
            bool judge = false;

            Department temp = dDAO.SelectDepartment(department.DepartmentNumber);
            
            if (temp.DepartmentNumber == String.Empty)      //如果数据库中没有该部门
            {
                judge = false;
            }
            else       //数据库内存在该部门
            {
                dDAO.RemoveDepartment(department);
                judge = true;
            }
            return judge;
        }


        public bool AddDepartment(Department department)       //增加部门
        {
            bool judge = false;
            
            if (dDAO.SelectDepartment(department.DepartmentNumber) == null)      //如果数据库中没有有该部门
            {
                dDAO.AddDepartment(department);
                judge = true;
            }
            else       //数据库内存在该公司
            {

                judge = false;
            }
            return judge;
        }



        public bool EditDepartment(Department department)      //修改公司信息
        {
            bool judge = false;
            
            if (dDAO.SelectDepartment(department.DepartmentNumber) == null)      //如果数据库中不存在该公司
            {

                judge = false;
            }
            else       //数据库内存在该公司
            {
                dDAO.UpdateDepartment(department);
                judge = true;
            }
            return judge;
        }



    }
}
