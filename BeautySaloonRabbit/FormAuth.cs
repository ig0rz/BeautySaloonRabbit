using BeautySaloonRabbit.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeautySaloonRabbit
{
    public partial class FormAuth : Form
    {
        public FormAuth()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Введите логин и/или пароль.");
                return;
            }

            try
            {
            Пользователи пользователь = Program.db.Пользователи.Where(u => u.Логин == textBoxLogin.Text).Single();

            string usrLogin = пользователь.Логин;
            string usrPass = пользователь.Пароль;

                if (usrLogin == textBoxLogin.Text && usrPass == textBoxPassword.Text) //Проверка введенных данных
                {
                    switch (пользователь.IDРоли)//Переход на форму соответствующую роли
                    {
                        case 1:
                            FormAdmin formAdmin = new FormAdmin();
                            formAdmin.Show();
                            Hide();
                            break;
                        case 2:
                            FormHairdresser formHairdresser = new FormHairdresser();
                            formHairdresser.Show();
                            Hide();
                            break;
                        case 3:
                            FormRestyler formRestyler = new FormRestyler();
                            formRestyler.Show();
                            Hide();
                            break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Неверный логин или пароль. Введите капчу");

                FormCaptcha formCaptcha = new FormCaptcha();
                DialogResult dialogResult = formCaptcha.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    MessageBox.Show("Каптча подтверждена");
                }
            } 
        }

        private void FormAuth_Load(object sender, EventArgs e)
        {

        }

        private void buttonClientAuth_Click(object sender, EventArgs e) //Переход на форму клиента
        {
            FormClient formClient = new FormClient();
            formClient.Show();
            Hide();
        }

        private void linkLabelRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) // Переход на форму регистрации
        {
            FormRegistration formRegistration = new FormRegistration();
            formRegistration.Show();
            Hide();
        }
    }
}
