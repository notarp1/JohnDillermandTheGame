using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRange : MonoBehaviour
{
    private GameObject player;
    private List<GameObject> enemiesInRange = new List<GameObject>();
    private float factorSize;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemiesInRange = new List<GameObject>();
        float startCircleRange = this.GetComponent<CircleCollider2D>().radius;
        factorSize = this.GetComponent<SpriteRenderer>().size.x / startCircleRange;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setRange(float range)
    {
        SpriteRenderer spr = this.GetComponent<SpriteRenderer>();
        spr.drawMode = SpriteDrawMode.Sliced;
        spr.size = new Vector2(range*factorSize, range*factorSize);
        this.GetComponent<CircleCollider2D>().radius = range;
    }

    public List<GameObject> getAllEnemiesInRange()
    {
        return this.enemiesInRange;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("enemy") && !collision.name.Equals("Range"))
        {
            if (!enemiesInRange.Contains(collision.gameObject))
            {
                enemiesInRange.Add(collision.gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemiesInRange.Remove(collision.gameObject);
    }

    private void printEnemies()
    {
        foreach (GameObject enemy in enemiesInRange)
        {
            Debug.Log(enemy+"\t"+enemy.tag);
        }
    }

}
