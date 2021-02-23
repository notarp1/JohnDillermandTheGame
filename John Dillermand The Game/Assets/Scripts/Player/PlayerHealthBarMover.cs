using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBarMover : MonoBehaviour
{
    private GameObject player;

    private GameObject playerHPBar;

    private float xOffset;

    private float yOffset;
    // Start is called before the first frame update
    void Start()
    {   
        player = GameObject.Find("Player");
        playerHPBar = GameObject.Find("PlayerHealthBar");
        xOffset = playerHPBar.transform.position.x;
        yOffset = playerHPBar.transform.position.y;
        playerHPBar.transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, 0);
    }

    // Update is called once per frame
    void Update()
    {
        playerHPBar.transform.position = new Vector3(player.transform.position.x+xOffset, player.transform.position.y+yOffset, 0);
    }
}
