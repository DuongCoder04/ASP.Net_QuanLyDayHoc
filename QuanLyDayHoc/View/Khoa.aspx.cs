using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace QuanLyDayHoc.View
{
    public partial class Khoa : System.Web.UI.Page
    {
        string strCon = "server = ACERNITRO5\\VANDUONG; database=QuanLyDayHoc; Trusted_Connection=true";
        protected void Page_Load(object sender, EventArgs e)
        {
            txbMaKhoa.Enabled = false;
            LoadData();
        }
        private void LoadData()
        {
            string sql = "select * from Khoa";
            using(SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvKhoa.DataSource = dt;
                dgvKhoa.DataBind();
            }
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string sql = "Insert into Khoa(TenKhoa) Values(@TenKhoa)";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaKhoa", txbMaKhoa.Text);
                cmd.Parameters.AddWithValue("@TenKhoa", txbTenKhoa.Text);
                cmd.ExecuteNonQuery();
            }
            LoadData();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "Update Khoa set TenKhoa = @TenKhoa where MaKhoa = @MaKhoa";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaKhoa", txbMaKhoa.Text);
                cmd.Parameters.AddWithValue("@TenKhoa", txbTenKhoa.Text);
                cmd.ExecuteNonQuery();
            }
            LoadData();
        }

        protected void dgvKhoa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Edit")
            {
                txbMaKhoa.Text = dgvKhoa.Rows[row].Cells[0].Text;
                txbTenKhoa.Text = dgvKhoa.Rows[row].Cells[1].Text;
            }
            else if (e.CommandName == "Delete")
            {
                string sql = "Delete from Khoa where MaKhoa = @MaKhoa";
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@MaKhoa", dgvKhoa.Rows[row].Cells[0].Text);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
            }
        }

        protected void dgvKhoa_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dgvKhoa_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}