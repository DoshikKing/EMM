using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace EMM
{
    public class LoadTable
    {
        public LoadTable()
        {
        }
        public DataTable loadSelectedTable(String tableName, String connectionInstance)
        {
            DataTable dataTable = new DataTable();
            String query = "select * from engine_construction." + tableName;
            MySqlConnection mySqlConnection = new MySqlConnection(connectionInstance);
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                mySqlCommand.CommandType = CommandType.Text;
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);
                mySqlConnection.Open();
                mySqlDataAdapter.SelectCommand = mySqlCommand;
                mySqlDataAdapter.Fill(dataTable);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (mySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }
            return dataTable;
        }
    }
}
