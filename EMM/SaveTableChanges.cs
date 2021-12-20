using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace EMM
{
    internal class SaveTableChanges
    {
        public SaveTableChanges()
        {
        }
        public String saveAllChanges(DataTable dataTable, String connectionInstance, String tableName)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(connectionInstance);
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("select * from engine_construction." + tableName, mySqlConnection);
            MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);
            mySqlDataAdapter.UpdateCommand = mySqlCommandBuilder.GetUpdateCommand();
            mySqlDataAdapter.InsertCommand = mySqlCommandBuilder.GetInsertCommand();
            mySqlDataAdapter.DeleteCommand = mySqlCommandBuilder.GetDeleteCommand();
            try
            {
                mySqlDataAdapter.Update(dataTable);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return null;
        }
    }
}