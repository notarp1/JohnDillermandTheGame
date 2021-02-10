using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviour : MonoBehaviour
{
    public Sprite chestClosed;
    public Sprite chestOpened;
    GameObject chest;
    SpriteRenderer sr;
    private bool isOnCollider = false;
    private bool isOpened = false;


    // Start is called before the first frame update
    void Start()
    {
       
       sr = gameObject.GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnCollider)
        {

            if (Input.GetKeyDown("e"))
            {
                if (!isOpened){
                    setChestOpen();
                    isOpened = true;
                } else {
                    setChestClosed();
                    isOpened = false;
                }
            }
           
        }
    }

    public void setChestOpen()
    {
        sr.sprite = chestOpened;
    }
    public void setChestClosed()
    {
        sr.sprite = chestClosed;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        isOpened = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        isOnCollider = true;


    }

    void OnTriggerExit2D(Collider2D other)
    {
        setChestClosed();
        isOnCollider = false;
    }
}
