using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemPickUpDetection : MonoBehaviour
{
    public GameObject player;

    public PlayerInventory playerInventory;
    public PlayerAttributes playerAttributes;

// Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Hvis du går over nogle items på jorden
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("groundItem"))
        {
            bool hasBeenAdded = false;
            Item currentItem = collider.gameObject.GetComponent<GroundItemInventory>().getItem();
            Item[] items = playerInventory.getItems();

            // check quests

            switch (currentItem.getItemName())
            {
                case "Potion":
                    playerAttributes.checkQuests(objectsInQuest.potion, objectives.pickup, currentItem.getItemAmount());
                    break;
                case "Poison":
                    playerAttributes.checkQuests(objectsInQuest.poison, objectives.pickup, currentItem.getItemAmount());
                    break;
                default:
                    // do nothing rn
                    break;

            }

            foreach (Item i in items)
            {
                if (i != null)
                {

                    if (i.getItemName().Equals(currentItem.getItemName()))
                    {
                        i.setItemAmount(i.getItemAmount() + currentItem.getItemAmount());
                        playerInventory.setItems(items);
                        collider.gameObject.GetComponent<GroundItemInventory>().destroyItem();
                        hasBeenAdded = true;
                        break;
                    }
                }
            }

            if (!playerInventory.isFull() && !hasBeenAdded)
            {
                playerInventory.addItem(currentItem);
                collider.gameObject.GetComponent<GroundItemInventory>().destroyItem();
            }


        }
    }
}
