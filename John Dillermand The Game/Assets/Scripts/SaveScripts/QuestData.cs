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

    public string[] questTitlesGiver;
    public objectives[] objetivesGiver;
    public objectsInQuest[] objectsGiver;
    public rewards[] rewardsGiver;
    public int[] rewardAmountGiver;
    public int[] amountLeftGiver;
    public int[] startValuesGiver;

    public QuestData(List<Quest> questsToSave, List<Quest> questsToSaveGiver)
    {
        questTitles = new string[questsToSave.Count];
        objetives = new objectives[questsToSave.Count];
        objects = new objectsInQuest[questsToSave.Count];
        rewards = new rewards[questsToSave.Count];
        rewardAmount = new int[questsToSave.Count];
        amountLeft = new int[questsToSave.Count];
        startValues = new int[questsToSave.Count];

        questTitlesGiver = new string[questsToSaveGiver.Count];
        objetivesGiver = new objectives[questsToSaveGiver.Count];
        objectsGiver = new objectsInQuest[questsToSaveGiver.Count];
        rewardsGiver = new rewards[questsToSaveGiver.Count];
        rewardAmountGiver = new int[questsToSaveGiver.Count];
        amountLeftGiver = new int[questsToSaveGiver.Count];
        startValuesGiver = new int[questsToSaveGiver.Count];


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

        for (int i = 0; i < questsToSaveGiver.Count; i++)
        {
            questTitlesGiver[i] = questsToSaveGiver[i].getTitle();
            objetivesGiver[i] = questsToSaveGiver[i].getObjective();
            objectsGiver[i] = questsToSaveGiver[i].getObjectInQuest();
            rewardsGiver[i] = questsToSaveGiver[i].getReward();
            rewardAmountGiver[i] = questsToSaveGiver[i].getRewardAmount();
            amountLeftGiver[i] = questsToSaveGiver[i].getAmountLeft();
            startValuesGiver[i] = questsToSaveGiver[i].getStartValue();
        }
    }


}
