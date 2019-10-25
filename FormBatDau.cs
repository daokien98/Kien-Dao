using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using demo_xử_lý_ảnh.Properties;
using System.Media;


namespace demo_xử_lý_ảnh
{
    public partial class FormBatDau : DevComponents.DotNetBar.RibbonForm
    {
        //public PictureBox pgoc;
        // khai báo biến bitmap cho ảnh ban đầu và ảnh sau chỉnh sửa
        public Bitmap bmpgoc;
        private Bitmap bmpdich;
        private Bitmap bmpxuly;
        private Bitmap bmpdoimau;
        private Bitmap bmpxoaychieudh;
        private Bitmap bmpxoaynguocdh;
        private Bitmap bmpxoay180;
        public int red1, green1, blue1;
        public float tuongphan = 0;
        int lastCol = 0; // màu vẽ
        float gamma = 1;
        // mở file lưu file
        Boolean mofile = false;
        Random random = new Random();

        // xử lý ảnh liên tục
        public bool ambanclick = false;
        public bool trangdenclick = false;
        public bool cochayclick = false;
        public bool xamclick = false;
        public bool veclick = false;
        public bool doclick = false;
        public bool lucclick = false;
        public bool lamclick = false;
        public bool vangclick = false;
        public bool hongclick = false;


        public FormBatDau()
        {
            //Tao giao dien load phan mem
            //Thread t = new Thread(new ThreadStart(TaiForm));
            //t.Start();
            //Thread.Sleep(4000);
            //t.Abort();
            InitializeComponent();

            timer2.Enabled = true;
            ChoiNhac("amthanh.wav");
        }

        public void TaiForm()
        {
            Application.Run(new LoadAnh());
        }
        private void bti_moanh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Mở Ảnh";
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //file = Image.FromFile(openFileDialog1.FileName);
                bmpgoc = new Bitmap(openFileDialog1.FileName);
                picGoc.Image = bmpgoc;
                mofile = true;
            }
            //pgoc.Image = picGoc.Image;
        }

        private void bti_luuanh_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (bmpdich == bmpxuly)
                {
                    if (mofile)
                    {
                        if (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 3).ToLower() == "jpg")
                        {
                            bmpxuly.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                        }
                        if (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 3).ToLower() == "png")
                        {
                            bmpxuly.Save(saveFileDialog1.FileName, ImageFormat.Png);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn cần mở ảnh trước!");
                    }
                }
                if (bmpdich == bmpdoimau)
                {
                    if (mofile)
                    {
                        if (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 3).ToLower() == "jpg")
                        {
                            bmpdoimau.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                        }
                        if (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 3).ToLower() == "png")
                        {
                            bmpdoimau.Save(saveFileDialog1.FileName, ImageFormat.Png);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn cần mở ảnh trước!");
                    }
                }
                if (bmpdich == bmpxoay180)
                {
                    if (mofile)
                    {
                        if (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 3).ToLower() == "jpg")
                        {
                            bmpxoay180.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                        }
                        if (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 3).ToLower() == "png")
                        {
                            bmpxoay180.Save(saveFileDialog1.FileName, ImageFormat.Png);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn cần mở ảnh trước!");
                    }
                }
                else
                {
                    if (mofile)
                    {
                        if (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 3).ToLower() == "jpg")
                        {
                            bmpdich.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                        }
                        if (saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.Length - 3).ToLower() == "png")
                        {
                            bmpdich.Save(saveFileDialog1.FileName, ImageFormat.Png);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn cần mở ảnh trước!");
                    }
                }
                
            }
        }


        private void symbolBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đây là bài tập lớn chúng em kính gửi cô Nguyễn Kim Anh.\n\nBài tập còn nhiều thiếu sót, chúng em mong nhận được những góp ý chân thành từ cô cũng như các bạn.\n\nChúng em xin chân thành cảm ơn!\n\nYêu cô <3!"
                , "Thông tin bài tập", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void picGoc_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Mở Ảnh";
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmpgoc = new Bitmap(openFileDialog1.FileName);
                picGoc.Image = bmpgoc;
                mofile = true;
            }
        }

        private void bti_xamanh_Click(object sender, EventArgs e)
        {
            //một điểm ảnh trong ảnh được biểu diễn bằng một số 8 bit = 2^8=256 giá trị từ tối tới sáng
            xamclick = true;
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {
                if (doclick == true || lucclick == true || lamclick == true || hongclick == true || vangclick == true)
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpxuly = new Bitmap(bmpdoimau.Width, bmpdoimau.Height);
                    for (int y = 0; y < bmpxuly.Height; y++)
                    {
                        for (int x = 0; x < bmpxuly.Width; x++)
                        {
                            Color c = bmpdoimau.GetPixel(x, y);
                            int g = (int)(c.R * .299 + c.G * .587 + c.B * .114);
                            bmpxuly.SetPixel(x, y, Color.FromArgb(g, g, g));
                        }
                    }
                    //picDich.Image = bmpxuly;
                    bmpdich = bmpxuly;
                    picDich.Image = bmpdich;
                }
                else
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpxuly = new Bitmap(bmpgoc.Width, bmpgoc.Height);
                    for (int y = 0; y < bmpxuly.Height; y++)
                    {
                        for (int x = 0; x < bmpxuly.Width; x++)
                        {
                            Color c = bmpgoc.GetPixel(x, y);
                            int g = (int)(c.R * .299 + c.G * .587 + c.B * .114);
                            bmpxuly.SetPixel(x, y, Color.FromArgb(g, g, g));
                        }
                    }
                    //picDich.Image = bmpxuly;
                    bmpdich = bmpxuly;
                    picDich.Image = bmpdich;
                }
            }
        }

        private void bti_trangden_Click(object sender, EventArgs e)
        {
            //một điểm ảnh được biểu diễn bằng số một bit = 2^1=2 giá trị tối và sáng
            trangdenclick = true;
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {

                if (doclick == true || lucclick == true || lamclick == true || hongclick == true || vangclick == true)
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpxuly = new Bitmap(bmpdoimau.Width, bmpdoimau.Height);
                    for (int y = 0; y < bmpxuly.Height; y++)
                    {
                        for (int x = 0; x < bmpxuly.Width; x++)
                        {
                            Color c = bmpdoimau.GetPixel(x, y);// lấy thông tin màu của từng điểm ảnh
                            int g = 120; // ngưỡng là 120
                            int desColor = Convert.ToInt32((c.R * 0.2989) + (c.G * 0.5870) + (c.B * 0.1140));

                            //-- Kiểm tra giá trị màu với ngưỡng xám
                            if (desColor < g) desColor = 0;
                            else desColor = 255;

                            bmpxuly.SetPixel(x, y, Color.FromArgb(255, desColor, desColor, desColor));// set màu cho mỗi điểm ảnh

                        }
                    }
                    bmpdich = bmpxuly;
                    picDich.Image = bmpdich;

                }
                else
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpxuly = new Bitmap(bmpgoc.Width, bmpgoc.Height);
                    for (int y = 0; y < bmpxuly.Height; y++)
                    {
                        for (int x = 0; x < bmpxuly.Width; x++)
                        {
                            Color c = bmpgoc.GetPixel(x, y);// lấy thông tin màu của từng điểm ảnh
                            int g = 120; // ngưỡng là 120
                            int desColor = Convert.ToInt32((c.R * 0.2989) + (c.G * 0.5870) + (c.B * 0.1140));

                            //-- Kiểm tra giá trị màu với ngưỡng xám
                            if (desColor < g) desColor = 0;
                            else desColor = 255;

                            bmpxuly.SetPixel(x, y, Color.FromArgb(255, desColor, desColor, desColor));// set màu cho mỗi điểm ảnh

                        }
                    }
                    bmpdich = bmpxuly;
                    picDich.Image = bmpdich;
                }
            }
        }

        private void bti_cochay_Click(object sender, EventArgs e)
        {
            cochayclick = true;
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {

                if (doclick == true || lucclick == true || lamclick == true || hongclick == true || vangclick == true)
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpxuly = new Bitmap(bmpdoimau.Width, bmpdoimau.Height);
                    for (int y = 0; y < bmpxuly.Height; y++)
                    {
                        for (int x = 0; x < bmpxuly.Width; x++)
                        {
                            Color p = bmpdoimau.GetPixel(x, y);
                            int t1, t2, t3;
                            t1 = (p.R >= 128) ? 255 : 0;
                            t2 = (p.G >= 128) ? 255 : 0;
                            t3 = (p.B >= 128) ? 255 : 0;
                            bmpxuly.SetPixel(x, y, Color.FromArgb(t1, t2, t3));
                        }
                    }
                    bmpdich = bmpxuly;
                    picDich.Image = bmpdich;
                }
                else
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpxuly = new Bitmap(bmpgoc.Width, bmpgoc.Height);
                    for (int y = 0; y < bmpxuly.Height; y++)
                    {
                        for (int x = 0; x < bmpxuly.Width; x++)
                        {
                            Color p = bmpgoc.GetPixel(x, y);
                            int t1, t2, t3;
                            t1 = (p.R >= 128) ? 255 : 0;
                            t2 = (p.G >= 128) ? 255 : 0;
                            t3 = (p.B >= 128) ? 255 : 0;
                            bmpxuly.SetPixel(x, y, Color.FromArgb(t1, t2, t3));
                        }
                    }
                    bmpdich = bmpxuly;
                    picDich.Image = bmpdich;
                }
            }
        }

        private void bti_amban_Click(object sender, EventArgs e)
        {
            ambanclick = true;
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {

                if (doclick == true || lucclick == true || lamclick == true || hongclick == true || vangclick == true)
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpxuly = new Bitmap(bmpdoimau.Width, bmpdoimau.Height);
                    for (int y = 0; y < bmpxuly.Height; y++)
                    {
                        for (int x = 0; x < bmpxuly.Width; x++)
                        {
                            Color c = bmpdoimau.GetPixel(x, y);

                            bmpxuly.SetPixel(x, y, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                        }
                    }
                    bmpdich = bmpxuly;
                    picDich.Image = bmpdich;
                }
                else
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpxuly = new Bitmap(bmpgoc.Width, bmpgoc.Height);
                    for (int y = 0; y < bmpxuly.Height; y++)
                    {
                        for (int x = 0; x < bmpxuly.Width; x++)
                        {
                            Color c = bmpgoc.GetPixel(x, y);

                            bmpxuly.SetPixel(x, y, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                        }
                    }
                    bmpdich = bmpxuly;
                    picDich.Image = bmpdich;
                }
            }
        }

        private void bti_do_Click(object sender, EventArgs e)
        {
            doclick = true;
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {

                if (xamclick == true || ambanclick == true || veclick == true || cochayclick == true || trangdenclick == true)
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpdoimau = new Bitmap(bmpxuly.Width, bmpxuly.Height);
                    for (int y = 0; y < bmpdoimau.Height; y++)
                    {
                        for (int x = 0; x < bmpdoimau.Width; x++)
                        {
                            Color c = bmpxuly.GetPixel(x, y);

                            bmpdoimau.SetPixel(x, y, Color.FromArgb(c.R, 255 - c.G, 255 - c.B));
                        }
                    }
                    //picDich.Image = bmpdoimau;
                    bmpdich = bmpdoimau;
                    picDich.Image = bmpdich;
                }
                else
                {
                    bmpdoimau = new Bitmap(bmpgoc.Width, bmpgoc.Height);
                    for (int y = 0; y < bmpdoimau.Height; y++)
                    {
                        for (int x = 0; x < bmpdoimau.Width; x++)
                        {
                            Color c = bmpgoc.GetPixel(x, y);

                            bmpdoimau.SetPixel(x, y, Color.FromArgb(c.R, 255 - c.G, 255 - c.B));
                        }
                    }
                    //picDich.Image = bmpdoimau;
                    bmpdich = bmpdoimau;
                    picDich.Image = bmpdich;
                }
            }
        }

        private void bti_luc_Click(object sender, EventArgs e)
        {
            lucclick = true;
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {

                if (xamclick == true || ambanclick == true || veclick == true || cochayclick == true || trangdenclick == true)
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpdoimau = new Bitmap(bmpxuly.Width, bmpxuly.Height);
                    for (int y = 0; y < bmpdoimau.Height; y++)
                    {
                        for (int x = 0; x < bmpdoimau.Width; x++)
                        {
                            Color c = bmpxuly.GetPixel(x, y);

                            bmpdoimau.SetPixel(x, y, Color.FromArgb(255 - c.R, c.G, 255 - c.B));
                        }
                    }
                    bmpdich = bmpdoimau;
                    picDich.Image = bmpdich;
                }
                else
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpdoimau = new Bitmap(bmpgoc.Width, bmpgoc.Height);
                    for (int y = 0; y < bmpdoimau.Height; y++)
                    {
                        for (int x = 0; x < bmpdoimau.Width; x++)
                        {
                            Color c = bmpgoc.GetPixel(x, y);

                            bmpdoimau.SetPixel(x, y, Color.FromArgb(255 - c.R, c.G, 255 - c.B));
                        }
                    }
                    bmpdich = bmpdoimau;
                    picDich.Image = bmpdich;
                }
            }
        }

        private void bti_lam_Click(object sender, EventArgs e)
        {
            lamclick = true;
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {

                if (xamclick == true || ambanclick == true || veclick == true || cochayclick == true || trangdenclick == true)
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpdoimau = new Bitmap(bmpxuly.Width, bmpxuly.Height);
                    for (int y = 0; y < bmpdoimau.Height; y++)
                    {
                        for (int x = 0; x < bmpdoimau.Width; x++)
                        {
                            Color c = bmpxuly.GetPixel(x, y);

                            bmpdoimau.SetPixel(x, y, Color.FromArgb(255 - c.R, 255 - c.G, c.B));
                        }
                    }
                    bmpdich = bmpdoimau;
                    picDich.Image = bmpdich;
                }
                else
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpdoimau = new Bitmap(bmpgoc.Width, bmpgoc.Height);
                    for (int y = 0; y < bmpdoimau.Height; y++)
                    {
                        for (int x = 0; x < bmpdoimau.Width; x++)
                        {
                            Color c = bmpgoc.GetPixel(x, y);

                            bmpdoimau.SetPixel(x, y, Color.FromArgb(255 - c.R, 255 - c.G, c.B));
                        }
                    }
                    bmpdich = bmpdoimau;
                    picDich.Image = bmpdich;
                }

            }
        }

        private void bti_vang_Click(object sender, EventArgs e)
        {
            vangclick = true;
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {

                if (xamclick == true || ambanclick == true || veclick == true || cochayclick == true || trangdenclick == true)
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpdoimau = new Bitmap(bmpxuly.Width, bmpxuly.Height);
                    for (int y = 0; y < bmpdoimau.Height; y++)
                    {
                        for (int x = 0; x < bmpdoimau.Width; x++)
                        {
                            Color c = bmpxuly.GetPixel(x, y);

                            bmpdoimau.SetPixel(x, y, Color.FromArgb(c.R, c.G, 255 - c.B));
                        }
                    }
                    bmpdich = bmpdoimau;
                    picDich.Image = bmpdich;
                }
                else
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpdoimau = new Bitmap(bmpgoc.Width, bmpgoc.Height);
                    for (int y = 0; y < bmpdoimau.Height; y++)
                    {
                        for (int x = 0; x < bmpdoimau.Width; x++)
                        {
                            Color c = bmpgoc.GetPixel(x, y);

                            bmpdoimau.SetPixel(x, y, Color.FromArgb(c.R, c.G, 255 - c.B));
                        }
                    }
                    bmpdich = bmpdoimau;
                    picDich.Image = bmpdich;
                }
            }
        }

        private void bti_canhsen_Click(object sender, EventArgs e)
        {
            hongclick = true;
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {

                if (xamclick == true || ambanclick == true || veclick == true || cochayclick == true || trangdenclick == true)
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpdoimau = new Bitmap(bmpxuly.Width, bmpxuly.Height);
                    for (int y = 0; y < bmpdoimau.Height; y++)
                    {
                        for (int x = 0; x < bmpdoimau.Width; x++)
                        {
                            Color c = bmpxuly.GetPixel(x, y);

                            bmpdoimau.SetPixel(x, y, Color.FromArgb(c.R, 255 - c.G, c.B));
                        }
                    }
                    bmpdich = bmpdoimau;
                    picDich.Image = bmpdich;
                }
                else
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpdoimau = new Bitmap(bmpgoc.Width, bmpgoc.Height);
                    for (int y = 0; y < bmpdoimau.Height; y++)
                    {
                        for (int x = 0; x < bmpdoimau.Width; x++)
                        {
                            Color c = bmpgoc.GetPixel(x, y);

                            bmpdoimau.SetPixel(x, y, Color.FromArgb(c.R, 255 - c.G, c.B));
                        }
                    }
                    bmpdich = bmpdoimau;
                    picDich.Image = bmpdich;
                }
            }
        }

        private void bti_dosang_Click(object sender, EventArgs e)
        {
            //truyenthamso form = new truyenthamso();
            //form.ShowDialog();

            //int gt = int.Parse(form.TextBox1_Form2.Text);
            int gt = track_sang.Value;
            tb_sang.Text = track_sang.Value.ToString();
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {

                if (bmpdich == bmpxuly)
                {
                    Bitmap bmp = (Bitmap)picGoc.Image.Clone();
                    for (int y = 0; y < bmpxuly.Height; y++)
                    {
                        for (int x = 0; x < bmpxuly.Width; x++)
                        {
                            Color c = bmpxuly.GetPixel(x, y);
                            int t1 = Math.Max(Math.Min(c.R + gt, 255), 0);
                            int t2 = Math.Max(Math.Min(c.G + gt, 255), 0);
                            int t3 = Math.Max(Math.Min(c.B + gt, 255), 0);
                            bmpxuly.SetPixel(x, y, Color.FromArgb(t1, t2, t3));
                        }
                    }
                    picDich.Image = bmpxuly;
                }
                else if (bmpdich == bmpdoimau)
                {
                    Bitmap bmp = (Bitmap)picGoc.Image.Clone();
                    for (int y = 0; y < bmpdoimau.Height; y++)
                    {
                        for (int x = 0; x < bmpdoimau.Width; x++)
                        {
                            Color c = bmpdoimau.GetPixel(x, y);
                            int t1 = Math.Max(Math.Min(c.R + gt, 255), 0);
                            int t2 = Math.Max(Math.Min(c.G + gt, 255), 0);
                            int t3 = Math.Max(Math.Min(c.B + gt, 255), 0);
                            bmpdoimau.SetPixel(x, y, Color.FromArgb(t1, t2, t3));
                        }
                    }
                    picDich.Image = bmpdoimau;
                }
                else
                {
                    Bitmap bmp = (Bitmap)picGoc.Image.Clone();
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        for (int x = 0; x < bmp.Width; x++)
                        {
                            Color c = bmp.GetPixel(x, y);
                            int t1 = Math.Max(Math.Min(c.R + gt, 255), 0);
                            int t2 = Math.Max(Math.Min(c.G + gt, 255), 0);
                            int t3 = Math.Max(Math.Min(c.B + gt, 255), 0);
                            bmp.SetPixel(x, y, Color.FromArgb(t1, t2, t3));
                        }
                    }
                    picDich.Image = bmp;
                }
            }
        }

        private void bti_tuongphan_Click(object sender, EventArgs e)
        {
            //truyenthamso form = new truyenthamso();
            //form.ShowDialog();

            //int gttp = int.Parse(form.TextBox1_Form2.Text);
            int gttp = track_tuongphan.Value;
            tb_tp.Text = track_tuongphan.Value.ToString();
            tuongphan = 0.04f + gttp;
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {

                if (bmpdich == bmpxuly)
                {
                    Bitmap bmpdich = new Bitmap(bmpxuly.Width, bmpxuly.Height); // đổi từ ảnh gốc 
                    Graphics g = Graphics.FromImage(bmpdich);// lấy các đối tượng trong ảnh
                    ImageAttributes im = new ImageAttributes();// tạo các thuộc tính của ảnh    

                    // tạo ma trận màu 
                    ColorMatrix matrix = new ColorMatrix(new float[][]
                    {
                new float[] { tuongphan,0f,0f,0f,0f},
                new float[] { 0f,tuongphan,0f,0f,0f},
                new float[] { 0f,0f,tuongphan,0f,0f},
                new float[] { 0f,0f,0f,1f,0f},
                new float[] {0.001f,0.001f,0.001f,0f,1f}
                    });
                    im.SetColorMatrix(matrix); // set màu cho ma trận
                    g.DrawImage(bmpxuly, new Rectangle(0, 0, bmpxuly.Width, bmpxuly.Height), 0, 0, bmpxuly.Width, bmpxuly.Height, GraphicsUnit.Pixel, im);
                    g.Dispose();// loại bỏ các đối tượng Graphics thừa
                    im.Dispose(); // loại bỏ các thuộc tính thừa
                    picDich.Image = bmpdich;
                }
                if (bmpdich == bmpdoimau)
                {
                    Bitmap bmpdich = new Bitmap(bmpdoimau.Width, bmpdoimau.Height); // đổi từ ảnh gốc 
                    Graphics g = Graphics.FromImage(bmpdich);// lấy các đối tượng trong ảnh
                    ImageAttributes im = new ImageAttributes();// tạo các thuộc tính của ảnh    

                    // tạo ma trận màu 
                    ColorMatrix matrix = new ColorMatrix(new float[][]
                    {
                new float[] { tuongphan,0f,0f,0f,0f},
                new float[] { 0f,tuongphan,0f,0f,0f},
                new float[] { 0f,0f,tuongphan,0f,0f},
                new float[] { 0f,0f,0f,1f,0f},
                new float[] {0.001f,0.001f,0.001f,0f,1f}
                    });
                    im.SetColorMatrix(matrix); // set màu cho ma trận
                    g.DrawImage(bmpdoimau, new Rectangle(0, 0, bmpdoimau.Width, bmpdoimau.Height), 0, 0, bmpdoimau.Width, bmpdoimau.Height, GraphicsUnit.Pixel, im);
                    g.Dispose();// loại bỏ các đối tượng Graphics thừa
                    im.Dispose(); // loại bỏ các thuộc tính thừa
                    picDich.Image = bmpdich;
                }
                else
                {
                    Bitmap bmdich = new Bitmap(bmpgoc.Width, bmpgoc.Height); // đổi từ ảnh gốc 
                    Graphics g = Graphics.FromImage(bmpdich);// lấy các đối tượng trong ảnh
                    ImageAttributes im = new ImageAttributes();// tạo các thuộc tính của ảnh    

                    // tạo ma trận màu 
                    ColorMatrix matrix = new ColorMatrix(new float[][]
                    {
                new float[] { tuongphan,0f,0f,0f,0f},
                new float[] { 0f,tuongphan,0f,0f,0f},
                new float[] { 0f,0f,tuongphan,0f,0f},
                new float[] { 0f,0f,0f,1f,0f},
                new float[] {0.001f,0.001f,0.001f,0f,1f}
                    });
                    im.SetColorMatrix(matrix); // set màu cho ma trận
                    g.DrawImage(bmpgoc, new Rectangle(0, 0, bmpgoc.Width, bmpgoc.Height), 0, 0, bmpgoc.Width, bmpgoc.Height, GraphicsUnit.Pixel, im);
                    g.Dispose();// loại bỏ các đối tượng Graphics thừa
                    im.Dispose(); // loại bỏ các thuộc tính thừa
                    picDich.Image = bmpdich;

                }
            }
        }

        private void bti_zoom_Click(object sender, EventArgs e)
        {
            FormZoomAnh formzoom = new FormZoomAnh();
            formzoom.Show();
            this.Hide();
        }

        private void bti_cat_Click(object sender, EventArgs e)
        {
            FormCatAnh formcat = new FormCatAnh();
            formcat.Show();
            this.Hide();
        }

        private void bti_tuychinhmau_Click(object sender, EventArgs e)
        {
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {

                if (doclick == true || lamclick == true || vangclick == true || lucclick == true || hongclick == true)
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpdich = new Bitmap(bmpdoimau.Width, bmpdoimau.Height);
                    for (int y = 0; y < bmpdich.Height; y++)
                    {
                        for (int x = 0; x < bmpdich.Width; x++)
                        {
                            Color c = bmpdoimau.GetPixel(x, y);

                            bmpdich.SetPixel(x, y, Color.FromArgb(Math.Min(red1, c.R), Math.Min(green1, c.G), Math.Min(blue1, c.B)));
                        }
                    }
                    picDich.Image = bmpdich;
                }
                else if (veclick == true || xamclick == true || trangdenclick == true || ambanclick == true || cochayclick == true)
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpdich = new Bitmap(bmpxuly.Width, bmpxuly.Height);
                    for (int y = 0; y < bmpdich.Height; y++)
                    {
                        for (int x = 0; x < bmpdich.Width; x++)
                        {
                            Color c = bmpgoc.GetPixel(x, y);

                            bmpdich.SetPixel(x, y, Color.FromArgb(Math.Min(red1, c.R), Math.Min(green1, c.G), Math.Min(blue1, c.B)));
                        }
                    }
                    picDich.Image = bmpdich;
                }
                else
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpdich = new Bitmap(bmpgoc.Width, bmpgoc.Height);
                    for (int y = 0; y < bmpdich.Height; y++)
                    {
                        for (int x = 0; x < bmpdich.Width; x++)
                        {
                            Color c = bmpgoc.GetPixel(x, y);

                            bmpdich.SetPixel(x, y, Color.FromArgb(Math.Min(red1, c.R), Math.Min(green1, c.G), Math.Min(blue1, c.B)));
                        }
                    }
                    picDich.Image = bmpdich;
                }
            }
        }

        private void bti_ve_Click(object sender, EventArgs e)
        {
            veclick = true;
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {

                if (doclick == true || lucclick == true || lamclick == true || hongclick == true || vangclick == true)
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpxuly = new Bitmap(bmpdoimau.Width, bmpdoimau.Height);
                    for (int y = 0; y < bmpxuly.Height; y++)
                    {
                        for (int x = 0; x < bmpxuly.Width; x++)
                        {
                            bmpxuly.SetPixel(x, y, Color.DarkGray);
                        }
                    }
                    for (int y = 0; y < bmpxuly.Height; y++)
                    {
                        for (int x = 0; x < bmpxuly.Width; x++)
                        {
                            try
                            {
                                Color c = bmpdoimau.GetPixel(x, y);
                                int coval = (c.R + c.G + c.B);// tổng màu ban đầu
                                if (lastCol == 0) lastCol = (c.R + c.G + c.B); // tổng màu cuối cùng
                                int diff; // giá trị trừ
                                if (coval > lastCol)
                                {
                                    diff = coval - lastCol;
                                }
                                else
                                {
                                    diff = lastCol - coval;
                                }
                                if (diff > 100)
                                {
                                    bmpxuly.SetPixel(x, y, Color.Gray);
                                    lastCol = coval;
                                }
                            }
                            catch (Exception) { }
                        }

                    }
                    bmpdich = bmpxuly;
                    picDich.Image = bmpdich;
                }
                else
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpdich = new Bitmap(bmpgoc.Width, bmpgoc.Height);
                    for (int y = 0; y < bmpdich.Height; y++)
                    {
                        for (int x = 0; x < bmpdich.Width; x++)
                        {
                            bmpdich.SetPixel(x, y, Color.DarkGray);
                        }
                    }
                    for (int y = 0; y < bmpdich.Height; y++)
                    {
                        for (int x = 0; x < bmpdich.Width; x++)
                        {
                            try
                            {
                                Color c = bmpgoc.GetPixel(x, y);
                                int coval = (c.R + c.G + c.B);
                                if (lastCol == 0) lastCol = (c.R + c.G + c.B);
                                int diff;
                                if (coval > lastCol)
                                {
                                    diff = coval - lastCol;
                                }
                                else
                                {
                                    diff = lastCol - coval;
                                }
                                if (diff > 100)
                                {
                                    bmpdich.SetPixel(x, y, Color.Gray);
                                    lastCol = coval;
                                }
                            }
                            catch (Exception) { }
                        }

                    }
                    picDich.Image = bmpdich;
                }
            }
        }

        private void bti_lammo_Click(object sender, EventArgs e)
        {
            //truyenthamso form = new truyenthamso();
            //form.ShowDialog();

            //int mo = int.Parse(form.TextBox1_Form2.Text);
            int mo = track_mo.Value;
            tb_mo.Text = track_mo.Value.ToString();
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {

                if (bmpdich == bmpxuly)
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpdich = new Bitmap(bmpxuly.Width, bmpxuly.Height);
                    for (int y = mo; y <= bmpdich.Height - mo; y++)
                    {
                        for (int x = mo; x <= bmpdich.Width - mo; x++)
                        {
                            try
                            {
                                Color Xtruoc = bmpxuly.GetPixel(x - mo, y);
                                Color Xtiep = bmpxuly.GetPixel(x + mo, y);
                                Color Ytruoc = bmpxuly.GetPixel(x, y - mo);
                                Color Ytiep = bmpxuly.GetPixel(x, y + mo);
                                int tbR = (int)((Xtruoc.R + Xtiep.R + Ytruoc.R + Ytiep.R) / 4);
                                int tbG = (int)((Xtruoc.G + Xtiep.G + Ytruoc.G + Ytiep.G) / 4);
                                int tbB = (int)((Xtruoc.B + Xtiep.B + Ytruoc.B + Ytiep.B) / 4);
                                bmpdich.SetPixel(x, y, Color.FromArgb(tbR, tbG, tbB));


                            }
                            catch (Exception) { }
                        }
                    }
                    picDich.Image = bmpdich;
                }
                else if (bmpdich == bmpdoimau)
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpdich = new Bitmap(bmpdoimau.Width, bmpdoimau.Height);
                    for (int y = mo; y <= bmpdich.Height - mo; y++)
                    {
                        for (int x = mo; x <= bmpdich.Width - mo; x++)
                        {
                            try
                            {
                                Color Xtruoc = bmpdoimau.GetPixel(x - mo, y);
                                Color Xtiep = bmpdoimau.GetPixel(x + mo, y);
                                Color Ytruoc = bmpdoimau.GetPixel(x, y - mo);
                                Color Ytiep = bmpdoimau.GetPixel(x, y + mo);
                                int tbR = (int)((Xtruoc.R + Xtiep.R + Ytruoc.R + Ytiep.R) / 4);
                                int tbG = (int)((Xtruoc.G + Xtiep.G + Ytruoc.G + Ytiep.G) / 4);
                                int tbB = (int)((Xtruoc.B + Xtiep.B + Ytruoc.B + Ytiep.B) / 4);
                                bmpdich.SetPixel(x, y, Color.FromArgb(tbR, tbG, tbB));


                            }
                            catch (Exception) { }
                        }
                    }
                    picDich.Image = bmpdich;
                }
                else
                {
                    bmpgoc = (Bitmap)picGoc.Image.Clone();
                    bmpdich = new Bitmap(bmpgoc.Width, bmpgoc.Height);
                    for (int y = mo; y <= bmpdich.Height - mo; y++)
                    {
                        for (int x = mo; x <= bmpdich.Width - mo; x++)
                        {
                            try
                            {
                                Color Xtruoc = bmpgoc.GetPixel(x - mo, y);
                                Color Xtiep = bmpgoc.GetPixel(x + mo, y);
                                Color Ytruoc = bmpgoc.GetPixel(x, y - mo);
                                Color Ytiep = bmpgoc.GetPixel(x, y + mo);
                                int tbR = (int)((Xtruoc.R + Xtiep.R + Ytruoc.R + Ytiep.R) / 4);
                                int tbG = (int)((Xtruoc.G + Xtiep.G + Ytruoc.G + Ytiep.G) / 4);
                                int tbB = (int)((Xtruoc.B + Xtiep.B + Ytruoc.B + Ytiep.B) / 4);
                                bmpdich.SetPixel(x, y, Color.FromArgb(tbR, tbG, tbB));


                            }
                            catch (Exception) { }
                        }
                    }
                    picDich.Image = bmpdich;
                }
            }

        }

        private void bti_gamma_Click(object sender, EventArgs e)
        {
            //truyenthamso form = new truyenthamso();
            //form.ShowDialog();

            //int gtgm = int.Parse(form.TextBox1_Form2.Text);
            int gtgm = track_gamma.Value;
            tb_gamma.Text = track_gamma.Value.ToString();
            gamma = 0.04f * gtgm;
            bmpgoc = (Bitmap)picGoc.Image.Clone();
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {

                if (bmpdich == bmpxuly)
                {
                    bmpdich = new Bitmap(bmpxuly.Width, bmpxuly.Height);
                    Graphics g = Graphics.FromImage(bmpdich);
                    ImageAttributes ia = new ImageAttributes();
                    ia.SetGamma(gamma);
                    g.DrawImage(bmpxuly, new Rectangle(0, 0, bmpxuly.Width, bmpxuly.Height), 0, 0, bmpxuly.Width, bmpxuly.Height, GraphicsUnit.Pixel, ia);
                    g.Dispose();// loại bỏ các đối tượng Graphics thừa
                    ia.Dispose(); //loại bỏ thuộc tính thừa
                    picDich.Image = bmpdich;
                }
                if (bmpdich == bmpdoimau)
                {
                    bmpdich = new Bitmap(bmpdoimau.Width, bmpdoimau.Height);
                    Graphics g = Graphics.FromImage(bmpdich);
                    ImageAttributes ia = new ImageAttributes();
                    ia.SetGamma(gamma);
                    g.DrawImage(bmpdoimau, new Rectangle(0, 0, bmpdoimau.Width, bmpdoimau.Height), 0, 0, bmpdoimau.Width, bmpdoimau.Height, GraphicsUnit.Pixel, ia);
                    g.Dispose();
                    ia.Dispose();
                    picDich.Image = bmpdich;
                }
                else
                {
                    bmpdich = new Bitmap(bmpgoc.Width, bmpgoc.Height);
                    Graphics g = Graphics.FromImage(bmpdich);
                    ImageAttributes ia = new ImageAttributes();
                    ia.SetGamma(gamma);
                    g.DrawImage(bmpgoc, new Rectangle(0, 0, bmpgoc.Width, bmpgoc.Height), 0, 0, bmpgoc.Width, bmpgoc.Height, GraphicsUnit.Pixel, ia);
                    g.Dispose();
                    ia.Dispose();
                    picDich.Image = bmpdich;
                }

            }

        }

        private void bti_thoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn thực sự muốn thoát sao?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (dr == DialogResult.OK)
            {
                Application.Exit();
            }
        }


        private void bti_facebook_Click(object sender, EventArgs e)
        {
            Facebook f = new Facebook();
            f.Show();
        }

        private void bti_gmail_Click(object sender, EventArgs e)
        {
            Gmail f = new Gmail();
            f.Show();
        }

        private void bti_mess_Click(object sender, EventArgs e)
        {
            Mess f = new Mess();
            f.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int a = random.Next(0, 255);
            int b = random.Next(0, 255);
            int c = random.Next(0, 255);
            ribbonBar1.TitleStyle.TextColor = Color.FromArgb(a,b,c);
            ribbonBar2.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar3.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar4.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar5.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar6.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar7.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar8.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar9.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar10.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar11.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar12.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar13.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar14.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar15.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar16.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar17.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar18.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar19.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar20.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar21.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar22.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar23.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar24.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar26.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar27.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ribbonBar29.TitleStyle.TextColor = Color.FromArgb(a, b, c);
            ratingStar1.TextColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            rflb_nhom.Location = new Point(rflb_nhom.Location.X, rflb_nhom.Location.Y - 1);
            rflb_ten.Location = new Point(rflb_ten.Location.X, rflb_ten.Location.Y - 1);
            rflb_kien.Location = new Point(rflb_kien.Location.X, rflb_kien.Location.Y - 1);
            rflb_huong.Location = new Point(rflb_huong.Location.X, rflb_huong.Location.Y - 1);
            if ((rflb_ten.Location.Y + rflb_ten.Height < 0) && (rflb_nhom.Location.Y + rflb_nhom.Height < 0)
                    && (rflb_kien.Location.Y + rflb_kien.Height < 0) && (rflb_huong.Location.Y + rflb_huong.Height < 0))
            {
                rflb_ten.Location = new Point(rflb_ten.Location.X, panel1.Height);
                rflb_nhom.Location = new Point(rflb_ten.Location.X, panel2.Height);
                rflb_kien.Location = new Point(rflb_ten.Location.X, panel3.Height);
                rflb_huong.Location = new Point(rflb_ten.Location.X, panel4.Height);
            }
            rflb_nhom.ForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            rflb_ten.ForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            rflb_kien.ForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            rflb_huong.ForeColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

        private void FormBatDau_Load(object sender, EventArgs e)
        {
            //timer2.Enabled = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            tb_sang.Text = Convert.ToString(track_sang.Value);
            tb_tp.Text = Convert.ToString(track_tuongphan.Value);
            tb_mo.Text = Convert.ToString(track_mo.Value);
            tb_gamma.Text = Convert.ToString(track_gamma.Value);
        }

        private void bti_xoayngang_Click(object sender, EventArgs e)
        {
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {

                if (bmpdich == bmpxuly)
                {
                    bmpxuly.RotateFlip(RotateFlipType.Rotate180FlipY);
                    bmpxoay180 = bmpxuly;
                    picDich.Image = bmpxoay180;
                }
                else if (bmpdich == bmpdoimau)
                {
                    bmpdoimau.RotateFlip(RotateFlipType.Rotate180FlipY);
                    bmpxoay180 = bmpdoimau;
                    picDich.Image = bmpxoay180;
                }
                else
                {
                    bmpgoc.RotateFlip(RotateFlipType.Rotate180FlipY);
                    bmpxoay180 = bmpgoc;
                    picDich.Image = bmpxoay180;
                }
            }
        }

        private void bti_xoaydoc_Click(object sender, EventArgs e)
        {
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {

                if (bmpdich == bmpxuly)
                {
                    bmpxuly.RotateFlip(RotateFlipType.Rotate270FlipY);
                    bmpxoaynguocdh = bmpxuly;
                    picDich.Image = bmpxoaynguocdh;
                }
                else if (bmpdich == bmpdoimau)
                {
                    bmpdoimau.RotateFlip(RotateFlipType.Rotate270FlipY);
                    bmpxoaynguocdh = bmpdoimau;
                    picDich.Image = bmpxoaynguocdh;
                }
                else
                {
                    bmpgoc.RotateFlip(RotateFlipType.Rotate270FlipY);
                    bmpxoaynguocdh = bmpgoc;
                    picDich.Image = bmpxoaynguocdh;
                }
            }
        }

        private void bti_bandau_Click(object sender, EventArgs e)
        {
            picDich.Image = bmpgoc;
            bmpdoimau = bmpgoc;
            bmpxuly = bmpgoc;
        }

        private void bti_xuoichieudh_Click(object sender, EventArgs e)
        {
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {
                
                if (bmpdich == bmpxuly)
                {
                    bmpxuly.RotateFlip(RotateFlipType.Rotate90FlipY);
                    bmpxoaychieudh = bmpxuly;
                    picDich.Image = bmpxoaychieudh;
                }
                else if (bmpdich == bmpdoimau)
                {
                    bmpdoimau.RotateFlip(RotateFlipType.Rotate90FlipY);
                    bmpxoaychieudh = bmpdoimau;
                    picDich.Image = bmpxoaychieudh;
                }
                else
                {
                    bmpgoc.RotateFlip(RotateFlipType.Rotate90FlipY);
                    bmpxoaychieudh = bmpgoc;
                    picDich.Image = bmpxoaychieudh;
                }
            }
        }

        private void ratingStar1_RatingChanged(object sender, EventArgs e)
        {
            if (ratingStar1.Rating == 1)
                MessageBox.Show("Huhu được có 1 sao thôi sao? T-T");
            else if (ratingStar1.Rating == 2)
                MessageBox.Show("Hai sao thôi à thêm nữa đi bạn ơi!");
            else if (ratingStar1.Rating == 3)
                MessageBox.Show("3 sao, trời ơi tin được hông?!");
            else if (ratingStar1.Rating == 4)
                MessageBox.Show("Quá tuyệt, nhưng 5 sao thì sẽ tuyệt hơn!");
            else
                MessageBox.Show("Bạn là người tuyệt vời nhất!\n\nCám ơn vì đã đánh giá 5 sao!");

        }

        private void bti_xoaylenxuong_Click(object sender, EventArgs e)
        {
            if (picGoc.Image == null)
                MessageBox.Show("Bạn cần mở ảnh trước");
            else
            {
                if (bmpdich == bmpxuly)
                {
                    bmpxuly.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    bmpxoaychieudh = bmpxuly;
                    picDich.Image = bmpxoaychieudh;
                }
                else if (bmpdich == bmpdoimau)
                {
                    bmpdoimau.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    bmpxoaychieudh = bmpdoimau;
                    picDich.Image = bmpxoaychieudh;
                }
                else
                {
                    bmpgoc.RotateFlip(RotateFlipType.RotateNoneFlipY);
                    bmpxoaychieudh = bmpgoc;
                    picDich.Image = bmpxoaychieudh;
                }
            }
        }

        private void rflb_kien_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tb_red.Text = Convert.ToString(trackBar1.Value);
            tb_green.Text = Convert.ToString(trackBar2.Value);
            tb_blue.Text = Convert.ToString(trackBar3.Value);

            red1 = int.Parse(tb_red.Text);
            green1 = int.Parse(tb_green.Text);
            blue1 = int.Parse(tb_blue.Text);

        }

        private static void ChoiNhac(string amthanh)
        {
            SoundPlayer sound = new SoundPlayer("amthanh.wav");
            sound.LoadAsync();
            sound.PlayLooping();
            //sound.Play();
        }

    }
}