using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Virt_lab_25
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        //public int amountOfFluctationsInput;

        private void enterRegister_Click(object sender, EventArgs e)
        {
           if (checkTextBox() && checkTextGroup())
            {
                    string name = textBoxName.Text;
                    string group = textBoxGroup.Text;
                    this.Hide();
                    Form1 form = new Form1();

                    form.name = name;
                    form.groupName = group;
                    //form.amountOfFluctations = amountOfFluctationsInput;
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Не заполнены поля");
                }
            
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void closeRegister_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool checkTextBox()
        {
            if ((textBoxName.Text.Trim() == string.Empty))
            {
                MessageBox.Show("Не заполнены поля");
                return false;
            } else if ((textBoxName.Text.Trim() == string.Empty))
            {
                MessageBox.Show("Не заполнены поля");
                return false;
            }
            return true;
        }

        private bool checkTextGroup()
        {
            if ((textBoxGroup.Text.Trim() == string.Empty))
            {
                MessageBox.Show("Не заполнены поля");
                return false;
            }
            else if ((textBoxGroup.Text.Trim() == string.Empty))
            {
                MessageBox.Show("Не заполнены поля");
                return false;
            }
            return true;
        }



        private void Register_Load(object sender, EventArgs e)
        {

        }

       // private void radioButton1_CheckedChanged(object sender, EventArgs e)
      //  {

      //  }

    //    private void radioButton2_CheckedChanged(object sender, EventArgs e)
     //   {

      //  }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            ProtocolImport protocol = new ProtocolImport();
            protocol.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
