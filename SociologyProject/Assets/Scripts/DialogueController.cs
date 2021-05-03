// Courtesy of Matthew Ventures
// http://www.mrventures.net/all-tutorials/converting-a-twine-story-to-unity

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialogueObject;

public class DialogueController : MonoBehaviour
{

    [SerializeField] TextAsset[] chapters;
    Dialogue curDialogue;
    Node curNode;
    int curChapterIndex;

    public delegate void NodeEnteredHandler(Node node);
    public event NodeEnteredHandler onEnteredNode;

    public Node GetCurrentNode()
    {
        return curNode;
    }

    public void InitializeDialogue(TextAsset chapter)
    {
        curDialogue = new Dialogue(chapter);
        curNode = curDialogue.GetStartNode();
        onEnteredNode(curNode);
    }

    public void StartDialogue()
    {
        // TODO: Add assertion
        curChapterIndex = 0;
        InitializeDialogue(chapters[curChapterIndex]);
    }

    public void NextChapter()
    {
        if (curChapterIndex < chapters.Length - 1)
        {
            InitializeDialogue(chapters[++curChapterIndex]);
        }
        
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
}