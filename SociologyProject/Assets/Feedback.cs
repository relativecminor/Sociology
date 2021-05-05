using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Feedback : MonoBehaviour
{
    public DialogueBoxController dialogueBoxController;
    public string text = "feedback";

    public GameObject textBox;
    private Coroutine dialogueCo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void OnMouseEnter()
    {
        StartDialogue(text);
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        HideDialogue();
        
    }*/

    public void StartDialogue()
    {
        if (dialogueCo != null)
        {
            StopCoroutine(dialogueCo);
        }
        dialogueCo = StartCoroutine(typeText(text));
    }

    public void HideDialogue()
    {
        StopCoroutine(dialogueCo);
        textBox.GetComponent<TextMeshProUGUI>().text = "";
    }

    IEnumerator typeText(string text)
    {
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
        
    }
}
