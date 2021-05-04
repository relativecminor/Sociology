using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeMenu : MonoBehaviour
{
    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    public void Menu()
    {
        StartCoroutine(GameManager.Instance.LoadYourAsyncScene("MainMenu"));
    }

}
