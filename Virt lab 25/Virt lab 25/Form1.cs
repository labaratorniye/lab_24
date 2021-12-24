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
        public string groupName = "";
        public string name = "";
        public Form1()
        {
            InitializeComponent();
        }

        int ErrorCount = 0;

        private void check_Results_Click(object sender, System.EventArgs e)
        {
            int counttable1 = 0, counttable2 = 0; // счётчик 1-ой таблицы и счётчик 2-ой таблицы
            for (int i = 0; i < 4; i++) // цикл проверки 1-ой таблицы на заполненность
            {
                if (!String.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells[3].Value))) // Если строка не пустая или нулевая
                {
                    counttable1++;
                }
            }
            for (int i = 0; i < 10; i++) // цикл проверки второй таблицы на заполненность
            {
                if ((!String.IsNullOrEmpty(Convert.ToString(dataGridView2.Rows[i].Cells[3].Value))) && (!String.IsNullOrEmpty(Convert.ToString(dataGridView2.Rows[i].Cells[4].Value)))) // Если строка не пустая или нулевая
                {
                    counttable2 = counttable2 + 2;
                }
            }
            if ((counttable1 == 4) && (counttable2 == 16))
            {
                double I, R=0, U, Z, L, V = 50, w = 2 * Math.PI * V; 
                int ConstITrueAnswerCount=0, VarITrueAnswerCount=0, StepTable1;
                for (int i = 0; i < 4; i++) // Проверка введённых значений постоянного тока
                {
                    I = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                    U = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                    R = U / I;
                    R = Math.Round(R, 1);
                    if (R == Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value))
                    {
                        ConstITrueAnswerCount++;
                    }
                }
                if (ConstITrueAnswerCount == 4)
                {
                    MessageBox.Show("Измерения постоянного тока вычислены верно!", "Сообщение");
                }
                else
                {
                    MessageBox.Show("Измерения постоянного тока вычислены неверно!", "Сообщение");
                    ErrorCount = ErrorCount + (4-ConstITrueAnswerCount);
                }
                for (int i = 0; i < 10; i++) // Проверка введённых значений переменного тока
                {
                    StepTable1 = Convert.ToInt32(dataGridView2.Rows[i].Cells[5].Value); // Типо id
                    I = Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value);
                    U = Convert.ToDouble(dataGridView2.Rows[i].Cells[2].Value);
                    Z = U / I;
                    Z = Math.Round(Z, 1);
                    for (int j = 0; j < 4; j++) // Поиск нужного сопротивления постоянного тока
                    {
                        if (StepTable1 == Convert.ToInt32(dataGridView1.Rows[j].Cells[4].Value))
                        {
                            R = Convert.ToDouble(dataGridView1.Rows[j].Cells[3].Value);
                        }
                    }
                    L = Math.Sqrt(Math.Pow(Z, 2) - Math.Pow(R, 2))/w;
                    L = Math.Round(L, 4);
                    if ((Z == Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value)) && (L == Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value)))
                    {
                        VarITrueAnswerCount++;
                    }
                }
                if (VarITrueAnswerCount == 8)
                {
                    MessageBox.Show("Измерения переменного тока вычислены верно!", "Сообщение");
                }
                else
                {
                    MessageBox.Show("Измерения переменного тока вычислены неверно!", "Сообщение");
                    ErrorCount = ErrorCount + (8 - VarITrueAnswerCount);
                }
            } 
            else 
            {
                MessageBox.Show("Вы не провели все измерения", "Сообщение");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {//trackBar1.Enabled = true; блокирую просто ползунок после 3 измерений(команда для Саши), для включения в переменном токе
            if (radioButton1.Checked == true)
            {
                if (trackBar1.Value == 0)
                {
                    MessageBox.Show("Выберите шаг отличный от нуля", "Сообщение");
                }
                if (trackBar1.Value == 1)
                {
                    if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[0].Cells[1].Value)))
                    {
                        textBox1.Text = "0,3";
                        textBox2.Text = "9";
                        dataGridView1.Rows[0].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[0].Cells[2].Value = textBox2.Text;
                        dataGridView1.Rows[0].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[1].Cells[1].Value)) && Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != "0,3")
                    {
                        textBox1.Text = "0,3";
                        textBox2.Text = "9";
                        dataGridView1.Rows[1].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[1].Cells[2].Value = textBox2.Text;
                        dataGridView1.Rows[1].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[2].Cells[1].Value)) && Convert.ToString(dataGridView1.Rows[1].Cells[1].Value) != "0,3" && Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != "0,3")
                    {
                        textBox1.Text = "0,3";
                        textBox2.Text = "9";
                        dataGridView1.Rows[2].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[2].Cells[2].Value = textBox2.Text;
                        dataGridView1.Rows[2].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[3].Cells[1].Value)) && Convert.ToString(dataGridView1.Rows[2].Cells[1].Value) != "0,3" && Convert.ToString(dataGridView1.Rows[1].Cells[1].Value) != "0,3" && Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != "0,3")
                    {
                        textBox1.Text = "0,3";
                        textBox2.Text = "9";
                        dataGridView1.Rows[3].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[3].Cells[2].Value = textBox2.Text;
                        dataGridView1.Rows[3].Cells[4].Value = trackBar1.Value;
                    }
                }
                if (trackBar1.Value == 2)
                {
                    if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[0].Cells[1].Value)))
                    {
                        textBox1.Text = "0,55";
                        textBox2.Text = "15";
                        dataGridView1.Rows[0].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[0].Cells[2].Value = textBox2.Text;
                        dataGridView1.Rows[0].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[1].Cells[1].Value)) && Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != "0,55")
                    {
                        textBox1.Text = "0,55";
                        textBox2.Text = "15";
                        dataGridView1.Rows[1].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[1].Cells[2].Value = textBox2.Text;
                        dataGridView1.Rows[1].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[2].Cells[1].Value)) && Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != "0,55" && Convert.ToString(dataGridView1.Rows[1].Cells[1].Value) != "0,55")
                    {
                        textBox1.Text = "0,55";
                        textBox2.Text = "15";
                        dataGridView1.Rows[2].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[2].Cells[2].Value = textBox2.Text;
                        dataGridView1.Rows[2].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[3].Cells[1].Value)) && Convert.ToString(dataGridView1.Rows[2].Cells[1].Value) != "0,55" && Convert.ToString(dataGridView1.Rows[1].Cells[1].Value) != "0,55" && Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != "0,55")
                    {
                        textBox1.Text = "0,55";
                        textBox2.Text = "15";
                        dataGridView1.Rows[3].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[3].Cells[2].Value = textBox2.Text;
                        dataGridView1.Rows[3].Cells[4].Value = trackBar1.Value;
                    }
                }
                if (trackBar1.Value == 3)
                        {
                    if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[0].Cells[1].Value)))
                    {
                        textBox1.Text = "0,8";
                        textBox2.Text = "22";
                        dataGridView1.Rows[0].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[0].Cells[2].Value = textBox2.Text;
                        dataGridView1.Rows[0].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[1].Cells[1].Value)) && Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != "0,8")
                    {
                        textBox1.Text = "0,8";
                        textBox2.Text = "22";
                        dataGridView1.Rows[1].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[1].Cells[2].Value = textBox2.Text;
                        dataGridView1.Rows[1].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[2].Cells[1].Value)) && Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != "0,8" && Convert.ToString(dataGridView1.Rows[1].Cells[1].Value) != "0,8")
                    {
                        textBox1.Text = "0,8";
                        textBox2.Text = "22";
                        dataGridView1.Rows[2].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[2].Cells[2].Value = textBox2.Text;
                        dataGridView1.Rows[2].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[3].Cells[1].Value)) && Convert.ToString(dataGridView1.Rows[2].Cells[1].Value) != "0,8" && Convert.ToString(dataGridView1.Rows[1].Cells[1].Value) != "0,8" && Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != "0,8")
                    {
                        textBox1.Text = "0,8";
                        textBox2.Text = "22";
                        dataGridView1.Rows[3].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[3].Cells[2].Value = textBox2.Text;
                        dataGridView1.Rows[3].Cells[4].Value = trackBar1.Value;
                    }
                }
                if (trackBar1.Value == 4)
                {
                    if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[0].Cells[1].Value)))
                    {
                        textBox1.Text = "1";
                        textBox2.Text = "28";
                        dataGridView1.Rows[0].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[0].Cells[2].Value = textBox2.Text;
                        dataGridView1.Rows[0].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[1].Cells[1].Value)) && Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != "1")
                    {
                        textBox1.Text = "1";
                        textBox2.Text = "28";
                        dataGridView1.Rows[1].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[1].Cells[2].Value = textBox2.Text;
                        dataGridView1.Rows[1].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[2].Cells[1].Value)) && Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != "1" && Convert.ToString(dataGridView1.Rows[1].Cells[1].Value) != "1")
                    {
                        textBox1.Text = "1";
                        textBox2.Text = "28";
                        dataGridView1.Rows[2].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[2].Cells[2].Value = textBox2.Text;
                        dataGridView1.Rows[2].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[3].Cells[1].Value)) && Convert.ToString(dataGridView1.Rows[2].Cells[1].Value) != "1" && Convert.ToString(dataGridView1.Rows[1].Cells[1].Value) != "1" && Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != "1")
                    {
                        textBox1.Text = "1";
                        textBox2.Text = "28";
                        dataGridView1.Rows[3].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[3].Cells[2].Value = textBox2.Text;
                        dataGridView1.Rows[3].Cells[4].Value = trackBar1.Value;
                    }
                }
            } // постоянный ток


            if (radioButton2.Checked == true) 
            {
                if (comboBox1.Text == "Катушка без сердечника") // Катушка без сердечника
                {
                    if (trackBar1.Value == 0)
                    {
                        MessageBox.Show("Выберите шаг отличный от нуля", "Сообщение");
                    }
                    if (trackBar1.Value == 1)
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[1].Cells[1].Value)))
                        {
                            textBox1.Text = "0,2";
                            textBox2.Text = "8";
                            dataGridView2.Rows[1].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[1].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[1].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[2].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[1].Cells[1].Value) != "0,2")
                        {
                            textBox1.Text = "0,2";
                            textBox2.Text = "8";
                            dataGridView2.Rows[2].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[2].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[2].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[3].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[2].Cells[1].Value) != "0,2" && Convert.ToString(dataGridView2.Rows[1].Cells[1].Value) != "0,2")
                        {
                            textBox1.Text = "0,2";
                            textBox2.Text = "8";
                            dataGridView2.Rows[3].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[3].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[3].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[4].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[3].Cells[1].Value) != "0,2" && Convert.ToString(dataGridView2.Rows[2].Cells[1].Value) != "0,2" && Convert.ToString(dataGridView2.Rows[1].Cells[1].Value) != "0,2")
                        {
                            textBox1.Text = "0,2";
                            textBox2.Text = "8";
                            dataGridView2.Rows[4].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[4].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[4].Cells[5].Value = trackBar1.Value;
                        }
                    }
                    if (trackBar1.Value == 2)
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[1].Cells[1].Value)))
                        {
                            textBox1.Text = "0,35";
                            textBox2.Text = "14";
                            dataGridView2.Rows[1].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[1].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[1].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[2].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[1].Cells[1].Value) != "0,35")
                        {
                            textBox1.Text = "0,35";
                            textBox2.Text = "14";
                            dataGridView2.Rows[2].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[2].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[2].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[3].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[2].Cells[1].Value) != "0,35" && Convert.ToString(dataGridView2.Rows[1].Cells[1].Value) != "0,35")
                        {
                            textBox1.Text = "0,35";
                            textBox2.Text = "14";
                            dataGridView2.Rows[3].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[3].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[3].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[4].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[3].Cells[1].Value) != "0,35" && Convert.ToString(dataGridView2.Rows[2].Cells[1].Value) != "0,35" && Convert.ToString(dataGridView2.Rows[1].Cells[1].Value) != "0,35")
                        {
                            textBox1.Text = "0,35";
                            textBox2.Text = "14";
                            dataGridView2.Rows[4].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[4].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[4].Cells[5].Value = trackBar1.Value;
                        }
                    }
                    if (trackBar1.Value == 3)
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[1].Cells[1].Value)))
                        {
                            textBox1.Text = "0,5";
                            textBox2.Text = "21";
                            dataGridView2.Rows[1].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[1].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[1].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[2].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[1].Cells[1].Value) != "0,5")
                        {
                            textBox1.Text = "0,5";
                            textBox2.Text = "21";
                            dataGridView2.Rows[2].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[2].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[2].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[3].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[2].Cells[1].Value) != "0,5" && Convert.ToString(dataGridView2.Rows[1].Cells[1].Value) != "0,5")
                        {
                            textBox1.Text = "0,5";
                            textBox2.Text = "21";
                            dataGridView2.Rows[3].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[3].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[3].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[4].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[3].Cells[1].Value) != "0,5" && Convert.ToString(dataGridView2.Rows[2].Cells[1].Value) != "0,5" && Convert.ToString(dataGridView2.Rows[1].Cells[1].Value) != "0,5")
                        {
                            textBox1.Text = "0,5";
                            textBox2.Text = "21";
                            dataGridView2.Rows[4].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[4].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[4].Cells[5].Value = trackBar1.Value;
                        }
                    }
                    if (trackBar1.Value == 4)
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[1].Cells[1].Value)))
                        {
                            textBox1.Text = "0,65";
                            textBox2.Text = "27";
                            dataGridView2.Rows[1].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[1].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[1].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[2].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[1].Cells[1].Value) != "0,65")
                        {
                            textBox1.Text = "0,65";
                            textBox2.Text = "27";
                            dataGridView2.Rows[2].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[2].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[2].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[3].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[2].Cells[1].Value) != "0,65" && Convert.ToString(dataGridView2.Rows[1].Cells[1].Value) != "0,65")
                        {
                            textBox1.Text = "0,65";
                            textBox2.Text = "27";
                            dataGridView2.Rows[3].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[3].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[3].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[4].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[3].Cells[1].Value) != "0,65" && Convert.ToString(dataGridView2.Rows[2].Cells[1].Value) != "0,65" && Convert.ToString(dataGridView2.Rows[1].Cells[1].Value) != "0,65")
                        {
                            textBox1.Text = "0,65";
                            textBox2.Text = "27";
                            dataGridView2.Rows[4].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[4].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[4].Cells[5].Value = trackBar1.Value;
                        }
                    }
                }
                else // Катушка с сердечником
                {
                    if (trackBar1.Value == 0)
                    {
                        MessageBox.Show("Выберите шаг отличный от нуля", "Сообщение");
                    }
                    if (trackBar1.Value == 1)
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[6].Cells[1].Value)))
                        {
                            textBox1.Text = "0,12";
                            textBox2.Text = "12,8";
                            dataGridView2.Rows[6].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[6].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[6].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[7].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[6].Cells[1].Value) != "0,12")
                        {
                            textBox1.Text = "0,12";
                            textBox2.Text = "12,8";
                            dataGridView2.Rows[7].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[7].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[7].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[8].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[7].Cells[1].Value) != "0,12" && Convert.ToString(dataGridView2.Rows[6].Cells[1].Value) != "0,12")
                        {
                            textBox1.Text = "0,12";
                            textBox2.Text = "12,8";
                            dataGridView2.Rows[8].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[8].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[8].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[9].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[8].Cells[1].Value) != "0,12" && Convert.ToString(dataGridView2.Rows[7].Cells[1].Value) != "0,12" && Convert.ToString(dataGridView2.Rows[6].Cells[1].Value) != "0,12")
                        {
                            textBox1.Text = "0,12";
                            textBox2.Text = "12,8";
                            dataGridView2.Rows[9].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[9].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[9].Cells[5].Value = trackBar1.Value;
                        }
                    }
                    if (trackBar1.Value == 2)
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[6].Cells[1].Value)))
                        {
                            textBox1.Text = "0,21";
                            textBox2.Text = "22,4";
                            dataGridView2.Rows[6].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[6].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[6].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[7].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[6].Cells[1].Value) != "0,21")
                        {
                            textBox1.Text = "0,21";
                            textBox2.Text = "22,4";
                            dataGridView2.Rows[7].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[7].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[7].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[8].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[7].Cells[1].Value) != "0,21" && Convert.ToString(dataGridView2.Rows[6].Cells[1].Value) != "0,21")
                        {
                            textBox1.Text = "0,21";
                            textBox2.Text = "22,4";
                            dataGridView2.Rows[8].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[8].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[8].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[9].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[8].Cells[1].Value) != "0,21" && Convert.ToString(dataGridView2.Rows[7].Cells[1].Value) != "0,21" && Convert.ToString(dataGridView2.Rows[6].Cells[1].Value) != "0,21")
                        {
                            textBox1.Text = "0,21";
                            textBox2.Text = "22,4";
                            dataGridView2.Rows[9].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[9].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[9].Cells[5].Value = trackBar1.Value;
                        }
                    }
                    if (trackBar1.Value == 3)
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[6].Cells[1].Value)))
                        {
                            textBox1.Text = "0,3";
                            textBox2.Text = "33,6";
                            dataGridView2.Rows[6].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[6].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[6].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[7].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[6].Cells[1].Value) != "0,3")
                        {
                            textBox1.Text = "0,3";
                            textBox2.Text = "33,6";
                            dataGridView2.Rows[7].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[7].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[7].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[8].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[7].Cells[1].Value) != "0,3" && Convert.ToString(dataGridView2.Rows[6].Cells[1].Value) != "0,3")
                        {
                            textBox1.Text = "0,3";
                            textBox2.Text = "33,6";
                            dataGridView2.Rows[8].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[8].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[8].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[9].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[8].Cells[1].Value) != "0,3" && Convert.ToString(dataGridView2.Rows[7].Cells[1].Value) != "0,3" && Convert.ToString(dataGridView2.Rows[6].Cells[1].Value) != "0,3")
                        {
                            textBox1.Text = "0,3";
                            textBox2.Text = "33,6";
                            dataGridView2.Rows[9].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[9].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[9].Cells[5].Value = trackBar1.Value;
                        }
                    }
                    if (trackBar1.Value == 4)
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[6].Cells[1].Value)))
                        {
                            textBox1.Text = "0,39";
                            textBox2.Text = "43,2";
                            dataGridView2.Rows[6].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[6].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[6].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[7].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[6].Cells[1].Value) != "0,39")
                        {
                            textBox1.Text = "0,39";
                            textBox2.Text = "43,2";
                            dataGridView2.Rows[7].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[7].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[7].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[8].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[7].Cells[1].Value) != "0,39" && Convert.ToString(dataGridView2.Rows[6].Cells[1].Value) != "0,39")
                        {
                            textBox1.Text = "0,39";
                            textBox2.Text = "43,2";
                            dataGridView2.Rows[8].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[8].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[8].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView2.Rows[9].Cells[1].Value)) && Convert.ToString(dataGridView2.Rows[8].Cells[1].Value) != "0,39" && Convert.ToString(dataGridView2.Rows[7].Cells[1].Value) != "0,39" && Convert.ToString(dataGridView2.Rows[6].Cells[1].Value) != "0,39")
                        {
                            textBox1.Text = "0,39";
                            textBox2.Text = "43,2";
                            dataGridView2.Rows[9].Cells[1].Value = textBox1.Text;
                            dataGridView2.Rows[9].Cells[2].Value = textBox2.Text;
                            dataGridView2.Rows[9].Cells[5].Value = trackBar1.Value;
                        }
                    }
                }
            } // переменный ток
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView2.Hide();
            pictureBox1.Hide();
            pictureBox2.Hide();
            richTextBox1.Hide();
            richTextBox2.Hide();
            radioButton1.Checked = true; // Выбор активного типа тока 
            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.AllowUserToResizeRows = false;
            int quantity1 = 0;
            int columns1 = 4;
            for (int i = 0; i < columns1; i++) // заполнение 1-3 1 таблицы постоянного тока 
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = quantity1 + 1;
                quantity1++;
            }
            int quantity2 = 0;
            int columns2 = 10;

            dataGridView2.Rows.Add(10);
            for (int i = 0; i < columns2; i++)    // заполнение всех строк 2 таблицы переменного тока      // Строки 0,4 не проверяем на значения, они должны быть пустые!
            {
                if ((i == 0) || (i == 5))
                {
                    quantity2 = 0;
                }
                else
                {
                    dataGridView2.Rows[i].Cells[0].Value = quantity2 + 1;
                    quantity2++;
                }

            }




        }


        Form3 metodichka = new Form3();
        Form2 taskList = new Form2();
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
            Protocol protocol = new Protocol();
            protocol.groupName = groupName;
            protocol.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Show();
            dataGridView2.Hide();
            richTextBox1.Hide();
            richTextBox2.Hide();
            pictureBox1.Hide();
            pictureBox2.Show();
            comboBox1.Enabled = false;
            comboBox1.SelectedIndex = -1;
            trackBar1.Value = 0;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView2.Show();
            richTextBox1.Show();
            richTextBox2.Show();
            pictureBox1.Show();
            pictureBox2.Hide();
            comboBox1.Enabled = true;
            comboBox1.SelectedItem = comboBox1.Items[0];
            trackBar1.Value = 0;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            trackBar1.Enabled = true;
            trackBar1.Value = 0;
        }
    }
}
