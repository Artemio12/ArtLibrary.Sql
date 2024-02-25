using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace ArtLibrary.Sql
{
    public class Checker
    {
        private string checkedConnectionString;
        public string CheckedConnectionString => checkedConnectionString;

        public void CheckConnection(string connectionString)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        checkedConnectionString = connectionString;
                        MessageBox.Show("Подключение к базе данных успешно установлено");
                    }
                    else
                    {
                        MessageBox.Show("Не получилось установить подключение к базе данных. Проверьте корректность строки подключения");
                    }
                        
                }
            }
            catch
            {
                MessageBox.Show("Строка подключения не введена или не соответствует формату. Проверьте корректность строки подключения");
            }
        }

        public void CheckFolderPath(string path)
        {
            if (!Directory.Exists(@path))
            { 
                MessageBox.Show("Папки не существует. Проверьте корректность пути"); 
            }
        }
    }
}
