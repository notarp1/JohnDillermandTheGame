using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class EnemyAttribute : MonoBehaviour
{
    private int enemyHealth;
    private Slider healthbar;
    public GameObject lootPrefab;
    private List<Item> lootItems;
    public GameObject player;
    public ParticleSystem hitParticle;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 100;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).name.Equals("EnemyHealthBar"))
            {
                healthbar = this.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Slider>();
                break;
            }
        }

        healthbar.maxValue = enemyHealth;
        setHealthBar(enemyHealth);
        initiateLootItems();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void setEnemyHealth(int hp)
    {
        this.enemyHealth = hp;
        setHealthBar(this.enemyHealth);
    }

    public int getEnemyHealth()
    {
        return this.enemyHealth;
    }

    public void damageEnemy(int damage, GameObject enemy)
    {
        setEnemyHealth(getEnemyHealth()-damage);
        setHealthBar(this.enemyHealth);
        if (getEnemyHealth() <= 0)
        {
            killEnemy(enemy);
        }
    }

    private void killEnemy(GameObject enemy)
    {
        ParticleSystem particle = Instantiate(hitParticle, transform.position, transform.rotation);
        GameObject loot = Instantiate(lootPrefab, new Vector3(enemy.transform.position.x-2, enemy.transform.position.y+2, 0),
            Quaternion.identity);
        Random rand = new Random();
        Item lootToAdd = lootItems[rand.Next(0, lootItems.Count)];
        lootToAdd.setItemAmount(rand.Next(1,11));
        loot.GetComponent<GroundItemInventory>().setItem(lootToAdd);
        player.GetComponent<PlayerAttributes>().checkQuests(objectsInQuest.enemy,objectives.kill,1);
        Destroy(enemy);
    }

    private void setHealthBar(int hp)
    {
        healthbar.value = hp;
        for (int i = 0; i < healthbar.transform.childCount; i++)
        {
            if (healthbar.transform.GetChild(i).name.Equals("HealthBarText"))
            {
                healthbar.transform.GetChild(i).GetComponent<TextMeshProUGUI>().SetText(enemyHealth+"");
            }
        }
    }

    private void initiateLootItems()
    {
        lootItems = new List<Item>();
        //lootItems.Add(new HealItem("Potion", 0, itemTypes.HealItem, 10));
        //lootItems.Add(new HealItem("Poison", 0, itemTypes.HealItem, -5));
        lootItems.Add(new Money("CoinBag",0,itemTypes.Coin,coinAmount.coinBag));
    }
}
