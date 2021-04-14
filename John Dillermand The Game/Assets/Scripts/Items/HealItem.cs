using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum healingType
{
    potion, poison
}

public class HealItem : Item
{
    private string itemName;
    private itemTypes itemType;
    private int itemAmount, healingAmount;

    public HealItem(string itemName, int itemAmount, itemTypes itemType, int healingAmount)
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

    public itemTypes getItemType()
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

    public void setItemType(itemTypes itemType)
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

    public void useItem(Item item, Animator anim, HotbarItemUser hotbarItemUser)
    {
        PlayerAttributes playerAttribute = GameObject.Find("Player").GetComponent<PlayerAttributes>();
        if (playerAttribute.isDamageable())
        {
            PlayerInventory playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
            if (((HealItem) item).getHealingAmount() > 0)
            {
                if (item.getItemAmount() != 0 && playerAttribute.getPlayerHealth() != 100)
                {
                    anim.Play("PotionAnimation");
                    hotbarItemUser.startPotionRoutine("PotionAnimation");
                    Item[] items = playerInventory.getItems();
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (items[i].getItemName().Equals(item.getItemName()))
                        {
                            playerAttribute.healPlayer(((HealItem) item).getHealingAmount());
                            items[i].setItemAmount(item.getItemAmount() - 1);
                            break;
                        }
                    }

                    playerInventory.setItems(items);
                }
                else hotbarItemUser.startPotionRoutine("Empty");
            }
            else
            {
                if (item.getItemAmount() != 0 && playerAttribute.getPlayerHealth() != 0)
                {
                    hotbarItemUser.startPotionRoutine("Empty");
                    Item[] items = playerInventory.getItems();
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (items[i].getItemName().Equals(item.getItemName()))
                        {
                            playerAttribute.dealDamage(Math.Abs(((HealItem) item).getHealingAmount()));
                            items[i].setItemAmount(item.getItemAmount() - 1);
                            break;
                        }
                    }

                    playerInventory.setItems(items);
                }
                else hotbarItemUser.startPotionRoutine("Empty");
            }
        }
        else hotbarItemUser.startPotionRoutine("Empty");

    }
}
