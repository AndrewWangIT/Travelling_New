<%@ Page Title="添加游客" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AddVisitor.aspx.cs" Inherits="Travelling.Web.Form.AddVisitor" %>

<%--<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="frm" runat="server">
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
        <div class="content container_12">
            <div class="box grid_12">
            <div class="box-head"><h2>添加新游客</h2></div>
            <div class="box-content no-pad">
              <table class="display">
              <tbody>
                <tr class="odd gradeX">
                  <td>
                      <asp:Label ID="lblLine" Font-Bold="true" Font-Size="15px" Width="100px" runat="server" Text="报客线路:"></asp:Label>
                      <asp:DropDownList ID="ddlDay" AutoPostBack="True" OnTextChanged="ddlDay_TextChanged" Width="150px" runat="server">
                          <asp:ListItem Text="-- 请选择天数 --" Selected="True" Value="0"></asp:ListItem>
                      </asp:DropDownList>
                      <asp:DropDownList ID="ddlLine" Width="150px" runat="server"></asp:DropDownList>
                  </td>
                  <td>
                      <asp:Label ID="lblDate" Font-Bold="true" Font-Size="15px" Width="100px" runat="server" Text="游玩日期:"></asp:Label>
                      <asp:TextBox ID="txtDate" Width="300px" runat="server"></asp:TextBox>
                      <%--<asp:CalendarExtender ID="txtDate_Calendar" runat="server" Format="yyyy-MM-dd" PopupButtonID="ImageCalendar" TargetControlID="txtDate">
                      </asp:CalendarExtender>--%>
                      <%--<asp:Image ID="ImageCalendar" runat="server" ImageUrl="../images/Calendar_scheduleHS.png" />--%>
                  </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblValueFrCus" Font-Bold="true" Font-Size="15px" Width="100px" runat="server" Text="成人价格:"></asp:Label>
                        <asp:TextBox ID="txtValueFrCus" Width="300px" runat="server"></asp:TextBox>
                        <asp:Label ID="lbltag" Font-Size="10px" runat="server" Text="元/人"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblName" Font-Bold="true" Font-Size="15px" Width="100px" runat="server" Text="游客姓名:"></asp:Label>
                        <asp:TextBox ID="txtName" Width="300px" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAdultNum" Font-Bold="true" Font-Size="15px" Width="100px" runat="server" Text="成人人数:"></asp:Label>
                        <asp:TextBox ID="txtAdultNum" Width="300px" runat="server" ></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblPhone" Font-Bold="true" Font-Size="15px" Width="100px" runat="server" Text="联系电话:"></asp:Label>
                        <asp:TextBox ID="txtPhone" Width="300px" TextMode="Phone" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton ID="radSH" GroupName="SHWD" runat="server" /><asp:Label ID="lblSH" Font-Bold="True" Font-Size="15px" Width="183px" runat="server" Text="上海人"></asp:Label>
                        <asp:RadioButton ID="radWD" GroupName="SHWD" runat="server" /><asp:Label ID="lblWD" Font-Bold="True" Font-Size="15px" Width="183px" runat="server" Text="外地人"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButton ID="radBM" AutoPostBack="true" OnCheckedChanged ="radBM_CheckedChanged" GroupName="BMBBM" runat="server" /><asp:Label ID="lblBM" Font-Bold="True" Font-Size="15px" Width="183px" runat="server" Text="包门票"></asp:Label>
                        <asp:RadioButton ID="radBBM" AutoPostBack="true" OnCheckedChanged ="radBM_CheckedChanged" GroupName="BMBBM" runat="server" /><asp:Label ID="lblBBM" Font-Bold="True" Font-Size="15px" Width="183px" runat="server" Text="不包门"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButton ID="radChild" AutoPostBack="true" OnCheckedChanged ="radNonChild_CheckedChanged" GroupName="Child" runat="server" /><asp:Label ID="lblChild" Font-Bold="True" Font-Size="15px" Width="183px" runat="server" Text="有儿童"></asp:Label>
                        <asp:RadioButton ID="radNonChild" AutoPostBack="true" OnCheckedChanged ="radNonChild_CheckedChanged" GroupName="Child" runat="server" /><asp:Label ID="lblNonChild" Font-Bold="True" Font-Size="15px" Width="183px" runat="server" Text="没儿童"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButton ID="radBSLYK" AutoPostBack="true" OnCheckedChanged="radNonBSLYK_CheckedChanged" GroupName="BSLYK" runat="server" /><asp:Label ID="lblBSYLK" Font-Bold="True" Font-Size="15px" Width="183px" runat="server" Text="补收旅游款"></asp:Label>
                        <asp:RadioButton ID="radNonBSLYK" AutoPostBack="true" OnCheckedChanged="radNonBSLYK_CheckedChanged" GroupName="BSLYK" runat="server" /><asp:Label ID="lblNonBSLYK" Font-Bold="True" Font-Size="15px" Width="183px" runat="server" Text="没补收旅游款"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblChildValue" Font-Bold="true" Font-Size="15px" Width="100px" runat="server" Text="儿童价格:"></asp:Label>
                        <asp:TextBox ID="txtChildValue" Width="300px" runat="server" ></asp:TextBox>
                        <asp:Label ID="lblChildTag" Font-Size="10px" runat="server" Text="元/人"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblBSJE" Font-Bold="true" Font-Size="15px" Width="100px" runat="server" Text="补收金额:"></asp:Label>
                        <asp:TextBox ID="txtBSJE" Width="300px" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblChildNum" Font-Bold="true" Font-Size="15px" Width="100px" runat="server" Text="儿童人数:"></asp:Label>
                        <asp:TextBox ID="txtChildNum" Width="300px" runat="server" ></asp:TextBox>
                    </td>
                    <%--<td>
                        <asp:Label ID="lblRetValue" Font-Bold="true" Font-Size="15px" Width="100px" runat="server" Text="盈利总和:"></asp:Label>
                        <asp:TextBox ID="txtRetValue" Width="300px" runat="server" ></asp:TextBox>
                    </td>--%>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblAddress" Font-Bold="true" Font-Size="15px" Width="100px" runat="server" Text="接站地址:"></asp:Label>
                        <asp:TextBox ID="txtAddress" Width="1050px" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblNotes" Font-Bold="true" Font-Size="15px" Width="100px" runat="server" Text="备注:"></asp:Label>
                        <asp:TextBox ID="txtNotes" Width="1050px" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                  <tr>
                    <td colspan="2" style="text-align:right;">
                        <asp:ImageButton ID="Submit" runat="server" CausesValidation="false" ImageUrl="../images/add2.gif" ToolTip="提交" OnClick="Submit_Click" />
                    </td>
                </tr>
              </tbody>
             </table>
            </div>
          </div>
        </div>
    </form>

    <script type="text/javascript">
      $(document).ready(function () {
          var myDate = new Date();//获取系统当前时间
          var curentDate = myDate.getFullYear() + "-" + (myDate.getMonth() + 1) + "-" + myDate.getDate();//myDate表示当前时间
          var date = new Date(curentDate);
          $("#MainContent_txtDate").datepicker({//添加日期选择功能 
              numberOfMonths: 1,//显示几个月 
              showButtonPanel: true,//是否显示按钮面板 
              dateFormat: 'yy-mm-dd',//日期格式 
              clearText: "清除",//清除日期的按钮名称 
              closeText: "关闭",//关闭选择框的按钮名称 
              yearSuffix: '年', //年的后缀 
              showMonthAfterYear: true,//是否把月放在年的后面 
              defaultDate: myDate.getDate() + 1,//默认日期 
              minDate: date.getDate + 1,//最小日期 
              maxDate: date.getDate + 7,//最大日期 
              monthNames: ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月'],
              dayNames: ['星期日', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六'],
              dayNamesShort: ['周日', '周一', '周二', '周三', '周四', '周五', '周六'],
              dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
              
          });
      }); 
  </script>


</asp:Content>


