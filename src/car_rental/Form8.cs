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
    public partial class Form8 : Form
    {
        string ordb = "Data source=orcl;User Id=hr;Password=hr;";
        OracleConnection conn;
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select rental_enddate from rental where rentalID = :rId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("rId", comboBox2.SelectedItem);*/
            /*int max_id, new_id;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select max(rentalid) from rental_table;";
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
            }*/

            int max_id, new_id;
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select max(ratingid) from rating_table";
            cmd.CommandType = CommandType.Text;
            //cmd.Parameters.Add("max_id", OracleDbType.Int32, ParameterDirection.Output);
            using (OracleDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read()) // Moves to the first (and only) row
                {
                    if (!reader.IsDBNull(0)) // Check if the column is not NULL
                    {
                        new_id = Convert.ToInt32(reader.GetValue(0)); // Safe conversion
                        new_id = new_id + 1;
                    }
                    else
                    {
                        new_id = 1;
                    }
                }
                else
                {
                    new_id = 1;
                }
            }

            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "SELECT COUNT(*) FROM rating_table WHERE rentalid = :id ";
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("id", comboBox2.SelectedItem.ToString());
            int count = 0;
            using (OracleDataReader reader = cmd2.ExecuteReader())
            {
                if (reader.Read())
                {
                    count = Convert.ToInt32(reader.GetValue(0));
                }
            }

            if (count > 0)
            {
                /*OracleCommand c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "UPDATE rating_table SET rating = :rate WHERE rentalid = :rentalId";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("rateId", new_id);
                c.Parameters.Add("rate", comboBox1.SelectedItem.ToString());
                c.Parameters.Add("rentalId", comboBox2.SelectedItem.ToString());*/
                //c.ExecuteNonQuery();
                MessageBox.Show("you have already rated it!!!!");
            }
            else
            {
                OracleCommand c = new OracleCommand();
                c.Connection = conn;
                c.CommandText = "insert into rating_table values(:rateId , :rentalId , :rate)";
                c.CommandType = CommandType.Text;
                c.Parameters.Add("rateId", new_id);
                c.Parameters.Add("rentalId", comboBox2.SelectedItem.ToString());
                c.Parameters.Add("rate", comboBox1.SelectedItem.ToString());
                c.ExecuteNonQuery();
                MessageBox.Show("rated successifully");
            }

            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {

            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select rentalID from rental_table where rental_enddate <= :date1 and userID = :id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("date1", DateTime.Now);
            cmd.Parameters.Add("id", globalData.id);

            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0]);
            }
            dr.Close();

            for (int i = 1; i<= 5; i++)
                comboBox1.Items.Add(i);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
            this.Hide();
        }
    }
}
