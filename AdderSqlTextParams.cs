using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ArtLibrary.Sql
{
    public class AdderSqlTextParams
    {
        public void Add(SqlCommand cmd, List<string> columnNames, List<Control> dataControls)
        {
            foreach (var element in columnNames.Zip(dataControls, Tuple.Create))
            {
                Add( cmd, element.Item1, element.Item2);
            }
        }

        public void Add(SqlCommand cmd, string columnName, Control control)
        {
            cmd.Parameters.AddWithValue(columnName, control.Text);
        }

        public void Add(SqlCommand cmd, string columnName, List<string> value)
        {
            foreach(var element in value)
            {
                cmd.Parameters.AddWithValue(columnName, element);
            }
        }

        public void Add(SqlCommand cmd, List<string> columnNames, List<string> values)
        {
            foreach (var element in columnNames.Zip(values, Tuple.Create))
            {
                cmd.Parameters.AddWithValue(element.Item1, element.Item2);
            }
        }
    }
}
