using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using System.Media;
using ClickerGame.Properties;
using NAudio.Wave;
using static System.Windows.Forms.DataFormats;

namespace ClickerGame
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer leaderboardTimer;

        private int localClickCount = 0; // Yerel týklamalarý tutacak deðiþken
        private int serverClickCount = 0; // Sunucudaki týklama sayýsý
        private bool isUpdating = false; // Veriyi güncelliyor olup olmadýðýný takip eder

        private int clickCount = 0;
        private const int clickThreshold = 50;

        private Database database;

        private AuthService authService;
        private User loggedInUser;
        private Random random = new Random();

        private Label floatingLabel;
        private System.Windows.Forms.Timer labelHideTimer;
        private System.Windows.Forms.Timer labelFadeTimer;
        private const int labelDisplayTime = 1000; // Label'ý 1 saniye göster
        private const int labelFadeTime = 300; // Label'ýn kaybolma süresi (300 ms)
        private const int fadeStep = 5; // Her adýmda þeffaflýk deðiþimi

        private System.Windows.Forms.Timer clickTimer;
        private bool canClick;



        private static string kirmizinormal = "Kýzýl Tilki";
        private static string karlitilki = "Mavi Tilki";
        private static string BiyikliTilki = "Býyýklý Tilki";
        private static string UyuklayanTilki = "Uyuklayan Tilki";
        private static string MisirTil = "Mýsýrlý Tilki";
        private static string PembeTilki = "Pembe Tilki";
        private static string SariTilki = "Sarý Tilki";
        private static string SiyT = "Siyah Tilki";
        private static string SuriT = "Suriyeli Tilki";
        private static string TT = "Turuncu Tilki";
        private static string Yt = "Yeþil Tilki";
        private static string HKT = "Zýplayan Tilki";
        private static string NahliTilki = "Nahlý Tilki";
        private static string UcubeTilki = "Ucube Tilki";
        private static string Bos = "";

        // Eþyalarýn nadirlik deðerlerini tanýmlayýn
        Dictionary<string, double> itemRarity = new Dictionary<string, double>
        {
            { kirmizinormal, 0.0009 },   // %0.09 ihtimal // %5 ihtimal 0.05 // %1 ihtimal 0.01 // ----> %0.01 Ýhtimal 0.0001
            { karlitilki, 0.00008 },     // %0.008 ihtimal
            { BiyikliTilki, 0.00005 },   // %0.005 ihtimal
            { UyuklayanTilki, 0.00005 }, // %0.005 ihtimal
            { MisirTil, 0.00004 },       // %0.004 ihtimal
            { PembeTilki, 0.00003 },     // %0.003 ihtimal
            { SariTilki, 0.00002 },      // %0.002 ihtimal
            { SiyT, 0.00001 },           // %0.001 ihtimal
            { SuriT, 0.00001 },          // %0.001 ihtimal
            { TT, 0.000009 },            // %0.0009 ihtimal
            { Yt, 0.000008 },            // %0.0008 ihtimal
            { HKT, 0.000001 },           // %0.0001 ihtimal
        };

        private void MevcutEsyaSecim()
        {
            loggedInUser = authService.GetUserByUsername(loggedInUser.Username);
            // Seçili eþyayý ClickerButton'a yükle
            if (!string.IsNullOrEmpty(loggedInUser.SelectedItem))
            {
                // Envanterde bu eþyanýn olup olmadýðýný kontrol et
                var selectedItemInInventory = loggedInUser.Inventory.FirstOrDefault(i => i.Name == loggedInUser.SelectedItem);
                if (selectedItemInInventory != null)
                {
                    // Eþya envanterde varsa iþlemi gerçekleþtir
                    ClickerButton.Text = $"Eþya: {loggedInUser.SelectedItem}";

                    if (loggedInUser.SelectedItem == kirmizinormal)
                    {
                        // PictureBox1'e Resources içindeki "itemImage" adlý resmi atar
                        pictureBox1.Image = Properties.Resources.K1;
                    }
                    else if (loggedInUser.SelectedItem == karlitilki)
                    {
                        // PictureBox1'e Resources içindeki "itemImage" adlý resmi atar
                        pictureBox1.Image = Properties.Resources.S1;
                    }
                    else if (loggedInUser.SelectedItem == BiyikliTilki)
                    {
                        // PictureBox1'e Resources içindeki "itemImage" adlý resmi atar
                        pictureBox1.Image = Properties.Resources.BKT;
                    }
                    else if (loggedInUser.SelectedItem == UyuklayanTilki)
                    {
                        // PictureBox1'e Resources içindeki "itemImage" adlý resmi atar
                        pictureBox1.Image = Properties.Resources.KUT;
                    }
                    else if (loggedInUser.SelectedItem == MisirTil)
                    {
                        // PictureBox1'e Resources içindeki "itemImage" adlý resmi atar
                        pictureBox1.Image = Properties.Resources.MT;
                    }
                    else if (loggedInUser.SelectedItem == PembeTilki)
                    {
                        // PictureBox1'e Resources içindeki "itemImage" adlý resmi atar
                        pictureBox1.Image = Properties.Resources.PT;
                    }
                    else if (loggedInUser.SelectedItem == SariTilki)
                    {
                        // PictureBox1'e Resources içindeki "itemImage" adlý resmi atar
                        pictureBox1.Image = Properties.Resources.SAT;
                    }
                    else if (loggedInUser.SelectedItem == SiyT)
                    {
                        // PictureBox1'e Resources içindeki "itemImage" adlý resmi atar
                        pictureBox1.Image = Properties.Resources.ST;
                    }
                    else if (loggedInUser.SelectedItem == SuriT)
                    {
                        // PictureBox1'e Resources içindeki "itemImage" adlý resmi atar
                        pictureBox1.Image = Properties.Resources.SURT;
                    }
                    else if (loggedInUser.SelectedItem == TT)
                    {
                        // PictureBox1'e Resources içindeki "itemImage" adlý resmi atar
                        pictureBox1.Image = Properties.Resources.TT;
                    }
                    else if (loggedInUser.SelectedItem == Yt)
                    {
                        // PictureBox1'e Resources içindeki "itemImage" adlý resmi atar
                        pictureBox1.Image = Properties.Resources.YT;
                    }
                    else if (loggedInUser.SelectedItem == HKT)
                    {
                        // PictureBox1'e Resources içindeki "itemImage" adlý resmi atar
                        pictureBox1.Image = Properties.Resources.HNT;
                    }
                    else if (loggedInUser.SelectedItem == NahliTilki)
                    {
                        // PictureBox1'e Resources içindeki "itemImage" adlý resmi atar
                        pictureBox1.Image = Properties.Resources.NahliTilki;
                    }
                    else if (loggedInUser.SelectedItem == UcubeTilki)
                    {
                        // PictureBox1'e Resources içindeki "itemImage" adlý resmi atar
                        pictureBox1.Image = Properties.Resources.UcubeTilki;
                    }
                    else
                    {
                        pictureBox1.Image = Properties.Resources.KV1;
                    }




                }
                else
                {
                    ClickerButton.Text = $"Týkla!";
                    pictureBox1.Image = Properties.Resources.KV1;
                }

            }
        }

        private Image GetImageForItem(string itemName)
        {
            // Eþyaya göre uygun resmi seç
            if (itemName == kirmizinormal)
            {
                return Properties.Resources.K1;
            }
            else if (itemName == karlitilki)
            {
                return Properties.Resources.S1;
            }
            else if (itemName == BiyikliTilki)
            {
                return Properties.Resources.BKT;
            }
            else if (itemName == UyuklayanTilki)
            {
                return Properties.Resources.KUT;
            }
            else if (itemName == MisirTil)
            {
                return Properties.Resources.MT;
            }
            else if (itemName == PembeTilki)
            {
                return Properties.Resources.PT;
            }
            else if (itemName == SariTilki)
            {
                return Properties.Resources.SAT;
            }
            else if (itemName == SiyT)
            {
                return Properties.Resources.ST;
            }
            else if (itemName == SuriT)
            {
                return Properties.Resources.SURT;
            }
            else if (itemName == TT)
            {
                return Properties.Resources.TT;
            }
            else if (itemName == Yt)
            {
                return Properties.Resources.YT;
            }
            else if (itemName == HKT)
            {
                return Properties.Resources.HNT;
            }
            else if (itemName == HKT)
            {
                return Properties.Resources.HNT;
            }
            else if (itemName == NahliTilki)
            {
                return Properties.Resources.NahliTilki;
            }
            else if (itemName == UcubeTilki)
            {
                return Properties.Resources.UcubeTilki;
            }
            else
            {
                return Properties.Resources.KV1;
            }
        }

        public Form1()
        {
            InitializeComponent();

            // MongoDB baðlantýsýný baþlat
            database = new Database(); // Initialize database field
            authService = new AuthService(database);

            // ClickerButton baþlangýçta inaktif
            ClickerButton.Enabled = false;

            // Giriþ yapýldýðýnda envanteri ve puaný güncelle
            LoadUserData();

            // Timer'ý oluþturun
            clickTimer = new System.Windows.Forms.Timer();
            clickTimer.Interval = 150; // 1 saniye (1000 milisaniye)
            clickTimer.Tick += ClickTimer_Tick;

            // Ýlk baþta týklamaya izin ver
            canClick = true;







            ///
            // Floating label oluþtur ve ayarla
            floatingLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Red,
                BackColor = Color.Transparent,
                Visible = false,
                Parent = this // Form üzerinde gösterilmesi için
            };

            // Zamanlayýcý oluþtur ve ayarla
            labelHideTimer = new System.Windows.Forms.Timer
            {
                Interval = labelDisplayTime
            };
            labelHideTimer.Tick += (s, args) =>
            {
                // 1 saniye sonra animasyonlu kaybolmayý baþlat
                StartFadeOutAnimation();
                labelHideTimer.Stop();
            };

            // Animasyon zamanlayýcýyý ayarla
            labelFadeTimer = new System.Windows.Forms.Timer
            {
                Interval = labelFadeTime / (255 / fadeStep) // Þeffaflýk deðiþimini her adýmda ayarlar
            };
            labelFadeTimer.Tick += (s, args) =>
            {
                if (floatingLabel.BackColor.A > fadeStep)
                {
                    // Label'ý her adýmda þeffaflaþtýr
                    floatingLabel.BackColor = Color.FromArgb(floatingLabel.BackColor.A - fadeStep, Color.Transparent);
                }
                else
                {
                    // Tamamen görünmez olduðunda gizle
                    floatingLabel.Visible = false;
                    labelFadeTimer.Stop();
                }
            };

            // Fare hareketini dinle
            this.MouseMove += (s, e) =>
            {
                if (floatingLabel.Visible)
                {
                    floatingLabel.Location = new Point(e.X + 10, e.Y + 10); // Konumu fare imlecinin biraz yanýna koyar
                }
            };
        }

        private void StartFadeOutAnimation()
        {
            // Fade out animasyonunu baþlat
            labelFadeTimer.Start();
        }

        private void ClickTimer_Tick(object sender, EventArgs e)
        {
            // Timer durdurulur ve týklamaya izin verilir
            canClick = true;
            clickTimer.Stop();
        }

        private void LoadUserData()
        {
            if (loggedInUser != null)
            {
                // Mevcut puaný Label1'de göster
                Puan.Text = $"Puanýnýz: {loggedInUser.Points}";

                // Envanteri güncelle
                UpdateInventoryDisplay();
            }
        }

        private async void UpdateClickCountFromServer()
        {
            //if (loggedInUser == null || isUpdating) return;

            //isUpdating = true;
            //try
            //{
            //    // Sunucudan týklama sayýsýný al
            //    //int newServerClickCount = await authService.GetClickCountForUserAsync(loggedInUser.Username);

            //    // Yerel týklamalarý sunucudaki deðere ekle ve güncelle
            //    //newServerClickCount += localClickCount;

            //    // Sunucuya güncellenmiþ deðeri gönder
            //    //await authService.UpdateClickCountForUserAsync(loggedInUser.Username, newServerClickCount);

            //    // Sunucudaki yeni týklama sayýsýný güncelle
            //    //serverClickCount = newServerClickCount;


            //    // Yerel týklamalarý sýfýrla
            //    //localClickCount = 0;
            //    //loggedInUser = authService.GetUserByUsername(loggedInUser.Username);
            //    // Ekranda týklama sayýsýný güncelle
            //    //loggedInUser.Points += localClickCount;
            //    //loggedInUser.Points++;
            //    //Puan.Text = $"Puanýnýz: {serverClickCount}";
            //}
            //finally
            //{
            //    isUpdating = false;
            //}
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Giriþ iþlemi
            loggedInUser = authService.Login(username, password);
            if (loggedInUser != null)
            {
                MessageBox.Show("Baþarýyla giriþ yapýldý!", "Giriþ Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ClickerButton aktif hale gelir
                ClickerButton.Enabled = true;

                // Mevcut puaný Label1'de göster
                Puan.Text = $"Puanýnýz: {loggedInUser.Points}";

                MevcutEsyaSecim();

                //// Seçili eþyayý ClickerButton'a yükle
                //if (!string.IsNullOrEmpty(loggedInUser.SelectedItem))
                //{
                //    // Envanterde bu eþyanýn olup olmadýðýný kontrol et
                //    var selectedItemInInventory = loggedInUser.Inventory.FirstOrDefault(i => i.Name == loggedInUser.SelectedItem);
                //    if (selectedItemInInventory != null)
                //    {
                //        // Eþya envanterde varsa iþlemi gerçekleþtir
                //        ClickerButton.Text = $"Eþya: {loggedInUser.SelectedItem}";
                //    }
                //    else
                //    {
                //        ClickerButton.Text = $"Týkla!";
                //    }

                //}

                UpdateClickCountFromServer();

                // Envanteri güncelle
                UpdateInventoryDisplay();
            }
            else
            {
                MessageBox.Show("Kullanýcý adý veya þifre hatalý.", "Giriþ Hatasý", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Kayýt iþlemi
            if (authService.Register(username, password))
            {
                MessageBox.Show("Baþarýyla kayýt olundu! Þimdi giriþ yapabilirsiniz.", "Kayýt Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bu kullanýcý adý zaten mevcut.", "Kayýt Hatasý", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ClickerButton'a her týkladýðýnda puaný artýran ve eþya düþüren fonksiyon
        private async void ClickerButton_Click(object sender, EventArgs e)
        {







            if (canClick)
            {









                // Eðer loggedInUser.SelectedItem SariTilki ise
                if (loggedInUser.SelectedItem == SariTilki)
                {
                    clickCount++;
                    if (clickCount >= clickThreshold)
                    {
                        // Farklý sesi çal
                        var sound1 = new MemoryStream(Properties.Resources.Fart);
                        var waveStream1 = new WaveFileReader(sound1);
                        var waveOut1 = new WaveOutEvent();
                        waveOut1.Init(waveStream1);
                        waveOut1.Play();
                        // Sayaçý sýfýrla
                        clickCount = 0;
                    }
                    else
                    {
                        // Ana sesi çal
                        var sound1 = new MemoryStream(Properties.Resources.Click);
                        var waveStream1 = new WaveFileReader(sound1);
                        var waveOut1 = new WaveOutEvent();
                        waveOut1.Init(waveStream1);
                        waveOut1.Play();
                    }
                }
                else
                {
                    var sound1 = new MemoryStream(Properties.Resources.Click);
                    var waveStream1 = new WaveFileReader(sound1);
                    var waveOut1 = new WaveOutEvent();
                    waveOut1.Init(waveStream1);
                    waveOut1.Play();

                    //await Task.Run(() =>
                    //{
                    //    // Properties.Resources.Click'in bir byte[] dizisi olduðunu varsayýyoruz
                    //    byte[] soundData = Properties.Resources.Click;

                    //    // Byte[]'ý MemoryStream'e dönüþtür
                    //    using (MemoryStream stream = new MemoryStream(soundData))
                    //    {
                    //        using (SoundPlayer player = new SoundPlayer(stream))
                    //        {
                    //            player.Play(); // Ses dosyasýný oynat
                    //        }
                    //    }
                    //});
                }





                //------------------>>
                canClick = false;
                clickTimer.Start();

                await Task.Run(() => ProcessClickAsync());



                //// Fare týklamasýnýn ekran üzerindeki pozisyonunu al
                //Point mousePosition = this.PointToClient(Cursor.Position);

                //// Floating label'ý ayarla
                //this.Invoke(new Action(() =>
                //{
                //    floatingLabel.Text = "+1";
                //    floatingLabel.Location = new Point(mousePosition.X + 10, mousePosition.Y + 10); // Konumu fare imlecinin biraz yanýna koyar
                //    floatingLabel.Visible = true;
                //    floatingLabel.BackColor = Color.FromArgb(255, Color.Transparent); // Baþlangýçta tamamen opak
                //    floatingLabel.BringToFront(); // Diðer tüm kontrollerin üzerinde olmasýný saðlar

                //    // 1 saniye sonra label'ý kaybolma animasyonunu baþlat
                //    labelHideTimer.Start();
                //}));
            }

        }


        private void ProcessClickAsync()
        {
            if (loggedInUser != null)
            {

                // Kullanýcýyý güncelle
                loggedInUser = authService.GetUserByUsername(loggedInUser.Username);

                //LoadUserData();
                //MevcutEsyaSecim();
                //UpdateInventoryDisplay();

                // Envanterde bu eþyanýn olup olmadýðýný kontrol et


                this.Invoke(new Action(() =>
                {
                    var selectedItemInInventory = loggedInUser.Inventory.FirstOrDefault(i => i.Name == loggedInUser.SelectedItem);
                    if (selectedItemInInventory != null)
                    {
                        // Eþya envanterde varsa iþlemi gerçekleþtir
                        ClickerButton.Text = $"Eþya: {loggedInUser.SelectedItem}";
                    }
                    else
                    {
                        ClickerButton.Text = $"Týkla!";
                    }

                    if (loggedInUser.SelectedItem == HKT)
                    {
                        loggedInUser.Points++;
                        loggedInUser.Points++;
                        loggedInUser.Points++;
                    }
                    else
                    {
                        loggedInUser.Points++; // Puaný artýr
                                               //localClickCount++;
                    }


                    Puan.Text = $"Puanýnýz: {loggedInUser.Points}"; // Puaný Label1'de güncelle

                }));





                // Eþyalarýn nadirlik deðerlerine göre rastgele bir eþya seç
                string droppedItem = null;
                double randomValue = random.NextDouble();

                // Eþyalarýn nadirlik deðerlerine göre düþüþ ihtimalini kontrol et
                foreach (var item in itemRarity)
                {
                    if (randomValue < item.Value)
                    {
                        droppedItem = item.Key;
                        break;
                    }
                    randomValue -= item.Value;
                }

                this.Invoke(new Action(() =>
                {
                    if (droppedItem != null)
                    {
                        // Mevcut eþyayý envantere ekle veya miktarýný artýr
                        authService.AddOrUpdateItemInInventory(loggedInUser.Username, droppedItem);

                        // Envanteri güncelle
                        loggedInUser.Inventory = authService.GetUserInventory(loggedInUser.Username);
                        UpdateInventoryDisplay();

                        //MessageBox.Show($"Yeni eþya kazandýnýz: {droppedItem}", "Eþya Düþüþü", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowNotification(droppedItem);
                    }
                }));



                // Puaný MongoDB'ye kaydet
                authService.UpdateUserPoints(loggedInUser.Username, loggedInUser.Points);
            }
        }




        private void ShowNotification(string droppedItem)
        {
            // Notif formunu oluþtur ve gerekli resim ve metni ayarla
            Image notificationImage = GetImageForItem(droppedItem);
            string notificationText = $"Yeni Eþya: {droppedItem}";

            // Notif formunu oluþtur ve göster
            Notif notificationForm = new Notif(notificationText, notificationImage);
            notificationForm.Show();
        }






        private void UpdateInventoryDisplay()
        {
            if (loggedInUser.Inventory.Any())
            {
                var inventoryItems = loggedInUser.Inventory;
                var inventoryList = string.Join(", ", inventoryItems.Select(i => $"{i.Name} ({i.Count})"));
                //MessageBox.Show($"Envanteriniz: {inventoryList}", "Envanter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //MessageBox.Show("Envanteriniz boþ.", "Envanter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Envanter butonuna týklandýðýnda eþyalarý gösteren fonksiyon
        private async void InventoryButton_Click(object sender, EventArgs e)
        {
            if (loggedInUser != null)
            {


                // Kullanýcýyý güncelle
                loggedInUser = authService.GetUserByUsername(loggedInUser.Username);

                // Verileri ekranda güncelle
                LoadUserData();

                // Envanteri güncelle
                UpdateInventoryDisplay();

                await Task.Run(() =>
                {
                    // Properties.Resources.Click'in bir byte[] dizisi olduðunu varsayýyoruz
                    byte[] soundData = Properties.Resources.OpenMenu;

                    // Byte[]'ý MemoryStream'e dönüþtür
                    using (MemoryStream stream = new MemoryStream(soundData))
                    {
                        using (SoundPlayer player = new SoundPlayer(stream))
                        {
                            player.Play(); // Ses dosyasýný oynat
                        }
                    }
                });

                // Envanterdeki eþyalar arasýndan seçim yapma
                var selectItemDialog = new SelectItemDialog(loggedInUser.Inventory.Select(i => i.Name).ToList());
                if (selectItemDialog.ShowDialog() == DialogResult.OK)
                {

                    // Önce gerekli kontrolleri yapalým
                    if (authService != null && loggedInUser != null && !string.IsNullOrEmpty(loggedInUser.Username))
                    {
                        // selectItemDialog'dan seçilen öðeyi alalým
                        string selectedItem = selectItemDialog?.SelectedItem;

                        if (!string.IsNullOrEmpty(selectedItem))
                        {
                            // selectedItem geçerliyse, mevcut öðeyi güncelleyelim
                            authService.SetSelectedItem(loggedInUser.Username, selectedItem);

                            // ClickerButton üzerindeki yazýyý deðiþtirelim
                            ClickerButton.Text = $"Eþya: {selectedItem}";

                            // Mevcut eþyayý güncelleyelim
                            LoadUserData();
                            MevcutEsyaSecim();
                            UpdateInventoryDisplay();
                        }
                        else
                        {
                            // selectedItem null veya boþsa yapýlacak iþlemler
                            MessageBox.Show("Seçilen öðe geçerli deðil.");
                        }
                    }
                    else
                    {
                        // authService veya loggedInUser null ise yapýlacak iþlemler
                        MessageBox.Show("Kullanýcý veya servis geçerli deðil.");
                    }

                }

                //loggedInUser = authService.GetUserByUsername(loggedInUser.SelectedItem);
                loggedInUser = authService.GetUserByUsername(loggedInUser.Username);
                LoadUserData();
                MevcutEsyaSecim();
                UpdateInventoryDisplay();

            }
        }


        private void btnOpenMarket_Click(object sender, EventArgs e)
        {
            if (loggedInUser != null)
            {
                // Market formunu aç
                var marketForm = new MarketForm(authService, loggedInUser, database);
                marketForm.ShowDialog();

                // Market formu kapandýktan sonra verileri güncelle
                LoadUserData();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm(authService, this);
            loginForm.ShowDialog();

            // Initialize the timer
            leaderboardTimer = new System.Windows.Forms.Timer();
            leaderboardTimer.Interval = 2000; // 2 seconds
            leaderboardTimer.Tick += UpdateLeaderboard;
            leaderboardTimer.Start();
        }

        private void UpdateLeaderboard(object sender, EventArgs e)
        {
            UpdateClickCountFromServer();
            var topUsers = database.GetTopUsers(10);
            DisplayTopUsers(topUsers);
        }

        private void DisplayTopUsers(List<User> topUsers)
        {
            // Clear previous leaderboard
            leaderboardLabel.Text = "";

            for (int i = 0; i < topUsers.Count; i++)
            {
                var user = topUsers[i];
                leaderboardLabel.Text += $"{i + 1}. {user.Username} - {user.Points} Puan\n";
            }
        }


        public void SetLoggedInUser(User user)
        {
            loggedInUser = user;
            LoadUserData();
            MevcutEsyaSecim();
            ClickerButton.Enabled = true;

        }

        public User GetLoggedInUser()
        {
            return this.loggedInUser;
        }

        private async void pictureBox4_Click(object sender, EventArgs e)
        {
            if (loggedInUser != null)
            {


                loggedInUser = authService.GetUserByUsername(loggedInUser.Username);


                Image notificationImage = GetImageForItem(loggedInUser.SelectedItem);

                // FindCorrectPoints formunu aç
                var gameForm = new FindCorrectPoints(loggedInUser, notificationImage, authService, database);

                await Task.Run(() =>
                {
                    // Properties.Resources.Click'in bir byte[] dizisi olduðunu varsayýyoruz
                    byte[] soundData = Properties.Resources.OpenMenu;

                    // Byte[]'ý MemoryStream'e dönüþtür
                    using (MemoryStream stream = new MemoryStream(soundData))
                    {
                        using (SoundPlayer player = new SoundPlayer(stream))
                        {
                            player.Play(); // Ses dosyasýný oynat
                        }
                    }
                });

                gameForm.ShowDialog();

                // Market formu kapandýktan sonra verileri güncelle
                LoadUserData();
                //authService.UpdateUserPoints(loggedInUser.Username, loggedInUser.Points);
            }
        }

        private async void pictureBox5_Click(object sender, EventArgs e)
        {
            if (loggedInUser != null)
            {


                loggedInUser = authService.GetUserByUsername(loggedInUser.Username);


                Image notificationImage = GetImageForItem(loggedInUser.SelectedItem);


                var gameForm = new FireGame(loggedInUser, notificationImage);

                await Task.Run(() =>
                {
                    // Properties.Resources.Click'in bir byte[] dizisi olduðunu varsayýyoruz
                    byte[] soundData = Properties.Resources.OpenMenu;

                    // Byte[]'ý MemoryStream'e dönüþtür
                    using (MemoryStream stream = new MemoryStream(soundData))
                    {
                        using (SoundPlayer player = new SoundPlayer(stream))
                        {
                            player.Play(); // Ses dosyasýný oynat
                        }
                    }
                });

                gameForm.ShowDialog();

                // Market formu kapandýktan sonra verileri güncelle
                LoadUserData();
                authService.UpdateUserPoints(loggedInUser.Username, loggedInUser.Points);
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            // Oda oluþturma için RoomForm'u aç
            RoomForm rf = new RoomForm(new Database(), new AuthService(new Database()));
            rf.ShowDialog();

            // Kullanýcý verilerini güncelle
            LoadUserData();
            authService.UpdateUserPoints(loggedInUser.Username, loggedInUser.Points);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            var resultmsg = MessageBox.Show(
                    $"Eðer sýrayý aklýnda tut oyununu kazanýrsanýz 100 puan artar, eðer kaybederseniz 100 puan eksilir.",
                    "Onay",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
            );

            if (resultmsg == DialogResult.Yes)
            {
                loggedInUser.Points -= 100;
                authService.UpdateUserPoints(loggedInUser.Username, loggedInUser.Points);
                // Form2'yi oluþtur
                MemoryGame mg = new MemoryGame();

                // Form2'yi modal olarak aç
                DialogResult result = mg.ShowDialog();

                // Eðer kullanýcý Form2'de onay verdi ise (OK düðmesi ile kapandýysa)
                if (result == DialogResult.OK)
                {
                    // Form2'den gelen veriyi al ve Form1'de kullan
                    int receivedData = mg.ReturnedData;
                    //MessageBox.Show("Form2'den gelen veri: " + receivedData);
                    loggedInUser.Points += 100;
                    loggedInUser.Points += receivedData;
                }

                LoadUserData();
                authService.UpdateUserPoints(loggedInUser.Username, loggedInUser.Points);
            }
            else
            {
                
            }

           

        }



    }



    public class Database
    {
        private IMongoDatabase database;

        public Database()
        {
            //var client = new MongoClient("mongodb://localhost:27017"); // MongoDB baðlantý adresini buraya ekleyin
            var client = new MongoClient("YOUR_MONGODB_URI"); // MongoDB baðlantý adresini buraya ekleyin
            database = client.GetDatabase("ClickerGame");
        }

        public IMongoCollection<User> GetUsersCollection()
        {
            return database.GetCollection<User>("Users");
        }

        public IMongoCollection<MarketItem> GetMarketItemsCollection()
        {
            return database.GetCollection<MarketItem>("MarketItems");
        }

        public IMongoCollection<Notification> GetNotificationsCollection()
        {
            return database.GetCollection<Notification>("Notifications");
        }

        public IMongoCollection<DuelloGame> GetDuelloGamesCollection()
        {
            return database.GetCollection<DuelloGame>("DuelloGames");
        }

        public List<User> GetTopUsers(int topCount)
        {
            var usersCollection = GetUsersCollection();
            var filter = Builders<User>.Filter.Empty;
            var sort = Builders<User>.Sort.Descending(u => u.Points);
            return usersCollection.Find(filter)
                                  .Sort(sort)
                                  .Limit(topCount)
                                  .ToList();
        }
    }




    public class AuthService
    {
        private IMongoCollection<User> users;
        private IMongoCollection<MarketItem> marketItems;
        private IMongoCollection<Notification> notifications;
        private IMongoDatabase database; // 'database' deðiþkenini tanýmlayýn
        private IMongoCollection<DuelloGame> duelloGames;
        public Database Database { get; private set; }

        public AuthService(Database db)
        {
            users = db.GetUsersCollection();
            marketItems = db.GetMarketItemsCollection();
            notifications = db.GetNotificationsCollection();
            duelloGames = db.GetDuelloGamesCollection();
        }

        public User GetUserByUsername(string username)
        {
            return users.Find(u => u.Username == username).FirstOrDefault();
        }

        // Basit bir veri saklama yapýsý (örneðin kullanýcý ID'leri ve click sayýlarý)
        private Dictionary<string, int> userClickCounts = new Dictionary<string, int>();

        // Kullanýcýnýn click sayýsýný almak için async metod
        public async Task<int> GetClickCountForUserAsync(string userId)
        {
            // Simülasyon amaçlý asenkron bir iþlem (örneðin veri tabanýndan veri alýnýyor)
            await Task.Delay(100); // Yapýlacak iþlem simülasyonu
            if (userClickCounts.ContainsKey(userId))
            {
                return userClickCounts[userId];
            }
            else
            {
                return 0; // Eðer kullanýcý yoksa 0 týklama döndürüyoruz
            }
        }




        // Kullanýcýnýn click sayýsýný güncellemek için async metod
        public async Task<bool> UpdateClickCountForUserAsync(string userId, int newClickCount)
        {
            await Task.Delay(100); // Simülasyon amaçlý asenkron iþlem

            // Kullanýcý var mý yok mu kontrol ediyoruz, yoksa yeni ekliyoruz
            if (userClickCounts.ContainsKey(userId))
            {
                userClickCounts[userId] = newClickCount;
            }
            else
            {
                userClickCounts.Add(userId, newClickCount);
            }

            return true; // Güncelleme baþarýlý
        }

        // Kullanýcýnýn envanterinden ürünü kaldýr
        //public void RemoveItemFromInventory(string username, string itemName)
        //{
        //    var filter = Builders<User>.Filter.Eq(u => u.Username, username);
        //    var itemFilter = Builders<User>.Filter.ElemMatch(u => u.Inventory, i => i.Name == itemName);
        //    var update = Builders<User>.Update.PullFilter(u => u.Inventory, i => i.Name == itemName);
        //    users.UpdateOne(filter & itemFilter, update);
        //}

        // Kullanýcýnýn envanterinden belirtilen miktardaki ürünü kaldýr
        // Kullanýcýnýn envanterinden ürünü kaldýr
        public void RemoveItemFromInventory(string username, string itemName, int quantity)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Username, username);
            var itemFilter = Builders<User>.Filter.ElemMatch(u => u.Inventory, i => i.Name == itemName);

            var update = Builders<User>.Update.Inc("Inventory.$.Count", -quantity);

            var result = users.UpdateOne(filter & itemFilter, update);

            // Eðer ürün miktarý 0'a düþtüyse, envanterden tamamen çýkar
            if (result.ModifiedCount > 0)
            {
                var inventory = users.Find(filter).FirstOrDefault()?.Inventory;
                var item = inventory?.FirstOrDefault(i => i.Name == itemName);

                if (item != null && item.Count <= 0)
                {
                    var pullUpdate = Builders<User>.Update.PullFilter(u => u.Inventory, i => i.Name == itemName);
                    users.UpdateOne(filter, pullUpdate);
                }
            }
        }


        // Kullanýcýnýn envanterine ürün ekle veya güncelle
        public void AddOrUpdateItemInInventory(string username, string itemName, int quantity)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Username, username);
            var itemFilter = Builders<User>.Filter.ElemMatch(u => u.Inventory, i => i.Name == itemName);
            var update = Builders<User>.Update.Inc("Inventory.$.Count", quantity);

            var updateOptions = new UpdateOptions { IsUpsert = true };

            var result = users.UpdateOne(filter & itemFilter, update);

            if (result.ModifiedCount == 0)
            {
                var newItem = new Item { Name = itemName, Count = quantity };
                var addItemUpdate = Builders<User>.Update.AddToSet(u => u.Inventory, newItem);
                users.UpdateOne(filter, addItemUpdate, updateOptions);
            }
        }


        public bool IsUserSeller(string username, string itemName)
        {
            // Pazardaki ürünlerin sahiplerini kontrol edin
            var marketItems = GetMarketItems(); // Tüm pazar ürünlerini al
            return marketItems.Any(item => item.Name == itemName && item.Seller == username);
        }


        // Kullanýcýyý kaydet
        public bool Register(string username, string password)
        {
            var existingUser = users.Find(u => u.Username == username).FirstOrDefault();
            if (existingUser == null)
            {
                var newUser = new User
                {
                    Username = username,
                    Password = BCrypt.Net.BCrypt.HashPassword(password), // Þifreyi hashle
                    Points = 0,
                    Inventory = new List<Item>()
                };
                users.InsertOne(newUser);
                return true;
            }
            return false;
        }

        // Kullanýcý giriþi
        //public User Login(string username, string password)
        //{
        //    var user = users.Find(u => u.Username == username).FirstOrDefault();
        //    if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
        //    {
        //        return user; // Giriþ baþarýlý
        //    }
        //    return null; // Giriþ baþarýsýz
        //}

        public User Login(string username, string password)
        {
            var user = users.Find(u => u.Username == username).FirstOrDefault();
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                // Kullanýcýnýn günlük giriþ durumunu kontrol edin
                HandleDailyReward(user);

                return user;
            }
            return null;
        }

        // Kullanýcýnýn puanýný güncelle
        public void UpdateUserPoints(string username, int newPoints)
        {
            var update = Builders<User>.Update.Set(u => u.Points, newPoints);
            users.UpdateOne(u => u.Username == username, update);
        }

        // Kullanýcýnýn envanterine ürün ekle veya güncelle
        public void AddOrUpdateItemInInventory(string username, string itemName)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Username, username);

            // Eþyayý güncellerken
            var itemFilter = Builders<User>.Filter.ElemMatch(u => u.Inventory, i => i.Name == itemName);
            var update = Builders<User>.Update.Inc("Inventory.$.Count", 1);

            var updateOptions = new UpdateOptions { IsUpsert = true };

            // Önce mevcut eþyayý güncellemeye çalýþ
            var result = users.UpdateOne(filter & itemFilter, update);

            // Eðer eþya güncellenmediyse, yeni eþya ekle
            if (result.ModifiedCount == 0)
            {
                var newItem = new Item { Name = itemName, Count = 1 };
                var addItemUpdate = Builders<User>.Update.AddToSet(u => u.Inventory, newItem);

                users.UpdateOne(filter, addItemUpdate, updateOptions);
            }
        }

        // Kullanýcýnýn seçili ürününü ayarla
        public void SetSelectedItem(string username, string itemName)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Username, username);
            var update = Builders<User>.Update.Set(u => u.SelectedItem, itemName);
            users.UpdateOne(filter, update);
        }

        // Kullanýcýnýn envanterini al
        //public List<Item> GetUserInventory(string username)
        //{
        //    var user = users.Find(u => u.Username == username).FirstOrDefault();
        //    return user?.Inventory ?? new List<Item>();
        //}

        public List<Item> GetUserInventory(string username)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Username, username);
            var user = users.Find(filter).FirstOrDefault();
            return user?.Inventory ?? new List<Item>();
        }


        // Pazara ürün ekle
        public void AddMarketItem(MarketItem item)
        {
            marketItems.InsertOne(item);
        }

        // Pazardan ürün kaldýr
        public void RemoveMarketItem(MarketItem item)
        {
            var filter = Builders<MarketItem>.Filter.Eq(i => i.Id, item.Id);
            marketItems.DeleteOne(filter);
        }

        // Pazardaki ürünleri al
        public List<MarketItem> GetMarketItems()
        {
            return marketItems.Find(_ => true).ToList();
        }

        public void AddNotification(string username, string message)
        {
            var notification = new Notification
            {
                Username = username,
                Message = message,
                Timestamp = DateTime.Now
            };
            notifications.InsertOne(notification);
        }

        public List<Notification> GetNotifications(string username)
        {
            return notifications.Find(n => n.Username == username).ToList();
        }






        // Oda oluþturma ve MongoDB'ye ekleme
        public void CreateRoom(DuelloGame room)
        {
            duelloGames.InsertOne(room);
        }

        // Oda bilgilerini almak
        public DuelloGame GetRoomByName(string roomName)
        {
            return duelloGames.Find(r => r.RoomName == roomName).FirstOrDefault();
        }














        public void HandleDailyReward(User user)
        {
            // Türkiye'nin yerel zaman dilimini kullanmak için saat dilimi farkýný hesapla
            TimeZoneInfo turkeyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");

            // Türkiye zaman diliminde bugünün tarihini al
            DateTime today = TimeZoneInfo.ConvertTime(DateTime.Today, turkeyTimeZone);

            // Eðer kullanýcý tarih deðerleri boþsa, uygun varsayýlan deðerler ata
            DateTime lastLoginDate = user.LastLoginDate == default ? today.AddDays(-2) : user.LastLoginDate;
            DateTime lastRewardDate = user.LastRewardDate == default ? today.AddDays(-2) : user.LastRewardDate;

            // Türkiye zaman diliminde tarihi kontrol et
            lastLoginDate = TimeZoneInfo.ConvertTime(lastLoginDate, turkeyTimeZone);
            lastRewardDate = TimeZoneInfo.ConvertTime(lastRewardDate, turkeyTimeZone);

            // Eðer kullanýcý bugün giriþ yaptýysa veya ödül aldýysa, tekrar ödül verilmez
            if (lastLoginDate.Date == today.Date && lastRewardDate.Date == today.Date)
            {
                Console.WriteLine("Bugün zaten ödül alýndý, ödül verilmiyor.");
                return;
            }

            // Son giriþ tarihinin bugünden bir gün öncesi ile karþýlaþtýrma yaparak ardýþýk gün sayýsýný artýr
            if (lastLoginDate.Date == today.AddDays(-1).Date)
            {
                user.ConsecutiveLoginDays++;
            }
            else if (lastLoginDate.Date < today.AddDays(-1).Date)
            {
                // Eðer kullanýcý bir gün kaçýrmýþsa ardýþýk giriþ gün sayýsýný sýfýrla
                user.ConsecutiveLoginDays = 1;
            }

            // Son giriþ tarihini güncelle
            user.LastLoginDate = today;

            // Eðer kullanýcý maksimum gün sayýsýna ulaþtýysa ardýþýk gün sayýsýný sýfýrla
            if (user.ConsecutiveLoginDays > user.MaxDays)
            {
                user.ConsecutiveLoginDays = 1; // Tekrar 1. güne baþlar
            }

            // Ardýþýk giriþ günlerine göre ödül ver
            GiveRewardBasedOnConsecutiveDays(user);

            // Son ödül tarihini bugünün tarihiyle güncelle
            user.LastRewardDate = today;

            // Kullanýcý bilgilerini güncelle (veritabanýna kaydet)
            UpdateUserInDatabase(user);
        }




        private void GiveRewardBasedOnConsecutiveDays(User user)
        {
            string dayInfo = "";
            string rewardInfo = "";
            int rewardPoints = 0; // Verilen ödül puaný

            switch (user.ConsecutiveLoginDays)
            {
                case 1:
                    dayInfo = "1. gün ödülü verildi!";
                    rewardPoints = 100;
                    user.Points += rewardPoints;
                    break;
                case 2:
                    dayInfo = "2. gün ödülü verildi!";
                    rewardPoints = 1000;
                    user.Points += rewardPoints;
                    break;
                case 3:
                    dayInfo = "3. gün ödülü verildi!";
                    rewardPoints = 1500;
                    user.Points += rewardPoints;
                    break;
                case 4:
                    dayInfo = "4. gün ödülü verildi!";
                    rewardPoints = 3000;
                    user.Points += rewardPoints;
                    break;
                case 5:
                    dayInfo = "5. gün ödülü verildi!";
                    rewardPoints = 5000;
                    user.Points += rewardPoints;
                    break;
                case 6:
                    dayInfo = "6. gün ödülü verildi!";
                    rewardPoints = 6000;
                    user.Points += rewardPoints;
                    break;
                case 7:
                    dayInfo = "7. gün ödülü verildi!";
                    rewardPoints = 7000;
                    user.Points += rewardPoints;
                    break;
                case 8:
                    dayInfo = "8. gün ödülü verildi!";
                    rewardPoints = 8000;
                    user.Points += rewardPoints;
                    break;
                case 9:
                    dayInfo = "9. gün ödülü verildi!";
                    rewardPoints = 5000;
                    user.Points += rewardPoints;
                    break;
                case 10:
                    dayInfo = "10. gün ödülü verildi!";
                    rewardPoints = 5000;
                    user.Points += rewardPoints;
                    break;
                case 11:
                    dayInfo = "11. gün ödülü verildi!";
                    rewardPoints = 5000;
                    user.Points += rewardPoints;
                    break;
                case 12:
                    dayInfo = "12. gün ödülü verildi!";
                    rewardPoints = 1000;
                    user.Points += rewardPoints;
                    break;
                case 13:
                    dayInfo = "13. gün ödülü verildi!";
                    rewardPoints = 1000;
                    user.Points += rewardPoints;
                    break;
                case 14:
                    dayInfo = "14. gün ödülü verildi!";
                    rewardPoints = 20000;
                    user.Points += rewardPoints;
                    break;
                default:
                    dayInfo = $"{user.ConsecutiveLoginDays}. gün ödülü verildi!";
                    break;
            }

            rewardInfo = $"Ödül: {rewardPoints} puan";
            
            // Formu aç ve bilgileri göster
            DailyRewards rewardsForm = new DailyRewards(dayInfo, rewardInfo);
            rewardsForm.ShowDialog();  // Modal olarak formu göster
        }


        public void UpdateUserInDatabase(User user)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Username, user.Username);
            var update = Builders<User>.Update
                .Set(u => u.LastLoginDate, user.LastLoginDate)
                .Set(u => u.LastRewardDate, user.LastRewardDate)
                .Set(u => u.ConsecutiveLoginDays, user.ConsecutiveLoginDays)
                .Set(u => u.Points, user.Points);

            users.UpdateOne(filter, update);
        }




    }

    public class MarketItem
    {
        public ObjectId Id { get; set; } // MongoDB'de benzersiz ID
        public string Name { get; set; }
        public int Price { get; set; }
        public string Seller { get; set; }

        public string Display => $"{Name} - {Price} puan - Satýcý: {Seller}";
    }

    public class Notification
    {
        public string Username { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }

    







    //public class User
    //{
    //    [BsonId]
    //    public ObjectId Id { get; set; } // MongoDB'de benzersiz ID

    //    public string Username { get; set; }
    //    public string Password { get; set; }
    //    public int Points { get; set; }
    //    public List<Item> Inventory { get; set; }
    //    public string SelectedItem { get; set; }
    //}

    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public int Points { get; set; }
        public List<Item> Inventory { get; set; }
        public string SelectedItem { get; set; }


        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime LastLoginDate { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime LastRewardDate { get; set; }
        public int ConsecutiveLoginDays { get; set; } = 1;
        public int MaxDays { get; set; } = 14; // Ödül sistemi için maksimum ardýþýk gün sayýsý
    }


    public class Item
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }


    public class DuelloGame
    {
        public ObjectId Id { get; set; }  // MongoDB için Id alaný
        public string RoomName { get; set; }
        public string HostPlayer { get; set; }
        public string JoinedPlayer { get; set; }
        public int HostPlayerScore { get; set; }
        public int JoinedPlayerScore { get; set; }
        public int TimeRemaining { get; set; }
        public bool IsGameStarted { get; set; }

        public DuelloGame(string roomName, string hostPlayer)
        {
            RoomName = roomName;
            HostPlayer = hostPlayer;
            JoinedPlayer = string.Empty;
            HostPlayerScore = 0;
            JoinedPlayerScore = 0;
            TimeRemaining = 30; // Baþlangýç süresi
            IsGameStarted = false;
        }

        public DuelloGame()
        {
        }

        public void JoinGame(string playerName)
        {
            if (string.IsNullOrEmpty(JoinedPlayer))
            {
                JoinedPlayer = playerName;
            }
            else
            {
                throw new InvalidOperationException("Oyun zaten dolu.");
            }
        }

        public void StartGame()
        {
            if (!string.IsNullOrEmpty(JoinedPlayer))
            {
                IsGameStarted = true;
            }
            else
            {
                throw new InvalidOperationException("Oyun baþlatýlamaz. Katýlýmcý eksik.");
            }
        }
    }


    public class SelectItemDialog : Form
    {
        private ListBox itemListBox;
        private Button buttonOk;
        private Button buttonCancel;
        public string SelectedItem { get; private set; }
        private string defaultItem = "Varsayýlan"; // Varsayýlan deðer adý

        public SelectItemDialog(List<string> items)
        {
            InitializeComponent();
            this.Load += SelectItemDialog_Load;

            // Varsayýlan öðeyi listeye ekle
            if (!items.Contains(defaultItem))
            {
                items.Insert(0, defaultItem); // Varsayýlan öðeyi listenin baþýna ekle
            }

            itemListBox.DataSource = items;
            itemListBox.SelectedItem = defaultItem; // Varsayýlan öðeyi seçili yap

            // Pencereyi ekranýn ortasýna yerleþtirme
            this.StartPosition = FormStartPosition.CenterScreen;

        }



        private void SelectItemDialog_Load(object sender, EventArgs e)
        {
            // Formun simgesini ayarla
            byte[] iconBytes = Properties.Resources.KI; // Simgenizin byte[] formatýnda olduðunu varsayýyoruz
            using (var stream = new MemoryStream(iconBytes))
            {
                this.Icon = new Icon(stream);
            }
        }



        private void InitializeComponent()
        {
            this.itemListBox = new System.Windows.Forms.ListBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // itemListBox
            // 
            this.itemListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.itemListBox.FormattingEnabled = true;
            this.itemListBox.Location = new System.Drawing.Point(12, 12);
            this.itemListBox.Name = "itemListBox";
            this.itemListBox.Size = new System.Drawing.Size(260, 95);
            this.itemListBox.TabIndex = 0;

            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.buttonOk.Text = "Tamam";
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(116, 113);
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Click += new System.EventHandler(this.ButtonOk_Click);

            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            this.buttonCancel.Text = "Ýptal";
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(197, 113);
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;

            // 
            // SelectItemDialog
            // 
            this.ClientSize = new System.Drawing.Size(284, 148);
            this.Controls.Add(this.itemListBox);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Name = "SelectItemDialog";
            this.Text = "Eþya Seç";
            this.ResumeLayout(false);

            //// Formun simgesini ayarla
            //byte[] iconBytes = Properties.Resources.KI; // Simgenizin byte[] formatýnda olduðunu varsayýyoruz
            //using (var stream = new MemoryStream(iconBytes))
            //{
            //    this.Icon = new Icon(stream);
            //}
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            SelectedItem = itemListBox.SelectedItem?.ToString();
        }
    }

}
