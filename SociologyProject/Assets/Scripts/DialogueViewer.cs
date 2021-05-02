using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using TMPro;
using static DialogueObject;

public class DialogueViewer : MonoBehaviour
{
    public GameObject[] choices;

    public PassageController passageController;
    public PolicyController policyController;
    public CutSceneController cutSceneController;
    public DialogueBoxController dialogueBoxController;
    DialogueController dialogueController;

    
    // Start is called before the first frame update
    void Start()
    {
        dialogueController = GetComponent<DialogueController>();

        dialogueController.onEnteredNode += OnNodeEntered;
        passageController.onEnteredChunk += OnChunkEntered;

        dialogueController.InitializeDialogue();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNodeEntered(Node node)
    {                

        if (node.tags.Contains("Policy"))
        {
            dialogueBoxController.HideDialogue();
            policyController.OpenPolicy();
        }
        else
        {
            passageController.InitializePassage(node);
            
        }

        
    }

    public void OnNodeSelected(int i)
    {
        HideAllChoices();
        dialogueBoxController.dialogueSide.SetActive(true);
        Debug.Log("Player chose option " + i);
        if (!dialogueController.GetCurrentNode().IsEndNode())
        {
            dialogueController.ChooseResponse(i);
        }
        
    }

    public void OnChunkEntered(string chunk)
    {
        
        if (dialogueController.GetCurrentNode().tags.Contains("CutScene"))
        {
            dialogueBoxController.HideDialogue(); //
            cutSceneController.DisplayText(chunk);

            Debug.Log("Entered chunk with text: " + chunk);
        }
        else
        {
            dialogueBoxController.StartDialogue(chunk);
        }
    }

    public void Next()
    {
        if (!passageController.IsEndOfPassagage())
        {
            passageController.Next();
        }
        else
        {
            if (dialogueController.GetCurrentNode().responses.Count > 1)
            {
                
                ShowChoices(dialogueController.GetCurrentNode().responses);
                Debug.Log("Reached responses: ");
                foreach (Response response in dialogueController.GetCurrentNode().responses)
                {
                    Debug.Log(response.displayText);
                }
            }
            else { OnNodeSelected(0); } // Move on to next node


        }
    }

    

    public void ShowChoices(List<Response> responses)
    {
        //HideAllChoices();
        dialogueBoxController.dialogueSide.SetActive(false);
        Assert.IsTrue(choices.Length >= responses.Count);
        for (int i = 0; i < responses.Count; i++)
        {
            //choices[i].GetComponent<Button>().onClick.AddListener(delegate { OnNodeSelected(i); });
            choices[i].SetActive(true);
            choices[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = responses[responses.Count - (i + 1)].displayText;
            
            
        }        
    }

    public void HideAllChoices()
    {
        foreach (GameObject button in choices)
        {
            button.SetActive(false);
        }
        
    }
}
