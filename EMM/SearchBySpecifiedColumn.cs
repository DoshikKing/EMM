using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace EMM
{
    internal class SearchBySpecifiedColumn
    {
        public DataTable search(String columName, String connectionInstance, String tableName, String field)
        {
            DataTable dataTable = new DataTable();
            String query = "select * from engine." + tableName + " where " + columName + " like '" + field + "%'";
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