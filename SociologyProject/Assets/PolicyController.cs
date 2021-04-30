using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyController : MonoBehaviour
{
    public Animator policyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPolicy()
    {
        gameObject.SetActive(true);
        policyAnimator.SetBool("isOpen", true);
    }

    public void ClosePolicy()
    {
        gameObject.SetActive(false);
        policyAnimator.SetBool("isOpen", false);
    }

}
