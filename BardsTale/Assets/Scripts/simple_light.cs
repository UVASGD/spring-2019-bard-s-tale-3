using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simple_light : MonoBehaviour {

    public float alpha = 0;
    SpriteRenderer light_renderer;
    bool discoMode = false;
    public float discoR = 0f;
    public float discoG = 0f;
    public float discoB = 0f;
    public float discoSpeed = .005f;
    public int discoColor = 0;
    public float discoMagnitude = 1;
    public float cooldownCoefficient = .001f;

    // Use this for initialization
    void Start () {
        light_renderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        // minimum alpha value = static_information.max_light_level - 15.0f
        // maximum alpha value = static_information.max_light_level

        alpha = (alpha >= static_information.max_light_level - 15.0f)?static_information.max_light_level - 15.0f:
            (alpha + (cooldownCoefficient * static_information.max_light_level));

        if (discoMode == true)
        {
            switch (discoColor)
            {
                case 0: //RED INIT
                    discoR += discoSpeed;
                    if (discoR >= .5)
                    {
                        discoColor=1;
                    }
                    break;
                case 4: //RED
                    discoR += discoSpeed;
                    discoB -= discoSpeed;
                    if (discoR >= .5)
                    {
                        discoColor = 1;
                    }
                    break;
                case 1: //Green
                    discoR -= discoSpeed;
                    discoG += discoSpeed;
                    if (discoG >= .5)
                    {
                        discoColor=2;
                    }
                    break;
                case 2: //Blue
                    discoG -= discoSpeed;
                    discoB += discoSpeed;
                    if (discoB >= .5)
                    {
                        discoColor = 4;
                    }
                    break;
            }

        }
        else
        {
            discoR = 0;
            discoG = 0;
            discoB = 0;
        }
        
        if(alpha > 14)
        {
            discoR = 0;
            discoG = 0;
            discoB = 0;
        }

        light_renderer.color = new Color(discoR * discoMagnitude, discoG * discoMagnitude, discoB * discoMagnitude, alpha/static_information.max_light_level);
	}

    public void addLight()
    {
        if (alpha > 0)

            alpha -= static_information.max_light_level * (alpha / 30f);
    }

    public void addLight(float cooldownCoefficient, bool discoMode, float discoSpeed)
    {
        if (alpha > 0)

            alpha -= static_information.max_light_level * (alpha / 30f);
        this.discoMode = discoMode;
        this.discoSpeed = discoSpeed;
        this.cooldownCoefficient = cooldownCoefficient;
    }
}
