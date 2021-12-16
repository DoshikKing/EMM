using System;
using MySql.Data.MySqlClient;

namespace EMM
{
    class Login
    {
        public Login()
        {
        }
        public UserDTO LoginIntoSystem(UserDTO userDTO, String connectionInstance, String login, String password)
        {
            userDTO = new UserDTO();
            String query = "select * from engine.users where login=@login and password=@password";
            MySqlConnection mySqlConnection = new MySqlConnection(connectionInstance);
            try
            {
                MySqlCommand mySqlCommand = new MySqlCommand(query, mySqlConnection);
                mySqlCommand.Parameters.AddWithValue("@login", login);
                mySqlCommand.Parameters.AddWithValue("@password", password);
                MySqlDataReader mySqlDataReader;
                mySqlConnection.Open();
                mySqlCommand.Prepare();
                mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    userDTO = new UserDTO(mySqlDataReader.GetString("id_users"), mySqlDataReader.GetString("role"));
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if(mySqlConnection.State == System.Data.ConnectionState.Open)
                {
                    mySqlConnection.Close();
                }
            }
            return userDTO;
        }
    }

}
