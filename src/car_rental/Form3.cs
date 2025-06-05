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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace car_rental
{
    public partial class rent : Form
    {
        string ordb = "Data source=orcl;User Id=hr;Password=hr;";
        OracleConnection conn;

        public rent()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int max_id, new_id;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "create_id";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("max_id", OracleDbType.Int32, ParameterDirection.Output);
            cmd.ExecuteNonQuery();
            if (Convert.ToInt32(cmd.Parameters["max_id"].Value.ToString()) != -1)
            {
                max_id = Convert.ToInt32(cmd.Parameters["max_id"].Value.ToString());
                new_id = max_id + 1;
            }
            else
            {
                //MessageBox.Show("hiiii");
                new_id = 1;
            }

            OracleCommand c = new OracleCommand();
            c.Connection = conn;
            c.CommandText = "insert into rental_table values(:ren_id , :car_id  ,:mem_id ,:ren_date , :back_date)";
            c.CommandType = CommandType.Text;
            c.Parameters.Add("ren_id", new_id);
            c.Parameters.Add("car_id", dataGridView2.SelectedRows[0].Cells["carid"].Value.ToString());
            c.Parameters.Add("mem_id", globalData.id);
            c.Parameters.Add("ren_date", Convert.ToDateTime(textBox2.Text));
            c.Parameters.Add("back_date", Convert.ToDateTime(textBox4.Text));
            c.ExecuteNonQuery();


            MessageBox.Show("Rented success");

            OracleCommand c2 = new OracleCommand();
            c2.Connection = conn;

            c2.CommandText = "update car_table set is_rented = 1 where carid =:id";
            c2.CommandType = CommandType.Text;
            c2.Parameters.Add("id", dataGridView2.SelectedRows[0].Cells["carid"].Value.ToString());
            c2.ExecuteNonQuery();
            MessageBox.Show("Updated");
            ///////////////////////////////////////////payment
            int new_id2;

            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "select max(paymentid) from payment_table";
            cmd2.CommandType = CommandType.Text;
            //cmd.Parameters.Add("max_id", OracleDbType.Int32, ParameterDirection.Output);
            using (OracleDataReader reader = cmd2.ExecuteReader())
            {
                if (reader.Read()) // Moves to the first (and only) row
                {
                    if (!reader.IsDBNull(0)) // Check if the column is not NULL
                    {
                        new_id2 = Convert.ToInt32(reader.GetValue(0)); // Safe conversion
                        new_id2 = new_id2 + 1;
                    }
                    else
                    {
                        new_id2 = 1;
                    }
                }
                else
                {
                    new_id2 = 1;
                }
            }
            OracleCommand c3 = new OracleCommand();
            c3.Connection = conn;
            c3.CommandText = "insert into payment_table values(:pay_id , :rental_id  ,:pay_date ,:pay_method)";
            c3.CommandType = CommandType.Text;
            c3.Parameters.Add("pay_id", new_id2);
            c3.Parameters.Add("rental_id", new_id);
            c3.Parameters.Add("pay_date", DateTime.Now);
            c3.Parameters.Add("pay_method", comboBox1.SelectedItem.ToString());
            c3.ExecuteNonQuery();

            dataGridView2.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select carid,cost,model from car_table where cost <= :c and is_rented = 0";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("cost", textBox5.Text);
            //OracleDataReader dr = cmd.ExecuteReader();


            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            //GridView
            dataGridView2.DataSource = dt;

            /*comboBox2.Items.Clear();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0]);
            }
            dr.Close();*/
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select cost,model from car_table where carId = :id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", comboBox2.SelectedItem.ToString());

            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox3.Text = dr[1].ToString();  
            }*/
            
        }

        private void rent_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            comboBox1.Items.Add("card");
            comboBox1.Items.Add("cash");


            textBox2.Text = DateTime.Now.ToString();
            textBox4.Text = DateTime.Now.AddDays(5).ToString();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GETAVAILABLECARS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("cid", OracleDbType.RefCursor, ParameterDirection.Output);

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            //GridView
            dataGridView2.DataSource = dt;

           
        }

        private void rent_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
