// Courtesy of Matthew Ventures
// http://www.mrventures.net/all-tutorials/converting-a-twine-story-to-unity

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialogueObject;

public class DialogueController : MonoBehaviour
{

    //[SerializeField] TextAsset[] chapters;
    //[SerializeField] TextAsset twineText;
    //public GameObject[] backgrounds;
    Dialogue curDialogue;
    Node curNode;
    string delimeter = "\r\n";
    public bool macLineEndings = false;


    public delegate void NodeEnteredHandler(Node node);
    public event NodeEnteredHandler onEnteredNode;

    public Node GetCurrentNode()
    {
        return curNode;
    }

    public void InitializeDialogue(TextAsset twineText)
    {
        if (macLineEndings) { delimeter = "\n"; }
        curDialogue = new Dialogue(twineText, delimeter);
        curNode = curDialogue.GetStartNode();
        onEnteredNode(curNode);
    }    

    public List<Response> GetCurrentResponses()
    {
        return curNode.responses;
    }

    public void ChooseResponse(int responseIndex)
    {
        string nextNodeID = curNode.responses[responseIndex].destinationNode;
        Node nextNode = curDialogue.GetNode(nextNodeID);
        curNode = nextNode;
        onEnteredNode(nextNode);
    }

    public void UpdateDialogue()
    {
        Response newResponse = new Response();
        newResponse.displayText = "Next";
        newResponse.destinationNode = "UniformB";
        curDialogue.GetNode("Policy").responses[0] = newResponse;
    }

    public Dialogue GetCurrentDialogue()
    {
        return curDialogue;
    }
}