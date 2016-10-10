using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductManager
    {
        public ProductDAO pDAO = new ProductDAO();

        public bool AddProduct(Product product)        //增加
        {
            bool flag = false;
            if (pDAO.SelectProduct(product.ProductType) == null)
            {
                pDAO.AddProduct(product);
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        public bool DeleteProduct(Product product)      //删除
        {
            bool flag = false;
            if (pDAO.SelectProduct(product.ProductType) != null)
            {
                pDAO.RemoveProduct(product);
                flag = true;
            }
            else
            {
                flag = false;
            }

            return flag;
        }

        public ProductDAO SearchProduct(Product product)        //查找
        {
            ProductDAO temp = new ProductDAO();

            return temp;
        }

        public bool EditProduct(Product product)            //修改
        {
            bool flag = false;
            if (pDAO.SelectProduct(product.ProductType) != null)
            {
                pDAO.UpdateProduct(product);
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
