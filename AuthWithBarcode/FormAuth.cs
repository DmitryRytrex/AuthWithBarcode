using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthWithBarcode
{
    public partial class FormAuth : Form
    {
        public FormAuth()
        {
            InitializeComponent();
        }

        int count = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            using (DataBase db = new DataBase())
            {
                DataTable users = db.ExecuteSql($"select * from [USERS] where UserLogin = '{login}' and UserPassword = '{password}'");

                if (users.Rows.Count > 0)
                {
                    MainForm Main = new MainForm();
                    Main.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль! Проверьте корректность введенных данных.");
                    count++;
                }
                if (count >= 3)
                {
                    FormCaptcha captcha = new FormCaptcha();
                    captcha.Show();
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count>=3)
            {
                timer1.Interval = 20000;
                timer1.Start();
                this.Visible = false;
            }
        }
    }
}
