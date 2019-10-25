using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace demo_xử_lý_ảnh
{
    public partial class DoiMau : Form
    {

        public DoiMau()
        {
            InitializeComponent();


        }

        private void DoiMau_Load(object sender, EventArgs e)
        {
            this.AcceptButton = ok;
            this.CancelButton = cancel;
        }

        public int red
        {
            get
            {
                return (Convert.ToInt32(Red.Text, 10));
            }
            set { Red.Text = value.ToString(); }
        }

        public int green
        {
            get
            {
                return (Convert.ToInt32(Green.Text, 10));
            }
            set { Green.Text = value.ToString(); }
        }

        public int blue
        {
            get
            {
                return (Convert.ToInt32(Blue.Text, 10));
            }
            set { Blue.Text = value.ToString(); }
        }

        public TextBox maured
        {
            get
            {
                return Red;
            }
            set
            {
                Red = value;
            }
        }
        public TextBox maublue
        {
            get
            {
                return Blue;
            }
            set
            {
                Blue = value;
            }
        }
        public TextBox maugreen
        {
            get
            {
                return Green;
            }
            set
            {
                Green = value;
            }
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (Red.Text == "" || Blue.Text == "" || Green.Text == "")
                MessageBox.Show("Bạn chưa nhập giá trị nào!");
            else
                this.Close();
        }
    }
}
