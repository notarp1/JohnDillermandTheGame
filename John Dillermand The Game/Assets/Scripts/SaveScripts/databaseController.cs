using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class databaseController
    {
        DatabaseCon dataCon = new DatabaseCon();
        public async void FetchUserID(UserDTO dto)
        {
            
          
            var getUserTask =  dataCon.GetUser(dto);
            
       
            var databaseTask = new List<Task> { getUserTask };

            Task finishedTask = await Task.WhenAny(databaseTask);
            if (finishedTask == getUserTask)
            {
                //Ændre i global variable, eller gør hvad der skal med idet
                Console.WriteLine(((Task<int>)finishedTask).Result);
            }

        }

        public async void FetchUserInvertory(int userID)
        {
            var getUserTask = dataCon.GetInvertory(userID);

          
            var databaseTask = new List<Task> { getUserTask };

            Task finishedTask = await Task.WhenAny(databaseTask);
            if (finishedTask == getUserTask)
            {
                //Ændre i global variable, eller gør hvad der skal med idet
                foreach (ItemDTO dto in ((Task<List<ItemDTO>>)finishedTask).Result)
                {
                    Console.WriteLine(dto.ToString());
                }
            }
        }
        public async void UpdateInvertory(List<ItemDTO> invitory, UserDTO user)
        {
            List<Task> Task = new List<Task>();
            foreach(ItemDTO item in invitory)
            {
                dataCon.UpdateItem(item, user); 
            }

            
        }
    }
}
