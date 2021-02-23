using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject player;
    private Animator anim;
    private Rigidbody2D rigidbody;

    float x = 0f;
    float y = 0f;
    private float addX = 0f;
    private float addY = 0f;
    public bool facingRight = true; //Depends on if your animation is by default facing right or left
    float speed = 5f;
    public String rotation;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        rigidbody = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        //Debug.Log(rigidbody.position.x + "\t" + rigidbody.position.y);
        if (!Input.anyKey) {
            anim.Play("Idle");
        }
        if (Input.GetKey("d"))
        {
            anim.Play("JohnAnimation");
            x = x + 0.005f;
            //player.transform.position = new Vector3(x, y, -0.01f);
            addX += speed;
            rotation = "r";
        }
        if (Input.GetKey("a"))
        {
            FixedUpdate();
            anim.Play("JohnAnimation");
            x = x - 0.005f;
            //player.transform.position = new Vector3(x, y, -0.01f);
            addX -= speed;
            rotation = "l";
        }
        if (Input.GetKey("w"))
        {
            anim.Play("JohnAnimation");
            y = y + 0.005f;
            //player.transform.position = new Vector3(x, y, -0.01f);
            addY += speed;
            rotation = "u";
        }
        if (Input.GetKey("s"))
        {
            anim.Play("JohnAnimation");
            y = y - 0.005f;
            //player.transform.position = new Vector3(x, y, -0.01f);
            addY -= speed;
            rotation = "d";
        }
        rigidbody.MovePosition(rigidbody.position + new Vector2(addX, addY) * Time.fixedDeltaTime);
        addX = 0f;
        addY = 0f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((-3.5 < rigidbody.position.x && rigidbody.position.x < -1) && (2.5 > rigidbody.position.y && rigidbody.position.y > 1.2))
        {
            player.transform.position = new Vector3(-57.2f, -6f, -0.01f);
        }
        else if ((-59 < rigidbody.position.x && rigidbody.position.x < -56) && (-2.5 > rigidbody.position.y && rigidbody.position.y > -4.5))
        {
            player.transform.position = new Vector3(-1.4f, -0.1f, -0.01f);
        }

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if ((-3.5 < rigidbody.position.x && rigidbody.position.x < -1) && (2.5 > rigidbody.position.y && rigidbody.position.y > 1.2))
        {
            player.transform.position = new Vector3(-57.2f, -6f, -0.01f);
        }
        else if ((-59 < rigidbody.position.x && rigidbody.position.x < -56) && (-2.5 > rigidbody.position.y && rigidbody.position.y > -4.5))
        {
            player.transform.position = new Vector3(-1.4f, -0.1f,-0.01f);
        }

    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
    }

}
