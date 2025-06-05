using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace car_rental
{
    public partial class Form1 : Form
    {
        string ordb = "Data source=orcl;User Id=hr;Password=hr;";
        OracleConnection conn;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "CHECKADMINNAME";
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.Add("name", textBox1.Text);
            c.Parameters.Add("pass", textBox2.Text);
            c.Parameters.Add("id2", OracleDbType.Int32, ParameterDirection.Output);
            c.ExecuteNonQuery();
            if (Convert.ToInt32(c.Parameters["id2"].Value.ToString()) == -1)
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "CHECKUSERNAME";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("name", textBox1.Text);
                cmd.Parameters.Add("pass", textBox2.Text);
                cmd.Parameters.Add("id2", OracleDbType.Int32, ParameterDirection.Output);

                cmd.ExecuteNonQuery();
                if (Convert.ToInt32(cmd.Parameters["id2"].Value.ToString()) != -1)
                {
                    globalData.id = Convert.ToInt32(cmd.Parameters["id2"].Value.ToString());
                    MessageBox.Show("Login successful. Welcome!");
                    if (globalData.id == 1)
                    {
                        //admin main form
                        Form5 f = new Form5();
                        f.Show();
                        this.Hide();
                        //Application.Run(new Form5());
                    }
                    else
                    {
                        Form4 f = new Form4();
                        f.Show();
                        this.Hide();
                        //Application.Run(new Form4());

                    }

                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Login successful. Welcome!");

                globalData.id = Convert.ToInt32(c.Parameters["id2"].Value.ToString());
                Form5 f = new Form5();
                f.Show();
                this.Hide();
                //Application.Run(new Form4());

          
            }

            



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //user name
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
