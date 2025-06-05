using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
namespace car_rental
{
    public partial class Form10 : Form
    {
        CrystalReport2 CR;

        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CR.SetParameterValue(0, comboBox2.Text);
            crystalReportViewer1.ReportSource = CR;
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            CR = new CrystalReport2();
            crystalReportViewer1.ReportSource = CR;
            foreach (ParameterDiscreteValue v in CR.ParameterFields[0].DefaultValues)
            {
                comboBox2.Items.Add(v.Value);
            }
        }
    }
}
