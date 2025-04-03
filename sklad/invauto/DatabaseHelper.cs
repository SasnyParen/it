using System;
using System.Threading.Tasks;
using Npgsql;

namespace invauto
{
    public static class DatabaseHelper
    {
        private static readonly string ConnectionString = "Host=your_host;Port=5432;Username=your_user;Password=your_password;Database=your_db";

        // Асинхронный метод для подключения к базе данных
        public static async Task<bool> TryConnectAsync()
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();  // Асинхронное подключение
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Асинхронный метод для верификации пользователя
        public static async Task<bool> ValidateUserAsync(string username, string password)
        {
            try
            {
                using (var connection = new NpgsqlConnection(ConnectionString))
                {
                    await connection.OpenAsync();  // Асинхронное подключение

                    using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM users WHERE username = @username AND password = crypt(@password, password)", connection))
                    {
                        cmd.Parameters.AddWithValue("username", username);
                        cmd.Parameters.AddWithValue("password", password);

                        // Асинхронное выполнение запроса
                        int userCount = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                        return userCount > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при верификации пользователя: " + ex.Message);
            }
        }
    }
}
