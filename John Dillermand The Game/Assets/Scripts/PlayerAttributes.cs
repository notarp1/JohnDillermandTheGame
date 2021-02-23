using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    private int playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 100;
    }

    public void setPlayerHealth(int playerHealth)
    {
        this.playerHealth = playerHealth;
        GameObject.Find("HealthBar").GetComponent<HealthBar>().setHealthBar(playerHealth);
    }

    public int getPlayerHealth()
    {
        return this.playerHealth;
    }


}
