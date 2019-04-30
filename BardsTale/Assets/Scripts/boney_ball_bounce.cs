using UnityEngine;
using System.Collections;

public class boney_ball_bounce : MonoBehaviour
{
    public int collide_count = 0;
    public GameObject Skeleton;
    public float damage_cooldown = 0;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col != null && col.gameObject.tag == "Room")
        {
            collide_count++;
            if (collide_count == 3)
            {
                Debug.Log("Uhhhhhhhh :^)");//Destroy(gameObject); will destroy the ball
                var skelly = Instantiate(Skeleton, new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y), Quaternion.identity);
                skelly.GetComponent<SpriteRenderer>().sortingLayerName = "Moreground";
                Destroy(this.gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Hero")
        {
            // skeleton will attack if it is within 0.1 of the hero
            if (damage_cooldown > 0)
            {
                damage_cooldown--;
            }
            else
            {
                static_information.hero.GetComponent<hero_act>().takeDamage();
                damage_cooldown = 1;
            }

            static_information.heroRigidBody.AddForce((static_information.hero.transform.position - transform.position).normalized * 250f);
        }
    }
}
