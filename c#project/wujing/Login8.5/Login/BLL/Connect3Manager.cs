using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Connect3Manager
    {
        public DepartmentDAO dDAO = new DepartmentDAO();
        public Connect3DAO c3DAO = new Connect3DAO();
        public ImageDAO iDAO = new ImageDAO();

        public bool AddConnect3(List<Connect3> c3List)
        {
            bool flag = false;
            for (int i = 0; i < c3List.Count; i++)
            {
                if (iDAO.SelectImage(c3List[i].ImageNumber) != null && dDAO.SelectDepartment(c3List[i].DepartmentNumber) != null)
                {
                    if (c3DAO.SelectConnect3(c3List[i]) == null)
                    {
                        c3DAO.AddConnect3(c3List[i]);
                        flag = true;
                    }
                }
                else
                {
                    flag = false;
                }


            }

            return flag;
        }

        public bool DeleteConnect3(Connect3 c3)
        {
            bool flag = false;

            if (iDAO.SelectImage(c3.ImageNumber) != null)
            {
                c3DAO.RemoveConnect3(c3);
                flag = true;
            }
            /*else if (pDAO.SelectProduct(c3.ProductType) == null)
            {
                c3DAO.RemoveConnect31(c3);
                flag = true;
            }*/
            else
            {
                flag = false;
            }

            return flag;
        }

        public List<Connect3> SearchConnect3(Connect3 c3, string judge)
        {
            List<Connect3> tempList = null;
            if (judge == "imageNumber")
            {
                tempList = c3DAO.SelectConnect311(c3.ImageNumber);
            }
            else
            {
                tempList = c3DAO.SelectConnect31(c3.DepartmentNumber);
            }
            return tempList;

        }

        public List<Connect3> SearchConnect(Connect3 c3)
        {
            List<Connect3> tempList = null;
            if (c3 != null)
            {
                tempList = c3DAO.SelectConnect3(c3);
            }
            return tempList;
        }

        public bool AlterConnect3(Connect3 c3)
        {
            bool flag = false;
            if (c3DAO.SelectConnect3(c3) != null)
            {
                c3DAO.UpdateConnect3(c3);
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
