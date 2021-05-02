using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static DialogueObject;

public class DialogueViewer : MonoBehaviour
{
    public GameObject textBox;
    public GameObject[] buttons;
    DialogueController dialogueController;
    public PassageController passageController;
    public PolicyController policyController;
    public CutSceneController cutSceneController;
    public DialogueBoxController dialogueBoxController;

    /*void Awake()
    {
        HideAllButtons();
    }*/

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

        textBox.GetComponent<TextMeshProUGUI>().text = node.text;

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
        HideAllButtons();

        if (!dialogueController.GetCurrentNode().IsEndNode())
        {
            dialogueController.ChooseResponse(i);
        }
        
    }

    public void OnChunkEntered(string chunk)
    {
        //textBox.GetComponent<TextMeshProUGUI>().text = chunk;
        if (dialogueController.GetCurrentNode().tags.Contains("CutScene"))
        {
            dialogueBoxController.HideDialogue(); //
            cutSceneController.gameObject.SetActive(true);
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
            // Move on to next node
            OnNodeSelected(0);
        }
    }

    /*public void ShowResponses(List<Response> responses)
    {
        for (int i = 0; i < responses.Count; i++)
        {
            Debug.Log(responses[i].displayText);
            buttons[i].GetComponent<Button>().DisplayText(responses[responses.Count - 1 - i].displayText);
            buttons[i].SetActive(true);
        }
    }*/

    public void HideAllButtons()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
        
    }

    
}
