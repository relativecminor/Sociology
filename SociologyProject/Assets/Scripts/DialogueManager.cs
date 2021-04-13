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

    private string[] chapter1Dialogue = new string[2];
    private int currentTextTracker = 0;

    void Start()
    {
        policyCanvas.enabled = false;
        chapter1Dialogue[0] = "As the school year draws to a close and the weather is getting warmer, it's time for School High to select the teacher training programs for the summer.";
        chapter1Dialogue[1] = "As the education coordinator for your district the selection falls on your hands, and there are a couple factors to consider";
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
        policyAnimator.SetBool("isOpen", true);
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
