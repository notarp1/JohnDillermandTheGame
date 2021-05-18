using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class QuestGiver : MonoBehaviour
{
    public List<Quest> questsToGive = new List<Quest>();
    private bool isReadyToGiveQuest = true;
    private bool playerIsInRange = false;
    public PlayerAttributes attr;
    public bool isInitialized = false;
    public GameObject textShower;

    // Start is called before the first frame update
    void Start()
    {
        if (!isInitialized)
        {
            initializeQuests();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isReadyToGiveQuest)
        {
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        else
        {
            gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 0);
            if (attr.activeQuests.Count != 5 && questsToGive.Count > 0)
            {
                setIsReadyToGiveQuest(true);
            }
        }
    }

    private void initializeQuests()
    {
        questsToGive = new List<Quest>();
        questsToGive.Add(new Quest(objectsInQuest.enemy,1,1,"Slayer of enemies",objectives.kill, rewards.coins,3));
        questsToGive.Add(new Quest(objectsInQuest.potion,10,10,"Gain some HP",objectives.pickup,rewards.poison,10));
        questsToGive.Add(new Quest(objectsInQuest.poison, 10, 10, "Gain some HP", objectives.pickup, rewards.poison, 10));
        questsToGive.Add(new Quest(objectsInQuest.enemy, 1, 1, "Slayer of enemies", objectives.pickup, rewards.coins, 3));
        questsToGive.Add(new Quest(objectsInQuest.johnHouse, 1, 1, "Indiana Johns", objectives.gotolocation, rewards.coins, 5));
    }

    public void setIsReadyToGiveQuest(bool ready)
    {
        this.isReadyToGiveQuest = ready;
    }

    public bool getIsReadyToGiveQuest()
    {
        return this.isReadyToGiveQuest;
    }

    public void giveQuestToPlayer()
    {
        attr.addQuest(getQuest());
        if (attr.activeQuests.Count == 5)
        {
            setIsReadyToGiveQuest(false);
        }
        textShower.GetComponentInChildren<TextMeshProUGUI>().SetText("Quest added!\nPress tab to show active quests");
        textShower.SetActive(true);
        StartCoroutine(hideText());
    }

    public Quest getQuest()
    {

        Random rand = new Random();
        int index = rand.Next(0, questsToGive.Count);
        Quest quest = questsToGive[index];
        questsToGive.RemoveAt(index);
        if (questsToGive.Count == 0)
        {
            setIsReadyToGiveQuest(false);
        }
        return quest;
    }

    public bool getPlayerIsInRange()
    {
        return this.playerIsInRange;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player"))
        {
            playerIsInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player"))
        {
            playerIsInRange = false;
        }
    }

    public void setQuests(List<Quest> newQuests)
    {
        this.questsToGive = newQuests;
        if (attr.activeQuests.Count != 5 && questsToGive.Count > 0)
        {
            setIsReadyToGiveQuest(true);
        } else setIsReadyToGiveQuest(false);
    }


    private IEnumerator hideText()
    {
        yield return new WaitForSeconds(2);
        textShower.SetActive(false);
    }

}
