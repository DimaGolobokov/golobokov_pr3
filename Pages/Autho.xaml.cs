using golobokov_pr3.Services;
using System;
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
using golobokov_pr3.Models;
using System.Windows.Threading;

namespace golobokov_pr3.Pages
{
    /// <summary>
    /// Interaction logic for Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        private int click;
        private DispatcherTimer lockTimer;
        private int lockTimeRemaining;

        public Autho()
        {
            InitializeComponent();
            click = 0;

            lockTimer = new DispatcherTimer();
            lockTimer.Interval = TimeSpan.FromSeconds(1);
            lockTimer.Tick += LockTimer_Tick;
        }

        private void btnEnterGuest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Client(null, null));
        }

        private void GenerateCapctcha()
        {
            tbCaptcha.Visibility = Visibility.Visible;
            tblCaptcha.Visibility = Visibility.Visible;

            string capctchaText = CaptchaGenerator.GenerateCaptchaText(6);
            tblCaptcha.Text = capctchaText;
            tblCaptcha.TextDecorations = TextDecorations.Strikethrough;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (lockTimeRemaining > 0)
            {
                MessageBox.Show("Пожалуйста, подождите завершения блокировки.");
                return;
            }

            click += 1;
            string login = tbLogin.Text.Trim();
            string password = tbPassword.Text.Trim();

            string hashedPassword = Hash.HashPassword(password);
            password = hashedPassword;

            var db = Helper.GetContext();

            var user = db.Auth.Where(x => x.Username == login && x.Password == password).FirstOrDefault();
            if (user != null && (click == 1 || (click > 1 && tbCaptcha.Text == tblCaptcha.Text)))
            {
                MessageBox.Show("Вы вошли под: " + user.Roles.RoleName.ToString());
                LoadPage(user.Roles.RoleName.ToString(), user);
            }
            else
            {
                MessageBox.Show("Вы ввели логин или пароль неверно!");
                if (click >= 3)
                {
                    StartLockTimer();
                }
                else
                {
                    GenerateCapctcha();
                    tbPassword.Text = "";
                }
            }
        }

        private void StartLockTimer()
        {
            lockTimeRemaining = 10;
            tbTimer.Text = $"Окно заблокировано на {lockTimeRemaining} секунд.";
            tbTimer.Visibility = Visibility.Visible;

            Controls(false);

            lockTimer.Start();
        }

        private void LockTimer_Tick(object sender, EventArgs e)
        {
            lockTimeRemaining--;
            if (lockTimeRemaining > 0)
            {
                tbTimer.Text = $"Окно заблокировано на {lockTimeRemaining} секунд.";
            }
            else
            {
                lockTimer.Stop();
                tbTimer.Visibility = Visibility.Collapsed;

                Controls(true);
                click = 0;
            }
        }

        private void Controls(bool isEnabled)
        {
            tbLogin.IsEnabled = isEnabled;
            tbPassword.IsEnabled = isEnabled;
            tbCaptcha.IsEnabled = isEnabled;
            btnEnter.IsEnabled = isEnabled;
            btnEnterGuest.IsEnabled = isEnabled;
        }

        private void LoadPage(string _role, Auth user)
        {
            click = 0;
            switch (_role)
            {
                case "Клиент":
                    NavigationService.Navigate(new Client(user, _role));
                    break;
                case "Сотрудник":
                    NavigationService.Navigate(new Employee(user, _role));
                    break;
            }
        }

    }
}
