using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Item[] items;
    private GameObject player;

    private GameObject hotbar_hotbar;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        items = new Item[10];
        items[0] = new Weapon("Sword", 30, "Weapon",100);
        items[1] = new HealItem("Potion", 30, "HealItem", 10);
        items[2] = new HealItem("Potion2", 30, "HealItem", -5);
        hotbar_hotbar = GameObject.Find("Hotbar_hotbar");
        for (int i = 0; i < items.Length; i++)
        {
            hotbar_hotbar.transform.GetChild(i).GetComponent<HotbarItemUser>().setItem(items[i]);
        }
        Debug.Log("ITEM SIZE ER " + items.Length);
        setItems(items);
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
            if (items[i] == null)
            {
                hotbar_hotbar.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().SetText(0 + "");
            } else hotbar_hotbar.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().SetText(items[i].getItemAmount() + "");
        }
    }

    public void addItem(Item newItem)
    {
        Item[] newItemArray = new Item[items.Length + 1];
        for (int i = 0; i < items.Length; i++)
        {
            newItemArray[i] = items[i];
        }

        newItemArray[items.Length] = newItem;
        setItems(newItemArray);
    }

}
