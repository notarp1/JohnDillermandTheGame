using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    bool isOnTrigger = false;
    public GameObject player;
    private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnTrigger) {
            float step = speed * Time.deltaTime;
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, player.transform.position, step);
        }
     
    }   


        private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            isOnTrigger = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isOnTrigger = false;
        }
    }
}
