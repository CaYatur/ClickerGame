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
    public partial class FindCorrectPoints : Form
    {
        //public int CurrentScore { get; private set; } = 100;

        private User loggedInUser;
        private Database database;
        private AuthService authService;

        private int FirstPoint;
        private Image pictureBoxImage;
        private Image CurrentImage;


        public int CurrentScore { get; private set; } = 0;
        private int riskAmount;

        public FindCorrectPoints(User user, Image pictureBoxImage, AuthService authService, Database database)
        {
            InitializeComponent();
            this.loggedInUser = user;
            this.authService = authService;
            this.database = database;
            CurrentScore = loggedInUser.Points;
            FirstPoint = loggedInUser.Points;
            CurrentImage = pictureBoxImage;
        }

        private void FindCorrectPoints_Load(object sender, EventArgs e)
        {
            lblCurrentScore.Text = $"Mevcut Puan: {CurrentScore}";


        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtRiskAmount.Text, out riskAmount) && riskAmount > 0 && riskAmount <= CurrentScore)
            {
                // Kullanıcıya onay mesajı göster
                var result = MessageBox.Show(
                    $"{txtRiskAmount.Text} Miktarındaki puanınızı riske atmak istediğinizden emin misiniz? Bu işlem geri alınamaz.",
                    "Onay",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    Image notificationImage = CurrentImage;

                    FindCorrect gameForm = new FindCorrect(riskAmount, CurrentScore, notificationImage, authService, database);
                    gameForm.ShowDialog();
                    CurrentScore = gameForm.UpdatedScore;
                    lblCurrentScore.Text = $"Mevcut Puan: {CurrentScore}";
                    if (CurrentScore > loggedInUser.Points)
                    {
                        loggedInUser.Points += riskAmount;
                        authService.UpdateUserPoints(loggedInUser.Username, loggedInUser.Points);
                        MessageBox.Show("Tebrikler, doğru butona tıkladınız!");
                    }
                    else
                    {
                        loggedInUser.Points -= riskAmount;
                        authService.UpdateUserPoints(loggedInUser.Username, loggedInUser.Points);
                        MessageBox.Show("Yanlış seçim, puan kaybettiniz!");
                    }

                    


                }
                else
                {
                    // Kullanıcı "Hayır" seçeneğini seçti, işlem iptal edildi
                    //MessageBox.Show("İşlem iptal edildi.");
                }

                

                
            }
            else
            {
                MessageBox.Show("Geçersiz miktar, lütfen geçerli bir puan girin.");
            }
        }
    }
}
