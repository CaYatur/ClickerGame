using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickerGame
{
    public partial class CheckForUpdates : Form
    {
        private readonly string currentVersion = "1.0.0"; // Mevcut program sürümünüz
        private readonly string mongoConnectionString = "YOUR_MONGODB_URI"; // MongoDB bağlantı dizesi
        private readonly string databaseName = "ClickerGameUpdate"; // Veritabanı adı
        private readonly string collectionName = "ApplicationVersions"; // Koleksiyon adı

        public CheckForUpdates()
        {
            InitializeComponent();
            CheckForUpdate();
        }

        private void CheckForUpdate()
        {
            var client = new MongoClient(mongoConnectionString);
            var database = client.GetDatabase(databaseName);
            var collection = database.GetCollection<BsonDocument>(collectionName);

            // MongoDB'deki sürüm verisini kontrol et
            var appVersion = collection.Find(Builders<BsonDocument>.Filter.Eq("appName", "ClickerGame")).FirstOrDefault();

            if (appVersion == null)
            {
                // Eğer MongoDB'de sürüm verisi yoksa, yeni bir sürüm oluştur
                var newVersionDocument = new BsonDocument
                {
                    { "appName", "ClickerGame" },
                    { "version", currentVersion },
                    { "downloadLink", "https://example.com/download" } // İndirme linki
                };
                collection.InsertOne(newVersionDocument);
            }
            else
            {
                var latestVersion = appVersion["version"].AsString;
                var downloadLink = appVersion["downloadLink"].AsString;

                if (IsNewVersionAvailable(currentVersion, latestVersion))
                {
                    // Yeni sürüm var, kullanıcıya uyarı göster
                    var result = MessageBox.Show($"Yeni bir sürüm mevcut: {latestVersion}\nMevcut sürüm: {currentVersion}\nGüncellemek ister misiniz?",
                              "Güncelleme Mevcut", MessageBoxButtons.YesNo);


                    if (result == DialogResult.Yes)
                    {
                        // Kullanıcı güncellemek istiyorsa indirme sayfasını aç
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = downloadLink,
                            UseShellExecute = true
                        });
                        Environment.Exit(1);
                    }
                    else
                    {
                        // Kullanıcı güncellemek istemiyorsa programı kapat
                        //Application.Exit();
                        Environment.Exit(1);
                    }
                }
                else
                {
                    // Form1'i aç ve bu formu kapat
                    this.Hide(); // Ana formu gizle
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                    Environment.Exit(1);
                    //this.Close(); // Bu formu tamamen kapat
                }
            }
        }

        private bool IsNewVersionAvailable(string currentVersion, string latestVersion)
        {
            Version current = new Version(currentVersion);
            Version latest = new Version(latestVersion);
            return latest > current; // Eğer MongoDB'deki sürüm daha büyükse güncelleme var demektir
        }

    }
}
