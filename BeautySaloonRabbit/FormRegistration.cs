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
    public partial class FormRegistration : Form
    {
        Пользователи пользователи = new Пользователи();
        Сотрудники сотрудники = new Сотрудники();
        Роль роль = new Роль();
        public FormRegistration()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e) // Возврат на форму входа
        {
            Form ifrm = Application.OpenForms[0];
            Close();
            ifrm.Show();
        }

        private void FormRegistration_Load(object sender, EventArgs e)
        {
            рольBindingSource.DataSource = Program.db.Роль.ToList();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            пользователи.Логин = логинTextBox.Text;
            пользователи.Пароль = парольTextBox.Text;
            пользователи.IDРоли = Int32.Parse(iDРолиTextBox.Text);
            сотрудники.Имя = имяTextBox.Text;
            сотрудники.Фамилия = фамилияTextBox.Text;
            сотрудники.Отчество = отчествоTextBox.Text;
            сотрудники.НомерТелефона = номерТелефонаTextBox.Text;
            сотрудники.Должность = должностьTextBox.Text;


            try
            {
                Program.db.Пользователи.Add(пользователи);
                Program.db.Сотрудники.Add(сотрудники);
                Program.db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Ошибка произошла.");
            }
            Form ifrm = Application.OpenForms[0];
            Close();
            ifrm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            роль.ID = Int32.Parse(iDTextBox.Text);
            роль.Наименование = наименованиеTextBox.Text;
            try
            {
                Program.db.Роль.Add(роль);
                Program.db.SaveChanges();
                рольBindingSource.DataSource = Program.db.Роль.ToList();
            }
            catch
            {
                MessageBox.Show("Ошибка произошла.");
            }
        }
    }
}
