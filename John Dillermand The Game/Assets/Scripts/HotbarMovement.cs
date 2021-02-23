using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarMovement : MonoBehaviour
{
    private GameObject player;

    private GameObject hotbar_canvas;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        hotbar_canvas = GameObject.Find("Hotbar_canvas");
    }

    // Update is called once per frame
    void Update()
    {
        hotbar_canvas.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0f);
    }
}
