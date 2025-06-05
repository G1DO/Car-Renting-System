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
    public partial class Form2 : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        public Form2()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String constr = "Data source=orcl;User Id=hr;Password=hr;";
            String cmdstr = "";
            if (radioButton1.Checked)
            {
                cmdstr = "select * from car_table where is_rented = 0 ";
            }
            else if (radioButton2.Checked)
            {
                cmdstr = "select * from car_table where is_rented = 1 ";
            }
            adapter = new OracleDataAdapter(cmdstr, constr);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);

            adapter.Update(ds.Tables[0]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
            this.Hide();
        }
    }
}
