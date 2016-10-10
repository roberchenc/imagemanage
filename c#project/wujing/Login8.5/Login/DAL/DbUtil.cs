using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbUtil
    {
        //用于保存 链接服务器的sql语句
        public static string ConnString = @"Server=CCL;Database=wujing;User ID=sa; Password=ccl";
       
        //操作company表的语句
        public static string companyDataBasesql1 = @"insert into company values ( @companyName, @companyNumber)";
        public static string companyDataBasesql2 = @"delete from company where companyNumber=@companyNumber";
        public static string companyDataBasesql3 = @"select * from company where companyNumber=@companyNumber";
        public static string companyDataBasesql4 = @"update from company set companyNumber=@companyNumber, companyName=@companyName";

        //操作connect1表的语句
        public static string connect1DataBasesql1 = @"insert into connect1 values (@productType, @imageNumber)";
        public static string connect1DataBasesql2 = @"delete from connect1 where imageNumber=@imageNumber";
        public static string connect1DataBasesql3 = @"select * from connect1 where imageNumber=@imageNumber and productType=@productType";
        public static string connect1DataBasesql4 = @"select * from connect1 where productType=@productType";
        public static string connect1DataBasesql5 = @"update from connect1 set imageNumber=@imageNumber, productType=@productType";
        public static string connect1DataBasesql6 = @"delete from connect1 where productType=@productType and imageNumber=@imageNumber,";
        public static string connect1DataBasesql7 = @"select * from connect1 where imageNumber=@imageNumber";

        //操作connect2表的语句
        public static string connect2DataBasesql1 = @"insert into connect2 values (@companyNumber, @imageNumber)";
        public static string connect2DataBasesql2 = @"delete from connect2 where imageNumber=@imageNumber";
        public static string connect2DataBasesql3 = @"select * from connect2 where imageNumber=@imageNumber and companyNumber=@companyNumber";
        public static string connect2DataBasesql4 = @"select * from connect2 where companyNumber=@companyNumber";
        public static string connect2DataBasesql5 = @"update from connect2 set imageNumber=@imageNumber, companyNumber=@companyNumber";
        public static string connect2DataBasesql6 = @"delete from connect2 where companyNumber=@companyNumber and imageNumber=@imageNumber";
        public static string connect2DataBasesql7 = @"select * from connect2 where imageNumber=@imageNumber";

        //操作connect3表的语句
        public static string connect3DataBasesql1 = @"insert into connect3 values (@departmentNumber, @imageNumber)";
        public static string connect3DataBasesql2 = @"delete from connect3 where imageNumber=@imageNumber";
        public static string connect3DataBasesql3 = @"select * from connect3 where imageNumber=@imageNumber and departmentNumber=@departmentNumber";
        public static string connect3DataBasesql4 = @"select * from connect3 where departmentNumber=@departmentNumber";
        public static string connect3DataBasesql5 = @"update from connect3 set imageNumber=@imageNumber, departmentNumber=@departmentNumber";
        public static string connect3DataBasesql6 = @"delete from connect3 where departmentNumber=@departmentNumber and imageNumber=@imageNumber";
        public static string connect3DataBasesql7 = @"select * from connect3 where imageNumber=@imageNumber";

        //操作users表的语句
        public static string userDataBasesql1 = @"insert into users values (@account, @name, @password, @permission, @departmentNumber)";
        public static string userDataBasesql2 = @"delete from users where account=@account";
        public static string userDataBasesql3 = @"select * from users where account=@account";
        //public static string userDataBasesql3 = @"select * from users where account like @account ";
        public static string userDataBasesql4 = @"update from users set account=@account, name=@name, password=@password, 
                                                permission=@permission, departmentNumber=@departmentNumber   where account=@account";

        //操作image表的语句
        public static string imageDataBasesql1 = @"insert into image values (@imageNumber, @partsName, @path, @updateTime, @image)";
        public static string imageDataBasesql2 = @"delete from image where imageNumber=@imageNumber";
        public static string imageDataBasesql3 = @"select * from image where imageNumber=@imageNumber";
        public static string imageDataBasesql4 = @"update from image set imageNumber=@imageNumber, partsName=@partsName, path=@path, 
                                                 image=@image   where imageNumber=@imageNumber";
        public static string imageDataBasesql5 = @"select * from image where imageNumber like @imageNumber";
        public static string imageDataBasesql6 = @"select * from image where imageNumber like @imageNumber and partsName like @partsName ";
        public static string imageDataBasesql7 = @"select *  from (select t.*,m.companyName,m.companyNumber from
                                           (select i.*,p.* from connect1 as c1 left join product as p on c1.productType=p.productType left join image as i on i.imageNumber=c1.imageNumber) t,
                                           (select i.*,c.* from connect2 as c2 left join company as c on c2.companyNumber=c.companyNumber left join image as i on i.imageNumber=c2.imageNumber)  
                                           where t.imageNumber=m.imageNumber) z
                                     where imageNumber like @imageNumber and partsName=@partsName and productType=@productType and companyNumber=@companyNumber";

        //操作visitlog表的语句
        public static string visitlogDataBasesql1 = @"insert into visitlog values (@account, @name, @time, @productType, @imageNumber)";
        public static string visitlogDataBasesql2 = @"delete FROM visitlog where account=@account";
        public static string visitlogDataBasesql3 = @"select * FROM visitlog where account=@account";
        public static string visitlogDataBasesql4 = @"update FROM visitlog set account=@account, name=@name, time=@time, @imageNumber, 
                                                productType=@productType   where account=@account";
        public static string visitlogDataBasesql5 = @"select top @num * from visitlog order by time";

        //操作product表的语句
        public static string productDataBasesql1 = @"insert into product values (@productType, @productName)";
        public static string productDataBasesql2 = @"delete FROM product where productType=@productType";
        public static string productDataBasesql3 = @"select * FROM product where productType=@productType";
        public static string productDataBasesql4 = @"update FROM product set productType=@productType, productName=@productName 
                                                where productType=@productType";

        //操作department表的语句
        public static string departmentDataBasesql1 = @"insert into department values (@departmentName, @departmentNumber)";
        public static string departmentDataBasesql2 = @"delete FROM department where departmentNumber=@departmentNumber";
        public static string departmentDataBasesql3 = @"select * FROM department where departmentNumber=@departmentNumber";
        public static string departmentDataBasesql4 = @"update FROM department set departmentName=@departmentName, departmentNumber=@departmentNumber 
                                                where departmentNumber=@departmentNumber";


    }
}
