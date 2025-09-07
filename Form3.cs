using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Video
{
    public partial class Form3 : Form
    {
        VideoCapture capture;
        int FPS, totalFrames, currentFrameNumber;
        Mat currentFrame;

        int cameraIndex = 0;
        public Form3()
        {
            InitializeComponent();
            capture = new VideoCapture(cameraIndex);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            currentFrameNumber = 1;
            capture.Start();
            currentFrame = new Mat();
            FPS = Convert.ToInt32(capture.Get(CapProp.Fps));
            totalFrames = Convert.ToInt32(capture.Get(CapProp.FrameCount));
            capture.Read(currentFrame);
            imageBoxVideo.Image = currentFrame.ToImage<Bgr, Byte>();
            imageBoxWebcam.Image = currentFrame.ToImage<Gray, Byte>();

            trackBarProcessing.Value = 0;
            trackBarProcessing.Minimum = 0;
            trackBarProcessing.Maximum = 800;
        }

        string outputPath = @"C:\Users\Mark\Documents\Visual Studio 2022\2023_10_21\output_video.avi";
        VideoWriter videoWriter;
        private void Frame_Export_Click(object sender, EventArgs e)
        {
            videoWriter.Write(segMap.Convert<Bgr, Byte>().Mat);
        }

        int GetRandomNeighborXCoordinate(int x)
        {
            int xOffset;
            Random rand = new Random();
            if (x == width - 1)
            {
                return x - 1;
            }
            if (x == 0)
            {
                xOffset = 1;
            }
            else
            {
                xOffset = rand.Next(-1, 2);
            }
            return x + xOffset;
        }

        int GetRandomNeighborYCoordinate(int y)
        {
            int yOffset;
            Random rand = new Random();
            if (y == height - 1)
            {
                return y - 1;
            }
            if (y == 0)
            {
                yOffset = 1;
            }
            else
            {
                yOffset = rand.Next(-1, 2);
            }
            return y + yOffset;
        }

        int N = 20;
        int R = 20;
        int min = 2;
        int FI = 16;
        int width, height;
        Image<Bgr, Byte> frameImage;
        byte[,,] samples;
        Image<Gray, Byte> segMap;
        byte background = 0;
        byte foreground = 255;

        private void ReinitializeModel(Image<Bgr, Byte> frameImage)
        {
            segMap = new Image<Gray, Byte>(width, height);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    for (int i = 0; i < N; i++)
                    {
                        samples[x, y, i] = frameImage.Data[y, x, 0];
                    }
                }
            }
        }

        private async void VibeAlgorithm(object sender, EventArgs e)
        {
            width = Convert.ToInt32(capture.Get(CapProp.FrameWidth));
            height = Convert.ToInt32(capture.Get(CapProp.FrameHeight));

            await Task.Run(() =>
            {
                int rand;
                Random rnd = new Random();

                // Inicializáció
                segMap = new Image<Gray, Byte>(width, height);
                samples = new byte[width, height, N];

                int j = 0;
                videoWriter = new VideoWriter(outputPath, 1482049860, 50, new Size(width, height), true);
                while (j < 799)
                {
                    Mat frameRead = new Mat();
                    capture.Set(CapProp.PosFrames, j);
                    capture.Read(frameRead);
                    // Gray kép
                    Image<Bgr, Byte> frameImage = frameRead.ToImage<Bgr, Byte>();
                    if(j == 0)
                    {
                        ReinitializeModel(frameImage);
                    }
                    for (int x = 0; x < width; x++)
                        {
                            for (int y = 0; y < height; y++)
                            {
                                // 1. Összehasonlítás a pixel a háttérmodellhez
                                int count = 0;
                                for (int i = 0; i < N; i++)
                                {
                                    int randRow = rnd.Next(-1, 1);
                                    int randCol = rnd.Next(-1, 1);

                                    int randX = x + randRow;
                                    int randY = y + randCol;

                                    int minWidth = width - 1;
                                    int minHeight = height - 1;

                                    randX = Math.Max(0, Math.Min(randX, minWidth));
                                    randY = Math.Max(0, Math.Min(randY, minHeight));

                                    if (x >= 0 && x < width && y >= 0 && y < height && randX >= 0 && randX < width && randY >= 0 && randY < height)
                                    {
                                        // Szurkearnyalatos tavolsag
                                        int dist = Math.Abs(frameImage.Data[y, x, 0] - samples[randX, randY, i]);
                                        if (dist < R)
                                        {
                                            count++;
                                        }
                                        if (count >= min) break;
                                    }
                                }

                                // 2. Pixel osztályozása és modell frissítése
                                if (count >= min)
                                {
                                    segMap.Data[y, x, 0] = background;

                                    // 3. Frissítsd az aktuális pixel modelljét véletlenszerű mintavételezéssel
                                    rand = rnd.Next(0, FI - 1);
                                    if (rand == 0)
                                    {
                                        int randModel = rnd.Next(0, N - 1);
                                        samples[x, y, randModel] = frameImage.Data[y, x, 0];
                                    }
                                    // 4. Frissítsd a szomszédos pixel modelljét véletlenszerű mintavételezéssel
                                    rand = rnd.Next(0, FI - 1);
                                    if (rand == 0)
                                    {
                                        int xNG = GetRandomNeighborXCoordinate(x);
                                        int yNG = GetRandomNeighborYCoordinate(y);

                                        if (xNG >= 0 && xNG < width && yNG >= 0 && yNG < height)
                                        {
                                            int randModel = rnd.Next(0, N - 1);
                                            samples[xNG, yNG, randModel] = frameImage.Data[y, x, 0];
                                        }
                                    }

                                    segMap.Data[y, x, 0] = background;
                                }
                                else
                                {
                                    segMap.Data[y, x, 0] = foreground;
                                }
                            }
                        }

                    // UI frissítése
                    BeginInvoke(new Action(() =>
                    {
                        j++;
                        Frame_Export_Click(sender, e);
                        imageBoxVideo.Image = frameImage;
                        imageBoxWebcam.Image = segMap;
                        int percentage = Math.Abs((int)((double)j / totalFrames));
                        progressLabel.Text = percentage.ToString();
                        if (trackBarProcessing.Maximum > totalFrames - 1)
                        {
                            trackBarProcessing.Value = j - 1;
                        }
                        if (j == 799)
                        {
                            MessageBox.Show("A videó feldolgozása és a framek exportálása sikeresen befejeződött!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            trackBarProcessing.Value = 0;
                            progressLabel.Text = percentage.ToString();
                        }
                        ReinitializeModel(frameImage);
                    }));
                }
                videoWriter.Dispose();
            });
        }

        private bool isDragging = false;
        private void trackBarProcessing_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
        }

        private void trackBarProcessing_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void trackBarProcessing_ValueChanged(object sender, EventArgs e)
        {
            if (isDragging)
            {
                int value = trackBarProcessing.Value;
                int percentage = Math.Abs((int)((double)value / trackBarProcessing.Maximum));
                if (value <= trackBarProcessing.Maximum)
                {
                    progressLabel.Text = percentage.ToString();
                }
                UpdateVideoPosition(value);
            }
        }

        private void UpdateVideoPosition(int frameNumber)
        {
            capture.Set(CapProp.PosFrames, frameNumber);
            Mat frameRead = new Mat();
            capture.Read(frameRead);

            // ImageBoxVideo frissítése
            Image<Bgr, Byte> frameImage = frameRead.ToImage<Bgr, Byte>();
            imageBoxVideo.Image = frameImage;

            Image<Gray, Byte> segMap = frameRead.ToImage<Gray, Byte>();
            imageBoxWebcam.Image = segMap;
        }
    }
}
