using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : Item
{
    private String itemName, itemType;
    private int itemAmount, healingAmount;

    public HealItem(String itemName, int itemAmount, String itemType, int healingAmount)
    {
        this.itemName = itemName;
        this.itemAmount = itemAmount;
        this.itemType = itemType;
        this.healingAmount = healingAmount;
    }

    public int getItemAmount()
    {
        return this.itemAmount;
    }

    public string getItemName()
    {
        return this.itemName;
    }

    public string getItemType()
    {
        return this.itemType;
    }

    public void setItemAmount(int itemAmount)
    {
        this.itemAmount = itemAmount;
    }

    public void setItemName(string itemName)
    {
        this.itemName = itemName;
    }

    public void setItemType(string itemType)
    {
        this.itemType = itemType;
    }

    public int getHealingAmount()
    {
        return this.healingAmount;
    }

    public void setHealingAmount(int healingAmount)
    {
        this.healingAmount = healingAmount;
    }

    public void useItem(Item item)
    {
        PlayerAttributes playerAttribute = GameObject.Find("Player").GetComponent<PlayerAttributes>();
        PlayerInventory playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
        if (((HealItem) item).getHealingAmount() > 0)
        {
            if (item.getItemAmount() != 0 && playerAttribute.getPlayerHealth() != 100)
            {

                Item[] items = playerInventory.getItems();
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].getItemName().Equals(item.getItemName()))
                    {
                        playerAttribute.setPlayerHealth(Math.Min(playerAttribute.getPlayerHealth() + ((HealItem)item).getHealingAmount(), 100));
                        items[i].setItemAmount(item.getItemAmount() - 1);
                        break;
                    }
                }
                playerInventory.setItems(items);
            }
            else Debug.Log("Ikke nok item amount tilbage eller player HP er 100!!");
        }
        else
        {
            if (item.getItemAmount() != 0 && playerAttribute.getPlayerHealth() != 0)
            {

                Item[] items = playerInventory.getItems();
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].getItemName().Equals(item.getItemName()))
                    {
                        playerAttribute.setPlayerHealth(Math.Min(playerAttribute.getPlayerHealth() + ((HealItem)item).getHealingAmount(), 100));
                        items[i].setItemAmount(item.getItemAmount() - 1);
                        break;
                    }
                }
                playerInventory.setItems(items);
            }
            else Debug.Log("Ikke nok item amount tilbage eller player HP er 0!!");
        }
    }
}
