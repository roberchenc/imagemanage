using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//图纸信息类，对应数据库中相应表

namespace Model
{
    public class Images
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

        public override String ToString() 
        {
            return ImageNumber + PartsName + Path + UpdateTime;
        }


    }
}
