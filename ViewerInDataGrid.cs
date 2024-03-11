using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ArtLibrary.Sql
{
    public class ViewerInDataGrid
    {
        public void ClearTable(DataGridView dataGrid, string connectionStr, string tableName)
        {
            using (var connection = new SqlConnection(connectionStr))
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = $"TRUNCATE table [{tableName}]";
                dataGrid.DataSource = null;
                dataGrid.Rows.Clear();
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteSelectedRows(DataGridView dataGrid, string connectionStr, string tableName)
        {
            using (var connection = new SqlConnection(connectionStr))
            using (var cmd = connection.CreateCommand())
            {
                connection.Open();
                foreach (DataGridViewRow row in dataGrid.SelectedRows)
                {
                    cmd.CommandText = $"DELETE [{tableName}] WHERE Id = {row.Cells["Id"].Value}";
                    dataGrid.Rows.Remove(row);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ViewRequest(DataGridView dataGrid, string connectionStr, string command)
        {
            using (var connection = new SqlConnection(connectionStr))
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = command;

                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd.CommandText, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dataGrid.DataSource = ds.Tables[0];
            }
        }
    }
}
