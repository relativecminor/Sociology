using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject moneyTextBox;

    public int money;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMoney(int amount)
    {
        money = money + amount;
        if (money < 0) { money = 0; }
        moneyTextBox.GetComponent<TextMeshProUGUI>().text = "Money: " + money.ToString();
    }

}
