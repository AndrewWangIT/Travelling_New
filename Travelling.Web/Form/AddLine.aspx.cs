using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travelling.Service;

namespace Travelling.Web.Form
{
    public partial class AddLine : System.Web.UI.Page
    {
        LineService lineService = new LineService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void btnAddLine_Click(object sender, EventArgs e)
        {
            string startCity = txtStartCity.Text.ToString();
            string lineName = txtLineName.Text.ToString();
            int days = Convert.ToInt32(txtDays.Text);
            long lowPrice = Convert.ToInt64(txtLowPrice.Text);
            long priceSH = Convert.ToInt64(txtPriceSH.Text);
            long priceChild = Convert.ToInt64(txtPriceChild.Text);
            string notes = txtNotes.Text.ToString();
            bool retvalue;
            retvalue = lineService.CheckLineExist(startCity, lineName);
            if (retvalue == true)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('线路已存在，请重新添加同一线路！')", true);
            }
            else
            {
                bool addValue;
                addValue = lineService.AddNewLine(startCity, lineName, days, lowPrice, priceSH, priceChild, notes, Session["userName"].ToString());
                if (addValue == true)
                {
                    Response.Write("<script language=javascript>alert('新线路添加成功！');window.location.href='AdminLine.aspx'</script>");
                }
            }
        }
    }
}