using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalKeyPresses : MonoBehaviour
{
    public GameObject escapeMenu;

    public GameObject questUI;

    public QuestGiver questGiver;

    public HotbarChooser hotbarChooser;

    public PlayerMovement movement;

    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        hotbarChooser.setChildNumber(0);
    }

    // Update is called once per frame
    void Update()
    {
        /**
         * This is for moving the player
         *
         */



        /**
         * This is to open the pause menu
         * Timescale will be set to 0 to pause environment
         */
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (questUI.activeSelf)
            {
                questUI.SetActive(false);
            }
            escapeMenu.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
        }

        /**
         * This is to open quest tab
         * Timescale will be set to 0 to pause environment or 1 to reenable environment
         */
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!escapeMenu.activeSelf)
            {
                questUI.SetActive(!questUI.activeSelf);
                Time.timeScale = Time.timeScale == 0 ? 1 : 0;
                isPaused = !isPaused;
            }    
        }

        /**
         * This is the interact button
         * If player can get a quest get one
         */
        if (Input.GetKeyDown(KeyCode.E) && !isPaused)
        {
            if (questGiver.getPlayerIsInRange() && questGiver.getIsReadyToGiveQuest())
            {
                questGiver.giveQuestToPlayer();
            }   
        }


        /**
         * These are for setting the hotbar item
         */
        if (Input.GetKey(KeyCode.Alpha1) && !isPaused)
        {
            hotbarChooser.setChildNumber(0);
        }
        if (Input.GetKey(KeyCode.Alpha2) && !isPaused)
        {
            hotbarChooser.setChildNumber(1);
        }
        if (Input.GetKey(KeyCode.Alpha3) && !isPaused)
        {
            hotbarChooser.setChildNumber(2);
        }
        if (Input.GetKey(KeyCode.Alpha4) && !isPaused)
        {
            hotbarChooser.setChildNumber(3);
        }
        if (Input.GetKey(KeyCode.Alpha5) && !isPaused)
        {
            hotbarChooser.setChildNumber(4);
        }
        if (Input.GetKey(KeyCode.Alpha6) && !isPaused)
        {
            hotbarChooser.setChildNumber(5);
        }
        if (Input.GetKey(KeyCode.Alpha7) && !isPaused)
        {
            hotbarChooser.setChildNumber(6);
        }
        if (Input.GetKey(KeyCode.Alpha8) && !isPaused)
        {
            hotbarChooser.setChildNumber(7);
        }
        if (Input.GetKey(KeyCode.Alpha9) && !isPaused)
        {
            hotbarChooser.setChildNumber(8);
        }
        if (Input.GetKey(KeyCode.Alpha0) && !isPaused)
        {
            hotbarChooser.setChildNumber(9);
        }

        /**
         * These are to choose the hotbar item with the scrollwhell
         */
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && !isPaused)
        {
            int inventoryItemNr = hotbarChooser.getChildNumber();
            inventoryItemNr--;
            if (inventoryItemNr < 0 || inventoryItemNr == -1)
            {
                inventoryItemNr = 9;
            }
            hotbarChooser.setChildNumber(inventoryItemNr);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && !isPaused)
        {
            int inventoryItemNr = hotbarChooser.getChildNumber();
            inventoryItemNr++;
            if (inventoryItemNr < 0 || inventoryItemNr == -1)
            {
                inventoryItemNr = 9;
            }
            hotbarChooser.setChildNumber(inventoryItemNr);
        }


        /**
         * Use item in hotbar when pressing the left click
         */
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isPaused)
        {
            hotbarChooser.useHotbarItem();
        }


    }
}
