using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PolicyText : MonoBehaviour
{

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

    public void PolicyClicked(int policyNumber)
    {
        StartDialogue(GameManager.Instance.getPolicyDescription(policyNumber));
        Debug.Log("hey I know the Policy Number: " + policyNumber);
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
    {
        StopAllCoroutines();
        dialogueCo = StartCoroutine(typeText(text));
    }

    public void PolicyPurchased(int policyNumber)
    {
        if (GameManager.Instance.getPolicyPurchased(policyNumber))
        {
            this.GetComponent<Image>().color = Color.white;
        }
    }

}
