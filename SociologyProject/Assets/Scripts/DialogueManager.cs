using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Canvas mainMenu;
    
    public Animator dialogueAnimator;
    public Animator policyAnimator;
    public Canvas dialogueCanvas;
    public Canvas policyCanvas;

    private Coroutine dialogueCo;
    public GameObject dialogueBox;
    public GameObject textBox;

    public Canvas schoolPolicyCanvas;
    //public Animator schoolPolicyAnimator;

    public Canvas cutScene;
    public GameObject cutSceneDialogue;
    private string[] cutSceneText = new string[2];
    private int cutSceneTextTracker = 0;

    private string[] chapter1Dialogue = new string[5];
    private int currentTextTracker = 0;

    void Start()
    {
        mainMenu.enabled = true;
        policyCanvas.enabled = false;
        dialogueCanvas.enabled = false;
        schoolPolicyCanvas.enabled = false;
        cutScene.enabled = false;
        
    }

    public void playGame()
    {
        dialogueCanvas.enabled = true;
        mainMenu.enabled = false; 
        chapter1Dialogue[0] = "Hello and Welcome to GAME NAME. You will be playing as the government and as the superintendent of a school. You will be makigng decisions that have a lot of impact.";
        chapter1Dialogue[1] = "Use the policy menu to discover policies that you can pass as the government. Be careful, you must have enough money to buy and inact the policy";
        chapter1Dialogue[2] = "Also be weary of its effect on students in the school system. Some policies can have devestating effects on the student population";
        chapter1Dialogue[3] = "As the school year draws to a close and the weather is getting warmer, it's time for School High to select the teacher training programs for the summer.";
        chapter1Dialogue[4] = "As the education coordinator for your district the selection falls on your hands, and there are a couple factors to consider";
    }

    public void pauseGame()
    {
        mainMenu.enabled = true;
        policyCanvas.enabled = false;
        dialogueCanvas.enabled = false;
        schoolPolicyCanvas.enabled = false;
        cutScene.enabled = false;
    }
    public void OpenBox()
    {
        dialogueAnimator.SetBool("isOpen", true);
        StartDialogue(chapter1Dialogue[currentTextTracker]);
    }

    public void openboxcutscene()
    {
        dialogueAnimator.SetBool("isOpen", true);
        StartDialogue(cutSceneText[cutSceneTextTracker]);
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

    public void NextTextcutscene()
    {
        if (cutSceneTextTracker != cutSceneText.Length - 1)
        {
            cutSceneTextTracker++;
            openboxcutscene();
        }
    }

    public void OpenPolicy()
    {
        dialogueCanvas.enabled = false;
        policyCanvas.enabled = true;
        schoolPolicyCanvas.enabled = false;
        cutScene.enabled = false;
        policyAnimator.SetBool("isOpen", true);
    }
    public void openSchoolPolicy()
    {
        dialogueCanvas.enabled = false;
        policyCanvas.enabled = false;
        schoolPolicyCanvas.enabled = true;
        cutScene.enabled = false;
        //schoolPolicyAnimator.SetBool("isOpen", true);
    }

    public void openCutScene()
    {
        dialogueCanvas.enabled = false;
        policyCanvas.enabled = false;
        schoolPolicyCanvas.enabled = false;
        cutScene.enabled = true;
        cutSceneText[0] = "Hey you guys";
        cutSceneText[1] = "Thought I would give you an update";
        policyAnimator.SetBool("isOpen", true);

    }


    public void ClosePolicy()
    {
        dialogueCanvas.enabled = true;
        policyCanvas.enabled = false;
        schoolPolicyCanvas.enabled = false;
        cutScene.enabled = false;
        policyAnimator.SetBool("isOpen", false);
    }

    public void StartDialogue(string text)
    {
        if (dialogueCo != null) {
           StopCoroutine(dialogueCo);
        }
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
