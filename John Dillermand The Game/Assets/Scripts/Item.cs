using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Item
{
    void setItemName(String itemName);
    String getItemName();
    void setItemType(String itemType);
    String getItemType();
    void setItemAmount(int itemAmount);
    int getItemAmount();
    void useItem(Item item);

}
