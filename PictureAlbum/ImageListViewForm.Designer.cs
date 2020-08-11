namespace PictureAlbum
{
    partial class ImageListViewForm
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Select = new System.Windows.Forms.Button();
            this.Deselect = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Select
            // 
            this.Select.Location = new System.Drawing.Point(713, 57);
            this.Select.Name = "Select";
            this.Select.Size = new System.Drawing.Size(75, 23);
            this.Select.TabIndex = 0;
            this.Select.Text = "Select All";
            this.Select.UseVisualStyleBackColor = true;
            this.Select.Click += new System.EventHandler(this.Select_Click);
            // 
            // Deselect
            // 
            this.Deselect.Location = new System.Drawing.Point(713, 97);
            this.Deselect.Name = "Deselect";
            this.Deselect.Size = new System.Drawing.Size(75, 23);
            this.Deselect.TabIndex = 1;
            this.Deselect.Text = "Deselect All";
            this.Deselect.UseVisualStyleBackColor = true;
            this.Deselect.Click += new System.EventHandler(this.Deselect_Click);
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(713, 138);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 2;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // ImageListViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Deselect);
            this.Controls.Add(this.Select);
            this.Name = "ImageListViewForm";
            this.Text = "ImageListViewForm";
            this.Load += new System.EventHandler(this.ImageListViewForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button Select;
        private System.Windows.Forms.Button Deselect;
        private System.Windows.Forms.Button Delete;
    }
}