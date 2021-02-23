using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
        healthBar.maxValue = 100;
        healthBar.value = healthBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setHealthBar(int healthValue)
    {
        healthBar.value = healthValue;
        GameObject.Find("HealthBarAmountText").GetComponent<TextMeshProUGUI>().SetText(healthBar.value+"");
    }

}
