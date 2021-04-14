using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int hpAmount, staminaAmount, gold;
    public float[] position;
    public string[] inventoryItemNames;
    public int[] inventoryItemAmounts;

    public PlayerData(PlayerAttributes playerAttr, PlayerInventory playerInv, GameObject playerObj)
    {
        this.hpAmount = playerAttr.getPlayerHealth();
        this.staminaAmount = playerAttr.getStaminaAmount();
        this.gold = playerInv.getCoins();
        position = new float[3];
        position[0] = playerObj.transform.position.x;
        position[1] = playerObj.transform.position.y;
        position[2] = playerObj.transform.position.z;
        Item[] items = playerInv.getItems();
        int itemLength = items.Length;
        inventoryItemAmounts = new int[itemLength];
        inventoryItemNames = new string[itemLength];
        for (int i = 0; i < itemLength; i++)
        {
            if (items[i] != null)
            {
                inventoryItemAmounts[i] = items[i].getItemAmount();
                inventoryItemNames[i] = items[i].getItemName();
            }
        }


    }
}
