using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//对应数据库中相应表

namespace Model
{
    public class Product
    {
        private string productType;

        public string ProductType
        {
            get { return productType; }
            set { productType = value; }
        }
        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
    }
}
