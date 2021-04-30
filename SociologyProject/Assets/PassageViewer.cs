using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageViewer : MonoBehaviour
{
    public PassageController passageController;
    public CutSceneController cutSceneController;

    // Start is called before the first frame update
    void Start()
    {
        passageController.onEnteredChunk += OnChunkEntered;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChunkEntered(string chunk)
    {
        //textBox.GetComponent<TextMeshProUGUI>().text = chunk;
        cutSceneController.DisplayText(chunk);
    }

    public void Next()
    {
        if (!passageController.IsEndOfPassagage())
        {
            passageController.Next();
        }

    }
}
