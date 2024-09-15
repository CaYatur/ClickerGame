using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace ClickerGame
{
    public partial class Notif : Form
    {
        private string labelText;
        private Image pictureBoxImage;

        // Yeni yapılandırıcı
        public Notif(string labelText, Image pictureBoxImage)
        {
            InitializeComponent();
            this.labelText = labelText;
            this.pictureBoxImage = pictureBoxImage;
        }

        private async void Notif_Load(object sender, EventArgs e)
        {
            //// Properties.Resources.Click'in bir byte[] dizisi olduğunu varsayıyoruz
            //byte[] soundData = Properties.Resources.PopupWin;

            //// Byte[]'ı MemoryStream'e dönüştür
            //using (MemoryStream stream = new MemoryStream(soundData))
            //{
            //    using (SoundPlayer player = new SoundPlayer(stream))
            //    {
            //        player.Play(); // Ses dosyasını oynat
            //    }
            //}
            var sound1 = new MemoryStream(Properties.Resources.PopupWin);
            var waveStream1 = new WaveFileReader(sound1);
            var waveOut1 = new WaveOutEvent();
            waveOut1.Init(waveStream1);
            waveOut1.Play();


            // Formun ekranın sağ alt köşesine hizalanması
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);

            // Label ve PictureBox'ı güncelle
            label2.Text = labelText;
            pictureBox1.Image = pictureBoxImage;

            await Task.Delay(8500);

            stepHeight = this.Height / animationSteps;
            StartCloseAnimation();
        }

        private System.Windows.Forms.Timer closeTimer;
        private static int animationSteps = 20; // Animasyon adım sayısı
        private int currentStep = 0;
        private double stepOpacity = 1.0 / animationSteps;
        private int stepHeight;

        private void StartCloseAnimation()
        {
            // Kapatma animasyonunu başlat
            closeTimer = new System.Windows.Forms.Timer();
            closeTimer.Interval = 15; // Animasyon hızını ayarlayın (ms cinsinden)
            closeTimer.Tick += CloseTimer_Tick;
            closeTimer.Start();
        }

        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            // Formun boyutunu ve şeffaflığını azalt
            if (currentStep < animationSteps)
            {
                this.Opacity -= stepOpacity;
                this.Height -= stepHeight;
                currentStep++;
            }
            else
            {
                // Animasyon tamamlandığında formu kapat
                closeTimer.Stop();
                this.Close();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            // Animasyon başlat
            stepHeight = this.Height / animationSteps;
            StartCloseAnimation();
        }
    }

}
