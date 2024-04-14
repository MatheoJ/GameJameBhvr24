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
        bool isMagicBook = animator.GetBool("isMagicBook");
        float mouseScroll = Input.mouseScrollDelta.y;

        if (!isMagicBook && mouseScroll != 0)
        {
            animator.SetBool("isMagicBook", true);
        }

        if (isMagicBook && mouseScroll == 0)
        {
            animator.SetBool("isMagicBook", false);
        }
    }
}
