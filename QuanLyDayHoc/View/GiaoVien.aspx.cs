using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyDayHoc.View
{
    public partial class GiaoVien : System.Web.UI.Page
    {
        string strCon = "server = ACERNITRO5\\VANDUONG; database = QuanLyDayHoc; Trusted_Connection=true";
        protected void Page_Load(object sender, EventArgs e)
        {
            txbMaGV.Enabled = false;
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                string cmd = "select * from GiaoVien";
                using (SqlConnection sqlConnection = new SqlConnection(strCon))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(cmd, sqlConnection);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(sqlDataReader);
                    dgvGiaoVien.DataSource = dataTable;
                    dgvGiaoVien.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbHoTen.Text == "" || txbMaKhoa.Text == "")
                {
                    Response.Write("Vui lòng nhập đầy đủ thông tin");
                    return;
                }
                else
                {
                    string cmd = "INSERT INTO GiaoVien (HoTen, MaKhoa) VALUES(@HoTen, @MaKhoa)";
                    using (SqlConnection sqlConnection = new SqlConnection(strCon))
                    {
                        sqlConnection.Open();
                        SqlCommand sqlCommand = new SqlCommand(cmd, sqlConnection);
                        sqlCommand.Parameters.AddWithValue("@HoTen", txbHoTen.Text);
                        sqlCommand.Parameters.AddWithValue("@MaKhoa", txbMaKhoa.Text);
                        sqlCommand.ExecuteNonQuery();
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txbHoTen.Text == "" || txbMaKhoa.Text == "")
                {
                    Response.Write("Vui lòng nhập đầy đủ thông tin");
                    return;
                }
                else
                {
                    string cmd = "UPDATE dbo.GiaoVien SET HoTen = @HoTen, MaKhoa = @MaKhoa WHERE MaGV = @MaGV";
                    using (SqlConnection sqlConnection = new SqlConnection(strCon))
                    {
                        sqlConnection.Open();
                        SqlCommand sqlCommand = new SqlCommand(cmd, sqlConnection);
                        sqlCommand.Parameters.AddWithValue("@MaGV", txbMaGV.Text);
                        sqlCommand.Parameters.AddWithValue("@HoTen", txbHoTen.Text);
                        sqlCommand.Parameters.AddWithValue("@MaKhoa", txbMaKhoa.Text);
                        sqlCommand.ExecuteNonQuery();
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void dgvGiaoVien_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Edit")
                {
                    int row = int.Parse(e.CommandArgument.ToString());
                    txbMaGV.Text = dgvGiaoVien.Rows[row].Cells[0].Text;
                    txbHoTen.Text = dgvGiaoVien.Rows[row].Cells[1].Text;
                    txbMaKhoa.Text = dgvGiaoVien.Rows[row].Cells[2].Text;
                }
                else if (e.CommandName == "Delete")
                {
                    int row = int.Parse(e.CommandArgument.ToString());
                    string cmd = "DELETE FROM GiaoVien WHERE MaGV = @MaGV";
                    using (SqlConnection sqlConnection = new SqlConnection(strCon))
                    {
                        sqlConnection.Open();
                        SqlCommand sqlCommand = new SqlCommand(cmd, sqlConnection);
                        sqlCommand.Parameters.AddWithValue("@MaGV", dgvGiaoVien.Rows[row].Cells[0].Text);
                        sqlCommand.ExecuteNonQuery();
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void dgvGiaoVien_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dgvGiaoVien_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}