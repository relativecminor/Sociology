using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueViewer : MonoBehaviour
{
    public GameObject textBox;
    public GameObject[] buttons;
    DialogueController dialogueController;
    public PolicyController policyController;
    public CutSceneController cutSceneController;

    /*void Awake()
    {
        HideAllButtons();
    }*/

    // Start is called before the first frame update
    void Start()
    {
        dialogueController = GetComponent<DialogueController>();
        dialogueController.onEnteredNode += OnNodeEntered;
        dialogueController.InitializeDialogue();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNodeEntered(DialogueObject.Node node)
    {

        textBox.GetComponent<TextMeshProUGUI>().text = node.text;

        if (node.tags.Contains("Policy"))
        {
            policyController.OpenPolicy();
        }
        else if (node.tags.Contains("CutScene"))
        {
            cutSceneController.OpenCutScene();
            
        }
        else
        {
            ShowResponses(node.responses);
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

    public void Next()
    {
        OnNodeSelected(0);
    }

    public void ShowResponses(List<DialogueObject.Response> responses)
    {
        for (int i = 0; i < responses.Count; i++)
        {
            Debug.Log(responses[i].displayText);
            buttons[i].GetComponent<Button>().DisplayText(responses[responses.Count - 1 - i].displayText);
            buttons[i].SetActive(true);
        }
    }

    public void HideAllButtons()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
        
    }

    
}
