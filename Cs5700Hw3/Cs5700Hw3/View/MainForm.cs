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
using Cs5700Hw3.Commands;
using Cs5700Hw3.DB;
using Cs5700Hw3.Drawables;

namespace Cs5700Hw3.View
{
    public partial class MainForm : Form
    {
        public readonly int SelectToolIndex = 0;
        private PictureInfo picture;
        private Graphics graphics;
        private Stack<ICommand> commandHistory;
        private bool isDirty = true;

        public MainForm()
        {
            InitializeComponent();
            InitDrawableList();
            TogglePictureControls(false);
            commandHistory = new Stack<ICommand>();

        }

        private void InitDrawableList()
        {
            var list = new ImageList();
            list.Images.Add(Image.FromFile("Assets/pointer.png"));
            DrawableFactory.GetAllDrawables.ForEach(d => list.Images.Add(d.FileName,Image.FromFile(d.FileName)));
            drawableListView.View = System.Windows.Forms.View.LargeIcon;
            list.ImageSize = new Size(50,50);
            drawableListView.LargeImageList = list;

            var selectLvi = new ListViewItem
            {
                ImageIndex = 0,
                Text = "Select Tool"
            };
            drawableListView.Items.Add(selectLvi);
            for (var i = 1; i < list.Images.Count; i++)
            {
                var lvi = new ListViewItem
                {
                    ImageIndex = i,
                    Text = DrawableFactory.GetAllDrawables[i-1].ReadableName
                };
                drawableListView.Items.Add(lvi);
            }
        }

        private void ExecuteCommand(ICommand command, CommandArgs args = null)
        {
            isDirty = true;
            undoButton.Enabled = command.Undoable;
            if (command.Undoable)
            {
                commandHistory.Push(command);
            }
            else
            {
                commandHistory.Clear();
            }
            command.Execute(args);

        }


        private void TogglePictureControls(bool areEnabled)
        {
            shapesGrpBox.Enabled = areEnabled;
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if (picture == null || !isDirty) return;
            if (graphics == null)
            {
                graphics = drawingPanel.CreateGraphics();
            }
            picture.Draw(graphics);
            isDirty = false;
        }

        #region ClickListeners

        private void colorPickerButton_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == colorPicker.ShowDialog())
            {
                
            }
        }
        private void newButton_Click(object sender, EventArgs e)
        {
            var command = CommandFactory.CreateCommand(typeof(NewPicCommand));
            ExecuteCommand(command);
            picture = command.TargetPicture;
            noPictureLabel.Text = string.Empty;
            refreshTimer.Start();
            TogglePictureControls(true);
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            var command = CommandFactory.CreateCommand(typeof(OpenPicCommand));
            ExecuteCommand(command);
            picture = command.TargetPicture;
            noPictureLabel.Text = string.Empty;
            TogglePictureControls(true);
            refreshTimer.Start();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            var command = CommandFactory.CreateCommand(typeof(SavePicCommand));
            command.TargetPicture = picture;
            ExecuteCommand(command);
        }


        private void drawingPanel_Click(object sender, EventArgs e)
        {
            if (drawableListView.SelectedIndices.Count != 1 || picture == null) return;
            var selectedIndex = drawableListView.SelectedIndices[0];
            if (selectedIndex == SelectToolIndex)
            {
                //TODO selection
            }
            else
            {
                var args = new CommandArgs()
                {
                    Drawable = DrawableFactory.GetDrawable((CatDrawable) selectedIndex-1),
                    TargetLocation = ((MouseEventArgs) e).Location
                };
                var cmd = CommandFactory.CreateCommand(typeof(AddCommand));
                cmd.TargetPicture = picture;
                ExecuteCommand(cmd,args);
            }
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (commandHistory.Any())
            {
                var command = commandHistory.Pop();
                command.Undo();
                if (commandHistory.Any())
                {
                    undoButton.Enabled = commandHistory.Peek().Undoable;
                }
            }
        }
        #endregion


    }
}
