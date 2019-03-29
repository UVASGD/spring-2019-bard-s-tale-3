using UnityEngine;
using System.Collections;

public class boney_ball_bounce : MonoBehaviour
{
    public int collide_count = 0;
    public GameObject Skeleton;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col != null && col.gameObject.tag == "Room")
        {
            collide_count++;
            if (collide_count == 3)
            {
                Debug.Log("Uhhhhhhhh :^)");//Destroy(gameObject); will destroy the ball
                Instantiate(Skeleton, new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y), Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
