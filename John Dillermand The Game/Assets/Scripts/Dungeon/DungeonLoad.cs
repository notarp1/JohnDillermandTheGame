using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonLoad : MonoBehaviour
{
    private bool isOnCollider = false;
    GameObject spawn, player;
    public GameObject myPrefab;
    SpriteRenderer sr;
    BoxCollider2D bx;
    public Sprite doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        spawn = transform.Find("SpawnPoint").gameObject;
        player = GameObject.Find("Player");
        sr = gameObject.GetComponent<SpriteRenderer>();
        bx = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnCollider)
        {

            if (Input.GetKeyDown("e"))
            {
                SceneManager.SetActiveScene(gameObject.scene);
                Instantiate(myPrefab, spawn.transform.position, Quaternion.identity);
                sr.sprite = doorOpen;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                SceneManager.SetActiveScene(player.scene);
                player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 2);
               
            }

        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag.Equals("Hitbox"))
        {
            Debug.Log("Player at chest");
            isOnCollider = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Hitbox"))
        {
            Debug.Log("Player left chest");
            isOnCollider = false;
        }
    }
}

