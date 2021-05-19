using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class ItemDTO
    {
        string name;
        int amount;
        int id;
        int nr;
        public ItemDTO(string name, int amount, int id)
        {
            this.name = name;
            this.amount = amount;
            this.id = id;
        }
        public int getAmount() { return amount; }
        public string getName() { return name; }
        public int getID() { return id; }

        public int getNr()
        {
            return amount;
        }
        public string ToString()
        {
            return "name: " + name + " amount: " + amount;
        }
    }
    
}
