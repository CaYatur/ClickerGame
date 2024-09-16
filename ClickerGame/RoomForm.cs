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
    using ClickerGame;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Windows.Forms;

    public partial class RoomForm : Form
    {
        private Database _database;
        private AuthService _authService;

        public RoomForm(Database database, AuthService authService)
        {
            InitializeComponent();
            _database = database;
            _authService = authService;
        }

        private void CreateRoomButton_Click(object sender, EventArgs e)
        {
            string roomName = roomNameTextBox.Text;
            //string hostPlayer = _authService.GetUserByUsername(loggedInUser.Username).Username;
            string hostPlayer = "Test";

            var newRoom = new DuelloGame(roomName, hostPlayer);

            var duelloGamesCollection = _database.GetDuelloGamesCollection();
            duelloGamesCollection.InsertOne(newRoom);

            // `WaitingScreen` formunu açın
            WaitingScreen waitingScreen = new WaitingScreen(newRoom);
            waitingScreen.Show();

            // Oda oluşturma formunu kapat
            this.Close();
        }

        private void JoinRoomButton_Click(object sender, EventArgs e)
        {
            string roomName = roomNameTextBox.Text;
            //string joinedPlayer = _authService.GetUserByUsername(loggedInUser.Username).Username;
            string joinedPlayer = "Test2"; // Bu kısmı loggedInUser'dan almak yerine sabit bir değer kullanıyorsunuz.

            var duelloGamesCollection = _database.GetDuelloGamesCollection();
            var filter = Builders<DuelloGame>.Filter.Eq(game => game.RoomName, roomName);
            var update = Builders<DuelloGame>.Update.Set(game => game.JoinedPlayer, joinedPlayer);
            var result = duelloGamesCollection.UpdateOne(filter, update);

            if (result.ModifiedCount > 0)
            {
                MessageBox.Show("Odaya katıldınız.");

                // Oyun başlatılabilir mi kontrol et
                var room = duelloGamesCollection.Find(filter).FirstOrDefault();
                if (room != null)
                {
                    if (!room.IsGameStarted)
                    {
                        // Başlatma ekranına geç
                        ShowStartGameScreen(room);
                    }
                    else
                    {
                        // Oyun başladıysa hemen yeni formu aç
                        var gameForm = new GameForm(room);
                        gameForm.Show();
                        this.Close(); // WaitingScreen formunu kapat
                    }
                }
            }
            else
            {
                MessageBox.Show("Oda bulunamadı veya dolu.");
            }
        }


        //private void ShowWaitingScreen()
        //{
        //    WaitingScreen waitingScreen = new WaitingScreen();
        //    waitingScreen.Show();
        //}


        private DuelloGame _room;
        private void ShowStartGameScreen(DuelloGame room)
        {

            _room = room;

            if (!_room.IsGameStarted)
            {
                _room.StartGame();

                var duelloGamesCollection = new Database().GetDuelloGamesCollection();
                var filter = Builders<DuelloGame>.Filter.Eq(game => game.RoomName, _room.RoomName);
                var update = Builders<DuelloGame>.Update.Set(game => game.IsGameStarted, true);
                duelloGamesCollection.UpdateOne(filter, update);

                GameForm gameForm = new GameForm(_room);
                gameForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Oyun zaten başladı.");
            }
        }
    }



}
