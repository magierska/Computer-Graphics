using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor
{
    public partial class LineLengthEditor : Form
    {
        public double ChosenValue;
        public LineLengthEditor(double suggestedValue)
        {
            InitializeComponent();
            textBox1.Text = Math.Round(suggestedValue,2).ToString();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            double theNumber;
            if (!double.TryParse((sender as TextBox).Text, out theNumber))
            {
                (sender as TextBox).Text = string.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChosenValue = Math.Round(double.Parse(textBox1.Text),2);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
