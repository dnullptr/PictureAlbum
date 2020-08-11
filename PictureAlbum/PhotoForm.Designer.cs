namespace PictureAlbum
{
    partial class PhotoForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.descText = new System.Windows.Forms.TextBox();
            this.descLbl = new System.Windows.Forms.Label();
            this.locationCmb = new System.Windows.Forms.ComboBox();
            this.locationLbl = new System.Windows.Forms.Label();
            this.catLbl = new System.Windows.Forms.Label();
            this.categoryCmb = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Del = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.updatebtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // descText
            // 
            this.descText.Location = new System.Drawing.Point(90, 200);
            this.descText.Name = "descText";
            this.descText.Size = new System.Drawing.Size(100, 20);
            this.descText.TabIndex = 2;
            // 
            // descLbl
            // 
            this.descLbl.AutoSize = true;
            this.descLbl.Location = new System.Drawing.Point(3, 203);
            this.descLbl.Name = "descLbl";
            this.descLbl.Size = new System.Drawing.Size(81, 13);
            this.descLbl.TabIndex = 3;
            this.descLbl.Text = "Pic Description:";
            // 
            // locationCmb
            // 
            this.locationCmb.FormattingEnabled = true;
            this.locationCmb.Location = new System.Drawing.Point(90, 227);
            this.locationCmb.Name = "locationCmb";
            this.locationCmb.Size = new System.Drawing.Size(100, 21);
            this.locationCmb.TabIndex = 4;
            // 
            // locationLbl
            // 
            this.locationLbl.AutoSize = true;
            this.locationLbl.Location = new System.Drawing.Point(12, 230);
            this.locationLbl.Name = "locationLbl";
            this.locationLbl.Size = new System.Drawing.Size(48, 13);
            this.locationLbl.TabIndex = 5;
            this.locationLbl.Text = "Location";
            // 
            // catLbl
            // 
            this.catLbl.AutoSize = true;
            this.catLbl.Location = new System.Drawing.Point(12, 258);
            this.catLbl.Name = "catLbl";
            this.catLbl.Size = new System.Drawing.Size(49, 13);
            this.catLbl.TabIndex = 6;
            this.catLbl.Text = "Category";
            // 
            // categoryCmb
            // 
            this.categoryCmb.FormattingEnabled = true;
            this.categoryCmb.Location = new System.Drawing.Point(90, 258);
            this.categoryCmb.Name = "categoryCmb";
            this.categoryCmb.Size = new System.Drawing.Size(100, 21);
            this.categoryCmb.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(51, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 43);
            this.button2.TabIndex = 8;
            this.button2.Text = "Save Picture";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Save_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Del,
            this.Update});
            this.dataGridView1.Location = new System.Drawing.Point(315, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(691, 449);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // Del
            // 
            this.Del.HeaderText = "Del";
            this.Del.Name = "Del";
            // 
            // Update
            // 
            this.Update.HeaderText = "Update";
            this.Update.Name = "Update";
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(196, 197);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(75, 23);
            this.updatebtn.TabIndex = 10;
            this.updatebtn.Text = "Update";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.Updatebtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(15, 387);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(272, 167);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // PhotoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 599);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.categoryCmb);
            this.Controls.Add(this.catLbl);
            this.Controls.Add(this.locationLbl);
            this.Controls.Add(this.locationCmb);
            this.Controls.Add(this.descLbl);
            this.Controls.Add(this.descText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "PhotoForm";
            this.Text = "PhotoForm";
            this.Load += new System.EventHandler(this.PhotoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox descText;
        private System.Windows.Forms.Label descLbl;
        private System.Windows.Forms.ComboBox locationCmb;
        private System.Windows.Forms.Label locationLbl;
        private System.Windows.Forms.Label catLbl;
        private System.Windows.Forms.ComboBox categoryCmb;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn Del;
        private System.Windows.Forms.DataGridViewButtonColumn Update;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}