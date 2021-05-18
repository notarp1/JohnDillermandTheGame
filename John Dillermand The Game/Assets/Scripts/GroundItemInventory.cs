using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItemInventory : MonoBehaviour
{
    private Item item;

    public Item getItem()
    {
        return this.item;
    }

    public void setItem(Item item)
    {
        this.item = item;
        switch (item.getItemType())
        {
            case itemTypes.HealItem:
                switch (item.getItemName())
                {
                    case "Potion":
                        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Potion", typeof(Sprite)) as Sprite;
                        gameObject.transform.localScale = new Vector3(1, 1, 1);
                        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
                        break;
                    case "Poison":
                        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load("Poison", typeof(Sprite)) as Sprite;
                        gameObject.transform.localScale = new Vector3(1, 1, 1);
                        break;
                }
                break;

            case itemTypes.Weapon:
                switch (item.getItemName())
                {
                    case "Sword":
                        gameObject.GetComponent<SpriteRenderer>().sprite =
                            Resources.Load("Sword", typeof(Sprite)) as Sprite;
                        gameObject.transform.localScale = new Vector3(3, 3, 3);
                        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
                        break;
                }
                break;
            case itemTypes.Tool:
                switch (item.getItemName())
                {
                    case "Hoe":
                        gameObject.GetComponent<SpriteRenderer>().sprite =
                            Resources.Load("Hoe", typeof(Sprite)) as Sprite;
                        gameObject.transform.localScale = new Vector3(1, 1, 1);
                        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
                        break;
                }

                break;

            case itemTypes.Coin:
                switch (item.getItemName())
                {

                    case "CoinBag":
                        gameObject.GetComponent<SpriteRenderer>().sprite =
                            Resources.Load("MoneyBags", typeof(Sprite)) as Sprite;
                        gameObject.transform.localScale = new Vector3(1, 1, 1);
                        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
                        break;
                }
                break;

            case itemTypes.Seed:
                switch (item.getItemName())
                {
                    case "Sunflower Seed":
                        gameObject.GetComponent<SpriteRenderer>().sprite =
                            Resources.Load("sunflower", typeof(Sprite)) as Sprite;
                        gameObject.transform.localScale = new Vector3(1, 1, 1);
                        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(1, 1);
                        break;


                }

                break;
        }
    }

    public void destroyItem()
    {
        Destroy(gameObject);
    }
}
