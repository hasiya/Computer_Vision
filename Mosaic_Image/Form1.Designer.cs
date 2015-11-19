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
            this.TileBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TargetBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.MosiacBtn = new System.Windows.Forms.Button();
            this.TrgtImgDneLbl = new System.Windows.Forms.Label();
            this.TileImgDneLbl = new System.Windows.Forms.Label();
            this.MosiacImgDneLbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.ImageProgressBar = new System.Windows.Forms.ProgressBar();
            this.pers = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TileBtn
            // 
            this.TileBtn.Location = new System.Drawing.Point(159, 60);
            this.TileBtn.Name = "TileBtn";
            this.TileBtn.Size = new System.Drawing.Size(75, 23);
            this.TileBtn.TabIndex = 0;
            this.TileBtn.Text = "Browse ";
            this.TileBtn.UseVisualStyleBackColor = true;
            this.TileBtn.Click += new System.EventHandler(this.TileBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Tile Images Folder";
            // 
            // TargetBtn
            // 
            this.TargetBtn.Location = new System.Drawing.Point(159, 19);
            this.TargetBtn.Name = "TargetBtn";
            this.TargetBtn.Size = new System.Drawing.Size(75, 23);
            this.TargetBtn.TabIndex = 2;
            this.TargetBtn.Text = "Browse";
            this.TargetBtn.UseVisualStyleBackColor = true;
            this.TargetBtn.Click += new System.EventHandler(this.TargetBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Taget Image";
            // 
            // MosiacBtn
            // 
            this.MosiacBtn.Location = new System.Drawing.Point(79, 105);
            this.MosiacBtn.Name = "MosiacBtn";
            this.MosiacBtn.Size = new System.Drawing.Size(106, 23);
            this.MosiacBtn.TabIndex = 4;
            this.MosiacBtn.Text = "Create Mosiac";
            this.MosiacBtn.UseVisualStyleBackColor = true;
            this.MosiacBtn.Click += new System.EventHandler(this.MosiacBtn_Click);
            // 
            // TrgtImgDneLbl
            // 
            this.TrgtImgDneLbl.AutoSize = true;
            this.TrgtImgDneLbl.Location = new System.Drawing.Point(240, 24);
            this.TrgtImgDneLbl.Name = "TrgtImgDneLbl";
            this.TrgtImgDneLbl.Size = new System.Drawing.Size(0, 13);
            this.TrgtImgDneLbl.TabIndex = 5;
            // 
            // TileImgDneLbl
            // 
            this.TileImgDneLbl.AutoSize = true;
            this.TileImgDneLbl.Location = new System.Drawing.Point(240, 65);
            this.TileImgDneLbl.Name = "TileImgDneLbl";
            this.TileImgDneLbl.Size = new System.Drawing.Size(0, 13);
            this.TileImgDneLbl.TabIndex = 6;
            // 
            // MosiacImgDneLbl
            // 
            this.MosiacImgDneLbl.AutoSize = true;
            this.MosiacImgDneLbl.Location = new System.Drawing.Point(191, 110);
            this.MosiacImgDneLbl.Name = "MosiacImgDneLbl";
            this.MosiacImgDneLbl.Size = new System.Drawing.Size(0, 13);
            this.MosiacImgDneLbl.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(109, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ImageBox
            // 
            this.ImageBox.Location = new System.Drawing.Point(384, 19);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(366, 301);
            this.ImageBox.TabIndex = 9;
            this.ImageBox.TabStop = false;
            // 
            // ImageProgressBar
            // 
            this.ImageProgressBar.Location = new System.Drawing.Point(15, 208);
            this.ImageProgressBar.Name = "ImageProgressBar";
            this.ImageProgressBar.Size = new System.Drawing.Size(219, 30);
            this.ImageProgressBar.TabIndex = 10;
            // 
            // pers
            // 
            this.pers.AutoSize = true;
            this.pers.Location = new System.Drawing.Point(79, 256);
            this.pers.Name = "pers";
            this.pers.Size = new System.Drawing.Size(35, 13);
            this.pers.TabIndex = 11;
            this.pers.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 339);
            this.Controls.Add(this.pers);
            this.Controls.Add(this.ImageProgressBar);
            this.Controls.Add(this.ImageBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MosiacImgDneLbl);
            this.Controls.Add(this.TileImgDneLbl);
            this.Controls.Add(this.TrgtImgDneLbl);
            this.Controls.Add(this.MosiacBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TargetBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TileBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TileBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TargetBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button MosiacBtn;
        private System.Windows.Forms.Label TrgtImgDneLbl;
        private System.Windows.Forms.Label TileImgDneLbl;
        private System.Windows.Forms.Label MosiacImgDneLbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.ProgressBar ImageProgressBar;
        private System.Windows.Forms.Label pers;

    }
}

