using UnityEngine;
using UnityEngine.UI;

public class HotbarChooser : MonoBehaviour
{
    public GameObject hotbar_hotbar;
    private int inventoryItemNr = -1;
    private int childNumber;

    public PlayerInventory inventory;

    public WeaponRange weaponRange;

    public void setChildNumber(int number)
    {
        this.childNumber = number;
        if (inventory.getItems()[childNumber] != null)
        {
            if (inventory.getItems()[childNumber].getItemType().Equals("Weapon"))
            {
                weaponRange.setRange(((Weapon)inventory.getItems()[childNumber]).getRange());
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
