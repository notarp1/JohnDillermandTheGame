using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    GameObject target, arrow;
    Rigidbody2D rb;
    float timer = 0;
    float timerThreshold = 2f;

    PlayerAttributes pa;



    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        arrow = this.gameObject;
        pa = target.GetComponent<PlayerAttributes>();
        float posX = GetComponentInParent<Transform>().position.x;
        float posY = GetComponentInParent<Transform>().position.y;
        float posXplayer = target.GetComponent<Transform>().position.x;
        float posYplayer = target.GetComponent<Transform>().position.y;

        float b = posXplayer - posX;
        float a = posYplayer - posY;

        float z = (a * a) + (b*b);
        float c = Mathf.Sqrt(z);


        //Debug.Log("A = " + a);
        //Debug.Log("B = " + b);
        //Debug.Log("C = " + c);
   

        float vinkel = ((b * b) + (c * c) - (a * a));
        float test = 2 * b * c;
        float result = vinkel / test;
        float rad = Mathf.Acos(result);
        float deg = rad * Mathf.Rad2Deg;

        //Debug.Log("Vinkel = " + deg);
       
            if (posYplayer > posY) transform.Rotate(0, 0, deg);
            else transform.Rotate(0, 0, -deg);

        







    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
   
       

        if (timer > timerThreshold) {
            Destroy(arrow);
        }

    }

    private void FixedUpdate()
    {
       
        rb.AddForce(transform.right * 35f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.name == "DamageHitbox")
        {
            pa.dealDamage(10);
            Destroy(arrow);
        }
        else if(collision.tag != "enemy" && collision.tag != "weaponRange") Destroy(arrow);
    }



}
