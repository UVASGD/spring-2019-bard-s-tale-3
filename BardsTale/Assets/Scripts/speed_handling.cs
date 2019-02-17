using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed_handling : MonoBehaviour {
    bool am_sped_up;
    int speed_counter;
    public int speed_counter_max;
    float V = .03f;

    public string path;
    public int animation_counter; 
    private Sprite[] spritesList;
    private SpriteRenderer r;

	// Use this for initialization
	void Start () {
        am_sped_up = false;
        speed_counter = 0;
   
        spritesList = Resources.LoadAll<Sprite>(path);
        r = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

            if (speed_counter > 0 && animation_counter < 500)
            {
            
                speed_counter--;

                r.sprite = spritesList[animation_counter++ % spritesList.Length];
            }
            else
            {
            r.sprite = null;
            static_information.hero.GetComponent<hero_move>().speed = V;
            animation_counter = 0;
            if (am_sped_up)
                {
                    throttleDown();
                    r.sprite = null;
                }
            }
        
	}

    public void castSpeed()
    {
        


            if(!am_sped_up)
            {
                 static_information.hero.GetComponent<hero_move>().speed+=0.02f; speed_counter = speed_counter_max;
              
            }

         
    }
    void throttleDown()
    {
        static_information.hero.GetComponent<hero_move>().speed -= 0.08f;
        r.sprite = null;
        animation_counter = 0;
    }
}
