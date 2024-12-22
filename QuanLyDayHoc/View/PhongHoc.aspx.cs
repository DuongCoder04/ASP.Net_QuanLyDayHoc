using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace QuanLyDayHoc.View
{
    public partial class PhongHoc : System.Web.UI.Page
    {
        string strCon = "server = ACERNITRO5\\VANDUONG; database=QuanLyDayHoc; Trusted_Connection=true";
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string cmd = "Select * from PhongHoc";
            using (SqlConnection sqlConnection = new SqlConnection(strCon))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(cmd, sqlConnection);
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dgvPhongHoc.DataSource=dataTable;
                dgvPhongHoc.DataBind();
            }
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string cmd = "Insert Into PhongHoc(Phong, ChucNang) Values(@Phong, @ChucNang)";
            using (SqlConnection sqlConnection = new SqlConnection(strCon))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(cmd, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Phong", txbPhong.Text);
                sqlCommand.Parameters.AddWithValue("@ChucNang", txbChucNang.Text);
                sqlCommand.ExecuteNonQuery();
                LoadData();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string cmd = "UPDATE dbo.PhongHoc SET ChucNang = @ChucNang WHERE Phong = @Phong";
            using (SqlConnection sqlConnection = new SqlConnection(strCon))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(cmd, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Phong", txbPhong.Text);
                sqlCommand.Parameters.AddWithValue("@ChucNang", txbChucNang.Text);
                sqlCommand.ExecuteNonQuery();
                LoadData();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Edit")
            {
                txbPhong.Text = dgvPhongHoc.Rows[row].Cells[0].Text;
                txbChucNang.Text = dgvPhongHoc.Rows[row].Cells[1].Text;
            }
            if (e.CommandName == "Delete")
            {
                string cmd = "DELETE dbo.PhongHoc WHERE Phong = @Phong";
                using (SqlConnection sqlConnection = new SqlConnection(strCon))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(cmd,sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@Phong", dgvPhongHoc.Rows[row].Cells[0].Text);
                    sqlCommand.ExecuteNonQuery();
                    LoadData();
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}