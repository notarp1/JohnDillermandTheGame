using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ConsoleApp1
{
    class DatabaseCon
    {
        private string password;
        private string username;
        private string server;
        private string database;

        MySqlConnection conn;



        public DatabaseCon()
        {
            server = "localhost";
            database = "johnd";
            username = "root";
            password = "784512963a";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "USERNAME=" + username + ";" + "PASSWORD=" + password + ";";
            conn = new MySqlConnection(connectionString);

        }


        public void CreateDataBase()
        {


            String query = "CREATE DATABASE `johnd` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */ IF NOT EXIST johnd"; ;
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = "CREATE TABLE invertory (UserID int NOT NULL,ItemID int NOT NULL,Amount int DEFAULT NULL,PRIMARY KEY(`UserID`,`ItemID`)) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci IF NOT EXIST invertory;";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

           query = "CREATE TABLE `items` (`ItemID` int NOT NULL,`Name` varchar(45) DEFAULT NULL,`Text` varchar(45) DEFAULT NULL,PRIMARY KEY(`ItemID`),UNIQUE KEY `ID_Items_UNIQUE` (`ItemID`)) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci IF NOT EXIST items;";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            query = "CREATE TABLE `users` (`ID` int NOT NULL AUTO_INCREMENT,`username` char(64) NOT NULL,`password` char(64) NOT NULL,PRIMARY KEY(`ID`)) ENGINE = InnoDB AUTO_INCREMENT = 2 DEFAULT CHARSET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci NOT EXIST users;";
            cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();


        }


        public async Task<Boolean> Open()
        {
            try
            {
                await conn.OpenAsync();
                return true;
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        return false;


                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        return false;

                    default:
                        Console.WriteLine("Error in data Open"+e);
                        return false;
                }

            }
        }

        public void Close()
        {
            try
            {
                conn.CloseAsync();
                
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }

        public async void UpdateItem(ItemDTO item,UserDTO user)
        {
            if (await Open())
            {
                String query = "INSERT INTO items (UserID,ItemID,Amount) VALUES(@UserID, @ItemID, @nr) ON DUPLICATE KEY UPDATE Amount =@nr;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserID", user.getID());
                cmd.Parameters.AddWithValue("@ItemID", item.getID());
                cmd.Parameters.AddWithValue("@ItemID", item.getNr());
                cmd.ExecuteNonQuery();
            }
            Close();
        }


        public async void createUser(UserDTO dto)
        {
            if (await Open())
            {
                String query = "INSERT INTO users(username,password) VALUES (@username,@password)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", dto.getUsername());
                cmd.Parameters.AddWithValue("@password", dto.getPassword());
                cmd.ExecuteNonQuery();
            }
            Close();
        }


        public async void UpdateUser(UserDTO dto)
        {
            if(await Open())
            {
                String query = "UPDATE users SET username=@username,password=@password WHERE ID= @userID;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userID", dto.getID());
                cmd.Parameters.AddWithValue("@username", dto.getUsername());
                cmd.Parameters.AddWithValue("@password", dto.getPassword());
                cmd.ExecuteNonQuery();
            }
            Close(); 
        }



        public async Task<List<ItemDTO>> GetInvertory(int userID)
        {
            List<ItemDTO> res = new List<ItemDTO>(); 
            if(await Open())
            {
                String query = "SELECT Name, Amount,Text FROM invertory INNER JOIN items on invertory.ItemID = items.ItemID WHERE invertory.UserID = @userID;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userID", userID);
                MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
                while (reader.Read())
                {
                     res.Add(new ItemDTO(reader["name"]+"",Int32.Parse(reader["amount"]+""), Int32.Parse(reader["ItemID"] + "")));
                }
            }
            Close();
            return res; 

        }
        

   
        public async Task<int> GetUser(UserDTO dto)
        {
            int res = -1;

            if (await Open())
            {
                String query = "SELECT ID FROM users WHERE username=@username AND password = @password";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", dto.getUsername());
                cmd.Parameters.AddWithValue("@password", dto.getPassword());

                MySqlDataReader reader = (MySqlDataReader)await cmd.ExecuteReaderAsync();
                while (reader.Read())
                {
                    res = Int32.Parse(reader["ID"] + "");

                }
            }
            Close();
            return res; 
        }


    }
}