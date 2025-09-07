using System;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Emgu.CV.Util;
using System.Threading;

namespace Video
{
    public partial class Form1 : Form
    {
        VideoCapture capture;
        int FPS, totalFrames, currentFrameNumber;
        Mat currentFrame;

        Mat prevFrame;
        double movementThreshold = 7.0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            currentFrameNumber = 1;
            string videoPath = @"C:\Users\Mark\Documents\Visual Studio 2022\2023_10_21\test5.mp4";

            if (File.Exists(videoPath))
            {
                capture = new VideoCapture(videoPath);
                currentFrame = new Mat();
                prevFrame = new Mat();
                FPS = Convert.ToInt32(capture.Get(CapProp.Fps));
                totalFrames = Convert.ToInt32(capture.Get(CapProp.FrameCount));
                capture.Set(CapProp.PosFrames, currentFrameNumber);
                capture.Read(currentFrame);
                imageBoxVideo.Image = currentFrame.ToImage<Bgr, Byte>();
                imageBoxCurrentFrame.Image = currentFrame.ToImage<Gray, Byte>();
            }
            else
            {
                throw new FileNotFoundException("A videófájl nem található az adott elérési úton.");
            }

            trackBarProcessing.Value = 0;
            trackBarProcessing.Minimum = 0;
            trackBarProcessing.Maximum = totalFrames;
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

        int N = 20;  //pixelek szama
        int R = 20;  //pixelek sugara
        int min = 2; //osszehasonlito ertek
        int FI = 16; //frissitesek szama
        int width, height;
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

        private bool IsCameraMoved(Mat currentFrame)
        {
            if (prevFrame.IsEmpty) // Ha ez az első frame, ne végezzünk összehasonlítást
            {
                currentFrame.CopyTo(prevFrame);
                return false;
            }

            // A különbség kiszámítása a jelenlegi és az előző frame között
            Mat diffFrame = new Mat();
            CvInvoke.AbsDiff(currentFrame, prevFrame, diffFrame);

            // A különbség összegzése
            double frameDifference = CvInvoke.Mean(diffFrame).V0; // V0 az első csatornán mért átlagos különbség

            // Másolatot készítünk a jelenlegi frame-ről, hogy később összehasonlíthassuk
            currentFrame.CopyTo(prevFrame);

            // Ha a különbség meghaladja a küszöböt, akkor a kamera elmozdult
            return frameDifference > movementThreshold;
        }

        private void VibeAlgorithm(object sender, EventArgs e)
        {
            width = Convert.ToInt32(capture.Get(CapProp.FrameWidth));
            height = Convert.ToInt32(capture.Get(CapProp.FrameHeight));

            Random rnd = new Random();

            Thread processingThread = new Thread(() =>
            {
                int rand;

                // Inicializáció
                segMap = new Image<Gray, Byte>(width, height);
                samples = new byte[width, height, N];

                for (int j = 0; j < totalFrames; j++)
                {
                    capture.Set(CapProp.PosFrames, j);
                    Mat frameRead = capture.QueryFrame();
                    if (frameRead == null)
                        break; // Ha nincs több frame

                    // Frame konvertálása BGR képpé
                    Image<Bgr, Byte> frameImage = frameRead.ToImage<Bgr, Byte>();

                    // Ellenőrizzük, hogy a kamera elmozdult-e
                    if (IsCameraMoved(frameRead))
                    {
                        // Ha a kamera mozgott, újrainicializáljuk a modellt
                        ReinitializeModel(frameImage);  // Újrainicializálás
                        //MessageBox.Show("Modell újrainicializálva a kamera elmozdulása miatt.", "Modell frissítés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    /*currentFrame = capture.QueryFrame();
                    currentFrame.Save(@"C:\Users\Mark\Documents\Visual Studio 2022\2023_10_21\framek\" + j + ".jpg");
                    currentFrame.Dispose();*/

                    frameRead.Save(@"C:\Users\Mark\Documents\Visual Studio 2022\2023_10_21\framek\" + j + ".jpg");
                    frameRead.Dispose();

                    StreamWriter frame_kiiras = new StreamWriter(@"C:\Users\Mark\Documents\Visual Studio 2022\2023_10_21\framek\fps.txt");
                    frame_kiiras.WriteLine(Convert.ToString(FPS));
                    frame_kiiras.Close();

                    /*Mat frameRead = new Mat();
                    capture.Set(CapProp.PosFrames, j);
                    capture.Read(frameRead);
                    Image<Bgr, Byte> frameImage = frameRead.ToImage<Gray, Byte>();*/
                    // Az első frame esetén inicializáljuk a modellt
                    if (j == 0)
                    {
                        ReinitializeModel(frameImage);
                    }

                    for (int x = 0; x < width; x++)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            int count = 0;
                            for (int i = 0; i < N; i++)
                            {
                                int dist = Math.Abs(frameImage.Data[y, x, 0] - samples[x, y, i]);
                                if (dist < R)
                                {
                                    count++;
                                }
                                if (count >= min) break;
                            }

                            if (count >= min)
                            {
                                segMap.Data[y, x, 0] = background;

                                rand = rnd.Next(0, FI - 1);
                                if (rand == 0)
                                {
                                    int randModel = rnd.Next(0, N - 1);
                                    samples[x, y, randModel] = frameImage.Data[y, x, 0];
                                }

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
                            }
                            else
                            {
                                segMap.Data[y, x, 0] = foreground;
                            }
                        }
                    }

                    imageBoxVideo.Image = frameImage;
                    imageBoxCurrentFrame.Image = segMap;

                    Invoke(new Action(() =>
                    {
                        trackBarProcessing.Value = j;
                        int percentage = (int)((double)j / totalFrames * 101);
                        progressLabel.Text = percentage.ToString() + "%";
                        if (j == totalFrames - 1)
                        {
                            MessageBox.Show("A videó feldolgozása és a framek exportálása sikeresen befejeződött!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            trackBarProcessing.Value = 0;
                            progressLabel.Text = 0 + "%";
                        }
                    }));
                }
            });
            processingThread.IsBackground = true;
            processingThread.Start();
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
                int percentage = (int)((double)value / totalFrames * 101);
                progressLabel.Text = percentage.ToString() + "%";
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
            imageBoxCurrentFrame.Image = segMap;
        }
    }
}