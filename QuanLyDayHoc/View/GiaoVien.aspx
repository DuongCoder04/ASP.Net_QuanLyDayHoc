<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GiaoVien.aspx.cs" Inherits="QuanLyDayHoc.View.GiaoVien" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>
                Quan Ly Giao Vien
            </h1>
        </div>
        <div>
            <asp:Label Text="Ma giao vien" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txbMaGV" runat="server" />
        </div>
        <div>
            <asp:Label Text="Ten giao vien" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txbHoTen" runat="server" />
        </div>
        <div>
            <asp:Label Text="Ma khoa" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txbMaKhoa" runat="server" />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button Text="Them" runat="server" ID="btnInsert" OnClick="btnInsert_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button Text="Cap nhat" runat="server" ID="btnUpdate" OnClick="btnUpdate_Click" />
        </div>
        <asp:GridView ID="dgvGiaoVien" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvGiaoVien_RowCommand" OnRowDeleting="dgvGiaoVien_RowDeleting" OnRowEditing="dgvGiaoVien_RowEditing">
            <Columns>
                <asp:BoundField DataField="MaGV" HeaderText="Ma giao vien" />
                <asp:BoundField DataField="HoTen" HeaderText="Ho ten" />
                <asp:BoundField DataField="MaKhoa" HeaderText="Ma khoa" />
                <asp:CommandField ButtonType="Button" HeaderText="Edit" ShowCancelButton="False" ShowEditButton="True" ShowHeader="True" />
                <asp:CommandField ButtonType="Button" HeaderText="Delete" ShowDeleteButton="True" ShowHeader="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
