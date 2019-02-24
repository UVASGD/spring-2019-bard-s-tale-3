using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : Song
{
    public float speedRatio = 1.05f;
    public float duration = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Play()
    {
        //static_information.hero.GetComponentInChildren<self_spellcast_animation>().castSpell("speed");
        static_information.hero.GetComponentInChildren<speed_handling>().castSpeed(speedRatio, duration);
    }
}
