using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cs5700Hw3.DB;

namespace Cs5700Hw3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var name = Microsoft.VisualBasic.Interaction.InputBox("Enter name");
            var pi = new PictureInfo {PictureName = name};
            FireBaseDbo.Instance.Save(pi);
        }

        private void colorPickerButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorPicker.ShowDialog())
            {
                
            }
        }

        private async void openButton_Click(object sender, EventArgs e)
        {
            var pics = await FireBaseDbo.Instance.AvailablePictures();
            MessageBox.Show(this, string.Join(",", pics.ToArray()));
        }
    }
}
