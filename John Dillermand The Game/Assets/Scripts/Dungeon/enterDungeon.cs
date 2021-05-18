using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterDungeon : MonoBehaviour
{
    private bool isOnCollider = false;
    public int scene;
    public int sceneUnload;

    bool loaded;
    bool unloaded;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
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
