using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarItemUser : MonoBehaviour
{
    private Item currentItem = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setItem(Item item)
    {
        if (item != null)
        {
            switch (item.getItemName())
            {
                case "Potion":
                    this.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load("Potion", typeof(Sprite)) as Sprite;
                    break;
                case "Potion2":
                    this.transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load("Potion2", typeof(Sprite)) as Sprite;
                    break;

            }
        }
        this.currentItem = item;
    }

    public Item getItem()
    {
        return this.currentItem;
    }

    public void useItem()
    {
        if (currentItem != null)
        {
            switch (currentItem.getItemType())
            {
                case "Weapon":
                    ((Weapon) currentItem).useItem(currentItem);
                    break;
                case "HealItem":
                    ((HealItem)currentItem).useItem(currentItem);
                    break;
            }
        }
    }


}
