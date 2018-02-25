using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling.Repository
{
    public class LineReporsitory
    {
        string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public DataTable GetALlLines()
        {
            using (SqlConnection xonn = new SqlConnection(connStr))
            {
                xonn.Open();
                using (SqlCommand cmd = xonn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [dbo].[Travelling.Line]";
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataset = new DataTable();
                    adapter.Fill(dataset);
                    return dataset;
                }
            }
        }

        public int GetMaxDayLine()
        {
            using (SqlConnection xonn = new SqlConnection(connStr))
            {
                xonn.Open();
                using (SqlCommand cmd = xonn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Max(Day) FROM [dbo].[Travelling.Line]";
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataset = new DataTable();
                    adapter.Fill(dataset);
                    return Convert.ToInt32(dataset.Rows[0][0]);
                }
            }
        }

        public List<string> GetStartCity()
        {
            List<string> list = new List<string>();
            using (SqlConnection xonn = new SqlConnection(connStr))
            {
                xonn.Open();
                using (SqlCommand cmd = xonn.CreateCommand())
                {
                    cmd.CommandText = "SELECT DISTINCT([StartCity]) FROM [dbo].[Travelling.Line]";
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable datatable = new DataTable();
                    adapter.Fill(datatable);
                    for(int i = 0; i < datatable.Rows.Count; i ++)
                    {
                        list.Add(datatable.Rows[i][0].ToString());
                    }
                    return list;
                }
            }
        }

        public DataTable GetAllLineByDay(string selStartCity, string selDay)
        {
            using (SqlConnection xonn = new SqlConnection(connStr))
            {
                xonn.Open();
                using (SqlCommand cmd = xonn.CreateCommand())
                {
                    cmd.CommandText = "SELECT [LineID], [LineName] FROM [dbo].[Travelling.Line] WHERE [StartCity] = '" + selStartCity  + "' AND [Day] = " + selDay;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataset = new DataTable();
                    adapter.Fill(dataset);
                    return dataset;
                }
            }
        }

        public DataTable GetLineByID (long lineID)
        {
            using (SqlConnection xonn = new SqlConnection(connStr))
            {
                xonn.Open();
                using (SqlCommand cmd = xonn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [dbo].[Travelling.Line] WHERE [LineID] = " + lineID;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataset = new DataTable();
                    adapter.Fill(dataset);
                    return dataset;
                }
            }
        }

        public bool CheckRecordExsitByUserID(string userID, string lineID, string cusPhone)
        {
            using (SqlConnection xonn = new SqlConnection(connStr))
            {
                xonn.Open();
                using (SqlCommand cmd = xonn.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(1) FROM [dbo].[Travelling.VisitorInfo] WHERE [UserID] = '" + userID + "' AND [LineID] = '" + lineID + "' AND [Phone] = '" + cusPhone + "'";
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool InsertNewRecords(long userID, long lineID, long visitorStatusID, long firstVenderID, long secondVenderID, long billID
            ,long phone, DateTime visitTime, string address, long adultNum, long adultPrice, long returnCost, string visitor
            ,long childNum, long childPrice, bool isSH, bool isBM, bool isBSLYK, string notes, long otherCost, string createdBy, DateTime createdOn)
        {
            using (SqlConnection xonn = new SqlConnection(connStr))
            {
                xonn.Open();
                using (SqlCommand cmd = xonn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO[dbo].[Travelling.VisitorInfo]"
                                           + "([UserID]"
                                           + ",[LineID]"
                                           + ",[VisitorStatusID]"
                                           + ",[FirstVenderID]"
                                           + ",[SecondVenderID]"
                                           + ",[BillID]"
                                           + ",[Phone]"
                                           + ",[VisitTime]"
                                           + ",[Address]"
                                           + ",[AdultNum]"
                                           + ",[AdultPrice]"
                                           + ",[ReturnCost]"
                                           + ",[VisitorName]"
                                           + ",[ChildNum]"
                                           + ",[ChildPrice]"
                                           + ",[IsSH]"
                                           + ",[IsBM]"
                                           + ",[IsBSLYK]"
                                           + ",[Notes]"
                                           + ",[OtherCost]"
                                           + ",[CreatedBy]"
                                           + ",[CreatedOn]) "
                                      + "VALUES"
                                           + " ('" + userID + "'"
                                           + ", '" + lineID + "'"
                                           + ", '" + visitorStatusID + "'"
                                           + ", '" + firstVenderID + "'"
                                           + ", '" + secondVenderID + "'"
                                           + ", '" + billID + "'"
                                           + ", '" + phone + "'"
                                           + ", '" + visitTime + "'"
                                           + ", '" + address + "'"
                                           + ", '" + adultNum + "'"
                                           + ", '" + adultPrice + "'"
                                           + ", '" + returnCost + "'"
                                           + ", '" + visitor + "'"
                                           + ", '" + childNum + "'"
                                           + ", '" + childPrice + "'"
                                           + ", '" + isSH + "'"
                                           + ", '" + isBM + "'"
                                           + ", '" + isBSLYK + "'"
                                           + ", '" + notes + "'"
                                           + ", '" + otherCost + "'"
                                           + ", '" + createdBy + "'"
                                           + ", '" + createdOn+"')";
                    
                    int count = Convert.ToInt32(cmd.ExecuteNonQuery());
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public DataTable GetVisitorRecordForTomorrow(long userID)
        {
            using (SqlConnection xonn = new SqlConnection(connStr))
            {
                xonn.Open();
                using (SqlCommand cmd = xonn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetVisitorInformationByUserID";
                    SqlParameter parUserID = new SqlParameter("@userID", SqlDbType.BigInt);
                    parUserID.Value = userID;
                    cmd.Parameters.Add(parUserID);
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetVisitorRecordForHistory(long userID)
        {
            using (SqlConnection xonn = new SqlConnection(connStr))
            {
                xonn.Open();
                using (SqlCommand cmd = xonn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "GetHistoryVisitorInformationByUserID";
                    SqlParameter parUserID = new SqlParameter("@userID", SqlDbType.BigInt);
                    parUserID.Value = userID;
                    cmd.Parameters.Add(parUserID);
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable AdminGetVisitorRecordForTomorrow()
        {
            using (SqlConnection xonn = new SqlConnection(connStr))
            {
                xonn.Open();
                using (SqlCommand cmd = xonn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AdminGetVisitorInformationForTomorrow";
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable AdminGetVisitorRecordForHistory()
        {
            using (SqlConnection xonn = new SqlConnection(connStr))
            {
                xonn.Open();
                using (SqlCommand cmd = xonn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "AdminGetHistoryVisitorInformationByUserID";
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetAllSecondVender()
        {
            using (SqlConnection xonn = new SqlConnection(connStr))
            {
                xonn.Open();
                using (SqlCommand cmd = xonn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [dbo].[Travelling.SecondVender]";
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataset = new DataTable();
                    adapter.Fill(dataset);
                    return dataset;
                }
            }
        }

        public DataTable GetAllVisitorStatus()
        {
            using (SqlConnection xonn = new SqlConnection(connStr))
            {
                xonn.Open();
                using (SqlCommand cmd = xonn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [dbo].[Travelling.VisitorStatus]";
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataset = new DataTable();
                    adapter.Fill(dataset);
                    return dataset;
                }
            }
        }

        public int UpdateLineInformationForAdmin(long LineID, long updateLowPrice, long updateLowPriceSH, long updateLowPriceChild, string updateNotes)
        {
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                string sql = "UPDATE [dbo].[Travelling.Line] SET [LowPrice] = " + updateLowPrice + " , [LowPriceSH] = " + updateLowPriceSH +
                                " , [LowPriceChild] = " + updateLowPriceChild + " , [Notes] = '" + updateNotes + " WHERE [ID] = " + LineID;
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                return command.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        public int DeleteLineRecord(long LineID)
        {
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                string sql = "DELETE FROM [dbo].[Travelling.Line] WHERE [LineID] = " + LineID;
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                return command.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        public int UpdateVisitorInformationForAdmin(long VisitorID, long updateAdultNm, long updateAdultPrice, long updateChilNm, long updateChilPrice, string updateNotes, long updateRetValue, long updateSecVender, long updateVisitorStatus)
        {
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                string sql = "UPDATE [dbo].[Travelling.VisitorInfo] SET [AdultNum] = " + updateAdultNm + " , [AdultPrice] = "+ updateAdultPrice +
                                " , [ChildNum] = " + updateChilNm + " , [ChildPrice] = " + updateChilPrice + " , [Notes] = '" + updateNotes + 
                                "' , [ReturnCost] = " + updateRetValue + " , [SecondVenderID] = " + updateSecVender + " , [VisitorStatusID] = " + updateVisitorStatus +
                                " WHERE [ID] = '" + VisitorID + "'";
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                return command.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        public int DeleteVisitorRecord(long visitorID)
        {
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                string sql = "DELETE FROM [dbo].[Travelling.VisitorInfo] WHERE [ID] = " + visitorID;
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                return command.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool CheckLineExist(string startCity, string lineName)
        {
            using (SqlConnection xonn = new SqlConnection(connStr))
            {
                xonn.Open();
                using (SqlCommand cmd = xonn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [dbo].[Travelling.Line] WHERE [Status] = 1 AND [StartCity] = N'" + startCity + "' AND [LineName] = N'" + lineName + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool AddNewLine(string startCity, string lineName, int days, long lowPrice, long priceSH, long priceChild, string notes, string createdBy)
        {
            using (SqlConnection xonn = new SqlConnection(connStr))
            {
                xonn.Open();
                using (SqlCommand cmd = xonn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [dbo].[Travelling.Line]"
                                           + "([StartCity]"
                                           + ",[LineName]"
                                           + ",[Status]"
                                           + ",[Day]"
                                           + ",[LowPrice]"
                                           + ",[LowPriceSH]"
                                           + ",[LowPriceChild]"
                                           + ",[Notes]"
                                           + ",[LastUpdatedBy]"
                                           + ",[LastUpdatedOn]) "
                                      + "VALUES"
                                           + " ('" + startCity + "'"
                                           + ", '" + lineName + "'"
                                           + ", 1"
                                           + ", " + days
                                           + ", " + lowPrice
                                           + ", " + priceSH
                                           + ", " + priceChild
                                           + ", '" + notes + "'"
                                           + ", '" + createdBy + "'"
                                           + ", GETDATE())";

                    int count = Convert.ToInt32(cmd.ExecuteNonQuery());
                    if (count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

    }
}
