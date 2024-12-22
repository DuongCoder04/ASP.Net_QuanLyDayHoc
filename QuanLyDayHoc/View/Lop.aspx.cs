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
    public partial class Lop : System.Web.UI.Page
    {
        string strCon = "server = ACERNITRO5\\VANDUONG; database=QuanLyDayHoc; Trusted_Connection=true";
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string sql = "select * from Lop";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLop.DataSource = dt;
                dgvLop.DataBind();
            }
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string sql = "Insert into Lop(TenLop, MaKhoa) Values(@TenLop, @MaKhoa)";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaLop", txbMaLop.Text);
                cmd.Parameters.AddWithValue("@TenLop", txbTenLop.Text);
                cmd.Parameters.AddWithValue("@MaKhoa", txbMaKhoa.Text);
                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "Update Lop set TenLop = @TenLop, MaKhoa = @MaKhoa where MaLop = @MaLop";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaLop", txbMaLop.Text);
                cmd.Parameters.AddWithValue("@TenLop", txbTenLop.Text);
                cmd.Parameters.AddWithValue("@MaKhoa", txbMaKhoa.Text);
                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        protected void dgvLop_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Edit")
            {
                txbMaLop.Text = dgvLop.Rows[row].Cells[0].Text;
                txbTenLop.Text = dgvLop.Rows[row].Cells[1].Text;
                txbMaKhoa.Text = dgvLop.Rows[row].Cells[2].Text;
            }
            else if (e.CommandName == "Delete")
            {
                string sql = "Delete from Lop where MaLop = @MaLop";
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@MaLop", dgvLop.Rows[row].Cells[0].Text);
                    cmd.ExecuteNonQuery();
                    LoadData();
                }
            }
        }

        protected void dgvLop_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dgvLop_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}