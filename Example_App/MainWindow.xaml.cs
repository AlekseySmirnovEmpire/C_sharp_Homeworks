using Microsoft.Win32;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Example_App
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        AppContext db;

        private void loadAllUsers()
        {
            List<User> users = db.Users.ToList();
            listOfUsers.ItemsSource = users;
        }

        public MainWindow()
        {
            InitializeComponent();

            db = new AppContext();

            loadAllUsers();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void exitProgram_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveNewFile_Click(object sender, RoutedEventArgs e)
        {
            saveFileFunc();
        }

        private void openNewFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            bool? result = ofd.ShowDialog();

            if(result != false)
            { 
                Stream myStream;
                if ((myStream = ofd.OpenFile()) != null)
                {
                    string fileName = ofd.FileName;
                    string fileText = File.ReadAllText(fileName);

                    textBox.Text = fileText;
                }
            }            
        }

        private void createNewFile_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text == "")
                saveFileFunc();

            textBox.Text = "";
        }

        private void timesNewRomanFont_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontFamily = new FontFamily("Times New Roman");

            verdanaFont.IsChecked = false;
        }

        private void verdanaFont_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontFamily = new FontFamily("Verdana");

            timesNewRomanFont.IsChecked = false;
        }

        private void selectFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = selectFontSize.SelectedItem.ToString();
            fontSize = fontSize.Substring(fontSize.Length - 2);

            switch(fontSize)
            {
                case "10":
                    textBox.FontSize = 10;
                    break;
                case "14":
                    textBox.FontSize = 14;
                    break;
                case "16":
                    textBox.FontSize = 16;
                    break;
                case "20":
                    textBox.FontSize = 20;
                    break;
                case "24":
                    textBox.FontSize = 24;
                    break;
                case "32":
                    textBox.FontSize = 32;
                    break;
                case "48":
                    textBox.FontSize = 48;
                    break;
            }
        }

        private void saveFileFunc()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            bool? result = sfd.ShowDialog();

            if(result != false)
            {
                using (Stream s = File.Open(sfd.FileName, FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(s))
                    {
                        sw.Write(textBox.Text);
                    }
                }
            }            
        }

        private void regBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginField.Text;
            string password = passField.Password;

            if(login.Length < 4)
            {
                loginField.Background = Brushes.Red;
                loginField.ToolTip = "Некорректно заполнено!";
            }
            else if(password.Length < 4)
            {
                passField.Background = Brushes.Red;
                passField.ToolTip = "Некорректный пароль!";
            }
            else
            {
                passField.Background = Brushes.Transparent;
                loginField.Background = Brushes.Transparent;

                User user = null;
                user = db.Users.Where(el => el.Login == login && el.Password == password).FirstOrDefault();

                if(user != null)
                {
                    MessageBox.Show("Пользователь авторизован!");
                }
                else
                {
                    user = db.Users.Where(el => el.Login == login).FirstOrDefault();

                    if (user != null)
                        MessageBox.Show("Логин занят!");
                    else
                    {
                        user = new User(login, password);
                        db.Users.Add(user);
                        db.SaveChanges();

                        MessageBox.Show("Пользователь добавлен!");

                        loadAllUsers();
                    }
                }           
            }
        }
    }
}
