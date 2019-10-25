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
    public partial class FormCatAnh : DevComponents.DotNetBar.RibbonForm
    {
        FormBatDau f = new FormBatDau();
        private Bitmap bmp;
        private Bitmap cat;
        Rectangle HCN; //ve hinh chu nhat de cat anh

        Point VitriXY; // diem bat dau
        Point VitriX1Y1; // diem ket thuc
        bool IsMouseDown = false; //= true khi co su kien mouse down
        public FormCatAnh()
        {
            InitializeComponent();
        }

        private void FormCatAnh_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Mời bạn cắt ảnh!", "Cắt Ảnh", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
        }

        private void bti_moanh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Title = "Mở Ảnh";
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmp = new Bitmap(openFileDialog1.FileName);
                picGoc.Image = bmp;
            }
        }

        private void bti_luuanh_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cat.Save(saveFileDialog1.FileName + ".png");
            }
        }

        private void picGoc_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                VitriX1Y1 = e.Location;

                IsMouseDown = false;

                if (HCN != null)
                {
                    Bitmap bmp = new Bitmap(picGoc.Image, picGoc.Width, picGoc.Height);

                    cat = new Bitmap(HCN.Width, HCN.Height);

                    Graphics g = Graphics.FromImage(cat);
                    g.DrawImage(bmp, 0, 0, HCN, GraphicsUnit.Pixel);

                    picDic.Image = cat;
                }
            }
        }

        private void picGoc_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;
            VitriXY = e.Location; // lay toa do diem bat dau cat
        }

        private void picGoc_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown == true)
            {
                VitriX1Y1 = e.Location; // lay toa do diem ket thuc

                Refresh(); 
            }
        }

        private void picGoc_Paint(object sender, PaintEventArgs e)
        {
            if (HCN != null) // kiem tra vung cat
            {
                e.Graphics.DrawRectangle(Pens.Red, LayHCN()); // LayHCN() la ham ve hcn
            }
        }

        private Rectangle LayHCN()
        {
            HCN = new Rectangle();

            HCN.X = Math.Min(VitriXY.X, VitriX1Y1.X); // toa do x la min cua x bat dau va x ket thuc

            HCN.Y = Math.Min(VitriXY.Y, VitriX1Y1.Y); // toa do y la min cua y bat dau va y ket thuc

            HCN.Width = Math.Abs(VitriXY.X - VitriX1Y1.X);// chieu rong la gia tri nho nhat giua diem x bat dau va diem x hien tai

            HCN.Height = Math.Abs(VitriXY.Y - VitriX1Y1.Y);// nhu tren

            return HCN;
        }

        private void bti_quaylai_Click(object sender, EventArgs e)
        {
            FormBatDau f = new FormBatDau();
            f.Show();
            this.Hide();
        }

        private void bti_thoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn thực sự muốn thoát sao?", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
            if (dr == DialogResult.OK)
            {
                Application.Exit();
            }
        }

    }
}