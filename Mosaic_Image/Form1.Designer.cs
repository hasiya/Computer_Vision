namespace Mosaic_Image
{
    partial class Form1
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
            this.TargetBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.MosaicBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.ImageProgressBar = new System.Windows.Forms.ProgressBar();
            this.pers = new System.Windows.Forms.Label();
            this.TrgtImgDneTxt = new System.Windows.Forms.TextBox();
            this.MosiacImgDneTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tileSize = new System.Windows.Forms.ComboBox();
            this.Tile_man_DneTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Tile_Brws_Btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TargetBtn
            // 
            this.TargetBtn.Location = new System.Drawing.Point(179, 42);
            this.TargetBtn.Name = "TargetBtn";
            this.TargetBtn.Size = new System.Drawing.Size(87, 23);
            this.TargetBtn.TabIndex = 2;
            this.TargetBtn.Text = "Browse";
            this.TargetBtn.UseVisualStyleBackColor = true;
            this.TargetBtn.Click += new System.EventHandler(this.TargetBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Taget Image";
            // 
            // MosaicBtn
            // 
            this.MosaicBtn.Location = new System.Drawing.Point(65, 126);
            this.MosaicBtn.Name = "MosaicBtn";
            this.MosaicBtn.Size = new System.Drawing.Size(128, 34);
            this.MosaicBtn.TabIndex = 4;
            this.MosaicBtn.Text = "Create Mosiac";
            this.MosaicBtn.UseVisualStyleBackColor = true;
            this.MosaicBtn.Click += new System.EventHandler(this.MosiacBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(278, 126);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(128, 34);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // ImageBox
            // 
            this.ImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImageBox.Location = new System.Drawing.Point(447, 12);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(366, 315);
            this.ImageBox.TabIndex = 9;
            this.ImageBox.TabStop = false;
            // 
            // ImageProgressBar
            // 
            this.ImageProgressBar.Location = new System.Drawing.Point(65, 218);
            this.ImageProgressBar.Name = "ImageProgressBar";
            this.ImageProgressBar.Size = new System.Drawing.Size(341, 30);
            this.ImageProgressBar.TabIndex = 10;
            // 
            // pers
            // 
            this.pers.AutoSize = true;
            this.pers.Location = new System.Drawing.Point(72, 254);
            this.pers.Name = "pers";
            this.pers.Size = new System.Drawing.Size(0, 13);
            this.pers.TabIndex = 11;
            // 
            // TrgtImgDneTxt
            // 
            this.TrgtImgDneTxt.BackColor = System.Drawing.SystemColors.Info;
            this.TrgtImgDneTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TrgtImgDneTxt.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TrgtImgDneTxt.Location = new System.Drawing.Point(278, 45);
            this.TrgtImgDneTxt.Multiline = true;
            this.TrgtImgDneTxt.Name = "TrgtImgDneTxt";
            this.TrgtImgDneTxt.ReadOnly = true;
            this.TrgtImgDneTxt.Size = new System.Drawing.Size(149, 20);
            this.TrgtImgDneTxt.TabIndex = 12;
            this.TrgtImgDneTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MosiacImgDneTxt
            // 
            this.MosiacImgDneTxt.BackColor = System.Drawing.SystemColors.Info;
            this.MosiacImgDneTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MosiacImgDneTxt.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MosiacImgDneTxt.Location = new System.Drawing.Point(65, 177);
            this.MosiacImgDneTxt.Multiline = true;
            this.MosiacImgDneTxt.Name = "MosiacImgDneTxt";
            this.MosiacImgDneTxt.ReadOnly = true;
            this.MosiacImgDneTxt.Size = new System.Drawing.Size(341, 20);
            this.MosiacImgDneTxt.TabIndex = 14;
            this.MosiacImgDneTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Select Tile Size";
            // 
            // tileSize
            // 
            this.tileSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tileSize.FormattingEnabled = true;
            this.tileSize.Items.AddRange(new object[] {
            "5 X 5",
            "10 X 10",
            "25 X 25",
            "50 X 50",
            "75 X 75",
            "100 X 100"});
            this.tileSize.Location = new System.Drawing.Point(179, 87);
            this.tileSize.Name = "tileSize";
            this.tileSize.Size = new System.Drawing.Size(87, 21);
            this.tileSize.TabIndex = 16;
            this.tileSize.SelectedIndexChanged += new System.EventHandler(this.tileSize_SelectedIndexChanged);
            // 
            // Tile_man_DneTxt
            // 
            this.Tile_man_DneTxt.BackColor = System.Drawing.SystemColors.Info;
            this.Tile_man_DneTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Tile_man_DneTxt.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Tile_man_DneTxt.Location = new System.Drawing.Point(278, 294);
            this.Tile_man_DneTxt.Multiline = true;
            this.Tile_man_DneTxt.Name = "Tile_man_DneTxt";
            this.Tile_man_DneTxt.ReadOnly = true;
            this.Tile_man_DneTxt.Size = new System.Drawing.Size(149, 20);
            this.Tile_man_DneTxt.TabIndex = 19;
            this.Tile_man_DneTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Tile_man_DneTxt.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Select Tile Images Folder";
            this.label4.Visible = false;
            // 
            // Tile_Brws_Btn
            // 
            this.Tile_Brws_Btn.Location = new System.Drawing.Point(179, 291);
            this.Tile_Brws_Btn.Name = "Tile_Brws_Btn";
            this.Tile_Brws_Btn.Size = new System.Drawing.Size(87, 23);
            this.Tile_Brws_Btn.TabIndex = 17;
            this.Tile_Brws_Btn.Text = "Browse ";
            this.Tile_Brws_Btn.UseVisualStyleBackColor = true;
            this.Tile_Brws_Btn.Visible = false;
            this.Tile_Brws_Btn.Click += new System.EventHandler(this.Tile_Brws_Btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 339);
            this.Controls.Add(this.Tile_man_DneTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Tile_Brws_Btn);
            this.Controls.Add(this.tileSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MosiacImgDneTxt);
            this.Controls.Add(this.TrgtImgDneTxt);
            this.Controls.Add(this.pers);
            this.Controls.Add(this.ImageProgressBar);
            this.Controls.Add(this.ImageBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.MosaicBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TargetBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Tile_nat_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TargetBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button MosaicBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.ProgressBar ImageProgressBar;
        private System.Windows.Forms.Label pers;
        private System.Windows.Forms.TextBox TrgtImgDneTxt;
        private System.Windows.Forms.TextBox Tile_nat_DneTxt;
        private System.Windows.Forms.TextBox MosiacImgDneTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox tileSize;
        private System.Windows.Forms.TextBox Tile_man_DneTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Tile_Brws_Btn;

    }
}

