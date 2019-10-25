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
    public partial class Gmail : DevComponents.DotNetBar.RibbonForm
    {
        public Gmail()
        {
            InitializeComponent();
        }
        public WebBrowser wb1;
        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void Gmail_Load(object sender, EventArgs e)
        {
            wb1 = webBrowser1;
            wb1.Navigate("https://mail.google.com/mail/u/0/#inbox?compose=new");
        }
    }
}