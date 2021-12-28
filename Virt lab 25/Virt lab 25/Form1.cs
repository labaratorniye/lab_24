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
        public string группаИмя = "";
        public string имя = "";
    
        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        int количествоОшибок = 0;
        bool конецРаботы = false;

        private void check_Results_Click(object sender, System.EventArgs e)
        {
            int counttable1 = 0, counttable2 = 0; // счётчик 1-ой таблицы и счётчик 2-ой таблицы
            for (int i = 0; i < 4; i++) // цикл проверки 1-ой таблицы на заполненность
            {
                if (!String.IsNullOrEmpty(Convert.ToString(таблица1.Rows[i].Cells[3].Value))) // Если строка не пустая или нулевая
                {
                    counttable1++;
                }
            }
            for (int i = 0; i < 10; i++) // цикл проверки второй таблицы на заполненность
            {
                if ((!String.IsNullOrEmpty(Convert.ToString(таблица2.Rows[i].Cells[3].Value))) && (!String.IsNullOrEmpty(Convert.ToString(таблица2.Rows[i].Cells[4].Value)))) // Если строка не пустая или нулевая
                {
                    counttable2 = counttable2 + 2;
                }
            }
            if ((counttable1 == 4) && (counttable2 == 16))
            {
                double I, R=0, U, Z, L, V = 50, w = 2 * Math.PI * V, Ieff, Ueff; 
                int ConstITrueAnswerCount=0, VarITrueAnswerCount=0, StepTable1;
                for (int i = 0; i < 4; i++) // Проверка введённых значений постоянного тока
                {
                    I = Convert.ToDouble(таблица1.Rows[i].Cells[1].Value);
                    U = Convert.ToDouble(таблица1.Rows[i].Cells[2].Value);
                    R = U / I;
                    R = Math.Round(R, 1);
                    if (R == Convert.ToDouble(таблица1.Rows[i].Cells[3].Value))
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
                    количествоОшибок = количествоОшибок + (4-ConstITrueAnswerCount);
                    конецРаботы = false;
                }
                for (int i = 0; i < 10; i++) // Проверка введённых значений переменного тока
                {
                    StepTable1 = Convert.ToInt32(таблица2.Rows[i].Cells[5].Value); // Типо id
                    Ieff = Convert.ToDouble(таблица2.Rows[i].Cells[1].Value);
                    Ueff = Convert.ToDouble(таблица2.Rows[i].Cells[2].Value);
                    Z = Ueff / Ieff;
                    Z = Math.Round(Z, 1);
                    for (int j = 0; j < 4; j++) // Поиск нужного сопротивления постоянного тока
                    {
                        if (StepTable1 == Convert.ToInt32(таблица1.Rows[j].Cells[4].Value)) // Шаг из 1-ой и 2-ой таблицы
                        {
                            I = Convert.ToDouble(таблица1.Rows[j].Cells[1].Value);
                            U = Convert.ToDouble(таблица1.Rows[j].Cells[2].Value);
                            R = U / I;
                        }
                    }
                    L = Math.Sqrt(Math.Pow(Z, 2) - Math.Pow(R, 2))/w;
                    L = Math.Round(L, 3);
                    if ((Z == Convert.ToDouble(таблица2.Rows[i].Cells[3].Value)) && (L == Convert.ToDouble(таблица2.Rows[i].Cells[4].Value)))
                    {
                        VarITrueAnswerCount++;
                    }
                }
                if (VarITrueAnswerCount == 8)
                {
                    MessageBox.Show("Измерения переменного тока вычислены верно!", "Сообщение");
                    конецРаботы = true;
                }
                else
                {
                    MessageBox.Show("Измерения переменного тока вычислены неверно!", "Сообщение");
                    количествоОшибок = количествоОшибок + (8 - VarITrueAnswerCount);
                    конецРаботы = false;
                }
            } 
            else 
            {
                MessageBox.Show("Вы не провели все измерения", "Сообщение");
            }
        }

        private void кнопкаВыйти_Клик(object sender, EventArgs e)
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
                    if (String.IsNullOrWhiteSpace(Convert.ToString(таблица1.Rows[0].Cells[1].Value)))
                    {
                        текстовоеПоле1.Text = "0,3";
                        текстовоеПоле2.Text = "9";
                        таблица1.Rows[0].Cells[1].Value = текстовоеПоле1.Text;
                        таблица1.Rows[0].Cells[2].Value = текстовоеПоле2.Text;
                        таблица1.Rows[0].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица1.Rows[1].Cells[1].Value)) && Convert.ToString(таблица1.Rows[0].Cells[1].Value) != "0,3")
                    {
                        текстовоеПоле1.Text = "0,3";
                        текстовоеПоле2.Text = "9";
                        таблица1.Rows[1].Cells[1].Value = текстовоеПоле1.Text;
                        таблица1.Rows[1].Cells[2].Value = текстовоеПоле2.Text;
                        таблица1.Rows[1].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица1.Rows[2].Cells[1].Value)) && Convert.ToString(таблица1.Rows[1].Cells[1].Value) != "0,3" && Convert.ToString(таблица1.Rows[0].Cells[1].Value) != "0,3")
                    {
                        текстовоеПоле1.Text = "0,3";
                        текстовоеПоле2.Text = "9";
                        таблица1.Rows[2].Cells[1].Value = текстовоеПоле1.Text;
                        таблица1.Rows[2].Cells[2].Value = текстовоеПоле2.Text;
                        таблица1.Rows[2].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица1.Rows[3].Cells[1].Value)) && Convert.ToString(таблица1.Rows[2].Cells[1].Value) != "0,3" && Convert.ToString(таблица1.Rows[1].Cells[1].Value) != "0,3" && Convert.ToString(таблица1.Rows[0].Cells[1].Value) != "0,3")
                    {
                        текстовоеПоле1.Text = "0,3";
                        текстовоеПоле2.Text = "9";
                        таблица1.Rows[3].Cells[1].Value = текстовоеПоле1.Text;
                        таблица1.Rows[3].Cells[2].Value = текстовоеПоле2.Text;
                        таблица1.Rows[3].Cells[4].Value = trackBar1.Value;
                    }
                }
                if (trackBar1.Value == 2)
                {
                    if (String.IsNullOrWhiteSpace(Convert.ToString(таблица1.Rows[0].Cells[1].Value)))
                    {
                        текстовоеПоле1.Text = "0,55";
                        текстовоеПоле2.Text = "15";
                        таблица1.Rows[0].Cells[1].Value = текстовоеПоле1.Text;
                        таблица1.Rows[0].Cells[2].Value = текстовоеПоле2.Text;
                        таблица1.Rows[0].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица1.Rows[1].Cells[1].Value)) && Convert.ToString(таблица1.Rows[0].Cells[1].Value) != "0,55")
                    {
                        текстовоеПоле1.Text = "0,55";
                        текстовоеПоле2.Text = "15";
                        таблица1.Rows[1].Cells[1].Value = текстовоеПоле1.Text;
                        таблица1.Rows[1].Cells[2].Value = текстовоеПоле2.Text;
                        таблица1.Rows[1].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица1.Rows[2].Cells[1].Value)) && Convert.ToString(таблица1.Rows[0].Cells[1].Value) != "0,55" && Convert.ToString(таблица1.Rows[1].Cells[1].Value) != "0,55")
                    {
                        текстовоеПоле1.Text = "0,55";
                        текстовоеПоле2.Text = "15";
                        таблица1.Rows[2].Cells[1].Value = текстовоеПоле1.Text;
                        таблица1.Rows[2].Cells[2].Value = текстовоеПоле2.Text;
                        таблица1.Rows[2].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица1.Rows[3].Cells[1].Value)) && Convert.ToString(таблица1.Rows[2].Cells[1].Value) != "0,55" && Convert.ToString(таблица1.Rows[1].Cells[1].Value) != "0,55" && Convert.ToString(таблица1.Rows[0].Cells[1].Value) != "0,55")
                    {
                        текстовоеПоле1.Text = "0,55";
                        текстовоеПоле2.Text = "15";
                        таблица1.Rows[3].Cells[1].Value = текстовоеПоле1.Text;
                        таблица1.Rows[3].Cells[2].Value = текстовоеПоле2.Text;
                        таблица1.Rows[3].Cells[4].Value = trackBar1.Value;
                    }
                }
                if (trackBar1.Value == 3)
                        {
                    if (String.IsNullOrWhiteSpace(Convert.ToString(таблица1.Rows[0].Cells[1].Value)))
                    {
                        текстовоеПоле1.Text = "0,8";
                        текстовоеПоле2.Text = "22";
                        таблица1.Rows[0].Cells[1].Value = текстовоеПоле1.Text;
                        таблица1.Rows[0].Cells[2].Value = текстовоеПоле2.Text;
                        таблица1.Rows[0].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица1.Rows[1].Cells[1].Value)) && Convert.ToString(таблица1.Rows[0].Cells[1].Value) != "0,8")
                    {
                        текстовоеПоле1.Text = "0,8";
                        текстовоеПоле2.Text = "22";
                        таблица1.Rows[1].Cells[1].Value = текстовоеПоле1.Text;
                        таблица1.Rows[1].Cells[2].Value = текстовоеПоле2.Text;
                        таблица1.Rows[1].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица1.Rows[2].Cells[1].Value)) && Convert.ToString(таблица1.Rows[0].Cells[1].Value) != "0,8" && Convert.ToString(таблица1.Rows[1].Cells[1].Value) != "0,8")
                    {
                        текстовоеПоле1.Text = "0,8";
                        текстовоеПоле2.Text = "22";
                        таблица1.Rows[2].Cells[1].Value = текстовоеПоле1.Text;
                        таблица1.Rows[2].Cells[2].Value = текстовоеПоле2.Text;
                        таблица1.Rows[2].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица1.Rows[3].Cells[1].Value)) && Convert.ToString(таблица1.Rows[2].Cells[1].Value) != "0,8" && Convert.ToString(таблица1.Rows[1].Cells[1].Value) != "0,8" && Convert.ToString(таблица1.Rows[0].Cells[1].Value) != "0,8")
                    {
                        текстовоеПоле1.Text = "0,8";
                        текстовоеПоле2.Text = "22";
                        таблица1.Rows[3].Cells[1].Value = текстовоеПоле1.Text;
                        таблица1.Rows[3].Cells[2].Value = текстовоеПоле2.Text;
                        таблица1.Rows[3].Cells[4].Value = trackBar1.Value;
                    }
                }
                if (trackBar1.Value == 4)
                {
                    if (String.IsNullOrWhiteSpace(Convert.ToString(таблица1.Rows[0].Cells[1].Value)))
                    {
                        текстовоеПоле1.Text = "1";
                        текстовоеПоле2.Text = "28";
                        таблица1.Rows[0].Cells[1].Value = текстовоеПоле1.Text;
                        таблица1.Rows[0].Cells[2].Value = текстовоеПоле2.Text;
                        таблица1.Rows[0].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица1.Rows[1].Cells[1].Value)) && Convert.ToString(таблица1.Rows[0].Cells[1].Value) != "1")
                    {
                        текстовоеПоле1.Text = "1";
                        текстовоеПоле2.Text = "28";
                        таблица1.Rows[1].Cells[1].Value = текстовоеПоле1.Text;
                        таблица1.Rows[1].Cells[2].Value = текстовоеПоле2.Text;
                        таблица1.Rows[1].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица1.Rows[2].Cells[1].Value)) && Convert.ToString(таблица1.Rows[0].Cells[1].Value) != "1" && Convert.ToString(таблица1.Rows[1].Cells[1].Value) != "1")
                    {
                        текстовоеПоле1.Text = "1";
                        текстовоеПоле2.Text = "28";
                        таблица1.Rows[2].Cells[1].Value = текстовоеПоле1.Text;
                        таблица1.Rows[2].Cells[2].Value = текстовоеПоле2.Text;
                        таблица1.Rows[2].Cells[4].Value = trackBar1.Value;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица1.Rows[3].Cells[1].Value)) && Convert.ToString(таблица1.Rows[2].Cells[1].Value) != "1" && Convert.ToString(таблица1.Rows[1].Cells[1].Value) != "1" && Convert.ToString(таблица1.Rows[0].Cells[1].Value) != "1")
                    {
                        текстовоеПоле1.Text = "1";
                        текстовоеПоле2.Text = "28";
                        таблица1.Rows[3].Cells[1].Value = текстовоеПоле1.Text;
                        таблица1.Rows[3].Cells[2].Value = текстовоеПоле2.Text;
                        таблица1.Rows[3].Cells[4].Value = trackBar1.Value;
                    }
                }
            } // постоянный ток


            if (radioButton2.Checked == true) 
            {
                if (комбоКоробка.Text == "Катушка без сердечника") // Катушка без сердечника
                {
                    if (trackBar1.Value == 0)
                    {
                        MessageBox.Show("Выберите шаг отличный от нуля", "Сообщение");
                    }
                    if (trackBar1.Value == 1)
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[1].Cells[1].Value)))
                        {
                            текстовоеПоле1.Text = "0,2";
                            текстовоеПоле2.Text = "8";
                            таблица2.Rows[1].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[1].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[1].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[2].Cells[1].Value)) && Convert.ToString(таблица2.Rows[1].Cells[1].Value) != "0,2")
                        {
                            текстовоеПоле1.Text = "0,2";
                            текстовоеПоле2.Text = "8";
                            таблица2.Rows[2].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[2].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[2].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[3].Cells[1].Value)) && Convert.ToString(таблица2.Rows[2].Cells[1].Value) != "0,2" && Convert.ToString(таблица2.Rows[1].Cells[1].Value) != "0,2")
                        {
                            текстовоеПоле1.Text = "0,2";
                            текстовоеПоле2.Text = "8";
                            таблица2.Rows[3].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[3].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[3].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[4].Cells[1].Value)) && Convert.ToString(таблица2.Rows[3].Cells[1].Value) != "0,2" && Convert.ToString(таблица2.Rows[2].Cells[1].Value) != "0,2" && Convert.ToString(таблица2.Rows[1].Cells[1].Value) != "0,2")
                        {
                            текстовоеПоле1.Text = "0,2";
                            текстовоеПоле2.Text = "8";
                            таблица2.Rows[4].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[4].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[4].Cells[5].Value = trackBar1.Value;
                        }
                    }
                    if (trackBar1.Value == 2)
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[1].Cells[1].Value)))
                        {
                            текстовоеПоле1.Text = "0,35";
                            текстовоеПоле2.Text = "14";
                            таблица2.Rows[1].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[1].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[1].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[2].Cells[1].Value)) && Convert.ToString(таблица2.Rows[1].Cells[1].Value) != "0,35")
                        {
                            текстовоеПоле1.Text = "0,35";
                            текстовоеПоле2.Text = "14";
                            таблица2.Rows[2].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[2].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[2].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[3].Cells[1].Value)) && Convert.ToString(таблица2.Rows[2].Cells[1].Value) != "0,35" && Convert.ToString(таблица2.Rows[1].Cells[1].Value) != "0,35")
                        {
                            текстовоеПоле1.Text = "0,35";
                            текстовоеПоле2.Text = "14";
                            таблица2.Rows[3].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[3].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[3].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[4].Cells[1].Value)) && Convert.ToString(таблица2.Rows[3].Cells[1].Value) != "0,35" && Convert.ToString(таблица2.Rows[2].Cells[1].Value) != "0,35" && Convert.ToString(таблица2.Rows[1].Cells[1].Value) != "0,35")
                        {
                            текстовоеПоле1.Text = "0,35";
                            текстовоеПоле2.Text = "14";
                            таблица2.Rows[4].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[4].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[4].Cells[5].Value = trackBar1.Value;
                        }
                    }
                    if (trackBar1.Value == 3)
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[1].Cells[1].Value)))
                        {
                            текстовоеПоле1.Text = "0,5";
                            текстовоеПоле2.Text = "21";
                            таблица2.Rows[1].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[1].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[1].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[2].Cells[1].Value)) && Convert.ToString(таблица2.Rows[1].Cells[1].Value) != "0,5")
                        {
                            текстовоеПоле1.Text = "0,5";
                            текстовоеПоле2.Text = "21";
                            таблица2.Rows[2].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[2].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[2].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[3].Cells[1].Value)) && Convert.ToString(таблица2.Rows[2].Cells[1].Value) != "0,5" && Convert.ToString(таблица2.Rows[1].Cells[1].Value) != "0,5")
                        {
                            текстовоеПоле1.Text = "0,5";
                            текстовоеПоле2.Text = "21";
                            таблица2.Rows[3].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[3].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[3].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[4].Cells[1].Value)) && Convert.ToString(таблица2.Rows[3].Cells[1].Value) != "0,5" && Convert.ToString(таблица2.Rows[2].Cells[1].Value) != "0,5" && Convert.ToString(таблица2.Rows[1].Cells[1].Value) != "0,5")
                        {
                            текстовоеПоле1.Text = "0,5";
                            текстовоеПоле2.Text = "21";
                            таблица2.Rows[4].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[4].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[4].Cells[5].Value = trackBar1.Value;
                        }
                    }
                    if (trackBar1.Value == 4)
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[1].Cells[1].Value)))
                        {
                            текстовоеПоле1.Text = "0,65";
                            текстовоеПоле2.Text = "27";
                            таблица2.Rows[1].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[1].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[1].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[2].Cells[1].Value)) && Convert.ToString(таблица2.Rows[1].Cells[1].Value) != "0,65")
                        {
                            текстовоеПоле1.Text = "0,65";
                            текстовоеПоле2.Text = "27";
                            таблица2.Rows[2].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[2].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[2].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[3].Cells[1].Value)) && Convert.ToString(таблица2.Rows[2].Cells[1].Value) != "0,65" && Convert.ToString(таблица2.Rows[1].Cells[1].Value) != "0,65")
                        {
                            текстовоеПоле1.Text = "0,65";
                            текстовоеПоле2.Text = "27";
                            таблица2.Rows[3].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[3].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[3].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[4].Cells[1].Value)) && Convert.ToString(таблица2.Rows[3].Cells[1].Value) != "0,65" && Convert.ToString(таблица2.Rows[2].Cells[1].Value) != "0,65" && Convert.ToString(таблица2.Rows[1].Cells[1].Value) != "0,65")
                        {
                            текстовоеПоле1.Text = "0,65";
                            текстовоеПоле2.Text = "27";
                            таблица2.Rows[4].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[4].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[4].Cells[5].Value = trackBar1.Value;
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
                        if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[6].Cells[1].Value)))
                        {
                            текстовоеПоле1.Text = "0,12";
                            текстовоеПоле2.Text = "12,8";
                            таблица2.Rows[6].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[6].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[6].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[7].Cells[1].Value)) && Convert.ToString(таблица2.Rows[6].Cells[1].Value) != "0,12")
                        {
                            текстовоеПоле1.Text = "0,12";
                            текстовоеПоле2.Text = "12,8";
                            таблица2.Rows[7].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[7].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[7].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[8].Cells[1].Value)) && Convert.ToString(таблица2.Rows[7].Cells[1].Value) != "0,12" && Convert.ToString(таблица2.Rows[6].Cells[1].Value) != "0,12")
                        {
                            текстовоеПоле1.Text = "0,12";
                            текстовоеПоле2.Text = "12,8";
                            таблица2.Rows[8].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[8].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[8].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[9].Cells[1].Value)) && Convert.ToString(таблица2.Rows[8].Cells[1].Value) != "0,12" && Convert.ToString(таблица2.Rows[7].Cells[1].Value) != "0,12" && Convert.ToString(таблица2.Rows[6].Cells[1].Value) != "0,12")
                        {
                            текстовоеПоле1.Text = "0,12";
                            текстовоеПоле2.Text = "12,8";
                            таблица2.Rows[9].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[9].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[9].Cells[5].Value = trackBar1.Value;
                        }
                    }
                    if (trackBar1.Value == 2)
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[6].Cells[1].Value)))
                        {
                            текстовоеПоле1.Text = "0,21";
                            текстовоеПоле2.Text = "22,4";
                            таблица2.Rows[6].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[6].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[6].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[7].Cells[1].Value)) && Convert.ToString(таблица2.Rows[6].Cells[1].Value) != "0,21")
                        {
                            текстовоеПоле1.Text = "0,21";
                            текстовоеПоле2.Text = "22,4";
                            таблица2.Rows[7].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[7].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[7].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[8].Cells[1].Value)) && Convert.ToString(таблица2.Rows[7].Cells[1].Value) != "0,21" && Convert.ToString(таблица2.Rows[6].Cells[1].Value) != "0,21")
                        {
                            текстовоеПоле1.Text = "0,21";
                            текстовоеПоле2.Text = "22,4";
                            таблица2.Rows[8].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[8].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[8].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[9].Cells[1].Value)) && Convert.ToString(таблица2.Rows[8].Cells[1].Value) != "0,21" && Convert.ToString(таблица2.Rows[7].Cells[1].Value) != "0,21" && Convert.ToString(таблица2.Rows[6].Cells[1].Value) != "0,21")
                        {
                            текстовоеПоле1.Text = "0,21";
                            текстовоеПоле2.Text = "22,4";
                            таблица2.Rows[9].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[9].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[9].Cells[5].Value = trackBar1.Value;
                        }
                    }
                    if (trackBar1.Value == 3)
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[6].Cells[1].Value)))
                        {
                            текстовоеПоле1.Text = "0,3";
                            текстовоеПоле2.Text = "33,6";
                            таблица2.Rows[6].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[6].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[6].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[7].Cells[1].Value)) && Convert.ToString(таблица2.Rows[6].Cells[1].Value) != "0,3")
                        {
                            текстовоеПоле1.Text = "0,3";
                            текстовоеПоле2.Text = "33,6";
                            таблица2.Rows[7].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[7].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[7].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[8].Cells[1].Value)) && Convert.ToString(таблица2.Rows[7].Cells[1].Value) != "0,3" && Convert.ToString(таблица2.Rows[6].Cells[1].Value) != "0,3")
                        {
                            текстовоеПоле1.Text = "0,3";
                            текстовоеПоле2.Text = "33,6";
                            таблица2.Rows[8].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[8].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[8].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[9].Cells[1].Value)) && Convert.ToString(таблица2.Rows[8].Cells[1].Value) != "0,3" && Convert.ToString(таблица2.Rows[7].Cells[1].Value) != "0,3" && Convert.ToString(таблица2.Rows[6].Cells[1].Value) != "0,3")
                        {
                            текстовоеПоле1.Text = "0,3";
                            текстовоеПоле2.Text = "33,6";
                            таблица2.Rows[9].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[9].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[9].Cells[5].Value = trackBar1.Value;
                        }
                    }
                    if (trackBar1.Value == 4)
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[6].Cells[1].Value)))
                        {
                            текстовоеПоле1.Text = "0,39";
                            текстовоеПоле2.Text = "43,2";
                            таблица2.Rows[6].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[6].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[6].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[7].Cells[1].Value)) && Convert.ToString(таблица2.Rows[6].Cells[1].Value) != "0,39")
                        {
                            текстовоеПоле1.Text = "0,39";
                            текстовоеПоле2.Text = "43,2";
                            таблица2.Rows[7].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[7].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[7].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[8].Cells[1].Value)) && Convert.ToString(таблица2.Rows[7].Cells[1].Value) != "0,39" && Convert.ToString(таблица2.Rows[6].Cells[1].Value) != "0,39")
                        {
                            текстовоеПоле1.Text = "0,39";
                            текстовоеПоле2.Text = "43,2";
                            таблица2.Rows[8].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[8].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[8].Cells[5].Value = trackBar1.Value;
                        }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(таблица2.Rows[9].Cells[1].Value)) && Convert.ToString(таблица2.Rows[8].Cells[1].Value) != "0,39" && Convert.ToString(таблица2.Rows[7].Cells[1].Value) != "0,39" && Convert.ToString(таблица2.Rows[6].Cells[1].Value) != "0,39")
                        {
                            текстовоеПоле1.Text = "0,39";
                            текстовоеПоле2.Text = "43,2";
                            таблица2.Rows[9].Cells[1].Value = текстовоеПоле1.Text;
                            таблица2.Rows[9].Cells[2].Value = текстовоеПоле2.Text;
                            таблица2.Rows[9].Cells[5].Value = trackBar1.Value;
                        }
                    }
                }
            } // переменный ток
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            таблица1.Hide();
            таблица2.Hide();
            таблица1.ForeColor = Color.Black;
            таблица2.BackgroundColor = Color.Black;
            таблица1.AutoResizeColumns();
            таблица1.AutoResizeRows();



            

            картинкаКоробка1.Hide();
            картинкаКоробка2.Hide();
            богатаяТекстоваяКоробка1.Hide();
            богатаяТекстоваяКоробка2.Hide();
            radioButton1.Checked = true; // Выбор активного типа тока 
            таблица1.RowHeadersVisible = false;
            таблица2.RowHeadersVisible = false;
            таблица2.AllowUserToResizeRows = false;
            int количества1 = 0;
            int колонки1 = 4;
            for (int i = 0; i < колонки1; i++) // заполнение 1-3 1 таблицы постоянного тока 
            {
                таблица1.Rows.Add();
                таблица1.Rows[i].Cells[0].Value = количества1 + 1;
                количества1++;
            }

            таблица1.Rows[0].Height = 54;
            таблица1.Rows[1].Height = 55;
            таблица1.Rows[2].Height = 55;
            таблица1.Rows[3].Height = 55;

            таблица1.Columns[0].Width = 100;
            таблица1.Columns[1].Width = 100;
            таблица1.Columns[2].Width = 100;
            таблица1.Columns[3].Width = 100;

            таблица1.Width = 220;
            int количества2 = 0;
            int колонки2 = 10;

            таблица2.Rows.Add(10);
            for (int i = 0; i < колонки2; i++)    // заполнение всех строк 2 таблицы переменного тока      // Строки 0,4 не проверяем на значения, они должны быть пустые!
            {
                if ((i == 0) || (i == 5))
                {
                    количества2 = 0;
                }
                else
                {
                    таблица2.Rows[i].Cells[0].Value = количества2 + 1;
                    количества2++;
                }

            }




        }


        Form3 методичка = new Form3();
        Form2 taskList = new Form2();
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            методичка.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            taskList.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (конецРаботы)
            {
                Protocol протокольчик = new Protocol();
                протокольчик.группаИмя = группаИмя;
                протокольчик.полноеИмя = имя;
                протокольчик.количествоОшибок = количествоОшибок;
                протокольчик.Show();
            } else
            {
                MessageBox.Show("Выполните работу в полном объеме!");
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            таблица1.Show();
            таблица2.Hide();
            богатаяТекстоваяКоробка1.Hide();
            богатаяТекстоваяКоробка2.Hide();
            картинкаКоробка1.Hide();
            картинкаКоробка2.Show();
            комбоКоробка.Enabled = false;
            комбоКоробка.SelectedIndex = -1;
            trackBar1.Value = 0;
            текстовоеПоле1.Text = "";
            текстовоеПоле2.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            таблица1.Hide();
            таблица2.Show();
            богатаяТекстоваяКоробка1.Show();
            богатаяТекстоваяКоробка2.Show();
            картинкаКоробка1.Show();
            картинкаКоробка2.Hide();
            комбоКоробка.Enabled = true;
            комбоКоробка.SelectedItem = комбоКоробка.Items[0];
            trackBar1.Value = 0;
            текстовоеПоле1.Text = "";
            текстовоеПоле2.Text = "";
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

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
