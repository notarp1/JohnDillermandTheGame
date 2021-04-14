using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum coinAmount
{
    singleCoin = 5, coinStack = 50, coinBag = 100, coinPile = 500
}

public class Money : Item
{
    private string itemName;
    private int itemAmount;
    private itemTypes itemType;
    private coinAmount cAmount;
    public Money(string itemName, int itemAmount, itemTypes itemType, coinAmount cAmount)
    {
        this.itemName = itemName;
        this.itemAmount = itemAmount;
        this.itemType = itemType;
        this.cAmount = cAmount;
    }

    public void setItemName(string itemName)
    {
        this.itemName = itemName;
    }

    public string getItemName()
    {
        return this.itemName;
    }

    public void setItemType(itemTypes itemType)
    {
        this.itemType = itemType;
    }

    public itemTypes getItemType()
    {
        return this.itemType;
    }

    public void setItemAmount(int itemAmount)
    {
        this.itemAmount = itemAmount;
    }

    public int getItemAmount()
    {
        return this.itemAmount;
    }

    public void setCoinAmount(coinAmount cAmount)
    {
        this.cAmount = cAmount;
    }

    public coinAmount getCoinAmount()
    {
        return this.cAmount;
    }

    public void useItem(Item item, Animator anim)
    {
        PlayerInventory inven = GameObject.Find("Player").GetComponent<PlayerInventory>();
        inven.addMoney((int) ((Money) item).getCoinAmount());
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
