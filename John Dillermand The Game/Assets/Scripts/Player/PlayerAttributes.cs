using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class PlayerAttributes : MonoBehaviour
{
    private int playerHealth;
    private int playerStamina;
    private AudioSource audioSource;
    public AudioClip deathSound;
    public AudioClip damageSound;
    private bool soundCanBePlayed = true;
    public bool isLoaded = false;
    public GameObject questUIBox;

    private bool isDead = false;

    public List<Quest> activeQuests = new List<Quest>();
    public PlayerInventory playerInven;
    public ParticleSystem hitParticle;
    public GameObject lootPrefab;
    public GameObject player;
    public GameObject textShower;

    // Start is called before the first frame update
    void Start()
    {
        if (!isLoaded)
        {
            playerHealth = 100;
            playerStamina = 100;
            setPlayerHealth(playerHealth);
            setStamina(playerStamina);
            for (int i = 0; i < 5; i++)
            {
                questUIBox.transform.GetChild(i).gameObject.GetComponent<UIQuest>().setQuest(null);
            }
        }
        isDead = false;
        audioSource = player.GetComponent<AudioSource>();
    }

    public void setPlayerHealth(int playerHealth)
    {
        this.playerHealth = playerHealth;
        GameObject.Find("HealthBar").GetComponent<HealthBar>().setHealthBar(playerHealth);
    }

    public int getPlayerHealth()
    {
        return this.playerHealth;
    }

    public void dealDamage(int damage)
    {
        if (gameObject != null)
        {
            if (soundCanBePlayed)
            {
                if (playerHealth - damage > 0)
                {
                    soundCanBePlayed = false;
                    audioSource.volume = 0.6f;
                    audioSource.clip = damageSound;
                    audioSource.Play();
                    StartCoroutine(soundIsPlayable(audioSource.clip));
                }
                else
                {
                    soundCanBePlayed = false;
                    audioSource.volume = 0.8f;
                    audioSource.clip = deathSound;
                    audioSource.Play();
                    StartCoroutine(soundIsPlayable(audioSource.clip));
                    killPlayer();
                }

                setPlayerHealth(Math.Max(playerHealth - damage, 0));
            }
        }
    }

    public void healPlayer(int healAmount)
    {
        setPlayerHealth(Math.Min(getPlayerHealth()+healAmount, 100));
    }

    private void killPlayer()
    {
        isDead = true;
        ParticleSystem particle = Instantiate(hitParticle, transform.position, transform.rotation);
        Random rand = new Random();
        // remove all items from the inventory and make them grounditems
        foreach (Item i in playerInven.getItems())
        {
            if (i != null)
            {
                var loot = (GameObject) Instantiate(lootPrefab,new Vector3(player.transform.position.x + rand.Next(-5, 5),player.transform.position.y + rand.Next(-5, 5), 0),
                    Quaternion.identity);
                loot.GetComponent<GroundItemInventory>().setItem(i);
            }
        }
        playerInven.clearItems();
        gameObject.transform.position = new Vector3(1.5f, 1.35f, 0f);
        setPlayerHealth(100);
        setStamina(100);
        if (playerInven.getCoins() != 0)
        {
            playerInven.addMoney(-(playerInven.getCoins()/5));
        }
        isDead = false;
        textShower.GetComponentInChildren<TextMeshProUGUI>().SetText("You died!\nAll your items have been dropped on the ground where you died!");
        textShower.SetActive(true);
        StartCoroutine(hideText());
    }

    public bool isPlayerDead()
    {
        return this.isDead;
    }

    private IEnumerator soundIsPlayable(AudioClip clip)
    {
        yield return new WaitForSeconds(clip.length);
        soundCanBePlayed = true;
    }

    public bool isDamageable()
    {
        return soundCanBePlayed;
    }

    public void setStamina(int stamina)
    {
        this.playerStamina = stamina;
        GameObject.Find("StaminaBar").GetComponent<StaminaBar>().setStaminaBar(stamina);
    }

    public int getStaminaAmount()
    {
        return this.playerStamina;
    }

    public void useStamina(int amount)
    {
        setStamina(Math.Max(getStaminaAmount()-amount,0));
        GameObject.Find("StaminaBar").GetComponent<StaminaBar>().setStaminaBar(playerStamina);
    }

    public void addQuest(Quest quest)
    {
        bool isExists = false;
        for (int i = 0; i < activeQuests.Count; i++)
        {
            if (activeQuests[i].getObjectInQuest() == quest.getObjectInQuest() && activeQuests[i].getObjective() == quest.getObjective())
            {
                isExists = true;
            }
        }

        if (!isExists)
        {
            Debug.Log("QUEST ADDED WITH AMOUNT " + quest.getAmountLeft());
            activeQuests.Add(quest);
            questUIBox.transform.GetChild(activeQuests.Count - 1).gameObject.GetComponent<UIQuest>().setQuest(quest);
        }
    }

    public void checkQuests(objectsInQuest objectInQuest, objectives objective, int amount)
    {
        for (int i = 0; i < activeQuests.Count; i++)
        {
            Debug.Log("CHECKING QUEST");
            Debug.Log(activeQuests[i].getObjectInQuest() + "\t" + activeQuests[i].getObjective());
            Debug.Log(objectInQuest + "\t" + objective);
            Debug.Log(activeQuests[i].getObjectInQuest() == objectInQuest && activeQuests[i].getObjective() == objective);
            if (activeQuests[i].getObjectInQuest() == objectInQuest && activeQuests[i].getObjective() == objective)
            {
                if (activeQuests[i].getAmountLeft() - amount <= 0)
                {
                    activeQuests[i].setAmountLeft(0);
                    questUIBox.transform.GetChild(i).gameObject.GetComponent<UIQuest>().updateQuest(activeQuests[i]);
                }
                else
                {
                    activeQuests[i].setAmountLeft(activeQuests[i].getAmountLeft() - amount);
                    questUIBox.transform.GetChild(i).gameObject.GetComponent<UIQuest>().updateQuest(activeQuests[i]);
                }
                break;
            }
        }
    }

    public void finishQuest(Quest quest)
    {
        Debug.Log("QUEST ENDED WITH TITLE " + quest.getTitle());
        activeQuests.Remove(quest);
        for (int i = 0; i < activeQuests.Count; i++)
        {
            questUIBox.transform.GetChild(i).gameObject.GetComponent<UIQuest>().setQuest(activeQuests[i]);
        }

        for (int i = activeQuests.Count; i < 5; i++)
        {
            questUIBox.transform.GetChild(i).gameObject.GetComponent<UIQuest>().setQuest(null);
        }
    }

    public void setQuests(List<Quest> newQuests)
    {
        for (int i = 0; i < activeQuests.Count; i++)
        {
            questUIBox.transform.GetChild(i).gameObject.GetComponent<UIQuest>().setQuest(null);
        }

        activeQuests = newQuests;
        for (int i = 0; i < newQuests.Count; i++)
        {
            questUIBox.transform.GetChild(i).gameObject.GetComponent<UIQuest>().setQuest(newQuests[i]);
        }

    }

    private IEnumerator hideText()
    {
        yield return new WaitForSeconds(10);
        textShower.SetActive(false);
    }

}
