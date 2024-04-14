using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimation : MonoBehaviour
{
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool isTurnPage = animator.GetBool("isTurnPage");
        bool isClick = animator.GetBool("isClick");
        bool forwardPressed = Input.GetMouseButtonDown(0);
        float mouseScroll = Input.mouseScrollDelta.y;

        if (!isClick && forwardPressed)
        {
            animator.SetBool("isClick", true);
        }

        if (isClick && !forwardPressed)
        {
            animator.SetBool("isClick", false);
        }

        if (!isTurnPage && mouseScroll != 0)
        {
            animator.SetBool("isTurnPage", true);
        }

        if (isTurnPage && mouseScroll == 0)
        {
            animator.SetBool("isTurnPage", false);
        }
    }
}
