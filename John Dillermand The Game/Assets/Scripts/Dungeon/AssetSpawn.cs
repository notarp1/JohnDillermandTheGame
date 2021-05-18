using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetSpawn : MonoBehaviour
{

    SpriteRenderer sr;
    public GameObject spr1, spr2, spr3, spr4, spr5, spr6, spr7, spr8, spr9, spr10;
    private GameObject myPrefab;
    ArrayList prefab;
    public int chance;
    public bool doChance;
    // Start is called before the first frame update
    void Start()
    {
        prefab = new ArrayList();

        if (spr1 != null) prefab.Add(spr1);
        if (spr2 != null) prefab.Add(spr2);
        if (spr3 != null) prefab.Add(spr3);
        if (spr4 != null) prefab.Add(spr4);
        if (spr5 != null) prefab.Add(spr5);
        if (spr6 != null) prefab.Add(spr6);
        if (spr7 != null) prefab.Add(spr6);
        if (spr8 != null) prefab.Add(spr6);
        if (spr9 != null) prefab.Add(spr6);
        if (spr10 != null)prefab.Add(spr6);
        

  

        int f = Random.Range(1, chance+1);

       
        int r = Random.Range(1, prefab.Count+1);
        
        myPrefab = (GameObject)prefab[r - 1];
        if (doChance)
        {
            if (f != 1) Instantiate(myPrefab, this.transform.position, Quaternion.identity);
        } else Instantiate(myPrefab, this.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
