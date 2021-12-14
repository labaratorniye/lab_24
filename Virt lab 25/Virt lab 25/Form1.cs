using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Virt_lab_25
{
    //Application.Run(new Register());
    public partial class Form1 : Form
    {
        private bool startButtonClicked = false;
        public string name = "Пишите T с двумя знаками после запятой, а g с одним";
        public string groupName = "";

        public int minimumLenght = 0;
        public int maximumLenght = 0;
        private int countErrors = 0;
        
        public bool isChechResultsClicked = false;
        public bool isWorkWasSuccess = false;

        //public double amountOfFluctations;
        public double solutionForProblemNumber;
        public Form1()
        {
            
            InitializeComponent();
            pictureBox1.Enabled = false;
            pictureBox6.BackColor = Color.Transparent;

            timer1.Interval = 10;
        }

        private dynamic converDataFromTable(int row, int column)
        {
            if (dataGridView1.Rows[row].Cells[column].Value == null)
            {
                showTextBox("ячейки значений T пусты", "Сообщение");
                return null;
            }
            else
            {
                return (Convert.ToDouble(dataGridView1.Rows[row].Cells[column].Value));
            }
        }

        bool checkIsEqual(double periodCalculated, double periodInATable)
        {
            return (periodCalculated == periodInATable);
        }

        private void check_Results_Click(object sender, System.EventArgs e)
        {
            int countErrorRightNow = 0;
            isChechResultsClicked = true; // Переменная отвечающая за то, были результаты проверены или нет.
            Register reg = new Register();
            // проверка значений в таблице, сначала проверяю 6 измерений или нет, затем что значения T не равны нулю(введены), затем что g == 9.8, если работает то должно выдаваться "всё ок", иначе соответсвующие сообщения
            bool isAmountOfDataCorrect = dataGridView1.Rows.Count == 6;
            if (isAmountOfDataCorrect)
            {
                //double g = 0;
                for (int row = 0; row <= 5; row++)
                {
                    double timeFromTable = converDataFromTable(row, 2);
                    double periodInATable = converDataFromTable(row, 4);
                    bool isGNotNull = dataGridView1.Rows[row].Cells[5].Value != null;

                    if (isGNotNull)
                    {
                        var gForce = converDataFromTable(row, 5);
                        if (Convert.ToDouble(dataGridView1.Rows[row].Cells[1].Value) == 0.32)
                        {
                            if (gForce == 9.8 && (periodInATable == 1.14))
                            {
                                //showTextBox("Успешно преобразовали T", "Сообщение");
                            }
                            else
                            {
                                //showTextBox("Плохо преобразовали", "Сообщение");
                                countErrors++;
                                countErrorRightNow++;
                            }
                        }
                        else if (Convert.ToDouble(dataGridView1.Rows[row].Cells[1].Value) == 0.46)
                        {
                            if (gForce == 9.8 && (periodInATable == 1.36))
                            {
                                 //showTextBox("Успешно преобразовали T", "Сообщение");
                            }
                            else
                            {
                                //showTextBox("Плохо преобразовали", "Сообщение");
                                countErrors++;
                                countErrorRightNow++;
                            }
                        }
                        else if (Convert.ToDouble(dataGridView1.Rows[row].Cells[1].Value) == 0.48)
                        {
                            if (gForce == 9.8 && (periodInATable == 1.39))
                            {
                                //showTextBox("Успешно преобразовали T", "Сообщение");
                            }
                            else
                            {
                                //showTextBox("Плохо преобразовали", "Сообщение");
                                countErrorRightNow++;
                                countErrors++;
                            }
                        }
                        else
                        {
                            if (gForce == 9.8 && checkIsEqual(timeFromTable, periodInATable * 10))
                            {
                               //showTextBox("Успешно преобразовали T", "Сообщение");
                            }
                            else
                            {
                                //showTextBox("Плохо преобразовали", "Сообщение");
                                countErrorRightNow++;
                                countErrors++;
                            }
                        }
                    }

                }
                // showTextBox("OK", "Сообщение");
                if (countErrorRightNow == 0)
                {
                    MessageBox.Show("Ошибок нет!");
                    isWorkWasSuccess = true;
                }
                else
                {
                    isWorkWasSuccess = false;
                    showTextBox("Работа проведена с ошибками!", "Сообщение");
                }

            }
            else
            {
                showTextBox("Ошибка", "КОЛ-ВА ИЗМЕРЕНИЙ НЕ СООТВЕТСВУЮТ ДРУГ ДРУГУ");
                countErrors++;
            }
        }



        int quantity = 0; // Счетчик измерений 
        double Atime = 0; // время 10 колебаний 

        bool checkGValue(float amountOfFluctations, float tsmall, float tbig)
        {
            if ((tsmall / amountOfFluctations) == tbig)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Form3 metodichka = new Form3();
        private void button3_Click(object sender, EventArgs e)
        {
            metodichka.Show();
        }
        Form2 taskList = new Form2();
        private void button5_Click(object sender, EventArgs e)
        {
            taskList.Show();
        }
        double time = 0;
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false) // проверка на выбор длины
            {
                showTextBox("Выберите диапазон длины нити, для того чтобы начать измерения", "Сообщение");
            }
            else
            {
                if (quantity <= 5) // проверка на количество измерений 
                {
                    int length = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
                    Point Origin = new Point(pictureBox1.Width / 2, 0);
                    float Length = length * 3;
                    Point Bob = new Point(Origin.X, (int)Length);
                    Graphics G = pictureBox1.CreateGraphics();
                    Pen pen;
                    float Angle = (float)Math.PI / 13;
                    float AnglularVelocity = -0.01f;
                    float AngularAcceleration = 0.0f;
                    timer1.Interval = 10;
                    startButtonClicked = true;
                    timer1.Enabled = false;
                    timer1.Start();
                    this.Invalidate();
                    double g, l, T, t, n;
                    Register reg = new Register();
                    //n = reg.amountOfFluctationsInput;
                    n = 10;
                    //n = (int)amountOfFluctations;
                    l = Convert.ToDouble(numericUpDown1.Value) / 100;
                    bool check = false;
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        if (l == Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value))
                        {
                            showTextBox("Вы уже провели измерение с данной длиной", "Сообщение");
                            check = true;
                        }
                    }
                    if (check == false)
                    {
                        quantity++;
                        int number = dataGridView1.Rows.Add();
                        dataGridView1.Rows[number].Cells[1].Value = l;
                        g = 9.8;
                        g = Math.Round(g, 2);
                        T = 2 * Math.PI * Math.Sqrt(l / g);
                        T = Math.Round(T, 2);
                        t = T * n;
                        t = Math.Round(t, 2);
                        if (l == 0.32)
                        {
                            solutionForProblemNumber = T;
                        }
                        time = t;
                        Atime = Atime + time;

                        // textBox1.Text = Convert.ToString(t); ?
                        dataGridView1.Rows[number].Cells[0].Value = number + 1;  // вписываем номер № действия
                        dataGridView1.Rows[number].Cells[0].ReadOnly = true; // Блокировка ввода номера опыта

                        //dataGridView1.Rows[number].Cells[1].Value = l; // вписываем длину нити
                        dataGridView1.Rows[number].Cells[1].ReadOnly = true; // Блокировка ввода длины нити 

                        dataGridView1.Rows[number].Cells[2].Value = time; // ввод времени t
                        dataGridView1.Rows[number].Cells[2].ReadOnly = true; // Блокировка ввода времени t

                        dataGridView1.Rows[number].Cells[3].Value = n; // кол-во колебаний, всегда 10
                        dataGridView1.Rows[number].Cells[3].ReadOnly = true; // Блокировка ввода количества колебаний
                        dataGridView1.Rows[number].Cells[4].Value = 0;
                        dataGridView1.Rows[number].Cells[5].Value = 0;
                        
                        dataGridView1.Columns[4].DefaultCellStyle.BackColor = Color.Bisque;
                        dataGridView1.Columns[5].DefaultCellStyle.BackColor = Color.Bisque;
                    }
                    Brush brush = Brushes.Gray;
                    pen = new Pen(Color.Black, 2);
                    do
                    {

                        Bob.X = (int)(Length * Math.Sin(Angle) + Origin.X);
                        Bob.Y = (int)(Length * Math.Cos(Angle) + Origin.Y);

                        Angle += AnglularVelocity;
                        AnglularVelocity += AngularAcceleration;

                        AnglularVelocity *= (float)0.99;

                        //  G.DrawLine(pen, Origin.X, Origin.Y, Bob.X, Bob.Y);
                        G.DrawLine(pen, Origin.X, Origin.Y, Bob.X, Bob.Y);
                        // G.DrawEllipse(pen, Bob.X - 17, Bob.Y, 40, 40);
                        G.FillEllipse(brush, Bob.X - 8, Bob.Y - 2, 17, 17);
                        Application.DoEvents();


                        Thread.Sleep(14);
                        pictureBox1.Refresh();
                        AngularAcceleration = (float)(-0.01 * Math.Sin(Angle));
                        G.FillEllipse(brush, Bob.X - 8, Bob.Y - 2, 17, 17);
                        // G.DrawLine(pen, Origin.X, Origin.Y, Bob.X, Bob.Y);
                        //      G.DrawEllipse(pen, Bob.X - 17, Bob.Y, 40, 40);


                    } while (timer1.Enabled);

                    AngularAcceleration = 0;
                    Angle = 0;
                    AnglularVelocity = 0;

                }
                else
                {
                    showTextBox("Вы провели максимальное число измерений", "Сообщение");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 10;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox6.Hide();
            pictureBox7.Hide();
            pictureBox8.Hide();
        }
        static bool checkNumberText(object number)
        {
            if (!double.TryParse(number.ToString(), out _))
            {
                return (false);
            }
            else
            {
                return (true);
            }

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!checkNumberText(dataGridView1[e.ColumnIndex, e.RowIndex].Value))
            {
                MessageBox.Show("Некоректные данные(Формат записи дробей: 1,33)");
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = "";
            }
        }


        private void showTextBox(String message, String description)
        {
            MessageBox.Show(
                   message,
                   description);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        decimal numericValue = 30;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > numericValue)
            {
                pictureBox8.Top = pictureBox8.Top + 53;
            }
            else
            {
                pictureBox8.Top = pictureBox8.Top - 53;
            }
            numericValue = numericUpDown1.Value;
            //label2.Text = numericUpDown1.Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isChechResultsClicked == true)
            {
                minimumLenght = Convert.ToInt32(numericUpDown1.Minimum);
                maximumLenght = Convert.ToInt32(numericUpDown1.Maximum);
                
                Protocol protocol = new Protocol();
                protocol.fullName = name;
                protocol.groupName = groupName;
                protocol.countErrors = countErrors;
                protocol.isWorkWasSuccess = this.isWorkWasSuccess;
                protocol.minimumLenght = minimumLenght;
                protocol.maximumLenght = maximumLenght;
                protocol.Show();
            }
            else
            {
                showTextBox("Проверьте результаты", "Пожалуйста");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            metodichka.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            taskList.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (isChechResultsClicked == true)
            {
                minimumLenght = Convert.ToInt32(numericUpDown1.Minimum);
                maximumLenght = Convert.ToInt32(numericUpDown1.Maximum);
                
                Protocol protocol = new Protocol();
                protocol.fullName = name;
                protocol.groupName = groupName;
                protocol.countErrors = countErrors;
                protocol.isWorkWasSuccess = this.isWorkWasSuccess;
                protocol.minimumLenght = minimumLenght;
                protocol.maximumLenght = maximumLenght;
                protocol.Show();
            }
            else
            {
                showTextBox("Проверьте результаты", "Пожалуйста");
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены в своём выборе?", "Сообщение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                numericUpDown1.Value = 30;
                numericUpDown1.Minimum = 30;
                numericUpDown1.Maximum = 40;
                numericUpDown1.Enabled = true;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                pictureBox5.Hide();
                pictureBox7.Hide();
                pictureBox8.Show();
                pictureBox6.Show();
            }
            else
            {
                radioButton1.Checked = false;
            }
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены в своём выборе?", "Сообщение", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                numericUpDown1.Value = 40;
                numericUpDown1.Minimum = 40;
                numericUpDown1.Maximum = 50;
                numericUpDown1.Enabled = true;
                radioButton2.Enabled = false;
                radioButton1.Enabled = false;
                pictureBox7.Show();
                pictureBox5.Hide();
                pictureBox8.Show();
                pictureBox5.Hide();
                pictureBox8.Top = pictureBox8.Top - 50;
            }
            else
            {
                radioButton2.Checked = false;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {


        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}