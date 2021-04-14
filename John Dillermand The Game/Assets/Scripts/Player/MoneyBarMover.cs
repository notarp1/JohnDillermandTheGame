using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBarMover : MonoBehaviour
{
    private GameObject player;

    private GameObject playerMoneyBar;

    private float xOffset;

    private float yOffset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerMoneyBar = GameObject.Find("PlayerMoneyBar");
        xOffset = playerMoneyBar.transform.position.x;
        yOffset = playerMoneyBar.transform.position.y;
        playerMoneyBar.transform.position = new Vector3(player.transform.position.x + xOffset,
            player.transform.position.y + yOffset, 0);
    }

    // Update is called once per frame
    void Update()
    {
        playerMoneyBar.transform.position = new Vector3(player.transform.position.x + xOffset,
            player.transform.position.y + yOffset, 0);
    }
}
