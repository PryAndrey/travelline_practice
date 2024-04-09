using CarFactory.Models.CarColor;
using CarFactory.Models.CarEngine;
using CarFactory.Models.CarFormType;
using CarFactory.Models.CarTransmission;
using System.Windows.Forms;

namespace CarFactory
{
    partial class CarFactoryForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.colorBox = new System.Windows.Forms.GroupBox();
            this.carColor = new System.Windows.Forms.ComboBox();
            this.engineBox = new System.Windows.Forms.GroupBox();
            this.carEngine = new System.Windows.Forms.ComboBox();
            this.transmissionBox = new System.Windows.Forms.GroupBox();
            this.carTransmission = new System.Windows.Forms.ComboBox();
            this.formBox = new System.Windows.Forms.GroupBox();
            this.carFormType = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.confirmButton = new System.Windows.Forms.Button();
            this.colorBox.SuspendLayout();
            this.engineBox.SuspendLayout();
            this.transmissionBox.SuspendLayout();
            this.formBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.BackColor = System.Drawing.Color.YellowGreen;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(120, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Car Factory";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // colorBox
            // 
            this.colorBox.Controls.Add(this.carColor);
            this.colorBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.colorBox.Location = new System.Drawing.Point(2, 113);
            this.colorBox.Margin = new System.Windows.Forms.Padding(2);
            this.colorBox.Name = "colorBox";
            this.colorBox.Padding = new System.Windows.Forms.Padding(2);
            this.colorBox.Size = new System.Drawing.Size(172, 107);
            this.colorBox.TabIndex = 8;
            this.colorBox.TabStop = false;
            this.colorBox.Text = "Car color";
            // 
            // carColor
            // 
            this.carColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.carColor.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.carColor.FormattingEnabled = true;
            this.carColor.Items.AddRange(ColorDictionary.GetColorsName());
            this.carColor.Location = new System.Drawing.Point(5, 65);
            this.carColor.Margin = new System.Windows.Forms.Padding(2);
            this.carColor.Name = "carColor";
            this.carColor.Size = new System.Drawing.Size(163, 36);
            this.carColor.TabIndex = 4;
            // 
            // engineBox
            // 
            this.engineBox.Controls.Add(this.carEngine);
            this.engineBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.engineBox.Location = new System.Drawing.Point(178, 2);
            this.engineBox.Margin = new System.Windows.Forms.Padding(2);
            this.engineBox.Name = "engineBox";
            this.engineBox.Padding = new System.Windows.Forms.Padding(2);
            this.engineBox.Size = new System.Drawing.Size(172, 107);
            this.engineBox.TabIndex = 8;
            this.engineBox.TabStop = false;
            this.engineBox.Text = "Car Engine";
            // 
            // carEngine
            // 
            this.carEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.carEngine.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.carEngine.FormattingEnabled = true;
            this.carEngine.Items.AddRange(EngineDictionary.GetEnginesName());
            this.carEngine.Location = new System.Drawing.Point(5, 65);
            this.carEngine.Margin = new System.Windows.Forms.Padding(2);
            this.carEngine.Name = "carEngine";
            this.carEngine.Size = new System.Drawing.Size(163, 36);
            this.carEngine.TabIndex = 4;
            // 
            // transmissionBox
            // 
            this.transmissionBox.Controls.Add(this.carTransmission);
            this.transmissionBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.transmissionBox.Location = new System.Drawing.Point(2, 2);
            this.transmissionBox.Margin = new System.Windows.Forms.Padding(2);
            this.transmissionBox.Name = "transmissionBox";
            this.transmissionBox.Padding = new System.Windows.Forms.Padding(2);
            this.transmissionBox.Size = new System.Drawing.Size(172, 107);
            this.transmissionBox.TabIndex = 8;
            this.transmissionBox.TabStop = false;
            this.transmissionBox.Text = "Car Transmission";
            // 
            // carTransmission
            // 
            this.carTransmission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.carTransmission.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.carTransmission.FormattingEnabled = true;
            this.carTransmission.Items.AddRange(TransmissionDictionary.GetTransmissionsName());
            this.carTransmission.Location = new System.Drawing.Point(5, 65);
            this.carTransmission.Margin = new System.Windows.Forms.Padding(2);
            this.carTransmission.Name = "carTransmission";
            this.carTransmission.Size = new System.Drawing.Size(163, 36);
            this.carTransmission.TabIndex = 4;
            // 
            // formBox
            // 
            this.formBox.Controls.Add(this.carFormType);
            this.formBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.formBox.Location = new System.Drawing.Point(178, 113);
            this.formBox.Margin = new System.Windows.Forms.Padding(2);
            this.formBox.Name = "formBox";
            this.formBox.Padding = new System.Windows.Forms.Padding(2);
            this.formBox.Size = new System.Drawing.Size(172, 107);
            this.formBox.TabIndex = 8;
            this.formBox.TabStop = false;
            this.formBox.Text = "Car Form";
            // 
            // carFormType
            // 
            this.carFormType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.carFormType.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.carFormType.FormattingEnabled = true;
            this.carFormType.Items.AddRange(FormDictionary.GetFormsName());
            this.carFormType.Location = new System.Drawing.Point(5, 65);
            this.carFormType.Name = "carFormType";
            this.carFormType.Size = new System.Drawing.Size(163, 36);
            this.carFormType.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.DarkKhaki;
            this.flowLayoutPanel1.Controls.Add(this.transmissionBox);
            this.flowLayoutPanel1.Controls.Add(this.engineBox);
            this.flowLayoutPanel1.Controls.Add(this.colorBox);
            this.flowLayoutPanel1.Controls.Add(this.formBox);
            this.flowLayoutPanel1.Controls.Add(this.confirmButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(120, 54);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(358, 287);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.confirmButton.Location = new System.Drawing.Point(2, 224);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(2);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(348, 51);
            this.confirmButton.TabIndex = 10;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // CarFactoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(582, 348);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.Name = "CarFactoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CarFactory";
            this.colorBox.ResumeLayout(false);
            this.engineBox.ResumeLayout(false);
            this.transmissionBox.ResumeLayout(false);
            this.formBox.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Label label1;
        private GroupBox formTypeBox;
        private GroupBox colorBox;
        private ComboBox carColor;
        private GroupBox engineBox;
        private ComboBox carEngine;
        private GroupBox transmissionBox;
        private ComboBox carTransmission;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button confirmButton;
        private GroupBox formBox;
        private ComboBox carFormType;
    }
}