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
using Cs5700Hw3.BoardState;
using Cs5700Hw3.Commands;
using Cs5700Hw3.DB;
using Cs5700Hw3.Drawables;

namespace Cs5700Hw3.View
{
    public partial class MainForm : Form
    {
        private CommandInvoker commandInvoker;
        private Graphics graphics;
        private bool isDirty = true;
        private bool isProgramaticScaleChange = false;

        private PictureToolState currentPictureToolState;
        private PictureToolState noToolState;
        private PictureToolState selectToolState;
        private PictureToolState addDrawableToolState;
        private PictureToolState lineToolState;


        public readonly int SelectToolIndex = 0;
        public readonly int LineToolIndex = 1;
        public readonly int DrawavblesToolOffset = 2;
        public PictureInfo PictureInfo { get; private set; }
        public int SelectedDrawableIndex => drawableListView.SelectedIndices[0];

        public bool SelectionButtonsEnabled
        {
            get { return selectionGrpBox.Enabled; }
            set { selectionGrpBox.Enabled = value; }
        }


        public MainForm()
        {
            InitializeComponent();
            InitDrawableList();
            TogglePictureControls(false);
            KeyPreview = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            PictureInfo = new PictureInfo(); //just a dummy PictureInfo until we open/new
            commandInvoker = new CommandInvoker(PictureInfo);

            //init states
            noToolState = new NoToolState(this);
            selectToolState = new SelectToolState(this);
            addDrawableToolState = new AddDrawableToolState(this);
            lineToolState = new LineToolState(this);
            currentPictureToolState = noToolState;
        }

        private void InitDrawableList()
        {
            var list = new ImageList();
            list.Images.Add(Image.FromFile("Assets/pointer.png"));
            list.Images.Add(Image.FromFile("Assets/line.png"));
            DrawableFactory.GetAllDrawables.ForEach(d => list.Images.Add(d.FileName, Image.FromFile(d.FileName)));
            drawableListView.View = System.Windows.Forms.View.LargeIcon;
            list.ImageSize = new Size(50, 50);
            drawableListView.LargeImageList = list;

            var selectLvi = new ListViewItem
            {
                ImageIndex = 0,
                Text = "Select Tool"
            };
            var lineLvi = new ListViewItem()
            {
                ImageIndex = 1,
                Text = "Line Tool"
            };
            drawableListView.Items.Add(selectLvi);
            drawableListView.Items.Add(lineLvi);
            for (var i = 2; i < list.Images.Count; i++)
            {
                var lvi = new ListViewItem
                {
                    ImageIndex = i,
                    Text = DrawableFactory.GetAllDrawables[i - DrawavblesToolOffset].ReadableName
                };
                drawableListView.Items.Add(lvi);
            }
            drawableListView.Select();
            drawableListView.SelectedIndexChanged += SelectedDrawableChanged;
        }

        //We switch states here
        private void SelectedDrawableChanged(object sender, EventArgs e)
        {
            if (drawableListView.SelectedIndices.Count != 1) return; //no tool selected or error state
            var selectedIndex = drawableListView.SelectedIndices[0];
            if (selectedIndex == SelectToolIndex)
            {
                currentPictureToolState = selectToolState;
            }
            if (selectedIndex == LineToolIndex)
            {
                currentPictureToolState = lineToolState;
            }
            if (selectedIndex >= DrawavblesToolOffset)
            {
                currentPictureToolState = addDrawableToolState;
            }
        }

        public void ExecuteCommand(Type commandType, CommandArgs args = null)
        {
            undoButton.Enabled = commandInvoker.ExecuteCommand(commandType, args);
            isDirty = true;
        }


        private void TogglePictureControls(bool areEnabled)
        {
            shapesGrpBox.Enabled = areEnabled;
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if (PictureInfo == null || !isDirty) return;
            if (graphics == null)
            {
                graphics = drawingPanel.CreateGraphics();
            }
            PictureInfo.Draw(graphics);
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
                    MessageBox.Show($"Error creating a new PictureInfo: {Environment.NewLine}{ex.Message}");

                }
                PictureInfo = commandInvoker.LatestCommand.TargetPicture;
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
                    MessageBox.Show($"Error opening PictureInfo: {Environment.NewLine}{ex.Message}");
                }
                PictureInfo = commandInvoker.LatestCommand.TargetPicture;
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
                MessageBox.Show($"Error saving PictureInfo: {Environment.NewLine}{ex.Message}");
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {

        }


        private void drawingPanel_Click(object sender, EventArgs e)
        {
            currentPictureToolState?.HandleDrawingPanelClick((MouseEventArgs)e);
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            undoButton.Enabled = commandInvoker.Undo();
            isDirty = true;
        }

        public void HandleSelectionChange()
        {
            selectionGrpBox.Enabled = PictureInfo.SelectedDrawable != null;
            if (selectionGrpBox.Enabled)
            {
                isProgramaticScaleChange = true;
                scaleUpDown.Value = Convert.ToDecimal(PictureInfo.SelectedDrawable.Scale * 100);
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
            if (PictureInfo?.SelectedDrawable == null) return;
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
            if (PictureInfo?.SelectedDrawable == null) return;
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
