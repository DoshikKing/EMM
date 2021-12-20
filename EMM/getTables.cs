using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace EMM
{
	public class getTables
	{
		public getTables()
		{
		}
		public List<string> getAllTables(String connectionInstance, UserDTO userDTO)
        {
			List<string> data = new List<string>();
			String query = "show tables from engine_construction";
			MySqlConnection mySqlConnection = new MySqlConnection(connectionInstance);
            try
            {
				MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
				MySqlDataReader mySqlDataReader;
				mySqlConnection.Open();
				mySqlDataReader = mySqlCommand.ExecuteReader();
				while (mySqlDataReader.Read())
				{
                    if (!userDTO.getRole().Equals("admin"))
                    {
						if (!userDTO.getRole().Equals("direc"))
						{
							if (mySqlDataReader.GetString(0).Equals("employees") || mySqlDataReader.GetString(0).Equals("engine_parts") || mySqlDataReader.GetString(0).Equals("list_of_constructed_engines"))
							{
								data.Add(mySqlDataReader.GetString(0));
							}
						}
					}
                    else
                    {
						if (!mySqlDataReader.GetString(0).Equals("users"))
						{
							data.Add(mySqlDataReader.GetString(0));
						}
					}
				}
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
			return data;
		}
	}
}
