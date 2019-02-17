using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero_move : MonoBehaviour {

    public float speed;

    // 0 is up, 1 is left, 2 is down, 3 is right
    public int moveDir;

    private Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        moveDir = 0;
	}
	
	// Update is called once per frame
	void Update () {
        checkMoves();
	}

    void setMovementVariables(bool backWalk, bool frontWalk, bool leftWalk, bool rightWalk)
    {
        animator.SetBool("isBackWalk", backWalk);
        animator.SetBool("isFrontWalk", frontWalk);
        animator.SetBool("isLeftWalk", leftWalk);
        animator.SetBool("isRightWalk", rightWalk);
    }

    void checkMoves()
    {
        if (static_information.isPaused == false)
        {
            Vector2 new_position = new Vector2(transform.position.x, transform.position.y);

            // If moving in two directions (diagonally), this equals 2. If moving in one direction (orthogonally), this equals 1.
            // If not moving, this equals 0, which might indicate that we could divide by 0, but we can't.
            int count_effective_moves =
                ((Input.GetKey(static_information.controls[0]) || Input.GetKey(static_information.controls[2])) ? 1 : 0) +
                ((Input.GetKey(static_information.controls[1]) || Input.GetKey(static_information.controls[3])) ? 1 : 0);

            // sqrt(2) means speed is same everywhere, since a 45 degree (diagonal) line is speed times sqrt(2)
            if (Input.GetKey(static_information.controls[0])) // up
            {
                setMovementVariables(true, false, false, false);
                new_position.y += speed / Mathf.Sqrt(count_effective_moves);
                moveDir = 0;
            }
            else if (Input.GetKey(static_information.controls[2])) // down
            {
                setMovementVariables(false, true, false, false);
                new_position.y -= speed / Mathf.Sqrt(count_effective_moves);
                moveDir = 2;
            }
            else if (Input.GetKey(static_information.controls[1])) // left
            {
                setMovementVariables(false, false, true, false);
                new_position.x -= speed / Mathf.Sqrt(count_effective_moves);
                moveDir = 1;
            }
            else if (Input.GetKey(static_information.controls[3])) // right
            {
                setMovementVariables(false, false, false, true);
                new_position.x += speed / Mathf.Sqrt(count_effective_moves);
                moveDir = 3;
            }
            else
            {
                setMovementVariables(false, false, false, false);
            }

            // Debug.Log("Move Direction: " + moveDir);

            //if (static_information.is_in_bounds(new_position))
            //{
            //    transform.position = new_position;
            //    static_information.hero.transform.position = transform.position;
            //}
            //else
            //{
            //     Debug.Log("Hit a wall!");
            //}
        }
    }
}
