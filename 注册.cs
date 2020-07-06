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
    public partial class 注册 : Form
    {
        public 注册()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Dno = textBox1.Text;
            string Dmm = textBox2.Text;
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("请输入注册账户和密码!", "警告");
            }
            if(textBox3.Text!= textBox4.Text)
            {
                MessageBox.Show("两次密码输入不一致！", "警告");
            }
            else
            {
                string connstring = @"Data Source = LAPTOP - EB142USQ\MSSQLSERVER02; Initial Catalog = 电子族谱; Integrated Security = True";
                SqlConnection conn = new SqlConnection(connstring);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = @"select * from Users where Users_id = '" + Dno + "' and Users_password = '" + Dmm + "'";
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    MessageBox.Show("该账户已注册，请使用其他账户", "提示");
                }
                else
                {
                    reader.Close();
                    string myinsert = "insert into Users(Users_id,Users_name,Users_password) values ('" + textBox1.Text + "','" + textBox2 + "','" + textBox3 + "'";
                    SqlCommand mycom = new SqlCommand(myinsert, conn);
                    mycom.ExecuteNonQuery();
                    conn.Close();
                    conn.Dispose();
                    MessageBox.Show("您已注册成功！");
                    //此处输入页面跳转代码
                }

            }
        }
    }
}
