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
    public partial class AddVisitor : System.Web.UI.Page
    {
        LineService LineService = new LineService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {


                List<string> startCity;
                int maxDayLine;
                startCity = LineService.GetStartCity();
                for(int j = 0; j < startCity.Count; j ++)
                {
                    ddlStartCity.Items.Add(new ListItem(startCity[j] + "出发", startCity[j]));
                }
                
                maxDayLine = LineService.GetMaxDayLine();
                for(int i = 1; i <= maxDayLine; i++)
                {
                    ddlDay.Items.Add(new ListItem(i + "日游", i.ToString()));
                }

                txtDate.Attributes.Add("readonly", "true");

                //txtRetValue.Enabled = false;
                txtBSJE.Enabled = false;
                txtBSJE.Text = Convert.ToString(0);
            }

        }
        
        public void ddlDay_TextChanged(object sender, EventArgs e)
        {
            string selStartCity = ddlStartCity.SelectedValue;
            string selDay = ddlDay.SelectedValue;
            DataTable dt = LineService.GetAllLineByDay(selStartCity, selDay);
            ddlLine.DataSource = dt;
            ddlLine.DataValueField = dt.Columns[0].ColumnName;
            ddlLine.DataTextField = dt.Columns[1].ColumnName;
            ddlLine.DataBind();
        }

        public void radNonChild_CheckedChanged(object sender, EventArgs e)
        {
            if (radNonChild.Checked == true)
            {
                txtChildValue.Enabled = false;
                txtChildNum.Enabled = false;
                txtChildValue.Text = Convert.ToString(0);
                txtChildNum.Text = Convert.ToString(0);
            }
            else
            {
                txtChildValue.Enabled = true;
                txtChildNum.Enabled = true;
                txtChildValue.Text = null;
                txtChildNum.Text = null;
            }
        }

        public void radNonBSLYK_CheckedChanged(object sender, EventArgs e)
        {
            if (radNonBSLYK.Checked == true)
            {
                txtBSJE.Enabled = false;
                txtBSJE.Text = Convert.ToString(0);
            }
            else
            {
                txtBSJE.Enabled = true;
                txtBSJE.Text = null;
            }
        }

        public void radBM_CheckedChanged(object sender, EventArgs e)
        {
            if(radBM.Checked == true)
            {
                radBSLYK.Enabled = false;
                radNonBSLYK.Enabled = false;
                txtBSJE.Enabled = false;
                radBSLYK.Checked= false;
                radNonBSLYK.Checked = true;
                txtBSJE.Text = Convert.ToString(0);
            }
            else
            {
                radBSLYK.Enabled = true;
                radNonBSLYK.Enabled = true;
                radBSLYK.Checked = false;
                radNonBSLYK.Checked = false;
            }
        }

        public void Submit_Click(object sender, EventArgs e)
        {
            long lineID;
            long lowPrice;
            long lowPriceSH;
            long lowPriceChild;
            long adultPrice;
            long adultNum;
            long childPrice;
            long childNum;
            long rechargeValue;
            long retValue;
            long phone;
            string cusName;
            string notes;
            string address;
            DateTime visitTime;
            
            lineID = Convert.ToInt64(ddlLine.SelectedValue);
            DataTable dt = LineService.GetLineByID(lineID);
            lowPrice = Convert.ToInt64(dt.Rows[0]["LowPrice"]);
            lowPriceSH = Convert.ToInt64(dt.Rows[0]["LowPriceSH"]);
            lowPriceChild = Convert.ToInt64(dt.Rows[0]["LowPriceChild"]);
            adultPrice = Convert.ToInt64(txtValueFrCus.Text);
            adultNum = Convert.ToInt64(txtAdultNum.Text);
            childPrice = Convert.ToInt64(txtChildValue.Text);
            childNum = Convert.ToInt64(txtChildNum.Text);
            phone = Convert.ToInt64(txtPhone.Text);
            rechargeValue = Convert.ToInt64(txtBSJE.Text);
            cusName = Convert.ToString(txtName.Text);
            notes = Convert.ToString(txtNotes.Text);
            address = Convert.ToString(txtAddress.Text);
            visitTime = Convert.ToDateTime(txtDate.Text);

            if (ddlLine.SelectedIndex.ToString() == "-1")
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('请选择游玩线路！')", true);
                return;
            }
            else if(String.IsNullOrEmpty(txtDate.Text.ToString()))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('请选择游玩时间！')", true);
                return;
            }
            else if(String.IsNullOrEmpty(txtValueFrCus.Text.ToString()))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('请填写成人价格！')", true);
                return;
            }
            else if (String.IsNullOrEmpty(txtAdultNum.Text.ToString()))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('请填写成人人数！')", true);
                return;
            }
            else if (String.IsNullOrEmpty(txtName.Text.ToString()))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('请填写游客姓名！')", true);
                return;
            }
            else if (String.IsNullOrEmpty(txtPhone.Text.ToString()))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('请填写联系电话！')", true);
                return;
            }
            else if(String.IsNullOrEmpty(txtAddress.Text.ToString()))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('请填写接站地址！')", true);
                return;
            }
            else if(radSH.Checked == false && radWD.Checked == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('请填写游客是否是上海人！')", true);
                return;
            }
            else if (radBM.Checked == false && radBBM.Checked == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('请填写是否包门！')", true);
                return;
            }
            else if (radChild.Checked == false && radNonChild.Checked == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('请填写是否有儿童！')", true);
                return;
            }
            else if(radChild.Checked == true)
            {
                if(String.IsNullOrEmpty(txtChildValue.Text.ToString()) || String.IsNullOrEmpty(txtChildNum.Text.ToString()))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('请填写儿童人数和价格！')", true);
                    return;
                }
            }
            else if (radBSLYK.Checked == false && radNonBSLYK.Checked == false)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('请填写是否补收旅游款！')", true);
                return;
            }
            else if(radBSLYK.Checked == true)
            {
                if(String.IsNullOrEmpty(txtBSJE.Text.ToString()))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('请填写补收旅游款金额！')", true);
                    return;
                }
            }

            bool checkRecord = false;
            checkRecord = LineService.CheckRecordExsitByUserID(Session["userID"].ToString(), lineID.ToString(), txtPhone.Text.ToString());
            if (checkRecord == true)
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('客人已经添加，不能重复添加相同客人！')", true);
                Response.Write("<script language=javascript>alert('客人已经添加，不能重复添加相同客人！');window.location.href='AddVisitor.aspx'</script>");
                return;
            }
            else
            {
                if (radNonBSLYK.Checked == false)
                {
                    retValue = rechargeValue - ((adultPrice - lowPrice) * adultNum + (childPrice - lowPriceChild) * childNum);
                    //txtRetValue.Text = retValue.ToString();
                    return;
                }
                else if (radBBM.Checked == false)
                {
                    retValue = 0 - lowPrice * adultNum;
                    //txtRetValue.Text = retValue.ToString();
                    return;
                }
                else
                {
                    if (radWD.Checked == true && radNonChild.Checked == true)
                    {
                        retValue = (adultPrice - lowPrice) * adultNum;
                        //txtRetValue.Text = retValue.ToString();
                    }
                    else if (radWD.Checked == true && radNonChild.Checked == false)
                    {
                        retValue = (adultPrice - lowPrice) * adultNum + (childPrice - lowPriceChild) * childNum;
                        //txtRetValue.Text = retValue.ToString();
                    }
                    else if (radWD.Checked == false && radNonChild.Checked == true)
                    {
                        retValue = (adultPrice - lowPriceSH) * adultNum;
                        //txtRetValue.Text = retValue.ToString();
                    }
                    else if (radWD.Checked == false && radNonChild.Checked == false)
                    {
                        retValue = (adultPrice - lowPriceSH) * adultNum + (childPrice - lowPriceChild) * childNum;
                        //txtRetValue.Text = retValue.ToString();
                    }
                    else
                    {
                        retValue = 0;
                        //txtRetValue.Text = Convert.ToString(0);
                    }

                    bool retResult = false;
                    retResult = LineService.InsertNewRecords(Convert.ToInt64(Session["userID"]), lineID, 1, 1, 1, 2, phone
                                                            , visitTime, address, adultNum, adultPrice
                                                            , retValue, cusName, childNum, childPrice
                                                            , radSH.Checked, radBM.Checked, radBSLYK.Checked, notes, rechargeValue
                                                            , Convert.ToString(Session["userName"]), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")));
                    if(retResult == true)
                    {
                        Response.Write("<script language=javascript>alert('您的游客已提交成功，系统自动跳转到明日参团！');window.location.href='Inquiry.aspx'</script>");
                        //Response.Write("<script language=javascript>alert(您的游客已提交成功！');window.location.href='Inquiry.aspx'</script>");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "onekey", "alert('您的游客提交失败，请联系管理员！')", true);
                    }
                }
            }
           
        }
        
    }
}