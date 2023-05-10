namespace HostelManagement
{
    partial class C2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(C2));
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.detailsicon = new System.Windows.Forms.PictureBox();
            this.profileicon = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.issuelabel = new System.Windows.Forms.Label();
            this.issuesicon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailsicon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profileicon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.issuesicon)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Beige;
            this.button2.Font = new System.Drawing.Font("Bookman Old Style", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(876, 683);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 30);
            this.button2.TabIndex = 153;
            this.button2.Text = "Logout";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(459, 67);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(284, 167);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 151;
            this.pictureBox6.TabStop = false;
            // 
            // detailsicon
            // 
            this.detailsicon.BackColor = System.Drawing.Color.Transparent;
            this.detailsicon.BackgroundImage = global::HostelManagement.Properties.Resources.searchicon1;
            this.detailsicon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.detailsicon.Location = new System.Drawing.Point(68, 525);
            this.detailsicon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.detailsicon.Name = "detailsicon";
            this.detailsicon.Size = new System.Drawing.Size(61, 67);
            this.detailsicon.TabIndex = 150;
            this.detailsicon.TabStop = false;
            // 
            // profileicon
            // 
            this.profileicon.BackColor = System.Drawing.Color.Transparent;
            this.profileicon.BackgroundImage = global::HostelManagement.Properties.Resources.profile_icon;
            this.profileicon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.profileicon.Location = new System.Drawing.Point(68, 188);
            this.profileicon.Name = "profileicon";
            this.profileicon.Size = new System.Drawing.Size(61, 58);
            this.profileicon.TabIndex = 149;
            this.profileicon.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Location = new System.Drawing.Point(64, 426);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 5);
            this.pictureBox1.TabIndex = 148;
            this.pictureBox1.TabStop = false;
            // 
            // issuelabel
            // 
            this.issuelabel.AutoSize = true;
            this.issuelabel.BackColor = System.Drawing.Color.Transparent;
            this.issuelabel.Font = new System.Drawing.Font("Bookman Old Style", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.issuelabel.Location = new System.Drawing.Point(60, 340);
            this.issuelabel.Name = "issuelabel";
            this.issuelabel.Size = new System.Drawing.Size(88, 19);
            this.issuelabel.TabIndex = 147;
            this.issuelabel.Text = "Complaints";
            this.issuelabel.Click += new System.EventHandler(this.issuelabel_Click);
            // 
            // issuesicon
            // 
            this.issuesicon.BackColor = System.Drawing.Color.Transparent;
            this.issuesicon.BackgroundImage = global::HostelManagement.Properties.Resources.issues_icon2;
            this.issuesicon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.issuesicon.Location = new System.Drawing.Point(68, 362);
            this.issuesicon.Name = "issuesicon";
            this.issuesicon.Size = new System.Drawing.Size(61, 58);
            this.issuesicon.TabIndex = 146;
            this.issuesicon.TabStop = false;
            // 
            // C2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HostelManagement.Properties.Resources.caretaker2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1039, 745);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.detailsicon);
            this.Controls.Add(this.profileicon);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.issuelabel);
            this.Controls.Add(this.issuesicon);
            this.DoubleBuffered = true;
            this.Name = "C2";
            this.Text = "Issues Handling Portal";
            this.Load += new System.EventHandler(this.C2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailsicon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profileicon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.issuesicon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox detailsicon;
        private System.Windows.Forms.PictureBox profileicon;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label issuelabel;
        private System.Windows.Forms.PictureBox issuesicon;

    }
}