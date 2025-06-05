using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Oracle.DataAccess.Types;
using Oracle.DataAccess.Client;


namespace car_rental
{
    public partial class Form6 : Form
    {
        string ordb = "Data source=orcl;User Id=hr;Password=hr;";
        OracleConnection conn;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select userid from user_table where userid <> 1 ";
            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0].ToString());
            }
            dr.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            // Ensure there's a selected item
            if (comboBox2.SelectedItem == null) return;
            try
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GETUSER";
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Convert the selected item to number - IMPORTANT!
                    int userId;
                    if (!int.TryParse(comboBox2.SelectedItem.ToString(), out userId))
                    {
                        MessageBox.Show("Please select a valid numeric user ID");
                        return;
                    }

                    // Add parameters with proper types
                    cmd.Parameters.Add("userid2", OracleDbType.Int32).Value = userId;
                    cmd.Parameters.Add("username2", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("LICENSE_NUMBER2", OracleDbType.Int32).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    // Handle potential null outputs
                    string username = cmd.Parameters["username2"].Value?.ToString() ?? "N/A";
                    int licenseNumber = 0;
                    if (cmd.Parameters["LICENSE_NUMBER2"].Value != DBNull.Value)
                    {
                        licenseNumber = Convert.ToInt32(cmd.Parameters["LICENSE_NUMBER2"].Value.ToString());
                    }

                    // Display results
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Username");
                    dt.Columns.Add("License Number");
                    dt.Rows.Add(username, licenseNumber);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            conn.Dispose();

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
            this.Hide();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
