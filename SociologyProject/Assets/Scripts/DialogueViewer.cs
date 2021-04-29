using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueViewer : MonoBehaviour
{
    public GameObject textBox;
    public GameObject[] buttons;
    public GameObject nextButton;
    DialogueController dialogueController;
    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        dialogueController = GetComponent<DialogueController>();
        dialogueController.onEnteredNode += OnNodeEntered;
        dialogueController.InitializeDialogue();
        HideAllButtons();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNodeEntered(DialogueObject.Node node)
    {
        if (dialogueController.GetCurrentNode().tags.Contains("Policy"))
        {
            Debug.Log("ShowPolicy");
        }
        textBox.GetComponent<TextMeshProUGUI>().text = dialogueController.GetCurrentNode().text;
        //DisplayButtons(dialogueController.GetCurrentNode().responses);
    }

    public void OnNodeSelected(int i)
    {
        //HideAllButtons();
        if (!dialogueController.GetCurrentNode().IsEndNode())
        {
            dialogueController.ChooseResponse(i);
        }
        
    }

    /*public void DisplayButtons(List<DialogueObject.Response> responses)
    {
        if (responses.Count < 2)
        {
            nextButton.SetActive(true);
            
        }
        else
        {
            for (int i = 0; i < responses.Count; i++)
            {
                buttons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = responses[i].displayText;
                buttons[i].SetActive(true);
            }
        }
    }*/

    public void HideAllButtons()
    {
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
        nextButton.SetActive(false);
    }
}
