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
        private CommandInvoker commandInvoker;
        private Graphics graphics;
        private bool isDirty = true;
        private bool isProgramaticScaleChange = false;

        private PictureClickState currentPictureClickState;
        private PictureClickState noPictureClickState;
        private PictureClickState selectPictureClickState;
        private PictureClickState addPictureClickState;


        public readonly int SelectToolIndex = 0;
        public readonly int DrawavblesToolOffset = 1;
        public PictureState PictureState { get; private set; }
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
            PictureState = new PictureState(); //just a dummy PictureState until we open/new
            commandInvoker = new CommandInvoker(PictureState);

            noPictureClickState = new NoPictureClickState(this);
            selectPictureClickState = new SelectPictureClickState(this);
            addPictureClickState = new AddPictureClickState(this);
            currentPictureClickState = noPictureClickState;
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
            if (drawableListView.SelectedIndices.Count != 1) return; //no tool selected or error state
            if (drawableListView.SelectedIndices[0] == SelectToolIndex)
            {
                
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
            if (PictureState == null || !isDirty) return;
            if (graphics == null)
            {
                graphics = drawingPanel.CreateGraphics();
            }
            PictureState.Draw(graphics);
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
                    MessageBox.Show($"Error creating a new PictureState: {Environment.NewLine}{ex.Message}");

                }
                PictureState = commandInvoker.LatestCommand.TargetPicture;
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
                    MessageBox.Show($"Error opening PictureState: {Environment.NewLine}{ex.Message}");
                }
                PictureState = commandInvoker.LatestCommand.TargetPicture;
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
                MessageBox.Show($"Error saving PictureState: {Environment.NewLine}{ex.Message}");
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {

        }


        private void drawingPanel_Click(object sender, EventArgs e)
        {
            currentPictureClickState?.HandleDrawingPanelClick((MouseEventArgs)e);
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            undoButton.Enabled = commandInvoker.Undo();
            isDirty = true;
        }

        public void HandleSelectionChange()
        {
            selectionGrpBox.Enabled = PictureState.SelectedDrawable != null;
            if (selectionGrpBox.Enabled)
            {
                isProgramaticScaleChange = true;
                scaleUpDown.Value = Convert.ToDecimal(PictureState.SelectedDrawable.Scale * 100);
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
            if (PictureState?.SelectedDrawable == null) return;
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
            if (PictureState?.SelectedDrawable == null) return;
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
