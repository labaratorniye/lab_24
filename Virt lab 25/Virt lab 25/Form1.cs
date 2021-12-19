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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
        }


        
    private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView2.Hide();
            richTextBox1.Hide();
            richTextBox2.Hide();
            richTextBox3.Hide();
            dataGridView1.RowHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.AllowUserToResizeRows = false;
            int quantity1 = 0;
            int columns1 = 3;
            for (int i = 0; i < columns1; i++) // заполнение 1-3 строки 1 таблицы постоянного тока 
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = quantity1 + 1;
                quantity1++;
            }
            int quantity2 = 0;
            int columns2 = 12;

             dataGridView2.Rows.Add(12);
            for (int i = 0; i < columns2; i++)           // заполнение всех строк 2 таблицы переменного тока      // Строки 0,4,8 не проверяем на значения, они должны быть пустые!
            {
                if((i == 0) || (i==4) || (i==8))
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
            richTextBox3.Hide();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            dataGridView2.Show();
            richTextBox1.Show();
            richTextBox2.Show();
            richTextBox3.Show();

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
    }
}