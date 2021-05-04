using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBoxController : MonoBehaviour
{
    //public Animator dialogueAnimator;
    private Animator dialogueAnimator;

    public GameObject dialogueSide;
    public GameObject choiceSide;
    public GameObject dialogueBox;
    public GameObject textBox;
    public GameObject policyButton;

    private Coroutine dialogueCo;

    /*void Awake()
    {
        HideAllButtons();
    }*/


    void Start()
    {
        dialogueAnimator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        
    }    

    public void OpenBox()
    {
        dialogueAnimator.SetBool("isOpen", true);
        
    }

    public void CloseBox()
    {
        dialogueAnimator.SetBool("isOpen", false);
    }

    public void StartDialogue(string text)
    {
        OpenBox();
        if (dialogueCo != null)
        {
            StopCoroutine(dialogueCo);
        }
        dialogueCo = StartCoroutine(typeText(text));
    }

    public void HideDialogue()
    {
        StopCoroutine(dialogueCo);
        CloseBox();
    }

    

    IEnumerator typeText(string text)
    {
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char c in text.ToCharArray())
        {
            textBox.GetComponent<TextMeshProUGUI>().text += c;
            // https://answers.unity.com/questions/904429/pause-and-resume-coroutine-1.html
            while (GameController.Instance.gamePaused) {
                yield return null;
            }
            yield return new WaitForSeconds(.03f);
        }

    }
}
