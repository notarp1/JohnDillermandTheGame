using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIQuest : MonoBehaviour
{
    private Quest currentQuest;
    public Image checkBoxImage;
    public TextMeshProUGUI checkBoxText;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descText;
    public Sprite checkMark;
    public Sprite redCross;
    public PlayerInventory inven;
    public PlayerAttributes attr;

    void Start()
    {
        checkBoxImage.sprite = redCross;
        setQuest(currentQuest);
    }

    public void setQuest(Quest quest)
    {
        if (quest != null)
        {
            this.currentQuest = quest;
            setTitle(quest.getTitle());
            string description = "";
            switch (quest.getObjective())
            {
                case objectives.kill:
                    description += "Kill " + quest.getStartValue() + " ";
                    break;
                case objectives.pickup:
                    description += "Pick up " + quest.getStartValue() + " ";
                    break;
                case objectives.discoverlocation:
                    description += "Discover ";
                    break;
                case objectives.gotolocation:
                    description += "Go to ";
                    break;
            }

            switch (quest.getObjectInQuest())
            {
                case objectsInQuest.enemy:
                    description += "enemie(s)";
                    break;
                case objectsInQuest.poison:
                    description += "poison bottle(s)";
                    break;
                case objectsInQuest.potion:
                    description += "potion bottle(s)";
                    break;
                case objectsInQuest.johnHouse:
                    description += "John's house";
                    break;
            }
            setDesc(description);
            checkBoxText.text = currentQuest.getStartValue() - currentQuest.getAmountLeft() + "/" + currentQuest.getStartValue();
            if (currentQuest.getAmountLeft() == 0)
            {
                checkBoxText.text += "\nFinished";
                checkBoxImage.sprite = checkMark;
            }
            else
            {
                checkBoxText.text += "\nNot finished";
                checkBoxImage.sprite = redCross;
            }

        }
        else clearQuest();
    }

    public void updateQuest(Quest quest)
    {
        currentQuest = quest;
        checkBoxText.text = currentQuest.getStartValue()-currentQuest.getAmountLeft() + "/" + currentQuest.getStartValue();
        if (currentQuest.getAmountLeft() == 0)
        {
            checkBoxText.text += "\nFinished";
            checkBoxImage.sprite = checkMark;
        } else checkBoxText.text += "\nNot finished";

    }

    public Quest getQuest()
    {
        return this.currentQuest;
    }

    public void setTitle(string text)
    {
        titleText.text = text;
    }

    public void setDesc(string text)
    {
        descText.text = text;
    }

    private void clearQuest()
    {
        setTitle("");
        setDesc("");
        checkBoxText.text = "";
        checkBoxImage.sprite = null;
    }

    public void getReward()
    {
        if (currentQuest != null)
        {
            if (currentQuest.getAmountLeft() == 0)
            {
                currentQuest.giveReward(inven, attr);
            }
        }
    }

}
