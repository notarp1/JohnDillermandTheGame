using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemTypes
{
    HealItem, Weapon, Coin
}
public interface Item
{
    void setItemType(itemTypes itemName);
    itemTypes getItemType();
    void setItemAmount(int itemAmount);
    int getItemAmount();
    public void setItemName(string itemName);
    public string getItemName();
}
