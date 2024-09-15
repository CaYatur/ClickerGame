using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace ClickerGame
{
    public partial class MarketForm : Form
    {
        private Database database;
        private AuthService authService;
        private User loggedInUser;


        public MarketForm(AuthService authService, User user, Database database)
        {
            InitializeComponent();
            this.authService = authService;
            this.loggedInUser = user;
            this.database = database; // Assign database to a local field
            LoadMarketItems();
            LoadUserInventory();
        }


        private void LoadMarketItems()
        {
            var marketItems = authService.GetMarketItems();
            marketListBox.DataSource = marketItems;
            marketListBox.DisplayMember = "Display";
            marketListBox.ValueMember = "Price";
        }

        //private void LoadUserInventory()
        //{
        //    var inventoryItems = authService.GetUserInventory(loggedInUser.Username);
        //    inventoryListBox.DataSource = inventoryItems;
        //    inventoryListBox.DisplayMember = "Name";
        //    inventoryListBox.ValueMember = "Count";
        //}
        private void LoadUserInventory()
        {
            inventoryListBox.Items.Clear();

            var inventory = authService.GetUserInventory(loggedInUser.Username);

            foreach (var item in inventory)
            {
                string displayText = $"{item.Name} ({item.Count})";
                var listBoxItem = new ListBoxItem
                {
                    Text = displayText,
                    Tag = item
                };
                inventoryListBox.Items.Add(listBoxItem);
            }
        }

        public class ListBoxItem
        {
            public string Text { get; set; }
            public object Tag { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }


        private void marketListBox_DoubleClick(object sender, EventArgs e)
        {
            var selectedItem = marketListBox.SelectedItem as MarketItem;
            if (selectedItem != null)
            {
                // Kullanıcının kendi ürününü satın almaya çalışıp çalışmadığını kontrol et
                if (selectedItem.Seller == loggedInUser.Username)
                {
                    MessageBox.Show("Kendi ürünlerinizi satın alamazsınız.", "Satın Alma Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = MessageBox.Show($"Bu ürünü satın almak istiyor musunuz: {selectedItem.Name} ({selectedItem.Price} puan)?", "Satın Alma Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (loggedInUser.Points >= selectedItem.Price)
                    {
                        // Kullanıcı puanlarını güncelle
                        loggedInUser.Points -= selectedItem.Price;
                        authService.UpdateUserPoints(loggedInUser.Username, loggedInUser.Points);

                        // Kullanıcının envanterine ürünü ekle
                        authService.AddOrUpdateItemInInventory(loggedInUser.Username, selectedItem.Name, 1);

                        // Satıcının puanlarını güncelle
                        var seller = authService.GetUserByUsername(selectedItem.Seller);
                        if (seller != null)
                        {
                            seller.Points += selectedItem.Price;
                            authService.UpdateUserPoints(seller.Username, seller.Points);
                        }

                        // Pazar ürünlerini güncelle
                        authService.RemoveMarketItem(selectedItem);

                        // Envanteri ve pazar ürünlerini güncelle
                        LoadUserInventory();
                        LoadMarketItems();

                        // Satıcıya bildirim gönder
                        authService.AddNotification(selectedItem.Seller, $"{selectedItem.Name} ürünü {loggedInUser.Username} tarafından satın alındı ve {selectedItem.Price} puan eklendi.");

                        MessageBox.Show($"Ürün başarıyla satın alındı! Envanterinize eklendi.", "Satın Alma Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Yeterli puanınız yok.", "Satın Alma Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }




        private void removeButton_Click(object sender, EventArgs e)
        {
            if (marketListBox.SelectedItem is MarketItem selectedItem)
            {
                if (selectedItem.Seller == loggedInUser.Username)
                {
                    var result = MessageBox.Show($"Bu ürünü pazardan kaldırmak istiyor musunuz: {selectedItem.Name}?", "Kaldırma Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Ürünü pazardan kaldır
                        authService.RemoveMarketItem(selectedItem);

                        // Kullanıcının envanterine ürünü geri ekle
                        authService.AddOrUpdateItemInInventory(loggedInUser.Username, selectedItem.Name);

                        // Envanteri ve pazar ürünlerini güncelle
                        LoadUserInventory();
                        LoadMarketItems();

                        MessageBox.Show("Ürün başarıyla pazardan kaldırıldı.", "Kaldırma Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Bu ürünü yalnızca sahibi kaldırabilir.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen kaldırmak istediğiniz ürünü seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //private void sellButton_Click(object sender, EventArgs e)
        //{
        //    if (inventoryListBox.SelectedItem is Item selectedItem)
        //    {
        //        string priceInput = Microsoft.VisualBasic.Interaction.InputBox("Bu ürünü hangi fiyattan satmak istiyorsunuz?", "Ürün Fiyatı", "0");
        //        if (int.TryParse(priceInput, out int price) && price > 0)
        //        {
        //            var result = MessageBox.Show($"Bu ürünü {price} puana satmak istiyor musunuz: {selectedItem.Name}?", "Satış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //            if (result == DialogResult.Yes)
        //            {
        //                // Kullanıcının envanterinden ürünü kaldır
        //                authService.RemoveItemFromInventory(loggedInUser.Username, selectedItem.Name);

        //                // Ürünü pazara ekle
        //                authService.AddMarketItem(new MarketItem
        //                {
        //                    Name = selectedItem.Name,
        //                    Price = price,
        //                    Seller = loggedInUser.Username
        //                });

        //                // Envanteri ve pazar ürünlerini güncelle
        //                LoadUserInventory();
        //                LoadMarketItems();

        //                MessageBox.Show("Ürün başarıyla pazara eklendi!", "Satış Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Geçersiz fiyat girdiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Lütfen satış yapmak istediğiniz ürünü seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void sellButton_Click(object sender, EventArgs e)
        {
            if (inventoryListBox.SelectedItem is ListBoxItem selectedListBoxItem &&
                selectedListBoxItem.Tag is Item selectedItem)
            {
                // Kullanıcının envanterindeki ürünü kontrol et
                var itemInInventory = authService.GetUserInventory(loggedInUser.Username)
                    .FirstOrDefault(i => i.Name == selectedItem.Name);

                if (itemInInventory != null)
                {
                    // Kullanıcının ürünün miktarını belirle
                    int currentCount = itemInInventory.Count;

                    // Fiyat girişi almak için kullanıcıya sor
                    string priceInput = Microsoft.VisualBasic.Interaction.InputBox("Bu ürünü hangi fiyattan satmak istiyorsunuz?", "Ürün Fiyatı", "0");

                    if (int.TryParse(priceInput, out int price) && price > 0)
                    {
                        var result = MessageBox.Show($"Bu ürünü {price} puana satmak istiyor musunuz: {selectedItem.Name}?", "Satış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            // Ürün pazara eklenmeden önce kontrol et
                            // Pazardaki satış yapan kişinin kendisi olup olmadığını kontrol et
                            //if (authService.IsUserSeller(loggedInUser.Username, selectedItem.Name))
                            //{
                            //    MessageBox.Show("Aynı üründen zaten pazardayken tekrar koyamazsın!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    return;
                            //}

                            // Kullanıcının envanterinden ürünü miktarına göre azalt
                            if (currentCount > 1)
                            {
                                authService.RemoveItemFromInventory(loggedInUser.Username, selectedItem.Name, 1);
                            }
                            else
                            {
                                authService.RemoveItemFromInventory(loggedInUser.Username, selectedItem.Name, 1);
                            }

                            // Ürünü pazara ekle
                            authService.AddMarketItem(new MarketItem
                            {
                                Name = selectedItem.Name,
                                Price = price,
                                Seller = loggedInUser.Username
                            });

                            // Envanteri ve pazar ürünlerini güncelle
                            LoadUserInventory();
                            LoadMarketItems();

                            MessageBox.Show("Ürün başarıyla pazara eklendi!", "Satış Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz fiyat girdiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Seçilen ürün envanterinizde bulunmuyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lütfen satış yapmak istediğiniz ürünü seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }








        private async void MarketForm_Load(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                // Properties.Resources.Click'in bir byte[] dizisi olduğunu varsayıyoruz
                byte[] soundData = Properties.Resources.OpenMenu;

                // Byte[]'ı MemoryStream'e dönüştür
                using (MemoryStream stream = new MemoryStream(soundData))
                {
                    using (SoundPlayer player = new SoundPlayer(stream))
                    {
                        player.Play(); // Ses dosyasını oynat
                    }
                }
            });
        }
    }




}
