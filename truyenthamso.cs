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
    public partial class truyenthamso : Form
    {
        public truyenthamso()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Bạn chưa nhập giá trị nào!");
            else
            this.Close();
        }

        private void truyenthamso_Load(object sender, EventArgs e)
        {
            
            this.AcceptButton = button1;
        }
        public TextBox TextBox1_Form2
        {
            get
            {
                return textBox1;
            }
            set
            {
                textBox1 = value;
            }
        }
    }
}
