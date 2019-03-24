using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_act : MonoBehaviour {

    // should be self-explanatory
    public static bool is_attacking;
    public static bool took_damage;

    // skeleton defaults are x: 0.067, y: 0.167
    // boss defaults are x: unimplemented, y: unimplemented
    public Vector2 dimensions;

    // 0 is up, 1 is down, 2 is left, 3 is right
    public int move_direction;

    // valuable skelly boy data
    int health;
    public float defaultMoveSpeed;
    public float movespeed;
    public float maxFreezeCoolDown = 0.75f;
    public float freezeCoolDown;
    public bool is_dead;

    int recoil_cooldown;
    int max_recoil_cooldown = 4;

    public float cooldown_max = 4;

    float damage_cooldown;

    int move_cycle = 16;
    int move_cycle_current = 0;
    float[] movespeeds = new float[] {
        0.5f, 0.5f, 0.75f, 1.5f, 1.5f, 0.75f, 0.5f, 0.5f,
        0.5f, 0.5f, 0.75f, 1.5f, 1.5f, 0.75f, 0.5f, 0.5f
    };

    Animator animator;
    Collider2D collider;


    // Use this for initialization
    void Start() {
        is_attacking = false;
        took_damage = false;
        move_direction = 0;

        health = 3;

        recoil_cooldown = 0;
        damage_cooldown = 0;

        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        defaultMoveSpeed = movespeed;
        freezeCoolDown = maxFreezeCoolDown;
    }

    // Update is called once per frame
    void Update() {
        if (static_information.isPaused == false)
        {
            if (!is_dead)
            {
                is_attacking = false;
                took_damage = false;
                //if (static_information.which_room_am_I_in(transform.position.x, transform.position.y) == static_information.room_index)
                //{
                    Vector2 new_position = new Vector2(transform.position.x, transform.position.y);
                    int x_direct = 0, y_direct = 0; float small_float_value = 0.05f;
                    // Zombie is right of hero
                    if (transform.position.x - static_information.hero.transform.position.x > small_float_value)
                    {
                        x_direct = -1;
                        move_direction = 2;
                    }
                    // Zombie is left of hero
                    else if (transform.position.x - static_information.hero.transform.position.x < (-1 * small_float_value))
                    {
                        x_direct = 1;
                        move_direction = 3;
                    }

                    // Zombie is up of hero
                    if (transform.position.y - static_information.hero.transform.position.y > small_float_value)
                    {
                        y_direct = -1;
                        move_direction = 0;
                    }
                    // Zombie is down of hero
                    else if (transform.position.y - static_information.hero.transform.position.y < (-1 * small_float_value))
                    {
                        y_direct = 1;
                        move_direction = 1;
                    }



                    // if neither x_diff nor y_diff are true, we won't change new_position.
                    if (x_direct != 0)
                    {
                        new_position.x += (x_direct) * ((movespeed * movespeeds[++move_cycle_current % move_cycle]) / Mathf.Sqrt(Mathf.Abs(x_direct) + Mathf.Abs(y_direct)));
                    }
                    if (y_direct != 0)
                    {
                        new_position.y += (y_direct) * ((movespeed * movespeeds[++move_cycle_current % move_cycle]) / Mathf.Sqrt(Mathf.Abs(x_direct) + Mathf.Abs(y_direct)));  
                    }

                    //control animator
                    if (y_direct > 0 || x_direct > 0)
                    {
                        animator.SetBool("backWalk", true);
                        animator.SetBool("frontWalk", false);
                        animator.SetBool("facingFront", false);
                    }
                    else if (y_direct < 0 || x_direct < 0)
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

                if(freezeCoolDown > 0)
                {
                    freezeCoolDown -= Time.deltaTime;
                }
                else
                {
                    movespeed = defaultMoveSpeed;
                }

                if (static_information.is_in_bounds(new_position))
                    { transform.position = new_position; }
                //}
                //else
                //{
                //    Debug.Log("Zombie Error");
                //}
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.gray;
                animator.SetBool("frontWalk", false);
                animator.SetBool("backWalk", false);
                animator.SetBool("isDead", true);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 90);
            }
            if (recoil_cooldown > 0)
            {
                recoil_cooldown --;
            }
            if(damage_cooldown > 0)
            {
                damage_cooldown -= Time.deltaTime;
            }
        }
    }

    float distance_to_hero()
    {
        return Mathf.Sqrt(Mathf.Pow(static_information.hero.transform.position.x - transform.position.x, 2) + Mathf.Pow(static_information.hero.transform.position.y - transform.position.y, 2));
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // zombie will attack if it is within 0.05 of the hero
        if (distance_to_hero() <= 0.1f)
        {
            is_attacking = true;
            took_damage = false;
            if(damage_cooldown <= 0)
            {
                static_information.hero.GetComponent<hero_act>().takeDamage();
                damage_cooldown = 1;

                if (animator.GetBool("facingFront"))
                {
                    animator.SetTrigger("frontAttack");
                }
                else
                {
                    animator.SetTrigger("backAttack");
                }
            }
            movespeed = 0;
            freezeCoolDown = maxFreezeCoolDown;
            static_information.heroRigidBody.AddForce((static_information.hero.transform.position - transform.position).normalized * 250f);
            move_direction = -1;
        }
    }

    public void takeDamage()
    {
        if (!is_dead)
        {
            took_damage = true;
            health--;
            is_dead = (health <= 0);

            if (animator.GetBool("facingFront"))
            {
                animator.SetTrigger("frontDamage");
            }
            else
            {
                animator.SetTrigger("backDamage");
            }
            movespeed = 0;
            freezeCoolDown = maxFreezeCoolDown;
            // Debug.Log("Zombie took damage! Health is: " + health);
        }
    }
}
