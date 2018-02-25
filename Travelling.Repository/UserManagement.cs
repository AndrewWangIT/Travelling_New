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
    public class UserManagement
    {
        string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public DataTable ConfirmUserInfo(string userName, string password)
        {
            using (SqlConnection xonn = new SqlConnection(connStr))
            {
                xonn.Open();
                using (SqlCommand cmd = xonn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [dbo].[Travelling.UserInfo] WHERE [Status] = 1 AND [UserName] = N'" + userName + "' " + " AND [Password] = N'" + password + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataset = new DataTable();
                    adapter.Fill(dataset);
                    return dataset;
                }
            }
        }

        public int ResetPassword(string userName, string newPassword)
        {
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                string sql = "UPDATE [dbo].[Travelling.UserInfo] SET [Password] = '" + newPassword + "' WHERE [UserName] = '" + userName + "'";
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

        public bool CheckUserExist(string userName)
        {
            using (SqlConnection xonn = new SqlConnection(connStr))
            {
                xonn.Open();
                using (SqlCommand cmd = xonn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM [dbo].[Travelling.UserInfo] WHERE [Status] = 1 AND [UserName] = N'" + userName + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if(dt.Rows.Count > 0)
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

        public bool AddNewUser(string userName, string password, string createdBy)
        {
            using (SqlConnection xonn = new SqlConnection(connStr))
            {
                xonn.Open();
                using (SqlCommand cmd = xonn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO [dbo].[Travelling.UserInfo]"
                                           + "([UserName]"
                                           + ",[Password]"
                                           + ",[ProfileID]"
                                           + ",[Status]"
                                           + ",[CreatedBy]"
                                           + ",[CreatedOn]"
                                           + ",[UpdatedBy]"
                                           + ",[UpdatedOn]) "
                                      + "VALUES"
                                           + " ('" + userName + "'"
                                           + ", '" + password + "'"
                                           + ", '2'"
                                           + ", 1"
                                           + ", '" + createdBy + "'"
                                           + ", GETDATE()"
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

        public bool DeleteUserByUserName(string userName)
        {
            int retValue;
            SqlConnection conn = new SqlConnection(connStr);
            try
            {
                string sql = "UPDATE [dbo].[Travelling.UserInfo] SET [Status] = 0 WHERE [UserName] = '" + userName + "'";
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                retValue = command.ExecuteNonQuery();
                if(retValue >0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
