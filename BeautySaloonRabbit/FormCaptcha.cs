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
    public partial class FormCaptcha : Form
    {
        static Random rnd = new Random();//Для обновления капчи
        int randomInt = rnd.Next(1, 4);
        public FormCaptcha()
        {
            InitializeComponent();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            createImage();//Обновление капчи
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (((textBoxCaptcha.Text == "smwm" || textBoxCaptcha.Text == "SMWM") && randomInt == 1)|| //Проверка капчи
               ((textBoxCaptcha.Text == "s82s" || textBoxCaptcha.Text == "S82S") && randomInt == 2) ||
               ((textBoxCaptcha.Text == "0096") && randomInt == 3) ||
               ((textBoxCaptcha.Text == "2vyk" || textBoxCaptcha.Text == "2VYK") && randomInt == 4))

            {
                DialogResult = DialogResult.OK; //Капча пройдена
            }
            else
            {
                MessageBox.Show("Капча введена неверно, попробуйте снова.");
                textBoxCaptcha.Text = "";
                return;
            }
        }

        private void createImage() //Метод для показа капчи
        {
            randomInt = rnd.Next(1, 4);
            switch (randomInt) //Показ рандомной капчи
            {
                case 1:
                    pictureBoxCaptcha.Image = Properties.Resources.captcha1 as Bitmap;
                    break;
                case 2:
                    pictureBoxCaptcha.Image = Properties.Resources.captcha2 as Bitmap;
                    break;
                case 3:
                    pictureBoxCaptcha.Image = Properties.Resources.captcha3 as Bitmap;
                    break;
                case 4:
                    pictureBoxCaptcha.Image = Properties.Resources.captcha4 as Bitmap;
                    break;
            }
        }

        private void FormCaptcha_Load(object sender, EventArgs e)
        {
            createImage();//Показ капчи при загрузке формы
        }
    }
}
