using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CutSceneController : MonoBehaviour
{
    public GameObject background;
    public GameObject textBox;

    // Start is called before the first frame update
    void Start()
    {
        background.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCutScene()
    {
        background.SetActive(true);
    }

    public void CloseCutScene()
    {
        background.SetActive(false);
    }

    public void DisplayText(string text)
    {
        OpenCutScene();
        Debug.Log("Showing text: " + text);
        textBox.GetComponent<TextMeshProUGUI>().text = text;
    }
}
