using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Connect2Manager
    {
        public CompanyDAO cDAO = new CompanyDAO();
        public Connect2DAO c2DAO = new Connect2DAO();
        public ImageDAO iDAO = new ImageDAO();

        public bool AddConnect2(List<Connect2> c2List)
        {
            bool flag = false;
            for (int i = 0; i < c2List.Count; i++)
            {
                if (iDAO.SelectImage(c2List[i].ImageNumber) != null && cDAO.SelectCompany(c2List[i].CompanyNumber) != null)
                {
                    if (c2DAO.SelectConnect2(c2List[i]) == null)
                    {
                        c2DAO.AddConnect2(c2List[i]);
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

        public bool DeleteConnect2(Connect2 c2)
        {
            bool flag = false;

            if (iDAO.SelectImage(c2.ImageNumber) != null)
            {
                c2DAO.RemoveConnect2(c2);
                flag = true;
            }
            /*else if (pDAO.SelectProduct(c2.CompanyNumber) == null)
            {
                c2DAO.RemoveConnect21(c2);
                flag = true;
            }*/
            else
            {
                flag = false;
            }

            return flag;
        }

        public List<Connect2> SearchConnect2(Connect2 c2, string judge)
        {
            List<Connect2> tempList = null;
            if (judge == "imageNumber")
            {
                tempList = c2DAO.SelectConnect211(c2.ImageNumber);
            }
            else
            {
                tempList = c2DAO.SelectConnect21(c2.CompanyNumber);
            }
            return tempList;

        }

        public List<Connect2> SearchConnect(Connect2 c2)
        {
            List<Connect2> tempList = null;
            if (c2 != null)
            {
                tempList = c2DAO.SelectConnect2(c2);
            }
            return tempList;
        }

        public bool AlterConnect2(Connect2 c2)
        {
            bool flag = false;
            if (c2DAO.SelectConnect2(c2) != null)
            {
                c2DAO.UpdateConnect2(c2);
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
