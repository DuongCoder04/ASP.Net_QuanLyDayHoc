<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonHoc.aspx.cs" Inherits="QuanLyDayHoc.View.MonHoc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Quan Ly Mon Hoc<br />
            <asp:Label ID="Label1" runat="server" Text="Ma mon hoc"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txbMaMH" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Ten mon hoc"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="txbTenMH" runat="server"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Them" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Cap nhat" />
            <br />
            <asp:GridView ID="dgvMonHoc" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing">
                <Columns>
                    <asp:BoundField DataField="MaMH" HeaderText="Ma mon hoc" />
                    <asp:BoundField DataField="TenMH" HeaderText="Ten mon hoc" />
                    <asp:CommandField ButtonType="Button" HeaderText="Edit" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
                    <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
