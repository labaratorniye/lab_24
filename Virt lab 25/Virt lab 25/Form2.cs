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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            button1.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //pictureBox1.Image = Image.FromFile("vipoln.png");
           //pictureBox1.Width = Image.FromFile("vipoln.png").Width;
            pictureBox1.Parent = panel1;
            panel1.AutoScroll = true;
        }
        //Form2 close = new Form2();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
