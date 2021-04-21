using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public Animator dialogueAnimator;
    public Animator policyAnimator;
    public Canvas dialogueCanvas;
    public Canvas policyCanvas;

    private Coroutine dialogueCo;
    public GameObject dialogueBox;
    public GameObject textBox;

    public Canvas schoolPolicyCanvas;
    //public Animator schoolPolicyAnimator;

    private string[] chapter1Dialogue = new string[5];
    private int currentTextTracker = 0;

    void Start()
    {
        policyCanvas.enabled = false;
        schoolPolicyCanvas.enabled = false;
        chapter1Dialogue[0] = "Hello and Welcome to GAME NAME. You will be playing as the government and as the superintendent of a school. You will be makigng decisions that have a lot of impact.";
        chapter1Dialogue[1] = "Use the policy menu to discover policies that you can pass as the government. Be careful, you must have enough money to buy and inact the policy";
        chapter1Dialogue[2] = "Also be weary of its effect on students in the school system. Some policies can have devestating effects on the student population";
        chapter1Dialogue[3] = "As the school year draws to a close and the weather is getting warmer, it's time for School High to select the teacher training programs for the summer.";
        chapter1Dialogue[4] = "As the education coordinator for your district the selection falls on your hands, and there are a couple factors to consider";
    }

    public void OpenBox()
    {
        dialogueAnimator.SetBool("isOpen", true);
        StartDialogue(chapter1Dialogue[currentTextTracker]);
    }

    public void CloseBox()
    {
        dialogueAnimator.SetBool("isOpen", false);
    }

    public void NextText()
    {
        if (currentTextTracker != chapter1Dialogue.Length-1)
        {
            currentTextTracker++;
            OpenBox();
        }
    }

    public void OpenPolicy()
    {
        dialogueCanvas.enabled = false;
        policyCanvas.enabled = true;
        schoolPolicyCanvas.enabled = false;
        policyAnimator.SetBool("isOpen", true);
    }
    public void openSchoolPolicy()
    {
        dialogueCanvas.enabled = false;
        policyCanvas.enabled = false;
        schoolPolicyCanvas.enabled = true;
        //schoolPolicyAnimator.SetBool("isOpen", true);
    }


    public void ClosePolicy()
    {
        dialogueCanvas.enabled = true;
        policyCanvas.enabled = false;
        policyAnimator.SetBool("isOpen", false);
    }

    public void StartDialogue(string text)
    {
        StopAllCoroutines();
        dialogueCo = StartCoroutine(typeText(text));
    }

    public void HideDialogue()
    {
        StopCoroutine(dialogueCo);
    }

    IEnumerator typeText(string text)
    {
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char c in text.ToCharArray())
        {
            textBox.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(.03f);
        }
    }


}
