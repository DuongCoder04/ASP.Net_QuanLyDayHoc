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
    public partial class MonHoc : System.Web.UI.Page
    {
        string strCon = "server = ACERNITRO5\\VANDUONG; database=QuanLyDayHoc; Trusted_Connection=true";
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string sql = "select * from MonHoc";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMonHoc.DataSource = dt;
                dgvMonHoc.DataBind();
            }
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string sql = "Insert into MonHoc(TenMH) Values(@TenMH)";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaMH", txbMaMH.Text);
                cmd.Parameters.AddWithValue("@TenMH", txbTenMH.Text);
                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "Update MonHoc set TenMH = @TenMH where MaMH = @MaMH";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@MaMH", txbMaMH.Text);
                cmd.Parameters.AddWithValue("@TenMH", txbTenMH.Text);
                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Edit")
            {
                txbMaMH.Text = dgvMonHoc.Rows[row].Cells[0].Text;
                txbTenMH.Text = dgvMonHoc.Rows[row].Cells[1].Text;
            }
            else if (e.CommandName == "Delete")
            {
                string sql = "Delete from MonHoc where MaMH = @MaMH";
                using (SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@MaMH", dgvMonHoc.Rows[row].Cells[0].Text);
                    cmd.ExecuteNonQuery();
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