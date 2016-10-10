using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Connect1Manager
    {
        public ProductDAO pDAO = new ProductDAO();
        public Connect1DAO c1DAO = new Connect1DAO();
        public ImageDAO iDAO = new ImageDAO();

        public bool AddConnect1(List<Connect1> c1List)
        {
            bool flag = false;
            for (int i = 0; i < c1List.Count; i++)
            {
                if (iDAO.SelectImage(c1List[i].ImageNumber) != null && pDAO.SelectProduct(c1List[i].ProductType) != null)
                {
                    if (c1DAO.SelectConnect1(c1List[i]) == null)
                    {
                        c1DAO.AddConnect1(c1List[i]);
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

        public bool DeleteConnect1(Connect1 c1)
        {
            bool flag = false;
            
            if (iDAO.SelectImage(c1.ImageNumber) != null )
            {
                c1DAO.RemoveConnect1(c1);
                flag = true;
            }
            /*else if (pDAO.SelectProduct(c1.ProductType) == null)
            {
                c1DAO.RemoveConnect11(c1);
                flag = true;
            }*/
            else
            {
                flag = false;
            }

            return flag;
        }

        public List<Connect1> SearchConnect1(Connect1 c1 ,string judge)
        {
            List<Connect1> tempList = null;
            if (judge == "imageNumber")
            {
                tempList = c1DAO.SelectConnect111(c1.ImageNumber);
            }
            else
            {
                tempList = c1DAO.SelectConnect11(c1.ProductType);
            }
            return tempList;
        
        }

        public List<Connect1> SearchConnect(Connect1 c1)
        {
            List<Connect1> tempList = null;
            if (c1 != null)
            {
                tempList = c1DAO.SelectConnect1(c1);
            }
            return tempList;
        }

        public bool AlterConnect1(Connect1 c1)
        {
            bool flag = false;
            if (c1DAO.SelectConnect1(c1) != null)
            {
                c1DAO.UpdateConnect1(c1);
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
