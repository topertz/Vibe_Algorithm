namespace Video
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
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.imageBoxVideo = new Emgu.CV.UI.ImageBox();
            this.imageBoxCurrentFrame = new Emgu.CV.UI.ImageBox();
            this.trackBarProcessing = new System.Windows.Forms.TrackBar();
            this.progressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxCurrentFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProcessing)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 134);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 49);
            this.button2.TabIndex = 4;
            this.button2.Text = "Framek kinyerése és ViBe algoritmus";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.VibeAlgorithm);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // imageBoxVideo
            // 
            this.imageBoxVideo.Location = new System.Drawing.Point(167, 44);
            this.imageBoxVideo.Name = "imageBoxVideo";
            this.imageBoxVideo.Size = new System.Drawing.Size(488, 276);
            this.imageBoxVideo.TabIndex = 2;
            this.imageBoxVideo.TabStop = false;
            // 
            // imageBoxCurrentFrame
            // 
            this.imageBoxCurrentFrame.Location = new System.Drawing.Point(691, 44);
            this.imageBoxCurrentFrame.Name = "imageBoxCurrentFrame";
            this.imageBoxCurrentFrame.Size = new System.Drawing.Size(476, 276);
            this.imageBoxCurrentFrame.TabIndex = 2;
            this.imageBoxCurrentFrame.TabStop = false;
            // 
            // trackBarProcessing
            // 
            this.trackBarProcessing.Location = new System.Drawing.Point(167, 342);
            this.trackBarProcessing.Maximum = 800;
            this.trackBarProcessing.Name = "trackBarProcessing";
            this.trackBarProcessing.Size = new System.Drawing.Size(1000, 56);
            this.trackBarProcessing.TabIndex = 5;
            this.trackBarProcessing.ValueChanged += new System.EventHandler(this.trackBarProcessing_ValueChanged);
            this.trackBarProcessing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarProcessing_MouseDown);
            this.trackBarProcessing.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarProcessing_MouseUp);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(661, 382);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(26, 16);
            this.progressLabel.TabIndex = 6;
            this.progressLabel.Text = "0%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 464);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.trackBarProcessing);
            this.Controls.Add(this.imageBoxCurrentFrame);
            this.Controls.Add(this.imageBoxVideo);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Frame kinyerése és Vibe algoritmus";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxCurrentFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProcessing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Emgu.CV.UI.ImageBox imageBoxVideo;
        private Emgu.CV.UI.ImageBox imageBoxCurrentFrame;
        private System.Windows.Forms.TrackBar trackBarProcessing;
        private System.Windows.Forms.Label progressLabel;
    }
}

