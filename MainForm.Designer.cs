namespace ScanShell_OCR
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
            this.txtExtractedText = new System.Windows.Forms.TextBox();
            this.picScannedImage = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.imgSelectorButton = new System.Windows.Forms.Button();
            this.testMapper = new System.Windows.Forms.Button();
            this.cropedPicture = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pipelineButton = new System.Windows.Forms.Button();
            this.debugPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picScannedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cropedPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.debugPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // txtExtractedText
            // 
            this.txtExtractedText.AllowDrop = true;
            this.txtExtractedText.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtractedText.Location = new System.Drawing.Point(417, 180);
            this.txtExtractedText.Margin = new System.Windows.Forms.Padding(6);
            this.txtExtractedText.Multiline = true;
            this.txtExtractedText.Name = "txtExtractedText";
            this.txtExtractedText.ReadOnly = true;
            this.txtExtractedText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtExtractedText.Size = new System.Drawing.Size(377, 120);
            this.txtExtractedText.TabIndex = 1;
            // 
            // picScannedImage
            // 
            this.picScannedImage.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.picScannedImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picScannedImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picScannedImage.Location = new System.Drawing.Point(13, 12);
            this.picScannedImage.Name = "picScannedImage";
            this.picScannedImage.Size = new System.Drawing.Size(395, 291);
            this.picScannedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picScannedImage.TabIndex = 3;
            this.picScannedImage.TabStop = false;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(643, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 77);
            this.button1.TabIndex = 4;
            this.button1.Text = "Scan";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(668, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "Clear Image And Text";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(719, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 77);
            this.button3.TabIndex = 6;
            this.button3.Text = "Extract";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // imgSelectorButton
            // 
            this.imgSelectorButton.Location = new System.Drawing.Point(562, 12);
            this.imgSelectorButton.Name = "imgSelectorButton";
            this.imgSelectorButton.Size = new System.Drawing.Size(75, 77);
            this.imgSelectorButton.TabIndex = 7;
            this.imgSelectorButton.Text = "Select Image";
            this.imgSelectorButton.UseVisualStyleBackColor = true;
            this.imgSelectorButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // testMapper
            // 
            this.testMapper.Enabled = false;
            this.testMapper.Location = new System.Drawing.Point(562, 136);
            this.testMapper.Name = "testMapper";
            this.testMapper.Size = new System.Drawing.Size(100, 35);
            this.testMapper.TabIndex = 8;
            this.testMapper.Text = "Test Mapper";
            this.testMapper.UseVisualStyleBackColor = true;
            this.testMapper.Click += new System.EventHandler(this.ParseMRZButton_Click);
            // 
            // cropedPicture
            // 
            this.cropedPicture.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cropedPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cropedPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cropedPicture.Location = new System.Drawing.Point(12, 309);
            this.cropedPicture.Name = "cropedPicture";
            this.cropedPicture.Size = new System.Drawing.Size(396, 291);
            this.cropedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cropedPicture.TabIndex = 9;
            this.cropedPicture.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.SystemColors.Info;
            this.lblStatus.Location = new System.Drawing.Point(562, 92);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(234, 41);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "label1";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pipelineButton
            // 
            this.pipelineButton.Location = new System.Drawing.Point(417, 12);
            this.pipelineButton.Name = "pipelineButton";
            this.pipelineButton.Size = new System.Drawing.Size(128, 55);
            this.pipelineButton.TabIndex = 12;
            this.pipelineButton.Text = "Full Process";
            this.pipelineButton.UseVisualStyleBackColor = true;
            this.pipelineButton.Click += new System.EventHandler(this.pipelineButton_Click);
            // 
            // debugPicture
            // 
            this.debugPicture.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.debugPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.debugPicture.Location = new System.Drawing.Point(414, 309);
            this.debugPicture.Name = "debugPicture";
            this.debugPicture.Size = new System.Drawing.Size(380, 291);
            this.debugPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.debugPicture.TabIndex = 13;
            this.debugPicture.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 608);
            this.Controls.Add(this.debugPicture);
            this.Controls.Add(this.pipelineButton);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cropedPicture);
            this.Controls.Add(this.testMapper);
            this.Controls.Add(this.imgSelectorButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picScannedImage);
            this.Controls.Add(this.txtExtractedText);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picScannedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cropedPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.debugPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtExtractedText;
        private System.Windows.Forms.PictureBox picScannedImage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button imgSelectorButton;
        private System.Windows.Forms.Button testMapper;
        private System.Windows.Forms.PictureBox cropedPicture;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button pipelineButton;
        private System.Windows.Forms.PictureBox debugPicture;
    }
}

