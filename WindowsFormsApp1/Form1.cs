using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        bool vis = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void closebutton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Скрыть/показать пароль
        private void button3_Click(object sender, EventArgs e)
        {
            if (vis)
            {
                textBox2.UseSystemPasswordChar = false;
                vis = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                vis = true;
            }
        }
        // Ввод данных для авторизации, с проверкой  на правильность.
        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username == "admin" && password == "12345")
            {
                MessageBox.Show("Вы успешно авторизовались!", "Авторизация успешна", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form Form2 = new Form2();
                Form2.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Неправильное имя пользователя или пароль!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Clear();
                textBox2.Focus();
            }

        }
    }
}
