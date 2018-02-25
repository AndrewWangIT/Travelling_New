using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travelling.Repository;

namespace Travelling.Service
{
    public class UserManagementService
    {
        UserManagement repository = new UserManagement();
        public DataTable ConfirmUserInfo (string userName, string password)
        {
            return repository.ConfirmUserInfo(userName, password);
        }

        public int ResetPassword (string userName, string newPassword)
        {
            return repository.ResetPassword(userName, newPassword);
        }

        public bool CheckUserExist(string userName)
        {
            return repository.CheckUserExist(userName);
        }

        public bool AddNewUser(string userName, string password, string createdBy)
        {
            return repository.AddNewUser(userName, password, createdBy);
        }

        public bool DeleteUserByUserName(string userName)
        {
            return repository.DeleteUserByUserName(userName);
        }
    }
}
