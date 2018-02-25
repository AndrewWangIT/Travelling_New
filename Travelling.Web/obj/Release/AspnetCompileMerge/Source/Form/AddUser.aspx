<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Travelling.Web.Form.AddUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form" runat="server">
        <div style="text-align:center">
            <asp:Panel ID="panAddUser" BorderWidth="1px" BorderColor="#66ff99" GroupingText="添加用户" runat="server" Font-Bold="True" ForeColor="#006600">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblUserName" Font-Bold="true" Font-Size="16px" Width="80px" Text="用户名:" runat="server"></asp:Label>
                            <asp:TextBox ID="txtUserName" Width="300px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblPassword" Font-Bold="true" Font-Size="16px" Widt="80px" Text="初始密码" runat="server"></asp:Label>
                            <asp:TextBox ID="txtPassword" Width="300px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnAddUser" Width="100px" runat="server" Text="添加用户" Font-Bold="true" Font-Size="16px" 
                                OnClientClick="return CheckUserNamePassword()" OnClick="btnAddUser_Click" /> 
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="panDeleteUser" BorderWidth="1px" BorderColor="#66ff99" GroupingText="删除用户" runat="server" Font-Bold="True" ForeColor="#006600">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblUserNameDel" Font-Bold="true" Font-Size="16px" Width="80px" Text="用户名:" runat="server"></asp:Label>
                            <asp:TextBox ID="txtUserNameDel" Width="300px" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnDeleteUser" Width="100px" runat="server" Text="删除用户" Font-Bold="true" Font-Size="16px" 
                                OnClientClick="return CheckUserName()" OnClick="btnDeleteUser_Click" /> 
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
    <script type="text/javascript">
        function CheckUserNamePassword()
        {
            var password = $("#MainContent_txtPassword").val();
            var userName = $("#MainContent_txtUserName").val();
            if(password == '' || userName=='')
            {
                alert('用户名和初始密码不能为空！');
                return false;
            }
            else
            {
                return true;
            }
        }
        function CheckUserName()
        {
            var userName = $("#MainContent_txtUserNameDel").val();
            if (userName == '') {
                alert('请输入要删除的用户名！');
                return false;
            }
            else {
                if(confirm("确定要删除这个用户吗？"))
                {
                    return true
                }
                else
                {
                    return false;
                }
                
            }
        }
    </script>

</asp:Content>
