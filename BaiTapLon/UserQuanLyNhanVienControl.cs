using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BUS;
using DTO;

namespace BaiTapLon
{
    public partial class UserQuanLyNhanVienControl : UserControl
    {

        public UserQuanLyNhanVienControl()
        {
            InitializeComponent();
            dgvNhanVien.DataSource = NhanVienBUS.Instance.getNhanVien();
            txtHodem.Focus();
            cbxGioitinh.SelectedIndex = 0;
        }

        public bool checkData()
        {
            if (txtHodem.Text.Equals(""))
            {
                MessageBox.Show("Ho dem khong duoc de trong ", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHodem.Focus();
                return false;
            }
            else if (txtTen.Text.Equals(""))
            {
                MessageBox.Show("Ten khong duoc de trong ", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Focus();
                return false;
            }
            else if (date_Birthday.Text == " /  /")
            {
                MessageBox.Show("Bạn phải nhập ngày sinh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                date_Birthday.Focus();
                return false;
            }
            else if (txtQuequan.Text.Equals(""))
            {
                MessageBox.Show("Que quan dia chi khong duoc de trong ", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuequan.Focus();
                return false;
            }
            else if (txtSDT.Text.Equals(""))
            {
                MessageBox.Show("So dien thoai khong duoc de trong ", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
                return false;
            }
            /*else if (txtChucvu.Text.Equals(""))
            {
                MessageBox.Show("Chuc vu khong duoc de trong ", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtChucvu.Focus();
                return false;
            }*/
            if (txtEmail.Text.Equals("^[a-z][a-z0-9_\\.]{5,23}@[a-z0-9]{2,}(\\.[a-z0-9]{2,4}){1,2}$") == true)
            {
                MessageBox.Show("Email khong chuan dinh dang", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }
            return true;
        }

        private void btChonAnh_Click(object sender, EventArgs e)
        {
            string test, res = "\\Resources\\";
            OpenFileDialog OFL = new OpenFileDialog();
            OFL.Title = " Vui lòng chọn ảnh ^_^ ";
            OFL.Filter = " JPG|*.jpg|PNG|*.png|GIF|*gif";
            OFL.Multiselect = false;
            if (OFL.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(OFL.FileName);
                int index = -1;
                test = OFL.FileName;
                for (int i = test.Length - 1; i >= 0; i--)
                {
                    if (test[i] == '\\')
                    {
                        index = i;
                        break;
                    }
                }
                string[] files = Directory.GetFiles(Application.StartupPath + res);

                foreach (string file in files)
                    if (test.Substring(index + 1) == Path.GetFileName(file))
                    {
                        MessageBox.Show("trung ten hinh roi");
                        return;
                    }
                System.IO.File.Copy(OFL.FileName, Application.StartupPath + res + test.Substring(index + 1));
                txtHinh.Text = res + test.Substring(index + 1);
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                /*NhanVienDTO nv = new NhanVienDTO(0, txtHodem.Text, txtTen.Text, txtHinh.Text, date_Birthday.Value.Date, cbxGioitinh.SelectedItem.ToString(), txtQuequan.Text, txtSDT.Text, txtEmail.Text, txtChucvu.Text);
                if (NhanVienBUS.Instance.themNhanVien(nv))
                {
                    int maNV = NhanVienBUS.Instance.getMaNhanVien(txtHodem.Text, txtTen.Text, txtHinh.Text, date_Birthday.Value.Date, cbxGioitinh.SelectedItem.ToString(), txtQuequan.Text, txtSDT.Text, txtEmail.Text, txtChucvu.Text);
                    MucLuongNhanVienDTO ml = new MucLuongNhanVienDTO(maNV, 1, 1);
                    LuongNhanVienBUS.Instance.themLuongNhanVien(ml);
                    dgvNhanVien.DataSource = NhanVienBUS.Instance.getNhanVien();
                    MessageBox.Show("Them thanh cong");
                }
                else
                {
                    MessageBox.Show("them khong thanh cong");
                }*/
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                int n = dgvNhanVien.CurrentRow.Index;
                int maNV = Int32.Parse(dgvNhanVien.Rows[n].Cells[0].Value.ToString());
                /*NhanVienDTO nv = new NhanVienDTO(maNV, txtHodem.Text, txtTen.Text, txtHinh.Text, date_Birthday.Value, cbxGioitinh.SelectedItem.ToString(), txtQuequan.Text, txtSDT.Text, txtEmail.Text, txtChucvu.Text);
                if (NhanVienBUS.Instance.suaNhanVien(nv))
                {
                    dgvNhanVien.DataSource = NhanVienBUS.Instance.getNhanVien();
                    MessageBox.Show("Sua thanh cong");
                }
                else
                {
                    MessageBox.Show("Sua khong thanh cong");
                }*/

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xoá nhân viên này ko ", "WARNING!!!!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int n = dgvNhanVien.CurrentRow.Index;
                    int maNV = Int32.Parse(dgvNhanVien.Rows[n].Cells[0].Value.ToString());
                    if (NhanVienBUS.Instance.xoaNhanVien(maNV))
                    {
                        dgvNhanVien.DataSource = NhanVienBUS.Instance.getNhanVien();
                        MessageBox.Show("xoá thành công nhé anh trai ");
                    }
                    else
                    {
                        MessageBox.Show("Xoá không được nhá anh trai");
                    }
                }
            }
        }
        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            btnXoa.Show();
            btnChinhSua.Show();
            btnChinhSua.Hide();
            int n = dgvNhanVien.CurrentRow.Index;
            int maNV = Int32.Parse(dgvNhanVien.Rows[n].Cells[0].Value.ToString());

            txtHodem.Text = dgvNhanVien.Rows[n].Cells[1].Value.ToString();
            txtTen.Text = dgvNhanVien.Rows[n].Cells[2].Value.ToString();

            if (dgvNhanVien.Rows[n].Cells[3].Value.ToString().Equals(""))
            {
                pictureBox1.Image = null;
            }
            else
            {
                pictureBox1.Image = new Bitmap(Application.StartupPath + (dgvNhanVien.Rows[n].Cells[3].Value.ToString()));
            }
            date_Birthday.Text = dgvNhanVien.Rows[n].Cells[4].Value.ToString();
            cbxGioitinh.Text = dgvNhanVien.Rows[n].Cells[5].Value.ToString();
            txtQuequan.Text = dgvNhanVien.Rows[n].Cells[6].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[n].Cells[7].Value.ToString();
            txtEmail.Text = dgvNhanVien.Rows[n].Cells[8].Value.ToString();
            //txtChucvu.Text = dgvNhanVien.Rows[n].Cells[9].Value.ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string ten = txtTimKiem.Text;
            if (!string.IsNullOrEmpty(ten)) // kiem tra neu khong tim kiem khong rong
            {
                dgvNhanVien.DataSource = NhanVienBUS.Instance.timKiemNhanVien(ten);
            }
            else
            {
                dgvNhanVien.DataSource = NhanVienBUS.Instance.getNhanVien();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                dgvNhanVien.DataSource = NhanVienBUS.Instance.getNhanVien();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtHodem.Text = "";
            txtTen.Text = "";
            txtHinh.Text = ""; txtHinh.ForeColor = Color.White;
            date_Birthday.Text = "";
            cbxGioitinh.Text = "";
            txtQuequan.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            //txtChucvu.Text = "";
            dgvNhanVien.DataSource = NhanVienBUS.Instance.getNhanVien();
            btnXacNhan.Enabled = true;
            btnXoa.Hide();
            btnChinhSua.Hide();
            btnXacNhan.Show();
        }
    }
}