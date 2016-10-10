using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VisitLogManager
    {
        public VisitLogDAO vDAO = new VisitLogDAO();
        public void AddVisitLog(VisitLog vLog)        //增加
        {
            vDAO.AddVisitLog(vLog);
        }

        public List<VisitLog> SearchVisitLog(int number)
        {
            List<VisitLog> visitlogList;
            visitlogList = vDAO.SelectNVisitLog(number);
            return visitlogList;
        }

        public List<VisitLog> SearchVisitLog(String account)
        {
            List<VisitLog> visitlogList;
            visitlogList = vDAO.SelectVisitLog(account);
            return visitlogList;
        }


    }
}
