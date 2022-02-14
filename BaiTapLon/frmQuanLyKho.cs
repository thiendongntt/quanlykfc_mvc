using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLon
{
    public partial class frmQuanLyKho : Form
    {
        public frmQuanLyKho()
        {
            InitializeComponent();
            userKhoControl.BringToFront();
        }

        private void btnXuatKho_Click(object sender, EventArgs e)
        {

            btnKho.BackColor = Color.FromArgb(255, 128, 128);
            btnKho.ForeColor = Color.White;

            btnXuatNhapKho.BackColor = Color.White;
            btnXuatNhapKho.ForeColor = Color.Black;

            userXuatNhapKhoControl.BringToFront();
        }

        private void btnKho_Click(object sender, EventArgs e)
        {
           
            btnKho.BackColor = Color.White;
            btnKho.ForeColor = Color.Black;

            btnXuatNhapKho.BackColor = Color.FromArgb(255, 128, 128); ;
            btnXuatNhapKho.ForeColor = Color.White;

            userKhoControl.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
