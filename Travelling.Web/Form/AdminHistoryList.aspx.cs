using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travelling.Service;
using ClosedXML.Excel;
using System.IO;

namespace Travelling.Web.Form
{
    public partial class AdminHistoryList : System.Web.UI.Page
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
            gvAdminVisitorList.DataSource = lineService.AdminGetVisitorRecordForHistory();
            gvAdminVisitorList.DataBind();
        }


        protected void gvAdminVisitorList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAdminVisitorList.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void gvAdminVisitorList_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAdminVisitorList.EditIndex = -1;                 /*编辑索引赋值为-1，变回正常显示状态*/
            BindData();
        }

        protected void gvAdminVisitorList_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            long id = Convert.ToInt32(gvAdminVisitorList.DataKeys[e.RowIndex].Value);/*获取主键，需要设置 DataKeyNames，这里设为 id */
            int retValue = lineService.DeleteVisitorRecord(id);
            if(retValue >0)
            {
                Response.Write("<script language=javascript>alert('游客信息删除成功！');window.location.href='AdminMinRCT.aspx'</script>");
            }
        }

        protected void gvAdminVisitorList_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAdminVisitorList.EditIndex = e.NewEditIndex;
            
            BindData();              /*再次绑定显示编辑行的原数据,不进行绑定要点2次编辑才能跳到编辑状态*/
        }

        protected void gvAdminVisitorList_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            long VisitorID = Convert.ToInt32(gvAdminVisitorList.DataKeys[e.RowIndex].Value);
            long updateAdultNm = Convert.ToInt64((gvAdminVisitorList.Rows[e.RowIndex].Cells[4].Controls[0] as TextBox).Text);    /*获取要更新的数据*/
            long updateAdultPrice = Convert.ToInt64((gvAdminVisitorList.Rows[e.RowIndex].Cells[5].Controls[0] as TextBox).Text);
            long updateChilNm = Convert.ToInt64((gvAdminVisitorList.Rows[e.RowIndex].Cells[6].Controls[0] as TextBox).Text);
            long updateChilPrice = Convert.ToInt64((gvAdminVisitorList.Rows[e.RowIndex].Cells[7].Controls[0] as TextBox).Text);
            string updateNotes = (gvAdminVisitorList.Rows[e.RowIndex].Cells[9].Controls[0] as TextBox).Text.ToString();
            long updateRetValue= Convert.ToInt64((gvAdminVisitorList.Rows[e.RowIndex].Cells[10].Controls[0] as TextBox).Text);
            DropDownList itme1 = (DropDownList)(gvAdminVisitorList.Rows[e.RowIndex].FindControl("ddlSecVender"));
            DropDownList itme2 = (DropDownList)(gvAdminVisitorList.Rows[e.RowIndex].FindControl("ddlVisitorStatus"));
            long updateSecVender = Convert.ToInt64(itme1.SelectedValue);
            long updateVisitorStatus = Convert.ToInt64(itme2.SelectedValue);
            int retValue = lineService.UpdateVisitorInformationForAdmin(VisitorID, updateAdultNm, updateAdultPrice, updateChilNm, updateChilPrice, updateNotes, updateRetValue, updateSecVender, updateVisitorStatus);
            if(retValue > 0)
            {
                Response.Write("<script language=javascript>alert('游客信息修改成功！');window.location.href='AdminMinRCT.aspx'</script>");
            }
        }

        protected void gvAdminVisitorList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowState == DataControlRowState.Edit ||
                 e.Row.RowState == (DataControlRowState.Alternate | DataControlRowState.Edit))
            {
                DropDownList ddlSecVender = e.Row.FindControl("ddlSecVender") as DropDownList;
                DropDownList ddlVisitorStatus = e.Row.FindControl("ddlVisitorStatus") as DropDownList;
                DataTable dt = new DataTable();
                dt = lineService.GetAllSecondVender();
                ddlSecVender.DataSource = dt;
                ddlSecVender.DataValueField = dt.Columns[0].ColumnName;
                ddlSecVender.DataTextField = dt.Columns[1].ColumnName;
                ddlSecVender.DataBind();
                DataTable dt1 = new DataTable();
                dt1 = lineService.GetAllVisitorStatus();
                ddlVisitorStatus.DataSource = dt1;
                ddlVisitorStatus.DataValueField = dt1.Columns[0].ColumnName;
                ddlVisitorStatus.DataTextField = dt1.Columns[1].ColumnName;
                ddlVisitorStatus.DataBind();
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = lineService.AdminGetVisitorRecordForHistory();
            using (dt)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    IXLWorksheet ws = wb.Worksheets.Add(dt, "抱客历史记录");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=抱客历史记录.xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
        }
    }
}