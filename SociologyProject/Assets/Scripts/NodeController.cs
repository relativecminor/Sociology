using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController
{
    public DialogueObject.Node currentNode;
    public string[] chunks;
    public int currentIndex;

    public delegate void ChunkEnteredHandler(DialogueObject.Node node);
    public event ChunkEnteredHandler onEnteredChunk;

    public NodeController(DialogueObject.Node node)
    {
        chunks = node.text.Split(new string[] { "\n" }, StringSplitOptions.None);
        currentNode = node;
    }

    public string GetCurrentChunk()
    {
        return chunks[currentIndex];
    }


}