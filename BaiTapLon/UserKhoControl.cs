using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;

namespace BaiTapLon
{
    public partial class UserKhoControl : UserControl
    {
        public UserKhoControl()
        {
            InitializeComponent();
            dgvNguyenLieu.DataSource = NguyenLieuBUS.Instance.getAllNguyenLieu();
        }

        
    }
}
