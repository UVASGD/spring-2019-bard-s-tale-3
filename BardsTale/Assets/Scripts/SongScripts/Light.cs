﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : Song
{

    void Awake()
    {
    }

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
        static_information.hero.GetComponentInChildren<self_spellcast_animation>().castSpell("light");
        int room = static_information.which_room_am_I_in(static_information.hero.transform.position.x, static_information.hero.transform.position.y);
        string light_id = "light_machine (" + room + ")";
        GameObject light_machine = GameObject.Find(light_id);
        light_machine.GetComponent<simple_light>().addLight();
    }
}
