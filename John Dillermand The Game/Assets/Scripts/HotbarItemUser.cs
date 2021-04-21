using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarItemUser : MonoBehaviour
{
    private Item currentItem = null;

    private Animator anim;
    private bool itemCanBeUsed = true;

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
            this.transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 255);
            switch (item.getItemName())
            {
                case "Potion":
                    this.transform.GetChild(0).GetComponent<Image>().sprite =
                        Resources.Load("Potion", typeof(Sprite)) as Sprite;
                    break;
                case "Poison":
                    this.transform.GetChild(0).GetComponent<Image>().sprite =
                        Resources.Load("Poison", typeof(Sprite)) as Sprite;
                    break;
                case "Sword":
                    this.transform.GetChild(0).GetComponent<Image>().sprite =
                        Resources.Load("Sword", typeof(Sprite)) as Sprite;
                    break;
                case "CoinBag":
                    this.transform.GetChild(0).GetComponent<Image>().sprite =
                        Resources.Load("MoneyBags", typeof(Sprite)) as Sprite;
                    break;
                case "Hoe":
                    this.transform.GetChild(0).GetComponent<Image>().sprite =
                        Resources.Load("Hoe", typeof(Sprite)) as Sprite;
                    break;
            } 
        } else removeItem();
        this.currentItem = item;
    }

    public void removeItem()
    {
        this.transform.GetChild(0).GetComponent<Image>().sprite = null;
        this.transform.GetChild(0).GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }

    public Item getItem()
    {
        return this.currentItem;
    }

    public void useItem()
    {
        if (currentItem != null && itemCanBeUsed)
        {
            GameObject player = GameObject.Find("Player");
            switch (currentItem.getItemType())
            {
                case itemTypes.Weapon:
                    itemCanBeUsed = false;
                    anim = GameObject.Find("Sword").GetComponent<Animator>();
                    ((Weapon) currentItem).useItem(currentItem, anim);
                    itemCanBeUsed = true;
                    break;
                case itemTypes.Tool:
                    itemCanBeUsed = false;
                    anim = GameObject.Find("Sword").GetComponent<Animator>();
                    ((Tool)currentItem).useItem(currentItem, anim);
                    itemCanBeUsed = true;
                    break;
                case itemTypes.HealItem:
                    itemCanBeUsed = false;
                    player.transform.Find("Potion").gameObject.SetActive(true);
                    anim = GameObject.Find("Potion").GetComponent<Animator>();
                    ((HealItem)currentItem).useItem(currentItem, anim, this);
                    break;
                case itemTypes.Coin:
                    itemCanBeUsed = false;
                    anim = GameObject.Find("Sword").GetComponent<Animator>();
                    ((Money)currentItem).useItem(currentItem, anim);
                    itemCanBeUsed = true;
                    break;
            }
        }
    }

    public void startPotionRoutine(string name)
    {
        StartCoroutine(hidePotion(anim, name));
    }

    private IEnumerator hidePotion(Animator animator, string name)
    {
        if (name.Equals("Empty"))
        {
            GameObject.Find("Potion").SetActive(false);
            itemCanBeUsed = true;
        }
        else
        {
            foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
            {
                if (clip.name == name)
                {
                    yield return new WaitForSeconds(clip.length);
                    GameObject.Find("Potion").SetActive(false);
                    itemCanBeUsed = true;
                }
            }
        }
    }

}
