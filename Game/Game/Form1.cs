using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        ///Иницилазация основных  публичных переменных 
        static int mas_lenght = 8; /// Размерность поля в нашем случае 8на8
        Color ConObjR = Color.Red;
        Color ConObjB = Color.Blue;
        Color[] arri = new Color[] { Color.CadetBlue, Color.Pink }; // Алфавит нашего поля (пока поддерживает всего два цвета)
        PictureBox[,] mass = new PictureBox[mas_lenght, mas_lenght];//Игровое цветное поле
        double[,] p = new double[mas_lenght,mas_lenght]; //Массив для распределения поля вероятностей
        List<string> way = new List<string>();           //история команд передвижения
        List<Color> color_history = new List<Color>();   //Динамический массив для записи истории с его датчиков
        Color star;                                      // Буфер для запоминания переменной
        double sum = 0;


        //Функция задача которой проверять на каком метсе находиться робот и менять цвет клетки
        public void Color_chek(ref PictureBox[,] mass)
        {
            star = mass[Robot.X, Robot.Y].BackColor;
            if (mass[Robot.X,Robot.Y].BackColor == Color.CadetBlue)
                mass[Robot.X, Robot.Y].BackColor = ConObjB;
            else if (mass[Robot.X, Robot.Y].BackColor == Color.Pink)
                mass[Robot.X, Robot.Y].BackColor = ConObjR;
            color_history.Add(star);
            
            Probabilityi();
            Text123();
        }

        //Тестовая функция(не удалаять)
        public void Text123()
        {
            richTextBox1.Clear();
            for (int i = 0; i < mas_lenght; i++) {
                richTextBox1.Text += "\n";
                for (int j = 0; j < mas_lenght; j++)
                    //richTextBox1.AppendText(String.Format("{0:0.000}", p[i,j]).ToString() + " ");
                    richTextBox1.AppendText(String.Format("{0:0.0}", p[i, j]*100).ToString() + "% ");
            }
            richTextBox1.Text += "\n\n";
            //richTextBox1.Text += "\n";
            for (int i = 0; i < way.Count; i++)
                richTextBox1.Text += way[i];
            richTextBox1.Text += "\n";
            for (int i = 0; i < color_history.Count; i++)
                richTextBox1.Text += color_history[i];
            
        }
       
        //Предугадывания местоположения робота в зависимости от его пройденного пути
        public void Probabilityi()
        {
            sum = 0;
            for (int i = 0; i < mas_lenght; i++)
                for (int j = 0; j < mas_lenght; j++)
                {
                    double cof = 0;
                    int mixture_x = 0;
                    int mixture_y = 0;
                    //for (int k = 0;k < way.Count ; k++)
                    if (color_history[way.Count - 1] == star)
                        cof += Robot.pHit;
                    else
                        cof += Robot.pMiss;


                    for (int k = way.Count-2; k >= 0; k--)
                    {
                        if (color_history[k] == mass[(i - mixture_x + mas_lenght) % mas_lenght, (j - mixture_y + mas_lenght) % mas_lenght].BackColor)
                            cof += Robot.pHit;
                        else
                            cof += Robot.pMiss;

                        if (way[k] == "Up")              //Проход по обратному пути
                            mixture_y++;
                        else if (way[k] == "Down")
                            mixture_y--;
                        else if (way[k] == "Left")
                            mixture_x--;
                        else if (way[k] == "Right")
                            mixture_x++;
                    }
                    p[i, j] *= cof+1;
                    sum += p[i, j];    
                }
            for (int i = 0; i < mas_lenght; i++)
                for (int j = 0; j < mas_lenght; j++)
                    p[i, j] /= sum;
        }
    
        //Иницилизация поля 
        private void Form1_Load(object sender, EventArgs e)
        {
            mass[0, 0] = pictureBox19;
            mass[0, 1] = pictureBox20;
            mass[0, 2] = pictureBox21;
            mass[0, 3] = pictureBox22;
            mass[0, 4] = pictureBox23;
            mass[0, 5] = pictureBox24;
            mass[0, 6] = pictureBox25;
            mass[0, 7] = pictureBox26;
            mass[1, 0] = pictureBox27;
            mass[1, 1] = pictureBox28;
            mass[1, 2] = pictureBox29;
            mass[1, 3] = pictureBox30;
            mass[1, 4] = pictureBox31;
            mass[1, 5] = pictureBox32;
            mass[1, 6] = pictureBox33;
            mass[1, 7] = pictureBox34;
            mass[2, 0] = pictureBox35;
            mass[2, 1] = pictureBox36;
            mass[2, 2] = pictureBox37;
            mass[2, 3] = pictureBox38;
            mass[2, 4] = pictureBox39;
            mass[2, 5] = pictureBox40;
            mass[2, 6] = pictureBox41;
            mass[2, 7] = pictureBox42;
            mass[3, 0] = pictureBox43;
            mass[3, 1] = pictureBox44;
            mass[3, 2] = pictureBox45;
            mass[3, 3] = pictureBox46;
            mass[3, 4] = pictureBox47;
            mass[3, 5] = pictureBox48;
            mass[3, 6] = pictureBox49;
            mass[3, 7] = pictureBox50;
            mass[4, 0] = pictureBox51;
            mass[4, 1] = pictureBox52;
            mass[4, 2] = pictureBox53;
            mass[4, 3] = pictureBox54;
            mass[4, 4] = pictureBox55;
            mass[4, 5] = pictureBox56;
            mass[4, 6] = pictureBox57;
            mass[4, 7] = pictureBox58;
            mass[5, 0] = pictureBox59;
            mass[5, 1] = pictureBox60;
            mass[5, 2] = pictureBox61;
            mass[5, 3] = pictureBox62;
            mass[5, 4] = pictureBox63;
            mass[5, 5] = pictureBox64;
            mass[5, 6] = pictureBox65;
            mass[5, 7] = pictureBox66;
            mass[6, 0] = pictureBox67;
            mass[6, 1] = pictureBox68;
            mass[6, 2] = pictureBox69;
            mass[6, 3] = pictureBox70;
            mass[6, 4] = pictureBox71;
            mass[6, 5] = pictureBox72;
            mass[6, 6] = pictureBox73;
            mass[6, 7] = pictureBox74;
            mass[7, 0] = pictureBox75;
            mass[7, 1] = pictureBox76;
            mass[7, 2] = pictureBox77;
            mass[7, 3] = pictureBox78;
            mass[7, 4] = pictureBox79;
            mass[7, 5] = pictureBox80;
            mass[7, 6] = pictureBox81;
            mass[7, 7] = pictureBox82;

            var rand = new Random();

            for (int i = 0; i < mas_lenght; i++)
                for (int j = 0; j < mas_lenght; j++) {
                    mass[i, j].BackColor = arri[rand.Next(arri.Length)];
                    p[i, j] = 1.0 / (mas_lenght * mas_lenght);
                        }

          
            star = mass[0,0].BackColor;

        }

        //Заполнить поле рандомным цветом
        private void button1_Click(object sender, EventArgs e) 
        {
            var rand = new Random();

            for (int i = 0; i < mas_lenght; i++)
                for (int j = 0; j < mas_lenght; j++)
                    mass[i, j].BackColor = arri[rand.Next(arri.Length)];
                    
        }
        //Кнопка отвечаюшая за случайный спавн робоота
        private void button2_Click(object sender, EventArgs e)
        {
            mass[Robot.X, Robot.Y].BackColor = star;
            
            var rand = new Random();
            Robot.X = rand.Next(mas_lenght);
            Robot.Y = rand.Next(mas_lenght);

            way.Clear();              // Новое положение новая история
            color_history.Clear();
            star = mass[Robot.X, Robot.Y].BackColor;
            if (mass[Robot.X, Robot.Y].BackColor == Color.CadetBlue)
                mass[Robot.X, Robot.Y].BackColor = ConObjB;
            else if (mass[Robot.X, Robot.Y].BackColor == Color.Pink)
                mass[Robot.X, Robot.Y].BackColor = ConObjR;
            color_history.Add(star);
            

        }


        //Четыре подфункции для управлением движением робота
        private void vpered_Click(object sender, EventArgs e)
        {
           mass[Robot.X, Robot.Y].BackColor = star;
            if (Robot.X == 0)
                Robot.X = 7;
            else
                Robot.X -= 1;
            way.Add("Up");
            Color_chek(ref mass);
        }

        private void nazad_Click(object sender, EventArgs e)
        {
            mass[Robot.X, Robot.Y].BackColor = star;
            if (Robot.X == 7)
                Robot.X = 0;
            else
                Robot.X += 1;
            way.Add("Down");
            Color_chek(ref mass);

        }

        private void levo_Click(object sender, EventArgs e)
        {
            mass[Robot.X, Robot.Y].BackColor = star;

            if (Robot.Y == 0)
                Robot.Y = 7;
            else
                Robot.Y-= 1;
            way.Add("Left");
            Color_chek(ref mass);
        }

        private void pravo_Click(object sender, EventArgs e)
        {
            mass[Robot.X, Robot.Y].BackColor = star;

            if (Robot.Y == 7)
                Robot.Y = 0;
            else
                Robot.Y += 1;
            way.Add("Right");
            Color_chek(ref mass);
        }

        //Нужна только для теста
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
