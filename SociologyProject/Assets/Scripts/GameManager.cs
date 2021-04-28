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

    public GameObject dialogueManager;
    public GameObject events;

    public bool choiceA = false;
    public bool choiceB = false;
    public bool choiceC = false;
    public bool choiceD = false;
    public bool choiceE = false;
    public bool choiceF = false;
    public bool choiceG = false;
    public bool choiceH = false;
    public bool choiceI = false;
    public bool choiceJ = false;


    public GameObject chapteronebackground;
    public GameObject chaptertwobackground;
    public GameObject chapterthreebackground;
    public GameObject chapterfourbackground;
    public GameObject endscreen;
    public GameObject schoolbackground;
    public GameObject cutscene;

    public bool chap1;
    public bool chap1done;
    public bool chap2done;
    public bool chap3done;
    public bool chap4done;

    public Canvas dialoguecanvas;
    public Canvas canvas;
  

    private string[] policyTitle = new string[] {
        "Free Lunch Program",
        "Extended Bus Routes",
        "Voucher System",
        "FAFSA", 
        "Career and Technical Education Program", 
        "Establish Magnet Schools", 
        "Federal Cultural Competency Training", 
        "Title IX Training", 
        "After School Program",
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
        "Provides financial support for students pursuing higher education based on need.",
        "Establish an Office of Civil Rights in the CTE that works to close the discrimination gap in STEM fields.",
        "Allow for publicly funded schools that draw students from a variety of school districts under a specialized curriculum.",
        "A government funded program that will support schools with cultural competency training should they request it.",
        "Require all schools to follow the guidelines of Title IX relating to discrimination based on sex.",
        "Fund schools to host programs for students who may not be able to return home immediately after school.",
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
        1000,
        2000,
        1500,
        2000,
        2000,
        1500,
        1000,
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
            DontDestroyOnLoad(dialogueManager);
            DontDestroyOnLoad(events);
        }
        else
        {
            Destroy(gameObject);
            Destroy(dialogueManager);
            Destroy(events);
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
    //public void testButton2()
    //{
    //    Debug.Log(choiceA);
   // }

    public string getPolicyTitle(int policyNumber) { return policyTitle[policyNumber]; }
    public string getPolicyDescription(int policyNumber) { return policyDescription[policyNumber]; }
    public int getPolicyCost(int policyNumber) { return policyCost[policyNumber];  }
    public bool getPolicyPurchased(int policyNumber) { return policyPurchased[policyNumber];  }


    public IEnumerator LoadYourAsyncScene(string scene)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }


/**
public void nextchapter()
{
    if (chap1)
        { chapteronebackground.SetActive(true);
            schoolbackground.SetActive(false);
            dialoguecanvas.enabled = true;
            Debug.Log("chap1 is here");
        }
    if (chap1done)
    {
        chapteronebackground.SetActive(false);
        chaptertwobackground.SetActive(true);
        schoolbackground.SetActive(false);
        dialoguecanvas.enabled = true;
        
        Debug.Log("chapter2 is here");
    }
    if (chap2done)
    {
        chaptertwobackground.SetActive(false);
        chapterthreebackground.SetActive(true);
        
    }
    if (chap3done)
    {
        chapterthreebackground.SetActive(false);
        chapterfourbackground.SetActive(true);
        
    }
    if (chap4done)
    {
        chapterfourbackground.SetActive(false);
        //endscreen.SetActive(true);
        
    }
}
**/

}
