namespace Video
{
    partial class Form3
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.imageBoxVideo = new Emgu.CV.UI.ImageBox();
            this.imageBoxWebcam = new Emgu.CV.UI.ImageBox();
            this.trackBarProcessing = new System.Windows.Forms.TrackBar();
            this.progressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxWebcam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProcessing)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Framek kinyerése";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Frame_Export_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(17, 191);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(150, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "Webkamera";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.VibeAlgorithm);
            // 
            // imageBoxVideo
            // 
            this.imageBoxVideo.Location = new System.Drawing.Point(172, 42);
            this.imageBoxVideo.Name = "imageBoxVideo";
            this.imageBoxVideo.Size = new System.Drawing.Size(496, 298);
            this.imageBoxVideo.TabIndex = 2;
            this.imageBoxVideo.TabStop = false;
            // 
            // imageBoxWebcam
            // 
            this.imageBoxWebcam.Location = new System.Drawing.Point(723, 42);
            this.imageBoxWebcam.Name = "imageBoxWebcam";
            this.imageBoxWebcam.Size = new System.Drawing.Size(489, 298);
            this.imageBoxWebcam.TabIndex = 2;
            this.imageBoxWebcam.TabStop = false;
            // 
            // trackBarProcessing
            // 
            this.trackBarProcessing.Location = new System.Drawing.Point(172, 367);
            this.trackBarProcessing.Maximum = 800;
            this.trackBarProcessing.Name = "trackBarProcessing";
            this.trackBarProcessing.Size = new System.Drawing.Size(1040, 56);
            this.trackBarProcessing.TabIndex = 3;
            this.trackBarProcessing.ValueChanged += new System.EventHandler(this.trackBarProcessing_ValueChanged);
            this.trackBarProcessing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarProcessing_MouseDown);
            this.trackBarProcessing.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarProcessing_MouseUp);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(688, 406);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(14, 16);
            this.progressLabel.TabIndex = 4;
            this.progressLabel.Text = "0";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1379, 450);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.trackBarProcessing);
            this.Controls.Add(this.imageBoxWebcam);
            this.Controls.Add(this.imageBoxVideo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form3";
            this.Text = "Frame kinyerése webkamerából";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBoxWebcam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarProcessing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Emgu.CV.UI.ImageBox imageBoxVideo;
        private Emgu.CV.UI.ImageBox imageBoxWebcam;
        private System.Windows.Forms.TrackBar trackBarProcessing;
        private System.Windows.Forms.Label progressLabel;
    }
}