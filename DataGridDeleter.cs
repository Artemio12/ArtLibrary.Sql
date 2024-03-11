using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtLibrary.Sql
{
    public class DataGridDeleter
    {
        public void DeleteRows(DataGridView dataGrid, string tableName, string connectionStr)
        {
            using (var connection = new SqlConnection(connectionStr))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                foreach (DataGridViewRow row in dataGrid.SelectedRows)
                {
                    cmd.CommandText = $"DELETE [{tableName}] WHERE Id =  {row.Cells["Id"].Value}";
                    dataGrid.Rows.Remove(row);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
