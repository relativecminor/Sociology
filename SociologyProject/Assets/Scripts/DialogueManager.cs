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

    void Start()
    {
        policyCanvas.enabled = false;
    }

    public void OpenBox()
    {
        dialogueAnimator.SetBool("isOpen", true);
        StartDialogue("This is merely a test to determine the effectiveness of this method. To use elsewhere, use StartDialogue in DialogueManager.");
    }

    public void CloseBox()
    {
        dialogueAnimator.SetBool("isOpen", false);
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
