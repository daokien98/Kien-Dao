using System;
using System.Windows.Forms;
using System.Media;



namespace demo_xử_lý_ảnh
{
    public partial class LoadAnh : Form
    {
        public LoadAnh()
        {
            InitializeComponent();
        }
        //Random random = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            //rflb_nhom.Location = new Point(rflb_nhom.Location.X + 1, rflb_nhom.Location.Y);
            //rflb_ten.Location = new Point(rflb_ten.Location.X + 1, rflb_ten.Location.Y);
            //rflb_kien.Location = new Point(rflb_kien.Location.X + 1, rflb_kien.Location.Y);
            //rflb_huong.Location = new Point(rflb_huong.Location.X + 1, rflb_huong.Location.Y);
            //if ((rflb_ten.Location.Y + rflb_ten.Height < 0) && (rflb_nhom.Location.Y + rflb_nhom.Height < 0)
            //        && (rflb_kien.Location.Y + rflb_kien.Height < 0) && (rflb_huong.Location.Y + rflb_huong.Height < 0))
            //{
            //    rflb_ten.Location = new Point(rflb_ten.Location.X, panel1.Height);
            //    rflb_nhom.Location = new Point(rflb_ten.Location.X, panel1.Height);
            //    rflb_kien.Location = new Point(rflb_ten.Location.X, panel1.Height);
            //    rflb_huong.Location = new Point(rflb_ten.Location.X, panel1.Height);
            //}
            //rflb_nhom.ForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            //rflb_ten.ForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            //rflb_kien.ForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            //rflb_huong.ForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

        private void LoadAnh_Load(object sender, EventArgs e)
        {
            //timer1.Enabled = true;
            ChoiNhac("amthanh.wav");

        }
        private static void ChoiNhac(string amthanh)
        {
            SoundPlayer sound = new SoundPlayer("amthanh.wav");
            sound.LoadAsync();
            sound.Play();
        }
    }
}
