using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger2D : MonoBehaviour
{
   
    string currentHB, facingObject;
    public static OnTrigger2D instance;


    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setString(string name) {
        this.currentHB = name;
    }

    public string getString()
    {
        return currentHB;
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(this.gameObject.name + " Collider med: " + other.name);

    }
    void OnTriggerStay2D(Collider2D other)
    {
        
       
    }
    void OnTriggerExit2D(Collider2D other)
    {
        
    }


}
