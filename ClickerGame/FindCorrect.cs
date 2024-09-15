using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickerGame
{
    public partial class FindCorrect : Form
    {
        private int riskAmount;
        private int currentScore;
        private Button correctButton;
        private Image pictureBoxImage2;

        private User loggedInUser;
        private Database database;
        private AuthService authService;

        private bool Closing = false;
        public int UpdatedScore { get; private set; }

        private Image ImageC;

        // Yapıcı metodda parametreler ile değerleri al
        public FindCorrect(int riskAmount, int currentScore, Image ImageC, AuthService authService, Database database)
        {
            InitializeComponent();
            this.riskAmount = riskAmount;
            this.currentScore = currentScore;
            this.ImageC = ImageC;
        }

        private void FindCorrect_Load(object sender, EventArgs e)
        {
            lblRiskAmount.Text = $"Riske Atılan Puan: {riskAmount}";
            lblCurrentScore.Text = $"Mevcut Puan: {currentScore}";

            pictureBox1.Image = ImageC;

            SetCorrectButton();
        }

        private void SetCorrectButton()
        {
            if (riskAmount <= 500)
            {
                var buttons = new Button[] { btnOption1, btnOption2, btnOption3 };
                var random = new Random();
                correctButton = buttons[random.Next(buttons.Length)];
                btnOption4.Visible = false;
                btnOption5.Visible = false;
                btnOption6.Visible = false;
            }
            else
            {
                var buttons = new Button[] { btnOption1, btnOption2, btnOption3, btnOption4, btnOption5, btnOption6 };
                var random = new Random();
                correctButton = buttons[random.Next(buttons.Length)];
                btnOption4.Visible = true;
                btnOption5.Visible = true;
                btnOption6.Visible = true;
            }
            
            //correctButton.BackColor = Color.Green; // Doğru butonu yeşil yap
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var clickedButton = (Button)sender;

            if (clickedButton == correctButton)
            {
                //if (loggedInUser != null)
                //{
                //    UpdatedScore = currentScore + riskAmount; // Doğru seçim, puanı artır

                //    if (currentScore > loggedInUser.Points)
                //    {
                //        loggedInUser.Points += riskAmount;
                //    }
                //    else
                //    {
                //        loggedInUser.Points -= riskAmount;
                //    }
                //    authService.UpdateUserPoints(loggedInUser.Username, loggedInUser.Points);
                //}

                UpdatedScore = currentScore + riskAmount;

                //loggedInUser.Points = UpdatedScore;

                //authService.UpdateUserPoints(loggedInUser.Username, loggedInUser.Points);

                //MessageBox.Show("Tebrikler, doğru butona tıkladınız!");
            }
            else
            {
                //if (loggedInUser != null)
                //{
                //    UpdatedScore = currentScore - riskAmount; // Yanlış seçim, puanı azalt
                //    authService.UpdateUserPoints(loggedInUser.Username, loggedInUser.Points);
                //}

                UpdatedScore = currentScore - riskAmount;

                //loggedInUser.Points = UpdatedScore;

                //authService.UpdateUserPoints(loggedInUser.Username, loggedInUser.Points);

                //MessageBox.Show("Yanlış seçim, puan kaybettiniz!");
            }

            Closing = true;
            this.Close(); // Formu kapat
        }

        private void FindCorrect_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Closing == false)
            {
                // Kullanıcıya onay mesajı göster
                var result = MessageBox.Show(
                    $"Eğer çıkmak istediğinizi onaylarsanız {riskAmount} adet puan kaybetmiş sayılırsınız.",
                    "Onay",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    UpdatedScore = currentScore - riskAmount;
                }
                else
                {
                    // Kullanıcı "Hayır" seçeneğini seçti, işlem iptal edildi
                    //MessageBox.Show("İşlem iptal edildi.");
                    e.Cancel = true;
                }
                
            }
        }
    }
}
