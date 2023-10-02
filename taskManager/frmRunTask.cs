using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taskManager
{
    public partial class frmRunTask : Form
    {
        public frmRunTask()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtOpen.Text))
            {
                try
                {
                    Process proc = new Process();//Tạo biến tiến trình
                    proc.StartInfo.FileName = txtOpen.Text;//LẤy tên ứng với textbox nhập từ bàn phím
                    proc.Start();//Nhập đúng thì chạy còn không đúng thì chạy về catch
                } 
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);//HIển thị hộp thoại
                }
            }
        }

        private void txtOpen_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
