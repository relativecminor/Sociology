using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PolicyText : MonoBehaviour
{
    public int policyIndex;
    public GameObject policyTextBox;
    private Coroutine dialogueCo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PolicyClicked()
    {
        Debug.Log(policyIndex);
        StartDialogue(PolicyManager.Instance.getPolicyDescription(policyIndex));
        Debug.Log("hey I know the Policy Number: " + policyIndex);
    }

    IEnumerator typeText(string text)
    {
        policyTextBox.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char c in text.ToCharArray())
        {
            policyTextBox.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(.03f);
        }
    }

    public void StartDialogue(string text)
    {;
        StopAllCoroutines(); // REALLY NEED TO FIX THIS BUG OF THE TEXT REPEATING
        //GameController.Instance.StopAllCoroutines();
        dialogueCo = StartCoroutine(typeText(text));
    }

    public void PolicyPurchased()
    {
        //if (GameManager.Instance.getPolicyPurchased(policyNumber))
        if (PolicyManager.Instance.getPolicyPurchased(policyIndex))
        {
            this.GetComponent<Image>().color = Color.white;
        }
    }

}
