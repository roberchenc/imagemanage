using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ImageInformation
    {
        private string imageNumber;

        public string ImageNumber
        {
            get { return imageNumber; }
            set { imageNumber = value; }
        }
        private string partsName;

        public string PartsName
        {
            get { return partsName; }
            set { partsName = value; }
        }
        private string path;

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
        private DateTime updateTime;

        public DateTime UpdateTime
        {
            get { return updateTime; }
            set { updateTime = value; }
        }
        private byte[] image = new byte[1000];

        public byte[] ImageContent
        {
            get { return image; }
            set { image = value; }
        }

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
