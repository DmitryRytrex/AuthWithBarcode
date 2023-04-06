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
    public partial class FormCaptcha : Form
    {
        public FormCaptcha()
        {
            InitializeComponent();
            Captcha_();
        }
        private int num;
        private string captcha = "";
        private int stop = 0;


        public void Captcha_()
        {
            Random rand = new Random();
            int num = rand.Next(6, 8);
            captcha = "";
            int totl = 0;
            do
            {
                int chr = rand.Next(48, 123);
                if ((chr >= 48 && chr <= 57) || (chr >= 65 && chr <= 90) || (chr >= 97 && chr <= 122))
                {
                    captcha = captcha + (char)chr;
                    totl++;
                    if (totl > num)
                        break;
                    {
                    }
                }
            } while (true);
            label1.Text = captcha;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == captcha)
            {

                MessageBox.Show("Проверка пройдена!");
                FormAuth Auth = new FormAuth();
                Auth.Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show("Вы не прошли проверку. Закрытие приложения");
                stop++;
                ;

            }
            if (stop == 1)
            {

                Application.Exit();

            }
        }
    }
}
