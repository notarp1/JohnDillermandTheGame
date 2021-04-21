using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : Item
{
    private string name;
    private itemTypes type;
    private int itemAmount, staminaAmount;

    public Tool(string name, int amount, itemTypes type, int staminaAmount)
    {
        this.name = name;
        this.itemAmount = amount;
        this.type = type;
        this.staminaAmount = staminaAmount;
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
        this.itemAmount = itemAmount;
    }

    public int getItemAmount()
    {
        return this.itemAmount;
    }

    public void setItemName(string itemName)
    {
        this.name = itemName;
    }

    public string getItemName()
    {
        return this.name;
    }

    public void setStaminaAmount(int amount)
    {
        this.staminaAmount = amount;
    }

    public int getStaminaAmount()
    {
        return this.staminaAmount;
    }


    public void useItem(Item item, Animator anim)
    {
        if (GameObject.Find("Player").GetComponent<PlayerAttributes>().getStaminaAmount() != 0 ) // check også for at der kan farmes på det tile
        {
            GameObject.Find("Player").GetComponent<PlayerAttributes>().useStamina(((Tool)item).getStaminaAmount());
            

        }
        else
        {
            // Tell user no more stamina
        }
    }


}
