using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CompanyManager
    {
        public CompanyDAO cDAO = new CompanyDAO();

        public Company AccurateSearch(string companyNumber)     //精确查找
        {
            ///throw new NotImplementedException()
            Company company = new Company();

            if (companyNumber == String.Empty)      //如果数据库中没有该公司，则查找为空
            {
                throw new Exception("不存在该图号，请重新输入查询！");

            }
            else       //通过ui中填写的内容 返回来相应的数据
            {

                company = cDAO.SelectCompany(companyNumber);
            }
            return company;
        }


        public Company InformationDisplay(string CompanyNumber)     //信息展示
        {

            Company company = cDAO.SelectCompany(CompanyNumber);
            if (company.CompanyNumber == String.Empty)      //如果数据库中没有该公司
            {
                throw new Exception("错误！本图号已不存在");

            }
            else       //通过ui中填写的内容 返回来相应的数据
            {

                return company;
            }
        }


        public bool RemoveCompany(Company company)        //删除公司
        {
            bool judge = false;

            Company temp = cDAO.SelectCompany(company.CompanyNumber);
            if (temp==null)      //如果数据库中没有该公司
            {
                judge = false;
            }
            else       //数据库内存在该公司
            {
                cDAO.RemoveCompany(company);
                judge = true;
            }
            return judge;
        }


        public bool AddCompany(Company company)       //增加公司
        {
            bool judge = false;
            
            if (cDAO.SelectCompany(company.CompanyNumber) == null)      //如果数据库中没有有该公司
            {
                cDAO.AddCompany(company);
                judge = true;
            }
            else       //数据库内存在该公司
            {
                
                judge = false;
            }
            return judge;
        }



        public bool EditCompany(Company company)      //修改公司信息
        {
            bool judge = false;
            
            if (cDAO.SelectCompany(company.CompanyNumber) == null)      //如果数据库中不存在该公司
            {

                judge = false;
            }
            else       //数据库内存在该公司
            {
                cDAO.UpdateCompany(company);
                judge = true;
            }
            return judge;
        }



    }
}
