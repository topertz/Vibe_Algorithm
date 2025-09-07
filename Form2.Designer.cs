namespace Video
{
    partial class Form2
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
            this.imageBoxVideo = new Emgu.CV.UI.ImageBox();
            this.button2 = new System.Windows.Forms.Button();
            this.imageBoxCurrentFrame = new Emgu.CV.UI.ImageBox();
            this.trackBarProcessing = new System.Windows.Forms.TrackBar();
            this.progressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxCurrentFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProcessing)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBoxVideo
            // 
            this.imageBoxVideo.Location = new System.Drawing.Point(231, 37);
            this.imageBoxVideo.Name = "imageBoxVideo";
            this.imageBoxVideo.Size = new System.Drawing.Size(535, 275);
            this.imageBoxVideo.TabIndex = 2;
            this.imageBoxVideo.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(40, 142);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 45);
            this.button2.TabIndex = 3;
            this.button2.Text = "Framek kinyerese es ViBe algoritmus";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.VibeAlgorithm);
            // 
            // imageBoxCurrentFrame
            // 
            this.imageBoxCurrentFrame.Location = new System.Drawing.Point(825, 37);
            this.imageBoxCurrentFrame.Name = "imageBoxCurrentFrame";
            this.imageBoxCurrentFrame.Size = new System.Drawing.Size(484, 275);
            this.imageBoxCurrentFrame.TabIndex = 2;
            this.imageBoxCurrentFrame.TabStop = false;
            // 
            // trackBarProcessing
            // 
            this.trackBarProcessing.Location = new System.Drawing.Point(231, 340);
            this.trackBarProcessing.Maximum = 800;
            this.trackBarProcessing.Name = "trackBarProcessing";
            this.trackBarProcessing.Size = new System.Drawing.Size(1078, 56);
            this.trackBarProcessing.TabIndex = 4;
            this.trackBarProcessing.ValueChanged += new System.EventHandler(this.trackBarProcessing_ValueChanged);
            this.trackBarProcessing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarProcessing_MouseDown);
            this.trackBarProcessing.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarProcessing_MouseUp);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(781, 380);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(26, 16);
            this.progressLabel.TabIndex = 5;
            this.progressLabel.Text = "0%";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 450);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.trackBarProcessing);
            this.Controls.Add(this.imageBoxCurrentFrame);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.imageBoxVideo);
            this.Name = "Form2";
            this.Text = "Frame kinyerése videóból";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxCurrentFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProcessing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Emgu.CV.UI.ImageBox imageBoxVideo;
        private System.Windows.Forms.Button button2;
        private Emgu.CV.UI.ImageBox imageBoxCurrentFrame;
        private System.Windows.Forms.TrackBar trackBarProcessing;
        private System.Windows.Forms.Label progressLabel;
    }
}