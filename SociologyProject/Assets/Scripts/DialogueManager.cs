using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public Animator dialogueAnimator;
    public Animator policyAnimator;
    public Canvas dialogueCanvas;
    public Canvas policyCanvas;

    void Start()
    {
        policyCanvas.enabled = false;
    }

    public void OpenBox()
    {
        dialogueAnimator.SetBool("isOpen", true);
    }

    public void CloseBox()
    {
        dialogueAnimator.SetBool("isOpen", false);
    }

    public void OpenPolicy()
    {
        dialogueCanvas.enabled = false;
        policyCanvas.enabled = true;
        policyAnimator.SetBool("isOpen", true);
    }

    public void ClosePolicy()
    {
        dialogueCanvas.enabled = true;
        policyCanvas.enabled = false;
        policyAnimator.SetBool("isOpen", false);
    }

}
