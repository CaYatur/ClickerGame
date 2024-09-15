using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickerGame
{
    public partial class FireGame : Form
    {


        private int score = 0;
        private int waveCount = 5;
        private List<PictureBox> enemies = new List<PictureBox>();
        private List<PictureBox> bullets = new List<PictureBox>();
        private System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();
        private Random random = new Random(); // Rastgele konumlar için random nesnesi

        private Image pictureBoxImage;
        private User loggedInUser;

        public FireGame(User user, Image pictureBoxImage)
        {
            InitializeComponent();
            this.pictureBoxImage = pictureBoxImage;
            this.loggedInUser = user;
        }

        private void FireGame_Load(object sender, EventArgs e)
        {

            CenterControls();

            pictureBox1.Image = pictureBoxImage;
        }

        private void CenterControls()
        {
            // Form genişliği ve yüksekliği
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Button1'i formun ortasına yerleştir
            button1.Left = (formWidth - button1.Width) / 2;
            button1.Top = (formHeight - button1.Height) / 2;

            // Label2'yi Button1'in hemen altına ortalayarak yerleştir
            label2.Left = (formWidth - label2.Width) / 2;
            label2.Top = button1.Bottom + 10; // Button1'in altına 10 piksel boşluk bırak
        }

        private void StartGame()
        {
            //score = 50; // Başlangıç puanı
            score = loggedInUser.Points; // Başlangıç puanı
            labelScore.Text = "Puan: " + score;

            gameTimer.Interval = 10; // Oyun hızı
            gameTimer.Tick += GameTick;
            gameTimer.Start();

            CreateEnemies(); // İlk dalga canavarları oluştur
        }

        private void GameTick(object sender, EventArgs e)
        {
            // Karakterin Y ekseninde hareket etmesi (fareye göre)
            Point mousePosition = this.PointToClient(Cursor.Position);
            int newTop = mousePosition.Y - (pictureBox1.Height / 2);

            // Karakterin form dışına çıkmasını engelle
            if (newTop < 0)
                newTop = 0;
            else if (newTop + pictureBox1.Height > this.ClientSize.Height)
                newTop = this.ClientSize.Height - pictureBox1.Height;

            pictureBox1.Top = newTop;

            // Canavarların hareketi ve formdan çıkış kontrolü
            foreach (var enemy in enemies.ToList())
            {
                enemy.Left -= 5; // Sağdan sola hareket

                // Canavar form dışına çıktıysa sil
                if (enemy.Right < 0)
                {
                    Controls.Remove(enemy);
                    enemies.Remove(enemy);
                }

                // Çarpışma kontrolü
                if (enemy.Bounds.IntersectsWith(pictureBox1.Bounds))
                {
                    gameTimer.Stop(); // Çarpışma olursa oyun biter
                    //MessageBox.Show("Oyun Bitti!");
                    loggedInUser.Points = score;
                    label1.Visible = true;
                    button2.Visible = true;
                    CenterLabel1();
                    return;
                }
            }

            // Mermilerin hareketi
            foreach (var bullet in bullets.ToList())
            {
                bullet.Left += 10; // Mermi sağa gider

                // Mermi form dışına çıktıysa sil
                if (bullet.Left > this.ClientSize.Width)
                {
                    Controls.Remove(bullet);
                    bullets.Remove(bullet);
                }

                // Merminin canavara çarpması
                foreach (var enemy in enemies.ToList())
                {
                    if (bullet.Bounds.IntersectsWith(enemy.Bounds))
                    {
                        Controls.Remove(enemy); // Canavarı yok et
                        enemies.Remove(enemy);
                        Controls.Remove(bullet); // Mermiyi yok et
                        bullets.Remove(bullet);
                        score += 25; // Puan ekle
                        labelScore.Text = "Puan: " + score;
                        var sound1 = new MemoryStream(Properties.Resources.exploit);
                        var waveStream1 = new WaveFileReader(sound1);
                        var waveOut1 = new WaveOutEvent();
                        waveOut1.Init(waveStream1);
                        waveOut1.Play();
                        break; // Mermi bir canavarı yok ettiyse diğer canavarlar için kontrol etmeyi bırak
                    }
                }
            }

            // Eğer tüm canavarlar yok olduysa yeni dalga başlat
            if (enemies.Count == 0 && waveCount > 0)
            {
                waveCount--;
                CreateEnemies();
            }
            else if (waveCount == 0 && enemies.Count == 0)
            {
                gameTimer.Stop();
                //MessageBox.Show("Tebrikler, kazandınız!");
                label1.Text = "TEBRİKLER KAZANDIN!";
                label2.Text = "HESABINA EKSTRA 50 PUAN EKLENDİ!";
                label1.ForeColor = Color.Green;
                label2.ForeColor = Color.Green;

                label1.Visible = true;
                label2.Visible = true;

                button2.Visible = true;
                CenterLabels();

                score += 50;
                loggedInUser.Points = score;
                
            }
        }

        private void CreateEnemies()
        {
            for (int i = 0; i < 6; i++)
            {
                PictureBox enemy = new PictureBox();
                enemy.Size = new Size(50, 50);
                enemy.BackColor = Color.Red; // Canavarların rengini ayarla
                enemy.Left = this.ClientSize.Width + random.Next(100, 500); // Sağdan başlat
                enemy.Top = random.Next(0, this.ClientSize.Height - enemy.Height); // Rastgele Y pozisyonu

                // Canavara tıklayınca ateş etme olayı ekle
                enemy.MouseDown += Enemy_MouseDown;

                enemies.Add(enemy);
                Controls.Add(enemy);
            }
        }

        private void Enemy_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left && score >= 5) // Yeterli puan varsa ateş et
            //{
            //    score -= 5;
            //    labelScore.Text = "Puan: " + score;

            //    PictureBox bullet = new PictureBox();
            //    bullet.Size = new Size(20, 5);
            //    bullet.BackColor = Color.Orange; // Merminin rengini ayarla
            //    PictureBox enemy = sender as PictureBox;

            //    // Mermi tıklanan canavardan ateş ediliyor
            //    bullet.Left = enemy.Left;
            //    bullet.Top = enemy.Top + (enemy.Height / 2) - (bullet.Height / 2);
            //    bullets.Add(bullet);
            //    Controls.Add(bullet);
            //}
            if (gameTimer.Enabled)
            {
                if (e.Button == MouseButtons.Left && score >= 5) // Yeterli puan varsa ateş et
                {
                    // Her tıklamada ateş et ve puanı düşür
                    score -= 20;
                    labelScore.Text = "Puan: " + score;

                    PictureBox bullet = new PictureBox();
                    bullet.Size = new Size(20, 5);
                    bullet.BackColor = Color.Orange; // Merminin rengini ayarla
                    bullet.Left = pictureBox1.Right;
                    bullet.Top = pictureBox1.Top + (pictureBox1.Height / 2) - (bullet.Height / 2);
                    bullets.Add(bullet);
                    Controls.Add(bullet);

                    var sound1 = new MemoryStream(Properties.Resources.FireS);
                    var waveStream1 = new WaveFileReader(sound1);
                    var waveOut1 = new WaveOutEvent();
                    waveOut1.Init(waveStream1);
                    waveOut1.Play();
                }
            }

        }

        private void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (gameTimer.Enabled)
            {
                if (e.Button == MouseButtons.Left && score >= 5) // Yeterli puan varsa ateş et
                {
                    // Her tıklamada ateş et ve puanı düşür
                    score -= 20;
                    labelScore.Text = "Puan: " + score;

                    PictureBox bullet = new PictureBox();
                    bullet.Size = new Size(20, 5);
                    bullet.BackColor = Color.Orange; // Merminin rengini ayarla
                    bullet.Left = pictureBox1.Right;
                    bullet.Top = pictureBox1.Top + (pictureBox1.Height / 2) - (bullet.Height / 2);
                    bullets.Add(bullet);
                    Controls.Add(bullet);

                    var sound1 = new MemoryStream(Properties.Resources.FireS);
                    var waveStream1 = new WaveFileReader(sound1);
                    var waveOut1 = new WaveOutEvent();
                    waveOut1.Init(waveStream1);
                    waveOut1.Play();
                }
            }
        }

        private void CenterLabel1()
        {
            // Form genişliği ve yüksekliği
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Label1'i formun ortasına yerleştir
            label1.Left = (formWidth - label1.Width) / 2;
            label1.Top = (formHeight - label1.Height) / 2;
        }

        private void CenterLabels()
        {
            // Form genişliği ve yüksekliği
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Label1'i formun ortasına yatayda ortala
            label1.Left = (formWidth - label1.Width) / 2;

            // Label2'yi yatayda ortala ve Label1'in altına yerleştir
            label2.Left = (formWidth - label2.Width) / 2;
            label2.Top = label1.Bottom + 10; // Label1'in altına 10 piksel boşluk bırak

            // Her iki label'ı birlikte dikeyde ortala
            int totalHeight = label1.Height + label2.Height + 10; // 10 piksel boşluğu da dahil ediyoruz
            int topPosition = (formHeight - totalHeight) / 2;

            // Label1'in dikey pozisyonunu ayarla
            label1.Top = topPosition;

            // Label2'nin dikey pozisyonu zaten label1.Bottom'a göre ayarlandığı için ek işlem gerekmez
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Oyun başlatma
            pictureBox1.Visible = true;
            labelScore.Visible = true;
            button1.Visible = false;
            label2.Visible = false;
            button2.Visible = false;
            StartGame();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
