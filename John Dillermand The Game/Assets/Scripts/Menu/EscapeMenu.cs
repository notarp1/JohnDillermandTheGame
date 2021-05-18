using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public GameObject player;
    public PlayerAttributes playerAttr;
    public PlayerInventory playerInven;
    public QuestGiver questGiver;

    public void continueButton()
    {
        Time.timeScale = 1;
        player.GetComponent<GlobalKeyPresses>().isPaused = false;
    }

    public void saveButton()
    {
        SaveSystem.savePlayer(playerAttr, playerInven, player);
        SaveSystem.savePlayerQuests(playerAttr, questGiver.questsToGive);
    }

    public void loadButton()
    {
        PlayerData playerData = SaveSystem.loadPlayer();
        QuestData questData = SaveSystem.loadQuests();
        if (playerData != null)
        {
            player.transform.position = new Vector3(playerData.position[0], playerData.position[1], playerData.position[2]);
            playerAttr.setPlayerHealth(playerData.hpAmount);
            playerAttr.setStamina(playerData.staminaAmount);
            playerInven.setCoins(playerData.gold);
            playerInven.clearItems();
            for (int i = 0; i < playerData.inventoryItemAmounts.Length; i++)
            {
                switch (playerData.inventoryItemNames[i])
                {
                    case "Potion":
                        playerInven.addItem(new HealItem(playerData.inventoryItemNames[i], playerData.inventoryItemAmounts[i],itemTypes.HealItem, 10));
                        break;
                    case "Poison":
                        playerInven.addItem(new HealItem(playerData.inventoryItemNames[i], playerData.inventoryItemAmounts[i], itemTypes.HealItem, -5));
                        break;
                    case "Sword":
                        playerInven.addItem(new Weapon("Sword", playerData.inventoryItemAmounts[i], itemTypes.Weapon, 20, 0.5f, 2));
                        break;
                    default:
                        break;
                }
            }
        } else Debug.Log("NO PLAYERDATA FOUND");
        
        if (questData != null)
        {
            if (questData.questTitles.Length != 0)
            {
                List<Quest> quests = new List<Quest>();
                for (int i = 0; i < questData.questTitles.Length; i++)
                {
                    quests.Add(new Quest(questData.objects[i], questData.startValues[i], questData.amountLeft[i], questData.questTitles[i], questData.objetives[i], questData.rewards[i], questData.rewardAmount[i]));
                }
                playerAttr.setQuests(quests);
            }

            if (questData.questTitlesGiver.Length != 0)
            {
                List<Quest> giversQuests = new List<Quest>();
                for (int i = 0; i < questData.questTitlesGiver.Length; i++)
                {
                    giversQuests.Add(new Quest(questData.objectsGiver[i], questData.startValuesGiver[i], questData.amountLeftGiver[i], questData.questTitlesGiver[i], questData.objetivesGiver[i], questData.rewardsGiver[i], questData.rewardAmountGiver[i]));
                }

                questGiver.isInitialized = true;
                questGiver.setQuests(giversQuests);
            }
        }
        else Debug.Log("NO QUESTS FOUND");
    }
    public void quitButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }


}
