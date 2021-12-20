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


        private void check_Results_Click(object sender, System.EventArgs e)
        {
            if (trackBar1.Enabled == false)
            {
                if((Convert.ToString(dataGridView1.Rows[0].Cells[3].Value) == "45") || (Convert.ToString(dataGridView1.Rows[1].Cells[3].Value) == "45") || (Convert.ToString(dataGridView1.Rows[2].Cells[3].Value) == "45"))
                {
                    if ((Convert.ToString(dataGridView1.Rows[0].Cells[3].Value) == "27,2") || (Convert.ToString(dataGridView1.Rows[1].Cells[3].Value) == "27,2") || (Convert.ToString(dataGridView1.Rows[2].Cells[3].Value) == "27,2"))
                    {
                        if ((Convert.ToString(dataGridView1.Rows[0].Cells[3].Value) == "27,5") || (Convert.ToString(dataGridView1.Rows[1].Cells[3].Value) == "27,5") || (Convert.ToString(dataGridView1.Rows[2].Cells[3].Value) == "27,5"))
                        {
                            MessageBox.Show("Измерения постоянного тока вычислены верно", "Сообщение");
                        }
                    }
                }else
                {
                    MessageBox.Show("Измерения постоянного тока вычислены неверно", "Сообщение");
                }
            } else    // проверка значений постоянного тока 
            {
                MessageBox.Show("Вы не провели все измерения", "Сообщение");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {                                 //trackBar1.Enabled = true; блокирую просто ползунок после 3 измерений(команда для Саши), для включения в переменном токе

            if (radioButton1.Checked == true)
            {


                if (trackBar1.Value == 1)
                {
                    if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[0].Cells[1].Value)))
                    {
                        trackBar1.Enabled = true;
                        textBox1.Text = "0,2";
                        textBox2.Text = "9";
                        dataGridView1.Rows[0].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[0].Cells[2].Value = textBox2.Text;


                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[1].Cells[1].Value)) && Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != "0,2")
                    {
                        textBox1.Text = "0,2";
                        textBox2.Text = "9";
                        dataGridView1.Rows[1].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[1].Cells[2].Value = textBox2.Text;


                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[2].Cells[1].Value)) && Convert.ToString(dataGridView1.Rows[1].Cells[1].Value) != "0,2" && Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != "0,2")
                    {
                        textBox1.Text = "0,2";
                        textBox2.Text = "9";
                        dataGridView1.Rows[2].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[2].Cells[2].Value = textBox2.Text;
                        trackBar1.Enabled = false;

                    }
                }
                if (trackBar1.Value == 2)
                {
                    if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[0].Cells[1].Value)))
                    {
                        trackBar1.Enabled = true;
                        textBox1.Text = "0,55";
                        textBox2.Text = "15";
                        dataGridView1.Rows[0].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[0].Cells[2].Value = textBox2.Text;

                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[1].Cells[1].Value)) && Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != "0,55")
                    {
                        textBox1.Text = "0,55";
                        textBox2.Text = "15";
                        dataGridView1.Rows[1].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[1].Cells[2].Value = textBox2.Text;
                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[2].Cells[1].Value)) && Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != "0,55" && Convert.ToString(dataGridView1.Rows[1].Cells[1].Value) != "0,55")
                    {
                        textBox1.Text = "0,55";
                        textBox2.Text = "15";
                        dataGridView1.Rows[2].Cells[1].Value = textBox1.Text;
                        dataGridView1.Rows[2].Cells[2].Value = textBox2.Text;
                        trackBar1.Enabled = false;

                    }
                }
                if (trackBar1.Value == 3)
                    {
                        if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[0].Cells[1].Value)))
                        {
                        trackBar1.Enabled = true;
                        textBox1.Text = "0,8";
                            textBox2.Text = "22";
                            dataGridView1.Rows[0].Cells[1].Value = textBox1.Text;
                            dataGridView1.Rows[0].Cells[2].Value = textBox2.Text;

                    }
                    else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[1].Cells[1].Value)) && Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != "0,8")
                        {
                            textBox1.Text = "0,8";
                            textBox2.Text = "22";
                            dataGridView1.Rows[1].Cells[1].Value = textBox1.Text;
                            dataGridView1.Rows[1].Cells[2].Value = textBox2.Text;
                    }
                        else if (String.IsNullOrWhiteSpace(Convert.ToString(dataGridView1.Rows[2].Cells[1].Value)) && Convert.ToString(dataGridView1.Rows[0].Cells[1].Value) != "0,8" && Convert.ToString(dataGridView1.Rows[1].Cells[1].Value) != "0,8")
                        {
                            textBox1.Text = "0,8";
                            textBox2.Text = "22";
                            dataGridView1.Rows[2].Cells[1].Value = textBox1.Text;
                            dataGridView1.Rows[2].Cells[2].Value = textBox2.Text;
                        trackBar1.Enabled = false;
                    }
                    }

                
                
            } // постоянный ток


            if (radioButton2.Checked == true) 
            {

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
            int columns1 = 3;
            for (int i = 0; i < columns1; i++) // заполнение 1-3 1 таблицы постоянного тока 
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = quantity1 + 1;
                quantity1++;
            }
            int quantity2 = 0;
            int columns2 = 8;

            dataGridView2.Rows.Add(8);
            for (int i = 0; i < columns2; i++)    // заполнение всех строк 2 таблицы переменного тока      // Строки 0,4 не проверяем на значения, они должны быть пустые!
            {
                if ((i == 0) || (i == 4))
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


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView2.Show();
            richTextBox1.Show();
            richTextBox2.Show();
            pictureBox1.Show();
            pictureBox2.Hide();

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
    }
}
