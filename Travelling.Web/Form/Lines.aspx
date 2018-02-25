<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lines.aspx.cs" Inherits="Travelling.Web.Form.Lines" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="content container_12">
        <div class="box grid_12">
        <div class="box-head"><h2>线路底价最新信息列表</h2></div>
        <div class="box-content no-pad">
            <form runat ="server">
                <asp:GridView id="gvLine" Width="100%" runat="server" AutoGenerateColumns="false" BorderColor="#999999" Font-Bold="true" Font-Size="16px" BorderWidth="1px" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor ="#6699ff" 
                    HeaderStyle-Height="35px" CellPadding="3" HeaderStyle-Font-Size="26px" AllowPaging="true" PageSize="15" OnPageIndexChanging="gvLine_PageIndexChanging">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:BoundField DataField="LineID" HeaderText="线路编号" ReadOnly="true" />
                        <asp:BoundField DataField="StartCity" HeaderText="出发城市" ReadOnly="true" />
                        <asp:BoundField DataField="LineName" HeaderText="线路名称" ReadOnly="true" />
                        <asp:BoundField DataField="LowPrice" HeaderText="外地人底价" ReadOnly="true"/>
                        <asp:BoundField DataField="LowPriceSH" HeaderText="上海人底价" ReadOnly="true"/>
                        <asp:BoundField DataField="LowPriceChild" HeaderText="儿童底价" ReadOnly="true"/>
                        <asp:BoundField DataField="Notes" HeaderText="备注" />
                    </Columns>
                </asp:GridView>
            </form>
        </div>
      </div>
    </div>



</asp:Content>
