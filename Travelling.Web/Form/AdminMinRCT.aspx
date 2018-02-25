<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminMinRCT.aspx.cs" Inherits="Travelling.Web.Form.AdminMinRCT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="content container_12">
        <div class="box grid_12">
        <div class="box-head"><h2>管理员-明日参团列表</h2></div>
        <div class="box-content no-pad">
            <form runat ="server">
                <table>
                    <tr>
                        <asp:GridView id="gvAdminVisitorList" Width="100%" runat="server" AutoGenerateColumns="false" BorderColor="#999999" Font-Bold="true" Font-Size="10px" BorderWidth="1px" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor ="#6699ff" 
                            HeaderStyle-Height="35px" CellPadding="3" HeaderStyle-Font-Size="16px" AllowPaging="true" PageSize="15" OnPageIndexChanging="gvAdminVisitorList_PageIndexChanging"
                            DataKeyNames="id" AutoGenerateEditButton="True" OnRowDeleting="gvAdminVisitorList_OnRowDeleting" OnRowEditing="gvAdminVisitorList_OnRowEditing" 
                            OnRowDataBound="gvAdminVisitorList_RowDataBound" OnRowCancelingEdit="gvAdminVisitorList_OnRowCancelingEdit" OnRowUpdating="gvAdminVisitorList_OnRowUpdating">
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:BoundField DataField="VisitorName" HeaderText="游客姓名" SortExpression="VisitorName" ReadOnly="true" />
                                <asp:BoundField DataField="Phone" HeaderText="联系电话" SortExpression="Phone" ReadOnly="true" />
                                <asp:BoundField DataField="LineName" HeaderText="线路名称" SortExpression="LineName" ReadOnly="true" />
                                <asp:BoundField DataField="AdultNum" HeaderText="成人人数" SortExpression="AdultNum" />
                                <asp:BoundField DataField="AdultPrice" HeaderText="成人价格" SortExpression="AdultPrice" />
                                <asp:BoundField DataField="ChildNum" HeaderText="儿童人数" SortExpression="ChildNum" />
                                <asp:BoundField DataField="ChildPrice" HeaderText="儿童价格" SortExpression="ChildPrice" />
                                <%--<asp:BoundField DataField="IsSH" HeaderText="上海人" ReadOnly="true" />
                                <asp:BoundField DataField="IsBM" HeaderText="包门" ReadOnly="true" />
                                <asp:BoundField DataField="IsBSLYK" HeaderText="补收旅游款" />
                                <asp:BoundField DataField="OtherCost" HeaderText="补收旅游金额" />--%>
                                <asp:BoundField DataField="Address" HeaderText="联系地址" ReadOnly="true" />
                                <asp:BoundField DataField="Notes" HeaderText="备注" />
                                <asp:BoundField DataField="ReturnCost" HeaderText="返利" />
                        
                                <%--<asp:BoundField DataField="VisitorStatus" HeaderText="客人状态" ReadOnly="true" />--%>
                                <asp:TemplateField HeaderText="客人状态">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVisitorStatus" runat="server" Text='<%# Eval("VisitorStatus") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlVisitorStatus" runat="server" Width="151px"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="FisVenderName" HeaderText="收客人" ReadOnly="true" />
                                <%--<asp:BoundField DataField="SecVenderName" HeaderText="转接人" />--%>
                                <asp:TemplateField HeaderText="转接人">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSecVender" runat="server" Text='<%# Eval("SecVenderName") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlSecVender" runat="server" Width="151px"></asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="BillStatus" HeaderText="结账状态" ReadOnly="true" />
                                <asp:BoundField DataField="VisitTime" HeaderText="游玩日期" SortExpression="VisitTime" ReadOnly="true" />--%>
                                <asp:TemplateField ShowHeader="False">
　　                              <ItemTemplate>
　　                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="删除" OnClientClick="return confirm('确认要删除吗？');"></asp:LinkButton>
　　                              </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </tr>
                    <tr>
                        <asp:Button ID="btnExport" BackColor="#eaeaea" BorderWidth="2px" Font-Size="14px" Font-Bold="true" BorderColor="#000066" Text="导出到Excel" runat="server"  OnClick="btnExport_Click"/>
                    </tr>
                </table>
                
            </form>
        </div>
      </div>
    </div>

</asp:Content>