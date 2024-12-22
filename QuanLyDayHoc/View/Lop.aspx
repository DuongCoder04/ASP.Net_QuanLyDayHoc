<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lop.aspx.cs" Inherits="QuanLyDayHoc.View.Lop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Quan Ly Lop<br />
            <asp:Label ID="Label1" runat="server" Text="Ma lop"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txbMaLop" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Ten lop"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txbTenLop" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Ma khoa"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txbMaKhoa" runat="server"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Them" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Cap nhat" />
            <br />
            <asp:GridView ID="dgvLop" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvLop_RowCommand" OnRowDeleting="dgvLop_RowDeleting" OnRowEditing="dgvLop_RowEditing">
                <Columns>
                    <asp:BoundField DataField="MaLop" HeaderText="Ma lop" />
                    <asp:BoundField DataField="TenLop" HeaderText="Ten lop" />
                    <asp:BoundField DataField="MaKhoa" HeaderText="Ma khoa" />
                    <asp:CommandField ButtonType="Button" HeaderText="Edit" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
                    <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
