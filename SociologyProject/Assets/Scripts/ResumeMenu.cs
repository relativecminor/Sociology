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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!canvas.enabled)
            {
                canvas.enabled = true;
            }
            else
            {
                canvas.enabled = false;
            }
        }

        
    }

    public void Menu()
    {
        StartCoroutine(GameManager.Instance.LoadYourAsyncScene("MainMenu"));
    }

}
