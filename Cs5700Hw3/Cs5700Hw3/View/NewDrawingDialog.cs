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
    public partial class NewDrawingDialog : Form
    {
        public Color? SelectedColor { get; private set; }
        public string FileName { get; private set; }
        public NewDrawingDialog()
        {
            InitializeComponent();
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            var r = colorDialog1.ShowDialog();
            if (r == DialogResult.OK)
            {
                SelectedColor = colorDialog1.Color;
                this.Close();
            }
            DialogResult = DialogResult.OK;
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            var r = openFileDialog1.ShowDialog();
            if (r == DialogResult.OK)
            {
                FileName = openFileDialog1.SafeFileName;
                this.Close();
            }
            DialogResult = DialogResult.OK;
        }
    }
}
