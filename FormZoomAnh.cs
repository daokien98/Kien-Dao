using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace demo_xử_lý_ảnh
{
    public partial class FormZoomAnh : DevComponents.DotNetBar.RibbonForm
    {
        Bitmap bmp;
        FormBatDau f = new FormBatDau();
        public FormZoomAnh()
        {
            InitializeComponent();
        }

        private void bti_moanh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Mở Ảnh";
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmp = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = bmp;
            }
        }

        private void FormZoomAnh_Load(object sender, EventArgs e)
        {

            this.BackColor = Color.PowderBlue;
            MessageBox.Show("Mời bạn zoom ảnh!", "Zoom Ảnh", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //FormBatDau f = new FormBatDau();
            //pictureBox1.Image = bmp;
            trackBar1.Minimum = 50;
            trackBar1.Maximum = 500;
            pictureBox1.Left = (ClientSize.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = (ClientSize.Height - pictureBox1.Height) / 2;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(trackBar1.Value, pictureBox1.Size.Height);
            pictureBox1.Left = (ClientSize.Width - pictureBox1.Width) / 2;
            pictureBox1.Top = (ClientSize.Height - pictureBox1.Height) / 2;

        }

        private void FormZoomAnh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pictureBox1.Image != null)
                pictureBox1.Dispose(); // loại bỏ nếu ko có ảnh
        }

        private void bti_thoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn thực sự muốn thoát sao?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (dr == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void bti_quaylai_Click(object sender, EventArgs e)
        {
            FormBatDau f = new FormBatDau();
            f.Show();
            this.Hide();
        }
    }
}