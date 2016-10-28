using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cs5700Hw3.DB;

namespace Cs5700Hw3.View
{
    public partial class OpenDrawingDialog : Form
    {
        public  PictureInfo SelectedPicture { get; private set; }
        public OpenDrawingDialog()
        {
            InitializeComponent();
            InitList();
            
        }

        private async void InitList()
        {
            this.listBox1.SelectionMode = SelectionMode.One;
            var availPics = await  FireBaseDbo.Instance.AvailablePictures();
            var data = new PictureCollection();
            foreach (var p in availPics)
            {
                data.AddPicture(p);
            }
            listBox1.DataSource = data;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            SelectedPicture = (PictureInfo)listBox1?.SelectedItems[0];
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    public class PictureCollection : CollectionBase
    {
        public void AddPicture(PictureInfo pi)
        {
            this.List.Add(pi);
        }
    }
}
