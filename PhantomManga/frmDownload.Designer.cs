namespace PhantomManga
{
    partial class frmDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDownload));
            this.manga_picture = new System.Windows.Forms.PictureBox();
            this.manga_name = new System.Windows.Forms.Label();
            this.manga_description = new System.Windows.Forms.Label();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.manga_chapternum = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.manga_startpagenum = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.manga_endpagenum = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.manga_getlast = new System.Windows.Forms.Label();
            this.manga_download = new MaterialSkin.Controls.MaterialRaisedButton();
            this.Manga_resize = new MaterialSkin.Controls.MaterialCheckBox();
            this.materialDivider2 = new MaterialSkin.Controls.MaterialDivider();
            this.bulk_chapternums = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.bulk_download = new MaterialSkin.Controls.MaterialRaisedButton();
            this.autofindpages = new MaterialSkin.Controls.MaterialCheckBox();
            this.bulk_progress = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.manga_picture)).BeginInit();
            this.SuspendLayout();
            // 
            // manga_picture
            // 
            this.manga_picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.manga_picture.Location = new System.Drawing.Point(12, 75);
            this.manga_picture.Name = "manga_picture";
            this.manga_picture.Size = new System.Drawing.Size(154, 205);
            this.manga_picture.TabIndex = 0;
            this.manga_picture.TabStop = false;
            // 
            // manga_name
            // 
            this.manga_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.manga_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(38)))));
            this.manga_name.Location = new System.Drawing.Point(172, 75);
            this.manga_name.Name = "manga_name";
            this.manga_name.Size = new System.Drawing.Size(291, 46);
            this.manga_name.TabIndex = 21;
            this.manga_name.Text = "Fetching manga name..";
            // 
            // manga_description
            // 
            this.manga_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.manga_description.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(38)))));
            this.manga_description.Location = new System.Drawing.Point(172, 121);
            this.manga_description.Name = "manga_description";
            this.manga_description.Size = new System.Drawing.Size(291, 192);
            this.manga_description.TabIndex = 22;
            this.manga_description.Text = "Fetching manga description..";
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(469, 64);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(2, 260);
            this.materialDivider1.TabIndex = 23;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // manga_chapternum
            // 
            this.manga_chapternum.Depth = 0;
            this.manga_chapternum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.manga_chapternum.Hint = "Chapter #";
            this.manga_chapternum.Location = new System.Drawing.Point(480, 75);
            this.manga_chapternum.MaxLength = 32767;
            this.manga_chapternum.MouseState = MaterialSkin.MouseState.HOVER;
            this.manga_chapternum.Name = "manga_chapternum";
            this.manga_chapternum.PasswordChar = '\0';
            this.manga_chapternum.SelectedText = "";
            this.manga_chapternum.SelectionLength = 0;
            this.manga_chapternum.SelectionStart = 0;
            this.manga_chapternum.Size = new System.Drawing.Size(156, 23);
            this.manga_chapternum.TabIndex = 24;
            this.manga_chapternum.TabStop = false;
            this.manga_chapternum.UseSystemPasswordChar = false;
            // 
            // manga_startpagenum
            // 
            this.manga_startpagenum.Depth = 0;
            this.manga_startpagenum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.manga_startpagenum.Hint = "Page #";
            this.manga_startpagenum.Location = new System.Drawing.Point(480, 104);
            this.manga_startpagenum.MaxLength = 32767;
            this.manga_startpagenum.MouseState = MaterialSkin.MouseState.HOVER;
            this.manga_startpagenum.Name = "manga_startpagenum";
            this.manga_startpagenum.PasswordChar = '\0';
            this.manga_startpagenum.SelectedText = "";
            this.manga_startpagenum.SelectionLength = 0;
            this.manga_startpagenum.SelectionStart = 0;
            this.manga_startpagenum.Size = new System.Drawing.Size(60, 23);
            this.manga_startpagenum.TabIndex = 25;
            this.manga_startpagenum.TabStop = false;
            this.manga_startpagenum.UseSystemPasswordChar = false;
            // 
            // manga_endpagenum
            // 
            this.manga_endpagenum.Depth = 0;
            this.manga_endpagenum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.manga_endpagenum.Hint = "Page #";
            this.manga_endpagenum.Location = new System.Drawing.Point(576, 104);
            this.manga_endpagenum.MaxLength = 32767;
            this.manga_endpagenum.MouseState = MaterialSkin.MouseState.HOVER;
            this.manga_endpagenum.Name = "manga_endpagenum";
            this.manga_endpagenum.PasswordChar = '\0';
            this.manga_endpagenum.SelectedText = "";
            this.manga_endpagenum.SelectionLength = 0;
            this.manga_endpagenum.SelectionStart = 0;
            this.manga_endpagenum.Size = new System.Drawing.Size(60, 23);
            this.manga_endpagenum.TabIndex = 26;
            this.manga_endpagenum.TabStop = false;
            this.manga_endpagenum.UseSystemPasswordChar = false;
            // 
            // manga_getlast
            // 
            this.manga_getlast.AutoSize = true;
            this.manga_getlast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.manga_getlast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(38)))));
            this.manga_getlast.Location = new System.Drawing.Point(553, 108);
            this.manga_getlast.Name = "manga_getlast";
            this.manga_getlast.Size = new System.Drawing.Size(10, 13);
            this.manga_getlast.TabIndex = 27;
            this.manga_getlast.Text = "-";
            this.manga_getlast.Click += new System.EventHandler(this.manga_getlast_Click);
            // 
            // manga_download
            // 
            this.manga_download.AutoSize = true;
            this.manga_download.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.manga_download.Depth = 0;
            this.manga_download.Icon = null;
            this.manga_download.Location = new System.Drawing.Point(477, 133);
            this.manga_download.MouseState = MaterialSkin.MouseState.HOVER;
            this.manga_download.Name = "manga_download";
            this.manga_download.Primary = true;
            this.manga_download.Size = new System.Drawing.Size(161, 36);
            this.manga_download.TabIndex = 28;
            this.manga_download.Text = "download chapter";
            this.manga_download.UseVisualStyleBackColor = true;
            this.manga_download.Click += new System.EventHandler(this.manga_download_Click);
            // 
            // Manga_resize
            // 
            this.Manga_resize.AutoSize = true;
            this.Manga_resize.Checked = true;
            this.Manga_resize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Manga_resize.Depth = 0;
            this.Manga_resize.Font = new System.Drawing.Font("Roboto", 10F);
            this.Manga_resize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.Manga_resize.Location = new System.Drawing.Point(12, 283);
            this.Manga_resize.Margin = new System.Windows.Forms.Padding(0);
            this.Manga_resize.MouseLocation = new System.Drawing.Point(-1, -1);
            this.Manga_resize.MouseState = MaterialSkin.MouseState.HOVER;
            this.Manga_resize.Name = "Manga_resize";
            this.Manga_resize.Ripple = true;
            this.Manga_resize.Size = new System.Drawing.Size(149, 30);
            this.Manga_resize.TabIndex = 31;
            this.Manga_resize.Text = "Optimize Page Size";
            this.Manga_resize.UseVisualStyleBackColor = true;
            // 
            // materialDivider2
            // 
            this.materialDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Location = new System.Drawing.Point(469, 175);
            this.materialDivider2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(176, 2);
            this.materialDivider2.TabIndex = 32;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // bulk_chapternums
            // 
            this.bulk_chapternums.Depth = 0;
            this.bulk_chapternums.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.bulk_chapternums.Hint = "Chapter #\'s (1-2, 1-5, ..)";
            this.bulk_chapternums.Location = new System.Drawing.Point(480, 183);
            this.bulk_chapternums.MaxLength = 32767;
            this.bulk_chapternums.MouseState = MaterialSkin.MouseState.HOVER;
            this.bulk_chapternums.Name = "bulk_chapternums";
            this.bulk_chapternums.PasswordChar = '\0';
            this.bulk_chapternums.SelectedText = "";
            this.bulk_chapternums.SelectionLength = 0;
            this.bulk_chapternums.SelectionStart = 0;
            this.bulk_chapternums.Size = new System.Drawing.Size(156, 23);
            this.bulk_chapternums.TabIndex = 33;
            this.bulk_chapternums.TabStop = false;
            this.bulk_chapternums.UseSystemPasswordChar = false;
            // 
            // bulk_download
            // 
            this.bulk_download.AutoSize = true;
            this.bulk_download.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bulk_download.Depth = 0;
            this.bulk_download.Icon = null;
            this.bulk_download.Location = new System.Drawing.Point(473, 212);
            this.bulk_download.MouseState = MaterialSkin.MouseState.HOVER;
            this.bulk_download.Name = "bulk_download";
            this.bulk_download.Primary = true;
            this.bulk_download.Size = new System.Drawing.Size(169, 36);
            this.bulk_download.TabIndex = 34;
            this.bulk_download.Text = "download chapters";
            this.bulk_download.UseVisualStyleBackColor = true;
            this.bulk_download.Click += new System.EventHandler(this.bulk_download_Click);
            // 
            // autofindpages
            // 
            this.autofindpages.AutoSize = true;
            this.autofindpages.Depth = 0;
            this.autofindpages.Font = new System.Drawing.Font("Roboto", 10F);
            this.autofindpages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(87)))), ((int)(((byte)(200)))));
            this.autofindpages.Location = new System.Drawing.Point(493, 286);
            this.autofindpages.Margin = new System.Windows.Forms.Padding(0);
            this.autofindpages.MouseLocation = new System.Drawing.Point(-1, -1);
            this.autofindpages.MouseState = MaterialSkin.MouseState.HOVER;
            this.autofindpages.Name = "autofindpages";
            this.autofindpages.Ripple = true;
            this.autofindpages.Size = new System.Drawing.Size(131, 30);
            this.autofindpages.TabIndex = 35;
            this.autofindpages.Text = "Auto Find Pages";
            this.autofindpages.UseVisualStyleBackColor = true;
            this.autofindpages.CheckedChanged += new System.EventHandler(this.autofindpages_CheckedChanged);
            // 
            // bulk_progress
            // 
            this.bulk_progress.Location = new System.Drawing.Point(473, 254);
            this.bulk_progress.Name = "bulk_progress";
            this.bulk_progress.Size = new System.Drawing.Size(169, 10);
            this.bulk_progress.TabIndex = 36;
            this.bulk_progress.Visible = false;
            // 
            // frmDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 325);
            this.Controls.Add(this.bulk_progress);
            this.Controls.Add(this.autofindpages);
            this.Controls.Add(this.bulk_download);
            this.Controls.Add(this.bulk_chapternums);
            this.Controls.Add(this.materialDivider2);
            this.Controls.Add(this.Manga_resize);
            this.Controls.Add(this.manga_download);
            this.Controls.Add(this.manga_getlast);
            this.Controls.Add(this.manga_endpagenum);
            this.Controls.Add(this.manga_startpagenum);
            this.Controls.Add(this.manga_chapternum);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.manga_description);
            this.Controls.Add(this.manga_name);
            this.Controls.Add(this.manga_picture);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDownload";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Download";
            ((System.ComponentModel.ISupportInitialize)(this.manga_picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox manga_picture;
        private System.Windows.Forms.Label manga_name;
        private System.Windows.Forms.Label manga_description;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialSingleLineTextField manga_chapternum;
        private MaterialSkin.Controls.MaterialSingleLineTextField manga_startpagenum;
        private MaterialSkin.Controls.MaterialSingleLineTextField manga_endpagenum;
        private System.Windows.Forms.Label manga_getlast;
        private MaterialSkin.Controls.MaterialRaisedButton manga_download;
        private MaterialSkin.Controls.MaterialCheckBox Manga_resize;
        private MaterialSkin.Controls.MaterialDivider materialDivider2;
        private MaterialSkin.Controls.MaterialSingleLineTextField bulk_chapternums;
        private MaterialSkin.Controls.MaterialRaisedButton bulk_download;
        private MaterialSkin.Controls.MaterialCheckBox autofindpages;
        private System.Windows.Forms.ProgressBar bulk_progress;
    }
}