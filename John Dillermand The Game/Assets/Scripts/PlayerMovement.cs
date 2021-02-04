using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject player;
    private Animator anim;

    float x = 0f;
    float y = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        if (!Input.anyKey) {
            anim.Play("Idle");
        }
        if (Input.GetKey("d") && x < 6.8)
        {
            anim.Play("PlayerAnimation");
            x = x + 0.005f;
            player.transform.position = new Vector3(x, y, -0.01f);
        }
        if (Input.GetKey("a") && x > -6.8)
        {
            anim.Play("PlayerAnimation");
            x = x - 0.005f;
            player.transform.position = new Vector3(x, y, -0.01f);
        }
        if (Input.GetKey("w") && y < 6.5)
        {
            anim.Play("PlayerAnimation");
            y = y + 0.005f;
            player.transform.position = new Vector3(x, y, -0.01f);
        }
        if (Input.GetKey("s") && y > -6.5)
        {
            anim.Play("PlayerAnimation");
            y = y - 0.005f;
            player.transform.position = new Vector3(x, y, -0.01f);
        }
    }
}
