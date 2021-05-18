using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : Item
{
    private string seedName;
    private int amountLeft;
    private itemTypes type;


    public Seed(string name, int amount, itemTypes type)
    {
        this.seedName = name;
        this.amountLeft = amount;
        this.type = type;

    }

    public void setItemType(itemTypes type)
    {
        this.type = type;
    }

    public itemTypes getItemType()
    {
        return this.type;
    }

    public void setItemAmount(int itemAmount)
    {
        this.amountLeft = itemAmount;
    }

    public int getItemAmount()
    {
        return this.amountLeft;
    }

    public void setItemName(string itemName)
    {
        this.seedName = itemName;
    }

    public string getItemName()
    {
        return this.seedName;
    }

    public void useItem(Item item, Animator anim)
    {
        PlayerInventory inven = GameObject.Find("Player").GetComponent<PlayerInventory>();
        Item[] items = inven.getItems();
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                if (items[i].getItemName().Equals(item.getItemName()))
                {
                    items[i].setItemAmount(item.getItemAmount() - 1);
                    break;
                }
            }
        }
        inven.setItems(items);
    }

}
