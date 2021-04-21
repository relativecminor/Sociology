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
    private int openPolicy;

    private string[] policyTitle = new string[] {
        "Free Lunch Program",
        "Extended Bus Routes",
        "Voucher System",
        "4", "5", "6", "7", "8", "9",
    // school policies 
        "School Resource Officer (SRO)",
        "Dress Code",
        "Zero Tolerance Disciplin",
        "Critical Conversation Space",
        "IQ testing",
        "6",
        "7",
        "8",
        "9"
    };
    private string[] policyDescription = new string[] {
        "The government pays for free lunches for public schools",
        "Bus routes have a longer reach to pick up kids living further from schools",
        "Allows public money to follow students to private schools",
        "4", "5", "6", "7", "8", "9",
    // school policies 
     "Give your school a School Resource Officer (SRO)",
        "Enact a dress code policy",
        "Create a zero tolerance disoplinary policy",
        "Create Critical Conversation Spaces for students",
        "Use IQ testing to select kids for gift education services",
        "6",
        "7",
        "8",
        "9"
    };
    private int[] policyCost = new int[] {
        2000,
        1500,
        1200,
        0,
        0,
        0,
        0,
        0,
        0,
        //school policies
        2000,
        1500,
        1200,
        0,
        0,
        0,
        0,
        0,
        0};
    private bool[] policyPurchased = new bool[] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

   
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

    public void purchasePolicy()
    {
        if (money >= policyCost[openPolicy])
        {
            ChangeMoney(policyCost[openPolicy] * -1);
            policyPurchased[openPolicy] = true;
            Debug.Log("Purchased Policy " + openPolicy);
        }
    }

    public void activePolicy(int policyNumber)
    {
        openPolicy = policyNumber;
    }

    public string getPolicyTitle(int policyNumber) { return policyTitle[policyNumber]; }
    public string getPolicyDescription(int policyNumber) { return policyDescription[policyNumber]; }
    public int getPolicyCost(int policyNumber) { return policyCost[policyNumber];  }
    public bool getPolicyPurchased(int policyNumber) { return policyPurchased[policyNumber];  }

    
}
