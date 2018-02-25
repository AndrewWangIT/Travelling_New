using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travelling.Service;

namespace Travelling.Web.Form
{
    public partial class Lines : System.Web.UI.Page
    {
        LineService lineService = new LineService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            gvLine.DataSource = lineService.GetAllLines();
            gvLine.DataBind();
        }


        protected void gvLine_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLine.PageIndex = e.NewPageIndex;
            BindData();
        }
    }
}