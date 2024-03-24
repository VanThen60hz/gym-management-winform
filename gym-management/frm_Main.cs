using System;
using System.Windows.Forms;

namespace gym_management
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_HoSo hs = new frm_HoSo();
            hs.Show();
            hs.MdiParent = this;
        }
    }
}
