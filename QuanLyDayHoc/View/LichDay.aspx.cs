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
    public partial class LichDay : System.Web.UI.Page
    {
        string strCon = "server = ACERNITRO5\\VANDUONG; database=QuanLyDayHoc; Trusted_Connection=true";
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string sql = "select * from LichDay";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLichDay.DataSource = dt;
                dgvLichDay.DataBind();
            }
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string cmd = "INSERT INTO LichDay (MaGV, MaMH, Phong, MaLop, NgayDay, TuTiet, DenTiet, BaiDay, LyThuyet, GhiChu) VALUES(@MaGV, @MaMH, @Phong, @MaLop, @NgayDay, @TuTiet, @DenTiet, @BaiDay, @LyThuyet, @GhiChu)";
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                SqlCommand command = new SqlCommand(cmd, con);
                command.Parameters.AddWithValue("@MaGV", txbMaGV.Text);
                command.Parameters.AddWithValue("@MaMH", txbMaMH.Text);
                command.Parameters.AddWithValue("@Phong", txbPhong.Text);
                command.Parameters.AddWithValue("@MaLop", txbMaLop.Text);
                command.Parameters.Add("@NgayDay", SqlDbType.Date).Value = txbNgayDay.Text;
                command.Parameters.AddWithValue("@TuTiet", txbTuTiet.Text);
                command.Parameters.AddWithValue("@DenTiet", txbDenTiet.Text);
                command.Parameters.AddWithValue("@BaiDay", txbBaiDay.Text);
                command.Parameters.Add("@LyThuyet", SqlDbType.Bit).Value = int.Parse(txbLyThuyet.Text);
                command.Parameters.AddWithValue("@GhiChu", txbGhiChu.Text);
                command.ExecuteNonQuery();
                LoadData();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string cmd = "UPDATE dbo.LichDay SET TuTiet = @TuTiet,DenTiet = @DenTiet, BaiDay = @BaiDay, LyThuyet = @LyThuyet, GhiChu = @GhiChu WHERE MaGV = @MaGV AND MaMH = @MaMH AND Phong = @Phong AND MaLop = @MaLop AND NgayDay = @NgayDay";
            using (SqlConnection sqlConnection = new SqlConnection(strCon))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(cmd, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@MaGV", txbMaGV.Text);
                sqlCommand.Parameters.AddWithValue("@MaMH", txbMaMH.Text);
                sqlCommand.Parameters.AddWithValue("@Phong", txbPhong.Text);
                sqlCommand.Parameters.AddWithValue("@MaLop", txbMaLop.Text);
                sqlCommand.Parameters.Add("@NgayDay", SqlDbType.Date).Value = txbNgayDay.Text;
                sqlCommand.Parameters.AddWithValue("@TuTiet", txbTuTiet.Text);
                sqlCommand.Parameters.AddWithValue("@DenTiet", txbDenTiet.Text);
                sqlCommand.Parameters.AddWithValue("@BaiDay", txbBaiDay.Text);
                sqlCommand.Parameters.Add("@LyThuyet", SqlDbType.Bit).Value = txbLyThuyet.Text;
                sqlCommand.Parameters.AddWithValue("@GhiChu", txbGhiChu.Text);
                sqlCommand.ExecuteNonQuery();
                LoadData();
            }
        }

        protected void dgvLichDay_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int row = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Edit")
            {
                txbMaGV.Text = dgvLichDay.Rows[row].Cells[0].Text;
                txbMaMH.Text = dgvLichDay.Rows[row].Cells[1].Text;
                txbPhong.Text = dgvLichDay.Rows[row].Cells[2].Text;
                txbMaLop.Text = dgvLichDay.Rows[row].Cells[3].Text;
                txbNgayDay.Text = dgvLichDay.Rows[row].Cells[4].Text;
                txbTuTiet.Text = dgvLichDay.Rows[row].Cells[5].Text;
                txbDenTiet.Text = dgvLichDay.Rows[row].Cells[6].Text;
                txbBaiDay.Text = dgvLichDay.Rows[row].Cells[7].Text;
                txbLyThuyet.Text = dgvLichDay.Rows[row].Cells[8].Text;
                txbGhiChu.Text = dgvLichDay.Rows[row].Cells[9].Text;
            }
            else if (e.CommandName == "Delete")
            {
                string cmd = "DELETE FROM LichDay WHERE MaGV = @MaGV AND MaMH = @MaMH AND Phong = @Phong AND MaLop = @MaLop AND NgayDay = @NgayDay";
                using(SqlConnection con = new SqlConnection(strCon))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand(cmd, con);
                    command.Parameters.AddWithValue("@MaGV", dgvLichDay.Rows[row].Cells[0].Text);
                    command.Parameters.AddWithValue("@MaMH", dgvLichDay.Rows[row].Cells[1].Text);
                    command.Parameters.AddWithValue("@Phong", dgvLichDay.Rows[row].Cells[2].Text);
                    command.Parameters.AddWithValue("@MaLop", dgvLichDay.Rows[row].Cells[3].Text);
                    command.Parameters.Add("@NgayDay", SqlDbType.Date).Value = dgvLichDay.Rows[row].Cells[4].Text;
                    command.ExecuteNonQuery();
                    LoadData();
                }
            }
        }

        protected void dgvLichDay_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dgvLichDay_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}