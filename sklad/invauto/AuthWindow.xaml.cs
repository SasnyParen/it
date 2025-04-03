using System;
using System.Threading.Tasks;
using System.Windows;

namespace invauto
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        // Обработчик для кнопки "Войти"
        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Показываем индикатор загрузки или сообщение о процессе
            StatusTextBlock.Visibility = Visibility.Visible;
            StatusTextBlock.Text = "Вход в систему...";

            // Ожидаем выполнения асинхронного метода
            bool isAuthenticated = await AuthenticateUserAsync(username, password);

            // Скрываем индикатор загрузки
            StatusTextBlock.Visibility = Visibility.Collapsed;

            if (isAuthenticated)
            {
                MessageBox.Show("Добро пожаловать!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                // Открываем основное окно приложения
                // MainWindow mainWindow = new MainWindow();
                // mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверные учетные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Асинхронный метод для проверки пользователя в базе данных
        private async Task<bool> AuthenticateUserAsync(string username, string password)
        {
            try
            {
                // Проверяем соединение с базой данных
                if (!await DatabaseHelper.TryConnectAsync())
                {
                    MessageBox.Show("Отсутствует соединение с сервером.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

                // Проверяем учетные данные в базе данных
                bool isValid = await DatabaseHelper.ValidateUserAsync(username, password);
                return isValid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        // Обработчик для кнопки "Закрыть"
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
