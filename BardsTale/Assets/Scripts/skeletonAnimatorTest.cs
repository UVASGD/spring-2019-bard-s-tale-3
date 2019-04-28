using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonAnimatorTest : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            animator.SetInteger("walkDir", 1);
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            animator.SetInteger("walkDir", 0);
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            sprite.flipX = false;
            animator.SetInteger("walkDir", 2);
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            sprite.flipX = true;
            animator.SetInteger("walkDir", 2);
            animator.SetBool("isWalking", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("attack");
        }
        else
        {
            animator.ResetTrigger("attack");
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        { 
            animator.SetTrigger("takeDamage");
        }
        else
        {
            animator.ResetTrigger("takeDamage");
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetTrigger("die");
            animator.SetBool("isDead", true);
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            animator.SetBool("isDead", false);
        }
    }
}
