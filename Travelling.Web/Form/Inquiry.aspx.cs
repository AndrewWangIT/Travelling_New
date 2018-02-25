using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travelling.Service;

namespace Travelling.Web.Form
{
    public partial class Inquiry : System.Web.UI.Page
    {
        LineService lineService = new LineService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                gvVisitorList.DataSource = lineService.GetVisitorRecordForTomorrow(Convert.ToInt64(Session["userID"]));
                
                gvVisitorList.DataBind();
            }
        }

        public void gvVisitorList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVisitorList.PageIndex = e.NewPageIndex;
            gvVisitorList.DataSource = lineService.GetVisitorRecordForTomorrow(Convert.ToInt64(Session["userID"]));
            gvVisitorList.DataBind();
        }

        protected void gvVisitorList_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            long id = Convert.ToInt32(gvVisitorList.DataKeys[e.RowIndex].Value);/*获取主键，需要设置 DataKeyNames，这里设为 id */
            int retValue = lineService.DeleteVisitorRecord(id);
            if (retValue > 0)
            {
                Response.Write("<script language=javascript>alert('游客信息删除成功！');window.location.href='Inquiry.aspx'</script>");
            }
        }
    }
}