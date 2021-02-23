using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeScript : MonoBehaviour
{

    public GameObject arrow;
    bool isOnTrigger = false;
 
    float timer = 0;
    float timerThreshold = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isOnTrigger) {   
            timer += Time.deltaTime;

           
        }
        if (timer > timerThreshold)
        {
          
            timer = 0;
          
            float posX = GetComponentInParent<Transform>().position.x;
            float posY = GetComponentInParent<Transform>().position.y;
            Instantiate(arrow, new Vector2(posX, posY), Quaternion.identity);
 

        }
        
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if(collision.tag == "Player")
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
