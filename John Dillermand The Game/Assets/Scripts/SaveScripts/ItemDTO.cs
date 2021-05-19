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
        public ItemDTO(string name, int amount, int id,int nr)
        {
            this.name = name;
            this.amount = amount;
            this.id = id;
            this.nr = nr; 
        }
        public int getAmount() { return amount; }
        public string getName() { return name; }
        public int getID() { return id; }
        public int setNr(int nr) { this.nr = nr; }
        public int getNr() { return this.nr }
        public string ToString()
        {
            return "name: " + name + " amount: " + amount;
        }
    }
    
}
