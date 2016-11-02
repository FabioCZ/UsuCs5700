namespace Cs5700Hw3.View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.shapesGrpBox = new System.Windows.Forms.GroupBox();
            this.drawableListView = new System.Windows.Forms.ListView();
            this.commandGrpBox = new System.Windows.Forms.GroupBox();
            this.undoButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.selectionGrpBox = new System.Windows.Forms.GroupBox();
            this.downButton = new System.Windows.Forms.Button();
            this.upButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.colorPickerButton = new System.Windows.Forms.Button();
            this.scaleUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.duplButton = new System.Windows.Forms.Button();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.noPictureLabel = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.shapesGrpBox.SuspendLayout();
            this.commandGrpBox.SuspendLayout();
            this.selectionGrpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleUpDown)).BeginInit();
            this.drawingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // shapesGrpBox
            // 
            this.shapesGrpBox.Controls.Add(this.drawableListView);
            this.shapesGrpBox.Location = new System.Drawing.Point(12, 12);
            this.shapesGrpBox.Name = "shapesGrpBox";
            this.shapesGrpBox.Size = new System.Drawing.Size(137, 537);
            this.shapesGrpBox.TabIndex = 0;
            this.shapesGrpBox.TabStop = false;
            this.shapesGrpBox.Text = "Drawables";
            // 
            // drawableListView
            // 
            this.drawableListView.Location = new System.Drawing.Point(7, 25);
            this.drawableListView.Name = "drawableListView";
            this.drawableListView.Size = new System.Drawing.Size(121, 506);
            this.drawableListView.TabIndex = 0;
            this.drawableListView.UseCompatibleStateImageBehavior = false;
            // 
            // commandGrpBox
            // 
            this.commandGrpBox.Controls.Add(this.helpButton);
            this.commandGrpBox.Controls.Add(this.undoButton);
            this.commandGrpBox.Controls.Add(this.saveButton);
            this.commandGrpBox.Controls.Add(this.openButton);
            this.commandGrpBox.Controls.Add(this.newButton);
            this.commandGrpBox.Location = new System.Drawing.Point(155, 12);
            this.commandGrpBox.Name = "commandGrpBox";
            this.commandGrpBox.Size = new System.Drawing.Size(251, 53);
            this.commandGrpBox.TabIndex = 1;
            this.commandGrpBox.TabStop = false;
            this.commandGrpBox.Text = "Commands";
            // 
            // undoButton
            // 
            this.undoButton.Enabled = false;
            this.undoButton.Location = new System.Drawing.Point(154, 20);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(43, 23);
            this.undoButton.TabIndex = 3;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(105, 20);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(43, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(56, 20);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(43, 23);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(7, 20);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(43, 23);
            this.newButton.TabIndex = 0;
            this.newButton.Text = "New";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // selectionGrpBox
            // 
            this.selectionGrpBox.Controls.Add(this.downButton);
            this.selectionGrpBox.Controls.Add(this.upButton);
            this.selectionGrpBox.Controls.Add(this.rightButton);
            this.selectionGrpBox.Controls.Add(this.leftButton);
            this.selectionGrpBox.Controls.Add(this.colorPickerButton);
            this.selectionGrpBox.Controls.Add(this.scaleUpDown);
            this.selectionGrpBox.Controls.Add(this.label1);
            this.selectionGrpBox.Controls.Add(this.removeButton);
            this.selectionGrpBox.Controls.Add(this.duplButton);
            this.selectionGrpBox.Enabled = false;
            this.selectionGrpBox.Location = new System.Drawing.Point(412, 13);
            this.selectionGrpBox.Name = "selectionGrpBox";
            this.selectionGrpBox.Size = new System.Drawing.Size(402, 53);
            this.selectionGrpBox.TabIndex = 4;
            this.selectionGrpBox.TabStop = false;
            this.selectionGrpBox.Text = "Selection";
            // 
            // downButton
            // 
            this.downButton.Location = new System.Drawing.Point(346, 19);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(22, 23);
            this.downButton.TabIndex = 8;
            this.downButton.Text = "˅";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // upButton
            // 
            this.upButton.Location = new System.Drawing.Point(318, 19);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(22, 23);
            this.upButton.TabIndex = 7;
            this.upButton.Text = "˄";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.Location = new System.Drawing.Point(374, 19);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(22, 23);
            this.rightButton.TabIndex = 6;
            this.rightButton.Text = ">";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Location = new System.Drawing.Point(292, 19);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(22, 23);
            this.leftButton.TabIndex = 5;
            this.leftButton.Text = "<";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // colorPickerButton
            // 
            this.colorPickerButton.Location = new System.Drawing.Point(233, 20);
            this.colorPickerButton.Name = "colorPickerButton";
            this.colorPickerButton.Size = new System.Drawing.Size(53, 23);
            this.colorPickerButton.TabIndex = 4;
            this.colorPickerButton.Text = "Recolor";
            this.colorPickerButton.UseVisualStyleBackColor = true;
            this.colorPickerButton.Click += new System.EventHandler(this.colorPickerButton_Click);
            // 
            // scaleUpDown
            // 
            this.scaleUpDown.Location = new System.Drawing.Point(186, 22);
            this.scaleUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.scaleUpDown.Name = "scaleUpDown";
            this.scaleUpDown.Size = new System.Drawing.Size(41, 20);
            this.scaleUpDown.TabIndex = 3;
            this.scaleUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.scaleUpDown.ValueChanged += new System.EventHandler(this.scaleUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Scale:";
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(75, 20);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(62, 23);
            this.removeButton.TabIndex = 1;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // duplButton
            // 
            this.duplButton.Location = new System.Drawing.Point(7, 20);
            this.duplButton.Name = "duplButton";
            this.duplButton.Size = new System.Drawing.Size(62, 23);
            this.duplButton.TabIndex = 0;
            this.duplButton.Text = "Duplicate";
            this.duplButton.UseVisualStyleBackColor = true;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // drawingPanel
            // 
            this.drawingPanel.Controls.Add(this.noPictureLabel);
            this.drawingPanel.Location = new System.Drawing.Point(155, 72);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(659, 477);
            this.drawingPanel.TabIndex = 5;
            this.drawingPanel.Click += new System.EventHandler(this.drawingPanel_Click);
            // 
            // noPictureLabel
            // 
            this.noPictureLabel.AutoSize = true;
            this.noPictureLabel.Location = new System.Drawing.Point(4, 4);
            this.noPictureLabel.Name = "noPictureLabel";
            this.noPictureLabel.Size = new System.Drawing.Size(247, 13);
            this.noPictureLabel.TabIndex = 0;
            this.noPictureLabel.Text = "Please start a new drawing or open an existing one";
            this.noPictureLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // helpButton
            // 
            this.helpButton.Enabled = false;
            this.helpButton.Location = new System.Drawing.Point(201, 20);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(43, 23);
            this.helpButton.TabIndex = 4;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 561);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.selectionGrpBox);
            this.Controls.Add(this.commandGrpBox);
            this.Controls.Add(this.shapesGrpBox);
            this.Name = "MainForm";
            this.Text = "MeowDraw";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.shapesGrpBox.ResumeLayout(false);
            this.commandGrpBox.ResumeLayout(false);
            this.selectionGrpBox.ResumeLayout(false);
            this.selectionGrpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaleUpDown)).EndInit();
            this.drawingPanel.ResumeLayout(false);
            this.drawingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox shapesGrpBox;
        private System.Windows.Forms.GroupBox commandGrpBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.GroupBox selectionGrpBox;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button duplButton;
        private System.Windows.Forms.NumericUpDown scaleUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button colorPickerButton;
        private System.Windows.Forms.ColorDialog colorPicker;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.Label noPictureLabel;
        private System.Windows.Forms.ListView drawableListView;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button helpButton;
    }
}

