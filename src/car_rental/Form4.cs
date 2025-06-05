using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_rental
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rent f = new rent();
            f.Show();
            this.Hide();
            //Application.Run(new rent());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rent f = new rent();
            f.Show();
            this.Hide();
            //Application.Run(new rent());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            globalData.id = -1;
            Form1 f = new Form1();
            f.Show();
            this.Hide();
            //Application.Run(new Form1());

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.Show();
            this.Hide();
        }
    }
}
