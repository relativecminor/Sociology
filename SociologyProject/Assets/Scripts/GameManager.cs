using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject moneyTextBox;

    public int money;
    private int morality;

    // Start is called before the first frame update
    void Start()
    {
        morality = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMoney(int amount)
    {
        money = money + amount;
        if (money < 0 || money > 9999999) { money = 0; }
        moneyTextBox.GetComponent<TextMeshProUGUI>().text = "Money: " + money.ToString();
    }

    public void ChangeMOrality(int amount)
    {
        morality = morality + amount;
    }

}
