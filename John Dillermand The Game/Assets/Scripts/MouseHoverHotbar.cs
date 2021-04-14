using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHoverHotbar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hoverShowItem;

    private GameObject parentObject = null;
    // Start is called before the first frame update
    void Start()
    {
        hoverShowItem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hoverShowItem.activeSelf && parentObject != null)
        {
            hoverShowItem.transform.GetChild(0).transform.position = new Vector3(parentObject.transform.position.x, parentObject.transform.position.y + 2, 0);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Item item = gameObject.GetComponent<HotbarItemUser>().getItem();
        if (item != null)
        {
            hoverShowItem.SetActive(true);
            parentObject = eventData.pointerCurrentRaycast.gameObject;
            hoverShowItem.transform.GetChild(0).transform.position = new Vector3(eventData.pointerCurrentRaycast.gameObject.transform.position.x, eventData.pointerCurrentRaycast.gameObject.transform.position.y+2, 0);
            TextMeshProUGUI text = GameObject.Find("HoverShowItemText").GetComponent<TextMeshProUGUI>();
            string textToInsert = "";
            switch (item.getItemType())
            {
                case itemTypes.Weapon:
                    textToInsert = "Item: " + ((Weapon) item).getItemName() + "\nDamage: " +
                                   ((Weapon) item).getDamageAmount() + "\nStamina usage: " +
                                   ((Weapon) item).getStaminaAmount() + "\nRange: " + ((Weapon) item).getRange();
                    break;
                case itemTypes.HealItem:
                    textToInsert = "Item: " + ((HealItem)item).getItemName() + "\nHealing amount: " +
                                   ((HealItem)item).getHealingAmount() + "\nAmount left: " +
                                   ((HealItem)item).getItemAmount();
                    break;
            }
            text.SetText(textToInsert);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        parentObject = null;
        hoverShowItem.SetActive(false);
    }
}
