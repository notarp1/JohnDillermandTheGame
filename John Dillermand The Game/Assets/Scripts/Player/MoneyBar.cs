using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBar : MonoBehaviour
{
    private TextMeshProUGUI moneyBarText;
    // Start is called before the first frame update
    void Start()
    {
        moneyBarText = GameObject.Find("MoneyBarAmountText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setMoneyBar(int moneyValue)
    {
        moneyBarText.SetText(moneyValue + "");
    }
}
