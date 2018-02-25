using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travelling.Service;

namespace Travelling.Web.Form
{
    public partial class HistoryList : System.Web.UI.Page
    {
        LineService lineService = new LineService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvVisitorList.DataSource = lineService.GetVisitorRecordForHistory(Convert.ToInt64(Session["userID"]));

                gvVisitorList.DataBind();
            }
        }

        public void gvVisitorList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVisitorList.PageIndex = e.NewPageIndex;
            gvVisitorList.DataSource = lineService.GetVisitorRecordForHistory(Convert.ToInt64(Session["userID"]));
            gvVisitorList.DataBind();
        }
    }
}