﻿namespace Cs5700Hw3
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
            this.shapesGrpBox = new System.Windows.Forms.GroupBox();
            this.commandGrpBox = new System.Windows.Forms.GroupBox();
            this.undoButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.drawingGrpBox = new System.Windows.Forms.GroupBox();
            this.selectionGrpBox = new System.Windows.Forms.GroupBox();
            this.colorPickerButton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.duplButton = new System.Windows.Forms.Button();
            this.colorPicker = new System.Windows.Forms.ColorDialog();
            this.commandGrpBox.SuspendLayout();
            this.selectionGrpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // shapesGrpBox
            // 
            this.shapesGrpBox.Location = new System.Drawing.Point(12, 12);
            this.shapesGrpBox.Name = "shapesGrpBox";
            this.shapesGrpBox.Size = new System.Drawing.Size(137, 537);
            this.shapesGrpBox.TabIndex = 0;
            this.shapesGrpBox.TabStop = false;
            this.shapesGrpBox.Text = "Shapes";
            // 
            // commandGrpBox
            // 
            this.commandGrpBox.Controls.Add(this.undoButton);
            this.commandGrpBox.Controls.Add(this.saveButton);
            this.commandGrpBox.Controls.Add(this.openButton);
            this.commandGrpBox.Controls.Add(this.newButton);
            this.commandGrpBox.Location = new System.Drawing.Point(155, 12);
            this.commandGrpBox.Name = "commandGrpBox";
            this.commandGrpBox.Size = new System.Drawing.Size(209, 53);
            this.commandGrpBox.TabIndex = 1;
            this.commandGrpBox.TabStop = false;
            this.commandGrpBox.Text = "Commands";
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(154, 20);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(43, 23);
            this.undoButton.TabIndex = 3;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
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
            // 
            // drawingGrpBox
            // 
            this.drawingGrpBox.Location = new System.Drawing.Point(155, 71);
            this.drawingGrpBox.Name = "drawingGrpBox";
            this.drawingGrpBox.Size = new System.Drawing.Size(617, 478);
            this.drawingGrpBox.TabIndex = 2;
            this.drawingGrpBox.TabStop = false;
            this.drawingGrpBox.Text = "Drawing";
            // 
            // selectionGrpBox
            // 
            this.selectionGrpBox.Controls.Add(this.colorPickerButton);
            this.selectionGrpBox.Controls.Add(this.numericUpDown1);
            this.selectionGrpBox.Controls.Add(this.label1);
            this.selectionGrpBox.Controls.Add(this.removeButton);
            this.selectionGrpBox.Controls.Add(this.duplButton);
            this.selectionGrpBox.Location = new System.Drawing.Point(370, 12);
            this.selectionGrpBox.Name = "selectionGrpBox";
            this.selectionGrpBox.Size = new System.Drawing.Size(402, 53);
            this.selectionGrpBox.TabIndex = 4;
            this.selectionGrpBox.TabStop = false;
            this.selectionGrpBox.Text = "Selection";
            // 
            // colorPickerButton
            // 
            this.colorPickerButton.Location = new System.Drawing.Point(233, 20);
            this.colorPickerButton.Name = "colorPickerButton";
            this.colorPickerButton.Size = new System.Drawing.Size(62, 23);
            this.colorPickerButton.TabIndex = 4;
            this.colorPickerButton.Text = "Color";
            this.colorPickerButton.UseVisualStyleBackColor = true;
            this.colorPickerButton.Click += new System.EventHandler(this.colorPickerButton_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(186, 22);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.selectionGrpBox);
            this.Controls.Add(this.drawingGrpBox);
            this.Controls.Add(this.commandGrpBox);
            this.Controls.Add(this.shapesGrpBox);
            this.Name = "MainForm";
            this.Text = "Drawing Program";
            this.commandGrpBox.ResumeLayout(false);
            this.selectionGrpBox.ResumeLayout(false);
            this.selectionGrpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox shapesGrpBox;
        private System.Windows.Forms.GroupBox commandGrpBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.GroupBox drawingGrpBox;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.GroupBox selectionGrpBox;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button duplButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button colorPickerButton;
        private System.Windows.Forms.ColorDialog colorPicker;
    }
}

