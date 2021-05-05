using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using static PolicyObject;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public GameObject moneyTextBox;
    public int money;
    public int progress;
    private int openPolicy;
    //public DialogueController dialogueController; // Needed to start dialogue
    public GameObject mainMenu;
    public GameObject endScreen;
   // public GameObject policyScreen;

    //public int curChapterIndex;
    //public GameObject[] chapters;
    public DialogueViewer dialogueViewer;
    public GameObject pauseMenu;
    public bool gamePaused = false;
    public bool macLineEndings = false;
    string delimeter = "\r\n";
    public List<Policy> activeSchoolPolicies = new List<Policy>();

    public List<Policy> schoolPolicies = new List<Policy>();
    [SerializeField] TextAsset policies;
    // bool isPlaying = false;

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
        progress = 0;
        PolicyObject policyObject = new PolicyObject();
        
        if (macLineEndings) { delimeter = "\n"; }
        schoolPolicies = policyObject.ParsePolicies(policies, delimeter);
        foreach (Policy policy in schoolPolicies)
        {
            Debug.Log("Name: " + policy.name);
            Debug.Log("Cost: " + policy.cost);
            Debug.Log("--");

        }

        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
        endScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Toggle pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gamePaused)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    /*public GameObject GetCurChapter()
    {
        return chapters[curChapterIndex];
    }*/

    public void StartGame()
    {
        mainMenu.SetActive(false);
        // TODO: Add assertion
        //curChapterIndex = 0;

        //chapters[curChapterIndex].SetActive(true);
        dialogueViewer.InitializeDialogue();

        money = 0;
        ChangeMoney(1000);
        progress = 0;

        // isPlaying = true;
        // TODO: Reset purchased policies
    }

    /*public void NextChapter()
    {
        if (curChapterIndex < chapters.Length - 1)
        {
            chapters[curChapterIndex].SetActive(false);
            chapters[curChapterIndex].SetActive(true);
        }

    }*/

    public void Pause()
    {
        gamePaused = true;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        gamePaused = false;
        pauseMenu.SetActive(false);
    }

    public void MainMenu()
    {
        gamePaused = false;
        pauseMenu.SetActive(false);
        endScreen.SetActive(false);
        mainMenu.SetActive(true);
        //policyScreen.SetActive(false);
        progress = 0;
        money = 1000;
        ChangeMoney(0);
    }

    public void EndGame()
    {
        endScreen.SetActive(true);
        mainMenu.SetActive(false);
        
    }

    public void ChangeMoney(int amount)
    {
        money += amount;
        moneyTextBox.GetComponent<TextMeshProUGUI>().text = money.ToString();
    }

    public void ChangeProgress(int amount)
    {
        progress += amount;
    }

    public Policy FindPolicy(string name)
    {
        foreach (Policy policy in schoolPolicies)
        {
            if (policy.name == name) return policy;
        }
        return null;
    }

    public bool IsActiveSchoolPolicy(string policyName)
    {
        foreach (Policy policy in activeSchoolPolicies)
        {
            if (policy.name == policyName)
                return true;
        }
        return false;
    }

    public bool IsAvailable(string policyName)
    {
        Policy policy = FindPolicy(policyName);
        return IsEnoughMoney(policy) && ConditionsMet(policy);
    }

    private bool IsEnoughMoney(Policy policy)
    {
        return policy.cost <= money;
    }

    private bool ConditionsMet(Policy policy)
    {
        foreach (string condition in policy.requires)
        {
            if (!PolicyManager.Instance.IsActive(condition)) { return false; }
        }
        return true;
    }

    public void ActivatePolicy(Policy policy)
    {
        foreach ((string Name, int Value) action in policy.actions)
        {
            if (action.Name == "money")
            {
                ChangeMoney(action.Value);
            }
            else
            {
                ChangeProgress(action.Value);
            }
        }
        activeSchoolPolicies.Add(policy);
    }

    /*public void StartGame()
    {
        mainMenu.SetActive(false);
        dialogueController.StartDialogue();
    }*/

    // Policy stuff
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
    public int getPolicyCost(int policyNumber) { return policyCost[policyNumber]; }
    public bool getPolicyPurchased(int policyNumber) { return policyPurchased[policyNumber]; }


    public IEnumerator LoadYourAsyncScene(string scene)
    {        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

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


    //public bool IsActive(string title)
    //{
     //   Debug.Log(title);
    //    return policyPurchased[Array.IndexOf(policyTitle, title)];
   // }
}
