using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class ImageManager
    {
        public ImageDAO iDAO = new ImageDAO();

        public Images AccurateSearch(string imageNumber)     //精确查找
        {
            ///throw new NotImplementedException();

            if (imageNumber == String.Empty)      //如果数据库中没有该图号，则查找为空
            {
                throw new Exception("不存在该图号，请重新输入查询！");
                
            }
            else       //通过ui中填写的内容 返回来相应的数据
            {
                Images image = iDAO.SelectImage(imageNumber);
                return image;
            }
        }

        public List<Images> InformationDisplay(string imageNumber)     //信息展示
        {
            List<Images> imageList = new List<Images>();
            Images image = new Images();
            
            if (imageNumber == String.Empty)      //如果数据库中没有该图号
            {
                throw new Exception("错误！本图号已不存在");

            }
            else       //通过ui中填写的内容 返回来相应的数据
            {
                //image = iDAO.SelectImage(imageNumber);


                imageList = iDAO.FuzzySelect(imageNumber);
            }
            return imageList;
        }

        public List<ImageInformation> SearchImageInformation(ImageInformation imageInfo)     //信息展示
        {
            List<ImageInformation> imageList = new List<ImageInformation>();
            

            if (imageInfo != null)     
            {
                imageList = iDAO.FuzzyAll(imageInfo.ImageNumber, imageInfo.ProductType, imageInfo.PartsName, imageInfo.CompanyNumber);
            }
                
            
            return imageList;
        }

        public bool DeleteImage(Images image)        //删除图纸
        {
            bool judge = false;
            
            
            if (image.ImageNumber == String.Empty)      //如果数据库中没有该图号
            {
                judge = false;
            }
            else       //数据库内存在该图号
            {
                iDAO.RemoveImage(image.ImageNumber);
                judge = true;
            }
            return judge;
        }


        public bool AddImage(Images image)       //增加图纸
        {
            bool judge = false;
            
            if (iDAO.SelectImage(image.ImageNumber) == null)      //如果数据库中没有该图号
            {
                iDAO.AddImage(image);
                judge = true;
            }
            else       //数据库内存在该图号
            {

                judge = false;
            }
            return judge;
        }

        public bool EditImage(Images image)      //修改图纸信息
        {
            bool judge = false;
            
            if (iDAO.SelectImage(image.ImageNumber) == null)      //如果数据库中不存在该图号
            {

                judge = false;
            }
            else       //数据库内存在该图号
            {
                iDAO.UpdateImage(image);
                judge = true;
            }
            return judge;
        }


    }
}
