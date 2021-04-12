using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenBox()
    {
        animator.SetBool("isOpen", true);
    }

    public void CloseBox()
    {
        animator.SetBool("isOpen", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
