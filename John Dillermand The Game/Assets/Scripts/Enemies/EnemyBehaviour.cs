using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject player, arrow;
    private Rigidbody2D rb, arrowRB;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       // float posX = this.GetComponent<Transform>().position.x;
       // float posY = this.GetComponent<Transform>().position.y;

        //float posXplayer = player.GetComponent<Transform>().position.x;
       // float posYplayer = player.GetComponent<Transform>().position.y;
        /*
        if (posXplayer <= posX + 2f) {
            //rb.MovePosition(rb.position + new Vector2(-5f, 0) * Time.fixedDeltaTime);
            Instantiate(arrow, new Vector2(posX, posY), Quaternion.identity);
            arrowRB = arrow.GetComponent<Rigidbody2D>();

           
        } */
        
    }
}
