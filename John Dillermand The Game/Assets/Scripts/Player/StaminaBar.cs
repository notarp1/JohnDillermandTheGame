using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        staminaBar.maxValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setStaminaBar(int staminaValue)
    {
        staminaBar.maxValue = 100;
        staminaBar.value = staminaValue;
        GameObject.Find("StaminaBarAmountText").GetComponent<TextMeshProUGUI>().SetText(staminaBar.value + "");

    }

}
