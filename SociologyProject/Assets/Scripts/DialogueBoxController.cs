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
    private AudioSource nextSound;
    public DialogueViewer dialogueViewer;

    private Coroutine dialogueCo;
    private bool typingComplete = true;
    private string fullMessage;

    /*void Awake()
    {
        HideAllButtons();
    }*/


    void Start()
    {
        dialogueAnimator = gameObject.GetComponent<Animator>();
        nextSound = gameObject.GetComponent<AudioSource>();
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
        fullMessage = text;
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
        typingComplete = true;

        CloseBox();
    }

    public void Next()
    {
        if (typingComplete)
        {
            dialogueViewer.Next();
        }
        else
        {
            StopCoroutine(dialogueCo);
            textBox.GetComponent<TextMeshProUGUI>().text = fullMessage;
            typingComplete = true;
        }
        PlayNextSound();
    }

    IEnumerator typeText(string text)
    {
        typingComplete = false;
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char c in text.ToCharArray())
        {
            textBox.GetComponent<TextMeshProUGUI>().text += c;
            // https://answers.unity.com/questions/904429/pause-and-resume-coroutine-1.html
            while (GameController.Instance.gamePaused)
            {
                yield return null;
            }
            yield return new WaitForSeconds(.03f);
        }
        typingComplete = true;
    }

    public void PlayNextSound()
    {
        nextSound.Play();
    }
}
