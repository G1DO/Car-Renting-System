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
    public partial class Form7 : Form
    {

        string ordb = "Data source=orcl;User Id=hr;Password=hr;";
        OracleConnection conn;
        public Form7()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select rentalid , carid ,rental_startdate , rental_enddate  from rental_table where userID = :id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("cid", globalData.id);

            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            //GridView
            dataGridView1.DataSource = dt;
        }
    }
}
