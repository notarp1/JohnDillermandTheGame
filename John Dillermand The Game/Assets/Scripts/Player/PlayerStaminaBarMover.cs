using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStaminaBarMover : MonoBehaviour
{
    private GameObject player;

    private GameObject playerStaminaBar;

    private float xOffset;

    private float yOffset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerStaminaBar = GameObject.Find("PlayerStaminaBar");
        xOffset = playerStaminaBar.transform.position.x;
        yOffset = playerStaminaBar.transform.position.y;
        playerStaminaBar.transform.position = new Vector3(player.transform.position.x + xOffset,
            player.transform.position.y + yOffset, 0);
    }

    // Update is called once per frame
    void Update()
    {
        playerStaminaBar.transform.position = new Vector3(player.transform.position.x + xOffset,
            player.transform.position.y + yOffset, 0);
    }
}