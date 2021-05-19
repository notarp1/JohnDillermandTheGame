using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class UserDTO
    {
        String username;
        String password;
        int ID;
       
        public UserDTO setUserName(String username)
        {
            this.username = username;
            return this; 
        }
        public UserDTO setPassword(String password)
        {
            this.password = password;
            return this;
        }
        public UserDTO setID(int ID)
        {
            this.ID = ID;
            return this;
        }
      
        public string getUsername() { return username; }
        public string getPassword() { return password; }
        public int getID() { return this.ID; }
       


    }
}
