<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Khoa.aspx.cs" Inherits="QuanLyDayHoc.View.Khoa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Quan ly Khoa</h1>
        </div>
        <div>

            <asp:Label ID="Label1" runat="server" Text="Ma khoa"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txbMaKhoa" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Ten khoa"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txbTenKhoa" runat="server"></asp:TextBox>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Them" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Cap nhat" />
            <br />
            <asp:GridView ID="dgvKhoa" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvKhoa_RowCommand" OnRowDeleting="dgvKhoa_RowDeleting" OnRowEditing="dgvKhoa_RowEditing">
                <Columns>
                    <asp:BoundField DataField="MaKhoa" HeaderText="Ma khoa" />
                    <asp:BoundField DataField="TenKhoa" HeaderText="Ten khoa" />
                    <asp:CommandField ButtonType="Button" HeaderText="Edit" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
                    <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
