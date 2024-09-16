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
    public partial class WaitingScreen : Form
    {
        private DuelloGame _currentGame;
        private System.Windows.Forms.Timer _timer;

        public WaitingScreen(DuelloGame game)
        {
            InitializeComponent();
            _currentGame = game;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 500; // Her saniye
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Oyun başladığında GameForm'u aç
            if (_currentGame.IsGameStarted)
            {
                _timer.Stop();

                // GameForm'u oluşturun ve gösterin
                GameForm gameForm = new GameForm(_currentGame);
                gameForm.Show();

                // WaitingScreen formunu kapatın
                this.Close();
            }
        }
    }
}

