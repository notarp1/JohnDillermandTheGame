using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Item[] items;
    private int playerCoins;
    private GameObject player;
    private GameObject moneyBar;
    public bool isLoaded = false;

    private GameObject hotbar_hotbar;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        moneyBar = GameObject.Find("MoneyBar");
        if (!isLoaded)
        {
            items = new Item[10];
            items[0] = new Weapon("Sword", 1, itemTypes.Weapon, 20, 0.5f, 2);
            items[1] = new HealItem("Potion", 30, itemTypes.HealItem, 10);
            //items[2] = new HealItem("Poison", 30, "HealItem", -5);
            setCoins(0);
            hotbar_hotbar = GameObject.Find("Hotbar_hotbar");
            for (int i = 0; i < items.Length; i++)
            {
                hotbar_hotbar.transform.GetChild(i).GetComponent<HotbarItemUser>().setItem(items[i]);
            }
            setItems(items);
        }
        GameObject.Find("GroundItem").GetComponent<GroundItemInventory>().setItem(new HealItem("Poison", 30, itemTypes.HealItem, -5));
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public Item[] getItems()
    {
        return this.items;
    }

    public void setItems(Item[] items)
    {
        this.items = items;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                if (items[i].getItemAmount() == 0)
                {
                    items[i] = null;
                    hotbar_hotbar.transform.GetChild(i).GetComponent<HotbarItemUser>().setItem(null);
                }
            }
            if (items[i] == null)
            {
                hotbar_hotbar.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().SetText(0 + "");
            } else hotbar_hotbar.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().SetText(items[i].getItemAmount() + "");
        }
    }

    public void addItem(Item newItem)
    {
        Debug.Log("ADDING ITEM");
        bool isExist = false;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                if (items[i].getItemName().Equals(newItem.getItemName()))
                {
                    items[i].setItemAmount(items[i].getItemAmount() + newItem.getItemAmount());
                    isExist = true;
                    break;
                }
            }
        }

        if (!isExist)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    items[i] = newItem;
                    hotbar_hotbar.transform.GetChild(i).GetComponent<HotbarItemUser>().setItem(items[i]);
                    break;
                }
            }
        }
        setItems(this.items);
    }

    public bool isFull()
    {
        foreach (Item i in this.items)
        {
            if (i == null)
            {
                return false;
            }
        }
        return true;
    }

    public void addMoney(int amount)
    {
        setCoins(getCoins()+amount);
    }
    public void setCoins(int amount)
    {
        this.playerCoins = amount;
        moneyBar.GetComponent<MoneyBar>().setMoneyBar(amount);
    }

    public int getCoins()
    {
        return this.playerCoins;
    }

    public void clearItems()
    {
        Item[] newitems = new Item[10];
        for (int i = 0; i < newitems.Length; i++)
        {
            newitems[i] = null;
            hotbar_hotbar.transform.GetChild(i).GetComponent<HotbarItemUser>().setItem(null);
        }
        setItems(newitems);
    }

}
