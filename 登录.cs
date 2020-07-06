using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;

namespace 族谱登陆注册
{
    public partial class 登录 : Form
    {
        public 登录()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Dno = textBox1.Text;
            string Dmm = textBox2.Text;
            if(textBox1.Text == ""||textBox2.Text == "")
            {
                MessageBox.Show("请输入账户和密码!", "警告");
            }
            //数据库连接
            string connstring = @"Data Source = LAPTOP - EB142USQ\MSSQLSERVER02; Initial Catalog = 电子族谱; Integrated Security = True";
            SqlConnection conn = new SqlConnection("connstring");
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"select * from Users where Users_id = '" + Dno + "' and Users_password = '"+ Dmm +"'";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            if(reader.HasRows)
            {
                MessageBox.Show("登陆成功!", "提示");
                //此处加入页面跳转代码
                
            }
            else
            {
                MessageBox.Show("用户名或密码错误!", "警告");
                conn.Close();
            }

        }
    }
}
