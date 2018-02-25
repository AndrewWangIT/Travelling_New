<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HistoryList.aspx.cs" Inherits="Travelling.Web.Form.HistoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="content container_12">
        <div class="box grid_12">
        <div class="box-head"><h2>历史参团列表</h2></div>
        <div class="box-content no-pad">
            <form runat ="server">
                <asp:GridView id="gvVisitorList" Width="100%" runat="server" AutoGenerateColumns="false" BorderColor="#999999" Font-Bold="true" Font-Size="10px" BorderWidth="1px" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor ="#6699ff" 
                    HeaderStyle-Height="35px" CellPadding="3" HeaderStyle-Font-Size="16px" AllowPaging="true" PageSize="15" OnPageIndexChanging="gvVisitorList_PageIndexChanging"
                    DataKeyNames="id">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:BoundField DataField="VisitorName" HeaderText="游客姓名" SortExpression="VisitorName" ReadOnly="true" />
                        <asp:BoundField DataField="Phone" HeaderText="联系电话" SortExpression="Phone" ReadOnly="true" />
                        <asp:BoundField DataField="LineName" HeaderText="线路名称" SortExpression="LineName" ReadOnly="true" />
                        <asp:BoundField DataField="AdultNum" HeaderText="成人人数" SortExpression="AdultNum" ReadOnly="true" />
                        <asp:BoundField DataField="AdultPrice" HeaderText="成人价格" SortExpression="AdultPrice" ReadOnly="true" />
                        <asp:BoundField DataField="ChildNum" HeaderText="儿童人数" SortExpression="ChildNum" ReadOnly="true" />
                        <asp:BoundField DataField="ChildPrice" HeaderText="儿童价格" SortExpression="ChildPrice" ReadOnly="true" />
                        <asp:BoundField DataField="IsSH" HeaderText="上海人" ReadOnly="true" />
                        <asp:BoundField DataField="IsBM" HeaderText="包门" ReadOnly="true" />
                        <asp:BoundField DataField="IsBSLYK" HeaderText="补收旅游款" ReadOnly="true" />
                        <asp:BoundField DataField="OtherCost" HeaderText="补收旅游金额" ReadOnly="true" />
                        <asp:BoundField DataField="Address" HeaderText="联系地址" ReadOnly="true" />
                        <asp:BoundField DataField="Notes" HeaderText="备注" ReadOnly="true" />
                        <%--<asp:BoundField DataField="ReturnCost" HeaderText="返利" ReadOnly="true" />--%>
                        <asp:BoundField DataField="FisVenderName" HeaderText="收客人" ReadOnly="true" />
                        <asp:BoundField DataField="VisitorStatus" HeaderText="客人状态" ReadOnly="true" />
                       <%-- <asp:TemplateField ShowHeader="False">
　　                      <ItemTemplate>
　　                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="删除" OnClientClick="return confirm('确认要删除吗？');"></asp:LinkButton>
　　                      </ItemTemplate>
                        </asp:TemplateField>--%>
                       <%-- <asp:BoundField DataField="BillStatus" HeaderText="结账状态" ReadOnly="true" />
                        <asp:BoundField DataField="VisitTime" HeaderText="游玩日期" SortExpression="VisitTime" ReadOnly="true" />--%>
                    </Columns>
                </asp:GridView>
            </form>
        </div>
      </div>
    </div>

</asp:Content>
