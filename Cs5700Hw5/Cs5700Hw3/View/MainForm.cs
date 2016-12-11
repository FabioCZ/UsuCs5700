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
using Cs5700Hw3.Drawables.BoardState;

namespace Cs5700Hw3.View
{
    public partial class MainForm : Form
    {
        public readonly int SelectToolIndex = 0;
        private PictureState picture;
        private CommandDispatcher dispatcher;
        private Graphics graphics;
        private bool isDirty = true;
        private bool isProgramaticScaleChange = false;
        private IPictureClickState pictureClickState;

        public MainForm()
        {
            InitializeComponent();
            InitDrawableList();
            TogglePictureControls(false);
            KeyPreview = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            picture = new PictureState(); //just a dummy picture until we open/new
            dispatcher = new CommandDispatcher(picture);
            pictureClickState = new NoPictureClickState();
        }

        private void InitDrawableList()
        {
            var list = new ImageList();
            list.Images.Add(Image.FromFile("Assets/pointer.png"));
            DrawableFactory.GetAllDrawables.ForEach(d => list.Images.Add(d.FileName, Image.FromFile(d.FileName)));
            drawableListView.View = System.Windows.Forms.View.LargeIcon;
            list.ImageSize = new Size(50, 50);
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
                    Text = DrawableFactory.GetAllDrawables[i - 1].ReadableName
                };
                drawableListView.Items.Add(lvi);
            }
            drawableListView.Select();
            drawableListView.SelectedIndexChanged += SelectedDrawableChanged;
        }

        private void SelectedDrawableChanged(object sender, EventArgs e)
        {
            
        }

        private void ExecuteCommand(Type commandType, CommandArgs args = null)
        {
            undoButton.Enabled = dispatcher.ExecuteCommand(commandType, args);
            isDirty = true;
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

        private void colorPickerButton_Click(object sender, EventArgs e) => ExecuteCommand(typeof(TintCommand));

        private void newButton_Click(object sender, EventArgs e)
        {
            refreshTimer.Stop();
            var newPicDialog = new NewDrawingDialog();
            if (newPicDialog.ShowDialog() == DialogResult.OK)
            {
                var args = new CommandArgs()
                {
                    BackgroundColor = newPicDialog.SelectedColor,
                    BackgroundFileName = newPicDialog.FileName
                };
                try
                {
                    ExecuteCommand(typeof(NewPicCommand), args);

                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show($"Error creating a new picture: {Environment.NewLine}{ex.Message}");

                }
                picture = dispatcher.LatestCommand.TargetPicture;
                noPictureLabel.Text = string.Empty;
                refreshTimer.Start();
                TogglePictureControls(true);
            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            refreshTimer.Stop();
            var openPicDialog = new OpenDrawingDialog();
            if (openPicDialog.ShowDialog() == DialogResult.OK)
            {
                var args = new CommandArgs()
                {
                    PictureToOpen = openPicDialog.SelectedPicture
                };
                try
                {
                    ExecuteCommand(typeof(OpenPicCommand), args);

                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show($"Error opening picture: {Environment.NewLine}{ex.Message}");
                }
                picture = dispatcher.LatestCommand.TargetPicture;
                noPictureLabel.Text = string.Empty;
                TogglePictureControls(true);
                refreshTimer.Start();
            }


        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var name = Microsoft.VisualBasic.Interaction.InputBox("Enter name:");
            var args = new CommandArgs()
            {
                SavePictureName = name
            };
            try
            {
                ExecuteCommand(typeof(SavePicCommand), args);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show($"Error saving picture: {Environment.NewLine}{ex.Message}");
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {

        }


        private void drawingPanel_Click(object sender, EventArgs e)
        {
            if (drawableListView.SelectedIndices.Count != 1 || picture == null) return;
            var selectedIndex = drawableListView.SelectedIndices[0];
            if (selectedIndex == SelectToolIndex)
            {
                var args = new CommandArgs()
                {
                    TargetLocation = ((MouseEventArgs)e).Location
                };
                ExecuteCommand(typeof(SelectCommand), args);
                HandleSelectionChange();
            }
            else
            {
                var args = new CommandArgs()
                {
                    Drawable = DrawableFactory.GetDrawable((CatDrawable)selectedIndex - 1),
                    TargetLocation = ((MouseEventArgs)e).Location
                };
                ExecuteCommand(typeof(AddCommand), args);
                selectionGrpBox.Enabled = false;
            }
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            undoButton.Enabled = dispatcher.Undo();
            isDirty = true;
        }

        private void HandleSelectionChange()
        {
            selectionGrpBox.Enabled = picture.SelectedDrawable != null;
            if (selectionGrpBox.Enabled)
            {
                isProgramaticScaleChange = true;
                scaleUpDown.Value = Convert.ToDecimal(picture.SelectedDrawable.Scale * 100);
            }
        }

        private void scaleUpDown_Click(object sender, EventArgs e)
        {
            isProgramaticScaleChange = false;
        }

        private void scaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (((NumericUpDown)sender).Value <= 0)
            {
                ((NumericUpDown)sender).Value = 1;
            }
            if (((NumericUpDown)sender).Value > 1000)
            {
                ((NumericUpDown)sender).Value = 1000;
            }
            if (isProgramaticScaleChange)
            {
                isProgramaticScaleChange = false;
                return;
            }
            
            var args = new CommandArgs()
            {
                Scale = Convert.ToSingle(((NumericUpDown)sender).Value / 100)
            };
            ExecuteCommand(typeof(ResizeCommand), args);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            ExecuteCommand(typeof(RemoveCommand));
            selectionGrpBox.Enabled = false;
        }

        private void duplButton_Click(object sender, EventArgs e) => ExecuteCommand(typeof(DuplicateCommand));

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Help:
Key shortcuts:
arrow keys - move selected drawable
-/+ - scale selected drawable
delete - remove selected drawable");
        }
        #endregion



        #region Direction Command handlers/Key event handlers
        private void leftButton_Click(object sender, EventArgs e) => ProcessMoveCommand(MoveDirection.Left);

        private void upButton_Click(object sender, EventArgs e) => ProcessMoveCommand(MoveDirection.Up);

        private void downButton_Click(object sender, EventArgs e) => ProcessMoveCommand(MoveDirection.Down);

        private void rightButton_Click(object sender, EventArgs e) => ProcessMoveCommand(MoveDirection.Right);

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            drawingPanel.Focus();
            if (picture?.SelectedDrawable == null) return;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    ProcessMoveCommand(MoveDirection.Up);
                    break;
                case Keys.Right:
                    ProcessMoveCommand(MoveDirection.Right);
                    break;
                case Keys.Down:
                    ProcessMoveCommand(MoveDirection.Down);
                    break;
                case Keys.Left:
                    ProcessMoveCommand(MoveDirection.Left);
                    break;
                case Keys.OemMinus:
                    isProgramaticScaleChange = false;
                    scaleUpDown.Value = scaleUpDown.Value - 1;
                    break;
                case Keys.Oemplus:
                    isProgramaticScaleChange = false;
                    scaleUpDown.Value = scaleUpDown.Value + 1;
                    break;
                case Keys.Delete:
                    removeButton_Click(sender, e);
                    break;
            }
            e.Handled = true;
        }

        private void ProcessMoveCommand(MoveDirection direction)
        {
            if (picture?.SelectedDrawable == null) return;
            var args = new CommandArgs()
            {
                Direction = direction
            };
            ExecuteCommand(typeof(MoveCommand), args);
        }

        #endregion

        private void MainForm_Resize(object sender, EventArgs e)
        {
            isDirty = true;
        }
    }
}
