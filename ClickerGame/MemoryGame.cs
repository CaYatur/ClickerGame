using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ClickerGame
{
    public partial class MemoryGame : Form
    {
        private List<System.Drawing.Image> images;
        private List<System.Drawing.Image> correctSequence;
        private int currentImageIndex = 0;
        private System.Windows.Forms.Timer imageTimer; // Timer sınıfını kullanmak için
        private System.Windows.Forms.Timer guessTimer; // Seçim için zamanlayıcı
        private int guessTimeLimit = 5; // Saniye limiti
        private int remainingTime; // Kalan süre

        private bool closing = false;


        public int ReturnedData { get; set; }

        public MemoryGame()
        {
            InitializeComponent();
        }


        private void MemoryGame_Load(object sender, EventArgs e)
        {
            InitializeGame();
        }



        private void InitializeGame()
        {
            images = new List<System.Drawing.Image>
            {
                Properties.Resources.K1,
                Properties.Resources.YT,
                Properties.Resources.TT,
                Properties.Resources.SURT,
                Properties.Resources.MT,
                Properties.Resources.SAT,
                Properties.Resources.ST,
                Properties.Resources.KV1,
                Properties.Resources.S1,
                Properties.Resources.KUT,
                Properties.Resources.BKT,
                Properties.Resources.PT,
                Properties.Resources.HNT,
                Properties.Resources.NahliTilki,
                Properties.Resources.UcubeTilki,
            };

            ShuffleImages();
            ShowImagesInSequence();
        }

        //private void ShuffleImages()
        //{
        //    correctSequence = new List<System.Drawing.Image>(images);
        //    Random rand = new Random();
        //    correctSequence = correctSequence.OrderBy(x => rand.Next()).ToList();
        //}

        private void ShuffleImages()
        {
            Random rand = new Random();
            // Resimleri rastgele karıştırıyoruz
            images = images.OrderBy(x => rand.Next()).ToList();

            // Rastgele seçilen 5 resmi alıyoruz
            correctSequence = images.Take(5).ToList();
        }


        private void ShowImagesInSequence()
        {
            currentImageIndex = 0;
            imageTimer = new System.Windows.Forms.Timer();
            imageTimer.Interval = 1000; // 1 seconds
            imageTimer.Tick += ImageTimer_Tick;
            imageTimer.Start();
        }

        private void ImageTimer_Tick(object sender, EventArgs e)
        {
            if (currentImageIndex >= correctSequence.Count)
            {
                imageTimer.Stop();
                ShowGuessBoxes();
                return;
            }

            pictureBoxMain.Image = correctSequence[currentImageIndex];
            currentImageIndex++;
        }

        private void ShowGuessBoxes()
        {
            // Doğru sıralamayı (correctSequence) rastgele karıştırıyoruz
            var shuffledImages = new List<System.Drawing.Image>(correctSequence);
            shuffledImages = shuffledImages.OrderBy(x => Guid.NewGuid()).ToList(); // Rastgele karıştır

            // Karıştırılan resimleri tahmin kutularına yerleştiriyoruz
            pictureBoxGuess1.Image = shuffledImages[0];
            pictureBoxGuess2.Image = shuffledImages[1];
            pictureBoxGuess3.Image = shuffledImages[2];
            pictureBoxGuess4.Image = shuffledImages[3];
            pictureBoxGuess5.Image = shuffledImages[4];

            pictureBoxMain.Visible = false;

            pictureBoxGuess1.Visible = true;
            pictureBoxGuess2.Visible = true;
            pictureBoxGuess3.Visible = true;
            pictureBoxGuess4.Visible = true;
            pictureBoxGuess5.Visible = true;

            // Add click event handlers for guess boxes
            pictureBoxGuess1.Click += GuessBox_Click;
            pictureBoxGuess2.Click += GuessBox_Click;
            pictureBoxGuess3.Click += GuessBox_Click;
            pictureBoxGuess4.Click += GuessBox_Click;
            pictureBoxGuess5.Click += GuessBox_Click;

            // Zamanlayıcıyı başlat
            StartGuessTimer();
        }
        private void StartGuessTimer()
        {
            remainingTime = guessTimeLimit;
            guessTimer = new System.Windows.Forms.Timer();
            guessTimer.Interval = 1000; // Her saniye
            guessTimer.Tick += GuessTimer_Tick;
            guessTimer.Start();

            label1.Text = $"Kalan süre: {remainingTime} saniye";
            label1.Visible = true; // Etiketi görünür yap
        }

        private void GuessTimer_Tick(object sender, EventArgs e)
        {
            remainingTime--;

            label1.Text = $"Kalan süre: {remainingTime} saniye";

            if (remainingTime <= 0)
            {
                guessTimer.Stop();
                //GameOver(false); // Süre dolunca kaybet
                Fail(true);
            }
        }
        private void GuessBox_Click(object sender, EventArgs e)
        {
            var clickedPictureBox = sender as PictureBox;
            var selectedImage = clickedPictureBox.Image;



            if (correctSequence.First() == selectedImage)
            {
                correctSequence.RemoveAt(0);

                if (correctSequence.Count == 0)
                {
                    guessTimer.Stop();

                    label1.Visible = false;
                    label2.Visible = true;

                    ReturnedData = 100;  // Puanı döndür
                    //this.DialogResult = DialogResult.OK;  // DialogResult olarak veri döndür
                    //MessageBox.Show("Tebrikler! Hesabına 100 puan eklendi!");

                    //MessageBox.Show("Kazandınız!");
                    //ResetGame();
                    closing = true;
                    button1.Visible = true;
                }
            }
            else
            {
                //label1.Visible = false;
                //label2.Visible = true;

                //ReturnedData = -100;

                //label2.Text = "Yanlış tahmin. Oyun bitti!";
                //label2.ForeColor = Color.Red;
                ////MessageBox.Show("Kaybettiniz!");
                ////ResetGame();
                //closing = true;
                //button1.Visible = true;

                Fail(false);
            }
        }

        private void Fail(bool isTimeout)
        {

            pictureBoxGuess1.Click -= GuessBox_Click;
            pictureBoxGuess2.Click -= GuessBox_Click;
            pictureBoxGuess3.Click -= GuessBox_Click;
            pictureBoxGuess4.Click -= GuessBox_Click;
            pictureBoxGuess5.Click -= GuessBox_Click;

            label1.Visible = false;
            label2.Visible = true;

            ReturnedData = -100;
            label2.ForeColor = Color.Red;

            if (isTimeout)
            {
                label2.Text = "Süre doldu. Oyun bitti!";
                // Burada süre dolduğu için oyunun bittiğini belirtebilirsiniz.
            }
            else
            {
                label2.Text = "Yanlış seçim. Oyun bitti!";
                // Burada yanlış seçim yapıldığı için oyunun bittiğini belirtebilirsiniz.
            }

            closing = true;
            button1.Visible = true;
        }




        //private void ResetGame()
        //{
        //    pictureBoxGuess1.Visible = false;
        //    pictureBoxGuess2.Visible = false;
        //    pictureBoxGuess3.Visible = false;
        //    pictureBoxGuess4.Visible = false;
        //    pictureBoxGuess5.Visible = false;

        //    InitializeGame(); // Restart the game
        //}











        // Oyunun sonunu belirleyen metod
        private void GameOver(bool isWin)
        {
            label1.Visible = false;
            label2.Visible = true;

            if (isWin)
            {
                ReturnedData = 100;  // Puanı döndür
                this.DialogResult = DialogResult.OK;  // DialogResult olarak veri döndür
                MessageBox.Show("Tebrikler! Hesabına 100 puan eklendi!");
            }
            else
            {
                label2.Text = "Yanlış tahmin. Oyun bitti!";
                label2.ForeColor = Color.Red;
                MessageBox.Show("Yanlış tahmin. Oyun bitti!");
            }

            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MemoryGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closing == false)
            {
                var result = MessageBox.Show(
                    $"Eğer çıkmak istediğinizi onaylarsanız 100 adet puan kaybetmiş sayılırsınız.",
                    "Onay",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    ReturnedData = -100;
                }
                else
                {
                    // Kullanıcı "Hayır" seçeneğini seçti, işlem iptal edildi
                    //MessageBox.Show("İşlem iptal edildi.");
                    e.Cancel = true;
                }
            }
            else
            {
                this.DialogResult = DialogResult.OK;  // DialogResult olarak veri döndür
            }
            
        }
    }
}
