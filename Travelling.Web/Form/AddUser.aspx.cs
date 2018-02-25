using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travelling.Service;

namespace Travelling.Web.Form
{
    public partial class AddUser : System.Web.UI.Page
    {
        UserManagementService UserService = new UserManagementService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void btnAddUser_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.ToString();
            string password = txtPassword.Text.ToString();
            bool retvalue;
            retvalue = UserService.CheckUserExist(userName);
            if(retvalue == true)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('用户名已存在，请重新添加用户名！')", true);
            }
            else
            {
                bool addValue;
                addValue = UserService.AddNewUser(userName, password, Session["userName"].ToString());
                if(addValue == true)
                {
                    Response.Write("<script language=javascript>alert('用户名添加成功！');window.location.href='Default.aspx'</script>");
                }
            }
        }

        public void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string userName = txtUserNameDel.Text.ToString();
            bool retValue;
            retValue = UserService.DeleteUserByUserName(userName);
            if(retValue == true)
            {
                Response.Write("<script language=javascript>alert('此用户名已删除成功！');window.location.href='Default.aspx'</script>");
            }
        }
    }

}