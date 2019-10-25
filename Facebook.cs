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
    public partial class Facebook : DevComponents.DotNetBar.RibbonForm
    {
        public Facebook()
        {
            InitializeComponent();
        }
        public WebBrowser wb;

        private void FormShare_Load(object sender, EventArgs e)
        {
            wb = webBrowser1;
            wb.Navigate("http://www.facebook.com/groups/1495660450564476/");
        }
    }
}