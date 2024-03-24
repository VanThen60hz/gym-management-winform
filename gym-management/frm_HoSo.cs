using System;
using System.Globalization;
using System.Windows.Forms;

namespace gym_management
{
    public partial class frm_HoSo : Form
    {

        public frm_HoSo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            String sql = $"DELETE KHACHHANG WHERE MSKH = '{txt_MaKhachHang.Text}'";
            if (LOPDUNGCHUNG.CUD(sql) >= 1)
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Xóa không thành công.");
            }
            LoadTable();
        }

        private void dgv_HoSo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm_HoSo_Load(object sender, EventArgs e)
        {
            LoadTable();
            LoadGiaoVien();
        }

        public void LoadTable()
        {
            dgv_HoSo.DataSource = LOPDUNGCHUNG.GetDataToTable("SELECT * FROM KHACHHANG");
        }

        public void LoadGiaoVien()
        {
            cbo_TenGiaoVien.DataSource = LOPDUNGCHUNG.GetDataToTable("SELECT * FROM GIAOVIEN");
            cbo_TenGiaoVien.ValueMember = "MSGVHD";
            cbo_TenGiaoVien.DisplayMember = "TENGVHD";
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            String sql = $"INSERT INTO KHACHHANG VALUES ('{txt_MaKhachHang.Text}', N'{txt_HoTen.Text}', N'{txt_DiaChi.Text}', N'{dtp_NgaySinh.Value.ToString("dd/MM/yyyy")}', '{cbo_TenGiaoVien.SelectedValue}' )";
            if (LOPDUNGCHUNG.CUD(sql) >= 1)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm không thành công.");
            }
            LoadTable();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            String sql = $"UPDATE KHACHHANG SET HOTEN = N'{txt_HoTen.Text}', DIACHI = N'{txt_DiaChi.Text}', NGAYSINH = N'{dtp_NgaySinh.Value.ToString("dd/MM/yyyy")}', MSGVHD = '{cbo_TenGiaoVien.SelectedValue}' WHERE MSKH ='{txt_MaKhachHang.Text}'";
            if (LOPDUNGCHUNG.CUD(sql) >= 1)
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa không thành công.");
            }
            LoadTable();
        }

        private void dgv_HoSo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbo_TenGiaoVien.SelectedValue = dgv_HoSo.CurrentRow.Cells["MSGVHD"].Value.ToString();
            txt_MaKhachHang.Text = dgv_HoSo.CurrentRow.Cells["MSKH"].Value.ToString();
            txt_HoTen.Text = dgv_HoSo.CurrentRow.Cells["HOTEN"].Value.ToString();
            txt_DiaChi.Text = dgv_HoSo.CurrentRow.Cells["DIACHI"].Value.ToString();
            string dateString = dgv_HoSo.CurrentRow.Cells["NGAYSINH"].Value.ToString();
            DateTime ngaySinh = DateTime.TryParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate) ? parsedDate : DateTime.Now;
            dtp_NgaySinh.Value = ngaySinh;


        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }

}