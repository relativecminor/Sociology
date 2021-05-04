using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using static PolicyObject;

public class PolicyManager : MonoBehaviour
{
    public static PolicyManager Instance { get; private set; }

    public Animator policyAnimator;
    public Canvas policyCanvas;
    public Canvas dialogueCanvas;

    public GameObject moneyTextBox;
    public int money;

    private int openPolicy;

    // Start is called before the first frame update
    void Start()
    {
        
    }
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

    public string getPolicyTitle(int policyNumber) { return policyTitle[policyNumber]; }
    public string getPolicyDescription(int policyNumber) { return policyDescription[policyNumber]; }
    public int getPolicyCost(int policyNumber) { return policyCost[policyNumber]; }
    public bool getPolicyPurchased(int policyNumber) { return policyPurchased[policyNumber]; }

    public void printPolicyPurchased(int policyNumber) { Debug.Log(policyPurchased[policyNumber]); }


    public void OpenPolicy()
    {
        dialogueCanvas.enabled = false;
        policyCanvas.enabled = true;
       // cutScene.enabled = false;
        policyAnimator.SetBool("isOpen", true);
    }

    public void ClosePolicy()
    {
        dialogueCanvas.enabled = true;
        policyCanvas.enabled = false;
        //cutScene.enabled = false;
        policyAnimator.SetBool("isOpen", false);
    }

    public void purchasePolicy()
    {
        if (money >= policyCost[openPolicy] && !policyPurchased[openPolicy])
        {
            money += (policyCost[openPolicy] * -1);
            policyPurchased[openPolicy] = true;
            Debug.Log("Purchased Policy " + openPolicy);
        }
    }

    public void activePolicy(int policyNumber)
    {
        openPolicy = policyNumber;
    }
}
