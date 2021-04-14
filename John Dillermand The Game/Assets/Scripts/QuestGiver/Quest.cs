using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum objectives
{
    kill, pickup, gotolocation, discoverlocation
}

public enum objectsInQuest
{
    potion, poison, enemy, johnHouse   
}

public enum rewards
{
    poison, potion, coins
}


public class Quest
{
    private int amountLeft;
    private objectsInQuest objectInQuest;
    private string title;
    private objectives objective;
    private rewards reward;
    private int rewardAmount;
    private int startValue;

    public Quest(objectsInQuest objectInQuest, int startValue, int amountLeft, string title, objectives objective, rewards reward, int rewardAmount)
    {
        this.amountLeft = amountLeft;
        this.startValue = startValue;
        this.objectInQuest = objectInQuest;
        this.title = title;
        this.objective = objective;
        this.reward = reward;
        this.rewardAmount = rewardAmount;
    }

    public void setObjectInQuest(objectsInQuest questObject) {
        this.objectInQuest = questObject;
    }

    public objectsInQuest getObjectInQuest()
    {
        return this.objectInQuest;
    }

    public int getAmountLeft()
    {
        return this.amountLeft;
    }

    public void setAmountLeft(int amount)
    {
        this.amountLeft = amount;
    }

    public string getTitle()
    {
        return this.title;
    }

    public void setTitle(string title)
    {
        this.title = title;
    }

    public objectives getObjective()
    {
        return this.objective;
    }

    public void setObjective(objectives objective)
    {
        this.objective = objective;
    }

    public void setStartValue(int startValue)
    {
        this.startValue = startValue;
    }

    public int getStartValue()
    {
        return this.startValue;
    }

    public rewards getReward()
    {
        return this.reward;
    }

    public int getRewardAmount()
    {
        return this.rewardAmount;
    }

    public void giveReward(PlayerInventory inven, PlayerAttributes attr)
    {
        Item itemToAdd = new HealItem("Potion", 0, itemTypes.HealItem, 10);
        switch (reward)
        {
            case rewards.coins:
                itemToAdd = new Money("CoinBag", rewardAmount, itemTypes.Coin, coinAmount.coinBag);
                break;
            case rewards.potion:
                itemToAdd = new HealItem("Potion", rewardAmount, itemTypes.HealItem, 10);
                break;
            case rewards.poison:
                itemToAdd = new HealItem("Poison", rewardAmount, itemTypes.HealItem, -5);
                break;
            default:
                itemToAdd = new HealItem("Potion", 0, itemTypes.HealItem, 10);
                break;
        }
        inven.addItem(itemToAdd);
        attr.finishQuest(this);
    }


}
