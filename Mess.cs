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
    public partial class Mess : DevComponents.DotNetBar.RibbonForm
    {
        public Mess()
        {
            InitializeComponent();
        }
        public WebBrowser wb;
        private void Mess_Load(object sender, EventArgs e)
        {
            wb = webBrowser1;
            wb.Navigate("https://www.facebook.com/messages/new");
            
        }
    }
}