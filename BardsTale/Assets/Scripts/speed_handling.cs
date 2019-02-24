using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class speed_handling : MonoBehaviour {

    public bool am_sped_up;
    int speed_counter;
    public int speed_counter_max;

    public string path;
    public int animation_counter; 
    private Sprite[] spritesList;
    private SpriteRenderer r;

    public Stopwatch timer = new Stopwatch();
    public float speedRatio = 1.0f;
    public float speedDuration = 25.0f;
    public float timeUsed = 0;


	// Use this for initialization
	void Start () {
        am_sped_up = false;
        speed_counter = 0;

        spritesList = Resources.LoadAll<Sprite>(path);
        r = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        timeUsed = timer.ElapsedMilliseconds;
        /*if (speed_counter > 0)
        {
            speed_counter--;

            r.sprite = spritesList[animation_counter++ % spritesList.Length];
        }
        else
        {
            if (am_sped_up && timer.ElapsedMilliseconds > speedDuration*1000)
            {
                throttleDown();
                r.sprite = null;
            }
        }*/
        if (am_sped_up)
        {
            r.sprite = spritesList[animation_counter++ % spritesList.Length];
            if (timer.ElapsedMilliseconds > speedDuration * 1000)
            {
                throttleDown();
                r.sprite = null;

            }   
        }
    }

    public void castSpeed()
    {
        if (!am_sped_up)
        {
            static_information.hero.GetComponent<hero_move>().speed += 0.02f;
            speed_counter = speed_counter_max;
        }
    }

    public void castSpeed(float ratio, float duration)
    {
        if (!am_sped_up)
        {
            speedRatio = ratio;
            speedDuration = duration;
            static_information.hero.GetComponent<hero_move>().speed*=speedRatio;
            speed_counter = speed_counter_max;
            timer.Start();
            am_sped_up = true;
        }
    }

    void throttleDown()
    {
        static_information.hero.GetComponent<hero_move>().speed/=speedRatio;
        r.sprite = null;
        animation_counter = 0;
        timer.Stop();
        timer.Reset();
        am_sped_up = false;
    }
}
