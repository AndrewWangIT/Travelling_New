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
    public partial class AdminLine : System.Web.UI.Page
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

        protected void gvLine_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvLine.EditIndex = -1;                 /*编辑索引赋值为-1，变回正常显示状态*/
            BindData();
        }

        protected void gvLine_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            long id = Convert.ToInt32(gvLine.DataKeys[e.RowIndex].Value);/*获取主键，需要设置 DataKeyNames，这里设为 id */
            int retValue = lineService.DeleteLineRecord(id);
            if (retValue > 0)
            {
                Response.Write("<script language=javascript>alert('线路删除成功！');window.location.href='AdminLine.aspx'</script>");
            }
        }

        protected void gvLine_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvLine.EditIndex = e.NewEditIndex;

            BindData();              /*再次绑定显示编辑行的原数据,不进行绑定要点2次编辑才能跳到编辑状态*/
        }

        protected void gvLine_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            long LineID = Convert.ToInt32(gvLine.DataKeys[e.RowIndex].Value);
            long updateLowPrice = Convert.ToInt64((gvLine.Rows[e.RowIndex].Cells[4].Controls[0] as TextBox).Text);    /*获取要更新的数据*/
            long updateLowPriceSH = Convert.ToInt64((gvLine.Rows[e.RowIndex].Cells[5].Controls[0] as TextBox).Text);
            long updateLowPriceChild = Convert.ToInt64((gvLine.Rows[e.RowIndex].Cells[6].Controls[0] as TextBox).Text);
            string updateNotes = (gvLine.Rows[e.RowIndex].Cells[7].Controls[0] as TextBox).Text.ToString();
            
            int retValue = lineService.UpdateLineInformationForAdmin(LineID, updateLowPrice, updateLowPriceSH, updateLowPriceChild, updateNotes);
            if (retValue > 0)
            {
                Response.Write("<script language=javascript>alert('游客信息修改成功！');window.location.href='AdminMinRCT.aspx'</script>");
            }
        }

        //protected void gvLine_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowState == DataControlRowState.Edit ||
        //         e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
        //    {
        //        DropDownList ddlSecVender = e.Row.FindControl("ddlSecVender") as DropDownList;
        //        DropDownList ddlVisitorStatus = e.Row.FindControl("ddlVisitorStatus") as DropDownList;
        //        DataTable dt = new DataTable();
        //        dt = lineService.GetAllSecondVender();
        //        ddlSecVender.DataSource = dt;
        //        ddlSecVender.DataValueField = dt.Columns[0].ColumnName;
        //        ddlSecVender.DataTextField = dt.Columns[1].ColumnName;
        //        ddlSecVender.DataBind();
        //        DataTable dt1 = new DataTable();
        //        dt1 = lineService.GetAllVisitorStatus();
        //        ddlVisitorStatus.DataSource = dt1;
        //        ddlVisitorStatus.DataValueField = dt1.Columns[0].ColumnName;
        //        ddlVisitorStatus.DataTextField = dt1.Columns[1].ColumnName;
        //        ddlVisitorStatus.DataBind();
        //    }
        //}


    }
}