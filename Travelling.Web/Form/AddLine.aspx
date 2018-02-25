<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddLine.aspx.cs" Inherits="Travelling.Web.Form.AddLine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="AddLineForm" runat="server">
        <div style="text-align:center">
            <asp:Panel ID="panAddUser" BorderWidth="1px" BorderColor="#66ff99" GroupingText="添加新线路" runat="server" Font-Bold="True" ForeColor="#006600">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblStartCity" Font-Bold="true" Font-Size="16px" Width="80px" Text="出发城市:" runat="server"></asp:Label>
                            <asp:TextBox ID="txtStartCity" Width="300px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblLineName" Font-Bold="true" Font-Size="16px" Widt="80px" Text="线路名称：" runat="server"></asp:Label>
                            <asp:TextBox ID="txtLineName" Width="300px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblDays" Font-Bold="true" Font-Size="16px" Width="80px" Text="游玩天数:" runat="server"></asp:Label>
                            <asp:TextBox ID="txtDays" Width="300px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblLowPrice" Font-Bold="true" Font-Size="16px" Width="80px" Text="外地人结算价:" runat="server"></asp:Label>
                            <asp:TextBox ID="txtLowPrice" Width="300px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblPriceSH" Font-Bold="true" Font-Size="16px" Width="80px" Text="上海人结算价:" runat="server"></asp:Label>
                            <asp:TextBox ID="txtPriceSH" Width="300px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblPriceChild" Font-Bold="true" Font-Size="16px" Width="80px" Text="儿童结算价:" runat="server"></asp:Label>
                            <asp:TextBox ID="txtPriceChild" Width="300px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblNotes" Font-Bold="true" Font-Size="16px" Width="80px" Text="备注:" runat="server"></asp:Label>
                            <asp:TextBox ID="txtNotes" Width="701px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:right;">
                            <asp:Button ID="btnAddUser" Width="100px" runat="server" Text="添加用户" BackColor="#eaeaea" 
                                BorderWidth="2px" Font-Size="14px" Font-Bold="true" BorderColor="#000066" 
                                OnClientClick="return CheckLineInfo()" OnClick="btnAddLine_Click" /> 
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>

    <script type="text/javascript">
        function CheckLineInfo()
        {
            var startCity = $("#MainContent_txtStartCity").val();
            var lineName = $("#MainContent_txtLineName").val();
            var days = $("#MainContent_txtDays").val();
            var lowPrice = $("#MainContent_txtLowPrice").val();

            if (startCity == '' || lineName == '' || days == '' || lowPrice == '')
            {
                alert('出发城市,线路名称,游玩天数,外地人结算价不能为空！');
                return false;
            }
            else
            {
                return true;
            }
        }
    </script>
</asp:Content>
