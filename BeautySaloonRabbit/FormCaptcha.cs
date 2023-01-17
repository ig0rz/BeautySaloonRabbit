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
        Random rnd = new Random();//Для обновления капчи
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

        }

        private void createImage() //Метод для показа капчи
        {


            switch (rnd.Next(1, 4)) //Показ рандомной капчи
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
