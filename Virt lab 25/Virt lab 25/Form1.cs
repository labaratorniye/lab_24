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
    }
}