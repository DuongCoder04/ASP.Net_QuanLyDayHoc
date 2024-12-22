<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhongHoc.aspx.cs" Inherits="QuanLyDayHoc.View.PhongHoc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Quan ly Phong Hoc</h1>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Phong"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txbPhong" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Chuc nang"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txbChucNang" runat="server"></asp:TextBox>
            </p>
            <p style="margin-left: 80px">
                <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Them" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Cap nhat" />
            </p>
        </div>
        <asp:GridView ID="dgvPhongHoc" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing">
            <Columns>
                <asp:BoundField DataField="Phong" HeaderText="Phong" />
                <asp:BoundField DataField="ChucNang" HeaderText="Chuc nang" />
                <asp:CommandField ButtonType="Button" HeaderText="Edit" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
                <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
