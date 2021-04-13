using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject moneyTextBox;
    public int money;
    private int morality;

    private string[] policyTitle = new string[] {
        "Free Lunch Program",
        "Extended Bus Routes" };
    private string[] policyDescription = new string[] {
        "The government pays for free lunches for public schools",
        "Bus routes have a longer reach to pick up kids living further from schools" };
    private int[] policyCost = new int[] {
        2000,
        1500 };
    private bool[] policyPurchased = new bool[] { false, false };

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
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

    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
