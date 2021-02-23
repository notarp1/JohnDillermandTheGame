using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HotbarChooser : MonoBehaviour
{
    private GameObject hotbar_hotbar;

    private int inventoryItemNr = -1;
    // Start is called before the first frame update
    void Start()
    {
        hotbar_hotbar = GameObject.Find("Hotbar_hotbar");
        /*int children = hotbar_hotbar.transform.childCount;
        for (int i = 0; i < children; i++)
        {
            //Debug.Log(hotbar_hotbar.transform.GetChild(i) + " " + i);
            Transform child1 = hotbar_hotbar.transform.GetChild(i);
            Transform child2 = child1.GetChild(0);
            TextMeshProUGUI text = child2.GetChild(0).GetComponent<TextMeshProUGUI>();
            text.SetText(((i+1)%10)+"");
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        int childNumber = -1;
        if (Input.GetKey(KeyCode.Alpha1))
        {
            childNumber = 0;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            childNumber = 1;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            childNumber = 2;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            childNumber = 3;
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            childNumber = 4;
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            childNumber = 5;
        }
        if (Input.GetKey(KeyCode.Alpha7))
        {
            childNumber = 6;
        }
        if (Input.GetKey(KeyCode.Alpha8))
        {
            childNumber = 7;
        }
        if (Input.GetKey(KeyCode.Alpha9))
        {
            childNumber = 8;
        }
        if (Input.GetKey(KeyCode.Alpha0))
        {
            childNumber = 9;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (this.inventoryItemNr != -1)
            {
                hotbar_hotbar.transform.GetChild(inventoryItemNr).GetComponent<HotbarItemUser>().useItem();
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            inventoryItemNr--;
            if (inventoryItemNr < 0 || inventoryItemNr == -1)
            {
                inventoryItemNr = 9;
            }
            childNumber = inventoryItemNr;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            inventoryItemNr++;
            if (inventoryItemNr > 9 || inventoryItemNr == -1)
            {
                inventoryItemNr = 0;
            }
            childNumber = inventoryItemNr;
        }



        if (childNumber != -1)
        {
            this.inventoryItemNr = childNumber;
            Image billede = hotbar_hotbar.transform.GetChild(childNumber).GetComponent<Image>();
            billede.color = new Color32(110, 241, 121, 148);
            for (int i = 0; i < hotbar_hotbar.transform.childCount; i++)
            {
                if (i != childNumber)
                {
                    hotbar_hotbar.transform.GetChild(i).GetComponent<Image>().color = new Color32(63, 63, 63, 148);
                }
            }
        }
    }

    


}
