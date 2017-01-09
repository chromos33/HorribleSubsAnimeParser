namespace HorribleSubsParserForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.Anime = new System.Windows.Forms.TextBox();
            this.Resolution = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AddAnime = new System.Windows.Forms.Button();
            this.AnimeList = new System.Windows.Forms.ListBox();
            this.RemoveAnime = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Anime";
            // 
            // Anime
            // 
            this.Anime.AccessibleName = "AnimeName";
            this.Anime.Location = new System.Drawing.Point(35, 53);
            this.Anime.Name = "Anime";
            this.Anime.Size = new System.Drawing.Size(100, 20);
            this.Anime.TabIndex = 1;
            // 
            // Resolution
            // 
            this.Resolution.AccessibleName = "AnimeResolution";
            this.Resolution.FormattingEnabled = true;
            this.Resolution.Items.AddRange(new object[] {
            "480p",
            "720p",
            "1080p"});
            this.Resolution.Location = new System.Drawing.Point(35, 111);
            this.Resolution.Name = "Resolution";
            this.Resolution.Size = new System.Drawing.Size(121, 21);
            this.Resolution.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Resolution";
            // 
            // AddAnime
            // 
            this.AddAnime.AccessibleName = "AddAnime";
            this.AddAnime.Location = new System.Drawing.Point(35, 152);
            this.AddAnime.Name = "AddAnime";
            this.AddAnime.Size = new System.Drawing.Size(75, 23);
            this.AddAnime.TabIndex = 4;
            this.AddAnime.Text = "Add";
            this.AddAnime.UseVisualStyleBackColor = true;
            this.AddAnime.Click += new System.EventHandler(this.AddAnime_Click);
            // 
            // AnimeList
            // 
            this.AnimeList.FormattingEnabled = true;
            this.AnimeList.Location = new System.Drawing.Point(193, 28);
            this.AnimeList.Name = "AnimeList";
            this.AnimeList.Size = new System.Drawing.Size(201, 485);
            this.AnimeList.TabIndex = 5;
            // 
            // RemoveAnime
            // 
            this.RemoveAnime.AccessibleName = "RemoveAnime";
            this.RemoveAnime.Location = new System.Drawing.Point(35, 490);
            this.RemoveAnime.Name = "RemoveAnime";
            this.RemoveAnime.Size = new System.Drawing.Size(75, 23);
            this.RemoveAnime.TabIndex = 6;
            this.RemoveAnime.Text = "remove";
            this.RemoveAnime.UseVisualStyleBackColor = true;
            this.RemoveAnime.Click += new System.EventHandler(this.RemoveAnime_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 541);
            this.Controls.Add(this.RemoveAnime);
            this.Controls.Add(this.AnimeList);
            this.Controls.Add(this.AddAnime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Resolution);
            this.Controls.Add(this.Anime);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Anime;
        private System.Windows.Forms.ComboBox Resolution;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button AddAnime;
        private System.Windows.Forms.ListBox AnimeList;
        private System.Windows.Forms.Button RemoveAnime;
    }
}

