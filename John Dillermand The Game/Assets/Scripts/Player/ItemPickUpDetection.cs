using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemPickUpDetection : MonoBehaviour
{
    private GameObject player;

    private PlayerInventory playerInventory;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Hvis du går over nogle items på jorden
    private void OnTriggerEnter2D(Collider2D collider)
    {
        bool hasBeenAdded = false;
        if (collider.tag.Equals("groundItem"))
        {
            Item currentItem = collider.gameObject.GetComponent<GroundItemInventory>().getItem();
            Item[] items = playerInventory.getItems();

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
