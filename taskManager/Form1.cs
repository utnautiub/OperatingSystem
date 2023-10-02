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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Process[] proc;

        void GetAllProcess()
        {
            proc = Process.GetProcesses();// Gọi biến process trong thư viện getprocess
            listBox.Items.Clear();//Khi gọi lần 2 thì add thêm và nếu không clear thì xảy ra hiện tượng trùng lặp
            foreach(Process p in proc)// Truy cập trực tiếp phần tử
            {
                listBox.Items.Add(p.ProcessName);// Lấy tên tiến trình
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllProcess();
            timer.Start();//Cho thời gian chạy thực và lặp đi lặp lại
        }

        private void btnEndTask_Click(object sender, EventArgs e)
        {
            try
            {
                proc[listBox.SelectedIndex].Kill();//Ngắt tiến trình
                GetAllProcess();//Gọi hàm load lại tiến trình còn đang chạy trên tiến trình
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);//Hiển thị hộp thoại
            }
        }

        private void runNewTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRunTask frm = new frmRunTask())//Gọi form chạy tiến trình mới
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    GetAllProcess();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            float fcpu = pCPU.NextValue();//Tạo biến cpu, cập nhật giá trị tiếp theo cho biểu đổ progressbar
            float fram = pRAM.NextValue();//Tương tự như cpu
            metroProgressBarCPU.Value = (int)fcpu;//Convert sang kiểu int -> Đưa vào thanh progressbar
            metroProgressBarRAM.Value = (int)fram;
            lblCPU.Text = string.Format("{0:0.00}%", fcpu);
            lblRAM.Text = string.Format("{0:0.00}%", fram);//Hiển thị dưới dạng số và cập nhật trên label
            chart1.Series["CPU"].Points.AddY(fcpu);//Giá trị biểu đồ
            chart1.Series["RAM"].Points.AddY(fram);
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblCPU_Click(object sender, EventArgs e)
        {

        }

        private void metroProgressBarCPU_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
