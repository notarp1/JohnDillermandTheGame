using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject root;
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1;
        Destroy(root);
    }

    public void loadGame()
    {
        PlayerData data = SaveSystem.loadPlayer();
        if (data != null)
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            StartCoroutine(waitForSceneLoad(currentScene+1, data));
        } else playGame();
    }

    public void quitGame()
    {
        Application.Quit();
    }


    IEnumerator waitForSceneLoad(int sceneNumber, PlayerData data)
    {
        while (SceneManager.GetActiveScene().buildIndex != sceneNumber)
        {
            yield return null;
        }
        // Do anything after proper scene has been loaded
        if (SceneManager.GetActiveScene().buildIndex == sceneNumber)
        {
            GameObject player = GameObject.Find("Player");
            PlayerInventory inven = player.GetComponent<PlayerInventory>();
            inven.isLoaded = true;
            player.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
            player.GetComponent<PlayerAttributes>().setPlayerHealth(data.hpAmount);
            player.GetComponent<PlayerAttributes>().setStamina(data.staminaAmount);
            inven.setCoins(data.gold);
            inven.clearItems();
            for (int i = 0; i < data.inventoryItemAmounts.Length; i++)
            {
                switch (data.inventoryItemNames[i])
                {
                    case "Potion":
                        inven.addItem(new HealItem(data.inventoryItemNames[i], data.inventoryItemAmounts[i],
                            itemTypes.HealItem, 10));
                        break;
                    case "Poison":
                        inven.addItem(new HealItem(data.inventoryItemNames[i], data.inventoryItemAmounts[i],
                            itemTypes.HealItem, -5));
                        break;
                    case "Sword":
                        inven.addItem(new Weapon("Sword", data.inventoryItemAmounts[i], itemTypes.Weapon, 20, 0.5f, 2));
                        break;
                    default:
                        break;
                }
            }

            Time.timeScale = 1;
            Destroy(root);
        }
        
    }

}
