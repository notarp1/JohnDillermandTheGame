using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    private String name, type;

    private int amount, damageAmount;

    private static int a=10, b=10, theta = 60;

    public Weapon(String name, int amount, String type, int damageAmount)
    {
        this.name = name;
        this.amount = amount;
        this.type = type;
        this.damageAmount = damageAmount;
    }

    public void setItemName(String itemName)
    {
        this.name = itemName;
    }

    public String getItemName()
    {
        return this.name;
    }

    public void setItemAmount(int itemAmount)
    {
        this.amount = itemAmount;
    }

    public int getItemAmount()
    {
        return this.amount;
    }

    public void setItemType(String type)
    {
        this.type = type;
    }

    public String getItemType()
    {
        return this.type;
    }

    public void setDamageAmount(int damageAmount)
    {
        this.damageAmount = damageAmount;
    }

    public int getDamageAmount()
    {
        return this.damageAmount;
    }

    public void useItem(Item item)
    {
        float side = (float) (Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(theta)));
        float xCoord, yCoordLow, yCoordHigh;
        switch (GameObject.Find("Player").GetComponent<PlayerMovement>().rotation)
        {
                
            case "r":
                xCoord = GameObject.Find("Player").transform.position.x + a;
                yCoordLow = GameObject.Find("Player").transform.position.y - side/2;
                yCoordHigh = GameObject.Find("Player").transform.position.y + side/2;
                break;
            case "l":
                xCoord = GameObject.Find("Player").transform.position.x - a;
                yCoordLow = GameObject.Find("Player").transform.position.y - side / 2;
                yCoordHigh = GameObject.Find("Player").transform.position.y + side / 2;
                break;
            case "u":
                xCoord = GameObject.Find("Player").transform.position.y + a;
                yCoordLow = GameObject.Find("Player").transform.position.x - side / 2;
                yCoordHigh = GameObject.Find("Player").transform.position.x + side / 2;
                break;
            case "d":
                xCoord = GameObject.Find("Player").transform.position.y - a;
                yCoordLow = GameObject.Find("Player").transform.position.x - side / 2;
                yCoordHigh = GameObject.Find("Player").transform.position.x + side / 2;
                break;
        }
    }
}
