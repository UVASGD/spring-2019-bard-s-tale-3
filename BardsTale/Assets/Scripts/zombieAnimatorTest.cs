using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieAnimatorTest : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") > 0 || Input.GetAxis("Horizontal") > 0)
        {
            animator.SetBool("backWalk", true);
            animator.SetBool("frontWalk", false);
            animator.SetBool("facingFront", false);
        }
        else if(Input.GetAxis("Vertical") < 0 || Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("frontWalk", true);
            animator.SetBool("backWalk", false);
            animator.SetBool("facingFront", true);
        }
        else
        {
            animator.SetBool("frontWalk", false);
            animator.SetBool("backWalk", false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(animator.GetBool("facingFront"))
            {
                animator.SetTrigger("frontAttack");
            }
            else
            {
                animator.SetTrigger("backAttack");
            }
        }
        else
        {
            animator.ResetTrigger("backAttack");
            animator.ResetTrigger("frontAttack");
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            if (animator.GetBool("facingFront"))
            {
                animator.SetTrigger("frontDamage");
            }
            else
            {
                animator.SetTrigger("backDamage");
            }
        }
        else
        {
            animator.ResetTrigger("backDamage");
            animator.ResetTrigger("frontDamage");
        }
    }
}
