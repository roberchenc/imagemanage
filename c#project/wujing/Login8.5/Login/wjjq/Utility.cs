using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace wjjq
{
    public class Utility
    {
        public const long MAX_TIME = 6000; 
        public TimeSet getTime = new TimeSet();
        public UserInfo USER = new UserInfo(); 
        public void AddImageInformation(Company ctemp,Product ptemp, Images itemp)
        {
            CompanyManager cManager = new CompanyManager();
            ProductManager pManager = new ProductManager();
            ImageManager iManager = new ImageManager();
            cManager.AddCompany(ctemp);
            pManager.AddProduct(ptemp);
            iManager.AddImage(itemp);
        }

        public List<Company> cutstrCompany(string str1Temp, string str2Temp)
        {
            List<Company> companyList = new List<Company>();
            Company ctemp = new Company();


            string[] arr1 = Regex.Split(str1Temp, @"\s+");
            string[]  arr2 = Regex.Split(str2Temp, @"\s+");

            for (int k = 0; k < arr1.Length; k++)
            {
                ctemp.CompanyName = arr1[k];
                ctemp.CompanyNumber = arr2[k];
                companyList.Add(ctemp);

            }
           
            //正则表达式 用空格作为字符分隔符
            return companyList;
        }

        public List<Product> cutstrProduct(string str1Temp, string str2Temp)
        {
            List<Product> productList = new List<Product>();
            Product ctemp = new Product();

            string[] arr1 = Regex.Split(str1Temp, @"\s+");
            string[] arr2 = Regex.Split(str2Temp, @"\s+");

            for (int k = 0; k < arr1.Length;k++ )
            {
                ctemp.ProductName = arr1[k];
                ctemp.ProductType = arr2[k];
                productList.Add(ctemp);
            }

            //正则表达式 用空格作为字符分隔符
            return productList;

        }

        public void AddAll(Images img, List<Product> pList, List<Company> cList, List<Connect1> c1List, List<Connect2> c2List, List<Connect3> c3List)
        {
            ImageManager iManager = new ImageManager();
            CompanyManager cManager = new CompanyManager();
            ProductManager pManager = new ProductManager();
            Connect1Manager c1Manager = new Connect1Manager();
            Connect2Manager c2Manager = new Connect2Manager();
            Connect3Manager c3Manager =new Connect3Manager();

            iManager.AddImage(img);
            for (int i = 0; i < pList.Count; i++)
            {
                pManager.AddProduct(pList[i]);

            }
            for (int i = 0; i < pList.Count; i++)
            {
                cManager.AddCompany(cList[i]);
            }
            c1Manager.AddConnect1(c1List);
            c2Manager.AddConnect2(c2List);
            c3Manager.AddConnect3(c3List);

        }

        public bool TimeFree()
        {
            long temp = getTime.GetLastInputTime();
            if (temp >= MAX_TIME)
                return true;
            else
                return false;
        }

        public bool GetDepartmentManage(Images image, string tempDepartment)
        {
            bool flag=false;
            Connect3Manager c3Manager = new Connect3Manager();
            Connect3 c3 = new Connect3();
            List<Connect3> c3List = new List<Connect3>();
            c3.DepartmentNumber = tempDepartment;
            c3.ImageNumber = image.ImageNumber;
            c3List=c3Manager.SearchConnect(c3);
            for (int i = 0; i < c3List.Count; i++)
            {
                if (tempDepartment == c3List[i].DepartmentNumber)
                {
                    flag = true;
                }
            }
            return flag;
        }

    }
}
