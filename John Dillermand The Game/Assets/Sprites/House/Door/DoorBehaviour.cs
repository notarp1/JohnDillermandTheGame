using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public Sprite doorClosed;
    public Sprite doorOpened;
    SpriteRenderer sr;
    public bool isOnCollider = false;

    private bool isOpened = false;
  
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
     
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetKeyDown("e") && isOnCollider)
            {
                if (!isOpened)
                {
                    GetComponent<BoxCollider2D>().isTrigger = true;
                    setDoorOpen();              
                    isOpened = true;
                }
                else
                {
                    GetComponent<BoxCollider2D>().isTrigger = false;
                    setDoorClosed();                
                    isOpened = false;
                }
            }

        
    }

    void setDoorOpen() {
        sr.sprite = doorOpened;
    }
    public void setLayer(int number) {
        sr.sortingOrder = number;
    }
    public void setDoorClosed()
    {
        sr.sprite = doorClosed;
        GetComponent<BoxCollider2D>().isTrigger = false;
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
        isOnCollider = false;     
    }

}
