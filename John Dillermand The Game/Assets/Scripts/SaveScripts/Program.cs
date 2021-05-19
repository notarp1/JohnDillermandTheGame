using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            databaseController dbController = new databaseController();

            UserDTO user = new UserDTO();
            user.setUserName("johnjohn").setPassword("123");
            dbController.FetchUserInvertory(1); 
           
        }

        
    }
}