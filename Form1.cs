using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 族谱登陆注册
{
    public partial class 登陆注册 : Form
    {
        public 登陆注册()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            登录 f = new 登录();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            注册 z = new 注册();
            z.Show();
            this.Hide();
        }
    }
}
