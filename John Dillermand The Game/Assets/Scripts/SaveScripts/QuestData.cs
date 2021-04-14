using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestData
{
    public string[] questTitles;
    public objectives[] objetives;
    public objectsInQuest[] objects;
    public rewards[] rewards;
    public int[] rewardAmount;
    public int[] amountLeft;
    public int[] startValues;


    public QuestData(List<Quest> questsToSave)
    {
        questTitles = new string[questsToSave.Count];
        objetives = new objectives[questsToSave.Count];
        objects = new objectsInQuest[questsToSave.Count];
        rewards = new rewards[questsToSave.Count];
        rewardAmount = new int[questsToSave.Count];
        amountLeft = new int[questsToSave.Count];
        startValues = new int[questsToSave.Count];
        for (int i = 0; i < questsToSave.Count; i++)
        {
            questTitles[i] = questsToSave[i].getTitle();
            objetives[i] = questsToSave[i].getObjective();
            objects[i] = questsToSave[i].getObjectInQuest();
            rewards[i] = questsToSave[i].getReward();
            rewardAmount[i] = questsToSave[i].getRewardAmount();
            amountLeft[i] = questsToSave[i].getAmountLeft();
            startValues[i] = questsToSave[i].getStartValue();
        }
    }


}
