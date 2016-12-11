using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cs5700Hw3.View
{
    public partial class TintForm : Form
    {
        private const int barTo255Coeff = 17;
        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }
        public TintForm()
        {
            InitializeComponent();
            Red = 0;
            Green = 0;
            Blue = 0;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Red = redBar.Value* barTo255Coeff;
            Green = greenBar.Value* barTo255Coeff;
            Blue = blueBar.Value*barTo255Coeff;
        }
    }
}
