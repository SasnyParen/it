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
using System.Windows.Shapes;

using System;
using System.Windows;

namespace invauto
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработчик для кнопки "Профиль"
        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            // Открытие или обновление контента для профиля
            //MainContent.Content = new ProfilePage(); // Пример перехода на страницу профиля
        }

        // Обработчик для кнопки "Просмотр новостей"
        private void NewsButton_Click(object sender, RoutedEventArgs e)
        {
            // Открытие или обновление контента для новостей
            //MainContent.Content = new NewsPage(); // Пример перехода на страницу новостей
        }

        // Обработчик для кнопки "Управление мероприятиями"
        private void EventsButton_Click(object sender, RoutedEventArgs e)
        {
            // Открытие или обновление контента для управления мероприятиями
            //MainContent.Content = new EventsPage(); // Пример перехода на страницу мероприятий
        }

        // Обработчик для кнопки "Добавить задачу"
        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            // Открытие или обновление контента для добавления задач
            //MainContent.Content = new AddTaskPage(); // Пример перехода на страницу добавления задачи
        }

        // Обработчик для кнопки "Регистрация на мероприятие"
        private void RegisterEventButton_Click(object sender, RoutedEventArgs e)
        {
            // Открытие или обновление контента для регистрации на мероприятие
            //MainContent.Content = new RegisterEventPage(); // Пример перехода на страницу регистрации
        }

        // Обработчик для кнопки "Экстренная связь"
        private void EmergencyButton_Click(object sender, RoutedEventArgs e)
        {
            // Открытие или обновление контента для экстренной связи
           // MainContent.Content = new EmergencyPage(); // Пример перехода на страницу экстренной связи
        }

        // Обработчик для кнопки "Выход"
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Завершение работы приложения
            Application.Current.Shutdown();
        }
    }
}
