using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggersDoor : MonoBehaviour
{
    GameObject door, player, roof;
    GameObject [] wall;
    DoorBehaviour db;
    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Door");
        player = GameObject.Find("Player");
        wall = GameObject.FindGameObjectsWithTag("wall");
        db = door.GetComponent<DoorBehaviour>();
        roof = GameObject.FindGameObjectWithTag("roof");

    }

    // Update is called once per frame
    void Update()
    {
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (this.name == "HBDoorFront" && other.tag == "Player")
        {
            //db.setLayer(1);
            db.setDoorClosed();
            player.GetComponent<SpriteRenderer>().sortingOrder = 3;

            db.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            roof.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            foreach (GameObject obWall in wall)
            {
                obWall.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        
            }
        }
        else if (this.name == "HBDoorBack" && other.tag == "Player") {

            player.GetComponent<SpriteRenderer>().sortingOrder = 0;
            db.setDoorClosed();
            db.isOnCollider = false;
            db.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .7f);
            roof.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            foreach (GameObject obWall in wall) {
            
               
                obWall.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .7f);
            }
            
        } 
    }
}
