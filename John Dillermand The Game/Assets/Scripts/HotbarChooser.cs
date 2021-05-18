using UnityEngine;
using UnityEngine.UI;

public class HotbarChooser : MonoBehaviour
{
    public GameObject hotbar_hotbar;
    private int inventoryItemNr = -1;
    private int childNumber;

    public PlayerInventory inventory;

    public WeaponRange weaponRange;
    public HoverOverFarmTile farmtiling;

    public GameObject sword;
    public GameObject hoe;

    public void setChildNumber(int number)
    {
        if (childNumber != number)
        {
            farmtiling.setHoldingHoe(false);
        }
        hoe.SetActive(false);
        sword.SetActive(false);
        this.childNumber = number;
        if (inventory.getItems()[childNumber] != null)
        {
            if (inventory.getItems()[childNumber].getItemType() == itemTypes.Weapon)
            {
                weaponRange.setRange(((Weapon)inventory.getItems()[childNumber]).getRange());
                sword.SetActive(true);
            }

            if (inventory.getItems()[childNumber].getItemName().Equals("Hoe"))
            {
                farmtiling.setHoldingHoe(true);
                hoe.SetActive(true);
            }

            if (inventory.getItems()[childNumber].getItemType() == itemTypes.Seed)
            {
                farmtiling.setHoldingSeed(true, inventory.getItems()[childNumber].getItemName());
            }

        }
        this.inventoryItemNr = childNumber;
        Image billede = hotbar_hotbar.transform.GetChild(childNumber).GetComponent<Image>();
        billede.color = new Color32(110, 241, 121, 148);
        for (int i = 0; i < hotbar_hotbar.transform.childCount; i++)
        {
            if (i != childNumber)
            {
                hotbar_hotbar.transform.GetChild(i).GetComponent<Image>().color = new Color32(63, 63, 63, 148);
            }
        }
    }

    public int getChildNumber()
    {
        return this.childNumber;
    }

    public void useHotbarItem()
    {
        hotbar_hotbar.transform.GetChild(inventoryItemNr).GetComponent<HotbarItemUser>().useItem();
    }
}
