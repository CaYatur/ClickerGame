using System;
using System.IO;
using System.Windows.Forms;

namespace ClickerGame
{
    public partial class LoginForm : Form
    {
        private AuthService authService;
        private Form1 mainForm;
        private string tempFilePath = Path.Combine(Path.GetTempPath(), "loginData.txt");

        public LoginForm(AuthService authService, Form1 mainForm)
        {
            InitializeComponent();
            this.authService = authService;
            this.mainForm = mainForm;
            LoadSavedLoginData();
            this.FormClosing += LoginForm_FormClosing;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            User user = authService.Login(username, password);
            if (user != null)
            {
                Hide();
                mainForm.SetLoggedInUser(user);
                SaveLoginData(username, password); // Giriş verilerini kaydet
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (authService.Register(username, password))
            {
                MessageBox.Show("Başarıyla kayıt olundu! Şimdi giriş yapabilirsiniz.", "Kayıt Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bu kullanıcı adı zaten mevcut.", "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveLoginData(string username, string password)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(tempFilePath))
                {
                    writer.WriteLine(username);
                    writer.WriteLine(password);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Giriş verileri kaydedilirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSavedLoginData()
        {
            try
            {
                if (File.Exists(tempFilePath))
                {
                    using (StreamReader reader = new StreamReader(tempFilePath))
                    {
                        string username = reader.ReadLine();
                        string password = reader.ReadLine();
                        if (username != null && password != null)
                        {
                            txtUsername.Text = username;
                            txtPassword.Text = password;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Giriş verileri yüklenirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Eğer kullanıcı başarılı bir şekilde giriş yapmamışsa geçici dosyayı sil
            if (mainForm.GetLoggedInUser() == null)
            {
                Environment.Exit(0);
            }
        }
    }
}
