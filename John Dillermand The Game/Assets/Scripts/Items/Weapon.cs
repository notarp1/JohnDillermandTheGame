using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    private String name;
    private itemTypes type;

    private int amount, damageAmount, staminaAmount;
    private float range;

    public Weapon(String name, int amount, itemTypes type, int damageAmount, float range, int staminaAmount)
    {
        this.name = name;
        this.amount = amount;
        this.type = type;
        this.damageAmount = damageAmount;
        this.range = range;
        this.staminaAmount = staminaAmount;
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

    public void setItemType(itemTypes type)
    {
        this.type = type;
    }

    public itemTypes getItemType()
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

    public void setRange(float range)
    {
        this.range = range;
    }

    public float getRange()
    {
        return this.range;
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
        if (GameObject.Find("Player").GetComponent<PlayerAttributes>().getStaminaAmount() != 0)
        {
            GameObject sword = GameObject.Find("Sword");
            anim.Play("SwordAnimation");
            GameObject.Find("Player").GetComponent<PlayerAttributes>().useStamina(((Weapon)item).getStaminaAmount());
            List<GameObject> enemyList = GameObject.Find("WeaponRange").GetComponent<WeaponRange>().getAllEnemiesInRange();
            int enemyListCount = enemyList.Count;
            if (enemyListCount > 0)
            {
                for (int i = 0; i < enemyListCount; i++)
                {
                    enemyList[i].GetComponent<EnemyAttribute>().damageEnemy(((Weapon)item).damageAmount, enemyList[i]);
                    if (enemyList.Count != enemyListCount)
                    {
                        enemyListCount--;
                        i--;
                    }
                }
            }
        }
        else
        {
            // Tell user no more stamina
        }
    }

}
