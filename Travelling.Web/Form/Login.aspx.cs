using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travelling.Service;

namespace Travelling.Web.Form
{
    public partial class Login : System.Web.UI.Page
    {
        UserManagementService UserService = new UserManagementService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.ToString();
            string password = txtPassword.Text.ToString();
            DataTable dt = UserService.ConfirmUserInfo(userName, password);
            if(dt.Rows.Count < 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('用户名或密码不正确！')", true);
            }
            else
            {
                Session["userName"] = dt.Rows[0][1].ToString();
                Session["userID"] = dt.Rows[0][0].ToString();
                Session["profileID"] = dt.Rows[0][3].ToString();
                Response.Redirect("../Form/Lines.aspx");
            }
        }

        public void btnReset_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.ToString();
            string password = txtPassword.Text.ToString();
            DataTable dt = UserService.ConfirmUserInfo(userName, password);
            if (dt.Rows.Count < 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('用户名或密码不正确！')", true);
            }
            else
            {
                Session["userName"] = dt.Rows[0][1].ToString();
                Response.Redirect("../Form/Reset.aspx");
            }
        }
    }
}