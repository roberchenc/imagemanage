using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VisitLog
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
        private string time;

        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        private string imageNumber;

        public string ImageNumber
        {
            get { return imageNumber; }
            set { imageNumber = value; }
        }
        private string productType;

        public string ProductType
        {
            get { return productType; }
            set { productType = value; }
        }
    }
}
