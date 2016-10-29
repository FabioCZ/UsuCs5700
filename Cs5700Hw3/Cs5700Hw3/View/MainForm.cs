using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cs5700Hw3.DB;
using Cs5700Hw3.Drawables;

namespace Cs5700Hw3.View
{
    public partial class MainForm : Form
    {
        private PictureInfo picture;
        private Graphics graphics;

        public MainForm()
        {
            InitializeComponent();
            InitDrawableList();
        }

        private void InitDrawableList()
        {
            var list = new ImageList();
            DrawableFactory.GetAllDrawables.ForEach(d => list.Images.Add(d.FileName,Image.FromFile(d.FileName)));
            drawableListView.View = System.Windows.Forms.View.LargeIcon;
            list.ImageSize = new Size(50,50);
            drawableListView.LargeImageList = list;
            for (var i = 0; i < list.Images.Count; i++)
            {
                var lvi = new ListViewItem
                {
                    ImageIndex = i,
                    Text = DrawableFactory.GetAllDrawables[i].ReadableName
                };
                drawableListView.Items.Add(lvi);
            }
        }


        private void colorPickerButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorPicker.ShowDialog())
            {
                
            }
        }
        private void newButton_Click(object sender, EventArgs e)
        {
            var dialog = new NewDrawingDialog();
            if (DialogResult.OK == dialog.ShowDialog())
            {
                Debug.WriteLine(dialog.SelectedColor);
                if (dialog.SelectedColor != null)
                {
                    picture = new PictureInfo();
                    picture.Background = new SolidBackground(dialog.SelectedColor.Value);
                }
                else
                {
                    picture = new PictureInfo();
                    picture.Background = new ImageBackground(dialog.FileName);
                }
                noPictureLabel.Text = string.Empty;
                refreshTimer.Start();
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenDrawingDialog();
            if (DialogResult.OK == dialog.ShowDialog())
            {
                Debug.WriteLine($"Opening picture {dialog.SelectedPicture.PictureName}");
                picture = dialog.SelectedPicture;
                noPictureLabel.Text = string.Empty;
                refreshTimer.Start();
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            var name = Microsoft.VisualBasic.Interaction.InputBox("Enter name:");
            picture.PictureName = name;
            if (picture.Created == default(DateTime))
            {
                picture.Created = DateTime.Now;
            }
            FireBaseDbo.Instance.Save(picture);
        }



        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if (picture == null) return;
            if (graphics == null)
            {
                graphics = drawingPanel.CreateGraphics();
            }
            picture.Background.Draw(graphics);
        }
    }
}
