using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBook : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isPageRight = animator.GetBool("isPageRight");
        float mouseScroll = Input.mouseScrollDelta.y;
        bool isPageLeft = animator.GetBool("isPageLeft");

        if (!isPageRight && mouseScroll > 0)
        {
            animator.SetBool("isPageRight", true);
        }

        if (isPageRight && mouseScroll == 0)
        {
            animator.SetBool("isPageRight", false);
        }

        if (!isPageLeft && mouseScroll < 0)
        {
            animator.SetBool("isPageLeft", true);
        }

        if (isPageLeft && mouseScroll == 0)
        {
            animator.SetBool("isPageLeft", false);
        }
    }
}
