using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelling.Repository;

namespace Travelling.Service
{
    public class LineService
    {
        LineReporsitory repository = new LineReporsitory();
        public DataTable GetAllLines()
        {
            return repository.GetALlLines();
        }

        public int GetMaxDayLine()
        {
            return repository.GetMaxDayLine();
        }

        public List<string> GetStartCity()
        {
            return repository.GetStartCity();
        }

        public DataTable GetAllLineByDay(string selStartCity, string selDay)
        {
            return repository.GetAllLineByDay(selStartCity, selDay);
        }

        public DataTable GetLineByID(long lineID)
        {
            return repository.GetLineByID(lineID);
        }
        public bool CheckRecordExsitByUserID(string userID, string lineID, string cusPhone)
        {
            return repository.CheckRecordExsitByUserID(userID, lineID, cusPhone);
        }

        public bool InsertNewRecords(long userID, long lineID, long visitorStatusID, long firstVenderID, long secondVenderID, long billID
            , long phone, DateTime visitTime, string address, long adultNum, long adultPrice, long returnCost, string visitor
            , long childNum, long childPrice, bool isSH, bool isBM, bool isBSLYK, string notes, long otherCost, string createdBy, DateTime createdOn)
        {
            return repository.InsertNewRecords(userID, lineID, visitorStatusID, firstVenderID, secondVenderID, billID
            , phone, visitTime, address, adultNum, adultPrice, returnCost, visitor
            , childNum, childPrice, isSH, isBM, isBSLYK, notes, otherCost, createdBy, createdOn);
        }

        public DataTable GetVisitorRecordForTomorrow(long userID)
        {
            return repository.GetVisitorRecordForTomorrow(userID);
        }
        public DataTable GetVisitorRecordForHistory(long userID)
        {
            return repository.GetVisitorRecordForHistory(userID);
        }

        public DataTable AdminGetVisitorRecordForTomorrow()
        {
            return repository.AdminGetVisitorRecordForTomorrow();
        }

        public DataTable AdminGetVisitorRecordForHistory()
        {
            return repository.AdminGetVisitorRecordForHistory();
        }

        public DataTable GetAllSecondVender()
        {
            return repository.GetAllSecondVender();
        }

        public DataTable GetAllVisitorStatus()
        {
            return repository.GetAllVisitorStatus();
        }

        public int UpdateLineInformationForAdmin(long LineID, long updateLowPrice, long updateLowPriceSH, long updateLowPriceChild, string updateNotes)
        {
            return repository.UpdateLineInformationForAdmin(LineID, updateLowPrice, updateLowPriceSH, updateLowPriceChild, updateNotes);
        }

        public int DeleteLineRecord(long LineID)
        {
            return repository.DeleteLineRecord(LineID);
        }

        public int UpdateVisitorInformationForAdmin(long VisitorID, long updateAdultNm, long updateAdultPrice, long updateChilNm, long updateChilPrice, string updateNotes, long updateRetValue, long updateSecVender, long updateVisitorStatus)
        {
            return repository.UpdateVisitorInformationForAdmin(VisitorID, updateAdultNm, updateAdultPrice, updateChilNm, updateChilPrice, updateNotes, updateRetValue, updateSecVender, updateVisitorStatus);
        }

        public int DeleteVisitorRecord(long visitorID)
        {
            return repository.DeleteVisitorRecord(visitorID);
        }

        public bool CheckLineExist(string startCity, string lineName)
        {
            return repository.CheckLineExist(startCity, lineName);
        }

        public bool AddNewLine(string startCity, string lineName, int days, long lowPrice, long priceSH, long priceChild, string notes, string createdBy)
        {
            return repository.AddNewLine(startCity, lineName, days, lowPrice, priceSH, priceChild, notes, createdBy);
        }
    }
}
