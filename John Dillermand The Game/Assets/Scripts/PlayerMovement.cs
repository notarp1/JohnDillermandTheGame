using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject player, up, down, left, right;
    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    public float speed;
    OnTrigger2D refScript;
    private float addX = 0f;
    private float addY = 0f;
    public string rotation;
    private bool behindObject = false;
    public bool facingRight = true; //Depends on if your animation is by default facing right or left


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();

        up = GameObject.Find("HitboxUp");
        down = GameObject.Find("HitboxDown");
        left = GameObject.Find("HitboxLeft");
        right = GameObject.Find("HitboxRight");
        rb = player.GetComponent<Rigidbody2D>();
        col = player.GetComponent<BoxCollider2D>();
        up.SetActive(false);
        down.SetActive(false);
        left.SetActive(false);
        right.SetActive(false);

        refScript = right.GetComponent<OnTrigger2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (behindObject) player.GetComponent<SpriteRenderer>().sortingOrder = 0;
        else player.GetComponent<SpriteRenderer>().sortingOrder = 2;




    }
    private void FixedUpdate()
    {
        movePlayer();

        float h = Input.GetAxis("Horizontal");
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "behind" && col.IsTouching(collision))
        {
       
            behindObject = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "behind")
        {
           
            behindObject = false;
        }
    }


        private void movePlayer()
    {
        if (!Input.anyKey) anim.Play("Idle");
        if (Input.GetKey(KeyCode.W))
        {

            EnableHitbox("up");
            anim.Play("JohnWalkingBack");
            addY += speed;

        }
        if (Input.GetKey(KeyCode.A))
        {
            EnableHitbox("left");
            anim.Play("JohnAnimation");
            addX -= speed;
           // Vector3 move = new Vector3(-speed * Time.deltaTime, 0, 0);
           // transform.position += move;
        }
        if (Input.GetKey(KeyCode.D))
        {
            EnableHitbox("right");
            anim.Play("JohnAnimation");
            addX += speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
    
            EnableHitbox("down");
            anim.Play("JohnWalkingFront");
            addY -= speed;
        }

        rb.MovePosition(rb.position + new Vector2(addX, addY) * Time.fixedDeltaTime);
        addX = 0f;
        addY = 0f;
    }

    void EnableHitbox(string name)
    {
        if (name == "left")
        {
            refScript.setString("left");   
            left.SetActive(true);
            right.SetActive(false);
            down.SetActive(false);
            up.SetActive(false);    
        }
        else if (name == "right")
        {
            refScript.setString("right");
            right.SetActive(true);
            left.SetActive(false);
            down.SetActive(false);
            up.SetActive(false);
        }
        else if (name == "up")
        {

            refScript.setString("up");
            up.SetActive(true);
            left.SetActive(false);
            right.SetActive(false);
            down.SetActive(false);
       
        }
        else if (name == "down")
        {
            refScript.setString("down");
            left.SetActive(false);
            right.SetActive(false);
            down.SetActive(true);
            up.SetActive(false);

        }

        this.rotation = name;

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public string getHitBox()
    {
        return this.rotation;
    }


}
