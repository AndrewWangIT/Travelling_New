using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travelling.Service;

namespace Travelling.Web.Form
{
    public partial class Reset : System.Web.UI.Page
    {
        UserManagementService UserServer = new UserManagementService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtUserName.Text = Session["userName"].ToString();
            }
        }

        public void btnReset_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.ToString();
            string newPassword = txtPassword.Text.ToString();
            int retValue = UserServer.ResetPassword(userName, newPassword);
            if(retValue > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('密码更改成功！')", true);
                Response.Redirect("../Form/Login.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('密码更改失败，请确保用户名和初始用户名一致！')", true);
            }
        }

        public void btnCancel_Click (object sender, EventArgs e)
        {
            Response.Redirect("../Form/Login.aspx");
        }
    }
}