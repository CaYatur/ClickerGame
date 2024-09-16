using System;
using System.Windows.Forms;

namespace ClickerGame
{
    public partial class GameForm : Form
    {
        private DuelloGame _currentGame;
        private System.Windows.Forms.Timer _timer;

        public GameForm(DuelloGame game)
        {
            InitializeComponent();
            _currentGame = game;
            InitializeGame();
        }

        private void InitializeGame()
        {
            labelHostPlayer.Text = _currentGame.HostPlayer;
            labelJoinedPlayer.Text = _currentGame.JoinedPlayer;
            labelHostScore.Text = _currentGame.HostPlayerScore.ToString();
            labelJoinedScore.Text = _currentGame.JoinedPlayerScore.ToString();
            buttonHost.Text = _currentGame.HostPlayer;
            buttonJoined.Text = _currentGame.JoinedPlayer;

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000; // Her saniye
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _currentGame.TimeRemaining--;
            labelTimeRemaining.Text = _currentGame.TimeRemaining.ToString() + " saniye kaldı";

            if (_currentGame.TimeRemaining <= 0)
            {
                _timer.Stop();
                EndGame();
            }
        }

        private void buttonHost_Click(object sender, EventArgs e)
        {
            if (_currentGame.HostPlayer == buttonHost.Text) // Butona tıklıyorsa
            {
                _currentGame.HostPlayerScore++;
                labelHostScore.Text = _currentGame.HostPlayerScore.ToString();
            }
        }

        private void buttonJoined_Click(object sender, EventArgs e)
        {
            if (_currentGame.JoinedPlayer == buttonJoined.Text) // Butona tıklıyorsa
            {
                _currentGame.JoinedPlayerScore++;
                labelJoinedScore.Text = _currentGame.JoinedPlayerScore.ToString();
            }
        }

        private void EndGame()
        {
            if (_currentGame.HostPlayerScore > _currentGame.JoinedPlayerScore)
            {
                MessageBox.Show(_currentGame.HostPlayer + " kazandı!");
            }
            else if (_currentGame.JoinedPlayerScore > _currentGame.HostPlayerScore)
            {
                MessageBox.Show(_currentGame.JoinedPlayer + " kazandı!");
            }
            else
            {
                MessageBox.Show("Berabere!");
            }

            this.Close();
        }
    }
}
