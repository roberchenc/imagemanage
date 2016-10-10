using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Company
    {
        private string companyName;

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
        private string companyNumber;

        public string CompanyNumber
        {
            get { return companyNumber; }
            set { companyNumber = value; }
        }
    }
}
